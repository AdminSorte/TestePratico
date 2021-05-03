import { get, post, del, put } from './Methods';

export const AgendaApi = {
  User: {
    singIn: (body) => post('user/login', {body}),
  },
  Agenda: {
    create: (body) => post('agenda', {body}),
    update: (body) => put('agenda', {body}),
    delete: (agendaId) => del(`agenda?id=${agendaId}`),
    getAll: () => get('agenda'),
  },
};