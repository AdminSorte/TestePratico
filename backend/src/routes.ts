import express from 'express';

import { UserController } from './controllers/UserController';
import { SessionController } from './controllers/SessionController';

import AuthMiddleware from './middlewares/auth';
import { AgendaController } from './controllers/AgendaController';
import { SummaryController } from './controllers/SummaryController';

const routes = express.Router();
const userController = new UserController();
const sessionController = new SessionController();
const agendaController = new AgendaController();
const summaryController = new SummaryController();

//Login
routes.post('/session', sessionController.store);

//Cadastro de usuario
routes.post('/user', userController.store);

//Cadastro de agendamento
routes.post('/agenda', AuthMiddleware, agendaController.store);

routes.put('/agenda', AuthMiddleware, agendaController.update);

routes.delete('/agenda', AuthMiddleware, agendaController.destroy);

routes.get('/agendas', AuthMiddleware, agendaController.index);

routes.get('/summary', AuthMiddleware, summaryController.index);

export default routes;
