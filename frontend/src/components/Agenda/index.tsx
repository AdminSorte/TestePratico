import { Container, Content, FilterContainer, InputGroup } from './styles';
import { AgendaTable } from '../AgendaTable';

export function Agenda() {
	return (
		<Container>
			<Content>
				<FilterContainer>
					<p>Filtros:</p>
					<div>
						<InputGroup>
							<input type='text' placeholder='Descrição' />
						</InputGroup>
						<InputGroup>
							<input type='datetime-local' placeholder='--/--/----' />
							<span>até</span>
							<input type='datetime-local' placeholder='--/--/----' />
						</InputGroup>
						<button>Filtrar</button>
					</div>
				</FilterContainer>
				<AgendaTable />
			</Content>
		</Container>
	);
}
