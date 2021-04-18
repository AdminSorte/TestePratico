// index = lista todas
// show = lista um
// store = criar
// update = alterar
// destroy = remover
import { Request, Response } from 'express';
import connection from '../database/connection';

interface AgendaFilterParams {
	description?: string;
	initialDate?: number;
	finalDate?: number;
}

export class AgendaController {
	async index(req: Request, res: Response) {
		try {
			let whereSql = '';
			let whereValues = [];
			const params = req.query as AgendaFilterParams;

			if (params) {
				if (params.description) {
					whereSql += ` description like ? `;
					whereValues.push(`%${params.description}%`);
				}

				if (params.initialDate) {
					const initial = new Date();
					initial.setTime(params.initialDate);
					initial.setDate(initial.getDate() + 1);

					const initialDate = initial
						.toLocaleDateString('pt-BR')
						.split('/')
						.reverse()
						.join('-');
					console.log(initial.toLocaleDateString('pt-BR'));

					whereSql += ` ${params.description ? 'AND' : ''} date >= ?`;
					whereValues.push(initialDate);
				}

				if (params.finalDate) {
					const final = new Date();
					final.setTime(params.finalDate);
					final.setDate(final.getDate() + 1);
					const finalDate = final
						.toLocaleDateString('pt-BR')
						.split('/')
						.reverse()
						.join('-');

					whereSql += ` ${
						params.description || params.initialDate ? 'AND' : ''
					} date <= ? `;
					whereValues.push(finalDate);
				}
			}
			console.log(whereValues);

			const userId = req.cookies.user.id;

			const agendas = await connection('agenda')
				.where('user_id', userId)
				.andWhereRaw(whereSql, whereValues)
				.select(
					'id',
					'title',
					'date',
					'initial_hour',
					'final_hour',
					'description'
				)
				.orderBy('date');

			return res.json(agendas);
		} catch (err) {
			console.error(err);

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
		const { id } = req.query;
		const userId = req.cookies.user.id;
		console.log(req.query);

		const deleted = await connection('agenda').where({ id }).delete();

		if (deleted >= 1) {
			return res.json({ deletedId: id });
		} else {
			return res.status(404).json({
				error: 'agenda_not_found',
				message: 'Agendamento não encontrado!',
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
