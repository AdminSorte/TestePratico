import styled from 'styled-components';

export const Container = styled.form`
	header {
		background: var(--dark);
		color: var(--yellow);

		margin-bottom: 2rem;
		padding: 1rem 2rem;

		border-radius: 0.3rem 0.3rem 0 0;

		p {
			text-align: center;
			font-size: 1.5rem;
			font-weight: 600;
		}
	}

	main {
		padding: 0rem 2rem;
		input {
			width: 100%;
		}
	}

	footer {
		display: flex;
		align-items: center;
		justify-content: center;
		padding: 1rem 2rem 2rem ;
		button[type='submit'] {
			width: 100%;
			max-width: 300px;

			margin: 0 0.5rem;
			padding: 0 1.5rem;

			height: 3rem;

			background: var(--yellow);
			color: var(--dark-text);

			border-radius: 0.25rem;
			border: 0;

			font-size: 1rem;
			font-weight: 600;
		}
	}
`;

export const InputLine = styled.div`
	display: grid;
	grid-template-columns: 1fr 1fr;
	gap: 0.5rem;
`;
export const InputGroup = styled.div`
	display: flex;
	flex-direction: column;
`;
