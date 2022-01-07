import { useState } from 'react'

import * as S from './styles'

// icons
import { CloseIcon, TrashIcon, CheckIcon } from '../../../assets/icons'

// types
import { Commitment } from '../../../types/commitment'

// utils
import { generateToday } from '../../../utils/generateToday'

interface Props {
  selectedNote: Commitment
  close: () => void
  saveCommitment: (commitment: Commitment) => void
  deleteCommitment: () => void
}

const CreateEditCommitment = ({
  selectedNote,
  close,
  saveCommitment,
  deleteCommitment,
}: Props) => {
  const [change, setChange] = useState(false)
  const [commitment, setCommitment] = useState<Commitment>(selectedNote)

  const save = () => {
    const today = generateToday()

    const newCommitment = {
      ...commitment,
      date: today.date,
      hour: today.hour,
    }

    saveCommitment(newCommitment)
  }

  return (
    <S.Wrapper>
      <S.Content>
        <S.Header>
          <S.Title
            type="text"
            value={commitment.title || ''}
            placeholder="Título"
            onChange={(change: React.ChangeEvent<HTMLInputElement>) => {
              setCommitment({ ...commitment, title: change.target.value })
              setChange(true)
            }}
          />
          <div data-testid="close" onClick={close}>
            <CloseIcon />
          </div>
        </S.Header>
        <S.Body>
          <S.Commitment
            placeholder="Descrição"
            onChange={(change: React.ChangeEvent<HTMLTextAreaElement>) => {
              setCommitment({ ...commitment, description: change.target.value })
              setChange(true)
            }}
            value={commitment.description}
          />
        </S.Body>
        <S.Footer>
          <span>
            Última atualização <br /> {commitment.date} - {commitment.hour}
          </span>

          <div
            onClick={() => {
              if (!commitment.description) return

              if (!commitment.title)
                return window.alert('O título do compromisso é obrigatório.')

              if (!change) {
                close()
                deleteCommitment()
                return
              }

              save()
              setChange(false)
              close()
            }}
          >
            {change || !selectedNote.id ? <CheckIcon /> : <TrashIcon />}
          </div>
        </S.Footer>
      </S.Content>
    </S.Wrapper>
  )
}

export { CreateEditCommitment }
