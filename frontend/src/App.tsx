import { GlobalStyles } from './styles/global';
import { BrowserRouter } from 'react-router-dom';

import Routes from './routes';
import { ToastContainer } from 'react-toastify';
import { AgendaProvider } from './hooks/useAgenda';

export function App() {
	return (
		<BrowserRouter>
			<AgendaProvider>
				<GlobalStyles />
				<Routes />
				<ToastContainer autoClose={3000} />
			</AgendaProvider>
		</BrowserRouter>
	);
}
