<%@ Page MasterPageFile="~/simple.master" Language="C#" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="TFS.Intranet.Web.error" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="Server">

<a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
<h1 id="H1_3">Error!</h1>

<p>An error has occured in the application. The details of the error are listed below, please copy/paste the contents when reporting this error.</p>

<h4>Reporting:</h4>
<p>Please include as many details as to what you were doing when the error occured. These are needed to replicate the circumstances and find the source of the error.</p>

<p>Please submit bug reports at: <a href="http://trac.cridion.com:8080/public/trac/tfs2/newticket">http://trac.cridion.com:8080/public/trac/tfs2/newticket</a></p>



<asp:TextBox ID="ErrorInfo" BorderStyle="Solid" BorderWidth="2" BorderColor="black" runat="server" TextMode="multiLine" Width="75%" Height="300"></asp:TextBox>


</asp:Content>