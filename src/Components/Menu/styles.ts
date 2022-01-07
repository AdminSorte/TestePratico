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

  padding-left: 15px;

  background-color: #e1e3e4;

  border-radius: 10px;
  /* border: 1px solid #484848; */

  overflow: hidden;

  -webkit-box-shadow: 0px 4px 7px 0px rgba(150, 150, 150, 0.4);
  box-shadow: 0px 4px 7px 0px rgba(150, 150, 150, 0.4);
`

export const Title = styled.input`
  font-size: 1.8rem;

  border: none;

  color: #8f8f90;

  background-color: transparent;
`

export const IconContainer = styled.div`
  height: 100%;
  width: 50px;

  background-color: #188a74;

  display: flex;
  align-items: center;
  justify-content: center;

  & svg {
    stroke: #fff;
  }
`
