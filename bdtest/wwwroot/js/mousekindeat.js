past = this;
$(document).ready(function(){
    $(window).scrollTop(0);
    //при наведении на вид еды
    $(".kind-eat").mouseover(function(){
      $(this).css('color', '#008400');
    });
    //при отведении от вида еды
    $(".kind-eat").mouseout(function(){
        if(this.check !== true)
        {
            $(this).css('color', 'black');
        }
    });
    //плавная анимация при выборе вида еды
    $("#scroll-kind-eat,#bancet_holiday").on("click","a", function (event) {
        event.preventDefault();
        var id  = $(this).attr('href');
        if(document.getElementById(id))
        {
            var top = $(document.getElementById(id)).offset().top;
            var currenttop = $('#list-eat').scrollTop();
            $('#list-eat').animate({scrollTop: top+currenttop-200}, 400);
        }
    });
    //выделение вида еды при скролинге
    $('#list-eat').scroll(function(){
        $('#scroll-kind-eat a').each(function () { 
            id = $(this).attr('href'); 
            distanceid = $(document.getElementById(id)).offset().top;                                       //расстояние от текущего скрола до id
            currentscroll = $('#list-eat').scrollTop();
            if(currentscroll >= distanceid+currentscroll-201)
            {
                $(".kind-eat").css({'text-decoration':'none','color':'black'});
                $(".kind-eat").removeClass('arrow-right');
                $(this).css({'text-decoration':'underline','color':'#008400'});
                $(this).addClass('arrow-right')
                past.check = false;
                past = this;
                this.check = true;
                return 0;
            }
        });
    });
});