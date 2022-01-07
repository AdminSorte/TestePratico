import styled from 'styled-components'

export const Wrapper = styled.div`
  width: 100%;
  height: 60%;

  display: flex;
  align-items: center;
  justify-content: center;

  @media (min-width: 768px) {
    height: 100%;
  }
`

export const Content = styled.div`
  width: 100%;
  height: 100%;

  padding: 10px 0;

  display: flex;
  align-items: center;
  justify-content: space-between;

`

export const LogoContainer = styled.div`
  width: 50%;
  max-width: 30rem;
`

export const Logo = styled.img`
  width: 90%;
`

export const Title = styled.span`
  font-size: 2rem;
  font-weight: bold;
  color: #1a8a75;

  @media (min-width: 768px) {
    font-size: 3rem;
  }
`
