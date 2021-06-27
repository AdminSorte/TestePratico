import React, { useState } from 'react';
import './style.css';
import { FormLogin } from './components/form-login';
import { FormRegister } from './components/form-register';
import Loader from 'react-loader-spinner';
import { UserState } from '../../store/User/types';
import { useSelector } from 'react-redux';
import { ApplicationState } from '../../store/rootReducer';
import { isAuthenticated } from '../../services/auth';
import { Redirect } from 'react-router-dom';

export function Auth() {
  const userState: UserState = useSelector<ApplicationState, UserState>((state: ApplicationState) => state.user);
  
  const [viewRegisterPage, setViewRegisterPage] = useState<boolean>(false);

  const handleFormRegister = () => {
    setViewRegisterPage(!viewRegisterPage);
  };

  const formLogin = () => (
    <div className="content-actions">
      <FormLogin 
        handleFormRegister={handleFormRegister}
        hasError={false}
      />
    </div>
  );

  const formRegister = () => (
    <div className="content-actions">
      <FormRegister
        handleFormRegister={handleFormRegister}
      />
    </div>
  );

  const loading = () => (
    <>
      <Loader type="Oval" color="#3f51b5" height={60} />
    </>
  );

  return (
    <div className="content">
      {
        userState.authenticated && isAuthenticated() ? <Redirect to="/todo" /> : null
      }
      {
        userState.loading ? loading() : (viewRegisterPage ? formRegister() : formLogin())
      }
    </div>
  );
}