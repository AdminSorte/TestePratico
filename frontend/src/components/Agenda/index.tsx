import { Container, Content, FilterContainer, InputGroup } from './styles';
import { AgendaTable } from '../AgendaTable';
import { FormEvent, useState } from 'react';
import { useAgenda } from '../../hooks/useAgenda';

interface AgendaFilterParams {
	description?: string;
	initialDate?: number;
	finalDate?: number;
}

export function Agenda() {
	const { getAgendas } = useAgenda();

	const [descriptionFilter, setDescriptionFilter] = useState('');
	const [initialDateFilter, setInitialDateFilter] = useState('');
	const [finalDateFilter, setFinalDateFilter] = useState('');

	function handleFilterList(event: FormEvent) {
		event.preventDefault();

		const filterParams = {} as AgendaFilterParams;

		if (descriptionFilter) {
			filterParams.description = descriptionFilter;
		}

		if (initialDateFilter) {
			filterParams.initialDate = new Date(initialDateFilter).getTime();
		}

		if (finalDateFilter) {
			filterParams.finalDate = new Date(finalDateFilter).getTime();
		}

		getAgendas(filterParams);
	}

	return (
		<Container>
			<Content>
				<FilterContainer>
					<p>Filtros:</p>
					<form onSubmit={handleFilterList}>
						<InputGroup>
							<input
								type='text'
								placeholder='Descrição'
								value={descriptionFilter}
								onChange={(e) => setDescriptionFilter(e.target.value)}
							/>
						</InputGroup>
						<InputGroup>
							<input
								type='date'
								value={initialDateFilter}
								onChange={(e) => setInitialDateFilter(e.target.value)}
							/>
							<span>até</span>
							<input
								type='date'
								value={finalDateFilter}
								onChange={(e) => setFinalDateFilter(e.target.value)}
							/>
						</InputGroup>
						<button>Filtrar</button>
					</form>
				</FilterContainer>
				<AgendaTable />
			</Content>
		</Container>
	);
}
