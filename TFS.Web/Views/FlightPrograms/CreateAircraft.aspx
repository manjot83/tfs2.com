<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.FlightPrograms.AircraftViewModel>" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
Add new position
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="header-main">Add a new aircraft</div>
    <fieldset class="standard-form">
        <legend>Aircraft</legend>
        <% using (Html.BeginForm(MVC.FlightPrograms.CreateAircraft(), FormMethod.Post, new { @class = "fieldset-content" })) { %>
            <% Html.RenderPartial(MVC.FlightPrograms.Views.AircraftName); %>
            <div class="button-group">
                <input type="submit" value="Add new aircraft" />
                <input type="reset" value="Reset" />
            </div>
        <% } %>
    </fieldset>
</asp:Content>