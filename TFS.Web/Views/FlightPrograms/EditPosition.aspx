<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.FlightPrograms.PositionViewModel>" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
Rename position
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="header-main">Rename position</div>
    <p>
        <span class="warning">Warning: Renaming a position will also change existing references to that position.</span>
    </p>
    <fieldset class="standard-form">
        <legend>Position</legend>
        <% using (Html.BeginForm(MVC.FlightPrograms.RenamePosition(), FormMethod.Post, new { @class = "fieldset-content" })) { %>
            <%= Html.Hidden("Id", Model.Id.Value) %>
            <% Html.RenderPartial(MVC.FlightPrograms.Views.PositionTitle); %>
            <div class="button-group">
                <input type="submit" value="Rename" />
                <input type="reset" value="Reset" />
            </div>
        <% } %>
    </fieldset>
</asp:Content>