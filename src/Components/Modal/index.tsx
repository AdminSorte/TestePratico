import * as S from './styles'

interface Props {
  children: React.ReactNode
}

const Modal = ({ children }: Props) => {
  return (
    <S.Wrapper>
      <S.Content>{children}</S.Content>
    </S.Wrapper>
  )
}

export { Modal }
