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
function convertDatePickerCell(args, dateformat, cult)
{

    args.element.kendoDateTimePicker({
        format: dateformat,
        culture: cult
    });
}


function convertDatePickerUI(element, dateformat, cult)
{

    element.kendoDateTimePicker({
        format: dateformat,
        culture: cult
    });

}

function test(e, id, format) {

    setTimeout(function () { $('#' + id + '').kendoDateTimePicker({ format : format }) }, 50);

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
            fill: {
                gradient: {
                    type: "linear",
                    stops: [{
                        color: dataItem.color,
                        offset: 0,
                        opacity: 0.5
                    }, {
                        color: dataItem.color,
                        offset: 1,
                        opacity: 1
                    }]
                }
            }
        }));
        g.append(new dataviz.diagram.Rectangle({
            width: 8,
            height: dataItem.size,
            fill: "orange",
            stroke: {
                width: 0
            }
        }));
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

    g.append(new dataviz.diagram.TextBlock({
        text: dataItem.label,
        fontSize: 22,
        x: 10,
        y: 10,
        fill: "#0D0D0C",
        //height: 20,
        //width: 80
    }));

    //}

    return g;
}

function onDataBound(e) {
    var that = this;
    setTimeout(function () {
        that.bringIntoView(that.shapes);
    }, 0);
}