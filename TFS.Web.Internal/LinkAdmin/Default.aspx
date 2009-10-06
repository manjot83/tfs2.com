<%@ Page MasterPageFile="~/default.master" Language="C#" AutoEventWireup="true" Inherits="link_admin_Default" Codebehind="Default.aspx.cs" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <asp:ObjectDataSource
        ID="LinkDataSource" 
        runat="server" 
        TypeName="TFS.OpCenter.Data.ExternallinkController"
        SelectMethod="FetchAllNotDeleted">
    </asp:ObjectDataSource>
        
    <p>
    You can use this interface to add/remove links to external websites.<br />
    Links are always listed in alphabetical order.
    </p>    
    <p>
        <a href="newlink.aspx" title="Create a New Post">New Link</a>&nbsp;&nbsp;&nbsp;
    </p>
    
    <a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
    <h1 id="H1_2">Edit Links</h1>            
    <table>
    <tr>
        <td><span style="font-weight:bold;">Remove</span></td>
        <td><span style="font-weight:bold;">Edit</span></td>
        <td><span style="font-weight:bold;">Link Name</span></td>
        <td><span style="font-weight:bold;">Link URL</span></td>
    </tr>
    <asp:Repeater ID="LinkRepeater" runat="server" DataSourceID="LinkDataSource">
        <ItemTemplate>
        <tr>
            <td><a href='removelink.aspx?id=<%# Eval("id") %>' onclick="return confirm('Are you sure you want to delete?');">Remove</a></td>
            <td><a href='editlink.aspx?id=<%# Eval("id") %>'>Edit</a></td>
            <td><%# Eval("name") %></td>
            <td><%# Eval("navurl") %></td>
        </tr>
        </ItemTemplate>
    </asp:Repeater>
    </table>

</asp:Content>