<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.MissionViewModel>" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%= Html.ActionLink("Back to flight log summary ...", MVC.FlightLogs.EditFlightLog(Model.FlightLogId))%>
    </p>
    <div class="header-main">Edit flight log mission</div>
    <fieldset class="standard-form">
        <legend>Mission Info</legend>
        <% using (Html.BeginForm(MVC.FlightLogs.EditMission(Model.Mission.Id.Value), FormMethod.Post, new { @class = "fieldset-content" })) { %>
            <% Html.RenderPartial(MVC.FlightLogs.Views.MissionForm); %>
            <div class="button-group">
                <input type="submit" value="Save changes" />
                <input type="reset" value="Reset" />
            </div>
        <% } %>
    </fieldset>
</asp:Content>