import React, { useEffect, useState } from 'react';
import { CustomInput } from '../../../../components/custom-input';
import { Todo } from '../../../../store/Todo/types';
import { Dispatch } from 'redux';
import { useDispatch } from 'react-redux';
import { TodoDispatcher } from '../../../../store/Todo/actions';

export interface StateProps {
  todo?: Todo;
  handleClose(): void;
}

export function ActionMoal(props: StateProps) {
  const dispatch: Dispatch = useDispatch();
  const todoDispatcher = new TodoDispatcher(dispatch);

  const [title, setTitle] = useState<string>('');
  const [description, setDescription] = useState<string>('');
  const [titleError, setTitleError] = useState<boolean>(false);
  const [descriptionError, setDescriptionError] = useState<boolean>(false);

  const changeTitle = (event: any) => setTitle(event.target.value);
  const changeDescription = (event: any) => setDescription(event.target.value);

  useEffect(() => {
    setTitle(props.todo?.title as string);
    setDescription(props.todo?.description as string);
  }, [props.todo]);

  const handleCloseModal = () => {
    props.handleClose();
    setTitle('');
    setDescription('');
  }

  const validForm = (): boolean => {
    let valid = true;

    if (!title || title.length < 1) {
      setTitleError(true);
      valid = false;
    }
    else setTitleError(false);

    if (!description || description.length < 1) {
      setDescriptionError(true);
      valid = false;
    }
    else setDescriptionError(false);

    return valid;
  }

  const handleCreate = (event: React.FormEvent) => {
    event.preventDefault();

    if (validForm()) {
      todoDispatcher.createRequest({
        title: title,
        description: description
      });

      setTitle('');
      setDescription('');
    }
  }

  const handleUpdate = (event: React.FormEvent) => {
    event.preventDefault();

    if (validForm()) {
      todoDispatcher.updateRequest({
        id: props.todo?.id,
        title: title,
        description: description
      });

      setTitle('');
      setDescription('');
    }
  }

  return (
    <>
      <div className="modal fade" id="actionModal" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div className="modal-dialog modal-dialog-centered modal-lg">
          <div className="modal-content">
            <div className="modal-header">
              <h5 className="modal-title">
                {
                  props.todo ? 'Editar agenda' : 'Adicionar agenda'
                }
              </h5>
              <button type="button" className="close" data-dismiss="modal" onClick={handleCloseModal}>
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div className="modal-body">
              <CustomInput 
                label="Titulo"
                placeholder="Insira o titulo"
                value={title}
                onChange={changeTitle}
                errorText="Insira um titulo"
                hasError={titleError}
              />
              <CustomInput 
                label="Descrição"
                placeholder="Insira a descrição"
                value={description}
                onChange={changeDescription}
                multiline={true}
                rows={4}
                errorText="Insira uma descrição"
                hasError={descriptionError}
              />
            </div>
            <div className="modal-footer">
              <button type="button" className="btn btn-secondary" data-dismiss="modal" onClick={handleCloseModal}>Fechar</button>
              {
                props.todo ?
                  <button type="button" className="btn btn-primary" data-dismiss="modal" onClick={handleUpdate}>Alterar</button> :
                  <button type="button" className="btn btn-primary" data-dismiss="modal" onClick={handleCreate}>Incluir</button>
              }
            </div>
          </div>
        </div>
      </div>
    </>
  );
}