$(document).ready(function () {
    loadJoinSubject();
});
function loadJoinSubject() {

    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: "EmployeeInformation.aspx/GetAllSub",
        dataType: 'json',
        data: JSON.stringify({}),
        async: false,
        success: function (response) {
            var item = [];
            for (var i = 0; i < response.d.length; i++) {
                item.push(response.d[i].JoinSubject);
            }
            $("#MainContent_joinSubTextBox").autocomplete({
                source: item
            });
        },
        error: function () {
            //$("#MainContent_messageLabel").html("Error Found");
            //$("#MainContent_messageLabel").addClass('label-danger');
        }
    });
}