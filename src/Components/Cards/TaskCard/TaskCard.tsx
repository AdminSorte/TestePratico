import * as S from './styles'

import { Commitment } from '../../../types/commitment'

import { TrashIcon } from '../../../assets/icons/TrashIcon'

interface Props {
  commitment: Commitment
  deleteSelected: () => void
  openSelected: () => void
}

const TaskCard = ({ commitment, deleteSelected, openSelected }: Props) => {
  const { id, title, description, date, hour } = commitment

  const idFormated = id < 10 ? `0${id}` : id
  // prettier-ignore
  const slicedDescription = description.length >= 150
    ? description.slice(0, 150) + '...'
    : description

  const open = () => {
    openSelected()
  }

  return (
    <S.Wrapper>
      <S.Content>
        <S.Header onClick={open}>
          <div>
            <S.Title>{title}</S.Title>
          </div>
        </S.Header>
        <S.Body onClick={open}>
          <S.Description>{slicedDescription}</S.Description>
        </S.Body>
        <S.Footer>
          <S.Date>
            {date} - {hour}
          </S.Date>
          <S.Actions onClick={deleteSelected}>
            <S.Id>#{idFormated}</S.Id>
            <div>
              <TrashIcon />
            </div>
          </S.Actions>
        </S.Footer>
      </S.Content>
    </S.Wrapper>
  )
}

export { TaskCard }
