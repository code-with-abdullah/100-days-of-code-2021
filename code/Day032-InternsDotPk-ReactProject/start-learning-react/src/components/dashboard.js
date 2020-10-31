import React, { Component } from 'react';

import './dashboard.css'

import WidgetText from './widgetText'
import WidgetBar from './widgetBar';
import WidgetDoughnut from './widgetDoughnut';

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


class Dashboard extends Component {
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