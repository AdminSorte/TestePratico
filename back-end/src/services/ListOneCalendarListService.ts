import { getCustomRepository } from "typeorm";
import { CalendarListRepositories } from "./../repositories/CalendarListRepositories";

class ListOneCalendarListService {

    async execute(id: string) {

        const calendarListRepository = getCustomRepository(CalendarListRepositories);

        const listCalendarExists = await calendarListRepository.findOne(id);

        if(!listCalendarExists) {

            throw new Error('List Calendar not found!');

        }

        return listCalendarExists;

    };

};

export { ListOneCalendarListService };