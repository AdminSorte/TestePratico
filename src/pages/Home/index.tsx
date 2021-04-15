import { Container } from './styles';
import { Header } from '../../components/Header';
import { Cards } from '../../components/Cards';
import { Agenda } from '../../components/Agenda';

export function Home() {
	return (
		<Container>
			<Header />
			<Cards />
			<Agenda />
		</Container>
	);
}
