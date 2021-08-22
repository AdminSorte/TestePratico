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

    useEffect(() => {

        api.get('calendar')
            .then(response => setCalendar(response.data))
            .catch(error => console.log('error', error));

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