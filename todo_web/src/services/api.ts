import axios, { AxiosRequestConfig } from 'axios';
import { getToken } from './auth';

const api = axios.create({
    baseURL: 'http://localhost:5000/api/'
});

api.interceptors.request.use(async (config: AxiosRequestConfig) => {

    const token: any = getToken();

    if (token){
        config.headers.Authorization = `Bearer ${token}`;
    }

    return config;
});

export default api;