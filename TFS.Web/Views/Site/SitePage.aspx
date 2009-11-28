<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Models.Site.Page>" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
    <%= Html.Encode(Model.Title) %>
</asp:Content>

<asp:Content ContentPlaceHolderID="HeaderContent" runat="server">
    <%= Html.ImageContent("~/Content/public/headers/"+Model.HeaderFileName, "Header") %>
</asp:Content>

<asp:Content ContentPlaceHolderID="BannerContent" runat="server">
    <%= Html.ImageContent("~/Content/public/banners/"+Model.BannerFileName, "Banner") %>
</asp:Content>

<asp:Content ContentPlaceHolderID="ImageStripContent" runat="server">
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <%= Html.Markdown(Model.Content) %>
</asp:Content>
