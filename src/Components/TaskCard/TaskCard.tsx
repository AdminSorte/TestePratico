import * as S from './styles'

import { Commitment } from '../../types/commitment'

import { TrashIcon } from '../../assets/icons/TrashIcon'

interface Props {
  task: Commitment
}

const TaskCard = (props: Props) => {
  const { id, title, description, date } = props.task

  const idFormated = id < 10 ? `0${id}` : id
  const dateFormated = date.replace(/-/g, '/')
  // prettier-ignore
  const slicedDescription = description.length >= 150
    ? description.slice(0, 150) + '...'
    : description

  return (
    <S.Wrapper>
      <S.Content>
        <S.Header>
          <div>
            <S.Title>{title}</S.Title>
          </div>
        </S.Header>
        <S.Body>
          <S.Description>{slicedDescription}</S.Description>
        </S.Body>
        <S.Footer>
          <S.Date data-testid="date">{dateFormated}</S.Date>
          <S.Actions>
            <S.Id>#{idFormated}</S.Id>
            <TrashIcon />
          </S.Actions>
        </S.Footer>
      </S.Content>
    </S.Wrapper>
  )
}

export { TaskCard }
