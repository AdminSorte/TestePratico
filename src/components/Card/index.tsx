import { Container } from './styles';
import { FaRegCalendar } from 'react-icons/fa';

interface CardProps {
	title: string;
	content: string;
}

export function Card({ content, title }: CardProps) {
	return (
		<Container>
			<header>
				<FaRegCalendar />
				<p>{title}</p>
			</header>
			<p>{content}</p>
		</Container>
	);
}
