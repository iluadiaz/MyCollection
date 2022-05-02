// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// scripts.js
const openHandler = () =>
    document.querySelector(".sidebar").classList.remove("hidden");
const closeHandler = () => {
    document.querySelector(".sidebar").classList.add("close_sidebar");
    setTimeout(() => {
        document.querySelector(".sidebar").classList.add("hidden");
        document.querySelector(".sidebar").classList.remove("close_sidebar");
    }, 400);
};
document
    .getElementById("open_sidebar_button")
    .addEventListener("click", openHandler);
document.querySelector(".close_button").addEventListener("click", closeHandler);