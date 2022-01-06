import styled from 'styled-components'

export const Wrapper = styled.div`
  top: 0;
  left: 0;
  position: absolute;

  width: 100%;
  height: 100%;
  background-color: #00000060;

  display: flex;
  align-items: center;
  justify-content: center;
`

export const Content = styled.div`
  width: 90%;
  /* max-height: 80%; */
  /* max-height: 80%; */

  height: min(50rem, 80%);

  border-radius: 10px;
`
