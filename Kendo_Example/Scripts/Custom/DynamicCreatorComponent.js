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