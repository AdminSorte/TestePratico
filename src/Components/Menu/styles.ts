import styled from 'styled-components'

export const Wrapper = styled.div`
  font-size: 2.5rem;

  display: flex;
  align-items: center;
  justify-content: center;

  width: 100%;
  height: 5rem;

  &:hover {
    cursor: pointer;
  }
`

export const Content = styled.div`
  display: flex;
  align-items: center;
  justify-content: space-between;

  width: 100%;
  height: 100%;

  padding-left: 1.5rem;

  background-color: ${({ theme }) => theme.colors.light_gray};

  border-radius: 1rem;

  overflow: hidden;

  -webkit-box-shadow: 0px 4px 7px 0px rgba(150, 150, 150, 0.4);
  box-shadow: 0px 4px 7px 0px rgba(150, 150, 150, 0.4);
`

export const Title = styled.input`
  font-size: 1.8rem;

  border: none;

  color: ${({ theme }) => theme.colors.gray};

  background-color: transparent;

  width: 100%;
  padding-right: 1rem;

  @media (min-width: 768px) {
    padding-top: 0.5rem;
  }
`

export const IconContainer = styled.div`
  height: 100%;
  width: 5.5rem;

  background-color: ${({ theme }) => theme.colors.luck_green};

  display: flex;
  align-items: center;
  justify-content: center;

  & svg {
    width: 5.5rem;
    stroke: ${({ theme }) => theme.colors.white};
  }
`
