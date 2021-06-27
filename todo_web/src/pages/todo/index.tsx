import React, { useEffect, useState } from 'react';
import { AppBar, Toolbar, IconButton, Typography, Button, Fab } from '@material-ui/core';
import { Book, Visibility, Edit, Delete, Add } from '@material-ui/icons';
import './style.css';
import { ActionMoal } from './components/action-modal';
import { ViewModal } from './components/view-modal';
import { ApplicationState } from '../../store/rootReducer';
import { TodoState, Todo as TodoType } from '../../store/Todo/types';
import { useSelector } from 'react-redux';
import { LoadingIndicator } from '../../components/loading-indicator';
import { AlertModal } from '../../components/alert-modal';
import { Dispatch } from 'redux';
import { useDispatch } from 'react-redux';
import { TodoDispatcher } from '../../store/Todo/actions';
import { Redirect } from 'react-router-dom';
import { isAuthenticated, logout } from '../../services/auth';

export function Todo() {
  const dispatch: Dispatch = useDispatch();
  const todoDispatcher = new TodoDispatcher(dispatch);
  const todoState: TodoState = useSelector<ApplicationState, TodoState>((state: ApplicationState) => state.todo);

  const [todoData, setTodoData] = useState<TodoType | undefined>(undefined);
  const [redirectLogout, setRedirectLogout] = useState<boolean>(false);

  useEffect(() => {
    todoDispatcher.loadRequest();
  }, []);

  const handleCloseModal = () => {
    setTodoData(undefined);
  }

  const handlerRemove = () => {
    todoDispatcher.RemoveRequest(todoData?.id as number);
    setTodoData(undefined);
  }

  const logoutUser = () => {
    logout();
    setRedirectLogout(true);
  }

  return (
    <div className="content">
      <AppBar position="static">
        <Toolbar>
          <div className="title-page-content">
            <IconButton edge="start" color="inherit" aria-label="menu">
              <Book />
            </IconButton>
            <Typography variant="h6">
              Minha agenda minha vida
            </Typography>
          </div>
          <div className="logout-content">
            <Button color="inherit" onClick={logoutUser}>Sair</Button>
          </div>
        </Toolbar>
      </AppBar>

      <div className="content-table">
        <div className="container">
          <div className="col-12">
            <table className="table">
              <thead className="thead-dark">
                <th style={{width: "10%"}}>#</th>
                <th style={{width: "70%"}}>Titulo</th>
                <th style={{width: "20%"}}>Ações</th>
              </thead>
              <tbody>
                {
                  todoState.data?.map(x => (
                    <tr>
                      <td>{ x.id }</td>
                      <td>{ x.title }</td>
                      <td>
                        <IconButton edge="start" color="primary" aria-label="menu" onClick={() => setTodoData(x)} data-toggle="modal" data-target="#viewModal">
                          <Visibility />
                        </IconButton>
                        <IconButton edge="start" color="inherit" aria-label="menu" onClick={() => setTodoData(x)} data-toggle="modal" data-target="#actionModal">
                          <Edit />
                        </IconButton>
                        <IconButton edge="start" color="secondary" aria-label="menu" onClick={() => setTodoData(x)} data-toggle="modal" data-target="#alertModal">
                          <Delete />
                        </IconButton>
                      </td>
                    </tr>
                  ))
                }
              </tbody>
            </table>
          </div>
        </div>
      </div>

      <Fab color="primary" aria-label="add" className="floating-position" data-toggle="modal" data-target="#actionModal">
        <Add />
      </Fab>

      <ActionMoal
        handleClose={handleCloseModal}
        todo={todoData}
      />

      <ViewModal
        todo={todoData}
      />

      <AlertModal 
        title="Atenção"
        message="Realmente deseja remover esta agenda"
        confirm={handlerRemove}
        close={handleCloseModal}
      />

      {
        todoState.loading ? <LoadingIndicator /> : <></>
      }

      {
        redirectLogout && !isAuthenticated() ? <Redirect to="/" /> : null
      }
    </div>
  );
}