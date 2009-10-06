<%@ Page Language="C#" MasterPageFile="~/default.master" Title="Help Article Admin" AutoEventWireup="true" Inherits="help_admin_Default" Codebehind="Default.aspx.cs" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <asp:ObjectDataSource
        ID="HelpArticleDataSource" 
        runat="server" 
        TypeName="TFS.OpCenter.Data.HelparticleController"
        SelectMethod="FetchAll">
    </asp:ObjectDataSource>

    <p>
    You can use this interface to edit Help Articles.
    </p>    
    <p>
        <a href="newpost.aspx" title="Create a New Post">New Article</a>
    </p>
    

    <a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
    <h1 id="H1_1">Edit Articles</h1>            
    <table>
    <tr>
        <td><span style="font-weight:bold;">Article</span></td>
        <td><span style="font-weight:bold;">Subject</span></td>
        <td><span style="font-weight:bold;">Date</span></td>
        <td><span style="font-weight:bold;">Author</span></td>
    </tr>
    <asp:Repeater ID="HelpArticles" runat="server" DataSourceID="HelpArticleDataSource">
        <ItemTemplate>
            <tr>
                <td><%# Eval("id") %></td>
                <td><a href='editpost.aspx?id=<%# Eval("id") %>'><%# Eval("subject") %></a></td>
                <td><%# Eval("createdon") %></td>                    
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    </table>
</asp:Content>