import { render, screen } from '@testing-library/react'
import { Card } from '.'

import commitmentMock from '../../../mock/singleCommitment'

describe('Card', () => {
  const props = {
    title: 'Minha agenda',
    content: commitmentMock,
  }

  it('should render the title of the Card', () => {
    render(
      <Card
        isLoading={false}
        deleteSelected={jest.fn()}
        openSelected={jest.fn()}
        title={props.title}
        content={[]}
      />
    )

    const element = screen.getByText(props.title)

    expect(element).toBeInTheDocument()
  })

  it('should render the content of the Card', () => {
    render(
      <Card
        isLoading={false}
        deleteSelected={jest.fn()}
        openSelected={() => ''}
        title={props.title}
        content={props.content}
      />
    )

    const element = screen.getByText(props.content[0].description)

    expect(element).toBeInTheDocument()
  })
})
