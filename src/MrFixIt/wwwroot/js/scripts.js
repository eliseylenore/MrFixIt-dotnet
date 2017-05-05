$(document).ready(function () {
    
    $(".claim").submit(function (event) {
        event.preventDefault();
        console.log("hey!");
        $.ajax({
            url: $(this).data('request-url'),
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            complete: function (result) {
                $(location).attr("href", "/Workers");
            }
        })
    });
});