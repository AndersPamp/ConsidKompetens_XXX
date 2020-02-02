import React, { Component } from 'react';
import HomeImage from '../static/HomeImage.png';
import {Layout} from './Layout';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
          <div className="homeContainer">
            <input className="HomeInput form-control" type="text" placeholder="Search"/>
            <img className="homeImg" src={HomeImage} alt="ConsidCoffee"/>
          </div>
          <Layout>
            <button>Hello</button>
          </Layout>
      </div>
    );
  }
}
