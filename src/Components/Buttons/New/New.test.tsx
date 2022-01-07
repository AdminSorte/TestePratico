import { render, screen } from '@testing-library/react'
import { New } from './New'

describe('New', () => {
  it('should call clickAction on click', () => {
    const clickAction = jest.fn()

    render(<New clickAction={() => clickAction()} isClicked={false} />)
    screen.getByTestId('click').click()
    expect(clickAction).toHaveBeenCalled()
  })
})
