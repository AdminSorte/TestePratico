import styled from 'styled-components';

export const Container = styled.div`
	display: flex;
	align-items: center;
	justify-content: center;

	min-width: 95%;
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
			display: flex;
			align-items: center;
			justify-content: center;

			font-size: 1rem;
			height: 2.5rem;
			margin: 0 0.5rem;
			margin-left: auto;
		}
	}
	@media (max-width: 800px) {
		& > form {
			flex-direction: column;

			button {
				width: 90%;
				margin: auto;
				height: 3.5rem;
			}
		}
		p {
			text-align: center;
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

	@media (max-width: 800px) {
		flex-direction: column;
		width: 100%;

		&:not(:first-child) {
			margin-left: unset;
		}
		input {
			width: 90%;
		}
	}
`;
