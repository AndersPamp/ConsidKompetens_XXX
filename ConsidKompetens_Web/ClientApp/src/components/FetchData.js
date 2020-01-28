import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'

export class FetchData extends Component {
    static displayName = FetchData.name;

    //constructor(props) {
    //  super(props);
    //  this.state = { forecasts: [], loading: true };
    //}

    constructor(props) {
        super(props);
        this.state = { users: [], loading: true };
    }

    //componentDidMount() {
    //    this.populateWeatherData();
    //}

    componentDidMount() {
        this.populateUserData();
    }

    //static renderForecastsTable(forecasts) {
    //    return (
    //        <table className='table table-striped' aria-labelledby="tabelLabel">
    //            <thead>
    //                <tr>
    //                    <th>Date</th>
    //                    <th>Temp. (C)</th>
    //                    <th>Temp. (F)</th>
    //                    <th>Summary</th>
    //                </tr>
    //            </thead>
    //            <tbody>
    //                {forecasts.map(forecast =>
    //                    <tr key={forecast.date}>
    //                        <td>{forecast.date}</td>
    //                        <td>{forecast.temperatureC}</td>
    //                        <td>{forecast.temperatureF}</td>
    //                        <td>{forecast.summary}</td>
    //                    </tr>
    //                )}
    //            </tbody>
    //        </table>
    //    );
    //}

    static renderUserDataTable(users) {
        return (
            <table className="table table-striped" aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Created</th>
                        <th>Modified</th>
                        <th>About me</th>
                        <th>Profile image id</th>
                    </tr>
                </thead>
                <tbody>
                    {users.map(user =>
                        <tr key={user.id}>
                            <td>{user.id}</td>
                            <td>{user.Created}</td>
                            <td>{user.Modified}</td>
                            <td>{user.AboutMe}</td>
                            <td>{user.ProfileImageId}</td>
                        </tr>
                        )}
                </tbody>
            </table>
            
            );
    }

    //render() {
    //  let contents = this.state.loading
    //    ? <p><em>Loading...</em></p>
    //    : FetchData.renderForecastsTable(this.state.forecasts);

    //  return (
    //    <div>
    //      <h1 id="tabelLabel" >Weather forecast</h1>
    //      <p>This component demonstrates fetching data from the server.</p>
    //      {contents}
    //    </div>
    //  );
    //}

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderUserDataTable(this.state.users);
        return (
            <div>
                <h1 id="tabelLabel">Users</h1>
                {contents}
            </div>
            );
    }

    //async populateWeatherData() {
    //  const token = await authService.getAccessToken();
    //  const response = await fetch('weatherforecast', {
    //    headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
    //  });
    //  const data = await response.json();
    //  this.setState({ forecasts: data, loading: false });
    //  }

    async populateUserData() {
        const token = await authService.getAccessToken();
        const response = await fetch('https://localhost/api/1ded0138-47ce-435e-84ef-9ec1f439b749',
            {
                headers: !token ? {} : { 'Authorization': 'Bearer ${token}' }
            });
        const data = await response.json();
        this.setState({ users: data, loading: false });
    }
}
