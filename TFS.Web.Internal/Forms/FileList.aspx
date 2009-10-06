<%@ Page MasterPageFile="~/default.master" Language="C#" AutoEventWireup="true" CodeBehind="FileList.aspx.cs" Inherits="TFS.Web.Forms.FileList"
   Title="TFS - Form File Listing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<asp:ObjectDataSource ID="FilesObjectDataSource" runat="server"
TypeName="TFS.OpCenter.Forms.FileCollectionController"
SelectMethod="FetchAll">
    <SelectParameters>
        <asp:QueryStringParameter Name="formId" QueryStringField="form" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>

<h1>Form Listing</h1>

<p>
    <a href="Editor.aspx?form=<%= this.formid %>">Add New File</a>
</p>

<p>
    Clicking the linked text will bring up the report view for the form file.
</p>

<asp:UpdatePanel ID="FilesListViewUpdatePanel" runat="server">
<ContentTemplate>

<asp:ListView ID="FilesListView" runat="server" EnableViewState="true" DataSourceID="FilesObjectDataSource">
<LayoutTemplate>
    <table width="600px">
        <tr>
            <th>
                <asp:LinkButton ID="Header1" runat="server" CommandName="Sort" CommandArgument="modifiedby" Text="Modified By" ToolTip="Sort by modified by"></asp:LinkButton>
            </th>
            <th>                
                <asp:LinkButton ID="Header2" runat="server" CommandName="Sort" CommandArgument="FileKey" Text="File Key" ToolTip="Sort by file key"></asp:LinkButton>
            </th>
            <th>                
                <asp:LinkButton ID="Header3" runat="server" CommandName="Sort" CommandArgument="modifiedon" Text="Last Modified" ToolTip="Sort by date modified"></asp:LinkButton>
            </th>
            <th>&nbsp;</th>
            <th>&nbsp;</th>
        </tr>
        <tr id="itemPlaceholder" runat="server"></tr>
    </table>
</LayoutTemplate>
<ItemTemplate>
    <tr>
        <td>
            <%# Eval("modifiedby") %>
        </td>
        <td>
            <a href='<%# "FileView.aspx?file="+Eval("FileId") %>' title="View this file">
                <%# Eval("FileKey") %>
            </a>
        </td>
        <td>
            <%# Eval("modifiedon") %>
        </td>        
        <td>
            <a href='<%# "Editor.aspx?file="+Eval("FileId")+"&form="+Eval("FormId") %>' title="Edit this file">
                edit
            </a>
        </td>     
        <td>
            <a href='<%# "FileView.aspx?file="+Eval("FileId") %>' title="View this file">
                view
            </a>
        </td>  
    </tr>
</ItemTemplate>
</asp:ListView>

</ContentTemplate>
</asp:UpdatePanel>


</asp:Content>
