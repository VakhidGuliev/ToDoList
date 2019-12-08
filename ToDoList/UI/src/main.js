import FormController from "./controllers/form-controller";


const form = document.querySelector('form');
const formController = new FormController(form);

formController.validate();
formController.submit();

$('input[name="birthday"]').daterangepicker({
    "singleDatePicker": true,
    "showDropdowns": true,
    "minYear": 1900,
    "maxYear": 2019,
    "startDate": "01/01/1900",
    "minDate": "01/01/1990",
    "maxDate": "12/07/2019",
}, function (start, end, label) {
    console.log('New date range selected: ' + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD') + ' (predefined range: ' + label + ')');
});