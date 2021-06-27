import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import { BrowserRouter, Switch, Route } from "react-router-dom";
import { Auth } from './pages/auth';
import { Todo } from './pages/todo';
import { Provider } from 'react-redux';
import store from './store';
import PrivateRoute from './routes';

ReactDOM.render(
  <BrowserRouter>
		<Switch>
		  <Provider store={store}>
			  <Route exact path="/" component={Auth} />
			  <PrivateRoute exact path="/todo" component={Todo} />
		  </Provider>
		</Switch>
	</BrowserRouter>,
  document.getElementById('root')
);