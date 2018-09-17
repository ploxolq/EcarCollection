/// <reference path="jquery.min.js" />
/// <reference path="js_tool.js" />

$(function () {
    ///星星
    var val = $(".member_right_5 div");
    var arr = [];
    for (var i = 0; i < val.length; i++) {
        arr.push(val[i].id);
    }
    for (var i = 0; i < arr.length; i++) {
        var a = arr[i];
        $("#" + a + "").attr("id", "val_" + a + "")
    }
    for (var i = 0; i < arr.length; i++) {
        var a = arr[i];
        $("#val_" + a + " p").each(function (index, element) {
            var num = $(this).attr("tip") / 20;
            var www = num * 2 * 16;
            $(this).css("width", www);
        });
    }


});
