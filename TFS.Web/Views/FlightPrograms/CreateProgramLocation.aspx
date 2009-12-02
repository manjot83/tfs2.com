<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.FlightPrograms.ProgramLocationViewModel>" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
	Add Program Location
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%= Html.ActionLink("Back to flight program...", MVC.FlightPrograms.EditFlightProgram(Model.ProgramId))%>
    </p>
    <div class="header-main">Add a new program location for "<%= Html.Encode(Model.ProgramName) %>"</div>
    <fieldset class="standard-form">
        <legend>Location</legend>
        <% using (Html.BeginForm(MVC.FlightPrograms.CreateProgramLocation(), FormMethod.Post, new { @class = "fieldset-content" })) { %>
            <%= Html.Hidden("ProgramId", Model.ProgramId) %>
            <% Html.RenderPartial(MVC.FlightPrograms.Views.ProgramLocationInfo); %>
            <div class="button-group">
                <input type="submit" value="Add new location" />
                <input type="reset" value="Reset" />
            </div>
        <% } %>
    </fieldset>
</asp:Content>