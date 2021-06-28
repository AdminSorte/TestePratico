import React from 'react';
import { Todo } from '../../../../store/Todo/types';

export interface StateProps {
  todo?: Todo;
}

export function ViewModal(props: StateProps) {
  const formatDate = (): string => {
    const date = new Date(Date.parse(props.todo?.dateTodo as string));
    return date.toLocaleDateString();
  }

  return (
    <>
      <div className="modal fade" id="viewModal" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div className="modal-dialog modal-dialog-centered modal-lg">
          <div className="modal-content">
            <div className="modal-header">
              <h5 className="modal-title">Visualização da agenda</h5>
              <button type="button" className="close" data-dismiss="modal">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div className="modal-body">
              <h5>Titulo</h5>
              <p>{ props.todo?.title }</p>
              <div className="sized-box"></div>
              <h5>Data</h5>
              <p>{ formatDate() }</p>
              <div className="sized-box"></div>
              <h5>Descrição</h5>
              <p>{ props.todo?.description }</p>
            </div>
            <div className="modal-footer">
              <button type="button" className="btn btn-secondary" data-dismiss="modal">Fechar</button>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}