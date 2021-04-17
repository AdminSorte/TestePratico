import { Container, Content } from './styles';
import { MdExitToApp } from 'react-icons/md';

import { removeToken } from '../../services/auth';
import logo from '../../assets/logo.svg';

export function Header() {
	async function handleLogOut() {
		await removeToken();
		window.location.href = '/';
	}

	return (
		<Container>
			<Content>
				<img src={logo} alt='Minha agenda minha vida' />

				<button onClick={handleLogOut}>
					Desconectar
					<MdExitToApp />
				</button>
			</Content>
		</Container>
	);
}
