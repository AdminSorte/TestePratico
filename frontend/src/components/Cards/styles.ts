import styled from 'styled-components';

export const Container = styled.div`
	display: flex;
	align-items: center;
	justify-content: center;

	width: 95%;
	height: 100%;

	margin-top: -5rem;

	@media (max-width: 800px) {
		width: 100%;
	}
`;

export const Content = styled.div`
	display: flex;
	align-items: center;
	justify-content: flex-end;

	width: 95%;
	height: 100%;
	max-width: 1120px;

	@media (max-width: 800px) {
		width: 100%;
		justify-content: flex-start;

		overflow-y: auto;
		&::-webkit-scrollbar {
			width: 6px;
			background-color: transparent;
		}
		&::-webkit-scrollbar-thumb {
			background-color: transparent;
		}
		&::-webkit-scrollbar-track {
			-webkit-box-shadow: none;
			background-color: transparent;
		}
	}
`;
