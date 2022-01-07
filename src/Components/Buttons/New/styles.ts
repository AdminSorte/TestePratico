import styled from 'styled-components'

interface Props {
  isClicked: boolean
}

export const Wrapper = styled.div<Props>`
  width: 6rem;
  height: 6rem;

  display: flex;
  align-items: center;
  justify-content: center;

  font-size: 5rem;
  color: #fff;
  text-align: center;

  position: fixed;

  border-radius: 50%;

  background-color: #309583;

  z-index: 10;

  bottom: 2rem;
  right: 2rem;

  box-shadow: 0px 0px 10px 5px rgba(0, 0, 0, 0.3);

  ${({ isClicked }) =>
    isClicked
      ? `animation: rotate 0.1s linear forwards;`
      : `animation: rotateBack 0.1s linear forwards;`}

  @keyframes rotate {
    from {
      transform: rotate(-45deg);
    }
    to {
      transform: rotate(0deg);
    }
  }

  @keyframes rotateBack {
    from {
      transform: rotate(0deg);
    }
    to {
      transform: rotate(-45deg);
    }
  }

  & svg {
    stroke: #fff;
  }
`
