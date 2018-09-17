

$(function () {
    ///标题验证
    $("#txt_title").keyup(function () {
        titlevalidate("#txt_title", "#div_title_error");
    });
    $("#txt_title").blur(function () {
        titlevalidate("#txt_title", "#div_title_error");
    });
    //时间验证
    $("#txt_buydate").blur(function () {
        datevalidate("#txt_buydate", "#buydate_e");
    });
    //价格验证
    $("#txt_buyprice").keyup(function () {
        intinput("#txt_buyprice");
        pricevalidate("#txt_buyprice", "#div_buyprice_error");
    });
    $("#txt_buyprice").blur(function () {
        intinput("#txt_buyprice");
        pricevalidate("#txt_buyprice", "#div_buyprice_error");
    });
    //油耗验证
    $("#txt_car_oil").keyup(function () {
        oilvalidate("#txt_car_oil", "#div_oil_error");
    }); $("#txt_car_oil").blur(function () {
        oilvalidate("#txt_car_oil", "#div_oil_error");
    });

    //评价验证
    $("#txt_oil_summary").blur(function () {
        summaryvalidate("#star_oil", "#txt_oil_summary", "#error_oil");
        SpaceReplace("#txt_oil_summary");
    });
    $("#txt_oil_summary").keyup(function () {
        summaryvalidate("#star_oil", "#txt_oil_summary", "#error_oil");
    });
    $("#star_oil>div").click(function () {
        summaryvalidate("#star_oil", "#txt_oil_summary", "#error_oil");
    });

    $("#txt_drive_summary").blur(function () {
        summaryvalidate("#star_drive", "#txt_drive_summary", "#error_drive");
    });
    $("#star_drive>div").click(function () {
        summaryvalidate("#star_drive", "#txt_drive_summary", "#error_drive");
    });


    $("#txt_cost_summary").blur(function () {
        summaryvalidate("#star_cost", "#txt_cost_summary", "#error_cost");
    });
    $("#star_cost>div").click(function () {
        summaryvalidate("#star_cost", "#txt_cost_summary", "#error_cost");
    });


    $("#txt_power_summary").blur(function () {
        summaryvalidate("#star_power", "#txt_power_summary", "#error_power");
    });
    $("#star_power>div").click(function () {
        summaryvalidate("#star_power", "#txt_power_summary", "#error_power");
    });


    $("#txt_config_summary").blur(function () {
        summaryvalidate("#star_config", "#txt_config_summary", "#error_config");
    });
    $("#star_config>div").click(function () {
        summaryvalidate("#star_config", "#txt_config_summary", "#error_config");
    });


    $("#txt_comfort_summary").blur(function () {
        summaryvalidate("#star_comfort", "#txt_comfort_summary", "#error_comfort");
    });
    $("#star_comfort>div").click(function () {
        summaryvalidate("#star_comfort", "#txt_comfort_summary", "#error_comfort");
    });



    $("#txt_space_summary").blur(function () {
        summaryvalidate("#star_space", "#txt_space_summary", "#error_space");
    });
    $("#star_space>div").click(function () {
        summaryvalidate("#star_space", "#txt_space_summary", "#error_space");
    });


    $("#txt_appearance_summary").blur(function () {
        summaryvalidate("#star_appearance", "#txt_appearance_summary", "#error_appearance");
    });
    $("#star_appearance>div").click(function () {
        summaryvalidate("#star_appearance", "#txt_appearance_summary", "#error_appearance");
    });

    $("#txt_inside_summary").blur(function () {
        summaryvalidate("#star_inside", "#txt_inside_summary", "#error_inside");
    });
    $("#star_inside>div").click(function () {
        summaryvalidate("#star_inside", "#txt_inside_summary", "#error_inside");
    });

    $("#txt_all_summary").blur(function () {
        summaryvalidate("#star_all", "#txt_all_summary", "#error_all");
    });
    $("#star_all>div").click(function () {
        summaryvalidate("#star_all", "#txt_all_summary", "#error_all");
    });

});
function SpaceReplace(object) {
    var str = $(object).val();
    str = str.replace(/^\s+|\s+$/g, '');
    str = $.trim(str);
    $(object).val(str);
}


