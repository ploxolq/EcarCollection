<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SpaderGet.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body div span ul li a{margin:0px;padding:0px;}
        ul li { list-style :none; float:left;}
        .list{width:1000px;height:700px;   }
        .content{width:1000px;height:1000px;   }
        .line_01{width:410px;height:140px;   }
        .line_02{width:450px;height:70px; float:left;}
        .line_02_1{width:150px;height:70px; line-height:70px;display:block;}
        .line_02_2{width:250px;height:70px; display:block;}
        .line_03{width:500px;height:210px;      }
    </style>
</head>
<body>
    <form id="listconfig" action="kb_list.aspx" method="post">
    <div class="list">
        <div>列表配置</div><br />
        <div>
            <table>
                <tr>
                    <td>来源站点：</td>
                    <td><input type="text" size="41" /></td>
                </tr>
                <tr>
                    <td>车系：</td>
                    <td>
                        <select  name="dd_brand" id="dd_brand" >
                        <option>选择品牌</option>
                        <option>选择品牌</option>
                        <option>选择品牌</option>
                        <option>选择品牌</option>
                        </select>
                        <select  name="dd_series" id="dd_series" >
                        <option>选择车系</option>
                        <option>选择品牌</option>
                        <option>选择品牌</option>
                        <option>选择品牌</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>车系(采集)地址：</td>
                    <td><input type="text" size="41" id="txt_seedurl" name="txt_seedurl" />&nbsp;变化的地方请用(*)代替</td>
                </tr>
                <tr>
                    <td>列表开始标记：</td>
                    <td><textarea name="tr_liststart" rows="2" cols="30"></textarea></td>
                </tr>
                <tr>
                    <td>列表结束标记：</td>
                    <td><textarea name="tr_listend" rows="2" cols="30"></textarea></td>
                </tr>
                <tr>
                    <td>发布者始标记：</td>
                    <td><textarea name="tr_userstart" rows="2" cols="30"></textarea></td>
                </tr>
                <tr>
                    <td>发布者结束标记：</td>
                    <td><textarea name="tr_userend"  rows="2" cols="30"></textarea></td>
                </tr>
                <tr>
                    <td>采集页码：</td>
                    <td>从&nbsp;<input type="text" id="txt_min" name="txt_min" size="3"/>&nbsp;页&nbsp;到&nbsp;
                                <input type="text" id="txt_max" name="txt_max" size="3" />&nbsp;页</td>
                </tr>
                <tr>
                    <td>车型规则：</td>
                    <td>开始：<input type="text" id="txt_carstart" name="txt_carstart" size="33"/><br />
                        结束：<input type="text" id="txt_carend" name="txt_carend" size="33"/>
                    </td>
                </tr>
                <tr>
                    <td>链接规则：</td>
                    <td>开始：<input type="text" id="txt_urlstart" name="txt_urlstart" size="33"/><br />
                        结束：<input type="text" id="txt_urlend" name="txt_urlend" size="33"/></td>
                </tr>
                <tr>
                    <td>标题规则：</td>
                    <td>开始：<input type="text" id="txt_titlestart" name="txt_titlestart" size="33"/><br />
                        结束：<input type="text" id="txt_titleend" name="txt_titleend" size="33"/></td>
                </tr>
                <tr>
                    <td><input type="submit" id="btn_list_yl" value="列表预览" /></td>
                    <td>
                        <input type="button" id="btn_list_cj" value="列表采集" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <input type="button" id="btn_list_cl" value="列表处理" />
                    </td>
                </tr>
            </table>
        </div>
    </div>  
        </form>
    <form id="contconfig" action="#">
<%--    <div class="content">
        <div>内容配置</div>
    </div>
--%>    
    </form>
    <div>
        <input type="text" id="txt_list" />
    </div>
    <div>
    
        <input type="button" id="btn_list" value ="测试"/>
    </div>
    <div>
        <input type="text" id="txt_content" />
    </div>
    <div>
        <input type="button" id="btn_content" value ="测试"/>
    </div>    
    <script src="js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="js/jquery.cookie.js" type="text/javascript"></script>
    <script src="js/brand.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            bind();
        });
//        $("#btn_list_yl").click(function () {
//            
//            window.open("kb_list.aspx?url=" + txt_seedurl.value + "&min=" + txt_min.value + "&max=" + txt_max.value + "");
//        });
        $("#btn_list_cj").click(function () {
            $.ajax({
                url: "ajax/set_url.ashx",
                type: "POST",
                data: {
                    url: txt_seedurl.value,
                    min: txt_min.value,
                    max: txt_max.value,
                    series: dd_series.value
                },
                success: function (result) {
                    alert(result);
                }
            });
        });
        $("#btn_list_cl").click(function () {
             window.open("kb_list_cheak.aspx?series=" + dd_series.value +"");
        });
        $("#btn_list").click(function () {
            window.open("kb_list.aspx?url=" + txt_list.value + "");
        });
        $("#btn_content").click(function () {
            window.open("kb_content.aspx?url=" + txt_content.value + "");
        });
    </script>
</body>
</html>
