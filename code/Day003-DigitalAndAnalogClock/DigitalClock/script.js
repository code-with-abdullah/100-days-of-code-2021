/* global variable start */

let hours = 0;
let minutes = 0;
let seconds = 0;

let hoursChanaged = false;
let minutesChanaged = false;

/* global variable end */

/* ----- functions used ----- */

// assigns the time of current machine to global variables
const getCurrentTime = () => {
    let date = new Date();
    hours = date.getHours();
    minutes = date.getMinutes();
    seconds = date.getSeconds();
}

// this function assign the time of 
const updateTime = () => {
    if(seconds === 59) {
        seconds = 0;
        if(minutes === 59) {
            minutes = 0;
            minutesChanaged = true;
            if (hours === 23) {
                hours = 0;
                hoursChanaged = true;
            } else {
                hours += 1;
                hoursChanaged = true;
            }
        } else {
            minutes += 1;
            minutesChanaged = true;
        }
    } else {
        seconds += 1;
    }
}

$(document).ready(function(){
    // when the page is loaded, get the current time of machine
    getCurrentTime();

    // first time update all three (hours, minutes and seconds)
    updateTime();
    $("#seconds").text(seconds.toString().padStart(2, '0'));
    $("#hours").text(hours.toString().padStart(2, '0'));
    $("#minutes").text(minutes.toString().padStart(2, '0'));

    // after each seconds, update the seconds field and 
    // update hours and minutes only when their 
    // value changes - just to improve efficency
    setInterval(()=>{

        updateTime();
        // manipulate #seconds in DOM every-second
        $("#seconds").text(seconds.toString().padStart(2, '0'));

        // manipulate #hours in DOM only when the hours change
        if(hoursChanaged) {
            $("#hours").text(hours.toString().padStart(2, '0'));
            hoursChanaged = false;
        }

        // manipulate #minutes in DOM only when the minutes change
        if(minutesChanaged) {
            $("#minutes").text(minutes.toString().padStart(2, '0'));
            minutesChanaged = false;
        }
    }, 1000);
});