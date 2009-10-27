<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.SquadronLogViewModel>" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%= Html.ActionLink("Back to flight log summary ...", MVC.FlightLogs.EditMissionLog(Model.MissionLogId)) %>
    </p>
    <h1>Add a flight log squadron member</h1>
    <% using (Html.BeginForm(MVC.FlightLogs.CreateSquadronLog(Model.MissionLogId), FormMethod.Post, new { @class = "standard-form" })) { %>
        <% Html.RenderPartial("SquadronLogForm"); %>
        <div class="button-group">
            <input type="submit" value="Add new flight log squadron member" />
            <input type="reset" value="Reset" />
        </div>
    <% } %>
</asp:Content>