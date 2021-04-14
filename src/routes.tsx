import { Switch, Route } from 'react-router-dom';

import { Home } from './pages/Home';
import { SingIn } from './pages/SingIn';
import { SingUp } from './pages/SingUp';

const Routes = (): JSX.Element => {
	return (
		<Switch>
			<Route path='/' exact component={Home} />
			<Route path='/login' component={SingIn} />
			<Route path='/cadastro' component={SingUp} />
		</Switch>
	);
};

export default Routes;
