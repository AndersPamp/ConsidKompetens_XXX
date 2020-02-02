import React, { Component } from 'react';
import { Route, Switch } from 'react-router';
//import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import {NavMenu} from '../src/components/NavMenu';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';
import DetailsPage from '../src/components/DetailsPage';
import PersonalPage from '../src/components/PersonalPage';

import '../src/css/custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <div>
        <NavMenu/>
          <Switch>
            <Route exact path='/' component={Home} />
            <Route path='/personalPage' component={PersonalPage}/>
            <Route path='/detailsPage' component={DetailsPage}/>
            <AuthorizeRoute path='/fetch-data' component={FetchData} />
            <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
          </Switch>
      </div>
    );
  }
}
