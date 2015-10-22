<%@ Page Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeBehind="billingaccount_manage.aspx.cs"
    Inherits="TFS.Intranet.Web.Billing.Admin.billingaccount_manage" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <asp:ObjectDataSource ID="CityPerDiemDataSource" runat="server"
        TypeName="TFS.Intranet.Data.Billing.BillingDefaultCityRateController"
        SelectMethod="FetchAllActiveByAccountId"
        DeleteMethod="Delete"
        UpdateMethod="Update"
        OnSelecting="CityPerDiemDataSource_Selecting"
        OnDeleting="CityPerDiemDataSource_Deleting"></asp:ObjectDataSource>


    <asp:ObjectDataSource ID="RateGroupDataSource" runat="server" TypeName="TFS.Intranet.Data.Billing.RateGroupController"
        SelectMethod="FetchAll"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="BillingAccountDataSource" runat="server" TypeName="TFS.Intranet.Data.Billing.BillingAccountController"
        SelectMethod="FetchAll" InsertMethod="Insert" UpdateMethod="Update"></asp:ObjectDataSource>

    <asp:HiddenField ID="SelectedBillingAccountID" Value="" runat="server" />

    <p>
        <a href="default.aspx">Go Back</a>
    </p>
    <a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
    <h1 id="H1_3">Billing Accounts</h1>
    <br />
    <p>
        Select a Billing Account. Or <b>Insert</b> a new one below.<br />
        Change default values below.
    </p>
    <p>
        Billing Accounts:
        <asp:DropDownList runat="Server" ID="BillingAccountDropDown" DataSourceID="BillingAccountDataSource"
            DataTextField="name" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="BillingAccountSelected" AppendDataBoundItems="True">
            <asp:ListItem Text="Select A Billing Account"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:FormView ID="NewBillingAccountForm" runat="server" DataSourceID="BillingAccountDataSource"
            DefaultMode="Insert" OnItemInserted="ExpenseAccount_Created">
            <InsertItemTemplate>
                <asp:TextBox ID="AccountNameTextBox" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
                <asp:Button ID="InsertButton" CommandName="Insert" runat="server" Text="Insert" ValidationGroup="NewBillingAccountForm" />
                <asp:RequiredFieldValidator ID="NameRequired" runat="server" ValidationGroup="NewBillingAccountForm" ControlToValidate="AccountNameTextBox" ErrorMessage="Name Required"></asp:RequiredFieldValidator>
            </InsertItemTemplate>
        </asp:FormView>
    </p>


    <!-- CODE FOR EDIT PERIOD BILLING FORM -->
    <a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
    <h1 id="H1_1">Default Billing Rates</h1>
    <asp:Panel ID="EditPeriodBillingPanel" runat="server" BorderColor="Black" BorderStyle="Inset"
        BorderWidth="1" Visible="False">
        <p>
            Edit <b>Account Name</b><br />
            Name:
            <asp:TextBox ID="BillingAccountNameChanger" runat="server"></asp:TextBox>&nbsp;<asp:LinkButton ID="BillingAccountNameChangeButton" runat="server" Text="Change Name" OnClick="Change_AccountName"></asp:LinkButton>

        </p>

        <p>
            Edit <b>Default Billing Rates</b><br />
            Make sure you've selected a Billing Account first. Enter a rate, and then set it,
            for each <b>Payroll Group</b>
        </p>
        <p>
            Rates For: <b>
                <asp:Label ID="SelectedBillingAccountName" runat="server">Please Select An Account From Above</asp:Label></b>
        </p>
        <table>
            <tr style="display: none;">
                <th>
                    <asp:Label ID="Label2" runat="server" Text="Command" Width="120px"></asp:Label></th>
                <th>
                    <asp:Label ID="Label4" runat="server" Text="Default Per Diem Rate" Width="200px"></asp:Label></th>
                <th>
                    <asp:Label ID="Label6" runat="server" Text="Status" Width="100px"></asp:Label></th>
            </tr>
            <tr style="display: none;">
                <!--Replaced  by City Per Diem - BJO 10/20/2015-->
                <td>
                    <asp:LinkButton ID="PerDiemSet" runat="server" OnClick="SetDefaultPerDiemRate">Set Rate</asp:LinkButton></td>
                <td>$<asp:TextBox ID="PerDiem_Textbox" runat="server">-1</asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="PerDiemStatus" runat="server" ForeColor="red">&nbsp;</asp:Label></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="Label8" runat="server" Text="Command" Width="120px"></asp:Label></th>
                <th>
                    <asp:Label ID="Label9" runat="server" Text="Default Mileage Rate" Width="200px"></asp:Label></th>
                <th>
                    <asp:Label ID="Label10" runat="server" Text="Status" Width="100px"></asp:Label></th>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="MileageSet" runat="server" OnClick="SetDefaultMileageRate">Set Rate</asp:LinkButton></td>
                <td>$<asp:TextBox ID="Mileage_Textbox" runat="server">-1</asp:TextBox></td>
                <td>
                    <asp:Label ID="MileageStatus" runat="server" ForeColor="red">&nbsp;</asp:Label></td>
            </tr>
        </table>
        <br />
        <br />

        <!--**************************************-->
        <!--DefaultCityPerDiem-->
        <!--**************************************-->

        <strong>&nbsp;Default City Per Diem (Deleting a City Per Diem will not effect previous and current Billing Periods)</strong>
        <asp:UpdatePanel ID="CityPerDiemUpdatePanel" runat="server">
            <ContentTemplate>
                <asp:GridView ID="CityPerDiemGridView" runat="server" AutoGenerateColumns="False"
                    CellPadding="3" DataSourceID="CityPerDiemDataSource" GridLines="None" BackColor="White"
                    BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellSpacing="1"
                    DataKeyNames="id">
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <Columns>
                        <asp:TemplateField ShowHeader="False" ItemStyle-Width="100">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                    Text="Update"></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                    Text="Cancel"></asp:LinkButton>
                                <asp:HiddenField ID="AccountId" runat="Server" Value='<%# Bind("AccountId") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                    Text="Edit"></asp:LinkButton>
                                <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                                    Text="Delete"></asp:LinkButton>
                                <ajax:ConfirmButtonExtender ID="DeleteConfirmExtender" runat="server" TargetControlID="DeleteButton"
                                    ConfirmText="Are you sure you want to delete this entry?">
                                </ajax:ConfirmButtonExtender>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" ItemStyle-Width="250" />
                        <asp:BoundField DataField="DefaultPerDiemRate" HeaderText="Rate" SortExpression="DefaultPerDiemRate" ItemStyle-Width="250" DataFormatString="{0:C2}" />
                    </Columns>
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                    <EmptyDataTemplate>
                        No City Per Diem Entries Entered Yet
                    </EmptyDataTemplate>
                </asp:GridView>


                <p>
                    <b>Insert New City Per Diem</b>
                </p>

                <table style="border: solid 2px black;">
                    <tr>
                        <td>
                            <b>City:</b>
                            <asp:TextBox ID="tbxCity" Width="90%" runat="server"></asp:TextBox></td>
                        <td>
                            <b>Rate:</b>
                            <asp:TextBox ID="tbxCityPerDiemRate" Width="90%" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="CityPerDiem" ControlToValidate="tbxCity"
                                Text="City Required"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="CityPerDiem" ControlToValidate="tbxCityPerDiemRate"
                                Text="City Per Diem Rate Required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Button ID="CityPerDiemSubmit" OnClick="inserting_cityperdiem" Text="Add" runat="Server" ValidationGroup="CityPerDiem" /></td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="CityPerDiemSubmit" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>


        <!--**************************************-->


        <br />
        <br />
        <table>
            <tr>
                <th>
                    <asp:Label ID="Label1" runat="server" Text="Command" Width="120px"></asp:Label></th>
                <th>
                    <asp:Label ID="Label3" runat="server" Text="Rate Group" Width="200px"></asp:Label></th>
                <th>
                    <asp:Label ID="Label5" runat="server" Text="Default Billing Rate" Width="170px"></asp:Label></th>
                <th>
                    <asp:Label ID="Label7" runat="server" Text="Status" Width="100px"></asp:Label></th>
            </tr>
            <asp:Repeater ID="DefaultBillingRatesRepeater" DataSourceID="RateGroupDataSource"
                runat="server" OnItemCommand="DefaultBillingRatesCommand">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:LinkButton ID="SetRate" runat="server" CommandName="SetRate" CommandArgument='<%# Eval("id") %>'>Set Rate</asp:LinkButton></td>
                        <td>
                            <%# Eval("name") %>
                        </td>
                        <td>$<asp:TextBox ID="DefaultRate" runat="server" Text='<%# GetDefaultBillingRate((int)Eval("id")) %>'></asp:TextBox></td>
                        <td>
                            <asp:Label ID="Status" runat="server" ForeColor="red">&nbsp;</asp:Label></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </asp:Panel>
</asp:Content>
