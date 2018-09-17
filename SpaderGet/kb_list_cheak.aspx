<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kb_list_cheak.aspx.cs" Inherits="SpaderGet.kb_list_cheak" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .list_01{width:400px;height:75px;}
    </style>
</head>
<body>
    <div class="list_01">
        <div><strong>你是欢喜的年少</strong></div>
        <div><a style="float:left;">喜欢的少年是你</a><a style="float:right;">审查</a></div>
    </div>
    <asp:Repeater ID="Check_List" runat="server">
        <ItemTemplate>
            <div class="list_01">
                <div><strong><%# Eval("Car")%></strong></div>
                <div><a style="float:left;" href="<%#Eval("Url") %>"><%# Eval("Titile")%></a><a style="float:right;" href="kb_Release.aspx?url=<%# Eval("Url") %>&series=<%# Eval("Series")%>">审查</a></div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</body>
</html>
