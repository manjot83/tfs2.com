<%@ Page MasterPageFile="~/default.master" Title="Edit Post" ValidateRequest="false" Language="C#" AutoEventWireup="true" Inherits="EditPost" Codebehind="editpost.aspx.cs" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <asp:ObjectDataSource
        ID="NewsDataSource" 
        runat="server" 
        TypeName="TFS.OpCenter.Data.NewspostController"
        SelectMethod="FetchById"
        UpdateMethod="Update"
        DeleteMethod="Delete">
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="id" Name="id" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:QueryStringParameter QueryStringField="id" Name="id" Type="Int32" />
            <asp:Parameter Name="isurgent" DefaultValue="false" Type="Boolean" />
        </UpdateParameters>
        <DeleteParameters>
            <asp:QueryStringParameter QueryStringField="id" Name="id" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>
    
    <asp:ObjectDataSource
        ID="CategoryDataSource" 
        runat="server" 
        TypeName="TFS.OpCenter.Data.ArticlecategoryController"
        SelectMethod="FetchAll">
    </asp:ObjectDataSource>    
    
    <asp:FormView ID="EditPostForm" runat="server" DataSourceID="NewsDataSource" DefaultMode="Edit" Width="600px" OnItemUpdated="Item_Updated" OnItemUpdating="Item_Updating" OnItemDeleted="Item_Deleted">
        <EditItemTemplate>
            <p>
                <div class="left"><asp:Label runat="server" ID="label1" Text="Date" /></div>
                <div class="right"><asp:TextBox ID="postdate" runat="server" Text='<%# Bind("createdon", "{0}") %>' Width="300" ReadOnly="true" /></div>
            </p>
            <p>
                <div class="left"><asp:Label runat="server" ID="label5" Text="User" /></div>
                <div class="right"><asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Person.DisplayName", "{0}") %>' Width="300" ReadOnly="true" /></div>
            </p>
            <p>
                <div class="left"><asp:Label runat="server" ID="label2" Text="Category" /></div>                    
                <div class="right">
                    <asp:DropDownList ID="CategorySelectBox" runat="server" 
                    DataSourceID="CategoryDataSource" 
                    DataTextField="name" 
                    DataValueField="id" 
                    SelectedValue='<%# Bind("categoryID") %>'
                    Width="306">
                    </asp:DropDownList>                          
                </div>
            </p>
            <p>
                <div class="left"><asp:Label runat="server" ID="label3" Text="Subject" /></div>
                <div class="right"><asp:TextBox ID="subject" runat="server" Text='<%# Bind("subject", "{0}") %>' Width="300" /></div>
            </p>
            <p>
                <div class="left"><asp:Label runat="server" ID="label4" Text="Content (Markdown)" /></div>
                <div class="right"><asp:TextBox ID="content" runat="server" Text='<%# Bind("content", "{0}") %>' TextMode="MultiLine" Width="500" Height="300" /></div>
            </p>
            <p>
                <asp:CheckBox ID="IsUrgentCheckbox" runat="server" Checked='<%# Bind("Isurgent") %>' Text="Hot Item" />
            </p>
            <asp:Button CommandName="update" ID="UpdateButton" runat="server" Text="Update Post" />                
            <asp:Button CommandName="delete" ID="DeleteButton" runat="server" Text="Delete" />
            <asp:Button OnClick="Cancel" ID="CancelButton" runat="server" Text="Cancel" />            
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>