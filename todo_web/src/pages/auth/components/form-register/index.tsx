import React, { useState } from 'react';
import { Dispatch } from 'redux';
import { useDispatch } from 'react-redux';
import { UserDispatcher } from '../../../../store/User/actions';
import { Button } from '@material-ui/core';
import { CustomInput } from '../../../../components/custom-input';

export interface StateProps {
  handleFormRegister(): void;
}

export function FormRegister(props: StateProps) {
  const dispatch: Dispatch = useDispatch();
  const userDispatcher = new UserDispatcher(dispatch);

  const [name, setName] = useState<string>('');
  const [lastName, setLastName] = useState<string>('');
  const [email, setEmail] = useState<string>('');
  const [password, setPassword] = useState<string>('');
  const [confirmPassword, setConfirmPassword] = useState<string>('');
  const [nameError, setNameError] = useState<boolean>(false);
  const [lastNameError, setLastNameError] = useState<boolean>(false);
  const [emailError, setEmailError] = useState<boolean>(false);
  const [passwordError, setPasswordError] = useState<boolean>(false);
  const [confirmPasswordError, setConfirmPasswordError] = useState<boolean>(false);
  

  const changeName = (event: any) => setName(event.target.value);
  const changeLastName = (event: any) => setLastName(event.target.value);
  const changeEmail = (event: any) => setEmail(event.target.value);
  const changePassword = (event: any) => setPassword(event.target.value);
  const changeConfirmPassword = (event: any) => setConfirmPassword(event.target.value);

  const handleRegister = (event: React.FormEvent) => {
    event.preventDefault();

    let valid = true;
    const expEmail: RegExp = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    if (!email || email.length < 9 || !expEmail.test(email)) {
      setEmailError(true);
      valid = false;
    }
    else setEmailError(false);

    if (!name || name.length < 3) {
      setNameError(true);
      valid = false;
    }
    else setNameError(false);

    if (!lastName || lastName.length < 3) {
      setLastNameError(true);
      valid = false;
    }
    else setLastNameError(false);

    if (!password || password.length < 8) {
      setPasswordError(true);
      valid = false;
    }
    else setPasswordError(false);

    if (password !== confirmPassword) {
      setConfirmPasswordError(true);
      valid = false;
    }
    else setConfirmPasswordError(false);

    if (valid) {
      userDispatcher.registerRequest({
        email: email,
        password: password,
        name: name,
        lastName: lastName
      });
    }
  }

  return (
    <>
      <div>
        <div className="sized-box-2"></div>
        <h3>Cadastrar usuário</h3>
        <div className="sized-box"></div>
      </div>
      <div className="content-input">
        <CustomInput
          label="Nome"
          placeholder="Digite seu nome"
          value={name}
          onChange={changeName}
          errorText="O nome deve conter pelo menos 3 caracteres"
          hasError={nameError}
        />
        <CustomInput
          label="Sobrenome"
          placeholder="Digite seu sobrenome"
          value={lastName}
          onChange={changeLastName}
          errorText="O sobrenome deve conter pelo menos 3 caracteres"
          hasError={lastNameError}
        />
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
        <CustomInput
          label="Confirmar senha"
          placeholder="Confirme sua senha"
          value={confirmPassword}
          onChange={changeConfirmPassword}
          errorText="Senhas não conferem"
          hasError={confirmPasswordError}
          type="password"
        />
      </div>
      <div>
        <div className="sized-box"></div> 
        <Button 
          variant="contained"
          size="large"
          color="primary"
          onClick={handleRegister}>
          CADASTRAR
        </Button>
        <div className="sized-box-2"></div>
      </div>
      <div>
        <a 
          href="#"
          onClick={props.handleFormRegister}>
          Voltar
        </a>
        <div className="sized-box-2"></div>
      </div>
    </>
  );
}