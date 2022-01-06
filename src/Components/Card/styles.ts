import styled from 'styled-components'

export const Wrapper = styled.div`
  flex: 1;

  width: 100%;
  height: 100%;
`

export const Content = styled.div`
  flex: 1;

  width: 100%;
  height: calc(100% - 10px);

  padding: 10px;

  border-radius: 15px;
  border: 1px solid #c6c6c6;

  overflow: hidden;
`

export const TitleContainer = styled.div`
  width: 100%;
  height: 5%;

  display: flex;
  align-items: center;

  margin-bottom: 10px;
`

export const Title = styled.div`
  flex: 1;

  font-size: 2.5rem;
  font-weight: bold;
  color: #2f2f2f;
`

export const TasksContainer = styled.div`
  width: 100%;
  height: 95%;

  overflow: auto;
  padding: 1rem;

  border-radius: 1rem;

  box-shadow: 0px 10px 5px rgba(237, 237, 237, 0.8) inset;
`
