$(document).ready(function () {

    GetMovieDetails();

    GetTheaterList();

    $("#datepicker").on("change", function () {
        GetAvailabeShows();
        $("#show-time").prop("disabled", false);  
    });

    $("#theater-name").on("change", function () {
        GetTheaterSeatingLayout();
        $("#datepicker").prop("disabled", false);  
        GetAvailabilityBookingDates();
    });

    $("#show-time").on("change", function () {
        BlockReservedSeats();
        $("#theater-layout").css('display', 'block');
    });

    
    $("#theater-layout").on("click", ".seat", function () {
        if ($(this).prop("checked") == true) {
            $(this).addClass("selected_seat");
        }
        else {
            $(this).removeClass("selected_seat");
        }
        if ($(".selected_seat").length > 0) $("#continue-booking").css('display', 'block');
        else $("#continue-booking").css('display', 'none');
    });

    $(function () {
        $("#booking-dialog").dialog({

            autoOpen: false,
            modal: true,
            show: {
                effect: "blind",
                duration: 1000
            },
            hide: {
                effect: "explode",
                duration: 1000
            }
        });
    });
    
});

function GetMovieDetails() {
    var movieId = $(".movie_name").attr('id');
    $.ajax({
        type: "GET",

        url: `/api/BookMyTicket/GetMovie/${movieId}`,

        contentType: "application/json; charset=utf-8",

        dataType: "json",

        success: function (movie) {
            $('.movie_name').html("<div id='" + movie.Id + "' class='movie' onclick = 'location.href=`/BookMyTicket/BookingDetails/" + movie.Id + "`'><div  class='movie_poster'><img src = '/Images/" + (movie.Title).replace(/ /g, '') + movie.Language + ".jpg' alt ='" + movie.Title + "'></div><div class='title'>" + movie.Title + "</div><div id='language-duration'><span>" + movie.Language + "</span><span>" + Math.floor(movie.Duration_Minutes / 60) + "hrs " + (movie.Duration_Minutes % 60)+"mins</span></div></div>");
        },

        failure: function (response) {
            alert(response.responseText);
        },
        
    });
}

function GetTheaterList() {
    var movieId = $(".movie_name").attr('id');
    $.ajax({
        type: "GET",

        url: `/api/BookMyTicket/GetTheaters/${movieId}`,

        contentType: "application/json; charset=utf-8",

        dataType: "json",

        success: function (theaters) {
            theaters.forEach(function (theater) {

                $("#theater-name").append("<option value='" + theater.ID + "'>" + theater.Name + "</option>");
            });
        },

        failure: function (response) {
            alert(response.responseText);
        },
    });
}

function GetAvailabilityBookingDates(){
    var theaterId = $("#theater-name").val();
    $("#show-time").val("");
    $("#datepicker").val("");
    $("#datepicker").datepicker("destroy");
    $.ajax({
        type: "GET",

        url: `/api/BookMyTicket/GetDates/${theaterId}`,

        contentType: "application/json; charset=utf-8",

        dataType: "json",

        success: function (theaterShowDetails) {
            $("#datepicker").datepicker({ minDate: new Date(theaterShowDetails.start_date), maxDate: new Date(theaterShowDetails.end_date) });
        },

        failure: function (response) {
            alert(response.responseText);
        },
    });
}

function GetAvailabeShows() {
    var theaterMovieValue = $("#theater-name").val();
    $("#show-time").empty();
    $("#show-time").append("<option value='null'>---Select Show Time---</option>");
    $.ajax({
        type: "GET",

        url: `/api/BookMyTicket/GetShows/${theaterMovieValue}`,

        contentType: "application/json; charset=utf-8",

        dataType: "json",

        success: function (shows) {
           
            shows.forEach(function (show) {
                var time = new Date(show.show_time);
                var hours = time.getHours();
                var minutes = time.getMinutes();
                if (minutes == 0) minutes += "0";
                $("#show-time").append("<option id='" + show.ID + "' value = " + hours + ":" + minutes +">" + hours + ":" + minutes + "</option>");
            });
        },

        failure: function (response) {
            alert(response.responseText);
        },
    });
}

