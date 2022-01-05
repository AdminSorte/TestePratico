import { render, screen } from '@testing-library/react'
import { Menu } from '.'

test('should render the text Hi, hacker!', () => {
  const props = {
    title: 'Minha agenda minha vida',
  }

  render(<Menu title={props.title} />)
  const element = screen.getByText(props.title)
  expect(element).toBeInTheDocument()
})
