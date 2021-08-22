import { Request, Response } from "express";
import { UpdateCalendarListService } from "./../services/UpdateCalendarListService";

class UpdateCalendarListController {

    async handle(request: Request, response: Response) {

        const { id } = request.params;
        const { date, description, description_short } = request.body;

        const updateCalendarListService = new UpdateCalendarListService();

        const listCalendar = await updateCalendarListService.execute({
            id,
            data: { date, description, description_short }
        });

        return response.json(listCalendar);

    }

};

export { UpdateCalendarListController };