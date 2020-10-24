import React from 'react';
import './App.css';

import Hello from './components/HelloFunctionComponent';
import Welcome from './components/WelcomeClassComponent';

import Stylesheet from './components/Stylesheet';
import Inline from './components/Inline';

function App() {
  return (
    <div className="App">

    <Hello name="Abdullah"/>
    <Welcome name="Abdullah"/>

    <Stylesheet />
    <Inline />

    </div>
  );
}

export default App;
