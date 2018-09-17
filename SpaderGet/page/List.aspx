<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="SpaderGet.page.List" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <style type="text/css">
            ul li span a{margin:0;padding:0;}
            *{margin:0 auto;padding: 0px;list-style: none;}
            li{float: left; }
            a{text-decoration:none;color:Black;}           
            .nav{ list-style:none;float:left;display:block;margin-left:20px;}
            .nav li{float:left;width:100px;height:50px; line-height:50px;}
            .nav li a { color:#fff}
            .layout{width: 100%;height: 700px;margin:auto;      }
            .header{width: 1000px;height: 50px;margin:auto;background:rgba(0,0,0,0.8);}
            .content {width: 1000px;height: 500px;margin:auto;}
            .Contbox{ width:900px;height:100%;margin:auto;}
            .minibox{width:900px;height:50px;float:left; border:1px #456;display:block;margin:auto 5px ;}
            .mini_0{width:350px;height:48px;float:left; text-align:center; border-left:1px solid #000;border-top:1px solid #000;border-bottom:1px solid #000;line-height: 50px;}
            .mini_1{width:400px;height:48px;float:left;text-align:center;border:1px solid #000;text-align: center;line-height: 50px;  }
            .mini_2{width:65px;height:48px;float:left; text-align:center; border-right:1px solid #000;border-top:1px solid #000;border-bottom:1px solid #000;line-height: 50px;}
            .mini_3{width:200px;height:48px;float:left; text-align:center;border-right:1px solid #000;border-top:1px solid #000;border-bottom:1px solid #000;line-height: 50px;}
            .mini_7{width:350px;height:48px;float:left; text-align:center; border-left:1px solid #000;border-bottom:1px solid #000;line-height: 50px;}
            .mini_4{width:400px;height:48px;float:left;text-align:center;text-align: center;line-height: 50px; border-left:1px solid #000;border-right:1px solid #000;border-bottom:1px solid #000; }
            .mini_5{width:65px;height:48px;float:left; text-align:center; border-right:1px solid #000;border-bottom:1px solid #000;line-height: 50px;}
            .mini_6{width:200px;height:48px;float:left; text-align:center;border-right:1px solid #000;border-bottom:1px solid #000;line-height: 50px;}
     </style>

</head>
<body>
    <div class="layout">
        <div class="header">
            <ul class="nav">
                <li><a href="#">所有配置</a></li>
                <li><a href="#">新增配置</a></li>
            </ul>
        </div>
        <div class="content">
            <div class="Contbox">
                <div class="minibox">
                    <ul>
                    <li class="mini_0">车型</li>
                    <li class="mini_1">标题</li>
                    <li class="mini_2">处理</li>
                    <li class="mini_2">删除</li>
                    </ul>
                    <asp:Repeater ID="rep_list" runat="server">
                        <ItemTemplate>
                        <ul>
                            <li class="mini_7"><%#Eval("Car")%></li>
                            <li class="mini_4"><a href=<%#Eval("Url") %>"><%#Eval("Url") %><%#Eval("Titile")%></a></li>
                            <li class="mini_5">处理</li>
                            <li class="mini_5">删除</li>
                        </ul>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>
            </div>
        </div>
    </div>
</body>
</html>
