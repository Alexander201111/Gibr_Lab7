import React, { Component } from 'react';
import { Main } from './components/Main';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
      return (<Main />);
  }
}
