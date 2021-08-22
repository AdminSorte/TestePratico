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
    calendar: ICalendar[];
    saveCalendar: (newCalendar: ICalendar[]) => void;
};

interface CalendarProviderProps {
    children: ReactNode;
};

const CalendarContext = createContext({} as CalendarContextData);

export function CalendarProvider({ children }: CalendarProviderProps) {

    const [calendar, setCalendar] = useState<ICalendar[]>([]);

    const toast = useToast();

    useEffect(() => {

        api.get('calendar')
            .then(response => setCalendar(response.data))
            .catch(error => {

                toast({
                    status: 'error',
                    title: 'Aconteceu um erro na listagem dos itens!',
                    description: error.message,
                    position: 'top-right'
                });

            });

    }, []);

    const saveCalendar = (newCalendar: ICalendar[]) => setCalendar(newCalendar);

    return (

        <CalendarContext.Provider value={{
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