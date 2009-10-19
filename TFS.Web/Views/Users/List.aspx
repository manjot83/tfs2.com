<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.SortedListViewModel<TFS.Models.User>>" %>

<asp:Content ContentPlaceHolderID="AdditionalStyleSheets" runat="server">
    <link type="text/css" rel="stylesheet" href="<%= Url.Content("~/Content/internal/list-table.css") %>" />
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h1>Users</h1>
    <p>
        Click the user's name to edit, or <%= Html.ActionLink("Create", MVC.Users.Create()) %> a new one.
    </p>
    <table class="list-table">
        <thead>
            <tr>
                <th>
                <% if (Model.IsCurrentSortType("name")) { %>
                    <%= Html.ActionLink("Name", MVC.Users.List("name", Model.GetReverseSortDirection()), new { @class = Model.IsSortedAscending() ? "sorted-down" : "sorted-up" })%>
                <% } else { %>
                    <%= Html.ActionLink("Name", MVC.Users.List("name", SortDirection.Ascending)) %>
                <% } %>
                </th>
                <th>
                <% if (Model.IsCurrentSortType("username")) { %>
                    <%= Html.ActionLink("Username", MVC.Users.List("username", Model.GetReverseSortDirection()), new { @class = Model.IsSortedAscending() ? "sorted-down" : "sorted-up" })%>
                <% } else { %>
                    <%= Html.ActionLink("Username", MVC.Users.List("username", SortDirection.Ascending))%>
                <% } %>                    
                </th>
                <th>
                <% if (Model.IsCurrentSortType("email")) { %>
                    <%= Html.ActionLink("Email Address", MVC.Users.List("email", Model.GetReverseSortDirection()), new { @class = Model.IsSortedAscending() ? "sorted-down" : "sorted-up" })%>
                <% } else { %>
                    <%= Html.ActionLink("Email Address", MVC.Users.List("email", SortDirection.Ascending))%>
                <% } %>
                </th>
                <th>
                <% if (Model.IsCurrentSortType("status")) { %>
                    <%= Html.ActionLink("Status", MVC.Users.List("status", Model.GetReverseSortDirection()), new { @class = Model.IsSortedAscending() ? "sorted-down" : "sorted-up" })%>
                <% } else { %>
                    <%= Html.ActionLink("Status", MVC.Users.List("status", SortDirection.Ascending))%>
                <% } %>
                </th>
            </tr>
        </thead>
        <% foreach (var user in Model.Items) { %>
        <tr>
            <td>
                <%= Html.ActionLink(user.LastName + ", " +user.FirstName, MVC.Users.Edit(user.Username)) %>
            </td>
            <td>
                <%= Html.Encode(user.Username) %>
            </td>
            <td>
                <%= Html.Encode(user.Email) %>
            </td>
            <td>
                <%= !user.Disabled ? "Active" : "Disabled" %>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
