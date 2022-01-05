import * as S from './styles'

interface Props {
  title: string
  content: string
}

const Card = ({ title, content }: Props) => {
  return (
    <S.Wrapper>
      <S.Content>
        <S.TitleContainer>
          <S.Title>{title}</S.Title>
        </S.TitleContainer>
        <S.TasksContainer>
          <div>{content}</div>
        </S.TasksContainer>
      </S.Content>
    </S.Wrapper>
  )
}

export { Card }
