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

  padding: 0px 15px;

  border-radius: 15px;
  border: 1px solid #c6c6c6;

  -webkit-box-shadow: 0px 4px 7px 0px rgba(150, 150, 150, 0.4);
  box-shadow: 0px 4px 7px 0px rgba(150, 150, 150, 0.4);
`

export const Title = styled.input`
  font-size: 2.3rem;
  border: none;

  outline: none;
  color: #2f2f2f;

`

export const Icon = styled.div`
  height: 30px;
  width: 30px;

  display: flex;
  align-items: center;
  justify-content: center;
`
