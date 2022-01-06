import * as S from './styles'

// icons
import { CloseIcon, TrashIcon, EditIcon } from '../../../assets/icons'

// types
import { Commitment } from '../../../types/commitment'


interface Props {
  selectedNote: Commitment
  close: () => void
}

const CreateEditCommitment = ({ selectedNote, close }: Props) => {
  return (
    <S.Wrapper>
      <S.Content>
        <S.Header>
          <S.Title>{selectedNote.title}</S.Title>
          <div data-testid="close" onClick={close}>
            <CloseIcon />
          </div>
        </S.Header>
        <S.Body>
          <S.Commitment defaultValue={selectedNote.description} />
        </S.Body>
        <S.Footer>
          <span>
            Última atualização <br /> {selectedNote.date}
          </span>

          <div>
            <EditIcon />
            <TrashIcon />
          </div>
        </S.Footer>
      </S.Content>
    </S.Wrapper>
  )
}

export { CreateEditCommitment }
