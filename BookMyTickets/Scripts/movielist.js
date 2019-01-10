
$(document).ready(function () {
    GetMovies();
});

function GetMovies()
{
    $.ajax({

        type: "GET",

        url: "/api/bookmyticket/GetMovies",

        contentType: "application/json; charset=utf-8",

        dataType: "json",

        success: function (data) {
            data.forEach(function (movie) {
                $("#movies").append("<li id='" + movie.Id + "' class='movie' onclick = 'location.href=`/BookMyTicket/BookingDetails/" + movie.Id + "`'><div  class='movie_poster'><img src = 'Images/" + (movie.Title).replace(/ /g, '') + movie.Language + ".jpg' alt ='" + movie.Title + "'></div><div class='title'>" + movie.Title + "</div><div><span>" + movie.Language + "<span></div></li>");
            });
        },

        failure: function (response) {

            alert(response.responseText);

        },
    });
}