import { render, screen } from "@testing-library/react";

import { AddButton } from './index';

describe('Component AddButton', () => {

    it('should renders correctly', () => {

        render(<AddButton />);

        expect(screen.getByTestId('add-item')).toBeInTheDocument();

    })

})