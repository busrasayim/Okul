$(document).ready(function () {

    $("#pnl_yorumEkle").hide();

    $('#jsCarousel').jsCarousel({
        onthumbnailclick: function (src) {
            $('#resimGoster').empty();
            var resimID = src.substring(22, src.length);
            var img = document.getElementById(resimID);
            $('#resimGoster').css({
                "background-image": "url(" + img.src + ")",
                "background-size": "100% 400px",
                "background-repeat": "no-repeat"
            });
        }, autoscroll: false
    });

    $("#btn_yorumYap").click(function () {
        $("#pnl_yorumEkle").fadeIn();
    });
});
