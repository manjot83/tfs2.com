<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<SuccessViewModel>" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
	Success
</asp:Content>

<asp:Content ContentPlaceHolderID="StyleSheet" runat="server">
<%= Html.StylesheetsFor(Tags.CSS_INTERNAL_BASE) %>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <p>This action was completed successfully.</p>
    <% using(Html.BeginForm(Model.RedirectRoute, FormMethod.Get)) { %>
        <p>
            <input type="submit" value="Click to continue" />
        </p>
    <% } %>
</asp:Content>
