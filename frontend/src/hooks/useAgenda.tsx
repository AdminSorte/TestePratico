import { createContext, ReactNode, useContext, useEffect, useState } from 'react';
import { toast } from 'react-toastify';
import swal from 'sweetalert2';
import api from '../services/api';

export interface AgendaData {
	id: number;
	title: string;
	date: string;
	initial_hour: string;
	final_hour: string;
	description: string;
}

interface Summary {
	today: number;
	month: number;
}

type AgendaInput = Omit<AgendaData, 'id'>;

interface AgendasContextData {
	selectedAgenda: AgendaData;
	agendas: AgendaData[];
	summary: Summary;
	isAgendaModalOpen: boolean;
	handleOpenAgendaModal: (agenda?: AgendaData) => void;
	handleCloseAgendaModal: () => void;
	getAgendas: (filters: AgendaFilterParams) => Promise<void>;
	createAgenda: (agenda: AgendaInput) => Promise<void>;
	updateAgenda: (agenda: AgendaData) => Promise<void>;
	deleteAgenda: (agenda: AgendaData) => Promise<void>;
}

interface AgendaProviderProps {
	children: ReactNode;
}

interface AgendaFilterParams {
	description?: string;
	initialDate?: number;
	finalDate?: number;
}

const AgendaContext = createContext<AgendasContextData>({} as AgendasContextData);

export const AgendaProvider = function ({ children }: AgendaProviderProps) {
	const [isAgendaModalOpen, setIsAgendaModalOpen] = useState(false);
	const [selectedAgenda, setSelectedAgenda] = useState({} as AgendaData);
	const [agendas, setAgendas] = useState<AgendaData[]>([]);
	const [summary, setSummary] = useState<Summary>({ today: 0, month: 0 });

	useEffect(() => {
		getSummary();
		getAgendas({});
	}, []);

	function handleOpenAgendaModal(agenda?: AgendaData) {
		if (agenda) {
			setSelectedAgenda(agenda);
		}
		setIsAgendaModalOpen(true);
	}
	function handleCloseAgendaModal() {
		setSelectedAgenda({} as AgendaData);
		setIsAgendaModalOpen(false);
	}

	async function createAgenda(newAgenda: AgendaInput) {
		try {
			const response = await api.post('/agenda', newAgenda);
			console.log(response.data);
			getAgendas({});
			swal.fire('Parabéns!', 'Agendamento adicionado com sucesso!', 'success');
		} catch (error) {
			if (error.response?.data?.message) {
				toast.error(error.response.data.message);
				console.error(error.response.data);
			} else {
				toast.error('Erro deconhecido ao realizar agendamento!');
			}
		}
	}

	async function updateAgenda(agenda: AgendaData) {
		try {
			const response = await api.put('/agenda', agenda);
			console.log(response.data);
			getAgendas({});
			swal.fire('Parabéns!', 'Agendamento atualizado com sucesso!', 'success');
		} catch (error) {
			if (error.response?.data?.message) {
				toast.error(error.response.data.message);
				console.error(error.response.data);
			} else {
				toast.error('Erro deconhecido ao realizar agendamento!');
			}
		}
	}

	async function deleteAgenda(agenda: AgendaData) {
		try {
			const response = await api.delete('/agenda', { params: agenda });
			console.log(response.data);
			swal.fire('Parabéns!', 'Agendamento removido com sucesso!', 'success');
			getAgendas({});
		} catch (error) {
			if (error.response?.data?.message) {
				toast.error(error.response.data.message);
				console.error(error.response.data);
			} else {
				toast.error('Erro deconhecido ao remover agendamento!');
			}
		}
	}

	async function getAgendas(filters: AgendaFilterParams) {
		if (!filters.initialDate) {
			const iniDate = new Date();
			iniDate.setDate(iniDate.getDate() - 1);
			filters.initialDate = iniDate.getTime();
		}

		try {
			const response = await api.get('/agendas', { params: filters });
			setAgendas(response.data);
			console.log(response.data);
		} catch (error) {
			console.error(error);
		}
	}

	async function getSummary() {
		try {
			const response = await api.get('/summary');
			console.log(response.data);
			setSummary(response.data);
		} catch (error) {
			console.error(error);
		}
	}

	return (
		<AgendaContext.Provider
			value={{
				selectedAgenda,
				agendas,
				summary,
				isAgendaModalOpen,
				handleOpenAgendaModal,
				handleCloseAgendaModal,
				getAgendas,
				createAgenda,
				updateAgenda,
				deleteAgenda,
			}}
		>
			{children}
		</AgendaContext.Provider>
	);
};

export function useAgenda() {
	const context = useContext(AgendaContext);

	return context;
}
