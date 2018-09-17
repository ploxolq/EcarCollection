<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Content.aspx.cs" Inherits="SpaderGet.page.Content" %>

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
    <div class="layout">
        <div class="header">
            <ul class="nav">
                <li><a href="#">所有配置</a></li>
                <li><a href="#">新增配置</a></li>
            </ul>
        </div>
        <div class="content">
            <div class="Contbox">
            </div>
        </div>
    </div>
</body>
</html>
