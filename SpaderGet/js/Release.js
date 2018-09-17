
$(function () {
    $("#butn_send").click(function () {
        var url = $("#url").text();
        var E_ID = "0";
        var Car_ID = $("#dd_car").val();
        var E_Title = $("#txt_title").val();
        var Buy_Date = $("#txt_buydate").val();
        var Buy_Price = $("#txt_buyprice").val();
        var M_ID = "123";
        var T_ID = $(".types").attr("Ttype");
        var Car_Oil = $('#txt_car_oil').val();
        var Oil_Score = ($("#star_oil>div.star_score>.clibg").attr("data") * 1 + 1) * 10;
        var Oil_Summary = blockReplace($("#txt_oil_summary").val());
        var Power_Score = ($("#star_power>div.star_score>.clibg").attr("data") * 1 + 1) * 10;
        var Power_Summary = blockReplace($("#txt_power_summary").val());
        var Cost_Score = ($("#star_cost>div.star_score>.clibg").attr("data") * 1 + 1) * 10;
        var Cost_Summary = blockReplace($("#txt_cost_summary").val());
        var Config_Score = ($("#star_config>div.star_score>.clibg").attr("data") * 1 + 1) * 10;
        var Config_Summary = blockReplace($("#txt_config_summary").val());
        var Drive_Score = ($("#star_drive>div.star_score>.clibg").attr("data") * 1 + 1) * 10;
        var Drive_Summary = blockReplace($("#txt_drive_summary").val());
        var Space_Score = ($("#star_space>div.star_score>.clibg").attr("data") * 1 + 1) * 10;
        var Space_Summary = blockReplace($("#txt_space_summary").val());
        var Appearance_Score = ($("#star_appearance>div.star_score>.clibg").attr("data") * 1 + 1) * 10;
        var Appearance_Summary = blockReplace($("#txt_appearance_summary").val());
        var Comfort_Score = $("#star_comfort>div.star_score>.clibg").attr("data") * 10;
        var Comfort_Summary = blockReplace($("#txt_comfort_summary").val());
        var Inside_Score = ($("#star_inside>div.star_score>.clibg").attr("data") * 1 + 1) * 10;
        var Inside_Summary = blockReplace($("#txt_inside_summary").val());
        var All_Score = ($("#star_all>div.star_score>.clibg").attr("data") * 1 + 1) * 10;
        var All_Summary = $("#txt_all_summary").val();
        if ((Car_ID == "0") || Car_ID == "000000" || !titlevalidate("#txt_title") || !carvalidate("#dd_car") || !typtvalidate(".types", "#type_error") || !datevalidate("#txt_buydate") || !pricevalidate("#txt_buyprice") || !oilvalidate("#txt_car_oil") || !summaryvalidate("#star_all", "#txt_all_summary")) {
            alert("请完善内容");

            titlevalidate("#txt_title", "#div_title_error");
            carvalidate("#dd_car", "#car_error");
            typtvalidate(".types", "#type_error");
            datevalidate("#txt_buydate", "#buydate_e");
            pricevalidate("#txt_buyprice", "#div_buyprice_error");
            oilvalidate("#txt_car_oil", "#div_oil_error");
            summaryvalidate("#star_all", "#txt_all_summary", "#error_all");
        }
        else {
            $(this).val("正在提交");
            $(this).attr("disabled", true);
            $.ajax({
                type: "POST",
                //url: '../../authen/ajax/koubei.ashx?<%=Request.Uri.QueryString%>',
                url: '../ajax/Release.ashx',
                data: {
                    Url: url,
                    E_ID: E_ID,
                    Car_ID: Car_ID,
                    E_Title: E_Title,
                    Buy_Date: Buy_Date,
                    Buy_Price: Buy_Price * 10000,
                    M_ID: M_ID,
                    T_ID: T_ID,
                    Car_Oil: Car_Oil,
                    Oil_Score: star_opt(Oil_Score),
                    Oil_Summary: Oil_Summary,
                    Power_Score: star_opt(Power_Score),
                    Power_Summary: Power_Summary,
                    Cost_Score: star_opt(Cost_Score),
                    Cost_Summary: Cost_Summary,
                    Config_Score: star_opt(Config_Score),
                    Config_Summary: Config_Summary,
                    Drive_Score: star_opt(Drive_Score),
                    Drive_Summary: Drive_Summary,
                    Space_Score: star_opt(Space_Score),
                    Space_Summary: Space_Summary,
                    Appearance_Score: star_opt(Appearance_Score),
                    Appearance_Summary: Appearance_Summary,
                    Comfort_Score: star_opt(Comfort_Score),
                    Comfort_Summary: Comfort_Summary,
                    Inside_Score: star_opt(Inside_Score),
                    Inside_Summary: Inside_Summary,
                    All_Score: All_Score,
                    All_Summary: All_Summary
                },
                success: function (msg) {
                    if (msg == 1) {
                        alert("成功啦");

                    }
                    else {
                        alert("提交失败，请检查");
                        $("#butn_send").val("提交");
                        $("#butn_send").attr("disabled", false);
                    }
                }
            });
        }
    });
});
function star_opt(object) {
    var r;
    if (isNaN(object)) {
        r = "";
    } else {
        r = object;
    }
    return r;
}

function blockReplace(object) {
    var str = object;
    if (str == "在市区、郊区、高速上，油耗表现怎么样？" || str == "转向是否精准？过弯是否够硬？刹车是否灵敏？" || str == "花了多少钱呢？觉得性价比怎么样？" || str == "动力方面表现怎么样？" || str == "功能配置有何亮点？还有什么不太满意的吗？" || str == "座椅合适吗？有噪音吗？车是否有颠簸感？" || str == "乘坐空间和载物空间怎么样？" || str == "颜值如何？对Ta的线条、外观、轮毂满意吗？" || str == "内饰的做工，用料怎么样？") {
        str = "";
    }
    return str;
}