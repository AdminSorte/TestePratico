import { NextFunction, Request, Response } from 'express';
import { verify } from 'jsonwebtoken';

interface JsonWebToken {
	id: number;
}

export default async (req: Request, res: Response, next: NextFunction) => {
	const token = req.headers.authorization && req.headers.authorization.split(' ')[1];

	if (!token) {
		return res
			.status(401)
			.json({ error: 'missing_token', message: 'Token nao informado!' });
	}

	try {
		//ts-ignore
		const decoded = verify(token, process.env.SECRET) as JsonWebToken;
		req.cookies.user = { id: decoded.id };

		return next();
	} catch (err) {
		return res
			.status(401)
			.json({ error: 'invalid_token', message: 'Token invalido!' });
	}
};
