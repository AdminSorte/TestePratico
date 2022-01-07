import React, { useState, createContext, useContext, useEffect } from 'react'

// types
import { Commitment } from '../types/commitment'

// mock
import comp from '../mock/commitments'

interface ICommitment {
  filtCommitments: Commitment[]
  isLoading: boolean
  selectedCommitment: Commitment
  showModal: boolean
  clearSearch: () => void
  deleteCommitment: (id: number) => void
  onSearch: (search: string) => void
  openCommitment: (id: number) => void
  saveCommitment: (newCommitment: Commitment) => void
  setSelectedCommitment: (commitment: Commitment) => void
  toggleModal: () => void
}

export const CommitmentContext = createContext<ICommitment>({} as ICommitment)

export const CommitmentProvider: React.FC = ({ children }) => {
  const [lastId, setLastId] = useState(0)
  const [isLoading, setIsLoading] = useState(true)
  const [showModal, setShowModal] = useState(false)

  const [commitments, setCommitments] = useState<Commitment[]>([])
  const [filtCommitments, setFiltCommitments] = useState<Commitment[]>([])
  const [selectedCommitment, setSelectedCommitment] = useState<Commitment>(
    {} as Commitment
  )

  useEffect(() => {
    setTimeout(() => {
      const commitmentsAscOrder = sortAscByDate(comp)

      setCommitments(commitmentsAscOrder)
      setFiltCommitments(commitmentsAscOrder)
      setIsLoading(false)
    }, 1500)

    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [])

  useEffect(() => {
    if (isLoading) return

    const lastId = commitments[commitments.length - 1].id

    setLastId(lastId)

    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [isLoading])

  const sortAscByDate = (commitments: Commitment[]) => {
    return commitments.sort((a, b) => {
      const d1 = __changeDateFormat(a.date)
      const d2 = __changeDateFormat(b.date)

      return new Date(d2).getTime() - new Date(d1).getTime()
    })
  }

  const toggleModal = () => {
    setShowModal((old) => !old)
  }

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
    const confirm = window.confirm(
      'Tem certeza que deseja excluir esse compromisso?'
    )

    if (!confirm) return

    const newCommitments: Commitment[] = []

    filtCommitments.forEach((commitment) => {
      if (commitment.id === id) return

      newCommitments.push(commitment)
    })

    lastId - 1 === 0 ? setLastId(0) : setLastId(lastId - 1)
    setSelectedCommitment({} as Commitment)
    setCommitments(newCommitments)
    setFiltCommitments(newCommitments)
  }

  const saveCommitment = (newCommitment: Commitment) => {
    if (!newCommitment.title)
      return window.alert('O título do compromisso é obrigatório.')

    let newCommitments = [...commitments]

    let commitmentExist: boolean = false
    commitments.forEach(
      (commitment) =>
        commitment.id === newCommitment.id && (commitmentExist = true)
    )

    if (!commitmentExist) {
      newCommitment.id = lastId + 1
      setLastId((current) => current + 1)
      newCommitments.unshift(newCommitment)
    } else {
      newCommitments.forEach((commitment) => {
        if (commitment.id !== newCommitment.id) return

        commitment.title = newCommitment.title
        commitment.date = newCommitment.date
        commitment.hour = newCommitment.hour
        commitment.description = newCommitment.description
      })
    }

    const commitmentsAscOrder = sortAscByDate(newCommitments)
    setCommitments(commitmentsAscOrder)
    setFiltCommitments(commitmentsAscOrder)
  }

  const __changeDateFormat = (date: string) => {
    const [day, month, year] = date.split('/')

    return `${year}-${month}-${day}`
  }

  return (
    <CommitmentContext.Provider
      value={{
        filtCommitments: filtCommitments,
        isLoading: isLoading,
        selectedCommitment: selectedCommitment,
        showModal: showModal,

        clearSearch: clearSearch,
        deleteCommitment: deleteCommitment,
        onSearch: onSearch,
        openCommitment: openCommitment,
        saveCommitment: saveCommitment,
        setSelectedCommitment: setSelectedCommitment,
        toggleModal: toggleModal,
      }}
    >
      {children}
    </CommitmentContext.Provider>
  )
}

export function useCommitment() {
  return useContext(CommitmentContext)
}
