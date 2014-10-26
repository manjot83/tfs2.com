<%@ Page MasterPageFile="~/default.master" Language="C#" AutoEventWireup="true" CodeBehind="SRFView.aspx.cs" Inherits="TFS.Web.Forms.SRFView"
   Title="TFS - SRF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h1>Safety Read File</h1>

<table width="650px">
    <!-- 
        Top Header Part 
    -->
    <tr>
        <th colspan="2">SUBJECT</th>
        <th>SRF NUMBER</th>
    </tr>
    <tr>
        <td colspan="2"><%= file.GetStoredValue("Subject") %></td>
        <td><%= file.GetStoredValue("SRF Number") %></td>
    </tr>
    
    <!-- 
        Narrative section
    -->
    <tr>
        <th colspan="3">NARRATIVE</th>
    </tr>
    <tr>
        <td colspan="3"><%= this.TransformMarkdown(file.GetStoredValue("Narrative")) %></td>
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
        <th>AUTHORITY</th>
        <th>DESIGN AIRCRAFT</th>
        <th>POSTING DATE</th>
    </tr>
    <tr>
        <td><%= file.GetStoredValue("Authority") %></td>
        <td><%= file.GetStoredValue("Design Aircraft") %></td>
        <td><%= file.GetStoredValueAsDateTime("Posting Date").ToShortDateString() %></td>        
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
        <td><%= file.GetStoredValue("Crew Position") %></td>
        <td><%= file.GetStoredValue("Implementation") %></td>
        <td>&nbsp;</td>
    </tr>    
</table>

<p>
    <asp:HyperLink ID="PreviousLink" runat="server" title="View the previous file">Previous File</asp:HyperLink><br />
    <asp:HyperLink ID="NextLink" runat="server" title="View the next file">Next File</asp:HyperLink><br />
</p>
<p>
    <a href='SRFPrintView.aspx?file=<%= file.FileId %>' title="Print view" target="_blank">Printable View</a>
</p>
<p>
    <a href="SRFListing.aspx" title="Return">Return to File Listing</a><br />
    <asp:HyperLink ID="EditLink" runat="server" title="Edit">Edit this file (admin only)</asp:HyperLink><br />    
</p>

</asp:Content>
