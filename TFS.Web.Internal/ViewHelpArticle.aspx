<%@ Page Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" Inherits="view_help_article" Codebehind="ViewHelpArticle.aspx.cs" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <asp:ObjectDataSource
        ID="HelpArticleDataSource" 
        runat="server" 
        TypeName="TFS.OpCenter.Data.HelparticleController"
        SelectMethod="FetchById">
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="id" Name="id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:Repeater ID="BlogRepeater" runat="server" DataSourceID="HelpArticleDataSource">
            <ItemTemplate>
                <a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
                <h1 id="H1_1"><%# Eval("subject") %>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;<%# Eval("createdon") %></h1>
                <%# Process_Markdown(Eval("content").ToString()) %>
            </ItemTemplate>
    </asp:Repeater>

</asp:Content>