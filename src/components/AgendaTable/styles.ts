import styled from 'styled-components';

export const Container = styled.div`
	table {
		width: 100%;
		border-spacing: 0 0.5rem;

		.subTitleDay {
			td {
				background: none;
				padding: 0.5rem 1rem;
				text-align: left !important;
			}
		}

		td {
			padding: 1rem;
			border: 0;
			background: var(--white);
			color: var(--light-text);
			border-radius: 0.25rem;

			button {
				align-items: center;
				justify-content: center;

				height: 2rem;
				/* width: 2rem; */

				font-size: 1rem;

				padding: 0;
				margin: 0.5rem;

				svg {
					margin: 0.5rem;
				}
			}

			& .title {
				color: var(--dark-text);
			}

			& .description {
				text-overflow: ellipsis;
				white-space: nowrap;
				overflow: hidden;
				max-width: 450px;
			}
		}

		tr {
			td:last-child {
				text-align: right;
			}

			transition: filter 0.1s;
			&:hover {
				cursor: pointer;
				filter: brightness(0.9);
			}
		}
	}
`;
