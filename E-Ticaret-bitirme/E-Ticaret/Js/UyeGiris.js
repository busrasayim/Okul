$(document).ready(function () {
        var rid = $("#girisDurum").val();
        if (rid == "1") {
            event.preventDefault();
            $('form').fadeOut(500, function () {
                $('.wrapper').addClass('form-success');
                window.location.assign("http://localhost:59943/AnaSayfa.aspx");
            });
        }
});
