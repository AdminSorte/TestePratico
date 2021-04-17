import { Container, Content } from './styles';
import { Card } from '../Card';
import { useAgenda } from '../../hooks/useAgenda';

export function Cards() {
	const { summary } = useAgenda();

	return (
		<Container>
			<Content>
				<Card
					content={`${
						summary.today === 0 ? 'Nenhum' : summary.today
					} agendamento${summary.today > 1 ? 's' : ''}`}
					title={new Date().toLocaleString('pt-BR', {
						day: 'numeric',
						month: 'long',
						year: 'numeric',
					})}
				/>
				<Card
					content={`${
						summary.month === 0 ? 'Nenhum' : summary.month
					} agendamento${summary.month > 1 ? 's' : ''}`}
					title={new Date().toLocaleString('pt-BR', {
						month: 'long',
						year: 'numeric',
					})}
				/>
			</Content>
		</Container>
	);
}
