import { Switch, Route, Redirect, RouteProps } from 'react-router-dom';

import { Home } from './pages/Home';
import { Authentication } from './pages/Authentication';
import { NotFound } from './pages/NotFound';

import { isAuthenticated } from './services/auth';

const Routes = (): JSX.Element => {
	return (
		<Switch>
			<ProtectedRoute path='/' exact component={Home} />
			<Route path='/entrar' component={Authentication} />
			<Route path='/cadastro' component={Authentication} />
			<Route path='/404' component={NotFound} />
			<Redirect to='/404' />
		</Switch>
	);
};

const ProtectedRoute = (routeProps: RouteProps) => {
	if (isAuthenticated()) {
		return <Route {...routeProps} />;
	} else {
		return <Redirect to='/entrar' />;
	}
};

export default Routes;
