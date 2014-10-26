<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SRFPrintView.aspx.cs" Inherits="TFS.Web.Forms.SRFPrintView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SRF Print View</title>
</head>
<body>
    <form id="form1" runat="server">
        
        <b><%= file.SymanticForm.Form.Name %></b>
        [ 
        TFSF <%= file.SymanticForm.Form.Tfsfnumber %>
        (<%= file.SymanticForm.Form.Createdon.Value.ToShortDateString() %>)
        ]
        <br />
        <br />
        <table style="width:100%;">
            <!-- 
                Top Header Part 
            -->
            <tr>
                <th colspan="2" align="left">SUBJECT</th>
                <th align="left">SRF NUMBER</th>
            </tr>
            <tr>
                <td colspan="2" style="border: solid 1px black;"><%= file.GetStoredValue("Subject") %>&nbsp;</td>
                <td style="border: solid 1px black;"><%= file.GetStoredValue("SRF Number") %>&nbsp;</td>
            </tr>
            
            <!-- 
                Narrative section
            -->
            <tr>
                <th colspan="3" align="left">NARRATIVE</th>
            </tr>
            <tr>
                <td colspan="3" style="border: solid 1px black; padding:10px;"><%= this.TransformMarkdown(file.GetStoredValue("Narrative")) %>&nbsp;</td>
            </tr>
            <!--
            Buffer
            -->
            <tr>
                <td colspan="3">&nbsp;</td>
            </tr>
            
            <!-- 
                Mid-bottom section
            -->
            <tr>
                <th align="left">AUTHORITY</th>
                <th align="left">DESIGN AIRCRAFT</th>
                <th align="left">POSTING DATE</th>
            </tr>
            <tr>
                <td style="border: solid 1px black;"><%= file.GetStoredValue("Authority") %>&nbsp;</td>
                <td style="border: solid 1px black;"><%= file.GetStoredValue("Design Aircraft") %>&nbsp;</td>
                <td style="border: solid 1px black;"><%= file.GetStoredValueAsDateTime("Posting Date").ToShortDateString() %>&nbsp;</td>        
            </tr>
            
            <!-- 
                Bottom section
            -->
            <tr>
                <th>CREW POSITION</th>
                <th>IMPLEMENTATION</th>
                <th></th>
            </tr>
            <tr>
                <td style="border: solid 1px black;"><%= file.GetStoredValue("Crew Position") %>&nbsp;</td>
                <td style="border: solid 1px black;"><%= file.GetStoredValue("Implementation") %>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>    
        </table>
    </form>
</body>
</html>
