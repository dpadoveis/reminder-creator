import React from 'react';
import styled from 'styled-components';


const Button = styled.button`
  background-color: #6E6E8C; 
  color: #d1d5db; 
  padding: 0.5rem 1rem;
  border-radius: 15rem;
  cursor: pointer;
  transition: background-color 0.2s, transform 0.1s;

  &:hover {
    background-color: #d1d5db; 
  }

  &:active {
    transform: scale(0.98);
  }
  }
`;


function ButtonComponent({ children, onClick, className }) {
  return (
    <Button onClick={onClick} className={className}>
      {children}
    </Button>
  );
}

export default ButtonComponent;
