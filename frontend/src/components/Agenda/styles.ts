import styled from 'styled-components';

export const Container = styled.div`
	display: flex;
	align-items: center;
	justify-content: center;
`;

export const Content = styled.div`
	display: flex;
	flex-direction: column;
	justify-content: space-between;

	width: 100%;
	height: 100%;
	max-width: 1120px;

	color: var(--dark-text);
`;

export const FilterContainer = styled.div`
	display: flex;
	flex-direction: column;

	margin: 2rem 0;

	width: 100%;
	height: 100%;
	max-width: 1120px;

	& > form {
		display: flex;
		align-items: center;

		button {
			font-size: 1rem;
			height: 2.5rem;
			margin: 0 0.5rem;
			margin-left: auto;
		}
	}
`;

export const InputGroup = styled.div`
	display: flex;

	align-items: center;

	span {
		margin: 0 0.5rem;
	}

	input {
		width: 300px;
		height: 3rem;
	}

	&:not(:first-child) {
		margin-left: auto;
	}
`;
