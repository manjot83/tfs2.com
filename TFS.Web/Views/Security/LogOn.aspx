<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
	Tactical Flight Services - Log On
</asp:Content>

<asp:Content  ContentPlaceHolderID="HeaderContent" runat="server">
    <%= Html.ImageContent("~/Content/public/headers/header04.jpg", "header", new { width="768", height="224"}) %>
</asp:Content>

<asp:Content ContentPlaceHolderID="BannerContent" runat="server">
    <%= Html.ImageContent("~/Content/public/banners/aircrew_login.gif", "banner", new { width="505", height="42"}) %>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="474">
      <tr>
       <td><img src="../../Content/public/login/spacer.gif" width="34" height="1" border="0" alt="" /></td>
       <td><img src="../../Content/public/login/spacer.gif" width="400" height="1" border="0" alt="" /></td>
       <td><img src="../../Content/public/login/spacer.gif" width="40" height="1" border="0" alt="" /></td>
       <td><img src="../../Content/public/login/spacer.gif" width="1" height="1" border="0" alt="" /></td>
      </tr>

      <tr>
       <td colspan="3"><img name="loginlayout_r1_c1" src="../../Content/public/login/loginlayout_r1_c1.jpg" width="474" height="1" border="0" alt=""></td>
       <td><img src="../../Content/public/login/spacer.gif" width="1" height="1" border="0" alt=""></td>
      </tr>
      <tr>
       <td colspan="3"><img name="loginlayout_r2_c1" src="../../Content/public/login/loginlayout_r2_c1.jpg" width="474" height="29" border="0" alt=""></td>
       <td><img src="../../Content/public/login/spacer.gif" width="1" height="29" border="0" alt=""></td>
      </tr>
      <tr>
       <td>
       
       <img name="loginlayout_r3_c1" src="../../Content/public/login/loginlayout_r3_c1.jpg" width="34" height="250" border="0" alt=""></td>
       <td bgcolor="#E8EBEA">
        <% using (Html.BeginForm())
           { %>
		    <div align="center"><font size="1">&nbsp;</font><table border="0" width="90%" cellspacing="0" cellpadding="2">
			    <tr>
				                  <td width="99" class="boldbodycopy"><p><b>Callsign:</b></p></td>
				    <td><input type="text" name="username" size="36"></td>
			    </tr>
			    <tr>
				                  <td width="99" class="boldbodycopy"><p><b>Authenticate:</b></p></td>
				    <td><input type="password" name="password" size="36"></td>
			    </tr>
			    <tr>
				    <td width="99">&nbsp;</td>
				    <td>&nbsp;
				    </td>
			    </tr>
			    <tr>
				    <td width="99">&nbsp;</td>
				    <td>
                    <%= Html.Hidden("ReturnUrl", ViewData["ReturnUrl"]) %>
                    <%= Html.Hidden("RememberMe", false) %>
				    <input border="0" src="../../Content/public/login/submit.gif" name="I1" width="132" height="45" type="image"></td>
			    </tr>
			    <tr>
				              <td colspan="2">
				                <span style="color:Red;font-size:10px;">
				                <%= Html.ValidationSummary("Invalid Logon")  %>
				                </span></td>
			</tr>
		    </table>
		    </div>
	    <% } %>
	    </td>
       <td><img name="loginlayout_r3_c3" src="../../Content/public/login/loginlayout_r3_c3.jpg" width="40" height="250" border="0" alt=""></td>
       <td><img src="../../Content/public/login/spacer.gif" width="1" height="159" border="0" alt=""></td>
      </tr>
      <tr>
       <td colspan="3"><img name="loginlayout_r4_c1" src="../../Content/public/login/loginlayout_r4_c1.jpg" width="474" height="39" border="0" alt=""></td>
       <td><img src="../../Content/public/login/spacer.gif" width="1" height="39" border="0" alt=""></td>
      </tr>
    </table>
</asp:Content>

