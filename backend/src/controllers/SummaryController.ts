// index = lista todas
// show = lista um
// store = criar
// update = alterar
// destroy = remover
import { Request, Response } from 'express';
import connection from '../database/connection';

export class SummaryController {
	async index(req: Request, res: Response) {
		try {
			const userId = req.cookies.user.id;

			const agendas = await connection('agenda')
				.where('user_id', userId)
				.andWhereRaw('MONTH(initial_hour) = MONTH(NOW())')
				.select(
					'id',
					'title',
					'date',
					'initial_hour',
					'final_hour',
					'description'
				);

			const summary = agendas.reduce(
				(counter, agenda) => {
					const date = new Date(agenda.date);
					const today = new Date();
					if (
						date.toLocaleDateString('pt-BR') ===
						today.toLocaleDateString('pt-BR')
					) {
						counter.today += 1;
					}
					if (
						date.getFullYear() === today.getFullYear() &&
						date.getMonth() === today.getMonth()
					) {
						counter.month += 1;
					}

					return counter;
				},
				{
					today: 0,
					month: 0,
				}
			);

			return res.json(summary);
		} catch (err) {
			console.error(err);

			return res.status(400).json({
				error: 'inernal_server_error',
				message: 'Erro inesperado! Tente novamente mais tarde!',
			});
		}
	}
}
