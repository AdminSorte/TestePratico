import styled from 'styled-components';

export const Container = styled.div`
	display: flex;
	flex-direction: column;

	align-items: center;
	justify-content: center;

	height: 100vh;
	width: 100vw;

	background: var(--yellow);
	color: var(--dark-text);

	text-align: center;
	a {
		color: var(--dark-text);
		&:hover {
			color: var(--white) !important;
		}
	}
`;
