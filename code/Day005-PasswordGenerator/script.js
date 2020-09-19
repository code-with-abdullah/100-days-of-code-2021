let digitChecked = false;
let upperChecked = false;
let lowerChecked = false;
let symbolChecked = false;
let lengthOfPassword = 0;

let randomLocation = 0;

let iter = 0;

const isArrayCompletlyFilled = (array) => {
    let result = !(array.includes(undefined));
    return result;
}

// function taken from https://www.w3schools.com/js/js_random.asp
const getRandomNumberUsingRange = (min, max) => {
    return Math.floor(Math.random() * (max - min + 1) ) + min;
} 


const getRandomEmptyLocation = (array) => {
    let randomNumber;
    do {
        randomNumber = getRandomNumberUsingRange(0, lengthOfPassword-1);
    } while(array[randomNumber] !== undefined);

    return randomNumber;
}

const generatePassword = () => {
    let arrayOfPassword = new Array(parseInt(lengthOfPassword));

    let iterationNumber = 0;

    while(!isArrayCompletlyFilled(arrayOfPassword)) {
        if(digitChecked) {
            randomLocation = getRandomEmptyLocation(arrayOfPassword);
            let randomDigit = Math.floor(Math.random() * 10);
            arrayOfPassword[randomLocation] = randomDigit.toString();
        }

        if(isArrayCompletlyFilled(arrayOfPassword)) {
            break;
        }

        if (upperChecked) {
            randomLocation = getRandomEmptyLocation(arrayOfPassword);
            let randomUpperCase = getRandomNumberUsingRange(65, 90);
            arrayOfPassword[randomLocation] = String.fromCharCode(randomUpperCase);
        }

        if(isArrayCompletlyFilled(arrayOfPassword)) {
            break;
        }

        if (lowerChecked) {
            randomLocation = getRandomEmptyLocation(arrayOfPassword);
            let randomUpperCase = getRandomNumberUsingRange(97, 122);
            arrayOfPassword[randomLocation] = String.fromCharCode(randomUpperCase);
        }

        if(isArrayCompletlyFilled(arrayOfPassword)) {
            break;
        }

        if (symbolChecked) {
            randomLocation = getRandomEmptyLocation(arrayOfPassword);
            let randomSymbol;

            if(iterationNumber === 0){
                randomSymbol = getRandomNumberUsingRange(32, 47);
            }else if (iterationNumber === 1){
                randomSymbol = getRandomNumberUsingRange(91, 96);
            }else if (iterationNumber === 2){
                randomSymbol = getRandomNumberUsingRange(91, 96);
            }else {
                randomSymbol = getRandomNumberUsingRange(123, 126);
                iterationNumber = -1; // increament statement will make it zero again
            }

            iterationNumber++;
            arrayOfPassword[randomLocation] = String.fromCharCode(randomSymbol);
        }

    }
    return arrayOfPassword;
}

$(document).ready(function(){
    $('button').click(function(){
        digitChecked = $('#password-digit').prop('checked');
        lowerChecked = $('#password-lowercase').prop('checked');
        upperChecked = $('#password-uppercase').prop('checked');
        symbolChecked = $('#password-symbol').prop('checked');
        lengthOfPassword = $('#password-length').val();

        let generatedPassword = generatePassword().toString().replaceAll(",", "");

        $('#password-generated').val(generatedPassword);

        // $('#notice').css('visibility', 'visible');
    });
});