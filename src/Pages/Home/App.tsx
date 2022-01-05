import { Menu } from '../../Components/index'
import { Card } from '../../Components/index'

import * as S from './styles'

function App() {
  return (
    <div className="App">
      <S.Wrapper>
        <S.ContentContainer>
          <S.Header>
            <Menu title="Minha agenda minha vida" />
          </S.Header>
          <S.Content>
            <Card title="Hoje" content="teste " />
            <Card title="Próximos compromissos" content="teste " />
          </S.Content>
        </S.ContentContainer>
      </S.Wrapper>
    </div>
  )
}

export default App
