// index = lista todas
// show = lista um
// store = criar
// update = alterar
// destroy = remover
import { Request, Response } from 'express';
import connection from '../database/connection';

export class AgendaController {
	async index(req: Request, res: Response) {
		try {
			let whereSql = '';
			let whereValues = [];
			if (req.body && req.body.description) {
				whereSql += ` description like ? `;
				whereValues.push(`%${req.body.description}%`);
			}

			if (req.body && req.body.initialDate) {
				const initial = new Date(req.body.initialDate);
				const initialDate = initial
					.toLocaleDateString('pt-BR')
					.split('/')
					.reverse()
					.join('-');
				const initialTime = initial.toLocaleTimeString('pt-BR');

				whereSql += ` AND date >= ? AND initial_hour >= ?`;
				whereValues.push(initialDate);
				whereValues.push(initialTime);
			}

			if (req.body && req.body.finalDate) {
				const final = new Date(req.body.finalDate);
				const finalDate = final
					.toLocaleDateString('pt-BR')
					.split('/')
					.reverse()
					.join('-');
				const finalTime = final.toLocaleTimeString('pt-BR');

				whereSql += ` AND date <= ? AND final_hour <= ?`;
				whereValues.push(finalDate);
				whereValues.push(finalTime);
			}

			const userId = req.cookies.user.id;

			const agendas = await connection('agenda')
				.where('user_id', userId)
				.andWhereRaw(whereSql, whereValues)
				.select('*');
			console.log(agendas);

			return res.json(agendas);
		} catch {
			return res.status(400).json({
				error: 'inernal_server_error',
				message: 'Erro inesperado! Tente novamente mais tarde!',
			});
		}
	}

	async store(req: Request, res: Response) {
		const { title, date, initial_hour, final_hour, description } = req.body;

		const userId = req.cookies.user.id;

		const scheduled = await checkIfIsScheduled({
			userId,
			date,
			initial_hour,
			final_hour,
		});

		if (!scheduled) {
			const [insertedId] = await connection('agenda').insert({
				title,
				date,
				initial_hour,
				final_hour,
				description,
				user_id: userId,
			});

			const agenda = await connection('agenda')
				.where('id', insertedId)
				.select('*')
				.first();

			return res.json(agenda);
		} else {
			return res.status(409).json({
				error: 'date_already_scheduled',
				message: 'Você ja tem um agendamento para esta data!',
			});
		}
	}

	async update(req: Request, res: Response) {
		const { id, title, date, initial_hour, final_hour, description } = req.body;
		const userId = req.cookies.user.id;

		const scheduled = await checkIfIsScheduled({
			id,
			userId,
			date,
			initial_hour,
			final_hour,
		});

		if (!scheduled) {
			const update = await connection('agenda')
				.update(
					{
						title,
						date,
						initial_hour,
						final_hour,
						description,
						user_id: userId,
					},
					['id']
				)
				.where({ id });

			const agenda = await connection('agenda').where('id', id).select('*').first();

			return res.json(agenda);
		} else {
			return res.status(409).json({
				error: 'date_already_scheduled',
				message: 'Você ja tem um agendamento para esta data!',
			});
		}
	}

	async destroy(req: Request, res: Response) {
		const { id } = req.body;
		const userId = req.cookies.user.id;

		const deleted = await connection('agenda').where({ id }).delete();

		if (deleted > 1) {
			return res.json({ deletedId: id });
		} else {
			return res.status(404).json({
				error: 'agenda_not_found',
				message: 'Não encontramos a agenda!',
			});
		}
	}
}

interface CheckIfIsScheduledParams {
	id?: number;
	userId: number;
	date: string;
	initial_hour: string;
	final_hour: string;
}

async function checkIfIsScheduled({
	id,
	userId,
	date,
	initial_hour,
	final_hour,
}: CheckIfIsScheduledParams) {
	return await connection('agenda')
		.where('date', date)
		.andWhere(function () {
			this.whereRaw('? > initial_hour AND ? < final_hour', [
				initial_hour,
				initial_hour,
			])
				.orWhereRaw('? > initial_hour AND ? < final_hour', [
					final_hour,
					final_hour,
				])
				.orWhereRaw('? = initial_hour AND ? = final_hour', [
					initial_hour,
					final_hour,
				]);
		})
		.andWhere('user_id', userId)
		.andWhereNot('id', id ? id : 0)
		.select('*')
		.first();
}
