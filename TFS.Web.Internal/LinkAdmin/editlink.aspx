<%@ Page MasterPageFile="~/default.master" ValidateRequest="false" Language="C#" AutoEventWireup="true" Inherits="EditLink" Codebehind="editlink.aspx.cs" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <asp:ObjectDataSource 
        ID="LinkDataSource"
        runat="server"
        TypeName="TFS.OpCenter.Data.ExternallinkController"
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
    

    <asp:FormView ID="EditLinkForm" runat="server" DataSourceID="LinkDataSource" DefaultMode="Edit" Width="600px" OnItemUpdated="Item_Updated" OnItemDeleted="Item_Deleted">
        <EditItemTemplate>
            <p>
                <div class="left"><asp:Label runat="server" ID="label1" Text="Link Name" /></div>
                <div class="right"><asp:TextBox ID="name" runat="server" Text='<%# Bind("name", "{0}") %>' Width="300" /></div>
            </p>
            <p>
                <div class="left"><asp:Label runat="server" ID="label2" Text="Link URL" /></div>
                <div class="right"><asp:TextBox ID="description" runat="server" Text='<%# Bind("navurl", "{0}") %>' Width="300" /></div>
            </p>                
            <asp:Button CommandName="update" ID="UpdateButton" runat="server" Text="Update Link" />                
            <asp:Button CommandName="delete" ID="DeleteButton" runat="server" Text="Delete" />
            <asp:Button OnClick="Cancel" ID="CancelButton" runat="server" Text="Cancel" />
        </EditItemTemplate>
    </asp:FormView>
        
    

</asp:Content>