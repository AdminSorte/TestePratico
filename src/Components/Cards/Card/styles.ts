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
  box-shadow: 0px 5px 7px 0px rgba(0, 0, 0, 0.5);

  background-color: ${({ theme }) => theme.colors.white};

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
  color: ${({ theme }) => theme.colors.luck_green};
`

export const TasksContainer = styled.div`
  width: 100%;
  height: 95%;

  overflow: auto;
  padding: 1rem;

  border-radius: 1rem;

  box-shadow: 0px 15px 0.2rem rgba(237, 237, 237, 0.2) inset;
`

export const LoadContainer = styled.div`
  display: flex;
  width: 100%;
  height: 100%;
  justify-content: center;
  align-items: center;
`
