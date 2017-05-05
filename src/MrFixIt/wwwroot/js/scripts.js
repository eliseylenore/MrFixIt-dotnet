$(document).ready(function () {
    
    $(".claim").submit(function (event) {
        event.preventDefault();
        console.log("hey!");
        var job = {
            Id: $("#JobId").val(),
            Title: $("#Title").val(),
            Description: $("#Description").val()
        }
        $.ajax({
            url: $(this).data('request-url'),
            type: 'POST',
            dataType: 'json',
            data: JSON.stringify(job),
            contentType: "application/json",
            success: function (result) {
                console.log("success!")
            }
        })
    });
});