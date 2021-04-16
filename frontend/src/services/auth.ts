export const TOKEN_KEY = '@minha-agenda-Token';
export const isAuthenticated = () => sessionStorage.getItem(TOKEN_KEY) !== null;

export const getToken = () => {
	return new Promise<string>((resolve, reject) => {
		const token = sessionStorage.getItem(TOKEN_KEY) as string;
		setTimeout(() => {
			resolve(token);
		}, 200);
	});
};

export const setToken = (token: string) => {
	return new Promise<void>((resolve, reject) => {
		sessionStorage.setItem(TOKEN_KEY, token);
		setTimeout(() => {
			resolve();
		}, 200);
	});
};
export const removeToken = async () => {
	new Promise<void>((resolve, reject) => {
		sessionStorage.removeItem(TOKEN_KEY);
		setTimeout(() => {
			resolve();
		}, 200);
	});
};
