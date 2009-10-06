<%@ Page MasterPageFile="~/default.master" Language="C#" AutoEventWireup="true" Inherits="view_article" Codebehind="ViewArticle.aspx.cs" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <asp:ObjectDataSource
        ID="NewsDataSource" 
        runat="server" 
        TypeName="TFS.OpCenter.Data.NewspostController"
        SelectMethod="FetchById">
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="id" Name="id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>  
    
    <asp:HiddenField ID="postnumber" runat="server" />

    <asp:Repeater ID="BlogRepeater" runat="server" DataSourceID="NewsDataSource">
        <ItemTemplate>
            <a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
            <h1 id="H1_1"><%# Eval("subject") %>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;<%# Eval("createdon") %> by <%# Eval("Person.DisplayName") %></h1>
            <%# Process_Markdown(Eval("content").ToString()) %>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>