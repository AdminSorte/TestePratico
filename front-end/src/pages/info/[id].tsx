import { GetServerSideProps, NextPage } from 'next';
import { Fragment } from 'react';

import { Header } from '../../components/Header';
import { Content } from '../../components/Content';
import { Resume } from '../../components/Resume';

import { api } from '../../services/api';

interface IInfoProps {
    info: {
        id: string;
        date: string;
        description: string;
        description_short: string;
    }
}

interface IParams {
    id: string;
}

const Info = ({ info }: IInfoProps) => {
    return (

        <Fragment>

            <Header />

            <Content>

                <Resume info={info} />

            </Content>

        </Fragment>

    )
};

export default Info;

export const getServerSideProps: GetServerSideProps = async ({ params }) => {

    const { id } = params;

    try {

        const { data } = await api.get(`calendar/${id}`);

        return {
            props: {
                info: data
            }
        }
        
    } catch (error) {        

        return {
            redirect: {
                destination: "/",
                permanent: false
            }
        }

    }

    

}
