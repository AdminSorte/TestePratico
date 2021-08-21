import { getCustomRepository } from "typeorm";
import { CalendarListRepositories } from "./../repositories/CalendarListRepositories";

interface ICalendarListRequest {
    id: string;
    data: {
        date: string;
        description: string;
        description_short: string;
    }
};

class UpdateCalendarListService {

    async execute({ id, data }: ICalendarListRequest) {

        const calendarListRepository = getCustomRepository(CalendarListRepositories);

        await calendarListRepository.update(
            id,
            data
        );

        const updatedCalendarList = await calendarListRepository.findOne(id);

        return updatedCalendarList;

    }

};

export { UpdateCalendarListService };