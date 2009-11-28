<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.FlightPrograms.PositionViewModel>" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
Add new position
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="header-main">Add a new position</div>
    <fieldset class="standard-form">
        <legend>Position</legend>
        <% using (Html.BeginForm(MVC.FlightPrograms.CreatePosition(), FormMethod.Post, new { @class = "fieldset-content" })) { %>
            <% Html.RenderPartial(MVC.FlightPrograms.Views.PositionTitle); %>
            <div class="button-group">
                <input type="submit" value="Add new position" />
                <input type="reset" value="Reset" />
            </div>
        <% } %>
    </fieldset>
</asp:Content>