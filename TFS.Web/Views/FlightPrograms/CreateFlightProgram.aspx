<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.FlightPrograms.FlightProgramViewModel>" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
	Add Flight Program
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="header-main">Add a new flight program</div>
    <fieldset class="standard-form">
        <legend>Flight Program Information</legend>
        <% using (Html.BeginForm(MVC.FlightPrograms.CreateFlightProgram(), FormMethod.Post, new { @class = "fieldset-content" })) { %>
            <% Html.RenderPartial(MVC.FlightPrograms.Views.FlightProgramInfo); %>
            <div class="button-group">
                <input type="submit" value="Add flight program" />
                <input type="reset" value="Reset" />
            </div>
        <% } %>
    </fieldset>
</asp:Content>