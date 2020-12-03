<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChatView.aspx.cs" Inherits="WebAPI.Views.ChatView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>         
            <div><asp:Label ID="lblChatRoom" runat="server"></asp:Label></div>
            <div><asp:GridView ID="GWChat" runat="server"></asp:GridView></div>
            <div>
                <asp:TextBox ID="TxtMessage" runat="server" Rows="4" TextMode="MultiLine"></asp:TextBox>
                <asp:Button ID="BtnSend" OnClick="BtnSend_Click" runat="server" Text="Send" CssClass="btn btn-primary" />
                <asp:Button ID="btnLoadChat" runat="server" Text="Load Chat" OnClick="btnLoadChat_Click" />
            </div>
        </div>
    </form>
</body>
</html>
