<%@ Control Language="C#" AutoEventWireup="true" Inherits="User_Controls_Footer" Codebehind="Footer.ascx.cs" EnableViewState="false" %>
    
    <div id="footer">
      <div class="left">
      </div>

      <br class="doNotDisplay doNotPrint" />

      <div class="right">
        &copy; <%= DateTime.Now.Year %> Tactical Flight Services<br />
        Build Number: <b><%= TFS.OpCenter.Utility.GetBuildNumber() %></b><br />
      </div>
    </div>