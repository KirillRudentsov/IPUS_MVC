function onHTTPError_Alertify(message) {
    var str = message.errorThrown +" status : [" + message.status +"] xhr: [" + message.xhr.status + "]";
    var popup = $("#popupNotification").data("kendoNotification");
    popup.show(str, message.status);
}

function on_Alertify(message, alertType) {
    //alertType can be: info, error, upload, success, warning
    var popup = $("#popupNotification").data("kendoNotification");
    popup.show(message, alertType);
}