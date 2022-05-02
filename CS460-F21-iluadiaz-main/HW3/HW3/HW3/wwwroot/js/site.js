// Once the DOM is ready, execute everything in this function to set up the UI
$(function () {
    
        $.ajax({
            type: "GET",
            dataType: "json",
            url: "/GetUser",
            success: displayUser,
            error: errorOnAjax
        });

});

// Callback functions that execute once the AJAX calls return

function errorOnAjax() {
    console.log("ERROR in ajax request");
    // take care of the error, maybe display a message to the user
    // ...
}

/*
Expects:
    { message: "Random Numbers API", count: 10, max: 1000, domain: [Number], range: [Number]}
*/
function displayUser(data) {
    var myImg = data.d;
    $("#img").txt(myImg[0]);
}
});


