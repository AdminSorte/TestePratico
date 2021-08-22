import { Request, Response } from "express";
import { CreateCalendarListService } from "./../services/CreateCalendarListService";

class CreateCalendarListController {

    async handle(request: Request, response: Response) {

        const { date, description, description_short } = request.body;

        const createCalendarListService = new CreateCalendarListService();

        const createCalendarList = await createCalendarListService.execute({ date, description, description_short });

        return response.json(createCalendarList);
        
    }

};

export { CreateCalendarListController };