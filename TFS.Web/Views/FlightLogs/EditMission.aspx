<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.FlightLogs.MissionViewModel>" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
Edit Mission
</asp:Content>

<asp:Content ContentPlaceHolderID="Javascript" runat="server">
    <%= Html.JavaScriptsFor(Tags.JS_JQUERY) %>
    <script type="text/javascript">
        $(function() {
            var deleteButton = $("#deleteMission");
            if (deleteButton.length) {
                deleteButton.click(function() {
                    if (confirm("Are you sure you want to delete this mission?")) {
                        _post('<%= Url.Action(MVC.FlightLogs.DeleteMission()) %>', { id: '<%= Model.Id.ToString() %>' });
                    }
                    return false;
                });
            }
        });

        /* Quick and Dirty Form Posting */
        var _post = function(url, params) {
            var form = document.createElement("form");
            form.action = url;
            form.method = "POST";
            form.style.display = "none";
            for (var x in params) {
                var opt = document.createElement("textarea");
                opt.name = x;
                opt.value = params[x];
                form.appendChild(opt);
            }
            document.body.appendChild(form);
            form.submit();
            return form;
        }
    </script>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%= Html.ActionLink("Back to flight log summary ...", MVC.FlightLogs.EditFlightLog(Model.FlightLogId.Value))%>
    </p>
    <div class="header-main">Edit flight log mission</div>
    <fieldset class="standard-form">
        <legend>Mission Info</legend>
        <% using (Html.BeginForm(MVC.FlightLogs.EditMission(Model.Id.Value), FormMethod.Post, new { @class = "fieldset-content" })) { %>
            <% Html.RenderPartial(MVC.FlightLogs.Views.MissionForm); %>
            <div class="button-group">
                <input type="submit" value="Save changes" />
                <input type="reset" value="Reset" />
                <% if (Model.IsFlightLogManager) { %>
                <input type="button" value="Delete" id="deleteMission" />
                <% } %>
            </div>
        <% } %>
    </fieldset>
</asp:Content>