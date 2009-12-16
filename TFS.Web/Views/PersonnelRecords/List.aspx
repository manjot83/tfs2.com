<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.SortedListViewModel<TFS.Web.ViewModels.PersonnelRecords.PersonnelRecordListViewModel>>" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
Personnel Records
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="header-main">Personnel Records</div>
    <p class="instructions">Below is a list of all active users.</p>
    <ul class="instructions">
        <li>Click on the person's name to see and edit their personnel record.</li>
        <li>Sort by status to find people with missing key information (key information includes SSN, date of birth, and contact information).</li>
        <li>Click to download as a <b><%= Html.ActionLink("CSV", MVC.PersonnelRecords.DownloadAllAsCsv()) %></b> for Excel.</li>
    </ul>
    <div class="list-table-pager">
        <% if (Model.HasPreviousPage()) { %>
            <span><%= Html.ActionLink("« prev", MVC.PersonnelRecords.List(Model.SortType, Model.SortDirection, Model.PreviousPage(), Model.ItemsPerPage))%></span>
        <% } %>
        <span>Page <%= Html.Encode(Model.CurrentPage) %> of <%= Html.Encode(Model.TotalPages) %></span>
        <% if (Model.HasNextPage()) { %>
            <span><%= Html.ActionLink("next »", MVC.PersonnelRecords.List(Model.SortType, Model.SortDirection, Model.NextPage(), Model.ItemsPerPage))%></span>
        <% } %>
    </div>
    <table class="list-table">
        <thead>
            <tr>
                <th>
                <% if (Model.IsCurrentSortType("name")) { %>
                    <%= Html.ActionLink("Name", MVC.PersonnelRecords.List("name", Model.GetReverseSortDirection(), Model.CurrentPage, Model.ItemsPerPage), new { @class = Model.IsSortedAscending() ? "sorted-down" : "sorted-up" })%>
                <% } else { %>
                    <%= Html.ActionLink("Name", MVC.PersonnelRecords.List("name", SortDirection.Ascending, Model.CurrentPage, Model.ItemsPerPage)) %>
                <% } %>
                </th>
                <th>
                <% if (Model.IsCurrentSortType("status")) { %>
                    <%= Html.ActionLink("Status", MVC.PersonnelRecords.List("status", Model.GetReverseSortDirection(), Model.CurrentPage, Model.ItemsPerPage), new { @class = Model.IsSortedAscending() ? "sorted-down" : "sorted-up" })%>
                <% } else { %>
                    <%= Html.ActionLink("Status", MVC.PersonnelRecords.List("status", SortDirection.Ascending, Model.CurrentPage, Model.ItemsPerPage))%>
                <% } %>
                </th>
            </tr>
        </thead>
        <% foreach (var user in Model.Items) { %>
        <tr>
            <td>
                <%= Html.ActionLink(user.FileByName, MVC.PersonnelRecords.EditRecord(user.Username))%>
            </td>
            <td>
                <%= Html.Encode(user.Status) %>
            </td>
        </tr>
        <% } %>
    </table>
    <div class="list-table-pager">
        <% if (Model.HasPreviousPage()) { %>
            <span><%= Html.ActionLink("« prev", MVC.PersonnelRecords.List(Model.SortType, Model.SortDirection, Model.PreviousPage(), Model.ItemsPerPage))%></span>
        <% } %>
        <span>Page <%= Html.Encode(Model.CurrentPage) %> of <%= Html.Encode(Model.TotalPages) %></span>
        <% if (Model.HasNextPage()) { %>
            <span><%= Html.ActionLink("next »", MVC.PersonnelRecords.List(Model.SortType, Model.SortDirection, Model.NextPage(), Model.ItemsPerPage))%></span>
        <% } %>
        <div>
            <% using(Html.BeginForm(MVC.PersonnelRecords.List(Model.SortType, Model.SortDirection, Model.CurrentPage, Model.ItemsPerPage), FormMethod.Get)) { %>
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