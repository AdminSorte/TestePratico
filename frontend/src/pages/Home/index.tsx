import { Container } from './styles';
import { Header } from '../../components/Header';
import { Cards } from '../../components/Cards';
import { Agenda } from '../../components/Agenda';
import { AgendaProvider } from '../../hooks/useAgenda';

export function Home() {
	return (
		<AgendaProvider>
			<Container>
				<Header />
				<Cards />
				<Agenda />
			</Container>
		</AgendaProvider>
	);
}
