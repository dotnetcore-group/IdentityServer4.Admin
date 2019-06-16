// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    $('.ui.dropdown')
        .dropdown();

    var button = document.querySelector("#cookieConsent button[data-cookie-string]");
    console.log(typeof button.dataset.cookieString);
    $(button).on('click', function () {
        document.cookie = button.dataset.cookieString;
        $(this).closest('#cookieConsent').transition('fade');
    });
    $('#close-policy').on('click', function () {
        $(this).closest('#cookieConsent').transition('fade');
    });
});