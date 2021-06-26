
import { combineReducers } from 'redux';
import user from './User/reducer';
import todo from './Todo/reducer';
import { UserState } from './User/types';
import { TodoState } from './Todo/types'

export interface ApplicationState {
    user: UserState;
    todo: TodoState;
}

export default combineReducers({
    user,
    todo
});