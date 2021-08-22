import { Request, Response } from "express";
import { ListCalendarListService } from "./../services/ListCalendarListService";

class ListCalendarListController {

    async handle(request: Request, response: Response) {

        const listCalendarList = new ListCalendarListService();

        const calendarList = await listCalendarList.execute();

        return response.json(calendarList);

    }

};

export { ListCalendarListController };