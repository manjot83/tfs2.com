<%@ Page MasterPageFile="~/default.master"Language="C#" AutoEventWireup="true" CodeBehind="PersonnelFile.aspx.cs" 
Inherits="TFS.Web.Forms.PersonnelFile" Title="TFS - Personnel Record" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<h1>Personnel File Form</h1>
<p>
    Editing file for: <b><%= this.controller.File.Person.Displayname %></b>    
</p>
<h2>User Information</h2>
<p>
    Firstname: <b><%= this.controller.File.Person.Firstname %></b><br />
    Lastname: <b><%= this.controller.File.Person.Lastname %></b><br />
    Username: <b><%= this.controller.File.Person.Username %></b>    
</p>

<h1>Form Records</h1>

<tfs:EditableFileForm ID="EditForm" runat="server" />

</asp:Content>