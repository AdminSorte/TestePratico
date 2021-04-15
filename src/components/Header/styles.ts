import styled from 'styled-components';

export const Container = styled.div`
	display: flex;
	align-items: center;
	justify-content: center;

	height: 8.75rem;

	background: var(--yellow);
`;

export const Content = styled.div`
	display: flex;
	justify-content: space-between;

	width: 100%;
	height: 100%;
	max-width: 1120px;

	color: var(--dark-text);
	img {
		width: 80%;
		max-width: 15rem;
	}

	button {
		display: flex;
		align-items: center;

		height: 2rem;

		padding: 0.5rem 0;
		margin-top: 1rem;

		background: none;
		border: none;

		font-size: 1rem;
		svg {
			margin-left: 0.5rem;
			font-size: 1rem;
		}

		transition: color 0.2s;
		&:hover {
			color: var(--white);
		}
	}
`;
