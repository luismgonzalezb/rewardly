$(document).ready(function () {
    // When ready...
    window.addEventListener("load", function () {
        // Set a timeout...
        setTimeout(function () {
            // Hide the address bar!
            window.scrollTo(0, 1);
        }, 0);
    });

    //Clear form fields on focus
    $('input').focus(function () {
        if ($(this).attr('id') == 'Password' || $(this).attr('id') == 'ConfirmPassword') {
            $(this).val('').get(0).type = 'password';
        } else {
            $(this).val('');
        }
    });

    //Slide Menu
    $('#btnMenu').toggle(function () {
        $('#wrapper').animate({
            //opacity: .95,
            left: '240px'
        }, 500);
    },
    function () {
        $('#wrapper').animate({
            //opacity: 1,
            left: '0px'
        }, 500);
    });
});