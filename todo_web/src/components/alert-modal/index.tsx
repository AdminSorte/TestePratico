import React from 'react';

export interface StateProps {
  title: string;
  message: string;
  confirm(): void;
  close(): void;
}

export function AlertModal(props: StateProps) {
  return (
    <>
      <div className="modal fade" id="alertModal" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div className="modal-dialog modal-dialog-centered" role="document">
          <div className="modal-content">
            <div className="modal-header">
              <h5 className="modal-title" id="exampleModalLongTitle">{ props.title }</h5>
              <button type="button" className="close" data-dismiss="modal" aria-label="Close" onClick={props.close}>
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div className="modal-body">
              {
                props.message
              }
            </div>
            <div className="modal-footer">
              <button type="button" className="btn btn-secondary" data-dismiss="modal" onClick={props.close}>Fechar</button>
              <button type="button" className="btn btn-primary" data-dismiss="modal" onClick={props.confirm}>Confirmar</button>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}