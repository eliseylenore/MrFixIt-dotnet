$(document).ready(function () {
    
    $(".claim").submit(function (event) {
        event.preventDefault();
        console.log("hey!");
        $.ajax({
            url: $(this).data('request-url'),
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                console.log("success!")
            }
        })
    });
});