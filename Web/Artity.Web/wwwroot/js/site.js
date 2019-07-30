// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('.custom-file-input').on('change', function () {
    var fileName = document.getElementById("exampleInputFile").files[0].name;
    $(this).next('.form-control-file').addClass("selected").html(fileName);
})

$(document).ready(function () {

    /* 1. Visualizing things on Hover - See next part for action on click */
    $('#stars li').on('mouseover', function () {
        let onStar = parseInt($(this).data('value'), 10); // The star currently mouse on

        // Now highlight all the stars that's not after the current hovered star
        $(this).parent().children('li.star').each(function (e) {
            if (e < onStar) {
                $(this).addClass('hover');
            }
            else {
                $(this).removeClass('hover');
            }
        });

    }).on('mouseout', function () {
        $(this).parent().children('li.star').each(function (e) {
            $(this).removeClass('hover');
        });
    });


    /* 2. Action to perform on click */
    $('#stars li').on('click', function () {
        let onStar = parseInt($(this).data('value'), 10); // The star currently selected
        let stars = $(this).parent().children('li.star');

        for (i = 0; i < stars.length; i++) {
            $(stars[i]).removeClass('selected');
        }

        for (i = 0; i < onStar; i++) {
            $(stars[i]).addClass('selected');
        }

        // JUST RESPONSE (Not needed)
        let ratingValue = parseInt($('#stars li.selected').last().data('value'), 10);
        var msg = "Thanks! You rated this " + ratingValue + " stars.";
        responseMessage(msg);
        sendInfo(ratingValue);
    });

});

function sendInfo(ratingValue) {
    let artistName = document.getElementById("artist-name").textContent;
    let url = `/Rate/${ratingValue}/Artist/${artistName}`;
    let calculatedRating = 0;
    fetch(url)
        .then((response) => response.json())
        .then((data) => {
            calculatedRating = data.rating;
            if (calculatedRating) {
                let ratingElement = document.querySelector("#rating");
                let innerI = document.createElement("i");
                innerI.className = "fas fa-star-half-alt";
                ratingElement.appendChild(innerI);
                ratingElement.textContent = `Rating:  ${calculatedRating}`
            }
        })
}

function responseMessage(msg) {
    $('.success-box').fadeIn(200);
    $('.success-box div.text-message').html("<span>" + msg + "</span>");
}

