function clickDay(day = 0) {
    $(document).ready(function () {
        $('#list-eat').load('Index/GetListFood?day='+day, function () {
            $('#kinds-eat').load('Index/GetKindsFood?day='+day, function () {
                $('#order').load('Index/GetMiniBasket?day='+day);
            });
        });
        Cookies.set("day", day);
    });
}
$(document).ready(function () {
    $(window).load(function () {
        $(".day:first").css({ 'background': '#ffb444', 'color': '#008400' });//при загрузке выделяет сегодняшний день
        Cookies.remove('name');
        Cookies.remove('email');
        Cookies.remove('phone');
        Cookies.remove('street');
        Cookies.remove('house');
        Cookies.remove('porch');
        Cookies.remove('floor');
        Cookies.remove('apartment');
        Cookies.remove('comment');
        Cookies.remove('date');
        Cookies.remove('pay');
        Cookies.remove('fullprice');
    });
    //при наведении на дни
    $(".day").mouseover(function () {
        $(this).css('color', '#008400');
    });
    //при отведении от дней
    $(".day").mouseout(function () {
        if ($(this).css('background-color') !== 'rgb(255, 180, 68)') {
            $(this).css('color', 'black');
        }
    });
    //при нажатии на день
    $(".day").click(function () {
        $(".day").css({ 'background': 'white', 'color': 'black' });
        $(this).css({ 'background': '#ffb444', 'color': '#008400' });//при нажатии на день
    });
});