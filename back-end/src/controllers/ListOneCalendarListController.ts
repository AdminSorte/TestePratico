import { Request, Response } from "express";
import { ListOneCalendarListService } from "./../services/ListOneCalendarListService";

class ListOneCalendarListController {

    async handle(request: Request, response: Response) {

        const { id } = request.params;

        const listOneCalendarList = new ListOneCalendarListService();

        const listCalendar = await listOneCalendarList.execute(id);
        
        return response.json(listCalendar);

    }

};

export { ListOneCalendarListController };