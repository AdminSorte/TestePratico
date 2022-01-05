import * as S from './styles'

import { MenuIcon } from '../../assets/icons/MenuIcon'

type Props = {
  title: string
}

const Menu = ({ title }: Props) => {
  return (
    <S.Wrapper>
      <S.Content>
        <S.Title>{title}</S.Title>
        <MenuIcon />
      </S.Content>
    </S.Wrapper>
  )
}

export { Menu }
