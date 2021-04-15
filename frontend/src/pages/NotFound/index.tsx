import { Link } from 'react-router-dom';
import { Container } from './styles';

export function NotFound() {
	return (
		<Container>
			<h1>
				Ops! <br />
				Página não encontrada!
			</h1>
			<Link to='/'>Ir para tela inicial</Link>
		</Container>
	);
}
