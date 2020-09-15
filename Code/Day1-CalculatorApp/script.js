$(document).ready(function(){

    // event handler fired when some button inside calculator is clicked
    $(".button-row>div").click(function() {

        // clear both boxes above
        if($(this).text() === "C") {    
            $("#result-bar").text("");
            $("#equation-bar").text("");
        }

        // no functionality implemented for this operator
        else if($(this).text() === "+/-") {  
            // no code
        }

        // when symbol/number button pressed
        // append their text to equation
        else if($(this).hasClass("numeric-button")) {
            $("#equation-bar").text($("#equation-bar").text() + $(this).text());
        }
        else if($(this).hasClass("symbol-button")) {    
            $("#equation-bar").text($("#equation-bar").text() + " "+ $(this).text() + " ");
        }

        // means it is the equal button
        else { 
            // remove white-spaces from string before passsing it to the eval function
            let text = $("#equation-bar").text().replace(/\s/g, '');
            let computedValue = eval(text);
            $("#result-bar").text(computedValue);
            $("#equation-bar").text(computedValue);
        }
    });

});