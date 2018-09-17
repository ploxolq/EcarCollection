<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfigPage.aspx.cs" Inherits="SpaderGet.page.Content" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <style type="text/css">
            ul li span a{margin:0;padding:0;}
            *{margin:0 auto;padding: 0px;list-style: none;}
            li{float: left; }
            a{text-decoration:none;color:#fff;}           
            .nav{ list-style:none;float:left;display:block;margin-left:20px;}
            .nav li{float:left;width:100px;height:50px; line-height:50px;}
            .layout{width: 100%;height: 700px;margin:auto;      }
            .header{width: 1000px;height: 50px;margin:auto;background:rgba(0,0,0,0.8);}
            .content {width: 1000px;height: 500px;margin:auto;}
            .Contbox{ width:900px;height:100%;margin:auto;}
    </style>

</head>
<body>
        <div class="header">
            <ul class="nav">
                <li><a href="#">所有配置</a></li>
                <li><a href="#">新增配置</a></li>
            </ul>
        </div>
        <div class="content">
            <div class="Contbox">
                <form id="listconfig" action="list_preview.aspx" method="post">
                    <div class="list">
                        <div>列表配置</div><br />
                        <div>
                            <table>
                <tr>
                    <td>规则名称：</td>
                    <td><input type="text" id="txt_RGname" size="41" /></td>
                </tr>
                <tr>
                    <td>来源站点：</td>
                    <td><input type="text" id="txt_source" size="41" /></td>
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
                    <td><input type="text"a name="tr_liststart" id="tr_liststart" size="33" /></textarea></td>
                </tr>
                <tr>
                    <td>列表结束标记：</td>
                    <td><input type="text" name="tr_listend" id="tr_listend" size="33" /></textarea></td>
                </tr>
                <tr>
                    <td>发布者始标记：</td>
                    <td><input type="text" name="tr_userstart" id="tr_userstart" size="33" /></td>
                </tr>
                <tr>
                    <td>发布者结束标记：</td>
                    <td><input type="text" name="tr_userend" id="tr_userend" size="33" /></textarea></td>
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
                <form id="contconfig" action="content_preview.aspx" method="post">
                    <div class="content">
                       <div>具体配置</div><br />
                       <div>
                        <table>
                            <tr>
                                <td>内容链接（测试）：</td>
                                <td>
                                    <input type="text" id="txt_cont_url" name="txt_cont_url" size="33"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>车型：</td>
                                <td>
                                开始：<input type="text" id="txt_Ccarstart" name="txt_Ccarstart" size="33"/><br />
                                结束：<input type="text" id="txt_Ccarend" name="txt_Ccarend" size="33"/>
                                </td>
                            </tr>

                            <tr>
                                <td>标题：</td>
                                <td>
                                开始：<input type="text" id="txt_Ctitlestart" name="txt_Ctitlestart" size="33"/><br />
                                结束：<input type="text" id="txt_Ctitleend" name="txt_Ctitleend" size="33"/>
                                </td>
                            </tr>
                            <tr>
                                <td>类型：</td>
                                <td>
                                开始：<input type="text" id="txt_Ctypestart" name="txt_Ctypestart" size="33"/><br />
                                结束：<input type="text" id="txt_Ctypeend" name="txt_Ctypeend" size="33"/>
                                </td>
                            </tr>
                            <tr>
                                <td>购车日期：</td>
                                <td>
                                开始：<input type="text" id="txt_Cdatestart" name="txt_Cdatestart" size="33"/><br />
                                结束：<input type="text" id="txt_Cdateend" name="txt_Cdateend" size="33"/>
                                </td>
                            </tr>
                            <tr>
                                <td>购车地址:</td>
                                <td>
                                开始：<input type="text" id="txt_Caddstart" name="txt_Caddstart" size="33"/><br />
                                结束：<input type="text" id="txt_Caddend" name="txt_Caddend" size="33"/>
                                </td>
                            </tr>
                            <tr>
                                <td>价格:</td>
                                <td>
                                开始：<input type="text" id="txt_Cpricestart" name="txt_Cpricestart" size="33"/><br />
                                结束：<input type="text" id="txt_Cprieceend" name="txt_Cprieceend" size="33"/>
                                </td>
                            </tr>
                            <tr>
                                <td>油耗:</td>
                                <td>
                                开始：<input type="text" id="txt_oilstart" name="txt_oilstart" size="33"/><br />
                                结束：<input type="text" id="txt_oilend" name="txt_oilend" size="33"/>
                                </td>
                            </tr>
                            <tr>
                                <td>油耗评分：</td>
                                <td>
                                开始：<input type="text" id="txt_oilstarstart" name="txt_oilstarstart" size="33"/><br />
                                结束：<input type="text" id="txt_oilstarend" name="txt_oilstarend" size="33"/>
                                </td>
                            </tr>
                            <tr>
                                <td>油耗评价：</td>
                                <td>
                                开始：<input type="text" id="txt_oilsumstart" name="txt_oilsumstart" size="33"/><br />
                                结束：<input type="text" id="txt_oilsumend" name="txt_oilsumend" size="33"/>
                                </td>
                            </tr>
                            <tr>
                                <td>操控评分：</td>
                                <td>
                                开始：<input type="text" id="txt_caozuostartstart" name="txt_caozuostartstart" size="33"/><br />
                                结束：<input type="text" id="txt_caozuostarend" name="txt_caozuostarend" size="33"/>
                                </td>
                            </tr>
                            <tr>
                                <td>操控评价：</td>
                                <td>
                                开始：<input type="text" id="txt_caozuosumstart" name="txt_caozuosumstart" size="33"/><br />
                                结束：<input type="text" id="txt_caozuosumend" name="txt_caozuosumend" size="33"/>
                                </td>
                            </tr>
                            <tr>
                                <td>性价比评分：</td>
                                <td>
                                开始：<input type="text" id="txt_coststarstart" name="txt_coststarstart" size="33"/><br />
                                结束：<input type="text" id="txt_costend" name="txt_costend" size="33"/>
                                </td>
                            </tr>
                            <tr>
                                <td>性价比评价：</td>
                                <td>
                                开始：<input type="text" id="txt_costsumstart" name="txt_costsumstart" size="33"/><br />
                                结束：<input type="text" id="txt_costsumend" name="txt_costsumend" size="33"/>
                                </td>
                            </tr>
                            <tr>
                                <td>动力评分：</td>
                                <td>
                                开始：<input type="text" id="txt_powerstarstart" name="txt_powerstarstart" size="33"/><br />
                                结束：<input type="text" id="txt_powerstarend" name="txt_powerstarend" size="33"/>
                                </td>
                            </tr>
                            <tr>
                                <td>动力评价：</td>
                                <td>
                                开始：<input type="text" id="txt_powersumstart" name="txt_powersumstart" size="33"/><br />
                                结束：<input type="text" id="txt_powersumend" name="txt_powersumend" size="33"/>
                                </td>
                            </tr>
                            <tr>
                                <td>配置评分：</td>
                                <td>
                                开始：<input type="text" id="txt_configstarstart" name="txt_configstarstart" size="33"/><br />
                                结束：<input type="text" id="txt_configstarend" name="txt_configstarend" size="33"/>
                                </td>
                            </tr>
                            <tr>
                                <td>配置评价：</td>
                                <td>
                                开始：<input type="text" id="txt_configsumstart" name="txt_configsumstart" size="33"/><br />
                                结束：<input type="text" id="txt_configsumend" name="txt_configsumend" size="33"/>
                                </td>
                            </tr>
                            <tr>
                                <td>舒适度评分：</td>
                                <td>
                                开始：<input type="text" id="txt_comfortstarstart" name="txt_comfortstarstart" size="33"/><br />
                                结束：<input type="text" id="txt_comfortstarend" name="txt_comfortstarend" size="33"/>
                                </td>
                            </tr>
                            <tr>
                                <td>舒适度评价</td>
                                <td>
                                开始：<input type="text" id="txt_comfortsumstart" name="txt_comfortsumstart" size="33"/><br />
                                结束：<input type="text" id="txt_comfortsumend" name="txt_comfortsumend" size="33"/>
                                </td>
                            </tr>
                            <tr>
                                <td>空间评分：</td>
                                <td>
                                开始：<input type="text" id="txt_spacestarstart" name="txt_spacestarstart" size="33"/><br />
                                结束：<input type="text" id="txt_spacestarend" name="txt_spacestarend" size="33"/>
                                </td>
                            </tr>
                            <tr>
                                <td>空间评价：</td>
                                <td>
                                开始：<input type="text" id="txt_spacesumstart" name="txt_spacesumstart" size="33"/><br />
                                结束：<input type="text" id="txt_spacesumend" name="txt_spacesumend" size="33"/>
                                </td>
                            </tr>
                            <tr>
                                <td>外观评分：</td>
                                <td>
                                开始：<input type="text" id="txt_apprsstarstart" name="txt_apprsstarstart" size="33"/><br />
                                结束：<input type="text" id="txt_apprsstarend" name="txt_apprsstarend" size="33"/>
                                </td>
                            </tr>
                            <tr>
                                <td>外观评价：</td>
                                <td>
                                开始：<input type="text" id="txt_apprssumstart" name="txt_apprssumstart" size="33"/><br />
                                结束：<input type="text" id="txt_apprssumend" name="txt_apprssumend" size="33"/>
                                </td>
                            </tr>
                            <tr>
                                <td>内饰评分：</td>
                                <td>
                                开始：<input type="text" id="txt_insidestarstart" name="txt_insidestarstart" size="33"/><br />
                                结束：<input type="text" id="txt_insidestarend" name="txt_insidestarend" size="33"/>
                                </td>
                            </tr>
                            <tr>
                                <td>内饰评价：</td>
                                <td>
                                开始：<input type="text" id="txt_insidesumstart" name="txt_insidesumstart" size="33"/><br />
                                结束：<input type="text" id="txt_insidesumend" name="txt_insidesumend" size="33"/>
                                </td>
                            </tr>
                            <tr>
                                <td>综合评分:</td>
                                <td>
                                开始：<input type="text" id="txt_allstarstart" name="txt_allstarstart" size="33"/><br />
                                结束：<input type="text" id="txt_allstarend" name="txt_allstarend" size="33"/>
                                </td>
                            </tr>
                            <tr>
                                <td>综合评价：</td>
                                <td>
                                开始：<input type="text" id="txt_allsumstart" name="txt_allsumstart" size="33"/><br />
                                结束：<input type="text" id="txt_allsumend" name="txt_allsumend" size="33"/>
                                </td>
                            </tr>
                            <tr>
                                <td>微口碑总评分：</td>
                                <td>
                                开始：<input type="text" id="txt_wallstarstart" name="txt_wallstarstart" size="33"/><br />
                                结束：<input type="text" id="txt_wallstarend" name="txt_wallstarend" size="33"/>
                                </td>
                            </tr>
                            <tr>
                                <td>微口碑总评价：</td>
                                <td>
                                开始：<input type="text" id="txt_wallsumstart" name="txt_wallsumstart" size="33"/><br />
                                结束：<input type="text" id="txt_wallsumend" name="txt_wallsumend" size="33"/>
                                </td>
                            </tr>
                            <tr>
                                <td><input type="submit" id="sub_cont" value="内容预览" /></td>
                                <td>
                                <input type="button" id="btn_save" value="保存保存配置" />
                            </td>
                </tr>
                        </table>   
                       </div>                 
                    </div>
                </form>

            </div>
        </div>
<script src="../js/jquery-1.7.2.min.js" type="text/javascript"></script>
<script src="../js/brand.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        bind();

        $("#btn_list_cj").click(function () {
            $.ajax({
                url: "../ajax/edit_config.ashx",
                data: {
                
                }
            });

        });

        $("#btn_save").click(function () {
            $.ajax({
                url: "../ajax/edit_config.ashx",
                data: {
                    //
                    id: "0", //更改
                    rgname: $("#txt_RGname").val(),
                    series: $("#dd_series").val(),
                    source: $("#txt_source").val(),
                    uid: "9527", //更改


                    //list
                    txt_seedurl: $("#txt_seedurl").val(),
                    tr_liststart: $("#tr_liststart").val(),
                    tr_listend: $("#tr_listend").val(),
                    tr_userstart: $("#tr_userstart").val(),
                    tr_userend: $("#tr_userend").val(),
                    txt_carstart: $("#txt_carstart").val(),
                    txt_carend: $("#txt_carend").val(),
                    txt_urlstart: $("#txt_urlstart").val(),
                    txt_urlend: $("#txt_urlend").val(),
                    txt_titlestart: $("#txt_titlestart").val(),
                    txt_titleend: $("#txt_titleend").val(),
                    //content
                    txt_cont_url: $("#txt_cont_url").val(),

                    txt_Ccarstart: $("#txt_Ccarstart").val(),
                    txt_Ccarend: $("#txt_Ccarend").val(),

                    txt_Ctitlestart: $("#txt_Ctitlestart").val(),
                    txt_Ctitleend: $("#txt_Ctitleend").val(),

                    txt_Ctypestart: $("#txt_Ctypestart").val(),
                    txt_Ctypeend: $("#txt_Ctypeend").val(),

                    txt_Cdatestart: $("#txt_Cdatestart").val(),
                    txt_Cdateend: $("#txt_Cdateend").val(),

                    txt_Caddstart: $("#txt_Caddstart").val(),
                    txt_Caddend: $("#txt_Caddend").val(),

                    txt_Cpricestart: $("#txt_Cpricestart").val(),
                    txt_Cprieceend: $("#txt_Cprieceend").val(),

                    txt_oilstart: $("#txt_oilstart").val(),
                    txt_oilend: $("#txt_oilend").val(),

                    txt_oilstarstart: $("#txt_oilstarstart").val(),
                    txt_oilstarend: $("#txt_oilstarend").val(),

                    txt_oilsumstart: $("#txt_oilsumstart").val(),
                    txt_oilsumend: $("#txt_oilsumend").val(),

                    txt_caozuostartstart: $("#txt_caozuostartstart").val(),
                    txt_caozuostarend: $("#txt_caozuostarend").val(),

                    txt_caozuosumstart: $("#txt_caozuosumstart").val(),
                    txt_caozuosumend: $("#txt_caozuosumend").val(),

                    txt_coststarstart: $("#txt_coststarstart").val(),
                    txt_costend: $("#txt_costend").val(),

                    txt_costsumstart: $("#txt_costsumstart").val(),
                    txt_costsumend: $("#txt_costsumend").val(),

                    txt_powerstarstart: $("#txt_powerstarstart").val(),
                    txt_powerstarend: $("#txt_powerstarend").val(),

                    txt_powersumstart: $("#txt_powersumstart").val(),
                    txt_powersumend: $("#txt_powersumend").val(),

                    txt_configstarstart: $("#txt_configstarstart").val(),
                    txt_configstarend: $("#txt_configstarend").val(),

                    txt_configsumstart: $("#txt_configsumstart").val(),
                    txt_configsumend: $("#txt_configsumend").val(),

                    txt_comfortstarstart: $("#txt_comfortstarstart").val(),
                    txt_comfortstarend: $("#txt_comfortstarend").val(),

                    txt_comfortsumstart: $("#txt_comfortsumstart").val(),
                    txt_comfortsumend: $("#txt_comfortsumend").val(),

                    txt_spacestarstart: $("#txt_spacestarstart").val(),
                    txt_spacestarend: $("#txt_spacestarend").val(),

                    txt_spacesumstart: $("#txt_spacesumstart").val(),
                    txt_spacesumend: $("#txt_spacesumend").val(),

                    txt_apprsstarstart: $("#txt_apprsstarstart").val(),
                    txt_apprsstarend: $("#txt_apprsstarend").val(),

                    txt_apprssumstart: $("#txt_apprssumstart").val(),
                    txt_apprssumend: $("#txt_apprssumend").val(),

                    txt_insidestarstart: $("#txt_insidestarstart").val(),
                    txt_insidestarend: $("#txt_insidestarend").val(),

                    txt_insidesumstart: $("#txt_insidesumstart").val(),
                    txt_insidesumend: $("#txt_insidesumend").val(),

                    txt_allstarstart: $("#txt_allstarstart").val(),
                    txt_allstarend: $("#txt_allstarend").val(),


                    txt_allsumstart: $("#txt_allsumstart").val(),
                    txt_allsumend: $("#txt_allsumend").val(),

                    txt_wallstarstart: $("#txt_wallstarstart").val(),
                    txt_wallstarend: $("#txt_wallstarend").val(),

                    txt_wallsumstart: $("#txt_wallsumstart").val(),
                    txt_wallsumend: $("#txt_wallsumend").val()

                },
                type: "POST",
                success: function (result) {
                    alert(result);
                }
            });
        });

    });
</script>
</body>
</html>
