import { GlobalStyles } from './styles/global';
import { BrowserRouter } from 'react-router-dom';

import Routes from './routes';
import { ToastContainer } from 'react-toastify';

export function App() {
	return (
		<BrowserRouter>
			<GlobalStyles />
			<Routes />
			<ToastContainer autoClose={3000} />
		</BrowserRouter>
	);
}
