<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="WebAppTest.Update" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <h1>
        <center>更改資料</center>
    </h1>
    <form id="form1" runat="server">
        <div>
            <center>
            <table border ='1'>
            <tr><th>Last Name</th><th>First Name</th><th>Address</th><th>Email</th></tr>
            <tr>
            <td><center><asp:TextBox ID='last_name' runat='server' /></center></td>
            <td><center><asp:TextBox ID='first_name' runat='server' /></center></td>
            <td><center><asp:TextBox ID='address' runat='server' /></center></td>
            <td><center><asp:TextBox ID='email' runat='server' /></center></td>
            </tr>
            </table>
            <asp:Button ID="updateButton" Text="儲存" runat="server" OnClick="updateEventMethod" />
            <br />
            <asp:PlaceHolder ID="placeholder2" runat="server" />
            </center>
        </div>
    </form>
</body>
</html>
