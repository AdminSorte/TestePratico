import { render, screen } from '@testing-library/react'
import { TaskCard } from '.'

// styles
import { ThemeProvider } from 'styled-components'
import { theme } from '../../../styles/themes'

describe('TaskCard', () => {
  const commitmentMock = {
    id: 1,
    description: 'Content of the commitment',
    date: '01/01/2022',
    hour: '12:00',
    title: 'Content title',
  }

  it('should render the title of the TaskCard', () => {
    render(
      <ThemeProvider theme={theme}>
        <TaskCard
          openSelected={() => console.log('')}
          commitment={commitmentMock}
          deleteSelected={() => console.log('')}
        />
      </ThemeProvider>
    )
    const element = screen.getByTestId('title').innerHTML
    expect(element).toBe(commitmentMock.title)
  })

  it('should render the description of the TaskCard', () => {
    render(
      <ThemeProvider theme={theme}>
        <TaskCard
          openSelected={() => console.log('')}
          commitment={commitmentMock}
          deleteSelected={() => console.log('')}
        />
      </ThemeProvider>
    )
    const element = screen.getByText(commitmentMock.description)
    expect(element).toBeInTheDocument()
  })

  it("should render the formated id(when it's value is less than 10) of the TaskCard", () => {
    render(
      <ThemeProvider theme={theme}>
        <TaskCard
          openSelected={() => console.log('')}
          commitment={commitmentMock}
          deleteSelected={() => console.log('')}
        />
      </ThemeProvider>
    )
    const element = screen.getByText(`#0${commitmentMock.id}`)
    expect(element).toBeInTheDocument()
  })
})
