import { Container } from './styles';
import { FaTrash } from 'react-icons/fa';
import { MdModeEdit } from 'react-icons/md';
import { useAgenda } from '../../hooks/useAgenda';
import { ReactNode } from 'react';

import { Agenda } from '../../hooks/useAgenda';

export function AgendaTable() {
	const { agendas } = useAgenda();

	function handleDeleteAgenda(agenda: Agenda) {}
	function handleOpenEditAgenda(agenda: Agenda) {}
	function handleOpenDetailAgenda(agenda: Agenda) {}

	return (
		<Container>
			<table>
				<tbody>
					{agendas.map((agenda, index, array) => {
						const today = new Date();
						today.setHours(0, 0, 0, 0);

						const tomorow = new Date();
						tomorow.setHours(0, 0, 0, 0);
						tomorow.setDate(today.getDate() + 1);

						const date = new Date(agenda.date);
						date.setHours(0, 0, 0, 0);

						let line: ReactNode = null;

						if (
							index === 0 ||
							(array[index - 1] && agenda.date !== array[index - 1].date)
						) {
							line = (
								<tr className='subTitleDay'>
									<td colSpan={4}>
										{today.getTime() === date.getTime()
											? 'Hoje - '
											: tomorow.getTime() === date.getTime()
											? 'Amanhã - '
											: ''}
										{date.toLocaleDateString('pt-BR')}
									</td>
								</tr>
							);
						}

						line = (
							<>
								{line}
								<tr
									key={agenda.id}
									onClick={() => {
										handleOpenDetailAgenda(agenda);
									}}
								>
									<td>{agenda.id}</td>
									<td>
										{agenda.initial_hour.slice(0, 5)} -{' '}
										{agenda.final_hour.slice(0, 5)}h
									</td>
									<td>
										<p className='title'>{agenda.title}</p>
										<p className='description'>
											{agenda.description}
										</p>
									</td>
									<td>
										<button
											onClick={() => {
												handleOpenEditAgenda(agenda);
											}}
										>
											<MdModeEdit />
										</button>
										<button
											style={{
												color: 'var(--white)',
												background: 'var(--red)',
											}}
											onClick={() => {
												handleDeleteAgenda(agenda);
											}}
										>
											<FaTrash />
										</button>
									</td>
								</tr>
							</>
						);
						return line;
					})}

					{agendas.length <= 0 ? (
						<tr className='emptyWarning'>
							<td colSpan={4}>Nenhum agendamento encontrado.</td>
						</tr>
					) : null}
				</tbody>
			</table>
		</Container>
	);
}
