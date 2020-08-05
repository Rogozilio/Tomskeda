function errorRegExp(thisit, amount, pattern, text) {
    Cookies.set($(thisit).attr("name"), "");
    if ($(thisit).val().length > amount) {
        $(thisit).css("border-color", "FireBrick");
        $(thisit).parent().parent().next().find(".text-error").text("Количество знаков превышает лимит " + amount + ".");
        return 0;
    }
    if ($(thisit).val().length == 0 && $(thisit).attr("name") != "apartment" && $(thisit).attr("name") != "comment") {
        var name = $(thisit).parent().prev().text().slice(0, -1);
        $(thisit).css("border-color", "FireBrick");
        $(thisit).parent().parent().next().find(".text-error").text("Необходимо заполнить «" + name + "».");
        return 0;
    }
    if (pattern.test($(thisit).val())) {
        $(thisit).css("border-color", "rgb(104, 180, 54)");
        $(thisit).parent().parent().next().find(".text-error").text("");
        Cookies.set($(thisit).attr("name"), $(thisit).val());
        return 1;
    }
    else {
        $(thisit).css("border-color", "FireBrick");
        $(thisit).parent().parent().next().find(".text-error").text(text);
        return 0;
    }
}
$(window).ready(function () {
    /////////////////////////////////
    //////РЕГУЛЯРНЫЕ ВЫРАЖЕНИЯ///////
    /////////////////////////////////
    $("input[name='Name']").blur(function () {
        var pattern = new RegExp("^[A-Za-zА-Яа-я]+$");
        errorRegExp(this, 20, pattern, "Значение «Имя» должно содержать только буквенные символы.");
    })
    $("input[name='email']").blur(function () {
        var regexEmail = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
        var pattern = new RegExp(regexEmail);
        errorRegExp(this, 50, pattern, "Значение «Email» не является правильным email адресом.");
    })
    $("input[name='phone']").blur(function () {
        var pattern = new RegExp("^[+]{1}[0-9]{1}[(]{1}[0-9]{3}[)]{1} [0-9]{3}[-]{1}[0-9]{4}$");
        errorRegExp(this, 17, pattern, "Необходимо заполнить «Моб. телефон».");
    })
    $("input[name='street']").blur(function () {
        var pattern = new RegExp("^[^a-zA-Z]+$");
        errorRegExp(this, 50, pattern, "Значение «Улица» не должно содержать английские символы.");
    })
    $("input[name='house']").blur(function () {
        var pattern = new RegExp("");
        errorRegExp(this, 50, pattern, "");
    })
    $("input[name='porch']").blur(function () {
        var pattern = new RegExp("^[0-9]+$");
        errorRegExp(this, 2, pattern, "Значение «Подъезд» должно содержать только цифры.");
    })
    $("input[name='floor']").blur(function () {
        var pattern = new RegExp("^[0-9]+$");
        errorRegExp(this, 2, pattern, "Значение «Этаж» должно содержать только цифры.");
    })
    $("input[name='apartment']").blur(function () {
        var pattern = new RegExp("");
        errorRegExp(this, 50, pattern, "");
    })
    $("input[name='comment']").blur(function () {
        var pattern = new RegExp("");
        errorRegExp(this, 100, pattern, "");
    })
})