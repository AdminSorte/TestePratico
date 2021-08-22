import { getCustomRepository } from "typeorm";
import { CalendarListRepositories } from "./../repositories/CalendarListRepositories";

class DeleteCalendarListService {

    async execute(id: string) {

        const calendarListRepository = getCustomRepository(CalendarListRepositories);

        if(!id) {

            throw new Error('id empty');

        }
        
        const deleteCalendarList = await calendarListRepository.delete(id);

        return deleteCalendarList;

    }

};

export { DeleteCalendarListService };
