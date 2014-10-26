<%@ Page Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeBehind="Designer.aspx.cs" Inherits="TFS.Web.Forms.Designer"
    Title="TFS - Form Designer"
    %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<h1>Designing Form</h1>
<br />

<asp:UpdatePanel ID="FormInfoUpdatePanel" runat="server">
<ContentTemplate>

<table>
    <tr>
        <td align="right"><b>Form id:</b></td>
        <td>
            <b><asp:Literal ID="IDLiteral" runat="server"></asp:Literal></b>
        </td>
        <td>&nbsp;</td>        
    </tr>
    <tr>
        <td align="right"><b>Form name:</b></td>
        <td>
            <asp:TextBox ID="FormNameTextbox" runat="server" OnTextChanged="HandleFormInfoTextboxTextChanged" AutoPostBack="true" Columns="40"></asp:TextBox>
            
        </td>
        <td>
            <asp:LinkButton ID="SetFormNameTextbox" runat="server" CommandArgument="FormName" CommandName="Set" OnClick="HandleFormInfoSetButton" Visible="false">set new value</asp:LinkButton>
        </td>
    </tr>
    <tr>    
        <td align="right"><b>Short name:</b></td>
        <td>
            <asp:TextBox ID="ShortNameTextbox" runat="server" OnTextChanged="HandleFormInfoTextboxTextChanged" AutoPostBack="true"></asp:TextBox>            
        </td>
        <td>
            <asp:LinkButton ID="SetShortNameButton" runat="server" CommandArgument="ShortName" CommandName="Set" OnClick="HandleFormInfoSetButton" Visible="false">set new value</asp:LinkButton>
        </td>
    </tr>
    <tr>    
        <td align="right"><b>TFSF number:</b></td>
        <td>
            <asp:TextBox ID="TFSFNumberTextbox" runat="server" OnTextChanged="HandleFormInfoTextboxTextChanged" AutoPostBack="true"></asp:TextBox>            
        </td>
        <td>
            <asp:LinkButton ID="SetTFSFNumberButton" runat="server" CommandArgument="TFSFNumber" CommandName="Set" OnClick="HandleFormInfoSetButton" Visible="false">set new value</asp:LinkButton>
        </td>
    </tr>
    <tr>        
        <td align="right"><b>Created date:</b></td>
        <td>
            <asp:TextBox ID="CreatedDateTextbox" runat="server" OnTextChanged="HandleFormInfoTextboxTextChanged" AutoPostBack="true"></asp:TextBox>
            <ajax:CalendarExtender ID="Cal1" runat="server" TargetControlID="CreatedDateTextbox"></ajax:CalendarExtender>            
        </td>
        <td>
            <asp:LinkButton ID="SetCreatedDateButton" runat="server" CommandArgument="CreatedDate" CommandName="Set" OnClick="HandleFormInfoSetButton" Visible="false">set new value</asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td colspan="3"><asp:Label ID="FormInfoStatusLabel" runat="server" Visible="false" ForeColor="Red" Text=""></asp:Label>&nbsp;</td>
    </tr>
</table>

</ContentTemplate>
</asp:UpdatePanel>


