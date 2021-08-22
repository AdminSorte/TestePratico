import { getCustomRepository } from "typeorm";
import { CalendarListRepositories } from "../repositories/CalendarListRepositories";

interface ICalendarListRequest {
    date: string;
    description_short: string;
    description: string;
};

class CreateCalendarListService {

    async execute({ date, description, description_short }: ICalendarListRequest) {

        const calendarListRepository = getCustomRepository(CalendarListRepositories);

        if(!date || !description || !description_short) {

            throw new Error('Fields invalid')

        }

        const calendarList = calendarListRepository.create({ date, description, description_short });

        await calendarListRepository.save(calendarList);

        return calendarList;

    }

};

export { CreateCalendarListService };