import { render, screen } from '@testing-library/react'
import { Card } from '.'

test('should render the text Hi, hacker!', () => {
  const props = {
    title: 'Minha agenda minha vida',
    content: 'teste',
  }

  render(<Card title={props.title} content={props.content} />)
  const element = screen.getByText(props.title)
  expect(element).toBeInTheDocument()
})
