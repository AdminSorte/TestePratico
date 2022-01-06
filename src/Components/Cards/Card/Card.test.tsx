import { render, screen } from '@testing-library/react'
import { Card } from '.'

import commitmentMock from '../../../mock/singleCommitment'

// TODO: Fix tests
describe('Card', () => {
  const props = {
    title: 'Minha agenda',
    content: commitmentMock,
  }

  it('should render the title of the Card', () => {
    render(<Card deleteSelected={() => {''}} openSelected={() => {''}} title={props.title} content={[]} />)

    const element = screen.getByText(props.title)

    expect(element).toBeInTheDocument()
  })

  it('should render the content of the Card', () => {
    render(
      <Card deleteSelected={() => {''}} openSelected={() => ''} title={props.title} content={props.content} />
    )

    const element = screen.getByText(props.content[0].description)

    expect(element).toBeInTheDocument()
  })
})
