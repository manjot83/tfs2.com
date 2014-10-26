<%@ Page MasterPageFile="~/default.master" Title="Edit Category" ValidateRequest="false" Language="C#" AutoEventWireup="true" Inherits="EditCat" Codebehind="editcat.aspx.cs" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <asp:ObjectDataSource
        ID="CategoryDataSource" 
        runat="server" 
        TypeName="TFS.OpCenter.Data.ArticlecategoryController"
        SelectMethod="FetchById"
        UpdateMethod="Update"
        DeleteMethod="Delete">
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="id" Name="id" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:QueryStringParameter QueryStringField="id" Name="id" Type="Int32" />
        </UpdateParameters>
        <DeleteParameters>
            <asp:QueryStringParameter QueryStringField="id" Name="id" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>
    
    <asp:FormView ID="NewCatForm" runat="server" DataSourceID="CategoryDataSource" DefaultMode="Edit" Width="600px" OnItemUpdated="Item_Updated" OnItemDeleted="Item_Deleted">
        <EditItemTemplate>
            <p>
                <div class="left"><asp:Label runat="server" ID="label1" Text="Name" /></div>
                <div class="right"><asp:TextBox ID="name" runat="server" Text='<%# Bind("name", "{0}") %>' Width="300" /></div>
            </p>
            <p>
                <div class="left"><asp:Label runat="server" ID="label2" Text="Description" /></div>
                <div class="right"><asp:TextBox ID="description" runat="server" Text='<%# Bind("description", "{0}") %>' Width="300" /></div>
            </p>                
            <asp:Button CommandName="update" ID="UpdateButton" runat="server" Text="Update Category" />                
            <asp:Button CommandName="delete" ID="DeleteButton" runat="server" Text="Delete" />
            <asp:Button OnClick="Cancel" ID="CancelButton" runat="server" Text="Cancel" />
        </EditItemTemplate>
    </asp:FormView>
        
  </asp:Content>