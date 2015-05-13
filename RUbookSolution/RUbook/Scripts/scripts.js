
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

});
