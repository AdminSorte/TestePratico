import styled from 'styled-components';

export const Container = styled.div`
	margin-bottom: 4rem;

	table {
		width: 100%;
		border-spacing: 0 0.5rem;

		.subTitleDay {
			td {
				background: none;
				padding: 0.5rem 1rem;
				text-align: left !important;

				&:hover {
					cursor: auto;
					filter: none;
				}
			}
		}

		.emptyWarning {
			td {
				font-size: 1.3rem;
				background: none;
				padding: 0.5rem 1rem;
				text-align: center !important;
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
	@media (max-width: 800px) {
		tr {
			display: grid;
			margin-bottom: 1rem;
		}
		td {
			padding: 0.2rem 1rem !important;
			width: 95vw;
			margin: auto;
			button {
				height: 2.5rem !important;
				width: 2.5rem;

				font-size: 1.2rem !important;
				line-height: 1rem;
			}

			&:first-of-type {
				padding-top: 1rem !important;
			}
		}
	}
`;
