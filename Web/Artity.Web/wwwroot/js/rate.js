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
      
         let a = document.getElementsByClassName("container text-center text-uppercase");

        debugger;
        if (a.length != 1) {
            sendInfo(ratingValue);
        }
        else {
            sendInfoToPerformence(ratingValue)
        }
       
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
                ratingElement.innerHTML =''
                let innerI = document.createElement("I");
                innerI.className = "fas fa-star-half-alt";

                ratingElement.appendChild(innerI);
                ratingElement.textContent = `Rating: ${calculatedRating}`;
               
            }
        })
}

function sendInfoToPerformence(ratingValue) {
    let performenceName = document.getElementById("performence-name").textContent;
    let url = `/Rate/${ratingValue}/Performence/${performenceName}`;
    let calculatedRating = 0;
    fetch(url)
        .then((response) => response.json())
        .then((data) => {
            calculatedRating = data.rating;
            if (calculatedRating) {
                let ratingElement = document.querySelector("#rating");
                ratingElement.innerHTML = ''
                let innerI = document.createElement("I");
                innerI.className = "fas fa-star-half-alt";

                ratingElement.appendChild(innerI);
                ratingElement.textContent = `Rating: ${calculatedRating}`;

            }
        })
}

function responseMessage(msg) {
    $('.success-box').fadeIn(200);
    $('.success-box div.text-message').html("<span>" + msg + "</span>");
}


$(function  () {

    let artistName = document.getElementById("rating").getAttribute("name");
    let url = `/GetRate/Artist/${artistName}`;
let calculatedRating = 0;
    fetch(url)
        .then((response) => response.text())
    .then((data) => {
        calculatedRating = data
        if (calculatedRating) {
            let ratingElement = document.querySelector("#rating");
            ratingElement.innerHTML = ''
            let innerI = document.createElement("I");
            innerI.className = "fas fa-star-half-alt";

            ratingElement.appendChild(innerI);
            ratingElement.textContent = ` Rating: ${calculatedRating}`;

        }
    });
   

});

$(function () {

    let artistName = document.getElementById("rating").getAttribute("name");
    let url = `/GetRate/Performence/${artistName}`;
    let calculatedRating = 0;
    fetch(url)
        .then((response) => response.text())
        .then((data) => {
            calculatedRating = data
            if (calculatedRating) {
                let ratingElement = document.querySelector("#rating");
                ratingElement.innerHTML = ''
                let innerI = document.createElement("I");
                innerI.className = "fas fa-star-half-alt";

                ratingElement.appendChild(innerI);
                ratingElement.textContent = ` Rating: ${calculatedRating} %`;

            }
        });

});

function httpGet(theUrl) {
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.open("GET", theUrl, false); // false for synchronous request
    xmlHttp.send(theUrl);
  
    return xmlHttp.responseText;
}

$(function () {
    let artistName = document.getElementsByClassName("card card-cascade mx-auto mr-5 mb-5 mb-lg-4");

    if (artistName.length != 0) {
        for (let cart in artistName) {
            let artistcart = artistName[cart]

            let url = `https://localhost:44319/GetRate/Artist/${artistcart.id}`;
          
            fetch(url)
                .then((response) => response.text())
                .then((data) => {
                    calculatedRating = data
                    let aaaa = (artistcart.childNodes[9].childNodes[1].childNodes[3]);
                    aaaa.textContent = ` ${data}`


                })



        }
    }
    
    $(function () {
        let artistName = document.getElementsByClassName("col-xs-12 col-sm-6 col-md-4");

        if (artistName.length != 0) {
            for (let cart in artistName) {
                let artistcart = artistName[cart]

                let url = `https://localhost:44319/GetRate/Performence/${artistcart.id}`;
       
                fetch(url)
                    .then((response) => response.text())
                    .then((data) => {
                        calculatedRating = data
                        let aaaa = (artistcart.childNodes[1].childNodes[1].childNodes[1].childNodes[3].childNodes[1].childNodes[1]);
                      
                        aaaa.textContent = ` ${data} %`
                  


                    })



            }
        }


    });

});
