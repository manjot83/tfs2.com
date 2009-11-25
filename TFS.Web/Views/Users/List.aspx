<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.SortedListViewModel<TFS.Web.ViewModels.UserViewModel>>" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="header-main">Users</div>
    <p>
        Click the user's name to edit, or <%= Html.ActionLink("Create", MVC.Users.Create()) %> a new one.
    </p>
    <div class="list-table-pager">
        <% if (Model.HasPreviousPage()) { %>
            <span><%= Html.ActionLink("« prev", MVC.Users.List(Model.SortType, Model.SortDirection, Model.PreviousPage(), Model.ItemsPerPage))%></span>
        <% } %>
        <span>Page <%= Html.Encode(Model.CurrentPage) %> of <%= Html.Encode(Model.TotalPages) %></span>
        <% if (Model.HasNextPage()) { %>
            <span><%= Html.ActionLink("next »", MVC.Users.List(Model.SortType, Model.SortDirection, Model.NextPage(), Model.ItemsPerPage))%></span>
        <% } %>
    </div>
    <table class="list-table">
        <thead>
            <tr>
                <th>
                <% if (Model.IsCurrentSortType("name")) { %>
                    <%= Html.ActionLink("Name", MVC.Users.List("name", Model.GetReverseSortDirection(), Model.CurrentPage, Model.ItemsPerPage), new { @class = Model.IsSortedAscending() ? "sorted-down" : "sorted-up" })%>
                <% } else { %>
                    <%= Html.ActionLink("Name", MVC.Users.List("name", SortDirection.Ascending, Model.CurrentPage, Model.ItemsPerPage))%>
                <% } %>
                </th>
                <th>
                <% if (Model.IsCurrentSortType("username")) { %>
                    <%= Html.ActionLink("Username", MVC.Users.List("username", Model.GetReverseSortDirection(), Model.CurrentPage, Model.ItemsPerPage), new { @class = Model.IsSortedAscending() ? "sorted-down" : "sorted-up" })%>
                <% } else { %>
                    <%= Html.ActionLink("Username", MVC.Users.List("username", SortDirection.Ascending, Model.CurrentPage, Model.ItemsPerPage))%>
                <% } %>                    
                </th>
                <th>
                <% if (Model.IsCurrentSortType("email")) { %>
                    <%= Html.ActionLink("Email Address", MVC.Users.List("email", Model.GetReverseSortDirection(), Model.CurrentPage, Model.ItemsPerPage), new { @class = Model.IsSortedAscending() ? "sorted-down" : "sorted-up" })%>
                <% } else { %>
                    <%= Html.ActionLink("Email Address", MVC.Users.List("email", SortDirection.Ascending, Model.CurrentPage, Model.ItemsPerPage))%>
                <% } %>
                </th>
                <th>
                <% if (Model.IsCurrentSortType("status")) { %>
                    <%= Html.ActionLink("Status", MVC.Users.List("status", Model.GetReverseSortDirection(), Model.CurrentPage, Model.ItemsPerPage), new { @class = Model.IsSortedAscending() ? "sorted-down" : "sorted-up" })%>
                <% } else { %>
                    <%= Html.ActionLink("Status", MVC.Users.List("status", SortDirection.Ascending, Model.CurrentPage, Model.ItemsPerPage))%>
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
    <div class="list-table-pager">
        <% if (Model.HasPreviousPage()) { %>
            <span><%= Html.ActionLink("« prev", MVC.Users.List(Model.SortType, Model.SortDirection, Model.PreviousPage(), Model.ItemsPerPage))%></span>
        <% } %>
        <span>Page <%= Html.Encode(Model.CurrentPage) %> of <%= Html.Encode(Model.TotalPages) %></span>
        <% if (Model.HasNextPage()) { %>
            <span><%= Html.ActionLink("next »", MVC.Users.List(Model.SortType, Model.SortDirection, Model.NextPage(), Model.ItemsPerPage))%></span>
        <% } %>
        <div>
            <% using(Html.BeginForm(MVC.Users.List(Model.SortType, Model.SortDirection, Model.CurrentPage, Model.ItemsPerPage), FormMethod.Get)) { %>
            <select name="itemsPerPage">
                <option value="10" <%= Model.ItemsPerPage == 10 ? "selected=\"selected\"" : null %>>Show 10 items per page</option>
                <option value="20" <%= Model.ItemsPerPage == 20 ? "selected=\"selected\"" : null %>>Show 20 items per page</option>
                <option value="40" <%= Model.ItemsPerPage == 40 ? "selected=\"selected\"" : null %>>Show 40 items per page</option>
                <option value="80" <%= Model.ItemsPerPage == 80 ? "selected=\"selected\"" : null %>>Show 80 items per page</option>                
            </select>
            <input type="submit" value="Change" />
            <% } %>
        </div>
    </div>
</asp:Content>
