<%@ Page MasterPageFile="~/default.master" Title="New Category" ValidateRequest="false" Language="C#" AutoEventWireup="true" Inherits="NewCat" Codebehind="newcat.aspx.cs" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <asp:ObjectDataSource
        ID="CategoryDataSource" 
        runat="server" 
        TypeName="TFS.OpCenter.Data.ArticlecategoryController"
        InsertMethod="Insert">
    </asp:ObjectDataSource>
    

    
    <asp:FormView ID="NewCatForm" runat="server" DataSourceID="CategoryDataSource" DefaultMode="Insert" Width="600px" OnItemInserted="Item_Inserted">
        <InsertItemTemplate>
            <p>
                <div class="left"><asp:Label runat="server" ID="label1" Text="Name" /></div>
                <div class="right"><asp:TextBox ID="name" runat="server" Text='<%# Bind("name", "{0}") %>' Width="300" /></div>
            </p>
            <p>
                <div class="left"><asp:Label runat="server" ID="label2" Text="Description" /></div>
                <div class="right"><asp:TextBox ID="description" runat="server" Text='<%# Bind("description", "{0}") %>' Width="300" /></div>
            </p>                
            <asp:Button CommandName="Insert" ID="AddCategoryButton" runat="server" Text="Add Category" />
            <asp:Button OnClick="Reset" ID="ResetButton" runat="server" Text="Reset" />
        </InsertItemTemplate>
    </asp:FormView>
        
   </asp:Content>