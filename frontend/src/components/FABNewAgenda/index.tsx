import { AiOutlinePlus } from 'react-icons/ai';
import { Button } from './styles';

interface NewTransactionModalProps {
	isOpen: boolean;
	onClick: () => void;
}

export function FABNewAgenda({ isOpen, onClick }: NewTransactionModalProps) {
	return !isOpen ? (
		<Button type='button' onClick={onClick}>
			<AiOutlinePlus />
		</Button>
	) : null;
}
