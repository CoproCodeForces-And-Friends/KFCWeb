// Write your JavaScript code.
$(document).ready(function (){
    $('.row-body-content').on('click', function (e) {
        $(this).next('.hidden-row').toggle();
    });
});