
$(document).ready(function () {

    $('#CommentForm').submit(function (event) {

        $.ajax({

            type: 'POST',
            url: $(this).attr('action'),
            data: $(this).serialize(),

        }).done(function (result) {
            
            var resultHtml = $(result).find('#comment-list');
            $('#comment-list').replaceWith(resultHtml);
            $('input[type=text],textarea').val('');

        }).fail(function (xhr, err) {

            alert("readyState: " + xhr.readyState +
            "\nstatus: " + xhr.status);
            alert("responseText: " + xhr.responseText);
        });

        event.preventDefault();
        return false;
    });

    $('#followfriend').click(function () {
        
        var id = $(this).data('assigned-value');

        $.post("/Friends/CreateFriend", id, function (data) {
            $('#followfriend').hide();
            $('#unfriend').show();

        }).fail(function (xhr, err) {

            alert("readyState: " + xhr.readyState +
            "\nstatus: " + xhr.status);
            alert("responseText: " + xhr.responseText);
        });

    });

    $('#unfriend').click(function () {

        $.post("/Friends/RemoveFriend", function (data) {
            $('#followfriend').show();
            $('#unfriend').hide();

        }).fail(function (xhr, err) {

            alert("readyState: " + xhr.readyState +
            "\nstatus: " + xhr.status);
            alert("responseText: " + xhr.responseText);
        });

    });

});
