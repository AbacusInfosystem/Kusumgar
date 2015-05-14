function OpenPopup(top, left, width, callback) {

    $('#popup_container').css("top", top + "px"); // set top position suggested by caller.

    $('#popup_container').css("left", left + "px"); // set left position suggested by caller.
    
    $('#popup_container').fadeIn(500, function () {

        $(this).animate({
            width: width + 'px', // set size suggested by caller.
        },
        {
            duration: 500, // duration of animation.

            complete: function () // on completion invoke callback.
            {
                callback();

                $('#divLoadingChild').css("display", "none");
            }
        });
    });


    $('#popup_background').fadeIn(1000); // fade in overlay.

}

function HideLoadingDiv()
{
    $('#popup_data').css("display", "block");

    $('#divLoadingChild').fadeOut(2000);
}

function ClosePopup() {

    $('#popup_container').fadeOut(100, function () {

        $(this).css("width", "50%"); // Reset to original with of popup_container div.

        $('#popup_data').text(''); // Remove the usercontrol from popup_data div.

    }); // fade out popup_container.

    $('#popup_background').fadeOut(500); // fade out overlay.
}