// index = lista todas
// show = lista um
// store = criar
// update = alterar
// destroy = remover
import { Request, Response } from 'express';
import connection from '../database/connection';
import bcrypt from 'bcrypt';
import { sign } from 'jsonwebtoken';

export class UserController {
	async store(req: Request, res: Response) {
		const { username, password } = req.body;

		let user = await connection('users')
			.where('username', username)
			.select('*')
			.first();

		if (!user) {
			await bcrypt.hash(password, 10).then(async function (hash: string) {
				const [id] = await connection('users').insert({
					username,
					password: hash,
				});
				const token = sign({ id }, process.env.SECRET, {
					expiresIn: 86400,
				});
				return res.json({ authenticated: true, token: token });
			});
		} else {
			return res.status(409).json({
				error: 'user_already_created',
				message: 'Usuário já cadastrado!',
			});
		}
	}
}
