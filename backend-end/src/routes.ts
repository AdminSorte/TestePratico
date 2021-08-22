import { Router } from "express";

import { CreateCalendarListController } from "./controllers/CreateCalendarListController";
import { DeleteCalendarListController } from "./controllers/DeleteCalendarListController";
import { ListCalendarListController } from "./controllers/ListCalendarListController";
import { ListOneCalendarListController } from "./controllers/ListOneCalendarListController";
import { UpdateCalendarListController } from "./controllers/UpdateCalendarListController";

const routes = Router();

// CalendarList
const createCalendarListController = new CreateCalendarListController();
routes.post('/calendar', createCalendarListController.handle);

const listCalendarListController = new ListCalendarListController();
routes.get('/calendar', listCalendarListController.handle);

const listOneCalendarListController = new ListOneCalendarListController();
routes.get('/calendar/:id', listOneCalendarListController.handle);

const updatedCalendarList = new UpdateCalendarListController();
routes.put('/calendar/:id', updatedCalendarList.handle);

const deletedCalendarList = new DeleteCalendarListController();
routes.delete('/calendar/:id', deletedCalendarList.handle);

export { routes };