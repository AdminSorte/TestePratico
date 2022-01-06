import { useState } from 'react'

import * as S from './styles'

// icons
import { CloseIcon, TrashIcon, CheckIcon } from '../../../assets/icons'

// types
import { Commitment } from '../../../types/commitment'

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
    saveCommitment(commitment)
  }

  return (
    <S.Wrapper>
      <S.Content>
        <S.Header>
          <S.Title
            value={commitment.title}
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
            onChange={(change: React.ChangeEvent<HTMLTextAreaElement>) => {
              setCommitment({ ...commitment, description: change.target.value })
              setChange(true)
            }}
            defaultValue={commitment.description}
          />
        </S.Body>
        <S.Footer>
          <span>
            Última atualização <br /> {commitment.date}
          </span>

          <div
            onClick={() => {
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
            {change ? <CheckIcon /> : <TrashIcon />}
          </div>
        </S.Footer>
      </S.Content>
    </S.Wrapper>
  )
}

export { CreateEditCommitment }
