import styled from 'styled-components'

export const Wrapper = styled.div`
  flex: 1;

  width: 100%;
  height: 50%;
`

export const Content = styled.div`
  flex: 1;

  width: 100%;
  height: calc(100% - 10px);

  border-radius: 10px;

  padding: 10px;

  border-radius: 15px;
  border: 1px solid #c6c6c6;
`

export const TitleContainer = styled.div`
  width: 100%;
  height: 15%;

  display: flex;
  align-items: center;
`

export const Title = styled.div`
  flex: 1;

  font-size: 2.5rem;
`

export const TasksContainer = styled.div`
  width: 100%;
  height: 85%;
`
