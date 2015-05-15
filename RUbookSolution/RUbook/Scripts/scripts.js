
$(document).ready(function () {

    // Here we attach an event handler to the onclick event of the #CommentForm.
    // The form can be found in /Post/Details.cshtml
    // In this event handler, we issue an ajax request of type: POST

    $('#CommentForm').submit(function (event) {

        $.ajax({

            type: 'POST',
            url: $(this).attr('action'),    // Instead of hardcoding the path, we just read the path that the form is referring to by-default (the action attribute).
            data: $(this).serialize(),      // The .serialize() operation reads all information from the form and creates a query-string out of it

        }).done(function (result) {         // In this case, result is the whole HTML document
            
            var resultHtml = $(result).find('#comment-list');   // The only part of the HTML that we need is the #comment-list section of the div
            $('#comment-list').replaceWith(resultHtml);         // We then replace the content of the current #comment-list with the new HTML which includes
                                                                // all comments + the comment that we just inserted.
            $('input[type=text],textarea').val('');             // Finally, we empty the textarea, because that's not part of the HTML that we are reloading

        // Standard error handling:
        }).fail(function (xhr, err) {

            alert("readyState: " + xhr.readyState +
            "\nstatus: " + xhr.status);
            alert("responseText: " + xhr.responseText);
        });

        event.preventDefault();             // When this method is called, the default action of the event will not be triggered
        return false;
    });

    // Here we attach an event handler to the onclick event of the #followfriend button.
    // The button can be found in /UserInfoes/Details.cshtml
    // In this event handler, we issue an ajax request. In this case we use the $.post() function instead of $.ajax()

    $('#followfriend').click(function () {
        
        var id = $(this).data('assigned-value');                    // $(this) refers to the HTML element (#followfriend button) that was clicked and
                                                                    // fired the onclick event
        $.post("/Friends/CreateFriend", id, function (data) {
            $('#followfriend').hide();                              // Here we process the response by hiding the #followfriend button when it is clicked
            $('#unfriend').show();                                  // and the #unfriend button appears instead

        // Standard error handling:
        }).fail(function (xhr, err) {

            alert("readyState: " + xhr.readyState +
            "\nstatus: " + xhr.status);
            alert("responseText: " + xhr.responseText);
        });

    });

    // Similar to above, we attach an event handler to the onclick event of the #unfriend button
    // and use $.post() to issue the ajax request.

    $('#unfriend').click(function () {

        $.post("/Friends/RemoveFriend", function (data) {
            $('#followfriend').show();                              // Here we process the response by hiding the #unfriend button when it is clicked
            $('#unfriend').hide();                                  // and the #followfriend button appears instead

        // Standard error handling:
        }).fail(function (xhr, err) {

            alert("readyState: " + xhr.readyState +
            "\nstatus: " + xhr.status);
            alert("responseText: " + xhr.responseText);
        });

    });

});
