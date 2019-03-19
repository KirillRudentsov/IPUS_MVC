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

function reload_Grid(e) {

    console.log( e );

    e.sender.one("dataBound", function () {
        e.sender.dataSource.read();
    });

    if (e.type === "create" && e.response === "OK")
        on_Alertify("Новая запись добавлена!", "success");
};