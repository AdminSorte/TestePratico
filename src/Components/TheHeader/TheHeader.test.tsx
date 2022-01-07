import { render, screen } from '@testing-library/react'
import { TheHeader } from '.'

// styles
import { ThemeProvider } from 'styled-components'
import { theme } from '../../styles/themes'

describe('TheHeader', () => {
  it('should render the title of the TaskCard', () => {
    render(
      <ThemeProvider theme={theme}>
        <TheHeader />
      </ThemeProvider>
    )
    const title = 'Minha Agenda Minha Vida'
    const element = screen.getByText(title)
    expect(element).toBeInTheDocument()
  })
})
