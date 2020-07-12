<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAppTest.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>客戶管理系統</title>
</head>
<body>
    <h1>
        <center>客戶管理系統</center>
    </h1>
    <form id="form1" runat="server">
        <div>
            <center>
            <asp:PlaceHolder ID="placeholder" runat="server" />
            <br />
            <b>Last Name</b>
            <asp:TextBox ID="last_name" Text="" runat="server" />
            <b>First Name</b>
            <asp:TextBox ID="first_name" Text="" runat="server" />
            <b>Address</b>
            <asp:TextBox ID="address" Text="" runat="server" />
            <b>Email</b>
            <asp:TextBox ID="email" Text="" runat="server" />
            <br />
            <br />
            <asp:Button ID="registerButton" Text="新增" runat="server" OnClick="registerEventMethod" />
            <br />
            <asp:PlaceHolder ID="placeholder2" runat="server" />
            </center>
        </div>
    </form>
</body>
</html>
