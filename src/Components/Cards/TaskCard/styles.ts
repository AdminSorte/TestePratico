import styled from 'styled-components'

interface Props {
  color: string
}

export const Wrapper = styled.div`
  margin-bottom: 1rem;
`

export const Content = styled.div<Props>`
  border-radius: 0.5rem;
  padding: 0 1.2rem;

  border-top: 5px solid ${({ color }) => color};
  box-shadow: 0px 5px 7px 0px rgba(0, 0, 0, 0.2);
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

  &:hover {
    cursor: pointer;
  }
`

export const Body = styled.div`
  padding: 5px 0;

  &:hover {
    cursor: pointer;
  }
`

export const Title = styled.span<Props>`
  font-size: 2rem;
  font-weight: bold;
  color: ${({ color }) => color};
`

export const Id = styled.span<Props>`
  font-size: 1.5rem;
  font-weight: bold;
  color: ${({ color }) => color};
`

export const Description = styled.span`
  font-size: 1.5rem;

  margin-bottom: 0.5rem;
`

export const Date = styled.span<Props>`
  font-size: 1.5rem;
  font-weight: bold;
  color: ${({ color }) => color};
`

export const Footer = styled.div<Props>`
  display: flex;
  justify-content: space-between;
  align-items: center;

  width: 100%;

  padding: 5px 0;

  & svg {
    width: 2rem;
    transition: 0.2s;
    stroke: ${({ color }) => color};

    @media (min-width: 768px) {
      &:hover {
        stroke: ${({ theme }) => theme.colors.red};
        transition: 0.2s;
        cursor: pointer;
      }
    }
  }
`

export const Actions = styled.div`
  display: flex;
  align-items: center;
  justify-content: center;

  ${Id} {
    margin-right: 1rem;
  }
`
