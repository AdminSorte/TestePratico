import { Container } from './styles';
import { FaTrash } from 'react-icons/fa';
import { MdModeEdit } from 'react-icons/md';

export function AgendaTable() {
	return (
		<Container>
			<table>
				<tbody>
					<tr className='subTitleDay'>
						<td colSpan={4}>Hoje - 19/04/2021</td>
					</tr>
					<tr key={1}>
						<td>1</td>
						<td>10:30 - 11:00h</td>
						<td>
							<p className='title'>
								Este é um titulo para o meu agendamento
							</p>
							<p className='description'>
								Esta é uma breve descrição do meu agendamento Esta é uma
								breve descrição do meu agendamento
							</p>
						</td>
						<td>
							<button>
								<MdModeEdit />
							</button>
							<button
								style={{
									color: 'var(--white)',
									background: 'var(--red)',
								}}
							>
								<FaTrash />
							</button>
						</td>
					</tr>
				</tbody>
			</table>
		</Container>
	);
}
