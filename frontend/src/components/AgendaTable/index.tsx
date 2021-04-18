import { Container } from './styles';
import { FaTrash } from 'react-icons/fa';
import { MdModeEdit } from 'react-icons/md';
import { useAgenda } from '../../hooks/useAgenda';
import { ReactNode } from 'react';
import swal from 'sweetalert2';

import { AgendaData } from '../../hooks/useAgenda';

export function AgendaTable() {
	const {
		agendas,
		handleOpenAgendaModal,
		handleOpenAgendaDetailModal,
		deleteAgenda,
	} = useAgenda();

	function handleDeleteAgenda(agenda: AgendaData) {
		swal.fire({
			title: 'Atenção!',
			text:
				'Você esta prestes a deletar um agendamento, este processo não poderá ser desfeito!',
			icon: 'warning',
			showCancelButton: true,
			cancelButtonColor: 'var(--yellow)',
			cancelButtonText: 'Cancelar',
			confirmButtonColor: 'var(--red)',
			confirmButtonText: 'Deletar!',
		}).then((result) => {
			if (result.isConfirmed) {
				deleteAgenda(agenda);
			}
		});
	}

	function handleOpenEditAgenda(agenda: AgendaData) {
		handleOpenAgendaModal(agenda);
	}

	function handleOpenDetailAgenda(agenda: AgendaData) {
		handleOpenAgendaDetailModal(agenda);
	}

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
								<tr className='subTitleDay' key={date.getTime()}>
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
											onClick={(e) => {
												e.stopPropagation();
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
											onClick={(e) => {
												e.stopPropagation();
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
