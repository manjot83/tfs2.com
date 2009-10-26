<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.MissionViewModel>" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%= Html.ActionLink("Back to flight log summary ...", MVC.FlightLogs.EditMissionLog(Model.MissionLogId)) %>
    </p>
    <h1>Create a flight log mission</h1>
    <% using (Html.BeginForm(MVC.FlightLogs.CreateMission(Model.MissionLogId), FormMethod.Post, new { @class = "standard-form" })) { %>
        <% Html.RenderPartial("MissionForm"); %>
        <div class="button-group">
            <input type="submit" value="Create new flight log mission" />
            <input type="reset" value="Reset" />
        </div>
    <% } %>
</asp:Content>