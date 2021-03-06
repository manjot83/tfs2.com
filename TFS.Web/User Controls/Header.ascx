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
        <a href="https://mail.google.com" class="highlight" target="_blank">Email</a> |
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Security/ChangePassword" Text="Change Password" CssClass="highlight" /> |
        <asp:HyperLink ID="PayrollLink" runat="server" NavigateUrl="~/Billing/default.aspx" Text="My Timecards" /> |        
        <asp:HyperLink ID="LogoffLink" runat="server" NavigateUrl="~/Security/LogOff" Text="Log Off" CssClass="highlight" /> |        
      </div>
      
    </div>