import { Reducer } from 'redux';
import { TodoState, TodoActionTypes } from './types';

const initialState: TodoState = {
    fail: false,
    loading: false,
    data: undefined
}

const reducer: Reducer<TodoState> = (state = initialState, action) => {
    switch (action.type) {
        case TodoActionTypes.LoadFailure:
            return { ...state, data: undefined, loading: false, fail: true};
        case TodoActionTypes.LoadSuccess:
            return { ...state, data: action.payload, loading: false, fail: false};
        case TodoActionTypes.LoadRequest:
            return { ...state, data: undefined, loading: true, fail: false};

        case TodoActionTypes.CreateFailure:
            return { ...state, data: undefined, loading: false, fail: true};
        case TodoActionTypes.CreateRequest:
            return { ...state, data: undefined, loading: true, fail: false};

        case TodoActionTypes.UpdateFailure:
            return { ...state, data: undefined, loading: false, fail: true};
        case TodoActionTypes.UpdateRequest:
            return { ...state, data: undefined, loading: true, fail: false};

        case TodoActionTypes.RemoveFailure:
            return { ...state, data: undefined, loading: false, fail: true};
        case TodoActionTypes.RemoveRequest:
            return { ...state, data: undefined, loading: true, fail: false};
        
        case TodoActionTypes.ResetState:
            return { ...state, data: undefined, loading: false, fail: false};
        default:
            return state;
    }
}

export default reducer;