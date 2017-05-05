$(document).ready(function () {
    
    $(".claim").submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: $(this).data('request-url'),
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            complete: function (result) {
                $(location).attr("href", "/Workers");
            }
        });
    });
    $(".mark-active").click(function () {     
        $.ajax({
            url: $(this).data('request-url'),
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            complete: function (result) {
                console.log("success?")
                $(location).attr("href", "/Workers");
            }
        });
    });
    $(".mark-complete").click(function () {
        console.log("hey!");
        $.ajax({
            url: $(this).data('request-url'),
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            complete: function (result) {
                $(location).attr("href", "/Workers");
            }
        });
    });
 });