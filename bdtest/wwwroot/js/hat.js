$(document).ready(function () {
    $("#hat,#miniHat").css({
        "grid-template-columns": ($(window).width() - $('#eat,#main,#main-finish').width()) / 2 + "px " + $('#eat,#main,#main-finish').width() / 3 + "px " +
            +$('#eat,#main,#main-finish').width() / 3 + "px " + $('#eat,#main,#main-finish').width() / 3 + "px auto"
    });
    $('#hat div:nth-child(5)').css({ "margin-right": "auto" });
    if ($('*').is('#kinds-eat')) {
        $('#logo').css({ "margin": "5px " + ($('#kinds-eat').width() - $('#logo').width() + 16) / 2 + "px 0px auto" });
        $('#minihat-word').css({ "margin": "16px " + ($('#kinds-eat').width() - 186 + 16) / 2 + "px 0px auto" });
        $('#hat div:nth-child(5)').css({ "margin": "0px auto 0px " + ($('#order').width() + 16 - $('.work-time').width()) / 2 + "px" });
        $('#miniHat div:nth-child(5)').css({ "margin": "0px auto 0px " + ($('#order').width() + 16 - 110) / 2 + "px" });
    }
    //При смене размера экрана, меняет размер hat и logo
    $(window).on('resize', function () {
        if (($(window).width() - $('#eat,#main,#main-finish').width()) / 2 > 245) {
            $("#hat,#miniHat").css({
                "grid-template-columns": ($(window).width() - $('#eat,#main,#main-finish').width()) / 2 + "px " + $('#eat,#main,#main-finish').width() / 3 + "px " +
                    +$('#eat,#main,#main-finish').width() / 3 + "px " + $('#eat,#main,#main-finish').width() / 3 + "px auto"
            });
            if ($('*').is('#kinds-eat')) {
                $('#logo').css({ "margin": "5px " + ($('#kinds-eat').width() - $('#logo').width() + 16) / 2 + "px 0px auto" });
                $('#minihat-word').css({ "margin": "16px " + ($('#kinds-eat').width() - 186 + 16) / 2 + "px 0px auto" });
                $('#hat div:nth-child(5)').css({ "margin": "0px auto 0px " + ($('#order').width() + 16 - $('.work-time').width()) / 2 + "px" });
                $('#miniHat div:nth-child(5)').css({ "margin": "0px auto 0px " + ($('#order').width() + 16 - $('#miniHat div:nth-child(5) a h1').width()) / 2 + "px" });
            }
        }
    });
    //при нажатии на "заказать обед" страница прокручиается вверх
    $("#miniHat div:nth-child(2) a").click(function () {
        $("#list-eat").animate({ scrollTop: 0 }, 100);
    });
});