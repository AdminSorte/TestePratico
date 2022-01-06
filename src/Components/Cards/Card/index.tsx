import { Commitment } from '../../../types/commitment'
import { TaskCard } from '../TaskCard/TaskCard'
import * as S from './styles'

interface Props {
  title: string
  content: Commitment[]
  openSelected: (id: number) => void
}

const Card = ({ title, content, openSelected }: Props) => {
  return (
    <S.Wrapper>
      <S.Content>
        <S.TitleContainer>
          <S.Title>{title}</S.Title>
        </S.TitleContainer>
        <S.TasksContainer>
          {content.length ? (
            content.map((item, index) => (
              <div onClick={() => openSelected(item.id)}>
                <TaskCard key={index} task={item} />
              </div>
            ))
          ) : (
            <div
              style={{
                display: 'flex',
                width: '100%',
                height: '100%',
                backgroundColor: 'teal',
                justifyContent: 'center',
                alignItems: 'center',
              }}
            >
              <p>Loading</p>
            </div>
          )}
        </S.TasksContainer>
      </S.Content>
    </S.Wrapper>
  )
}

export { Card }
