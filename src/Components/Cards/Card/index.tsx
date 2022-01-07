import { Commitment } from '../../../types/commitment'
import { TaskCard } from '../../.'

// components
import { Loading } from '../../.'

// style
import * as S from './styles'

interface Props {
  content: Commitment[]
  isLoading: boolean
  title: string

  deleteSelected: (id: number) => void
  openSelected: (id: number) => void
}

const Card = ({
  title,
  content,
  openSelected,
  deleteSelected,
  isLoading,
}: Props) => {
  return (
    <S.Wrapper>
      <S.Content>
        <S.TitleContainer>
          <S.Title>{title}</S.Title>
        </S.TitleContainer>
        <S.TasksContainer>
          {!isLoading ? (
            content.map((commitment, index) => (
              <div key={index}>
                <TaskCard
                  data-testid="task-card-content"
                  commitment={commitment}
                  openSelected={() => openSelected(commitment.id)}
                  deleteSelected={() => deleteSelected(commitment.id)}
                />
              </div>
            ))
          ) : (
            <S.LoadContainer>
              <Loading />
            </S.LoadContainer>
          )}
        </S.TasksContainer>
      </S.Content>
    </S.Wrapper>
  )
}

export { Card }
