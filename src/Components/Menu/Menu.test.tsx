import { render, screen } from '@testing-library/react'
import { Menu } from '.'

describe('Menu', () => {
  it('should render the title of the menu bar', () => {
    const props = {
      title: 'Minha agenda',
    }

    render(
      <Menu
        clearSearch={() => console.log('oi')}
        onSearch={() => console.log('oi')}
        title={props.title}
      />
    )
    const element = screen.getByTestId('search')
    const placeholder = element.getAttribute('placeholder')

    expect(placeholder).toBe(props.title)
  })
})
