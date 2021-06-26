import { all, takeLatest } from 'redux-saga/effects';
import { UserActionTypes } from './User/types';
import { TodoActionTypes } from './Todo/types';
import { login, createUser } from './User/sagas';
import { createTodo, removeTodo, updateTodo } from './Todo/saga';

export default function * rootSaga(): any {
    return yield all([
        takeLatest(UserActionTypes.LoginRequest, login),
        takeLatest(UserActionTypes.RegisterRequest, createUser),
        takeLatest(TodoActionTypes.CreateRequest, createTodo),
        takeLatest(TodoActionTypes.UpdateRequest, updateTodo),
        takeLatest(TodoActionTypes.RemoveRequest, removeTodo),
    ]);
}