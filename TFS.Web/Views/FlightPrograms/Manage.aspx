<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.FlightPrograms.DashboardViewModel>" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
    Flight Programs
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="header-main">Flight Programs</div>
    <p>
        <% if (Model.ShowAllPrograms) { %>
        Current showing <u>ALL</u> flight programs. Click to show only <%= Html.ActionLink("ACTIVE", MVC.FlightPrograms.Manage(false)) %> flight programs.
        <% } else { %>
        Current showing only <u>ACTIVE</u> flight programs. Click to show <%= Html.ActionLink("ALL", MVC.FlightPrograms.Manage(true)) %> flight programs.
        <% } %>
    </p>
    <p>
        Click on the program name to edit.
    </p>
    <% using(Html.BeginForm(MVC.FlightPrograms.CreateFlightProgram(), FormMethod.Get)) { %>
        <p>
            <input type="submit" value="Add a new flight program" />
        </p>
    <% } %>
    <table class="list-table">
        <thead>
            <tr>
                <th>
                    Program Name
                </th>
                <th>
                    Account Name
                </th>
                <th>
                    Num. Of Location
                </th>
                <th>
                    Status
                </th>                
            </tr>
        </thead>
        <% foreach (var program in Model.SortedFlightPrograms) { %>
        <tr>
            <td>
                <%= Html.ActionLink(program.Name, MVC.FlightPrograms.EditFlightProgram(program.Id.Value)) %>
            </td>
            <td>
                <%= Html.Encode(program.AccountName) %>
            </td>
            <td>
                <%= Html.Encode(program.LocationsCount.ToString()) %>
            </td>
            <td>
                <%= Html.Encode(program.GetStatus()) %>
            </td>
        </tr>
        <% } %>
    </table>
    <hr />
    <div class="header-main">Positions</div>
    <p>
        Click on the position title to rename.
    </p>
    <% using(Html.BeginForm(MVC.FlightPrograms.CreatePosition(), FormMethod.Get)) { %>
        <p>
            <input type="submit" value="Add a new position" />
        </p>
    <% } %>
    <table class="list-table">
        <thead>
            <tr>
                <th>
                    Title
                </th>             
            </tr>
        </thead>
        <% foreach (var position in Model.SortedPositions) { %>
        <tr>
            <td>
                <%= Html.ActionLink(position.Title, MVC.FlightPrograms.RenamePosition(position.Id.Value))%>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
