import styled from 'styled-components'

export const Wrapper = styled.div`
  display: flex;
  justify-content: center;

  `

export const ContentContainer = styled.div`
  min-height: 100vh;
  max-width: 1000px;
  
  padding: 0 10px;
  
  `

export const Header = styled.div`
  width: 100%;
  height: 20%;
  max-height: 20vh;
  
  display: flex;
  align-items: center;
  justify-content: space-between;
  flex-direction: column;
  
  padding: 10px;
`

export const Content = styled.div`
  display: flex;
  align-items: center;

  width: 100%;
  height: 80%;
  max-height: 80vh;

  padding: 10px;
`
