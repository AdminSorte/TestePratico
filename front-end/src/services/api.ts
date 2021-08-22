import axios from "axios";

export const api = axios.create({
    headers: {
        "Access-Control-Allow-Origin": "*"
    },
    baseURL: "http://localhost:4000/"
});