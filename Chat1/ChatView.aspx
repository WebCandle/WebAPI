<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChatView.aspx.cs" Inherits="Chat1.ChatView" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
      <div class="container">
          <div class="row">
              <div class="col-sm-8">
    <asp:ScriptManager ID="ChatScriptManager" runat="server"></asp:ScriptManager>
    <asp:Timer ID="ChatTimer" runat="server" Interval="500" OnTick="ChatTimer_Tick"></asp:Timer>
        <div>         
            <div><asp:Label ID="lblChatRoom" runat="server"></asp:Label></div>
            <div>
                <asp:UpdatePanel ID="ChatUpdatePanel" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Pnl" runat="server"></asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ChatTimer" EventName="Tick" />
                    </Triggers>
                 </asp:UpdatePanel>
            </div>
            
        </div>
          </div>
              <div class="col-sm-4">
                  <table style="width: 100%;">
                      <tr>
                          <td>To:</td>
                          <td colspan="2"><asp:TextBox CssClass="form-control" ID="txtEndpointTo" runat="server"></asp:TextBox><br /></td>
                      </tr>
                      <tr><td colspan="3">&nbsp;</td></tr>
                      <tr>
                          <td>Sender Name:</td>
                          <td colspan="2"><asp:TextBox  CssClass="form-control" ID="txtSenderName" runat="server"></asp:TextBox></td>
                      </tr>
                      <tr><td colspan="3">&nbsp;</td></tr>
                      <tr>
                          <td colspan="3"><asp:TextBox CssClass="form-control" ID="TxtMessage" runat="server" Rows="4" TextMode="MultiLine" Width="100%"></asp:TextBox></td>
                      </tr>
                      <tr><td colspan="3">&nbsp;</td></tr>
                      <tr>
                          <td colspan="3">
                                <asp:Button ID="BtnSend" OnClick="BtnSend_Click" runat="server" Text="Send" CssClass="btn btn-primary" />
                          </td>
                      </tr>
                  </table>
                <div>
                     
                     
                </div>
                
                
            </div>
          </div>
        </div>
    </form>
</body>
</html>
