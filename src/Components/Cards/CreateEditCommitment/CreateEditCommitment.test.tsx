import { render, screen } from '@testing-library/react'
import { CreateEditCommitment } from '.'

describe('CreateEditCommitment', () => {
  test('should call select and close func on click', () => {
    const anything: any = []
    const closeFunc = jest.fn()

    render(
      <CreateEditCommitment
        selectedNote={anything}
        close={closeFunc}
        deleteCommitment={jest.fn()}
        saveCommitment={jest.fn()}
      />
    )
    screen.getByTestId('close').click()
    expect(closeFunc).toBeCalled()
  })
})
