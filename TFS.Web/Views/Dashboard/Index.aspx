<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
Dashboard
</asp:Content>

<asp:Content ContentPlaceHolderID="StyleSheet" runat="server">
<%= Html.StylesheetsFor(Tags.CSS_INTERNAL_BASE) %>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="header-main">Select options from the left.</div>
</asp:Content>