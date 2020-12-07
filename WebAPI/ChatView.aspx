<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChatView.aspx.cs" Inherits="WebAPI.ChatView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ChatScriptManager" runat="server"></asp:ScriptManager>
    <asp:Timer ID="ChatTimer" runat="server" Interval="500" OnTick="ChatTimer_Tick"></asp:Timer>
        <div>         
            <div><asp:Label ID="lblChatRoom" runat="server"></asp:Label></div>
            <div>
                <asp:UpdatePanel ID="ChatUpdatePanel" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="GWChat" runat="server"></asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ChatTimer" EventName="Tick" />
                    </Triggers>
                 </asp:UpdatePanel>
            </div>
            <div>
                <div>
                    To: <asp:TextBox ID="txtEndpointTo" runat="server"></asp:TextBox>
                </div>
                <asp:TextBox ID="TxtMessage" runat="server" Rows="4" TextMode="MultiLine"></asp:TextBox>
                <asp:Button ID="BtnSend" OnClick="BtnSend_Click" runat="server" Text="Send" CssClass="btn btn-primary" />
            </div>
        </div>
    </form>
</body>
</html>
