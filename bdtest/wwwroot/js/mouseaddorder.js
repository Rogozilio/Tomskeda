function createProduct(id, name, price = 0, value = 1){
  $('#orders-list').append("<div class='block-order'>"+
                              "<input type='hidden' value="+ id +">"+
                              "<div class='name-order'>"+
                                name+
                              "</div>"+
                              "<div class='down-part-order'>"+
                                "<div class='price-order'>"+
                                  price+
                                  "<span>₽</span>"+
                                "</div>"+
                                "<div class='count-order'>"+
                                  "<button class='btn-minus-order'>−</button>"+
                                  "<input class='text-number-order'  type=tel name=number maxlength=2 value="+ value +" />"+
                                  "<button class='btn-plus-order'>+</button>"+
                                "</div>"+
                              "</div>"+
                            "</div>");
}
//
function syncProduct(thisit){
    var nameproduct = $.trim($(thisit).parent().parent().parent().prev().prev().text());
     for(var checkdiv = $("div[id='orders-list']").children();checkdiv.text() !== "";checkdiv = checkdiv.next())
      {
          var nameorderproduct = $.trim(checkdiv.children().next().html());
          if (nameorderproduct == nameproduct)
          {
            checkdiv.find('.text-number-order').first().val($(thisit).parent().find("input").first().val());
            if($(thisit).parent().find("input").first().val() <= 0)
                checkdiv.first().remove();
            priceСalculation();
            return false;
          }
      }
      if($(thisit).parent().find("input").first().val() >= 1)
        createProduct($(thisit).parent().parent().parent().parent().parent().children().val(), $(thisit).parent().parent().parent().prev().prev().text(), $(thisit).parent().parent().prev().clone().children().remove().end().text(), $(thisit).parent().find("input").first().val());
      priceСalculation();
}
//
function syncKomplex(thisit){
  var exist = 0;
  var id = "2";
  var price = $(thisit).prev().clone().children().remove().end().text();
  var namekomplex = "Комплексный обед: <br>";
  $('.box-komplex, .extra-komplex').each(function(){
    if($(this).css('background-color') == "rgb(229, 244, 220)")
    {
      namekomplex += "-" + $(this).children().next().next().text() + '<br>';
      id +=","+$(this).children().val();
    }
  })
  $(".block-order").each(function(){
    if($(this).children().next().html() == namekomplex)
    {
      exist = 1;
      $(this).find(".text-number-order").first().val(Number($(this).find(".text-number-order").first().val()) + 1)
      return false;
    }
  })
  if(!exist)
    createProduct(id, namekomplex, price, 1);
  priceСalculation();
}
$(document).ready(function(){
    //проверка на цифру
    $("input[name='number']").keypress(function(key){ 
        if(key.charCode < 48 || key.charCode > 57)
            return false;
    });
    //возможность писать цифру до 20
    $("input[name='number']").blur(function(){
        if($(this).val() > 20)
            $(this).val(20);
        syncProduct(this);
        syncOrderCookie();
    });
    //при наведении на продукт
    $(".btn-minus, .btn-plus").mouseover(function(){
      $(this).css('background-color', 'whitesmoke');
    });
    //при отведении от продукта
    $(".btn-minus, .btn-plus").mouseout(function(){
        $(this).css('background-color', 'inherit');
    });
    //нажатие на минус
    $(".btn-minus").click(function(){
      var val = $(this).next().val();
      if(val > 0)
        $(this).next().val(--val);
      if($(this).next().val() <= 0)
        $(this).parent().parent().parent().parent().parent().animate({"background-color":"white"}, 300);
      syncProduct(this);
      syncOrderCookie();
    });
    //нажатие на плюс
    $(".btn-plus").click(function(){
      var val = $(this).prev().val();
      if(val < 20)
        $(this).prev().val(++val);
      if($(this).prev().val() > 0)
      {
        $(this).parent().parent().parent().parent().parent().animate({"background-color":"#E5F4DC"}, 300);
      }
      syncProduct(this);
      syncOrderCookie();
    });
    //при нажатие на добавить комплекcный обед
    $("#button-komplex").click(function(){
      if($(this).css("background-color") == "rgb(0, 132, 0)")
      {
        syncKomplex(this);
        syncOrderCookie();
      }
    })
});