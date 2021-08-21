import { getCustomRepository } from 'typeorm';
import { CalendarListRepositories } from './../repositories/CalendarListRepositories';

class ListCalendarListService {

    async execute() {

        const calendarListRepository = getCustomRepository(CalendarListRepositories);

        const calendarList = await calendarListRepository.find();

        return calendarList;

    }

};

export { ListCalendarListService };
