function loadCookie(product)
{
    var i = 0;
    var length = (product.length)/5;
    for(var i = 0;length--;i=i+5)
    {    
        if(product[i].indexOf("2,") != -1)
        {
            var id = product[i].split(',');
            var name = product[i+2].split('<br>-');
            $('#list-eat-order').append("<div class='block-komplex-order'>"+
                                            "<input type='hidden' value=" + product[i] + ">"+
                                            "<div class='komplex-order'>"+
                                                "<div class='part-block-eat'>"+
                                                    "<div class='name-eat-order font'>"+
                                                        name[0]+
                                                    "</div>"+
                                                    "<div class='price-eat-order font'>"+
                                                        product[i+3]+
                                                        "<span> ₽</span>"+
                                                    "</div>"+
                                                    "<div class='count'>"+
                                                        "x" + product[i+4] +
                                                    "</div>"+
                                                    "<div class='price-multiply-count font'>"+
                                                        (product[i+3]*product[i+4])+
                                                        "<span> ₽</span>"+
                                                    "</div>"+
                                                "</div>"+
                                            "</div>"+
                                        "</div>");
            for(var j = 1;id.length-- > 1;j++)
            {
                $('.komplex-order').last().append("<div class='part-block-eat'>"+
                                        "<div class='name-eat-order font'>"+
                                            name[j]+
                                        "</div>"+
                                        "<div class='price-eat-order font'>"+
                                            0 + "<span> ₽</span>"+
                                        "</div>"+
                                        "<div class='counts'>"+
                                            product[i+4]+
                                        "</div>"+
                                        "<div></div>"+
                                    "</div>")
            }
        }
        else
        {
        $('#list-eat-order').append("<div class='block-eat-order'>"+
                                        "<input type='hidden' value=" + product[i] + ">"+
                                        "<div class='image-eat-order'>"+
                                           "<img src=../" + product[i+1] + ">"+
                                        "</div>"+
                                        "<div class='name-eat-order font'>"+
                                            product[i+2]+
                                        "</div>"+
                                        "<div class='price-eat-order font'>"+
                                            product[i+3]+
                                            "<span> ₽</span>"+
                                        "</div>"+
                                        "<div class='count'>"+
                                            "x"+product[i+4] +
                                        "</div>"+
                                        "<div class='price-multiply-count font'>"+
                                            (product[i+3]*product[i+4])+
                                            "<span> ₽</span>"+
                                         "</div>"+
                                    "</div>");
        }
    }

    Cookies.remove('ids'+ Cookies.get("day"));
    Cookies.remove('counts'+ Cookies.get("day"));
}
function scorePrice()
{
    var price = Number(0);
    $("#list-eat-order .block-eat-order, .block-komplex-order").each(function(){
        price += Number($(this).first().find(".price-multiply-count").clone().children().remove().end().text());
    })
    if(price > 0 && price < 300)
    {
        $("#full-price").html((price+50)+"<span style='font-weight:normal'> ₽</span>");
        $('#list-eat-order').append("<div class='block-eat-order'>"+
                                    "<input type='hidden' value=1>"+
                                    "<div class='image-eat-order'>"+
                                       "<img src='../pict/delivery_food1.png' >"+
                                    "</div>"+
                                    "<div class='name-eat-order font'>Доставка</div>"+
                                    "<div class='price-eat-order font'>50<span> ₽</span></div>"+
                                    "<div class='count'>x 1</div>"+
                                    "<div class='price-multiply-count font'>50<span> ₽</span>"+
                                    "</div>"+
                                "</div>");
    }
    else
    {
        $("#full-price").html((price)+"<span style='font-weight:normal'> ₽</span>");
    }
}
$(document).ready(function(){
    if ($('#list-eat-order').children().length == 0)
    {
        $(location).attr('href',"https://tomskeda.ru/");
    }
    //очищаем ненужные куки
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
})