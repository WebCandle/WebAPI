<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChatView.aspx.cs" Inherits="WebAPI.Views.ChatView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div><asp:Label ID="lblChatRoom" runat="server"></asp:Label></div>
                   <asp:GridView ID="GWChat" runat="server">
                        
                    </asp:GridView>
            <div>
                <asp:TextBox ID="TxtMessage" runat="server" Rows="4" TextMode="MultiLine"></asp:TextBox>
                <asp:Button ID="BtnSend" OnClick="BtnSend_Click" runat="server" Text="Send" CssClass="btn btn-primary" />
            </div>
        </div>
    </form>
</body>
</html>
