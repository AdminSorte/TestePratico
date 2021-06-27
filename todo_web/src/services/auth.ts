export const TOKEN_KEY = 'GA_CHAT_WEB:JWT_TOKEN:AUTH';
export const EXPIRATION_TOKEN = 'TODO_WEB_JWT_TOKEN:EXPIRATION';
export const AUTH = 'TODO_WEB:AUTHORIZATION:AUTH';

export const isAuthenticated = (): boolean => {
    let authenticated: boolean = false;
    const token: string | null = localStorage.getItem(TOKEN_KEY);

    if (token !== null) {
        try {
            const expiration: string | null = localStorage.getItem(EXPIRATION_TOKEN);

            if (expiration) {
                const dateExpiration: number = Date.parse(expiration);
                const dateNow: number = Date.parse(new Date().toString());

                if (dateExpiration > dateNow) authenticated = true;
                else logout();
            }
        } catch {}
    }

    return authenticated;
}

export const getToken = () => localStorage.getItem(TOKEN_KEY);

export const login = (token: string, expiration: string) => {
    localStorage.setItem(TOKEN_KEY, token);
    localStorage.setItem(EXPIRATION_TOKEN, expiration);
}

export const logout = () => {
    localStorage.removeItem(TOKEN_KEY);
}