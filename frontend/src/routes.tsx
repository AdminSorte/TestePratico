import { Switch, Route, Redirect } from 'react-router-dom';

import { Home } from './pages/Home';
import { Authentication } from './pages/Authentication';
import { NotFound } from './pages/NotFound';

const Routes = (): JSX.Element => {
	return (
		<Switch>
			<Route path='/' exact component={Home} />
			<Route path='/entrar' component={Authentication} />
			<Route path='/cadastro' component={Authentication} />
			<Route path='/404' component={NotFound} />
			<Redirect to='/404' />
		</Switch>
	);
};

export default Routes;
