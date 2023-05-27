<%@ Page Title="Test" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="WebApplication1.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <div>
            <asp:Button ID="testBtn" runat="server" Text="Test" OnClick="TestClick" />
            <br />
            <asp:Label ID="test" runat="server"></asp:Label>
        </div>
    </main>
</asp:Content>
