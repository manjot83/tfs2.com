<%@ Page MasterPageFile="~/simple.master" Language="C#" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="TFS.Intranet.Web.error" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="Server">

<a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
<h1 id="H1_3">Error!</h1>

<p>An error has occured in the application.</p>

<asp:TextBox ID="ErrorInfo" BorderStyle="Solid" BorderWidth="2" BorderColor="black" runat="server" TextMode="multiLine" Width="75%" Height="300"></asp:TextBox>


</asp:Content>