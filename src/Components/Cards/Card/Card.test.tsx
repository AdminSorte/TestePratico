import { render, screen } from '@testing-library/react'
import { Card } from '.'

import commitmentMock from '../../../mock/singleCommitment'

// styles
import { ThemeProvider } from 'styled-components'
import { theme } from '../../../styles/themes'

describe('Card', () => {
  const props = {
    title: 'Minha agenda',
    content: commitmentMock,
  }

  it('should render the title of the Card', () => {
    render(
      <ThemeProvider theme={theme}>
        <Card
          isLoading={false}
          deleteSelected={jest.fn()}
          openSelected={jest.fn()}
          title={props.title}
          content={[]}
        />
      </ThemeProvider>
    )

    const element = screen.getByText(props.title)

    expect(element).toBeInTheDocument()
  })

  it('should render the content of the Card', () => {
    render(
      <ThemeProvider theme={theme}>
        <Card
          isLoading={false}
          deleteSelected={jest.fn()}
          openSelected={() => ''}
          title={props.title}
          content={props.content}
        />
      </ThemeProvider>
    )

    const element = screen.getByText(props.content[0].description)

    expect(element).toBeInTheDocument()
  })
})
