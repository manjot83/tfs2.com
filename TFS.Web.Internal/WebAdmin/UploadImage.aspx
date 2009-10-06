<%@ Page MasterPageFile="~/default.master" Title="Upload Image" Language="C#" AutoEventWireup="true"
    Inherits="admin_UploadImage" CodeBehind="UploadImage.aspx.cs" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Use this interface to upload images. Images will automatically be resized and reformated
        to the correct web graphics specs for this site.
    </p>
    <h1>
        Upload Images</h1>
    <p>
        Enter A Friendly Name&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="textImageName" runat="server" Width="200"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required"
            ControlToValidate="textImageName" />
        <br />
        <br />
        Select File To Upload:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:FileUpload ID="UploadFile" runat="Server" />
        <br />
        <br />
        <asp:Button ID="UploadBtn" Text="Upload Image" OnClick="UploadBtn_Click" runat="server">
        </asp:Button>
    </p>
</asp:Content>
