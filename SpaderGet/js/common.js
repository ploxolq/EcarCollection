/// <reference path="http://localhost:31429/js/jquery-1.4.1.js" />
/// <reference path="startScore.js" />
/// <reference path="jquery-ui.js" />
/// <reference path="js_tool.js" />


///口碑类型选择（）
$(function () {
    ///车型选择
    if (GetQueryString("id") != null) {
        setDisabled("#dd_brand");
        setDisabled("#dd_series");
        setDisabled("#dd_car");
    }

    ///口碑类型选择（）
    var a = $("#T_ID").attr("typeID");
    if (a == "") {
        $("#T_ID li span").click(function () {
            $("#T_ID li span").removeClass("types").addClass("type");
            $(this).addClass("types").removeClass("");
        });
    } else {
        $("#T_ID li span[Ttype=" + a + "]").addClass("types");
        $("#T_ID li span").css("display", "disable");
    }
    //日期选择
    $("#txt_buydate").datepicker({ dateFormat: 'yy-mm-dd', onSelect: function () {
        datevalidate("#txt_buydate", "#buydate_e");
    }
    });
    //购买价格改变
    //var price = formatMoney($("#txt_buyprice").val(), 0);
    //$("#txt_buyprice").val(toint(price));
    var price = $("#txt_buyprice").val();
    $("#txt_buyprice").val(price);
    //选择星
    var oil_scor = $("#star_oil").attr("star");
    var oil_sco = (oil_scor / 10) - 2;
    scoreFun($("#star_oil"), oil_sco, "#star_oil");

    var drive_scor = $("#star_drive").attr("star");
    var drive_sco = (drive_scor / 10) - 1;
    scoreFun($("#star_drive"), drive_sco, "#star_drive");

    var cost_scor = $("#star_cost").attr("star");
    var cost_sco = (cost_scor / 10) - 1;
    scoreFun($("#star_cost"), cost_sco, "#star_cost");

    var power_scor = $("#star_power").attr("star");
    var power_sco = (power_scor / 10) - 1;
    scoreFun($("#star_power"), power_sco, "#star_power");

    var config_scor = $("#star_config").attr("star");
    var config_sco = (config_scor / 10) - 1;
    scoreFun($("#star_config"), config_sco, "#star_config");

    var comfort_scor = $("#star_comfort").attr("star");
    var comfort_sco = (comfort_scor / 10) - 1;
    scoreFun($("#star_comfort"), comfort_sco, "#star_comfort");

    var space_scor = $("#star_space").attr("star");
    var space_sco = (space_scor / 10) - 1;
    scoreFun($("#star_space"), space_sco, "#star_space");

    var appearance_scor = $("#star_appearance").attr("star");
    var appearance_sco = (appearance_scor / 10) - 1;
    scoreFun($("#star_appearance"), appearance_sco, "#star_appearance");

    var inside_scor = $("#star_inside").attr("star");
    var inside_sco = (inside_scor / 10) - 1;
    scoreFun($("#star_inside"), inside_sco, "#star_inside");

    var all_scor = $("#star_all").attr("star");
    var all_sco = (all_scor / 10) - 1;
    scoreFun($("#star_all"), all_sco, "#star_all");

});
function setDisabled(object) {
    var obj = $(object);
    obj.attr("disabled", "disabled");
    obj.css("background-color", "#fff");
}

function intput(object, max) {
    var obj = $(object);
    obj.keyup(function () {
        var str = obj.val().replace(/[^\d\.+]/g, '');
        if (str > max) {
            str = max;
        }
        obj.val(str);
    });
}
