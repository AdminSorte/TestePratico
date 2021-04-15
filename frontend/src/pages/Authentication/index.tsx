import { Container, Form } from './styles';
import { FormEvent, useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

import logo from '../../assets/logo.svg';

export function Authentication() {
	const [currentPath, setCurrentPath] = useState('');

	useEffect(() => {
		const path = window.location.pathname.replace('/', '');
		setCurrentPath(path);
		document.title = `Minha agenda | ${path}`;
	}, [window.location.pathname]);

	function handleLogin(event: FormEvent) {
		event.preventDefault();
		alert('login');
	}

	function handleSingUp() {}

	return (
		<Container>
			<img src={logo} alt='Minha agenda minha vida' />
			{currentPath === 'entrar' ? (
				<Form onSubmit={handleLogin}>
					<header>
						<h2>Login</h2>
					</header>
					<main>
						<input type='text' placeholder='Usuário' spellCheck={false} />
						<input type='password' placeholder='Senha' />

						<button type='submit'>Entrar</button>
					</main>
					<footer>
						<p>Não tem conta?</p>
						<Link to='/cadastro'>Criar conta</Link>
					</footer>
				</Form>
			) : currentPath === 'cadastro' ? (
				<Form onSubmit={handleSingUp}>
					<header>
						<h2>Cadastro</h2>
					</header>
					<main>
						<input type='text' placeholder='Usuário' spellCheck={false} />
						<input type='password' placeholder='Senha' />
						<input type='password' placeholder='Repita a senha' />

						<button type='submit'>Cadastrar-se</button>
					</main>
					<footer>
						<p>Já tem conta?</p>
						<Link to='/entrar'>Entrar</Link>
					</footer>
				</Form>
			) : null}
		</Container>
	);
}
