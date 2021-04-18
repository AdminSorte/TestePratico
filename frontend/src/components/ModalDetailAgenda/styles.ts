import styled from 'styled-components';

export const Container = styled.div`
	header {
		background: var(--dark);
		color: var(--yellow);

		margin-bottom: 0rem;
		padding: 1rem 2rem;

		border-radius: 0.3rem 0.3rem 0 0;

		p {
			text-align: center;
			font-size: 1.5rem;
			font-weight: 600;
		}
	}

	main {
		display: flex;
		flex-direction: column;

		font-size: 1rem;
		padding: 2rem 2rem 3rem;

		min-height: 430px;

		p {
			&:first-of-type {
				font-size: 1.5rem;
			}
		}

		span {
			display: flex;
			align-items: center;
			color: var(--light-text);
			svg {
				margin-right: 0.3rem;
			}
			&:first-of-type {
				margin-bottom: 1rem;
			}
		}
	}

	footer {
		display: flex;
		align-items: center;
		justify-content: center;
		padding: 1rem 2rem 2rem;
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
