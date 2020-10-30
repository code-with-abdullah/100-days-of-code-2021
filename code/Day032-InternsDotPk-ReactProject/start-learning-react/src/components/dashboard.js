import React, { Component } from 'react';
import './dashboard.css'
import WidgetText from './widgetText'

class Dashboard extends Component {
    render() {
        return (
            <div>

                <WidgetText title="Title" value={120} description="Lorem ipsum dolor siet" />

            </div>
        );
    }
}

export default Dashboard;