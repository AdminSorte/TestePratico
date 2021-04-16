import express from 'express';

import { UserController } from './controllers/UserController';
import { SessionController } from './controllers/SessionController';

import AuthMiddleware from './middlewares/auth';

const routes = express.Router();
const userController = new UserController();
const sessionController = new SessionController();

//Login
routes.post('/session', sessionController.store);

//Cadastro de usuario
routes.post('/user', userController.store);

// routes.post('/user', AuthMiddleware, userController.store);

export default routes;
