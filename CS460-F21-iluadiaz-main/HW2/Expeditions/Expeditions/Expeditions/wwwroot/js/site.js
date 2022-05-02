// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//$(document).ready(function () {
//    $(".datepicker").datepicker({
//        dateFormat: "yyyy-MM-dd",
//        changemonth: true,
//        changeyear: true
//    });
//});



 $(document).ready(function () {
    $('#datepicker').datepicker({
        dateFormat: "yyyy-MM-dd",
        changemonth: true,
        changeyear: true
    }).datepicker("setDate", "0");
});

//        $(document).ready(function () {
//    $("#datePicker").datepicker({
//    });
//    var myDate = new Date();
//    var month = myDate.getMonth() + 1;
//    var prettyDate = month + '/' + myDate.getDate() + '/' + myDate.getFullYear();
//    $("#datePicker").val(prettyDate);
//});
