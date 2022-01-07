// context
import { useCommitment } from '../../context/Commitments'

// components
import {
  Card,
  CreateEditCommitment,
  Menu,
  Modal,
  TheHeader,
  New,
} from '../../Components/index'

// styles
import * as S from './styles'

// types
import { Commitment } from '../../types/commitment'

function App() {
  const {
    filtCommitments,
    isLoading,
    selectedCommitment,
    showModal,

    clearSearch,
    deleteCommitment,
    onSearch,
    openCommitment,
    saveCommitment,
    setSelectedCommitment,
    toggleModal,
  } = useCommitment()

  return (
    <div className="App">
      <S.Wrapper>
        <New
          isClicked={showModal}
          clickAction={() => {
            toggleModal()
            setSelectedCommitment({} as Commitment)
          }}
        />
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
              content={filtCommitments}
              title="Minha agenda"
              isLoading={isLoading}
              deleteSelected={(id) => deleteCommitment(id)}
              openSelected={(id) => openCommitment(id)}
            />
          </S.Content>
        </S.ContentContainer>
      </S.Wrapper>

      {/*  */}
      {showModal && (
        <Modal>
          <CreateEditCommitment
            selectedNote={selectedCommitment}
            close={() => {
              toggleModal()
              setSelectedCommitment({} as Commitment)
            }}
            deleteCommitment={() => deleteCommitment(selectedCommitment.id)}
            saveCommitment={(commitment: Commitment) =>
              saveCommitment(commitment)
            }
          />
        </Modal>
      )}
    </div>
  )
}

export default App
