import React, { Component } from 'react';

import './dashboard.css'

import WidgetText from './widgetText'
import WidgetBar from './widgetBar';
import WidgetDoughnut from './widgetDoughnut';

import Dropdown from 'react-dropdown'

import ReactFC from "react-fusioncharts";
import FusionCharts from "fusioncharts";
import Column2D from "fusioncharts/fusioncharts.charts";
import FusionTheme from "fusioncharts/themes/fusioncharts.theme.fusion";
ReactFC.fcRoot(FusionCharts, Column2D, FusionTheme);


const chartData = [
    {
    label: "Venezuela",
    value: "290"
    },
    {
    label: "Saudi",
    value: "260"
    },
    {
    label: "Canada",
    value: "180"
    } 
    // {
    // label: "Iran",
    // value: "140"
    // },
    // {
    // label: "Russia",
    // value: "115"
    // }
];

const config = {
    apiKey: 'AIzaSyDMu-Vw30ykPPmFT3cXeunzKEi4EahzglI',
    spreadsheetId: '1vcDPrMexD8bxNwwzK9IxF8wch6Hfezq2eooJACDiqgg'
}
const url = `https://sheets.googleapis.com/v4/spreadsheets/${config.spreadsheetId
    }/values:batchGet?ranges=Sheet1&majorDimension=ROWS&key=${config.apiKey}`;



class Dashboard extends Component {

    constructor() {
        super();
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
            })
    }


    render() {
        return (
            <div>

                {/* <WidgetText title="Title" value={120} description="Lorem ipsum dolor siet" />
                <WidgetText title="Title 2" value={150} description="Lorem ipsum dolor siet amet" /> */}

                {/* <WidgetBar title="title" data={chartData} /> */}

                <WidgetDoughnut title="title" data={chartData} />

            </div>
        );
    }
}

export default Dashboard;