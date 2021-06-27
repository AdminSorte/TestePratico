import React from 'react';
import Loader from 'react-loader-spinner';
import './styles.css';

export function LoadingIndicator() {
  return (
    <div className="content-indicator">
      <Loader type="Oval" color="white" height={70} />
    </div>
  );
}