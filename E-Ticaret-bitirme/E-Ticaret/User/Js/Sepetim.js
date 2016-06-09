$(document).ready(function () {
    $(".btn_sil").click(function () {
        var urunID = $(this).attr("id");
        var fiyat = $("#lbl" + urunID).text();
        var sepetID = $("#hfSepetID").val();
        $.ajax({
            type: "POST",
            url: "Sepetim.aspx/SepettenCikar",
            data: '{urunID: "' + urunID + '" ,fiyat:"' + fiyat + '",sepetID:"' + sepetID + '"  }',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function OnSuccess(response) {
                window.location.assign("http://localhost:59943/User/Sepetim.aspx");
            },
            failure: function (response) {
                alert("Bir Sorun Oluştu");
            }
        });

    });
});