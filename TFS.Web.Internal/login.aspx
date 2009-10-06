<%@ Page Language="C#" AutoEventWireup="true" Inherits="login" Codebehind="login.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Aircrew Login</title>
    <link href="style/Public/tfs2.css" rel="stylesheet" type="text/css" />
    <link href="style/Public/layout.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    
    <div id="css_frame">

    <!-- This div is for the header, at the top, just an image for now -->
    <div id="css_header">        
        <img src="style/template/header.jpg" width="768" height="224" alt="" />
    </div>

    <!-- The main content frame -->
    <div id="css_contentframe">

        <!-- Nav sfuff here, all links follow the class "rollover_x" for now -->
        <div id="css_nav">
        <asp:HyperLink ID="HomeLink" runat="server" NavigateUrl="/" Text="Home" />
	    <asp:HyperLink ID="LoginLink" runat="server" NavigateUrl="/secure" Text="Aircrew Login" />
        </div>
    
            <!-- The main content area --> 
        <div id="css_content">      
    
    <img src="https://apollo.tfs2.com/site/style/banners/aircrew_login.gif" />
    
    <table border="0" cellpadding="0" cellspacing="0" width="474">
<!-- fwtable fwsrc="layout_tbs_login.png" fwbase="loginlayout.jpg" fwstyle="Dreamweaver" fwdocid = "742308039" fwnested="0" -->
  <tr>
   <td><img src="login/spacer.gif" width="34" height="1" border="0" alt=""></td>
   <td><img src="login/spacer.gif" width="400" height="1" border="0" alt=""></td>
   <td><img src="login/spacer.gif" width="40" height="1" border="0" alt=""></td>
   <td><img src="login/spacer.gif" width="1" height="1" border="0" alt=""></td>
  </tr>

  <tr>
   <td colspan="3"><img name="loginlayout_r1_c1" src="https://apollo.tfs2.com/site/login/loginlayout_r1_c1.jpg" width="474" height="1" border="0" alt=""></td>
   <td><img src="login/spacer.gif" width="1" height="1" border="0" alt=""></td>
  </tr>
  <tr>
   <td colspan="3"><img name="loginlayout_r2_c1" src="https://apollo.tfs2.com/site/login/loginlayout_r2_c1.jpg" width="474" height="29" border="0" alt=""></td>
   <td><img src="login/spacer.gif" width="1" height="29" border="0" alt=""></td>
  </tr>
  <tr>
   <td>
   
   <img name="loginlayout_r3_c1" src="https://apollo.tfs2.com/site/login/loginlayout_r3_c1.jpg" width="34" height="250" border="0" alt=""></td>
   <td bgcolor="#E8EBEA">


<div align="center"><font size="1">&nbsp;</font><table border="0" width="90%" cellspacing="0" cellpadding="2">
		    <tr>
				              <b><td width="150"  align="right" class="boldbodycopy"><span style="font-size:small; font-weight:bold;">Callsign:</span></td></b>
				<td align="left"><asp:TextBox runat="server" ID="UserName" MaxLength="36" /></td>
			</tr>
			<tr>
				              <b><td width="150" align="right" class="boldbodycopy"><span style="font-size:small; font-weight:bold;">Authenticate:</span></td></b>
				<td align="left"><asp:TextBox runat="server" ID="UserPass" TextMode="password" MaxLength="36" /></td>
			</tr>						
			<tr>
				<td width="99">&nbsp;</td>
				<td>&nbsp;
				</td>
			</tr>
			<tr>
				<td width="99">&nbsp;</td>
				<td>				
				<asp:ImageButton border="0" width="132" height="44" ImageUrl="https://apollo.tfs2.com/site/login/submit.gif" ID="changePasswordButton" runat="server" OnClick="HandleLoginClicked" />
				</td>
			</tr>
			<tr>
				              <td colspan="2"><asp:Label id="lblResults"
                    ForeColor="red"
                    Font-Size="10"
                    runat="server" /></td>
			</tr>
		</table>
		</div>

 
    
    	</td>
   <td><img name="loginlayout_r3_c3" src="https://apollo.tfs2.com/site/login/loginlayout_r3_c3.jpg" width="40" height="250" border="0" alt=""></td>
   <td><img src="login/spacer.gif" width="1" height="159" border="0" alt=""></td>
  </tr>
  <tr>
   <td colspan="3"><img name="loginlayout_r4_c1" src="https://apollo.tfs2.com/site/login/loginlayout_r4_c1.jpg" width="474" height="39" border="0" alt=""></td>
   <td><img src="login/spacer.gif" width="1" height="39" border="0" alt=""></td>
  </tr>
</table>

            
        </div>

    </div>

    <!-- Finally we have the footer image -->
    <div id="css_footer">
        <img src="style/template/footer.gif" width="768" height="119" alt="" />
    </div>

    </div>

    
    </form>
</body>
</html>
