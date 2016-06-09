$(document).ready(function () {
    $(".cbl_deger").click(function () {
       var checkedValues = $('input:checkbox:checked').map(function () {
            return this.value;
        }).get();
       $("#hiddenDeger").val(checkedValues);
    });

});