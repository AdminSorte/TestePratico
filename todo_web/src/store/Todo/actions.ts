
import { Todo, TodoDispatchAction, TodoActionTypes } from './types';
import { Dispatch } from 'redux';

export class TodoDispatcher {
    private readonly dispatch: Dispatch<TodoDispatchAction>;

    constructor(dispatch: Dispatch<TodoDispatchAction>) {
        this.dispatch = dispatch;        
    }

    loadRequest = () => this.dispatch({ type: TodoActionTypes.LoadRequest, payload: undefined });

    createRequest = (user: Todo) => this.dispatch({ type: TodoActionTypes.CreateRequest, payload: user });

    updateRequest = (user: Todo) => this.dispatch({ type: TodoActionTypes.UpdateRequest, payload: user });

    RemoveRequest = (id: number) => this.dispatch({ type: TodoActionTypes.RemoveRequest, payload: id });

    resetState = () => this.dispatch({ type: TodoActionTypes.ResetState });
}