<%@ Page MasterPageFile="~/default.master" Language="C#" AutoEventWireup="true" CodeBehind="FCIFView.aspx.cs" Inherits="TFS.Web.Forms.FCIFView"
   Title="TFS - FCIF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h1>Flight Crew Information File</h1>

<table width="650px">
    <!-- 
        Top Header Part 
    -->
    <tr>
        <th colspan="2">SUBJECT</th>
        <th>FCIF NUMBER</th>
    </tr>
    <tr>
        <td colspan="2"><%= file.GetStoredValue("Subject") %></td>
        <td><%= file.GetStoredValue("FCIF Number") %></td>
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
    <a href='FCIFPrintView.aspx?file=<%= file.FileId %>' title="Print view" target="_blank">Printable View</a>
</p>
<p>
    <a href="FCIFListing.aspx" title="Return">Return to File Listing</a><br />
    <asp:HyperLink ID="EditLink" runat="server" title="Edit">Edit this file</asp:HyperLink><br />    
</p>

</asp:Content>
