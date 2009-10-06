<%@ Page MasterPageFile="~/default.master" Title="New Post" ValidateRequest="false" Language="C#" AutoEventWireup="true" Inherits="help_admin_newpost" Codebehind="newpost.aspx.cs" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <asp:ObjectDataSource
        ID="HelpArticleDataSource" 
        runat="server" 
        TypeName="TFS.OpCenter.Data.HelparticleController"
        InsertMethod="Insert">
    </asp:ObjectDataSource>
    
    <asp:FormView ID="NewPostForm" runat="server" DataSourceID="HelpArticleDataSource" DefaultMode="Insert" Width="600px" OnItemInserted="Item_Inserted" OnItemInserting="Item_Inserting">
        <InsertItemTemplate>
            <p>
            </p>
                <div class="left"><asp:Label runat="server" ID="label1" Text="Date" /></div>
                <div class="right"><asp:TextBox ID="postdate" runat="server" Text='<%# Bind("createdon", "{0}") %>' Width="300" /></div>
            <p>
            </p>
            <p>
            </p>
                <div class="left"><asp:Label runat="server" ID="label3" Text="Subject" /></div>
                <div class="right"><asp:TextBox ID="subject" runat="server" Text='<%# Bind("subject", "{0}") %>' Width="300" /></div>
            <p>
            </p>
            <p>
            </p>
                <div class="left"><asp:Label runat="server" ID="label4" Text="Content (Markdown)" /></div>
                <div class="right"><asp:TextBox ID="content" runat="server" Text='<%# Bind("content", "{0}") %>' TextMode="MultiLine" Width="500" Height="300" /></div>
            <p>
            </p>
            <asp:Button CommandName="Insert" ID="AddPostButton" runat="server" Text="Add Post" />
            <asp:Button OnClick="Reset" ID="ResetButton" runat="server" Text="Reset" />
        </InsertItemTemplate>
    </asp:FormView>
        
</asp:Content>