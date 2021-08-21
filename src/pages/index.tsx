import type { NextPage } from 'next';
import { Fragment } from 'react';

import { AddButton } from '../components/AddButton';
import { CalendarList } from '../components/CalendarList';
import { Content } from '../components/Content';
import { Header } from '../components/Header';
import { Search } from '../components/Search';

const Home: NextPage = () => {
    return (
        
        <Fragment>

            <Header />

            <Content>
                
                <Search />

                <CalendarList />

            </Content>

            <AddButton />
        
        </Fragment>

    )
}

export default Home
