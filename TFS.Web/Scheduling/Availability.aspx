<%@ Page MasterPageFile="~/default.master" Language="C#" AutoEventWireup="true" Codebehind="Availability.aspx.cs"
    Inherits="TFS.Intranet.Web.Scheduling.Availability" %>

<asp:Content runat="Server" ContentPlaceHolderID="MainContent">
   
    <link href="../style/CalendarStyle.css" rel="stylesheet" type="text/css" />
    
    <asp:ScriptManager ID="manager1" runat="Server">
    </asp:ScriptManager>
    
    <div style="text-align: center;">
        <h3>
            Select Month</h3>
        <p>
            <asp:DropDownList ID="MonthDropDown" runat="server">
                <asp:ListItem Text="January" Value="1" Selected="true"></asp:ListItem>
                <asp:ListItem Text="February" Value="2"></asp:ListItem>
                <asp:ListItem Text="March" Value="3"></asp:ListItem>
                <asp:ListItem Text="April" Value="4"></asp:ListItem>
                <asp:ListItem Text="May" Value="5"></asp:ListItem>
                <asp:ListItem Text="June" Value="6"></asp:ListItem>
                <asp:ListItem Text="July" Value="7"></asp:ListItem>
                <asp:ListItem Text="August" Value="8"></asp:ListItem>
                <asp:ListItem Text="September" Value="9"></asp:ListItem>
                <asp:ListItem Text="October" Value="10"></asp:ListItem>
                <asp:ListItem Text="November" Value="11"></asp:ListItem>
                <asp:ListItem Text="December" Value="12"></asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="YearDropDown" runat="Server">
                <asp:ListItem Text="2007" Value="2007"></asp:ListItem>
                <asp:ListItem Text="2008" Value="2008"></asp:ListItem>
                <asp:ListItem Text="2009" Value="2009"></asp:ListItem>
                <asp:ListItem Text="2010" Value="2010"></asp:ListItem>
                <asp:ListItem Text="2011" Value="2011"></asp:ListItem>
                <asp:ListItem Text="2012" Value="2012"></asp:ListItem>
                <asp:ListItem Text="2013" Value="2013"></asp:ListItem>
                <asp:ListItem Text="2014" Value="2014" Selected="True"></asp:ListItem>
                <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
            </asp:DropDownList>
            <asp:LinkButton ID="SelectMonthButton" runat="server" Text="Select Month"></asp:LinkButton>
        </p>
    </div>
    
    <a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
    
    <h1 id="H1_2">
        My Availability
        <asp:Label ID="CurrentUserLabel" runat="server"></asp:Label></h1>
    <p>
        To give your daily availability, click on the corresponding block. When the block
        changes color, that means you are available on that day. No need to save the changes.
        The changes are automatically saved.
    </p>
    
    <asp:UpdatePanel ID="CalendarUpdatePanel" runat="server">
        <ContentTemplate>
            <center>
                <h2>
                    <asp:Label ID="MonthLabel" runat="server"></asp:Label></h2>
            </center>
            <p>
                <tfs:AvailabilityCalendar ID="AvailCalendar" runat="server" TableCssClass="calendarTable"
                    CellCssClass="dayCell" DayHeaderCssClass="dayName" DayLabelCssClass="dayLabel"
                    MarkedDayCssClass="busyCell" UnMarkButtonText="Unselect" MarkButtonText="Select" />
            </p>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="SelectMonthButton" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    
</asp:Content>
