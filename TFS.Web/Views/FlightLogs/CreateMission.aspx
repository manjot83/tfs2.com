<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.FlightLogs.MissionViewModel>" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
Create Mission
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%= Html.ActionLink("Back to flight log summary ...", MVC.FlightLogs.EditFlightLog(Model.FlightLogId.Value))%>
    </p>
    <div class="header-main">Add a flight log mission</div>
    <fieldset class="standard-form">
        <legend>Mission Info</legend>
        <% using (Html.BeginForm(MVC.FlightLogs.CreateMission(Model.FlightLogId.Value), FormMethod.Post, new { @class = "fieldset-content" })) { %>
            <% Html.RenderPartial(MVC.FlightLogs.Views.MissionForm); %>
            <div class="button-group">
                <input type="submit" value="Add new flight log mission" />
                <input type="reset" value="Reset" />
            </div>
        <% } %>
    </fieldset>
</asp:Content>