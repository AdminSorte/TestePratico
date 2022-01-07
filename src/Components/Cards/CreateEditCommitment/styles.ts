import styled from 'styled-components'

export const Wrapper = styled.div`
  display: flex;
  align-items: center;
  justify-content: center;

  width: 100%;
  height: 95%;

  background-color: ${({ theme }) => theme.colors.white};

  padding: 1.5rem;

  border-radius: 1rem;

  -webkit-box-shadow: 0px 5px 7px 0px rgba(0, 0, 0, 0.5);
  box-shadow: 0px 5px 7px 0px rgba(0, 0, 0, 0.5);
`

export const Content = styled.div`
  flex: 1;
  height: 100%;
`

export const Header = styled.div`
  display: flex;
  align-items: center;
  justify-content: space-between;

  margin-bottom: 0.5rem;

  padding: 1rem 0;

  height: 10%;
  width: 100%;

  & svg {
    cursor: pointer;
  }
`

export const Title = styled.input`
  font-size: 2rem;
  font-weight: bold;
  color: ${({ theme }) => theme.colors.luck_green};

  border: 2px solid ${({ theme }) => theme.colors.light_gray};
  border-radius: 1rem;
  
  padding: 1rem;
  margin-bottom: 0.5rem;

  width: 90%;
`

export const Body = styled.div`
  display: flex;

  padding: 1rem;

  height: 77%;

  border-radius: 1rem;
  border: 2px solid ${({ theme }) => theme.colors.light_gray};
`

export const Commitment = styled.textarea`
  width: 100%;
  height: 100%;

  border: none;

  font-size: 1.7rem;
  color: ${({ theme }) => theme.colors.dark_gray};

  resize: none;

  white-space: pre-wrap;
`

export const Footer = styled.div`
  width: 100%;
  height: 13%;

  margin-top: 0.5rem;

  display: flex;
  align-items: center;
  justify-content: space-between;

  & div {
    display: flex;

    & svg {
      color: ${({ theme }) => theme.colors.dark_gray};
      transition: 0.3s;

      &:hover {
        cursor: pointer;
        stroke: red;
        transition: 0.3s;
      }
    }
  }

  & span {
    font-weight: bold;
    font-size: 1.5rem;
    color: ${({ theme }) => theme.colors.dark_gray};
  }
`
