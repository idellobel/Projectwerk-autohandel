//import { Debug } from "util";

// Write your JavaScript code.
$('#Merk').change(function () {

    var selectedMerk = $("#Merk").val();
    var modellenSelect = $('#Model');
    modellenSelect.empty();
    if (selectedMerk !== null && selectedMerk !== '') {
        $.getJSON("/Admin/Voertuigen/GetModellen", { merkId: selectedMerk }, function (modellen) {
            if (modellen !== null && !jQuery.isEmptyObject(modellen)) {
                modellenSelect.append($('<option/>', {
                    value: null,
                    text: "--- Selecteer nu een model! ---"
                }));
                $.each(modellen, function (index, model) {
                    modellenSelect.append($('<option/>', {
                        value: model.value,
                        text: model.text
                    }));
                });
            }
        });
    }
});


$(document).on('click', '[data-toggle="lightbox"]', function (event) {
    event.preventDefault();
    $(this).ekkoLightbox({ alwaysShowClose: true });
    $['']
});



