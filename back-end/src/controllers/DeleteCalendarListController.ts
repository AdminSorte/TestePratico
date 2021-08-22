import { Request, Response } from "express";
import { DeleteCalendarListService } from "./../services/DeleteCalendarListService";

class DeleteCalendarListController {

    async handle(request: Request, response: Response) {

        const { id } = request.params;

        const deleteCalendarList = new DeleteCalendarListService();

        const listCalendar = await deleteCalendarList.execute(id);

        return response.json(listCalendar);

    }

};

export { DeleteCalendarListController };