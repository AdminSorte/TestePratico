import { render, screen } from '@testing-library/react'
import { Menu } from '.'

describe('Menu', () => {
  it('should render the title of the menu bar', () => {
    const props = {
      title: 'Minha agenda minha vida',
    }

    render(<Menu title={props.title} />)
    const element = screen.getByText(props.title)
    expect(element).toBeInTheDocument()
  })
})
