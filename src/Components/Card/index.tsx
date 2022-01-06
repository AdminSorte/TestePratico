import { Commitment } from '../../types/commitment'
import { TaskCard } from '../TaskCard/TaskCard'
import * as S from './styles'

interface Props {
  title: string
  content: Commitment[]
}

const Card = ({ title, content }: Props) => {
  return (
    <S.Wrapper>
      <S.Content>
        <S.TitleContainer>
          <S.Title>{title}</S.Title>
        </S.TitleContainer>
        <S.TasksContainer>
          {content.map((item, index) => (
            <TaskCard key={index} task={item} />
          ))}
        </S.TasksContainer>
      </S.Content>
    </S.Wrapper>
  )
}

export { Card }
