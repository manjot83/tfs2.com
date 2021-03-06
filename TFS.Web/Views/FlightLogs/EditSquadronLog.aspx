<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.FlightLogs.SquadronLogViewModel>" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
Edit Squadron Log
</asp:Content>

<asp:Content ContentPlaceHolderID="Javascript" runat="server">
    <%= Html.JavaScriptsFor(Tags.JS_JQUERY) %>
    <script type="text/javascript">
        $(function() {
            var deleteButton = $("#deleteSquadronLog");
            if (deleteButton.length) {
                deleteButton.click(function() {
                    if (confirm("Are you sure you want to delete this squadron log?")) {
                        _post('<%= Url.Action(MVC.FlightLogs.DeleteSquadronLog()) %>', { id: '<%= Model.Id.ToString() %>' });
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
    <div class="header-main">Edit flight log squadron member</div>
    <fieldset class="standard-form">
        <legend>Squadron Member</legend>
        <% using (Html.BeginForm(MVC.FlightLogs.EditSquadronLog(Model.Id.Value), FormMethod.Post, new { @class = "fieldset-content" })) { %>
            <% Html.RenderPartial(MVC.FlightLogs.Views.SquadronLogForm); %>
            <div class="button-group">
                <input type="submit" value="Save changes" />
                <input type="reset" value="Reset" />
                <% if (Model.IsFlightLogManager) { %>
                <input type="button" value="Delete" id="deleteSquadronLog" />
                <% } %>
            </div>
        <% } %>
    </fieldset>
</asp:Content>