import styled from 'styled-components';

export const Container = styled.div`
	height: 100vh;
	display: flex;

	align-items: center;
	justify-content: space-between;

	background: var(--yellow);
	color: var(--dark);

	img {
		flex: 2;
		max-width: 40%;
		margin: auto;
	}

	@media (max-width: 800px) {
		flex-direction: column;

		justify-content: center;

		img {
			max-width: 23rem;
		}

		img,
		form {
			flex: none;
			margin: 2rem auto;
		}
	}
`;

export const Form = styled.form`
	background: var(--background);

	border-radius: 0.3rem;
	margin: 20vh auto;

	width: 90%;
	max-width: 25rem;

	flex: 1;

	header {
		background: var(--dark);
		color: var(--yellow);

		padding: 0.8rem 1rem;
		border-radius: 0.3rem 0.3rem 0 0;

		h2 {
			font-size: 2rem;
			text-align: center;
		}
	}

	main {
		display: flex;
		flex-direction: column;
		padding: 1.5rem 1.75rem 0;

		input {
			height: 3.5rem;
			font-size: 1rem;

			margin: 0.5rem 0;
			padding: 0.5rem 1rem;

			color: var(--light-text);
			background: var(--white);

			border: 0.125rem solid var(--light-border);
			border-radius: 0.3rem;
		}

		button {
			height: 3.5rem;
			font-size: 1.5rem;
			font-weight: 600;

			margin: 1rem 0 0;
			padding: 0.3rem 1rem;

			color: var(--dark-text);
			background: var(--yellow);

			border: none;
			border-radius: 0.3rem;

			transition: filter 0.2s;

			&:hover {
				filter: brightness(0.8);
			}
		}
	}

	footer {
		display: flex;
		flex-direction: column;
		padding: 1.5rem 1.75rem;

		text-align: center;
		p {
			color: var(--light-text);
		}
		a {
			color: var(--dark-text);
			text-decoration: none;
		}
	}
`;
