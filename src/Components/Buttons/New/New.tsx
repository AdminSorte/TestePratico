import * as S from './styles'

import { CloseIcon } from '../../../assets/icons/'

interface Props {
  clickAction: () => void
  isClicked: boolean
}

const New = ({ clickAction, isClicked }: Props) => {
  return (
    <S.Wrapper
      data-testid="click"
      onClick={() => clickAction()}
      isClicked={isClicked}
    >
      <CloseIcon />
    </S.Wrapper>
  )
}

export { New }
