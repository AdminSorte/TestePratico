import { Container, Content } from './styles';
import { Card } from '../Card';

export function Cards() {
	return (
		<Container>
			<Content>
				<Card content='3 Agendamentos' title='19 de Abril de 2021' />
				<Card content='13 Agendamentos' title='Abril de 2021' />
			</Content>
		</Container>
	);
}
