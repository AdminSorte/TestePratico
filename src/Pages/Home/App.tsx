import { useEffect, useState } from 'react'

import * as S from './styles'

import { Menu } from '../../Components/index'
import { Card } from '../../Components/index'
import { TheHeader } from '../../Components/TheHeader/TheHeader'

// mock
import comp from '../../mock/commitments'
import { Commitment } from '../../types/commitment'

function App() {
  const [commitments, setCommitments] = useState<Commitment[]>([])
  const [filtCommitments, setFiltCommitments] = useState<Commitment[]>([])

  useEffect(() => {
    setTimeout(() => {
      setCommitments(comp)
      setFiltCommitments(comp)
    }, 1000)
  }, [])

  const clearSearch = () => {
    setFiltCommitments(commitments)
  }

  const onSearch = (search: string) => {
    search.includes('#') ? searchById(search) : searchByTitle(search)
  }

  const searchByTitle = (title: string) => {
    const searchLowercase = title.toLowerCase()

    setFiltCommitments(
      commitments.filter((commitment) => {
        const commitmentTitleLowercase = commitment.title.toLowerCase()

        return commitmentTitleLowercase.includes(searchLowercase)
      })
    )
  }

  const searchById = (id: string) => {
    const idNum = parseInt(id.split('#')[1], 10)

    setFiltCommitments(
      commitments.filter((commitment) => {
        return commitment.id === idNum
      })
    )
  }

  return (
    <div className="App">
      <S.Wrapper>
        <S.ContentContainer>
          <S.Header>
            <TheHeader />
            <Menu
              clearSearch={clearSearch}
              onSearch={(search) => onSearch(search)}
              title="Busque por nome ou #id"
            />
          </S.Header>
          <S.Content>
            <Card title="Minha agenda" content={filtCommitments} />
          </S.Content>
        </S.ContentContainer>
      </S.Wrapper>
    </div>
  )
}

export default App
