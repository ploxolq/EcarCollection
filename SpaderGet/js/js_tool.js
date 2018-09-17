//获取url的名称
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}
//数字输入（非数字则替换）（贷款计算专用）
function intput(object,max) {
    var obj = $(object);
    obj.keyup(function () {
        var str = obj.val().replace(/[^\d]/g, '');
        str = str.replace(/^0*/, "");
            if (str*1 > max) {
                str = max;
                str = formatMoney(str, 0);
            }
            else {
                str = str.replace(/^0/, "");
                str = formatMoney(str, 0);
            }
        obj.val(str);
        allcount();
    });
}
function fpintput(object, max) {
    var obj = $(object);
    obj.keyup(function () {
        var str = obj.val().replace(/[^\d]/g, '');
        str = str.replace(/^0*/, "");
        if (str*1 > max) {
            str = max;
        }
        obj.val(str);
        allcount();
    });
}
//数字输入（非数字则替换）
function intinput(object, max) {
    var obj = $(object);
    var str = obj.val().replace(/^0*/, "");
    obj.keyup(function () {
        var str = obj.val().replace(/[^\d]/g, '');
        str = str.replace(/^0*/, "");
        if (str * 1 > max) {
            str = max;
        }
        obj.val(str);
    });
}
//检验是否为数字（包括浮点型）
function intinput(object) {
    var obj = $(object);
    obj.keyup(function () {
    reg = /^(\d*\.)?\d+$/;
    if (reg.test(obj.val() == true)){
        return true;
    } else {
        return false;
    }
    });
}
//转换为int
function toint(object) {
        var str = object.replace(/[^\d]/g, '');
        return str;
}
//数字格式化

function formatMoney(s, type) {
    if (/[^0-9\.]/.test(s))
        return s;
    if (s == null || s == "")
        return "0";
    s = s.toString().replace(/^(\d*)$/, "$1.");
    s = (s + "00").replace(/(\d*\.\d\d)\d*/, "$1");
    s = s.replace(".", ",");
    var re = /(\d)(\d{3},)/;
    while (re.test(s))
        s = s.replace(re, "$1,$2");
    s = s.replace(/,(\d\d)$/, ".$1");
    if (type == 0) {// 不带小数位(默认是有小数位)  
        var a = s.split(".");
        if (a[1] == "00") {
            s = a[0];
        }
    }
    return s;
}  