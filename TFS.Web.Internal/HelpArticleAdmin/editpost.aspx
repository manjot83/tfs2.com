<%@ Page MasterPageFile="~/default.master" Title="Edit Post" ValidateRequest="false" Language="C#" AutoEventWireup="true" Inherits="HelpEditPost" Codebehind="editpost.aspx.cs" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">


    <asp:ObjectDataSource
        ID="HelpArticleDataSource" 
        runat="server" 
        TypeName="TFS.OpCenter.Data.HelparticleController"
        UpdateMethod="Update"
        SelectMethod="FetchById"
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
    
    <asp:FormView ID="EditPostForm" runat="server" DataSourceID="HelpArticleDataSource" DefaultMode="Edit" Width="600px" OnItemUpdated="Item_Updated" OnItemUpdating="Item_Updating" OnItemDeleted="Item_Deleted">
        <EditItemTemplate>
            <p>
                <div class="left"><asp:Label runat="server" ID="label1" Text="Date" /></div>
                <div class="right"><asp:TextBox ID="postdate" runat="server" Text='<%# Bind("createdon", "{0}") %>' Width="300" ReadOnly="true" /></div>
            </p>
            <p>
                <div class="left"><asp:Label runat="server" ID="label3" Text="Subject" /></div>
                <div class="right"><asp:TextBox ID="subject" runat="server" Text='<%# Bind("subject", "{0}") %>' Width="300" /></div>
            </p>
            <p>
                <div class="left"><asp:Label runat="server" ID="label4" Text="Content (Markdown)" /></div>
                <div class="right"><asp:TextBox ID="content" runat="server" Text='<%# Bind("content", "{0}") %>' TextMode="MultiLine" Width="500" Height="300" /></div>
            </p>
            <asp:Button CommandName="update" ID="UpdateButton" runat="server" Text="Update Post" />                
            <asp:Button CommandName="delete" ID="DeleteButton" runat="server" Text="Delete" />
            <asp:Button OnClick="Cancel" ID="CancelButton" runat="server" Text="Cancel" />            
        </EditItemTemplate>
    </asp:FormView>
        
 </asp:Content>