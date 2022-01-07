import styled from 'styled-components'

export const Spinner = styled.div`
  border: 5px solid #f3f3f3;
  border-top: 5px solid ${({ theme }) => theme.colors.luck_green};
  border-radius: 50%;
  width: 40px;
  height: 40px;
  animation: spin 1.5s linear infinite;

  @keyframes spin {
    0% {
      transform: rotate(0deg);
    }
    100% {
      transform: rotate(360deg);
    }
  }
`
