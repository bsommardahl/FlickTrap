$(document).ready(function () {
    $(".trap_button").click(function () {
        var button = this;
        $.getJSON($(button).val(), function (result) {
            if (result.IsTrapped) {
                $(button).addClass("remove_from_flicks");
                $(button).removeClass("add_to_flicks");
                
            }
            else {
                $(button).addClass("add_to_flicks");
                $(button).removeClass("remove_from_flicks");

            }
            //flip isTrapped on the button's value
            alert($(button).val());
            $(button).val($(button).val().replace(!result.IsTrapped, result.IsTrapped));
            alert($(button).val());
        });

    });

});