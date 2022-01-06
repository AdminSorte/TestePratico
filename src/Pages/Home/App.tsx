import { useEffect, useState } from 'react'

// styles
import * as S from './styles'

// components
import {
  Card,
  CreateEditCommitment,
  Menu,
  Modal,
  TheHeader,
} from '../../Components/index'

// types
import { Commitment } from '../../types/commitment'

// mock
import comp from '../../mock/commitments'

function App() {
  const [showModal, setShowModal] = useState(false)

  // commitments
  const [commitments, setCommitments] = useState<Commitment[]>([])
  const [filtCommitments, setFiltCommitments] = useState<Commitment[]>([])
  const [selectedCommitment, setSelectedCommitment] = useState<Commitment>(
    {} as Commitment
  )

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

  const openCommitment = (id: number) => {
    const selectedCommitment = commitments.filter(
      (commitment) => commitment.id === id && commitment
    )[0]

    setSelectedCommitment(selectedCommitment)
    setShowModal(true)
  }

  const deleteCommitment = (id: number) => {
    // confirm delete
    const confitm = window.confirm(
      'Tem certeza que deseja excluir essa tarefa?'
    )

    if (!confitm) return

    const newCommitments: Commitment[] = []

    filtCommitments.forEach((commitment) => {
      if (commitment.id === id) return

      newCommitments.push(commitment)
    })

    setCommitments(newCommitments)
    setFiltCommitments(newCommitments)
  }

  const saveCommitment = (newCommitment: Commitment) => {
    let newCommitments = [...commitments]

    newCommitments.forEach((commitment) => {
      if (commitment.id !== newCommitment.id) return

      commitment.title = newCommitment.title
      commitment.description = newCommitment.description
    })

    setCommitments(newCommitments)
    setFiltCommitments(newCommitments)
  }

  return (
    <div className="App">
      {showModal && (
        <Modal>
          <CreateEditCommitment
            selectedNote={selectedCommitment}
            close={() => setShowModal(false)}
            deleteCommitment={() => deleteCommitment(selectedCommitment.id)}
            saveCommitment={(commitment: Commitment) =>
              saveCommitment(commitment)
            }
          />
        </Modal>
      )}

      {/*  */}
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
            <Card
              title="Minha agenda"
              content={filtCommitments}
              openSelected={(id) => openCommitment(id)}
              deleteSelected={(id) => deleteCommitment(id)}
            />
          </S.Content>
        </S.ContentContainer>
      </S.Wrapper>
    </div>
  )
}

export default App
