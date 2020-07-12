<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WebAppTest.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增客戶資料</title>
</head>
<body>
    <p>新增客戶資料</p>
    <a href="Default.aspx">回首頁</a> 
    <form id="form1" runat="server">
        <div>
            <p>Customer ID</p>
            <asp:TextBox ID="customerid" Text="" runat="server" />
            <p>Last Name</p>
            <asp:TextBox ID="last_name" Text="" runat="server" />
            <p>First Name</p>
            <asp:TextBox ID="first_name" Text="" runat="server" />
            <p>Address</p>
            <asp:TextBox ID="address" Text="" runat="server" />
            <p>Email</p>
            <asp:TextBox ID="email" Text="" runat="server" />
            <asp:Button ID="registerButton" Text="Add" runat="server" OnClick="registerEventMethod" />
            <asp:Button ID="Button1" Text="Update" runat="server" OnClick="updaterEventMethod" />
            <asp:Button ID="Button2" Text="Delete" runat="server" OnClick="deleteEventMethod" />
            <asp:PlaceHolder ID="placeholder2" runat="server" />
        </div>
    </form>
</body>
</html>
