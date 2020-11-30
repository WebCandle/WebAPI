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
            <asp:UpdatePanel ID="UPnl" runat="server">
                <ContentTemplate>
                    <div id="MyChat"></div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Timer ID="Tmr" runat="server" Interval="1000" OnTick="Tmr_Tick"></asp:Timer>
        </div>
    </form>
</body>
</html>
