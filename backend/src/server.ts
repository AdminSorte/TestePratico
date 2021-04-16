import express from 'express';
import routes from './routes';
import logger from './middlewares/logging';
import cors from 'cors';
require('dotenv-safe').config();
const app = express();

app.use(express.json());
app.use(cors());
app.use(logger);
app.use(routes);

app.listen(3333, () => {
	console.log('SERVER STARTED! \n');
	console.log('----- ENV -----');
	console.log('SECRET: ' + JSON.stringify(process.env.SECRET));
	console.log('LOG: ' + JSON.stringify(process.env.LOG));
	console.log('---------------');
});
