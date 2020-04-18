$(document).ready(function(){
    
    $("#miniHat").css({'visibility': 'visible',});
    $("#miniHat").slideUp(0);
    $('#list-eat').scrollTop(0);
    //при наведении на продукт
    $(".product, .box-komplex").mouseenter(function(){
      $(this).animate({"border-color":"#97CF9A"}, 200);
    });
    //при отведении от продукта
    $(".product, .box-komplex").mouseleave(function(){
      $(this).animate({"border-color":"#D3D3D3"}, 200);
    });
    //скролл списка с продуктами
    $("#list-eat").scroll(function(){
        var currenttop = $('#list-eat').scrollTop();
        var time = 100;
        if(currenttop == 0)
        {
            $('body').stop();
            $('body').animate({scrollTop: 0}, time);
            $("#hat").css({'visibility': 'visible',});
            $("#miniHat").slideUp(time);
            $("#hat").slideDown(time);
        }
        if(currenttop < ($("#list-eat")[0].scrollHeight - $("#list-eat").height()) && currenttop > 0)
        {
            $('body').stop();
            $('body').animate({scrollTop: 75}, time);
            $("#hat").css({'visibility': 'hidden',});
            $("#miniHat").slideDown(time);
        }
        if (currenttop >= ($("#list-eat")[0].scrollHeight - $("#list-eat").height()))
        {
            $('body').stop();
            $('body').animate({scrollTop:136}, time);
            $("#miniHat").slideUp(time);
        }
    });
    //нажатии на элемент комплексного обеда
    $(".box-komplex").click(function(){
        $(this).parent().find(".box-komplex").css({"background-color":"white"}, 100);
        $(this).css({"background-color":"#E5F4DC"}, 100);
        var count = $(".box-komplex").length/3;
        var active = 0;
        $(".box-komplex").each(function(){
        if($(this).css('background-color') == "rgb(229, 244, 220)")
            active++;
        })
        if(count == active)
            $("#button-komplex").css({"cursor":"pointer","background-color":"rgb(0, 132, 0);"});
        })
});