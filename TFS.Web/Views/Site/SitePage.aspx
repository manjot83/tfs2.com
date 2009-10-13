<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Models.Site.Page>" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
    <%= Html.Encode(Model.Title) %>
</asp:Content>

<asp:Content ContentPlaceHolderID="HeaderContent" runat="server">
    <%= Html.ImageContent("~/Content/public/headers/"+Model.HeaderFileName, "Header") %>
</asp:Content>

<asp:Content ContentPlaceHolderID="NavContent" runat="server">  
    <a href="<%= Url.Action(MVC.Site.Home()) %>" class="rollover_home"></a>
    <a href="<%= Url.Action(MVC.Site.Services()) %>" class="rollover_services"></a>
    <a href="<%= Url.Action(MVC.Site.Programs()) %>" class="rollover_programs"></a>
    <a href="<%= Url.Action(MVC.Site.Experience()) %>" class="rollover_experience"></a>
    <a href="<%= Url.Action(MVC.Security.LogOn()) %>" class="rollover_logon"></a>
    <a href="<%= Url.Action(MVC.Site.Contact()) %>" class="rollover_contact"></a>    
    
</asp:Content>

<asp:Content ContentPlaceHolderID="BannerContent" runat="server">
    <%= Html.ImageContent("~/Content/public/banners/"+Model.BannerFileName, "Banner") %>
</asp:Content>

<asp:Content ContentPlaceHolderID="ImageStripContent" runat="server">
</asp:Content>

<asp:Content ContentPlaceHolderID="BodyContent" runat="server">
    <%= Html.Markdown(Model.Content) %>
</asp:Content>
