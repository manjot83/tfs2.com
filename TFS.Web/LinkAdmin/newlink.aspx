<%@ Page MasterPageFile="~/default.master" Title="New Link" ValidateRequest="false"
    Language="C#" AutoEventWireup="true" Inherits="NewLink" CodeBehind="newlink.aspx.cs" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <asp:ObjectDataSource 
        ID="LinkDataSource"
        runat="server"
        TypeName="TFS.OpCenter.Data.ExternallinkController"
        InsertMethod="Insert">
    </asp:ObjectDataSource>
    
    <asp:FormView ID="NewCatForm" runat="server" DataSourceID="LinkDataSource" DefaultMode="Insert"
        Width="600px" OnItemInserted="Item_Inserted">
        <InsertItemTemplate>
            <p>
                <div class="left">
                    <asp:Label runat="server" ID="label1" Text="Link Name" /></div>
                <div class="right">
                    <asp:TextBox ID="name" runat="server" Text='<%# Bind("name", "{0}") %>' Width="300" /></div>
            </p>
            <p>
                <div class="left">
                    <asp:Label runat="server" ID="label2" Text="URL" /></div>
                <div class="right">
                    <asp:TextBox ID="navurl" runat="server" Text='<%# Bind("navurl", "{0}") %>' Width="300" /></div>
            </p>
            <asp:Button CommandName="Insert" ID="AddLinkButton" runat="server" Text="Add Link" />
            <asp:Button OnClick="Reset" ID="ResetButton" runat="server" Text="Reset" />
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
