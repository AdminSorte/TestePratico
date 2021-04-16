import chalk from 'chalk';
import fs from 'fs';
require('dotenv-safe').config();

const getActualRequestDurationInMilliseconds = (start) => {
	const NS_PER_SEC = 1e9; // constant to convert to nanoseconds
	const NS_TO_MS = 1e6; // constant to convert to milliseconds
	const diff = process.hrtime(start);

	return (diff[0] * NS_PER_SEC + diff[1]) / NS_TO_MS;
};

export default (req, res, next) => {
	if (process.env.LOG === 'true') {
		let current_datetime = new Date();
		let formatted_date =
			current_datetime.getFullYear() +
			'-' +
			(current_datetime.getMonth() + 1) +
			'-' +
			current_datetime.getDate() +
			' ' +
			current_datetime.getHours() +
			':' +
			current_datetime.getMinutes() +
			':' +
			current_datetime.getSeconds();
		let method = req.method;
		let url = req.url;
		let status = res.statusCode;

		const start = process.hrtime();
		const durationInMilliseconds = getActualRequestDurationInMilliseconds(start);

		let log = `[${chalk.blue(formatted_date)}] ${method}:${url} ${status} ${chalk.red(
			durationInMilliseconds.toLocaleString() + 'ms'
		)} `;
		let body = `${method != 'GET' ? `- BODY : ${JSON.stringify(req.body)}` : ''} `;

		console.log(log + body);

		let day =
			current_datetime.getFullYear() +
			'_' +
			(current_datetime.getMonth() + 1) +
			'_' +
			current_datetime.getDate();
		let filename = `./logs/server_log_${day}.txt`;

		fs.appendFile(filename, log + body + '\n', (err) => {
			if (err) {
				console.log(err);
			}
		});

		var oldWrite = res.write,
			oldEnd = res.end;
		var chunks = [];
		res.write = function (chunk) {
			chunks.push(chunk);
			oldWrite.apply(res, arguments);
		};
		res.end = function (chunk) {
			if (chunk) chunks.push(chunk);
			var body = Buffer.concat(chunks).toString('utf8');
			log += `- RESPONSE: ${body}`;
			console.log(log);
			fs.appendFile(filename, log + '\n', (err) => {
				if (err) {
					console.log(err);
				}
			});
			oldEnd.apply(res, arguments);
		};
	}
	next();
};
