// index = lista todas
// show = lista um
// store = criar
// update = alterar
// destroy = remover
import { Request, Response } from 'express';
import connection from '../database/connection';

import { sign } from 'jsonwebtoken';
import bcrypt from 'bcrypt';
require('dotenv-safe').config();

export class SessionController {
	async store(req: Request, res: Response) {
		const data = req.body;
		if (!data.username || !data.password) {
			return res.status(400).json({
				error: 'bad_request',
				message: 'Por favor, informe seus dados corretamente!',
			});
		}

		const user = await connection('users')
			.where('username', data.username)
			.select('*')
			.first();

		if (!user) {
			return res.status(400).json({
				error: 'user_not_found',
				message: 'Ops, parece que você não tem uma conta conosco! Cadastre-se!',
			});
		}

		const isValid = await bcrypt.compare(data.password, user.password);

		if (isValid) {
			const token = sign({ id: user.id }, process.env.SECRET, {
				expiresIn: 86400,
			});
			return res.json({ authenticated: true, token: token });
		} else {
			return res.status(401).json({
				error: 'invalid_password',
				message: 'Ops, Senha Inválida!',
			});
		}
	}
}
