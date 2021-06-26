import { Action } from 'redux';

export interface Todo {
    id?: number;
    title?: string;
    description?: string;
}

export interface TodoDispatchAction extends Action<TodoActionTypes> {
    payload?: Todo | number;
}

export enum TodoActionTypes {
    LoadSuccess = 'LOAD_SUCCESS_TODO',
    LoadFailure = 'LOAD_FAILURE_TODO',
    LoadRequest = 'LOAD_REQUEST_TODO',    
    CreateSuccess = 'CREATE_SUCCESS_TODO',
    CreateFailure = 'CREATE_FAILURE_TODO',
    CreateRequest = 'CREATE_REQUEST_TODO',
    UpdateSuccess = 'UPDATE_SUCCESS_TODO',
    UpdateFailure = 'UPDATE_FAILURE_TODO',
    UpdateRequest = 'UPDATE_REQUEST_TODO',
    RemoveSuccess = 'REMOVE_SUCCESS_TODO',
    RemoveFailure = 'REMOVE_FAILURE_TODO',
    RemoveRequest = 'REMOVE_REQUEST_TODO',
    ResetState = 'RESET_STATE_TODO'
}

export interface TodoState {
    readonly data?: Todo;
    readonly loading: boolean;
    readonly fail: boolean;
}