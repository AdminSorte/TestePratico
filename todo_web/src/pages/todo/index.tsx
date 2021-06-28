import React, { useEffect, useState } from 'react';
import { AppBar, Toolbar, IconButton, Typography, Button, Fab } from '@material-ui/core';
import { Book, Visibility, Edit, Delete, Add, Search } from '@material-ui/icons';
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
import { CustomInput } from '../../components/custom-input';

export function Todo() {
  const dispatch: Dispatch = useDispatch();
  const todoDispatcher = new TodoDispatcher(dispatch);
  const todoState: TodoState = useSelector<ApplicationState, TodoState>((state: ApplicationState) => state.todo);

  const [todoSelected, setTodoSelected] = useState<TodoType | undefined>(undefined);
  const [redirectLogout, setRedirectLogout] = useState<boolean>(false);
  const [filter, setFilter] = useState<string>('');
  const [todoData, setTodoData] = useState<TodoType[]>([]);

  const changeFilter = (event: any) => setFilter(event.target.value);

  useEffect(() => {
    todoDispatcher.loadRequest();
  }, []);

  useEffect(() => {
    setTodoData(todoState.data as TodoType[]);
  }, [todoState.data]);

  const handleFilterData = () => {
    setTodoData(todoState.data as TodoType[]);
    
    if (filter && filter.length > 0) {
      setTodoData((todoState.data as TodoType[]).filter(x => (x.title as string).indexOf(filter) >= 0));
    }
  }

  const handleCloseModal = () => {
    setTodoSelected(undefined);
  }

  const handlerRemove = () => {
    todoDispatcher.RemoveRequest(todoSelected?.id as number);
    setTodoSelected(undefined);
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

      <div className="content-filter">
        <div className="container">
          <div className="row">
            <div className="col-5">
              <CustomInput 
                label="Filtro"
                placeholder="Insira o nome que deseja filtrar"
                value={filter}
                onChange={changeFilter}
              />
            </div>
            <div className="col-1">
              <IconButton edge="start" color="inherit" aria-label="menu" onClick={handleFilterData}>
                <Search />
              </IconButton>
            </div>
          </div>
        </div>
      </div>
      <div className="content-table">
        <div className="container">
          <div className="row">
            <div className="col-12">
              <table className="table">
                <thead className="thead-dark">
                  <th style={{width: "10%"}}>#</th>
                  <th style={{width: "70%"}}>Titulo</th>
                  <th style={{width: "20%"}}>Ações</th>
                </thead>
                <tbody>
                  {
                    todoData?.map(x => (
                      <tr>
                        <td>{ x.id }</td>
                        <td>{ x.title }</td>
                        <td>
                          <IconButton edge="start" color="primary" aria-label="menu" onClick={() => setTodoSelected(x)} data-toggle="modal" data-target="#viewModal">
                            <Visibility />
                          </IconButton>
                          <IconButton edge="start" color="inherit" aria-label="menu" onClick={() => setTodoSelected(x)} data-toggle="modal" data-target="#actionModal">
                            <Edit />
                          </IconButton>
                          <IconButton edge="start" color="secondary" aria-label="menu" onClick={() => setTodoSelected(x)} data-toggle="modal" data-target="#alertModal">
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
      </div>

      <Fab color="primary" aria-label="add" className="floating-position" data-toggle="modal" data-target="#actionModal">
        <Add />
      </Fab>

      <ActionMoal
        handleClose={handleCloseModal}
        todo={todoSelected}
      />

      <ViewModal
        todo={todoSelected}
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