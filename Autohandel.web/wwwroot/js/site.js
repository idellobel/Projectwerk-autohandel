//import { Debug } from "util";

// Admin-Area: create voertuig.
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

//welkompagina -fotoreeks
$(document).on('click', '[data-toggle="lightbox"]', function (event) {
    event.preventDefault();
    $(this).ekkoLightbox({ alwaysShowClose: true });
    $['']
});


//voertuigDetail-btn specifieke gegevens
$(document).ready(function () {
    $("#sdetail").on('click', function () {
        $("#ddetail").toggle();
    })
});



