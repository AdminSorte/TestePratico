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
              <div key={index} onClick={() => openSelected(item.id)}>
                <TaskCard task={item} />
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