function oilvalidate(object, error) {
    var obj = $(object).val();
    var errors = $(error);
    var str = obj.replace(/\s+/g, '');
    str = str.replace(/^0*/, "");
    $(object).val(str);
    reg = /^(\d*\.)?\d+$/;
    regnull = /^\s*$/;
    if (regnull.test(obj)) {
        errors.css("display", "block");
        errors.html('请输入');
        return false;
    } else if (!reg.test(obj)) {
        errors.css('display', 'block');
        errors.html('请输入正确油耗');
        return false;
    } else if (obj <= 2 || obj >= 45) {
        errors.css('display', 'block');
        errors.width("300px");
        errors.html('请输入正确油耗，数值区间：（3-44）');
        return false;
    }
    else {
        errors.css('display', 'none');
        errors.html('');
        return true;
    }
}

function titlevalidate(object, error) {
    var obj = $(object).val();
    var errors = $(error);
    var str = obj.replace(/\s+/g, '');
    $(object).val(str);
    regnull = /^\s*$/;
    if (regnull.test(obj)) {
        errors.css("display", "block");
        errors.html('输入标题');
        return false;
    } else if (obj.length > 30) {
        errors.css("display", "block");
        errors.width("100px");
        errors.html('标题不得超过30字');
        return false;
    }
    else {
        errors.css("display", "none");
        errors.html('');
        return true;
    }

}

function pricevalidate(object, error) {
    var obj = $(object).val();
    var errors = $(error);
    var str = obj.replace(/\s+/g, '');
    str = str.replace(/^0*/, "");
    $(object).val(str);
    reg = /^(\d*\.)?\d+$/;
    regnull = /^\s*$/;
    if (regnull.test(obj)) {
        errors.css("display", "block");
        errors.html("请输入");
        return false;
    } else if (!reg.test(obj)) {
        errors.css('display', 'block');
        errors.html("请输入正确价格");
        return false;
    }
    else if (obj <= 0) {
        errors.css('display', 'block');
        errors.html("请输入正确价格");
        return false;
    }
    else {
        errors.css('display', 'none');
        errors.html("");
        return true;
    }
}


function summaryvalidate(star, summary, error) {
    var stars = $("" + star + ">div.star_score>.clibg").attr("data");
    var summarys = blockReplace($(summary).val());
    var errors = $(error);
    regnull = /^\s*$/;
    if (regnull.test(summarys)) {
        errors.css("display", "block");
        errors.html("请评价");
        return false;
    }
    else if (stars == undefined) {
        errors.css("display", "block");
        errors.html("请打分");
        return false;
    } else {
        errors.css("display", "none");
        errors.html("");
        return true;
    }

}
function blockReplace(object) {
    var str = object;
    if (str == "在市区、郊区、高速上，油耗表现怎么样？" || str == "转向是否精准？过弯是否够硬？刹车是否灵敏？" || str == "花了多少钱呢？觉得性价比怎么样？" || str == "动力方面表现怎么样？" || str == "功能配置有何亮点？还有什么不太满意的吗？" || str == "座椅合适吗？有噪音吗？车是否有颠簸感？" || str == "乘坐空间和载物空间怎么样？" || str == "颜值如何？对Ta的线条、外观、轮毂满意吗？" || str == "内饰的做工，用料怎么样？") {
        str = "";
    }
    return str;
}


function datevalidate(object, error) {
    var obj = $(object).val();
    var errors = $(error);
    regnull = /^\s*$/;
    if (regnull.test(obj)) {
        errors.css("display", "block");
        errors.html("请输入");
        return false;
    }
    else {
        errors.css("display", "none");
        errors.html("");
        return true;
    }
}

//车型验证
function carvalidate(object, error) {
    var obj = $(object).val();
    var errors = $(error);
    if (obj == "000000" || obj == "0") {
        errors.css("display", "block");
        errors.html("请选择车型");
        return false;
    }
    else {
        errors.css("display", "none");
        errors.html("");
        return true;
    }
}
//类型验证(使用class)
function typtvalidate(object, error) {
    var obj = $(object).attr("Ttype");
    var errors = $(error);
    if (obj == undefined) {
        errors.css("display", "block");
        errors.html("请选择口碑类型");
        return false;
    }
    else {
        errors.css("display", "none");
        errors.html("");
        return true;
    }
}
