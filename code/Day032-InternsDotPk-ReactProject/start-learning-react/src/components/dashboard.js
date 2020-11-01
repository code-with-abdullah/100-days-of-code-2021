import React, { Component } from 'react';
import { Col, Row, Container } from 'react-bootstrap';

import './dashboard.css';
import 'react-dropdown/style.css';

import WidgetText from './widgetText';
import WidgetBar from './widgetBar';
import WidgetDoughnut from './widgetDoughnut';

import Dropdown from 'react-dropdown'

import ReactFC from "react-fusioncharts";
import FusionCharts from "fusioncharts";
import Column2D from "fusioncharts/fusioncharts.charts";
import FusionTheme from "fusioncharts/themes/fusioncharts.theme.fusion";
ReactFC.fcRoot(FusionCharts, Column2D, FusionTheme);


// const chartData = [
//     {
//     label: "Venezuela",
//     value: "290"
//     },
//     {
//     label: "Saudi",
//     value: "260"
//     },
//     {
//     label: "Canada",
//     value: "180"
//     } 
//     {
//     label: "Iran",
//     value: "140"
//     },
//     {
//     label: "Russia",
//     value: "115"
//     }
// ];

const config = {
    apiKey: 'AIzaSyDMu-Vw30ykPPmFT3cXeunzKEi4EahzglI',
    spreadsheetId: '1vcDPrMexD8bxNwwzK9IxF8wch6Hfezq2eooJACDiqgg'
}
const url = `https://sheets.googleapis.com/v4/spreadsheets/${config.spreadsheetId}/values:batchGet?ranges=Sheet1&majorDimension=ROWS&key=${config.apiKey}`;

class Dashboard extends Component {

    constructor() {
        super();
        this.state = {
            items: [],
            dropdownOptions : [],
            selectedValue : null,
            orgaicSource: null,
            directSource:null,
            referralSource: null,
            pageViews: null,
            users: null,
            newUsers: null,
            sourceArr: [],
            usersArr: null
        }
    }

    getData = arg => {
        const arr = this.state.items;

        let organicSource = 0;
        let directSource = 0;
        let referralSource = 0;
        let pageViews = 0;
        let users = 0;
        let newUsers = 0;
        let sourceArr = [];
        let usersArr = [];
        let selectedValue = null;

        for (let i=0; i<arr.length; i++) {
            if(arg === arr[i]['month']) {
                organicSource = arr[i].organic_source;
                directSource = arr[i].direct_source;
                referralSource = arr[i].referral_source;
                pageViews = arr[i].page_views;
                users = arr[i].users;
                newUsers = arr[i].new_users;
                sourceArr.push(
                    { 
                        label:"Organic Source",
                        value: arr[i].organic_source
                    },
                    { 
                        label:"Direct Source",
                        value: arr[i].direct_source
                    },
                    { 
                        label:"Referral Source",
                        value: arr[i].referral_source
                    }
                );
                usersArr.push(
                    {
                        label: "Users",
                        value: arr[i].users
                    },
                    {
                        label: "New Users",
                        value: arr[i].new_users
                    }
                );
            }
        }

        selectedValue = arg;

        this.setState({
            organicSource: organicSource,
            directSource: directSource,
            referralSource: referralSource,
            pageViews: pageViews,
            users: users,
            newUsers: newUsers,
            sourceArr: sourceArr,
            usersArr: usersArr
        }, () => {
            console.log(organicSource)
        }
        )
    }

    updateDashboard = event => {
        this.getData(event.value);
        this.setState({selectedValue: event.value}, 
        () => {

        });
    }

    componentDidMount() {
        fetch(url)
            .then(response=>response.json())
            .then(data=>{
                let batchRowValues = data.valueRanges[0].values;
                const rows = [];

                for (let i = 1; i < batchRowValues.length; i++) {
                    let rowObject = {};
                    for (let j = 0; j < batchRowValues[i].length; j++) {
                        rowObject[batchRowValues[0][j]] = batchRowValues[i][j];
                    }
                    rows.push(rowObject);
                }

                let dropdownOptions = [];

                for (let i = 0; i < rows.length; i++) {
                    dropdownOptions.push(rows[i].month);
                }

                dropdownOptions = Array.from(new Set(dropdownOptions)).reverse();
                this.setState(
                    {
                        items: rows,
                        dropdownOptions: dropdownOptions,
                        selectedValue: "Jan 2018"
                    },
                    () => this.getData("Jan 2018")
                );
            });
    }

    render() {

        return (
            <div>

                {/* <WidgetText title="Title" value={120} description="Lorem ipsum dolor siet" />
                <WidgetText title="Title 2" value={150} description="Lorem ipsum dolor siet amet" /> */}

                {/* <WidgetBar title="title" data={chartData} /> */}

                {/* <WidgetDoughnut title="title" data={chartData} /> */}

                <Container>
                    <Row className="TopHeader">
                        <Col>
                            Dashboard
                        </Col>
                        <Col>
                        </Col>
                        <Col>
                            <Dropdown options={this.state.dropdownOptions} onChange={this.updateDashboard} value={this.state.selectedValue} placeholder="Select an option" />
                        </Col>
                    </Row>
                </Container>

                <Container className="mainDashboard">
                    <Row >
                        <Col>
                            <WidgetText title="Organic Source" value={this.state.organicSource} />
                        </Col>
                        <Col>
                            <WidgetText title="Direct Source" value={this.state.directSource} />
                        </Col>
                    </Row>
                    <Row>
                        <Col>
                            <WidgetText title="Referral Source" value={this.state.referralSource} />
                        </Col>
                    </Row>
                    <Row>
                        {/* <Col>
                            <WidgetText title="Users" value={this.state.users} />
                        </Col>
                        <Col>
                            <WidgetText title="New Users" value={this.state.newUsers} />
                        </Col> */}
                        <Col>
                            <WidgetBar title="Source Comparision" data={this.state.sourceArr} />
                        </Col>
                    </Row>
                    <Row>
                        <Col>
                            <WidgetDoughnut title="Users comparision" data={this.state.usersArr} />
                        </Col>
                    </Row>
                </Container>

            </div>
        );
    }
}

export default Dashboard;