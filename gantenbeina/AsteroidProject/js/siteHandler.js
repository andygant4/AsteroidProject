$(document).ready(function () {
    $('[data-toggle="popover"]').popover();
});

$(".navbar-brand").click(function () {
    $.ajaxSetup({ async: false });
    $.ajax({
        type: "POST",
        url: "./Default.aspx/getWSData",
        dataType: "json",
        success: function (response) {
            alert(response);
        },
        failure: function (response) {
            alert(response.d);
        }
    });
})

$('#google-avatar').popover({
    html: true,
    content: function () {
        return $("#popover-content").html();
    }
});
