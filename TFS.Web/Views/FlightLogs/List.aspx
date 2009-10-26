<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.SortedListViewModel<TFS.Models.FlightLogs.MissionLog>>" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h1>Flight Time Summaries</h1>
    <p>
        Click the date to edit, or <b><%= Html.ActionLink("Create", MVC.FlightLogs.CreateMissionLog())%></b> a new one.
    </p>
    <table class="list-table">
        <thead>
            <tr>
                <th>
                <% if (Model.IsCurrentSortType("date")) { %>
                    <%= Html.ActionLink("Date", MVC.FlightLogs.List("date", Model.GetReverseSortDirection()), new { @class = Model.SortDirectionClass("sorted-down", "sorted-up") })%>
                <% } else { %>
                    <%= Html.ActionLink("Date", MVC.FlightLogs.List("date", SortDirection.Ascending))%>
                <% } %>
                </th>
                <th>
                <% if (Model.IsCurrentSortType("aircraft")) { %>
                    <%= Html.ActionLink("Aircraft", MVC.FlightLogs.List("aircraft", Model.GetReverseSortDirection()), new { @class = Model.SortDirectionClass("sorted-down", "sorted-up") })%>
                <% } else { %>
                    <%= Html.ActionLink("Aircraft", MVC.FlightLogs.List("aircraft", SortDirection.Ascending))%>
                <% } %>                    
                </th>
                <th>
                <% if (Model.IsCurrentSortType("location")) { %>
                    <%= Html.ActionLink("Location", MVC.FlightLogs.List("location", Model.GetReverseSortDirection()), new { @class = Model.SortDirectionClass("sorted-down", "sorted-up") })%>
                <% } else { %>
                    <%= Html.ActionLink("Location", MVC.FlightLogs.List("location", SortDirection.Ascending))%>
                <% } %>
                </th>
            </tr>
        </thead>
        <% foreach (var log in Model.Items) { %>
        <tr>
            <td>
                <%= Html.ActionLink(log.LogDate.ToShortDateString(), MVC.FlightLogs.EditMissionLog(log.Id.Value)) %>
            </td>
            <td>
                <%= Html.Encode(log.AircraftMDS + " : " + log.AircraftSerialNumber)%>
            </td>
            <td>
                <%= Html.Encode(log.Location) %>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
