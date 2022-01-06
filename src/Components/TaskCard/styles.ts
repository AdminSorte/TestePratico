import styled from 'styled-components'

export const Wrapper = styled.div`
  margin-bottom: 10px;
`

export const Content = styled.div`
  border-radius: 10px;
  padding: 0 12px;

  border: 1px solid #c6c6c6;
`

export const Header = styled.div`
  width: 100%;
  font-size: 2.3rem;
  padding: 5px 0;

  flex: 1;

  & div {
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: space-between;
  }
`

export const Body = styled.div`
  padding: 5px 0;
`

export const Title = styled.span`
  font-size: 2rem;
  font-weight: bold;
  color: #2f2f2f;
`

export const Id = styled.span`
  font-size: 1.5rem;
  font-weight: bold;
  color: #2f2f2f;
`

export const Description = styled.span`
  font-size: 1.5rem;
  margin-bottom: 5px;
`

export const Date = styled.span`
  font-size: 1.5rem;
  font-weight: bold;
  color: #2f2f2f;
`

export const Footer = styled.div`
  display: flex;
  justify-content: space-between;
  align-items: center;

  width: 100%;

  padding: 5px 0;

  & svg {
    width: 20px;
    transition: 0.2s;

    &:hover {
      stroke: red;
      transition: 0.2s;
    }
  }
`

export const Actions = styled.div`
  display: flex;
  align-items: center;
  justify-content: center;

  ${Id} {
    margin-right: 10px;
  }
`
