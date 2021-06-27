import { call, put } from 'redux-saga/effects';
import api from './../../services/api';
import { AnyAction } from 'redux'
import { Todo, TodoActionTypes } from './types';

export function * createTodo(action: AnyAction): any {
    try {
        const todo: Todo = action.payload;

        let response = yield call(api.post, '/todotask', {
            title: todo.title,
            description: todo.description
        });

        if (response.data.success) yield put({ type: TodoActionTypes.CreateSuccess, payload: response.data.data });
        else yield put({ type: TodoActionTypes.CreateFailure });
    }
    catch (error: any) {
        yield put({ type: TodoActionTypes.CreateFailure });
    }
}

export function * updateTodo(action: AnyAction): any {
    try {
        const todo: Todo = action.payload;

        let response = yield call(api.put, '/todotask', {
            id: todo.id,
            title: todo.title,
            description: todo.description
        });

        if (response.data.success) yield put({ type: TodoActionTypes.UpdateSuccess, payload: response.data.data });
        else yield put({ type: TodoActionTypes.UpdateFailure });
    }
    catch (error: any) {
        yield put({ type: TodoActionTypes.UpdateFailure });
    }
}

export function * removeTodo(action: AnyAction): any {
    try {
        const todo: Todo = action.payload;

        let response = yield call(api.post, `/todotask?id=${todo.id}`);

        if (response.data.success) yield put({ type: TodoActionTypes.RemoveFailure, payload: response.data.data });
        else yield put({ type: TodoActionTypes.RemoveFailure });
    }
    catch (error: any) {
        yield put({ type: TodoActionTypes.RemoveFailure });
    }
}