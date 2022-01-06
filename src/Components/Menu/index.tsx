import { useState } from 'react'
import * as S from './styles'

import { SearchIcon } from '../../assets/icons/SearchIcon'
import { CloseIcon } from '../../assets/icons/CloseIcon'

type Props = {
  title: string

  clearSearch: () => void
  onSearch: (search: string) => void
}

const Menu = ({ title, clearSearch, onSearch }: Props) => {
  const [search, setSearch] = useState('')

  return (
    <S.Wrapper>
      <S.Content>
        <S.Title
          data-testid="search"
          placeholder={title}
          onChange={(value: any) => {
            onSearch(value.target.value)
            setSearch(value.target.value)
          }}
          value={search}
        />
        {!!search.length ? (
          <div
            onClick={() => {
              setSearch('')
              clearSearch()
            }}
          >
            <CloseIcon />
          </div>
        ) : (
          <SearchIcon />
        )}
      </S.Content>
    </S.Wrapper>
  )
}

export { Menu }
