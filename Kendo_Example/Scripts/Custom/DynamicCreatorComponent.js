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


function convertEditeDatePicker(args, dateformat, cult) {

    args.element.kendoDateTimePicker({
        format: dateformat,
        culture: cult
    });
}