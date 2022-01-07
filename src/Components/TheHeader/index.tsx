import * as S from './styles'

import LogoSOL from '../../assets/images/logo_sol.png'

const TheHeader = () => {
  return (
    <S.Wrapper>
      <S.Content>
        <S.LogoContainer>
          <S.Logo
            src={LogoSOL}
            alt="Logo sorte online com o texto Minha agenda minha vida ao lado"
          />
        </S.LogoContainer>
        <S.Title>Minha Agenda <br /> Minha Vida</S.Title>
      </S.Content>
    </S.Wrapper>
  )
}

export { TheHeader }
