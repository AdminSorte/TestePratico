import React, { useState } from 'react';
import { Button } from '@material-ui/core';
import { Dispatch } from 'redux';
import { useDispatch } from 'react-redux';
import { UserDispatcher } from '../../../../store/User/actions';
import { CustomInput } from '../../../../components/custom-input';

export interface StateProps {
  handleFormRegister(): void;
  hasError: boolean;
}

export function FormLogin(props: StateProps) {
  const dispatch: Dispatch = useDispatch();
  const userDispatcher = new UserDispatcher(dispatch);

  const [email, setEmail] = useState<string>('');
  const [password, setPassword] = useState<string>('');
  const [emailError, setEmailError] = useState<boolean>(false);
  const [passwordError, setPasswordError] = useState<boolean>(false);
  const changeEmail = (event: any) => setEmail(event.target.value);
  const changePassword = (event: any) => setPassword(event.target.value);

  const handleLogin = (event: React.FormEvent) => {
    event.preventDefault();

    let valid: boolean = true;
    const expEmail: RegExp = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    
    if (!email || email.length < 9 || !expEmail.test(email)) {
      setEmailError(true);
      valid = false;
    }
    else setEmailError(false);

    if (!password || password.length < 8) {
      setPasswordError(true);
      valid = false;
    }
    else setPasswordError(false);

    if (valid) {
      userDispatcher.loginRequest({
        email: email,
        password: password
      });
    }
  }

  return (
    <>
      <div>
        <div className="sized-box-2"></div>
        <h3>Minha agenda minha vida</h3>
        <div className="sized-box"></div>
      </div>
      <div className="content-input">
        <CustomInput
          label="Email"
          placeholder="Digite seu e-mail"
          value={email}
          onChange={changeEmail}
          errorText="O e-mail é inválido"
          hasError={emailError}
        />
        <CustomInput
          label="Senha"
          placeholder="Digite sua senha"
          value={password}
          onChange={changePassword}
          errorText="Senha inválida"
          hasError={passwordError}
          type="password"
        />
      </div>
      <div>
        <div className="sized-box"></div> 
        <Button 
          variant="contained"
          size="large"
          color="primary"
          onClick={handleLogin}>
          LOGIN
        </Button>
      </div>
      <div>
        <div className="sized-box-2"></div>
        <a 
          href="#"
          onClick={props.handleFormRegister}>
          Não tem uma conta? Cria uma agora
        </a>
        <div className="sized-box-2"></div>
      </div>
    </>
  );
}