function GetTheaterSeatingLayout() {
    var theaterMovieValue = $("#theater-name").val();
    $("#theater-layout").css('display', 'none');
    $("#theater-layout").empty();
    var SeatCost;
    $.ajax({
        type: "GET",

        url: `/api/BookMyTicket/GetTheaterLayout/${theaterMovieValue}`,

        contentType: "application/json; charset=utf-8",

        dataType: "json",

        success: function (theaterLayout) {
            SeatCost = theaterLayout.price;
            for (var row = 0; row < theaterLayout.total_rows; row++) {
                rowId = convertNumberToAlphabet(row);
                $("#theater-layout").append("<div id=" + rowId + "> </div>");
                for (var seat = 1; seat <= theaterLayout.seats_in_row; seat++) {

                    if (row == 0 && seat == 1) {
                        $("#" + rowId).append("<span><input type='checkbox' style='visibility: hidden'></span>")
                        $("#" + rowId).append("<span><input type='checkbox' style='visibility: hidden'></span>")
                    }
                    $("#" + rowId).append("<span><input type='checkbox' class='seat'  id='" + rowId + seat + "'></span>")
                    if (row != 0) {
                        if (seat == 5 || seat == 15) {
                            $("#" + rowId).append("<span><input type='checkbox' style='visibility: hidden'></span>")
                            $("#" + rowId).append("<span><input type='checkbox' style='visibility: hidden'></span>")
                        }
                    }
                }
            }
            $("#reserve").empty();
            $("#reserve").append("<input type='button' id='continue-booking' onClick='ContinueBooking(" + SeatCost + ")' value='Book Tickets' />");
            $('#continue-booking').css('display', 'none');
        },

        failure: function (response) {
            alert(response.responseText);
        },
       
    });
    
}

function convertNumberToAlphabet(n) {
    var ordA = 'A'.charCodeAt(0);
    var ordZ = 'z'.charCodeAt(0);
    var len = ordZ - ordA + 1;
    var s = "";
    while (n >= 0) {
        s = String.fromCharCode(n % len + ordA) + s;
        n = Math.floor(n / len) - 1;
    }
    return s;
}


function ContinueBooking(SeatCost) {
    var theaterMovieValue = $("#theater-name").val();
    var TotalAmount = ($(".selected_seat").length * SeatCost);
    var selectedSeats = [];
    $(".selected_seat").each(function () {
        selectedSeats.push($(this).attr('id'));
    });
    var ticketInfo = {
        theater_movie_id: $("#theater-name").val(),
        date_of_booking: $("#datepicker").val(),
        show_id: $('#show-time option:selected').attr('id'),
        seat_cost: SeatCost,
        seats_count: $(".selected_seat").length,
        total_amount: TotalAmount,
        seats: selectedSeats,
    }
    $.ajax({

        type: "GET",

        url: `/api/BookMyTicket/GetTheaterAndMovie/${theaterMovieValue}`,

        contentType: "application/json; charset=utf-8",

        dataType: "json",

        success: function (theaterMovie) {
            $("#booking-dialog").empty();
            $("#booking-dialog").append("<h2>" + theaterMovie.Title + "</h2><h3> (" + theaterMovie.Name + ")</h3><p>Show Date: " + ticketInfo.date_of_booking + "</p><p>Show Time: " + $('#show-time').val() + "</p><p>Seats Selected: " + $.each(selectedSeats, function (seat) { seat.value; }) + "</p><p>Total Amount: " + ticketInfo.seat_cost + "*" + ticketInfo.seats_count + " = " + ticketInfo.total_amount + "</p><input type='button' id='book-ticket' value='Confirm Booking' />")
        },

        failure: function (response) {
            alert(response.responseText);
        },
    });
    $("#booking-dialog").dialog("open");

    $("#booking-dialog").on("click", "#book-ticket", function () {
        BookTicket(ticketInfo, selectedSeats);
    });
}

function BookTicket(ticketInfo, selectedSeats) {
    $.ajax({

        type: "POST",

        url: `/api/BookMyTicket/BookTicket`,

        dataType: "json",

        data: ticketInfo,

        success: function (ticket) {
            if (ticket.Id != 0) {
                location.href = '/BookMyTicket/BookingSuccessful/';
            }
            else {
                location.href = '/BookMyTicket/BookingFailed/';
            }
        },

        failure: function (response) {
            alert(response.responseText);
        },
    });
}


function BlockReservedSeats() {
    var showDetails={
        theater_movie_id : $("#theater-name").val(),
        date_of_booking: $("#datepicker").val(),
        show_id: $('#show-time option:selected').attr('id'),
    }

    $.ajax({

        type: "GET",

        url: `/api/BookMyTicket/GetReservedSeats/`,

        dataType: 'json',

        data: showDetails,

        contentType: "application/json",

        success: function (seats) {
            seats.forEach(function (seat) {
                $("#" + seat).prop('checked', true);
                $("#" + seat).attr('disabled', true);
            });
        },

        failure: function (response) {
            alert(response.responseText);
        },
    });
}