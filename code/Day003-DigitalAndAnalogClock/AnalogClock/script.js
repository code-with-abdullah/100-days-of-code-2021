/* global variables start */
let temp = 0;

let hours = 0;
let minutes = 0;
let seconds = 0;

let rotatedHours = 0;
let rotatedSeconds = 0;
let rotatedMinutes = 0;

let hoursChanaged = false;
let minutesChanaged = false;

/* global variables end */


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
    rotatedHours = (hours * 30).toString();
    rotatedMinutes = (minutes * 6).toString();
    rotatedSeconds = (seconds * 6).toString();
    $("#second-hand").css('transform', 'rotate(' + rotatedSeconds + 'deg)');
    $("#minute-hand").css('transform', 'rotate(' + rotatedMinutes + 'deg)');
    $("#hour-hand").css('transform', 'rotate(' + rotatedHours + 'deg)');

    // after each seconds, update the seconds field and 
    // update hours and minutes only when their 
    // value changes - just to improve efficency
    temp = seconds;
    setInterval(()=>{
        updateTime();
        // manipulate #seconds in DOM every-second
        rotatedSeconds = (seconds * 6).toString();
        $("#second-hand").css('transform', 'rotate(' + temp*6 + 'deg)');
        // manipulate #minutes in DOM only when the minutes change
        if(minutesChanaged) {
            rotatedMinutes = (minutes * 6).toString();
            $("#hour-hand").css('transform', 'rotate(' + rotatedHours + 'deg)');
            minutesChanaged = false;
        }
        // manipulate #hours in DOM only when the hours change
        if(hoursChanaged) {
            rotatedHours = (hours * 15).toString();
            $("#minute-hand").css('transform', 'rotate(' + rotatedMinutes + 'deg)');
            hoursChanaged = false;
        }
        temp++;
    }, 1000);
});