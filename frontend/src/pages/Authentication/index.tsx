import { Container, Form } from './styles';
import { FormEvent, useEffect, useState } from 'react';
import { Link, useHistory } from 'react-router-dom';

import logo from '../../assets/logo.svg';
import { toast } from 'react-toastify';
import api from '../../services/api';
import { setToken } from '../../services/auth';

export function Authentication() {
	const history = useHistory();
	const [currentPath, setCurrentPath] = useState('');

	const [username, setUsername] = useState('');
	const [password, setPassword] = useState('');
	const [passwordAux, setPasswordAux] = useState('');

	useEffect(() => {
		const path = window.location.pathname.replace('/', '');
		setUsername('');
		setPassword('');
		setPasswordAux('');
		setCurrentPath(path);
		document.title = `Minha agenda | ${path}`;
	}, [window.location.pathname]);

	async function handleLogin(event: FormEvent) {
		event.preventDefault();
		const data = {
			username,
			password,
		};
		console.log(data);

		if (!data.username) {
			toast.error('Usuário não informado!');
			return;
		}

		if (!data.password) {
			toast.error('Senha não informada!');
			return;
		}

		try {
			const response = await api.post('session', data);
			if (response.data.error) {
				toast.error(response.data.message);
				return;
			}

			if (response.data.authenticated) {
				setToken(response.data.token).then(() => {
					history.push('/');
				});
			}
		} catch (error) {
			if (error.response?.data?.message) {
				toast.error(error.response.data.message);
				console.error(error.response.data);
			} else {
				toast.error('Erro deconhecido ao realizar login!');
			}
		}
	}

	async function handleSingUp(event: FormEvent) {
		event.preventDefault();
		const data = {
			username,
			password,
		};
		console.log(data);

		if (!data.username) {
			toast.error('Usuário não informado!');
			return;
		}

		if (!data.password) {
			toast.error('Senha não informada!');
			return;
		}

		if (data.password !== passwordAux) {
			toast.error('As senhas informadas não coincidem!');
			return;
		}

		try {
			const response = await api.post('user', data);
			if (response.data.error) {
				toast.error(response.data.message);
				return;
			}

			if (response.data.authenticated) {
				setToken(response.data.token).then(() => {
					history.push('/');
				});
			}
		} catch (error) {
			if (error.response?.data?.message) {
				toast.error(error.response.data.message);
				console.error(error.response.data);
			} else {
				toast.error('Erro deconhecido ao realizar cadastro!');
			}
		}
	}

	return (
		<Container>
			<img src={logo} alt='Minha agenda minha vida' />
			{currentPath === 'entrar' ? (
				<Form onSubmit={handleLogin}>
					<header>
						<h2>Login</h2>
					</header>
					<main>
						<input
							type='text'
							placeholder='Usuário'
							required
							spellCheck={false}
							value={username}
							onChange={(e) => setUsername(e.target.value)}
						/>
						<input
							type='password'
							placeholder='Senha'
							required
							value={password}
							onChange={(e) => setPassword(e.target.value)}
						/>

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
						<input
							type='text'
							required
							placeholder='Usuário'
							spellCheck={false}
							value={username}
							onChange={(e) => setUsername(e.target.value)}
						/>
						<input
							type='password'
							required
							placeholder='Senha'
							value={password}
							onChange={(e) => setPassword(e.target.value)}
						/>
						<input
							type='password'
							required
							placeholder='Repita a senha'
							value={passwordAux}
							onChange={(e) => setPasswordAux(e.target.value)}
						/>

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
