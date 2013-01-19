$(document).ready(function () {
    //Clear form fields on focus
    $('input').focus(function () {
        if ($(this).attr('id') == 'Password') {
            $(this).val('').get(0).type = 'password';
        } else {
            $(this).val('');
        }
    });


});