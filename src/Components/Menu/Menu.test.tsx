import { render, screen } from '@testing-library/react'
import { Menu } from '.'

// styles
import { ThemeProvider } from 'styled-components'
import { theme } from '../../styles/themes'

describe('Menu', () => {
  it('should render the title of the menu bar', () => {
    const props = {
      title: 'Minha agenda',
    }

    render(
      <ThemeProvider theme={theme}>
        <Menu
          clearSearch={() => console.log('oi')}
          onSearch={() => console.log('oi')}
          title={props.title}
        />
      </ThemeProvider>
    )
    const element = screen.getByTestId('search')
    const placeholder = element.getAttribute('placeholder')

    expect(placeholder).toBe(props.title)
  })
})
