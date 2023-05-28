<%@ Page Title="Test" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="WebApplication1.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <div>
            <h2>Image Gallery</h2>
            <asp:FileUpload ID="fileUpload" runat="server" />
            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
            <br />
            <asp:Label ID="lblFilter" runat="server" Text="Filter by:"></asp:Label>
            <asp:DropDownList ID="ddlFilter" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFilter_SelectedIndexChanged">
                <asp:ListItem Text="All" Value="0" />
                <asp:ListItem Text="Landscape" Value="1" />
                <asp:ListItem Text="Portrait" Value="2" />
            </asp:DropDownList>
            <br />
            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" EmptyDataText="No images found">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:ImageField DataImageUrlField="ImagePath" HeaderText="Image" ControlStyle-Width="200" ControlStyle-Height="150" />
                </Columns>
            </asp:GridView>
        </div>
    </main>
</asp:Content>
