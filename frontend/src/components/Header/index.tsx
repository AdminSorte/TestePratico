import { Container, Content } from './styles';
import { MdExitToApp } from 'react-icons/md';

import logo from '../../assets/logo.svg';

export function Header() {
	function handleLogOut() {
		alert('Logout');
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
