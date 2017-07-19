<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EmployeeDetailsReport.aspx.cs" Inherits="ReportsUI_EmployeeDetailsReport" %>
<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
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
            width: 25%;
        }
        .style4
        {
            width: 350px;
        }
        .style6
        {
            width: 350px;
            height: 59px;
        }
        .style7
        {
            width: 272px;
            height: 59px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <fieldset>
        <legend>
            <h1>Employee Details Information</h1>
        </legend>
        <table class="style1">
            <tr class="style2">
                <td class="style3">
                    <b>Employee Category</b><br />
                    <asp:DropDownList ID="ctgDropDownList" runat="server" Width="150px">
                    </asp:DropDownList>
                   
                    <br />
                </td>
                <td class="style3">
                    <b>Employee Designation</b><br />
                    <asp:DropDownList ID="designationDropDownList" runat="server" Width="150px">
                    </asp:DropDownList>                   
                    <br />
                </td>
                <td class="style3">
                    <b>Current Status</b><br />
                    <asp:DropDownList ID="currentStatusDropDownList" runat="server" Width="150px">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem Value="A">Active</asp:ListItem>
                        <asp:ListItem Value="L">Left</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </td>
                <td class="style3">
                    <b>Campus</b><br />
                     <asp:DropDownList ID="campusDropDownList" runat="server" AppendDataBoundItems="True"
                        Width="150px" DataSourceID="SqlDataSource7" DataTextField="house_name" DataValueField="house_Code">
                        <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [house_Code], [house_name] FROM [tblhouse]"></asp:SqlDataSource>
                    <br />
                </td>
            </tr>
            <tr class="style2">
                <td class="style3">
                    <asp:Button ID="showReportButton" runat="server" Text="Show" 
                        onclick="showReportButton_Click" />
                </td>
                <td colspan="3" class="style3">
                <span class="label label-warning" style="background-color: #f0ad4e; float: left;
                    font-size: 20px; position: relative;" id="failStatusLabel" runat="server"></span>
                <span class="label label-success" style="background-color: #5cb85c; float: left;
                    font-size: 20px; position: relative;" id="successStatusLabel" runat="server">
                </span>
                <br />
                <br />
            </td>
            </tr>
        </table>
       
    </fieldset>
     <CR:CrystalReportViewer ID="employeeDetailsReport" runat="server" Visible="True" AutoDataBind="False"
            Height="1202px" ToolPanelWidth="200px" Width="1104px" EnableDatabaseLogonPrompt="False"
            ToolPanelView="None" />
</asp:Content>