<h1>Fields</h1>
<p>
<asp:UpdatePanel ID="FieldListUpdatePanel" runat="server">
<ContentTemplate>
    <asp:ListView ID="FieldsListView" runat="server" OnItemCommand="HandleFieldItemCommand" OnSorting="HandleFieldItemSorting">
        <LayoutTemplate>
            <asp:LinkButton ID="SortButton" runat="server" CommandName="Sort" CommandArgument="Name">Sort</asp:LinkButton>
            <table>
                <tr id="itemPlaceholder" runat="server"></tr>
            </table>
        </LayoutTemplate>
        <ItemSeparatorTemplate>
        </ItemSeparatorTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <b><%# Eval("Name") %></b>
                </td>
                <td><asp:ImageButton ID="MoveUpButton" runat="server" ImageUrl="~/icons/arrow_up.png" ToolTip="Move Field Up" CommandName="MoveFieldUp" CommandArgument='<%# Eval("FormField.Id") %>' /></td>
                <td><asp:ImageButton ID="MoveDownButton" runat="server" ImageUrl="~/icons/arrow_down.png" ToolTip="Move Field Down" CommandName="MoveFieldDown" CommandArgument='<%# Eval("FormField.Id") %>' /></td>
                <td>
                    <asp:LinkButton ID="EditFieldNameButton" runat="server" Text="edit field" CommandArgument='<%# Eval("FormField.Id") %>' CommandName="EditField"></asp:LinkButton>
                </td>            
            </tr>
        </ItemTemplate>
    </asp:ListView>
    <p>
        <asp:TextBox ID="NewFieldNameTextbox" runat="server"></asp:TextBox>
        <asp:LinkButton ID="AddNewFieldButton" runat="server" OnClick="HandleAddNewFieldButtonClicked">Add New Field</asp:LinkButton>
    </p>
</ContentTemplate>
<Triggers>
    <asp:AsyncPostBackTrigger ControlID="UpdateFieldNameLinkButton" EventName="Click" /> 
</Triggers>
</asp:UpdatePanel>
</p>

<asp:UpdatePanel ID="FieldEditorUpdatePanel" runat="server">
<ContentTemplate>

<asp:Panel ID="FieldEditorPanel" runat="server" Visible="false">

<h1>Field Editor</h1>

<p>
<asp:Label ID="FieldUpdateStatusLabel" runat="server" Visible="false" ForeColor="Red" Text=""></asp:Label>
</p>

<p>
<asp:TextBox ID="FieldNameTextbox" runat="server"></asp:TextBox>
<asp:LinkButton ID="UpdateFieldNameLinkButton" runat="server" OnClick="HandleFieldNameUpdateButtonClicked">Update Name</asp:LinkButton>
</p>

<p>
<asp:CheckBox ID="FieldIsKeyFieldCheckbox" runat="server" Text="This field is the key field for the form" />
</p>

<p>
Field Control Type:<br />
<asp:RadioButtonList ID="FieldControlTypeList" runat="server">
    <asp:ListItem Text="Textbox" Value="Textbox" Selected="True"></asp:ListItem>
    <asp:ListItem Text="Textarea" Value="Textarea"></asp:ListItem>
    <asp:ListItem Text="RichTextarea" Value="RichTextarea"></asp:ListItem>
    <asp:ListItem Text="DatePicker" Value="DatePicker"></asp:ListItem>
    <asp:ListItem Text="Checkbox" Value="Checkbox"></asp:ListItem>
    <asp:ListItem Text="Dropdownbox" Value="Dropdownbox"></asp:ListItem>
</asp:RadioButtonList>
</p>

<p>
    <b>Field Value Codes</b>
    <br />
    <asp:Repeater ID="FieldCodesRepeater" runat="server">
        <ItemTemplate>
            Code Id: <b><%# Eval("Id") %></b> Code Label: <b><%# Eval("Label") %></b><br />
        </ItemTemplate>    
    </asp:Repeater>
    <br />
    <asp:TextBox ID="NewFieldCodeTextbox" runat="server"></asp:TextBox>
    <asp:LinkButton ID="AddNewFieldCodeTextbox" runat="server" OnClick="HandleAddNewFieldCodeButtonClicked">Add New Field</asp:LinkButton>    
</p>

<p>
    <asp:LinkButton ID="UpdateFieldButton" runat="server" OnClick="HandleFieldUpdateButtonClicked">Update Field</asp:LinkButton>
</p>
</asp:Panel>

</ContentTemplate>

<Triggers>
    <asp:AsyncPostBackTrigger ControlID="FieldsListView" EventName="ItemCommand" />
</Triggers>
</asp:UpdatePanel>


</asp:Content>