function loadCookie(product)
{
    var i = 0;
    var length = (product.length)/5;
    for(var i = 0;length--;i=i+5)
    {    
        if(product[i].indexOf("2,") != -1)
        {
            var id = product[i].split(',');
            var name = product[i + 2].split('<br> -');
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
                                                        "<button class='btn-minus-order'>−</button>"+
                                                        "<input class='text-number-order'  type=tel name=number maxlength=2 value="+ product[i+4] +" />"+
                                                        "<button class='btn-plus-order'>+</button>"+
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
                                            "<button class='btn-minus-order'>−</button>"+
                                            "<input class='text-number-order'  type=tel name=number maxlength=2 value="+ product[i+4] +" />"+
                                            "<button class='btn-plus-order'>+</button>"+
                                        "</div>"+
                                        "<div class='price-multiply-count font'>"+
                                            (product[i+3]*product[i+4])+
                                            "<span> ₽</span>"+
                                         "</div>"+
                                    "</div>");
        }
    }
    if(Cookies.get("Name") !== 'undefined')
        $("input[name='Name']").val(Cookies.get("Name"));
    if(Cookies.get("Email") !== 'undefined')
        $("input[name='Email']").val(Cookies.get("Email"));
    if(Cookies.get("Phone") !== 'undefined')
        $("input[name='Phone']").val(Cookies.get("Phone"));
    if(Cookies.get("Street") !== 'undefined')
        $("input[name='Street']").val(Cookies.get("Street"));
    if(Cookies.get("House") !== 'undefined')
        $("input[name='House']").val(Cookies.get("House"));
    if(Cookies.get("Porch") !== 'undefined')
        $("input[name='Porch']").val(Cookies.get("Porch"));
    if(Cookies.get("Floor") !== 'undefined')
        $("input[name='Floor']").val(Cookies.get("Floor"));
    if(Cookies.get("Apartment") !== 'undefined')
        $("input[name='Apartment']").val(Cookies.get("Apartment"));
    if(Cookies.get("Comment") !== 'undefined')
        $("input[name='Comment']").val(Cookies.get("Comment"));
    if(Cookies.get("date") !== undefined)
        $("select[name='date']").val(Cookies.get("date"));
    if(Cookies.get("pay") !== undefined)
    {
        $("input[type='radio'][value="+Cookies.get("pay")+"]").attr("checked","checked");
        $("input[type='radio'][value="+Cookies.get("pay")+"]").parent().next().children().css("color","rgb(104, 180, 54)");
        $("#payment-type").text($("input[type='radio'][value="+Cookies.get("pay")+"]").parent().next().children().text());
    }
    else
    {
        $("input[id='payChoice1']").attr("checked","checked");
        $("label[for='payChoice1']").css("color","rgb(104, 180, 54)");
        $("#payment-type").text($("input[type='radio'][value='1']").parent().next().children().text());
    }
}
function saveCookie(){
    var ids ='';
    var counts ='';
    var day = Cookies.get('day');
    $("#list-eat-order .block-eat-order, .block-komplex-order").each(function(){
        ids += $(this).find("input[type='hidden']").first().val()+',';
        counts += $(this).find('.text-number-order').first().val()+',';
    })
    ids = ids.slice(0,-1);
    counts = counts.slice(0,-1);
    Cookies.set("ids"+day,ids);
    Cookies.set("counts"+day,counts);
}
function sync()
{
    if ($('#list-eat-order').children().length == 0)
    {
        $("#list-extra-order .block-eat-order").show();
        $(location).attr('href',"https://tomskeda.ru/");
    }
    for(var nameextra = $("#list-extra-order .block-eat-order");nameextra.text() !== "";nameextra = nameextra.next())
    {
        for(var nameproduct = $("#list-eat-order .block-eat-order");nameproduct.text() !== "";nameproduct = nameproduct.next())
        {
            if($.trim(nameproduct.first().find(".name-eat-order").text()) == $.trim(nameextra.first().find(".name-eat-order").text()))
            {
                nameextra.hide();
                nameextra.first().find(".text-number-order").attr("value",nameproduct.first().find(".text-number-order").val());
                nameextra.first().find(".text-number-order").val(nameproduct.first().find(".text-number-order").val());
                nameextra.first().find(".price-multiply-count").html(nameproduct.first().find(".price-multiply-count").html());
                break;
            }
            else
            {
                nameextra.show();
            }
        }
    }
}
function scorePrice()
{
    var price = Number(0);
    $("#list-eat-order .block-eat-order, .block-komplex-order").each(function(){
        price += Number($(this).first().find(".price-multiply-count").clone().children().remove().end().text());
    })
    $("#full-price").html((price)+"<span style='font-weight:normal'> ₽</span>");
    $("td[name='price']").html(price+"<span style='font-weight:normal'> ₽</span>");
    if(price > 0 && price < 300)
    {
        $("td[name='delivery']").html(50+"<span style='font-weight:normal'> ₽</span>");
        $("td[name='result']").html((price+50)+"<span style='font-weight:normal'> ₽</span>");
        Cookies.set("fullprice",price+50);
    }
    else
    {
        $("td[name='delivery']").html(0+"<span style='font-weight:normal'> ₽</span>");
        $("td[name='result']").html(price+"<span style='font-weight:normal'> ₽</span>");
        Cookies.set("fullprice",price);
    }
}
function errorRegExp(thisit, amount, pattern, text)
{
    Cookies.set($(thisit).attr("name"),"");
    if($(thisit).val().length > amount)
    {
        $(thisit).css("border-color","FireBrick");
        $(thisit).parent().parent().next().find(".text-error").text("Количество знаков превышает лимит "+amount+".");
        return 0;
    }
    if($(thisit).val().length == 0 && $(thisit).attr("name") != "apartment" && $(thisit).attr("name") != "comment")
    {
        var name = $(thisit).parent().prev().text().slice(0,-1);
        $(thisit).css("border-color","FireBrick");
        $(thisit).parent().parent().next().find(".text-error").text("Необходимо заполнить «"+name+"».");
        return 0;
    }
    if(pattern.test($(thisit).val()))
    {
        $(thisit).css("border-color","rgb(104, 180, 54)");
        $(thisit).parent().parent().next().find(".text-error").text("");
        Cookies.set($(thisit).attr("name"),$(thisit).val());
        return 1;
    }
    else
    {
        $(thisit).css("border-color","FireBrick");
        $(thisit).parent().parent().next().find(".text-error").text(text);
        return 0;
    }
}

