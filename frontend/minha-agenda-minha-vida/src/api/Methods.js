import { API_URL, HEADERS } from './Constants';

async function baseRequest(method, route, options) {
  const body = options?.body ? JSON.stringify(options.body) : null;
  const headers = HEADERS;
  return await fetch(`${API_URL}${route}`, Object.assign({
    method,
    headers
  }, { body } || {}))
    .then(r => r.json())
    .then(json => {
      if (json.status === 200 || !json.status) {
        return json;
      }
      return json;
    }).catch(e => e);
}

export const get = (route, options) => baseRequest('GET', route, options);
export const post = (route, options) => baseRequest('POST', route, options);
export const put = (route, options) => baseRequest("PUT", route, options);
export const del = (route, options) => baseRequest("DELETE", route, options);