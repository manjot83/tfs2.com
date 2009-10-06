<%@ Page MasterPageFile="~/default.master"Language="C#" AutoEventWireup="true" CodeBehind="Editor.aspx.cs" Inherits="TFS.Web.Forms.Editor"
Title="TFS - Form File Editor"
 %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<h3>File Editor</h3>

<h1>File Form Information</h1>
<p>
    Editing file for form: <b><%= this.controller.Form.Name %></b>    
</p>
<h2>Other Information</h2>
<p>
    TFSF: <b><%= this.controller.Form.Tfsfnumber %></b><br />
    Remarks: <b><%= this.controller.Form.Remarks %></b><br />
    Form Created On: <b><%= this.controller.Form.Createdon.Value.ToShortDateString() %></b><br />
</p>

<h1>File Records</h1>

<tfs:EditableFileForm ID="EditForm" runat="server" />

</asp:Content>