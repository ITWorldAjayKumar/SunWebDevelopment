function APIServiceCall(_obj, url, callType) {
    var finalURL = 'http://localhost:59475/Api/' + url;
    $.ajax({
        url: finalURL,
        type: callType,
        cache: false,
        dataType: 'json',
        data: JSON.stringify(_obj),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            return data;
        },
        error: function (xhr, textStatus, errorThrown) {
            return "Error Occured. Please contact system admin";
        }
    });
}