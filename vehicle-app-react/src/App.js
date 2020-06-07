import React from 'react';
import './Layouts/App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import Routes from './Pages/Routes';
import { Heading } from './Layouts/Heading';

function App () {
  return(
    <div>
      <Heading />
      <header className="App-header">
      <Routes />
      </header>
    </div>
  );
}

export default App;
