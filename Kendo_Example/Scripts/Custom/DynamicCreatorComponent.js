function CreateControl(data) {

    console.log(data);


    $(document).ready(function () {
        // create DateTimePicker from input HTML element
        $("#TestDate").kendoDateTimePicker({
            value: new Date(),
            dateInput: true
        });
    });

}

// apply datepicker format
function convertDatePickerCell(args, dateformat, cult) {

    args.element.kendoDateTimePicker({
        format: dateformat,
        culture: cult
    });
}


function convertDatePickerUI(element, dateformat, cult) {

    element.kendoDateTimePicker({
        format: dateformat,
        culture: cult
    });

}

function convertAU(element, urlRead, dataFieldText) {
    element.kendoAutoComplete({
        dataSource: {
            type: "aspnetmvc-ajax",
            transport: {
                read: {
                    url: urlRead
                }
            },
            serverFiltering: true,
            schema: { data: "Data", total: "Total" }
        },
        dataTextField: dataFieldText,
        filter: "contains",
        ignoreCase: false,
        minLength: 1,
        placeholder: "Enter the text"
    })
}

function convertNumericTextBox(element, format) {

    element.kendoNumericTextBox({
        format: format,
    })

}

function test(e, id, format) {

    setTimeout(function () { $('#' + id + '').kendoDateTimePicker({ format: format }) }, 50);

}

function visualTemplate(options) {

    //console.log("visualTemplate handle!");
    //console.log(options);

    var dataviz = kendo.dataviz;
    var g = new dataviz.diagram.Group();
    var dataItem = options.dataItem;

    if (dataItem.shape === 'Rectangle') {
        g.append(new dataviz.diagram.Rectangle({
            width: dataItem.size,
            height: dataItem.size,
            stroke: {
                width: 0
            },
            fill: dataItem.color
            //fill: {
            //    gradient: {
            //        type: "linear",
            //        stops: [{
            //            color: dataItem.color,
            //            offset: 0,
            //            opacity: 0.5
            //        }, {
            //            color: dataItem.color,
            //            offset: 1,
            //            opacity: 1
            //        }]
            //    }
            //}
        }));
        //g.append(new dataviz.diagram.Rectangle({
        //    width: 8,
        //    height: dataItem.size,
        //    fill: "orange",
        //    stroke: {
        //        width: 0
        //    }
        //}));
    }
    if (dataItem.shape === 'Circle') {
        g.append(new dataviz.diagram.Circle({
            radius: 60,

            fill: {
                gradient: {
                    type: "linear",
                    stops: [{
                        color: "white",
                        offset: 0,
                        opacity: 1
                    },
                    {
                        color: dataItem.color,
                        offset: 1,
                        opacity: 1
                    }]
                }
            }
        }));
    }

    //g.append(new dataviz.diagram.TextBlock({
    //    text: dataItem.label,
    //    fontSize: 22,
    //    x: 25,
    //    y: 25,
    //    fill: "#0D0D0C",
    //    //height: 20,
    //    //width: 80
    //}));

    //}

    return g;
}

function onDataBound(e) {
    var that = this;
    setTimeout(function () {
        that.bringIntoView(that.shapes);
    }, 0);
}

function reloadGrid(gridId) {
    $("#" + gridId).dataSource.read();
}

function contextMenu_SelectEventHandler(e, addData) {
    var action = e.item.getAttribute('action')
    console.log("Grid id : " + e.sender.target[0].id);
    var gridId = e.sender.target[0].id;
    //var grid = $("#jsTestGrid").data("kendoGrid");
    //var model = grid.dataItem(event.target);
    var fn = $('#' + gridId + ' thead tr th').eq($('td#' + gridId + '_active_cell').index())[0].dataset.field;
    var cv = $('td#' + gridId + '_active_cell')[0].innerText;
    console.log(e);
    console.log('add data : ' + addData);
    console.log("field name : " + fn);
    console.log("cell value: " + cv);
    //execute action
    if (action == "GridLink") {
        e.item.children[0].href = e.item.children[0].href +
            '&field_name=' + fn + '&field_value=' + cv;
    }
    if (action == "ProcessDesignerLink") {
        e.item.children[0].href = e.item.children[0].href +
            '?link=' + cv;
    }
    if (action == "TempLink") { }
}