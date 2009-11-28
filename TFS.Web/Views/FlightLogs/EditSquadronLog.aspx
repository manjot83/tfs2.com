<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.FlightLogs.SquadronLogViewModel>" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
Edit Squadron Log
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%= Html.ActionLink("Back to flight log summary ...", MVC.FlightLogs.EditFlightLog(Model.FlightLogId.Value))%>
    </p>
    <div class="header-main">Edit flight log squadron member</div>
    <fieldset class="standard-form">
        <legend>Squadron Member</legend>
        <% using (Html.BeginForm(MVC.FlightLogs.EditSquadronLog(Model.Id.Value), FormMethod.Post, new { @class = "fieldset-content" })) { %>
            <% Html.RenderPartial(MVC.FlightLogs.Views.SquadronLogForm); %>
            <div class="button-group">
                <input type="submit" value="Save changes" />
                <input type="reset" value="Reset" />
            </div>
        <% } %>
    </fieldset>
</asp:Content>