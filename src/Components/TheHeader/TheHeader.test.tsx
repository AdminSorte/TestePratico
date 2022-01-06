import { render, screen } from '@testing-library/react'
import { TheHeader } from './TheHeader'

describe('TheHeader', () => {
  it('should render the title of the TaskCard', () => {
    render(<TheHeader />)
    const title = 'Minha agenda Minha vida'
    const element = screen.getByText(title)
    expect(element).toBeInTheDocument()
  })
})
