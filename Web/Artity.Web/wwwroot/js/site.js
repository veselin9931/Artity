// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.
$('.custom-file-input').on('change', function () {
    var fileName = document.getElementById("exampleInputFile").files[0].name;
    $(this).next('.form-control-file').addClass("selected").html(fileName);
})

    

//const connection = new signalr.HubConnectionBuilder()
 //   .withUrl("/notify")
  //  .build();

//connection.start().catch(err => console.error(err.toString()));
    
jQuery(document).ready(function($) {
    $(".clickable-row").click(function() {
    window.location = $(this).data("href");
    });
    });