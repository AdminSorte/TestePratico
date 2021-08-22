import { useToast } from "@chakra-ui/react";
import { useContext, useEffect, useState } from "react";
import { createContext, ReactNode } from "react";
import { api } from "../services/api";

interface ICalendar {
    id: string;
    date: string;
    description: string;
    description_short: string;
}

interface CalendarContextData {
    isLoadingCalendar: boolean;
    calendar: ICalendar[];
    saveCalendar: (newCalendar: ICalendar[]) => void;
};

interface CalendarProviderProps {
    children: ReactNode;
};

const CalendarContext = createContext({} as CalendarContextData);

export function CalendarProvider({ children }: CalendarProviderProps) {

    const [calendar, setCalendar] = useState<ICalendar[]>([]);
    const [isLoadingCalendar, setIsLoadingCalendar] = useState(false);

    const toast = useToast();

    useEffect(() => {

        const getCalendar = async () => {

            setIsLoadingCalendar(true)

            try {
                
                const { data } = await api.get('calendar');

                setCalendar(data);

            } catch (error) {
                
                toast({
                    status: 'error',
                    title: 'Aconteceu um erro na listagem dos itens!',
                    description: error.message,
                    position: 'top-right'
                });

            }

            setIsLoadingCalendar(false);

        };
        
        getCalendar();

    }, []);

    const saveCalendar = (newCalendar: ICalendar[]) => setCalendar(newCalendar);

    return (

        <CalendarContext.Provider value={{
            isLoadingCalendar,
            calendar,
            saveCalendar
        }}>
            { children } 
        </CalendarContext.Provider>

    )

}; 

export function useCalendar() {

    return useContext<CalendarContextData>(CalendarContext);

}