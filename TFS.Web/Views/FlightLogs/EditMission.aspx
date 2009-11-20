<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.MissionViewModel>" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%= Html.ActionLink("Back to flight log summary ...", MVC.FlightLogs.EditFlightLog(Model.FlightLogId))%>
    </p>
    <h1>Edit flight log mission</h1>
    <% using (Html.BeginForm(MVC.FlightLogs.EditMission(Model.Mission.Id.Value), FormMethod.Post, new { @class = "standard-form" })) { %>
        <% Html.RenderPartial(MVC.FlightLogs.Views.MissionForm); %>
        <div class="button-group">
            <input type="submit" value="Save changes" />
            <input type="reset" value="Reset" />
        </div>
    <% } %>
</asp:Content>