function priceСalculation(){
    var node = $("div #orders-list").children();
    var fullPrice = 0;
    while(node.text() !== "")
    {
        var price = node.first().find(".down-part-order").children().clone().children().remove().end().text();
        var count = node.first().find(".text-number-order").val();
        fullPrice += price*count;
        node = node.next();
    }
    if(fullPrice > 0)
    {
        $("#checkout").css({"background-color":"#008400","border":"1px solid #478a2d","cursor":"pointer"});
        $("#checkout").attr('onclick',"window.location.href='order-send.html'");
    }
    else
    {
        $("#checkout").css({"background-color":"grey","border":"0px solid #478a2d","cursor":"default"});
        $("#checkout").removeAttr( "onclick" );
    }
    $("#price-amount").children().next().text(fullPrice + " ₽");
}
function syncOrderProduct(thisit){
    var nameorderproduct = $.trim($(thisit).parent().parent().prev().text());
    if(nameorderproduct.indexOf("Комплексный обед") != -1)
    {
        priceСalculation();
        return false;
    }
    for(var checkdiv = $("div .product");checkdiv.text() !== "";checkdiv = checkdiv.next())
    {
        var nameproduct = $.trim(checkdiv.first().find(".text-name-product").text());
        if (nameorderproduct == nameproduct)
        {
            checkdiv.find('.text-number-product').first().val($(thisit).parent().find("input").first().val());
            if($(thisit).parent().find("input").first().val() <= 0)
            {
                $(thisit).parent().parent().parent().first().remove();
                checkdiv.first().animate({"background-color":"white"}, 300);
            }
            priceСalculation();
            return false;
        }
    }
}
function syncOrderProductAll(){  
    $(".block-order").each(function(){
        if($(this).children().val().indexOf(',') == -1)
        {
            $(".product input[value="+$(this).children().val()+"]").parent().find('.text-number-product').val($(this).find('.text-number-order').val());
            $(".product input[value="+$(this).children().val()+"]").parent().css({"background-color":"#E5F4DC"});
        }
    })
    priceСalculation();
}
function syncOrderCookie(){
    var ids = '';
    var counts = '';
    var day = $("input[name='day']").val();
    $(".block-order").each(function(){
        ids += $(this).children().val() + ',';
        counts += $(this).find('.text-number-order').val() + ',';
    })
    ids = ids.slice(0,-1);
    counts = counts.slice(0, -1);
    Cookies.set("ids"+day,ids);
    Cookies.set("counts"+day,counts);
}
function loadCookie(product)
{
    var day = $("input[name='day']").val();
    if(Cookies.get('ids'+day) !== null && Cookies.get('ids'+day) !== '' && Cookies.get('ids'+day) !== undefined)
    {
        var i = 0;
        var length = (product.length)/5;
        for(var length = (product.length)/5;length--;i = i + 5)
        {
            createProduct(product[i + 0], product[i + 2],product[i + 3],  product[i + 4])
        }
        syncOrderProductAll();
    }
}
$(document).ready(function(){
    //проверка на цифру
    $("#orders-list").keypress(function(key){ 
        if(key.charCode < 48 || key.charCode > 57)
            return false;
    });
    //возможность писать цифру до 20
    $("#orders-list").on( "blur", ".text-number-order",function(){
        if($(this).val() > 20)
            $(this).val(20);
        syncOrderProduct(this);
        syncOrderCookie();
    });
    //нажатие на минус
    $("#orders-list").on( "click",".btn-minus-order", function(){
    var val = $(this).next().val();
    if(val > 0)
        $(this).next().val(--val);
    if(val == 0)
        $(this).parent().parent().parent().first().remove();
    syncOrderProduct(this);
    syncOrderCookie();
    });
    //нажатие на плюс
     $("#orders-list").on( "click",".btn-plus-order", function(){
    var val = $(this).prev().val();
    if(val < 20)
        $(this).prev().val(++val);
    syncOrderProduct(this);
    syncOrderCookie();
    });
});