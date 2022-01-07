import { render, screen } from '@testing-library/react'
import { TaskCard } from '.'

describe('TaskCard', () => {
  const commitmentMock = {
    id: 1,
    description: 'Content of the commitment',
    date: '01/01/2022',
    hour: '12:00',
    title: 'Content of the title',
  }

  it('should render the title of the TaskCard', () => {
    render(
      <TaskCard
        openSelected={() => console.log('')}
        commitment={commitmentMock}
        deleteSelected={() => console.log('')}
      />
    )
    const element = screen.getByText(commitmentMock.title + '...')
    expect(element).toBeInTheDocument()
  })

  it('should render the description of the TaskCard', () => {
    render(
      <TaskCard
        openSelected={() => console.log('')}
        commitment={commitmentMock}
        deleteSelected={() => console.log('')}
      />
    )
    const element = screen.getByText(commitmentMock.description)
    expect(element).toBeInTheDocument()
  })

  it("should render the formated id(when it's value is less than 10) of the TaskCard", () => {
    render(
      <TaskCard
        openSelected={() => console.log('')}
        commitment={commitmentMock}
        deleteSelected={() => console.log('')}
      />
    )
    const element = screen.getByText(`#0${commitmentMock.id}`)
    expect(element).toBeInTheDocument()
  })
})
