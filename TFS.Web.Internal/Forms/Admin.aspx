<%@ Page MasterPageFile="~/default.master"Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="TFS.Web.Forms.Admin" 

Title="Forms Admin" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent" ID="content1">

<asp:ObjectDataSource
        ID="FormsDataSource" 
        runat="server" 
        TypeName="TFS.OpCenter.Data.FormController"
        SelectMethod="FetchAll">
    </asp:ObjectDataSource>  

<h1>Forms</h1>
<p>Click to view file list to get see files/reports:</p>
<asp:Repeater ID="FormsRepeater" runat="server" DataSourceID="FormsDataSource">
    <HeaderTemplate>
        <table>
            <thead>
                <tr>
                    <th>Name</th>
                    <th style="width: 90px;">Short Name</th> 
                    <th style="width: 60px;">Number</th>
                    <th style="width: 90px;">Created Date</th>
                    <th style="width: 130px;">&nbsp;</th>                    
                </tr>
            </thead>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <a href='FileList.aspx?form=<%# Eval("id") %>' title="View form file listing and reports"><%# Eval("name") %></a>
            </td>
            <td>
                <%# Eval("shortname") %>
            </td>
            <td>
                <%# Eval("tfsfnumber") %>
            </td>
            <td>
                <%# ((DateTime)Eval("createdon")).ToShortDateString() %>
            </td>
            <td>
                <a href='Designer.aspx?form=<%# Eval("id") %>' title="Design this form">design form</a>                
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>

<asp:Panel ID="AddFormPanel" runat="server" Visible="false">
<h1>Add a Form</h1>
<p>
    Name (required): <asp:TextBox ID="NewFormNameTextbox" runat="server"></asp:TextBox><br />
    Short Name: <asp:TextBox ID="NewFormShortNameTextbox" runat="server"></asp:TextBox><br />
    TFSF #: <asp:TextBox ID="NewFormTFSFTextbox" runat="server"></asp:TextBox><br />
    Remarks: <asp:TextBox ID="NewFormRemarksTexbox" runat="server"></asp:TextBox><br />
    <asp:Button ID="AddFormButton" runat="server" Text="Add" OnClick="HandleAddFormButtonClick" />
</p>
</asp:Panel>

</asp:Content>