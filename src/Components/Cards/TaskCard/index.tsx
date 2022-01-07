import * as S from './styles'

import { Commitment } from '../../../types/commitment'

import { TrashIcon } from '../../../assets/icons/TrashIcon'

interface Props {
  commitment: Commitment
  deleteSelected: () => void
  openSelected: () => void
}

const TaskCard = ({ commitment, deleteSelected, openSelected }: Props) => {
  const currentColor = '#1a8a75'
  const { id, title, description, date, hour } = commitment

  const returnSliced = (string: string, maxLength: number) => {
    return string.length > maxLength
      ? string.slice(0, maxLength) + '...'
      : string
  }

  const open = () => {
    openSelected()
  }

  const idFormated = id < 10 ? `0${id}` : id
  const slicedDescription = returnSliced(description, 150)
  const slicedTitle = returnSliced(title, 20)

  return (
    <S.Wrapper>
      <S.Content color={currentColor}>
        <S.Header onClick={open}>
          <div>
            <S.Title color={currentColor}>{slicedTitle}</S.Title>
          </div>
        </S.Header>
        <S.Body onClick={open}>
          <S.Description>{slicedDescription}</S.Description>
        </S.Body>
        <S.Footer color={currentColor}>
          <S.Date color={currentColor}>
            {date} - {hour}
          </S.Date>
          <S.Actions onClick={deleteSelected}>
            <S.Id color={currentColor}>#{idFormated}</S.Id>
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
