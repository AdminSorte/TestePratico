import { render, screen } from '@testing-library/react'
import { TheHeader } from '.'

describe('TheHeader', () => {
  it('should render the title of the TaskCard', () => {
    render(<TheHeader />)
    const title = 'Minha Agenda Minha Vida'
    const element = screen.getByText(title)
    expect(element).toBeInTheDocument()
  })
})
