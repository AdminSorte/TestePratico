import Modal from 'react-modal';
import { FormEvent, useEffect, useState } from 'react';
import { AgendaData, useAgenda } from '../../hooks/useAgenda';

import { MdClose } from 'react-icons/md';

import { Container, InputGroup, InputLine } from './styles';
import { toast } from 'react-toastify';
import { LoadingButton } from '../LoadingButton';

interface AgendaModalProps {
	isOpen: boolean;
	onRequestClose: () => void;
	selectedAgenda: AgendaData;
}

Modal.setAppElement('#root');

export function ModalAgenda({
	isOpen,
	onRequestClose,
	selectedAgenda,
}: AgendaModalProps) {
	const { createAgenda, updateAgenda } = useAgenda();

	const [isLoadingButton, setIsLoadingButton] = useState(false);

	const [title, setTitle] = useState('');
	const [date, setDate] = useState('');
	const [initialHour, setInitialHour] = useState('');
	const [finalHour, setFinalHour] = useState('');
	const [description, setDescription] = useState('');

	function onOpenModal() {
		if (selectedAgenda.id) {
			setTitle(selectedAgenda.title);
			setDate(selectedAgenda.date.split('T')[0]);
			setInitialHour(selectedAgenda.initial_hour);
			setFinalHour(selectedAgenda.final_hour);
			setDescription(selectedAgenda.description);
		} else {
			resetFormAgenda();
		}
	}

	async function handleSubmitAgenda(event: FormEvent) {
		event.preventDefault();
		setIsLoadingButton(true);

		if (!title) {
			toast.error('Informe um título para o seu agendamento!');
			setIsLoadingButton(false);
			return;
		}

		if (!date) {
			toast.error('Informe uma data para o seu agendamento!');
			setIsLoadingButton(false);
			return;
		}

		if (!initialHour) {
			toast.error('Informe um horário inicial para o seu agendamento!');
			setIsLoadingButton(false);
			return;
		}

		if (!finalHour) {
			toast.error('Informe um horário final para o seu agendamento!');
			setIsLoadingButton(false);
			return;
		}

		if (!description) {
			toast.error('Informe uma descrição para o seu agendamento!');
			setIsLoadingButton(false);
			return;
		}

		const data = {
			title,
			date,
			initial_hour: initialHour,
			final_hour: finalHour,
			description,
		};

		if (selectedAgenda.id) {
			await updateAgenda({ id: selectedAgenda.id, ...data });
		} else {
			await createAgenda(data);
		}

		setIsLoadingButton(false);
		onRequestClose();
		resetFormAgenda();
	}

	function resetFormAgenda() {
		setTitle('');
		setDate('');
		setInitialHour('');
		setFinalHour('');
		setDescription('');
	}

	return (
		<Modal
			isOpen={isOpen}
			onAfterOpen={onOpenModal}
			onRequestClose={onRequestClose}
			overlayClassName='react-modal-overlay'
			className='react-modal-content'
		>
			<button type='button' className='react-modal-close' onClick={onRequestClose}>
				<MdClose />
			</button>
			<Container onSubmit={handleSubmitAgenda}>
				<header>
					<p>
						{selectedAgenda.id ? 'Edição de Agendamento' : 'Novo agendamento'}
					</p>
				</header>

				<main>
					<InputGroup>
						<label>Título:</label>
						<input
							maxLength={55}
							type='text'
							placeholder='Título'
							value={title}
							onChange={(event) => setTitle(event.target.value)}
						/>
					</InputGroup>

					<InputGroup>
						<label>Data:</label>
						<input
							type='date'
							value={date}
							onChange={(event) => setDate(event.target.value)}
						/>
					</InputGroup>

					<InputLine>
						<InputGroup>
							<label>Inicio:</label>
							<input
								type='time'
								value={initialHour}
								onChange={(event) => setInitialHour(event.target.value)}
							/>
						</InputGroup>
						<InputGroup>
							<label>Fim:</label>
							<input
								type='time'
								value={finalHour}
								onChange={(event) => setFinalHour(event.target.value)}
							/>
						</InputGroup>
					</InputLine>

					<InputGroup>
						<label>Descrição:</label>
						<textarea
							maxLength={450}
							rows={5}
							value={description}
							onChange={(event) => setDescription(event.target.value)}
						/>
					</InputGroup>
				</main>

				<footer>
					<LoadingButton type='submit' isLoading={isLoadingButton}>
						{selectedAgenda.id ? 'Salvar' : 'Agendar'}
					</LoadingButton>
				</footer>
			</Container>
		</Modal>
	);
}
