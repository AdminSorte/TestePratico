import Modal from 'react-modal';
import { useState } from 'react';
import { AgendaData, useAgenda } from '../../hooks/useAgenda';

import { MdClose } from 'react-icons/md';
import { HiOutlineClock } from 'react-icons/hi';

import { Container } from './styles';

interface AgendaModalProps {
	isOpen: boolean;
	onRequestClose: () => void;
	selectedAgenda: AgendaData;
}

Modal.setAppElement('#root');

export function ModalDetailAgenda({
	isOpen,
	onRequestClose,
	selectedAgenda,
}: AgendaModalProps) {
	const [title, setTitle] = useState('');
	const [date, setDate] = useState('');
	const [initialHour, setInitialHour] = useState('');
	const [finalHour, setFinalHour] = useState('');
	const [description, setDescription] = useState('');

	function onOpenModal() {
		setTitle(selectedAgenda.title);
		setDate(new Date(selectedAgenda.date).toLocaleDateString('pt-BR'));
		setInitialHour(selectedAgenda.initial_hour);
		setFinalHour(selectedAgenda.final_hour);
		setDescription(selectedAgenda.description);
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
			<Container>
				<header>
					<p>Detalhe de agendamento</p>
				</header>

				<main>
					<p>{title}</p>
					<span>
						<HiOutlineClock />
						{date} {initialHour.slice(0, 5)} - {finalHour.slice(0, 5)}h
					</span>

					<span>Descrição:</span>
					<p>{description}</p>
				</main>
			</Container>
		</Modal>
	);
}
