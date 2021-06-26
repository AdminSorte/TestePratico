import { call, put } from 'redux-saga/effects';
import api from './../../services/api';
import { AnyAction } from 'redux'
import { login as loginApp } from './../../services/auth';
import { User, UserActionTypes } from './types';
import { TodoActionTypes } from '../Todo/types';

export function * login(action: AnyAction): any {
    try {
        const user: User = action.payload;
        
        let response = yield call(api.post, '/user/login', {
            email: user.email,
            password: user.password
        });

        if (response.data.success) {
            loginApp(response.data.data.token, response.data.data.expireDate);
            yield put ({ type: UserActionTypes.LoadSuccess, payload: response.data.data.user });
            yield init();
        }
        else yield put ({ type: UserActionTypes.LoadFailure });
    } catch {
        yield put({ type: UserActionTypes.LoadFailure });
    }
}

export function * createUser(action: AnyAction): any {
    try {
        const user: User = action.payload;

        let response = yield call(api.post, '/user', {
            email: user.email,
            password: user.password,
            name: user.name,
            lastName: user.lastName
        });

        if (response.data.success) yield put ({ type: UserActionTypes.RegisterSuccess });
        else yield put ({ type: UserActionTypes.RegisterFailure });
    } catch (error: any){
        if (error.response.status === 403) yield put ({ type: UserActionTypes.RegisterFailure });
        else yield put({ type: UserActionTypes.LoadFailure });
    }
}

function * init(): any {
    try {
        let response = yield call(api.get, '/todotask');

        yield put({ type: TodoActionTypes.LoadSuccess, payload: response.data.data });
    }
    catch (error: any) {
        yield put({ type: TodoActionTypes.LoadFailure });
    }
}