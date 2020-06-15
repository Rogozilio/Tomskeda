$(document).ready(function(){
    //при наведении на товар
    $("tr.str").mouseover(function(){
      $(this).children("td").css('background-color', 'green');
    });
    //при отведении от товара
    $("tr.str").mouseout(function(){
        $(this).children("td").css('background-color', 'white');
    });
    //при нажатии на товар
    $("tr.str").click(function(){
        $("input[name='id']").val($(this).children("td:eq(0)").text());                         //id
        $("input[name='name']").val($(this).children("td:eq(1)").text());                       //Имя
        $("textarea[name='description']").val($(this).children("td:eq(2)").text());             //опичание
        var str =  $(this).children("td:eq(3)").text();                                         //информация о продукте
        $("input[name='Kkal']").val(str.slice(str.indexOf("л") + 2, str.indexOf("Б") - 2));          //Ккал
        $("input[name='Belki']").val(str.slice(str.indexOf("Б") + 2, str.indexOf("Ж") - 2));         //Белки
        $("input[name='Jiry']").val(str.slice(str.indexOf("Ж") + 2, str.indexOf("У") - 2));          //Жиры
        $("input[name='Uglevod']").val(str.slice(str.indexOf("У") + 2));                             //Углеводы
        $("input[name='price']").val($(this).children("td:eq(4)").text());                      //Цена
        $("select[name='kind']").val($(this).children("td:eq(5)").text());                      //Вид еды
        var day = $(this).children("td:eq(6)").text();                                          //Дни товара
        var komplex = $(this).children("td:eq(7)").text();                                      //Дни комплекных обедов товара
        for(var i = 1;i < 8;i++)                                                                //Коректное отображение дней товара и комплекных дней на странице
        {
            if (~day.indexOf(""+ i +""))
                $("input[name=day][value='"+ i +"']").prop('checked',true);
            else
                $("input[name=day][value='"+ i +"']").prop('checked',false);
            if (~komplex.indexOf(""+ i +""))
                $("input[name=komplex][value='"+ i +"']").prop('checked',true);
            else
                $("input[name=komplex][value='"+ i +"']").prop('checked',false);
        }
        $("input[name='path']").val($(this).children("td:eq(8)").text()); 
        $('body,html').animate({scrollTop: 0}, 200);                                            //Скролл вверх
        $("input[value='Добавить']").attr('disabled',true);                                     //Кнопка 'добавить' изчезает
        $("input[value='Изменить']").attr('disabled',false);                                    //Кнопка 'изменить' появляется
    });
});