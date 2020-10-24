import React from 'react'

const heading = {
    color: 'red'
};

const Inline = () => {
    return (
        <div>
            <h1 style={heading}>Heading</h1>
            <p style={{color:'pink'}}>CSS Inline</p>
        </div>
    );
}

export default Inline;