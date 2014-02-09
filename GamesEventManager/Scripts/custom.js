$(document).ready(function () {
    $("#zipSearchForm").submit(function () {
        if (!$("#zipSearchForm").valid()) return false;
        $.blockUI({
            message: "Finding events...",
            css: {
                border: 'none',
                padding: '15px',
                backgroundColor: '#000',
                '-webkit-border-radius': '10px',
                '-moz-border-radius': '10px',
                opacity: .5,
                color: '#fff'
            }
        });
    });
    $("#EventDateTime").datetimepicker({
        pick12HourFormat: true
    });
    $("#editEventForm").submit(function () {
        if (!$("#editEventForm").valid()) return false;
        $.blockUI({
            message: "Saving event...",
            css: {
                border: 'none',
                padding: '15px',
                backgroundColor: '#000',
                '-webkit-border-radius': '10px',
                '-moz-border-radius': '10px',
                opacity: .5,
                color: '#fff'
            }
        });
    });
    $("#createEventForm").submit(function () {
        if (!$("#createEventForm").valid()) return false;
        $.blockUI({
            message: "Saving event...",
            css: {
                border: 'none',
                padding: '15px',
                backgroundColor: '#000',
                '-webkit-border-radius': '10px',
                '-moz-border-radius': '10px',
                opacity: .5,
                color: '#fff'
            }
        });
    });
});