function bind(sid) {
    if (sid != "") {
        bid = $.post("../ajax/get_brandID.ashx", { sid: sid }, function (bid) {
            brandload(bid);
            seriesload(bid, sid);

        });
    } else {
        brandload();
    }
}


$(function () {
    $("#dd_brand").change(function () {
        $.ajax({
            url: '../ajax/get_series.ashx',
            data: { bid: $.trim($(this).val()) },
            cache: false,
            async: false,
            type: "POST",
            dataType: 'json',
            success: function (area) {
                $("#dd_series").html("");
                $("#dd_series").append("<option value='000000'>选择车系</option>");
                $("#dd_car").html("");
                $("#dd_car").append("<option value='000000'>选择车型</option>");
                $.each(area, function (i, item) {
                    $("select[name$=dd_series]").append($("<optgroup></optgroup>").attr("label", item.name));
                    $.each(item.data, function (i, data) {
                        $("select[name$=dd_series]").append($("<option></option>").val(data.id).html(data.name));
                    });
                });
            }
        });
    });

    $("#dd_series").click(function () {
        $.ajax({
            url: '../ajax/get_car.ashx',
            data: { sid: $.trim($(this).val()) },
            cache: false,
            async: false,
            type: "POST",
            dataType: 'json',
            success: function (area) {
                $("#dd_car").html("");
                $("#dd_car").append("<option value='000000'>选择车型</option>");
                $.each(area, function (i, item) {
                    $("select[name$=dd_car]").append($("<optgroup></optgroup>").attr("label", item.name));
                    $.each(item.data, function (i, data) {
                        $("select[name$=dd_car]").append($("<option></option>").val(data.id).html(data.name));
                    });
                });
            }
        });
    });
});
function seriesload(bid,sid) {
    $.ajax({
        url: '../ajax/get_series.ashx',
        data: { bid: bid },
        cache: false,
        async: false,
        type: "POST",
        dataType: 'json',
        success: function (area) {
            $("#dd_series").html("");
            $("#dd_series").append("<option value='000000'>选择车系</option>");
            $("#dd_car").html("");
            $("#dd_car").append("<option value='000000'>选择车型</option>");
            $.each(area, function (i, item) {
                $("select[name$=dd_series]").append($("<optgroup></optgroup>").attr("label", item.name));
                $.each(item.data, function (i, data) {
                    if (data.id == sid) {
                        $("select[name$=dd_series]").append($("<option selected='selected'></option>").val(item.id).html(item.name));
                    }
                    $("select[name$=dd_series]").append($("<option></option>").val(data.id).html(data.name));
                });
            });
        }
    });

}

function brandload(bid) {
    $.ajax({
        url: '../ajax/get_brand.ashx',
        cache: false,
        async: false,
        type: "POST",
        dataType: 'json',
        success: function (area) {
            $("#dd_brand").html("");
            $("#dd_brand").append("<option value='000000'>选择品牌</option>");
            $.each(area, function (i, item) {
                if (item.id == bid) {
                    $("select[name$=dd_brand]").append($("<option selected='selected'></option>").val(item.id).html(item.name));
                }
                $("select[name$=dd_brand]").append($("<option></option>").val(item.id).html(item.name));
            });
        }
    });
};