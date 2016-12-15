$.ready(function ($) {
    $(window).load(function () {
        setTimeout(function () {
            $('.pl').fadeOut('slow', function () { });
        }, 2000);
    });
});