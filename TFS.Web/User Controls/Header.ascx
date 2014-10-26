<%@ Control Language="C#" AutoEventWireup="true" Inherits="User_Controls_Header" Codebehind="Header.ascx.cs" EnableViewState="false" %>
           
    <div id="header">
    
      <div class="superHeader">
        <div class="right">
          <span class="doNotDisplay">More related sites:</span>
          | <a href="http://tacticalflightservices.com">tacticalflightservices.com</a> |
        </div>          
      </div>

      <div class="midHeader">        
        <table width="100%">
            <tr>            
            <td align="left"><span class="headerTitle">Tactical Flight Services</span></td>
            <td align="right"><span class="headerTitle">Operations Center</span></td>
            </tr>
        </table>        
      </div>

      <div class="subHeader">
        <span class="doNotDisplay">Navigation:</span>        
        | <asp:HyperLink ID="IntranetLink" runat="server" NavigateUrl="~" Text="Intranet Home" /> |
        <a href="http://tacticalflightservices.com" class="highlight">TFS Home</a> |
        <a href="#" class="highlight" onclick="alert('TODO: add link to email'); return false;">Email</a> |
        <a href="#" class="highlight" onclick="alert('TODO: add link to change password'); return false;">Change Password</a> |
        <asp:HyperLink ID="PayrollLink" runat="server" NavigateUrl="~/Billing/default.aspx" Text="My Timecards" /> |        
        <a href="~Security/LogOff" class="highlight">Log Off</a> |
      </div>
      
    </div>