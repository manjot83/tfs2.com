<%@ Page MasterPageFile="~/default.master"Language="C#" AutoEventWireup="true" CodeBehind="PersonnelFileReport.aspx.cs" 
Inherits="TFS.Web.Forms.PersonnelFileReport" Title="TFS - Personnel Record" %>

<%@ Register Src="~/Forms/Controls/ViewableFileControl.ascx" TagPrefix="tfs" TagName="ViewableFileControl" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<tfs:ViewableFileControl ID="ViewableFileControl" runat="server" />

</asp:Content>