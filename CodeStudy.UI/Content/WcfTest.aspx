﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WcfTest.aspx.cs" Inherits="CodeStudy.UI.Content.WcfTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
    <asp:Button ID="btnSubmit" runat="server" Text="测试WCF服务" OnClick="btnClick" />
    </form>
</body>
</html>
 