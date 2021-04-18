import { Container } from './styles';
import { Header } from '../../components/Header';
import { Cards } from '../../components/Cards';
import { Agenda } from '../../components/Agenda';
import { useAgenda } from '../../hooks/useAgenda';
import { ModalAgenda } from '../../components/ModalAgenda';
import { FABNewAgenda } from '../../components/FABNewAgenda';
import { ModalDetailAgenda } from '../../components/ModalDetailAgenda';
import { useEffect } from 'react';

export function Home() {
	const {
		selectedAgenda,
		isAgendaModalOpen,
		handleOpenAgendaModal,
		handleCloseAgendaModal,
		isAgendaModalDetailOpen,
		handleCloseAgendaDetailModal,
	} = useAgenda();

	useEffect(() => {
		document.title = `Minha agenda | Inicio`;
	}, []);

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
			<ModalDetailAgenda
				isOpen={isAgendaModalDetailOpen}
				onRequestClose={handleCloseAgendaDetailModal}
				selectedAgenda={selectedAgenda}
			/>
		</Container>
	);
}
