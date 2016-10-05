
$(document).ready(function () {
    var GeneratedUrl = $('#lblGenerated').text();

    if(GeneratedUrl != '')
    {// only show popup when the url is populated.
        $('#GeneratedUrlPanel').modal('show');
    }
    

});