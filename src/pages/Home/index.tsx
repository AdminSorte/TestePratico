import { Container } from './styles';
import { Header } from '../../components/Header';
import { Cards } from '../../components/Cards';

export function Home() {
	return (
		<Container>
			<Header />
			<Cards />
		</Container>
	);
}
