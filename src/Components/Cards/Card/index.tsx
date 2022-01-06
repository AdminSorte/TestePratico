import { Commitment } from '../../../types/commitment'
import { TaskCard } from '../TaskCard/TaskCard'

// components
import { Loading } from '../../index'

// style
import * as S from './styles'

interface Props {
  title: string
  content: Commitment[]
  openSelected: (id: number) => void
  deleteSelected: (id: number) => void
}

const Card = ({ title, content, openSelected, deleteSelected }: Props) => {
  return (
    <S.Wrapper>
      <S.Content>
        <S.TitleContainer>
          <S.Title>{title}</S.Title>
        </S.TitleContainer>
        <S.TasksContainer>
          {content.length ? (
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
