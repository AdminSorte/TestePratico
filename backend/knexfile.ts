// Update with your config settings.
require('dotenv-safe').config();
export const development = {
	client: 'mysql',
	connection: {
		host: '127.0.0.1',
		user: process.env.DB_USER,
		password: process.env.DB_PASS,
		database: process.env.DB_NAME,
	},
	migrations: {
		directory: './src/migrations',
		tableName: 'knex_migrations',
	},
};
export const staging = {
	client: 'mysql',
	connection: {
		host: '127.0.0.1',
		user: 'your_database_user',
		password: 'your_database_password',
		database: 'myapp_test',
	},
	migrations: {
		tableName: 'knex_migrations',
	},
};
export const production = {
	client: 'mysql',
	connection: {
		host: '127.0.0.1',
		user: 'your_database_user',
		password: 'your_database_password',
		database: 'myapp_test',
	},
	migrations: {
		tableName: 'knex_migrations',
	},
};
