<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="BoardExamineeList.aspx.cs" Inherits="ReportsUI_BoardExamineeList" %>

<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            height: auto;
            width: 100%;
        }
        
        .style2
        {
            width: 100%;
        }
        .style3
        {
            width: 20%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <legend><b>
            <h2>
                Board Examinee List</h2>
        </b></legend>
        <table class="style1">
            <tr class="style2">
                <td class="style3">
                    <b><i>Session</i></b>
                    <br />
                    <asp:DropDownList ID="sessionDropDownList" runat="server" DataSourceID="SqlDataSource1"
                        AppendDataBoundItems="True" DataTextField="VarSessionName" DataValueField="VarSessionId"
                        OnSelectedIndexChanged="sessionDropDownList_SelectedIndexChanged" AutoPostBack="True"
                        Width="150px">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo] ORDER BY [VarSessionId] DESC">
                    </asp:SqlDataSource>
                </td>
                <td class="style3">
                    <b>Exam Session</b><br />
                    <asp:DropDownList ID="examSessionDropDownList" runat="server" Width="150px">
                    </asp:DropDownList>
                </td>
                <td class="style3">
                    <b>Class</b>
                    <br />
                    <asp:DropDownList ID="classDropDownList" runat="server" Width="150px">
                        <asp:ListItem Value="0">ALL</asp:ListItem>
                        <asp:ListItem Value="O-LEVEL">O-LEVEL</asp:ListItem>
                        <asp:ListItem Value="A-LEVEL">A-LEVEL</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style3">
                    <b>Board</b>
                    <br />
                    <asp:DropDownList ID="boardDropDownList" runat="server" Width="150px">
                        <asp:ListItem Value="0">ALL</asp:ListItem>
                        <asp:ListItem Value="EDEXCEL">EDEXCEL</asp:ListItem>
                        <asp:ListItem Value="CAMBRIDGE">CAMBRIDGE</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style3">
                    <b>Quali. Level</b>
                    <br />
                    <asp:DropDownList ID="qLevelDropDownList" runat="server" Width="150px">
                        <asp:ListItem Value="0">ALL</asp:ListItem>
                        <asp:ListItem Value="IAL">IAL</asp:ListItem>
                        <asp:ListItem Value="IGCSE">IGCSE</asp:ListItem>
                        <asp:ListItem Value="A-LEVEL">A-LEVEL</asp:ListItem>
                        <asp:ListItem Value="AS-LEVEL">AS-LEVEL</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <span class="label label-warning" style="background-color: #f0ad4e; float: left;
                        font-size: 20px; position: relative;" id="failStatusLabel" runat="server"></span>
                    <span class="label label-success" style="background-color: #5cb85c; float: left;
                        font-size: 20px; position: relative;" id="successStatusLabel" runat="server">
                    </span>
                </td>
            </tr>
        </table>
        <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
        <CR:CrystalReportViewer ID="BoardExamineeReport" runat="server" Visible="True" AutoDataBind="False"
            Height="1202px" ToolPanelWidth="200px" Width="1104px" EnableDatabaseLogonPrompt="False"
            ToolPanelView="None" />
    </fieldset>
</asp:Content>
