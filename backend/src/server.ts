import express from 'express';
import https from 'https';
import routes from './routes';
import logger from './middlewares/logging';
import * as fs from 'fs';
import cors from 'cors';
require('dotenv-safe').config();
const app = express();

app.use(express.json());
app.use(cors());
app.use(logger);
app.use(routes);

const key = fs.readFileSync('/var/www/html/server.key');
const cert = fs.readFileSync('/var/www/html/server.cert');
const server = https.createServer(
	{
		key,
		cert,
	},
	app
);

server.listen(3000, () => {
	console.log('SERVER STARTED! \n');
	console.log('----- ENV -----');
	console.log('SECRET: ' + JSON.stringify(process.env.SECRET));
	console.log('LOG: ' + JSON.stringify(process.env.LOG));
	console.log('---------------');
});
