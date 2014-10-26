<%@ Page Language="C#" MasterPageFile="~/default.master" Title="News Admin" AutoEventWireup="true" Inherits="news_admin_Default" Codebehind="Default.aspx.cs" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <asp:ObjectDataSource
        ID="CategoryDataSource" 
        runat="server" 
        TypeName="TFS.OpCenter.Data.ArticlecategoryController"
        SelectMethod="FetchAllNotDeleted">
    </asp:ObjectDataSource>
    
    <asp:ObjectDataSource
        ID="NewsDataSource" 
        runat="server" 
        TypeName="TFS.OpCenter.Data.NewspostController"
        SelectMethod="FetchAllNotDeleted">
    </asp:ObjectDataSource>    

    <p>
    You can use this interface to edit news posting or add new postings. You can also managing news categories.
    </p>    
    <p>
        <a href="newpost.aspx" title="Create a New Post">New Post</a>&nbsp;&nbsp;&nbsp;
        <a href="newcat.aspx" title="Create a New Category">New Category</a>
    </p>
    
    <a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
    <h1 id="H1_2">Edit Categories</h1>            
    <p>
    <asp:Repeater ID="CategoryRepeater" runat="server" DataSourceID="CategoryDataSource">
        <ItemTemplate>
            <a href='editcat.aspx?id=<%# Eval("id") %>'>&rsaquo; <%# Eval("name") %></a><br />
        </ItemTemplate>
    </asp:Repeater>
    </p>

    <a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
    <h1 id="H1_1">Edit Posts</h1>            
    <table>
    <tr>
        <td><span style="font-weight:bold;">&nbsp;</span></td>
        <td><span style="font-weight:bold;">&nbsp;</span></td>
        <td><span style="font-weight:bold;">Author</span></td>
        <td><span style="font-weight:bold;">Hot</span></td>
        <td><span style="font-weight:bold;">&nbsp;</span></td>
    </tr>
    <asp:Repeater ID="NewsEntries" runat="server" DataSourceID="NewsDataSource" OnItemCommand="HandleNewsItemCommand">
        <ItemTemplate>
            <tr>
                <td><a href='editpost.aspx?id=<%# Eval("id") %>'>&rsaquo; <%# Eval("subject") %></a></td>
                <td><%# Eval("Createdon") %></td>
                <td><%# Eval("Person.DisplayName") %></td>                
                <td><tfs:CommandCheckBox  ID="HotItemCheckbox" 
                                          runat="server"
                                          Checked='<%# Eval("Isurgent") %>' 
                                          AutoPostBack="true"
                                          CommandArgument='<%# Eval("id") %>'
                                          CommandName="MarkIsUrgent" /></td>
                <td><a href='#?id=<%# Eval("id") %>'>e-mail this item</a></td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    </table>
        
 </asp:Content>