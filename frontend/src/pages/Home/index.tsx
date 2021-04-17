import { Container } from './styles';
import { Header } from '../../components/Header';
import { Cards } from '../../components/Cards';
import { Agenda } from '../../components/Agenda';
import { AgendaProvider, useAgenda } from '../../hooks/useAgenda';
import { ModalAgenda } from '../../components/ModalAgenda';
import { FABNewAgenda } from '../../components/FABNewAgenda';
import { useState } from 'react';

export function Home() {
	const {
		selectedAgenda,
		isAgendaModalOpen,
		handleOpenAgendaModal,
		handleCloseAgendaModal,
	} = useAgenda();

	return (
		<Container>
			<Header />
			<Cards />
			<Agenda />
			<FABNewAgenda isOpen={isAgendaModalOpen} onClick={handleOpenAgendaModal} />
			<ModalAgenda
				isOpen={isAgendaModalOpen}
				onRequestClose={handleCloseAgendaModal}
				selectedAgenda={selectedAgenda}
			/>
		</Container>
	);
}
