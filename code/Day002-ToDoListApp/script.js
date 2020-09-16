$(document).ready(function(){
    
    // when clicked on button to add new to-do
    $("#new-to-do-button").click(function(){

        let heading = $('#new-to-do-heading-input').val();
        let description = $('#new-to-do-description-input').val();

        if (heading === "") {
            alert("Please add a heading!");
        }
        else if(description === "") {
            alert("Please add a description!");
        }
        else{
            let templateOfToDoBox = '<div class="to-do-box"> <div class="to-do-content"> <p class="to-do-heading">'+ heading +'</p> <p class="to-do-details">' + description + '</p> </div><div class="to-do-button-on-right"><span></span></div></div>';
            $("#usage-key").css('visibility', 'visible');
            $("#list").prepend(templateOfToDoBox).hide().fadeIn(250);
            $('#new-to-do-heading-input').val('');
            $('#new-to-do-description-input').val('');
        }
    });

    $("#list").delegate('div', 'dblclick', function() {
        $(this).fadeOut(500);
    });

    $("#list").delegate('div', 'click', function() {
        $(this).toggleClass('disabled-to-do-box');
    });
});