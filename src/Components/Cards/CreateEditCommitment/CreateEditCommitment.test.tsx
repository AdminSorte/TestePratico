import { render, screen } from '@testing-library/react'
import { CreateEditCommitment } from '.'

// styles
import { ThemeProvider } from 'styled-components'
import { theme } from '../../../styles/themes'

describe('CreateEditCommitment', () => {
  test('should call select and close func on click', () => {
    const anything: any = []
    const closeFunc = jest.fn()

    render(
      <ThemeProvider theme={theme}>
        <CreateEditCommitment
          selectedNote={anything}
          close={closeFunc}
          deleteCommitment={jest.fn()}
          saveCommitment={jest.fn()}
        />
      </ThemeProvider>
    )
    screen.getByTestId('close').click()
    expect(closeFunc).toBeCalled()
  })
})
