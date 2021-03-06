﻿<%@ Page MasterPageFile="~/default.master" Language="C#" AutoEventWireup="true" CodeBehind="SRFListing.aspx.cs" Inherits="TFS.Web.Forms.SRFListing"
   Title="TFS - SRF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


<asp:ScriptManager ID="ScriptManager1" runat="server" />


<asp:ObjectDataSource ID="FilesObjectDataSource" runat="server"
TypeName="TFS.OpCenter.Forms.FileCollectionController"
SelectMethod="FetchAll">
    <SelectParameters>
        <asp:Parameter Name="formId" DefaultValue="101" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>

<h1>Safety Read Files</h1>

<p>
<a runat="server" id="AddFileLink" href="Editor.aspx?filetype=srf&amp;form=101" title="Add a new SRF" visible='<%# this.UserCanEdit() %>'>Add New File</a>
</p>

<asp:UpdatePanel ID="FilesListViewUpdatePanel" runat="server">
<ContentTemplate>

<asp:ListView ID="FilesListView" runat="server" EnableViewState="true" DataSourceID="FilesObjectDataSource">
<LayoutTemplate>
     <table width="55%">
        <tr>
             <th>
                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Sort" CommandArgument="CreatedOn" Text="Created Date" ToolTip="Sort by date"></asp:LinkButton>
            </th>
            <th>
                <asp:Label ID="Header1" runat="server" Text="Posting Date"></asp:Label>
            </th>
            <th>                
                <asp:LinkButton ID="Header2" runat="server" CommandName="Sort" CommandArgument="Subject" Text="SUBJECT" ToolTip="Sort by subject"></asp:LinkButton>
            </th>
            <th>                
                <asp:LinkButton ID="Header3" runat="server" CommandName="Sort" CommandArgument="SRF NUMBER" Text="SRF NUMBER" ToolTip="Sort by number"></asp:LinkButton>
            </th>
            <th>&nbsp;</th>
        </tr>
        <tr id="itemPlaceholder" runat="server"></tr>
    </table>
</LayoutTemplate>
<ItemTemplate>
    <tr>
         <td>
            <%# Convert.ToDateTime(Eval("createdon")).ToShortDateString() %>
        </td>
        <td>
            <%# Eval("Posting Date") %>
        </td>
        <td>
            <a href='<%# "SRFView.aspx?file="+Eval("FileId") %>' title="View this file">
                <%# Eval("Subject") %>
            </a>
        </td>
        <td>
            <%# Eval("SRF NUMBER") %>
        </td>
        <td>
            <a runat="server" href='<%# "Editor.aspx?filetype=srf&file="+Eval("FileId")+"&form="+Eval("FormId") %>' title="Edit this file" visible='<%# this.UserCanEdit() %>'>
                edit
            </a>
        </td>       
    </tr>
</ItemTemplate>
</asp:ListView>

</ContentTemplate>
</asp:UpdatePanel>

</asp:Content>
