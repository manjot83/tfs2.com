<%@ Control Language="C#" AutoEventWireup="true" Inherits="User_Controls_Footer" Codebehind="Footer.ascx.cs" EnableViewState="false" %>
    
    <div id="footer">
      <div class="left">
        E-mail:&nbsp;<a href="mailto:support@tfs2.com" title="Email Support">support@tfs2.com</a><br />        
        <a href="#" class="doNotPrint">Security Information</a>
        <a href="#" class="doNotPrint">Privacy Policy</a>
      </div>

      <br class="doNotDisplay doNotPrint" />

      <div class="right">
        (c) 2008 Tactical Flight Services<br />
        Build Number: <b><%= TFS.OpCenter.Utility.GetBuildNumber() %></b><br />
      </div>
    </div>