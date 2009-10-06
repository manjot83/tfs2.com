<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Template.aspx.cs" Inherits="_Template" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="PRAGMA" content="NO-CACHE">
    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE">
    <title><%= pageTitle %></title>
    <link href="tfs2.css" rel="stylesheet" type="text/css" />
    <link href="layout.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    
    <!-- This div is for the whole frame of the page -->
    <div id="css_frame">

    <!-- This div is for the header, at the top, just an image for now -->
    <div id="css_header">
        <tfs2:Header ID="header" runat="server" />
    </div>

    <!-- The main content frame -->
    <div id="css_contentframe">

        <!-- Nav sfuff here, all links follow the class "rollover_x" for now -->
        <div id="css_nav">
            <asp:Literal ID="NavigationMenu" runat="server" />
	    <asp:HyperLink ID="LoginLink" runat="server" NavigateUrl="https://apollo.tfs2.com/secure" Text="Aircrew Login" />
        </div>
           
        <!-- The main content area --> 
        <div id="css_content">                    
            <asp:Literal ID="ContentBanner" runat="server" />        
            <!-- This section contains the padded text -->    
            
            <div id="css_imagestrip">
                <asp:Literal ID="ImageStrip" runat="server" />
            </div>
            
            <div id="css_text">
                <asp:Literal ID="ContentBody" runat="server" />                       					
            </div>
            
        </div>

    </div>

    <!-- Finally we have the footer image -->
    <div id="css_footer">
        <tfs2:Footer ID="footer" runat="server" />
    </div>

    </div>
    
    </form>
</body>
</html>
