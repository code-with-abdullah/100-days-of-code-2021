import React from 'react'

import ReactFC from "react-fusioncharts";
import FusionCharts from "fusioncharts";
import Column2D from "fusioncharts/fusioncharts.charts";
import FusionTheme from "fusioncharts/themes/fusioncharts.theme.fusion";
ReactFC.fcRoot(FusionCharts, Column2D, FusionTheme);

function widgetDoughnut(props) {

    const chartConfigs = {
        type: "doughnut2d", // The chart type
        width: "100%", // Width of the chart
        height: "125", // Height of the chart
        dataFormat: "json", // Data type
        dataSource: {
        // Chart Configuration
        chart: {
            bgColor: "#2a2a2a",
            theme: "fusion"                 //Set the theme for your chart
        },
        // Chart Data - from step 2
        data: props.data
        }
    };
    

    return (
        <div>

            <div className="widgetWrap">
                <div className="widgetTitle">
                    {props.title}
                </div>

                <div className="widgetValue">

                    <ReactFC {...chartConfigs} />

                </div>
            </div>

        </div>
    );
}

export default widgetDoughnut;