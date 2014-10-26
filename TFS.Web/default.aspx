<%@ Page MasterPageFile="~/default.master" Language="C#" AutoEventWireup="true" Inherits="main_Default" Codebehind="Default.aspx.cs" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
          
    <h1 style="background: #DB0000; color:White; font-weight: bolder;">TFS Hot Items</h1>    
    <asp:Repeater ID="HotItems" runat="server" EnableViewState="false">
        <HeaderTemplate>
            <p>
        </HeaderTemplate>
        <ItemTemplate>
            <a href='ViewArticle.aspx?id=<%# Eval("id") %>'><%# Eval("subject") %></a>
            <br />
        </ItemTemplate>
        <FooterTemplate>
            </p>
        </FooterTemplate>
    </asp:Repeater>                                     
     
    <h1>Latest TFS News</h1>            
    <p><a href="NewsAdmin/Default.aspx">Manage News</a></p>                 
    <asp:Repeater ID="NewsEntries" runat="server" EnableViewState="false">
        <HeaderTemplate>
            <p>
        </HeaderTemplate>
        <ItemTemplate>            
            <a href='ViewArticle.aspx?id=<%# Eval("id") %>'><%# Eval("subject") %></a>
            <span runat="server" class="hotitem" visible='<%# Eval("isurgent") %>'>Hot Item</span>
            <br />
        </ItemTemplate>        
        <FooterTemplate>
            </p>
        </FooterTemplate>
    </asp:Repeater>

    <h1>TFS Help Articles</h1>
    <asp:Repeater ID="HelpEntries" runat="server" EnableViewState="false">
        <HeaderTemplate>
            <p>
        </HeaderTemplate>
        <ItemTemplate>
            <a href='ViewHelpArticle.aspx?id=<%# Eval("id") %>'><%# Eval("subject") %></a>
            <br />
        </ItemTemplate>
        <FooterTemplate>
            </p>
        </FooterTemplate>
    </asp:Repeater>
     
</asp:Content>