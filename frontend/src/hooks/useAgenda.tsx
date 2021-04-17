import { createContext, ReactNode, useContext, useEffect, useState } from 'react';
import api from '../services/api';

export interface Agenda {
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

type AgendaInput = Omit<Agenda, 'id'>;

interface AgendasContextData {
	agendas: Agenda[];
	summary: Summary;
	getAgendas: (filters: AgendaFilterParams) => Promise<void>;
	createAgenda: (agenda: AgendaInput) => Promise<void>;
	updateAgenda: (agenda: Agenda) => Promise<void>;
	deleteAgenda: (agenda: Agenda) => Promise<void>;
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
	const [agendas, setAgendas] = useState<Agenda[]>([]);
	const [summary, setSummary] = useState<Summary>({ today: 0, month: 0 });

	useEffect(() => {
		getSummary();
		getAgendas({});
	}, []);

	async function createAgenda(newAgenda: AgendaInput) {}

	async function updateAgenda(agenda: Agenda) {}

	async function deleteAgenda(agenda: Agenda) {}

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
				agendas,
				summary,
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
