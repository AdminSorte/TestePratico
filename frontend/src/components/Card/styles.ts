import styled from 'styled-components';

export const Container = styled.div`
	display: flex;
	flex-direction: column;

	justify-content: center;

	background: var(--dark);
	color: var(--white);

	padding: 1.3rem 2rem;
	border-radius: 0.3rem;
	margin: 1rem 0 0 1rem;

	header {
		display: flex;
		align-items: center;

		font-size: 1rem;

		margin: 0.5rem 0;
		svg {
			margin-right: 0.5rem;
		}
	}
	& > p {
		font-size: 1.5rem;
	}

	@media (max-width: 800px) {
		min-width: 70vw;

		&:last-child {
			margin-right: 1rem;
		}
	}
`;
