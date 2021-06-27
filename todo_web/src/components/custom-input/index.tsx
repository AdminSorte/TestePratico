import { TextField } from '@material-ui/core';
import './style.css';

export interface StateProps {
  label: string;
  placeholder: string;
  value: string | number;
  onChange(event: any): void;
  hasError?: boolean;
  errorText?: string;
  type?: string
}

export function CustomInput(props: StateProps) {
  return (
    <>
      <TextField
          id="outlined-helperText"
          label={props.label}
          placeholder={props.placeholder}
          variant="outlined"
          fullWidth
          value={props.value}
          onChange={props.onChange}
          error={props.hasError}
          type={props.type ? props.type : 'text'}
        />
        {
          props.hasError ? 
            <div className="error-input">
              <span>{props.errorText}</span>
            </div>
            :
            <></>
        }
        <div className="mb-1"></div>
    </>
  )
}