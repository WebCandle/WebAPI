<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAPI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-4">
            <h2>GET</h2>
            <h5>URI</h5>
            <asp:TextBox ID="txtURIGet" runat="server"></asp:TextBox>
            <h5>Parameters</h5>
            <asp:TextBox ID="txtParametersGet" runat="server"></asp:TextBox>
            <asp:Button ID="btnGetSend" OnClick="btnGetSend_Click" CssClass="btn btn-default" runat="server" Text="Button" />
            <h5>Response</h5>
            <asp:TextBox ID="txtResponseGet" Wrap="true" runat="server" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <h2>POST</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>PUT</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
