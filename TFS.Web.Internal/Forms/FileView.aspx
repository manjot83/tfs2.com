<%@ Page MasterPageFile="~/default.master" Language="C#" AutoEventWireup="true" CodeBehind="FileView.aspx.cs" Inherits="TFS.Web.Forms.FileView"
   Title="TFS - Form File View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h1>File View</h1>



<p>
    <asp:HyperLink ID="PreviousLink" runat="server" title="View the previous file">Previous File</asp:HyperLink><br />
    <asp:HyperLink ID="NextLink" runat="server" title="View the next file">Next File</asp:HyperLink><br />
</p>
<p>
    <a href='FileList.aspx?form=<%= this.file.FormId %>' title="Return">Return to File Listing</a><br />
    <asp:HyperLink ID="EditLink" runat="server" title="Edit">Edit this file (admin only)</asp:HyperLink><br />    
</p>

</asp:Content>
