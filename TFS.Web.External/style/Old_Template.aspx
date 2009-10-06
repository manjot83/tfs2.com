<%@ Page Language="C#" MasterPageFile="~/style/Template.master" AutoEventWireup="true"  CodeFile="Old_Template.aspx.cs" Inherits="_Template" EnableViewState="false" %>

<asp:Content ContentPlaceHolderID="HeaderContent" runat="server">
    <asp:Literal ID="PageHeader" runat="server"></asp:Literal>   
</asp:Content>

<asp:Content ContentPlaceHolderID="NavContent" runat="server">
    <a href="home.page" class="rollover_1"></a>
    <a href="services.page" class="rollover_2"></a>
    <a href="programs.page" class="rollover_3"></a>
    <a href="experience.page" class="rollover_4"></a>
    <a href="login.html" class="rollover_5"></a>
    <a href="contact.page" class="rollover_6"></a>   
</asp:Content>

<asp:Content ContentPlaceHolderID="BannerContent" runat="server">
    <asp:Literal ID="ContentBanner" runat="server" />
</asp:Content>

<asp:Content ContentPlaceHolderID="ImageStripContent" runat="server">
    <asp:Literal ID="ImageStrip" runat="server" />
</asp:Content>

<asp:Content ContentPlaceHolderID="BodyContent" runat="server">
    <asp:Literal ID="ContentBody" runat="server" />                       					
</asp:Content>
