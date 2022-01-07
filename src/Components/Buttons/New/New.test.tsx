import { render, screen } from '@testing-library/react'
import { New } from './New'

// styles
import { ThemeProvider } from 'styled-components'
import { theme } from '../../../styles/themes'

describe('New', () => {
  it('should call clickAction on click', () => {
    const clickAction = jest.fn()

    render(
      <ThemeProvider theme={theme}>
        <New clickAction={() => clickAction()} isClicked={false} />
      </ThemeProvider>
    )
    screen.getByTestId('click').click()
    expect(clickAction).toHaveBeenCalled()
  })
})