$( window ).ready(function() 
{
    //проверка на цифру
    $("#list-eat-order,#list-extra-order").keypress(function(key){ 
        if(key.charCode < 48 || key.charCode > 57)
            return false;
    });
    //лимит ввода до 20
    $("#list-eat-order,#list-extra-order").on( "blur", ".text-number-order",function(){
        var price = $(this).parent().prev().clone().children().remove().end().text();
        $(this).attr("value",$(this).val());
        if($(this).attr("value") > 20)
        {
            $(this).attr("value",20);$(this).val(20);
        }
        $(this).parent().next().html($(this).attr("value")*price + "<span> ₽</span>");
        saveCookie();
        sync();
        scorePrice();
    })
    //лимит ввода до 20 для корзины
    $("#list-eat-order").on( "blur", ".text-number-order",function(){
        if($(this).attr("value") == 0)
        {
            $(this).parent().parent().remove();
        }
        saveCookie();
        sync();
        scorePrice();
    });
    //лимит ввода до 20 для доп. продуктов
    $("#list-extra-order").on( "blur", ".text-number-order",function(){
        if($(this).val() > 0)
        {
            $('#list-eat-order').append("<div class='block-eat-order'>"+
                                        $(this).parent().parent().html()+
                                        "</div>");
            $(this).parent().parent().hide();
        }
        saveCookie();
        sync();
        scorePrice();
    });
    //при нажатии на минус
    $("#list-eat-order,#list-extra-order").on( "click",".btn-minus-order", function(){
        node = $(this).next();
        value = $(this).next().attr("value");
        price = $(this).parent().prev().clone().children().remove().end().text();
        if(value > 0)
        {
            node.attr("value",--value);node.val(value);
            $(this).parent().next().html(value*price + "<span> ₽</span>");
        }
        saveCookie();
        sync();
        scorePrice();
    })
    //доп. при нажатии на минус только для корзины
    $("#list-eat-order").on( "click",".btn-minus-order", function(){
        if($(this).next().attr("value") == 0)
        {
            $(this).closest(".block-eat-order, .block-komplex-order").remove();
        }
        saveCookie();
        sync();
        scorePrice();
    })
    //при нажатии на плюс
    $("#list-eat-order,#list-extra-order").on( "click",".btn-plus-order", function(){
        node = $(this).prev();
        value = $(this).prev().attr("value");
        price = $(this).parent().prev().clone().children().remove().end().text();
        if(value < 20)
        {
            node.attr("value",++value);node.val(value);
            $(this).parent().next().html(value*price + "<span> ₽</span>");
        }
        saveCookie();
        scorePrice();
    })
    //при нажатии на плюс только в доп. продуктах
    $("#list-extra-order").on( "click",".btn-plus-order", function(){
        if($(this).prev().attr("value") > 0)
        {
            $('#list-eat-order').append("<div class='block-eat-order'>"+
                                        $(this).parent().parent().html()+
                                        "</div>");
            $(this).parent().parent().hide();
        }
        saveCookie();
        scorePrice();
    })
    //при нажатии на плюс и минус в комплексах
    $("#list-eat-order").on( "click",".btn-plus-order, .btn-minus-order", function(){
        node = $(this).parent().parent().parent();
        value = $(this).parent().first().find('.text-number-order').attr("value");
        $(this).closest(".komplex-order").find(".counts").html(Number(value));
    })
    //маска на телефон
    $("input[name='Phone']").mask("+7(999) 999-9999");
    //при нажатии на способ оплаты
    $("table").on("click","input[type='radio']:not(input[checked],#payChoice2)",function(){
        $("table label").css("color","black");
        $("input[checked]").removeAttr("checked");
        $(this).attr("checked","checked");
        $(this).parent().next().children().css("color","rgb(104, 180, 54)");
        $("#payment-type").text($(this).parent().next().children().text());
    })
    //при наведении на способ оплаты
    $("table").on("mouseover","label:not(label[for='close'],input[type='radio'])",function(){
        $(this).css("color","rgb(104, 180, 54)");
        $(this).parent().next().children().css("color","rgb(104, 180, 54)");
    });
    //при отведении от способа оплаты
    $("table").on("mouseout","label,input[type='radio']:not(input[checked])",function(){
        if(!$(this).parent().prev().children().attr("checked"))
        {
            $(this).css("color","black");
            $(this).parent().next().children().css("color","black");
        }
    });
    //скрытие/показ данных о соглашении обработки
    $("#info-data-processing").click(function(){ 
        $("#info-block").slideToggle("slow");
    });
    /////////////////////////////////
    //////РЕГУЛЯРНЫЕ ВЫРАЖЕНИЯ///////
    /////////////////////////////////
    $("input[name='Name']").blur(function(){
        var pattern = new RegExp("^[A-Za-zА-Яа-я]+$");
        errorRegExp(this, 20, pattern, "Значение «Имя» должно содержать только буквенные символы.");
    })
    $("input[name='Email']").blur(function(){
        var regexEmail = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
        var pattern = new RegExp(regexEmail);
        errorRegExp(this, 50, pattern, "Значение «Email» не является правильным email адресом.");
    })
    $("input[name='Phone']").blur(function(){
        var pattern = new RegExp("^[+]{1}[0-9]{1}[(]{1}[0-9]{3}[)]{1} [0-9]{3}[-]{1}[0-9]{4}$");
        errorRegExp(this, 17, pattern, "Необходимо заполнить «Моб. телефон».");
    })
    $("input[name='Street']").blur(function(){
        var pattern = new RegExp("^[^a-zA-Z]+$");
        errorRegExp(this, 50, pattern, "Значение «Улица» не должно содержать английские символы.");
    })
    $("input[name='House']").blur(function(){
        var pattern = new RegExp("");
        errorRegExp(this, 50, pattern, "");
    })
    $("input[name='Porch']").blur(function(){
        var pattern = new RegExp("^[0-9]+$");
        errorRegExp(this, 2, pattern, "Значение «Подъезд» должно содержать только цифры.");
    })
    $("input[name='Floor']").blur(function(){
        var pattern = new RegExp("^[0-9]+$");
        errorRegExp(this, 2, pattern, "Значение «Этаж» должно содержать только цифры.");
    })
    $("input[name='Apartment']").blur(function(){
        var pattern = new RegExp("");
        errorRegExp(this, 50, pattern, "");
    })
    $("input[name='Comment']").blur(function(){
        var pattern = new RegExp("");
        errorRegExp(this, 100, pattern, "");
    })
    //включение всех функций события blur при загрузке страницы
    $("input[type='text']").trigger('blur');
    //активация кнопки при всех заполненых полях 
    $("input[type='text'], input[type='checkbox']").on('blur change',function(){
        if(Cookies.get("name") != "" && Cookies.get("email") != "" && Cookies.get("phone") != "" && 
        Cookies.get("street") != "" && Cookies.get("house") != "" && Cookies.get("porch") != "" &&
        Cookies.get("floor") != "" && $("#data-processing").is(':checked'))
        {
            $("#button-checkout").css({"background":"rgba(104, 180, 54,1)","cursor":"pointer"});
            $("#button-checkout").removeAttr('disabled');
        }
        else
        {
            $("#button-checkout").css({"background-color":"rgba(104, 180, 54,0.7)","cursor":"default"});
            $("#button-checkout").attr("disabled",'disabled');
        }
    })
    //сохранить в куки способ оплаты
    Cookies.set("pay",$("input[type='radio'][checked='checked']").val());
    $("input[type='radio']").change(function(){
        Cookies.set("pay",$("input[type='radio'][checked='checked']").val());
    })
    //сохранить в куки время доставки
    Cookies.set("date",$("select[name='date']").val());
    $("select[name='date']").change(function(){
        Cookies.set("date",$(this).val());
    })
})