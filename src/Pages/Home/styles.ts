import styled from 'styled-components'

export const Wrapper = styled.div`
  display: flex;
  justify-content: center;
  `

export const ContentContainer = styled.div`
  min-height: 100vh;
  width: 80rem;
  
  padding: 0 1rem;  
  position: relative;
  `

export const Header = styled.div`
  width: 100%;
  height: 20%;
  max-height: 20vh;
  min-height: 15rem;
  
  display: flex;
  align-items: center;
  justify-content: space-between;
  flex-direction: column;
  
  padding: 1rem;
`

export const Content = styled.div`
  display: flex;
  align-items: center;

  width: 100%;
  height: 80%;
  max-height: 80vh;

  padding: 1rem;
`
