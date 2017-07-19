<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="EmployeeListReport.aspx.cs" Inherits="ReportsUI_EmployeeListReport" %>

<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style3
        {
            width: 25%;
        }        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <fieldset>
        <legend>
            <h1>
                Employee List</h1>
        </legend>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td class="style3">
                            <b>Employee Category</b><br />
                            <asp:DropDownList ID="ctgDropDownList" runat="server" Width="100px" DataSourceID="getEmpCategory" AppendDataBoundItems="True"
                                DataTextField="CategoryName" DataValueField="CategoryId">
                                <asp:ListItem Value="0">ALL</asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="getEmpCategory" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                SelectCommand="SELECT [CategoryId], [CategoryName] FROM [EmployeeCategory]">
                            </asp:SqlDataSource>
                            <br />
                        </td>
                        <td class="style3">
                            <b>Employee Designation</b><br />
                            <asp:DropDownList ID="designationDropDownList" runat="server" Width="100px" DataSourceID="getDesignation" AppendDataBoundItems="True"
                                DataTextField="VarDesignationName" DataValueField="NumDesignationId">
                                <asp:ListItem Value="0">ALL</asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="getDesignation" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                SelectCommand="SELECT [NumDesignationId], [VarDesignationName] FROM [EmployeeDesignation]">
                            </asp:SqlDataSource>
                            <br />
                        </td>
                        <td class="style3">
                            <b>Current Status</b><br />
                            <asp:DropDownList ID="currentStatusDropDownList" runat="server">
                                <asp:ListItem Value="0">ALL</asp:ListItem>
                                <asp:ListItem Value="A">Active</asp:ListItem>
                                <asp:ListItem Value="L">Left</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                        </td>
                        <td>
                            <b>Campus</b><br />
                            <asp:DropDownList ID="campusDropDownList" runat="server" AppendDataBoundItems="True"
                                Width="143px" DataSourceID="SqlDataSource7" DataTextField="house_name" DataValueField="house_Code">
                                <asp:ListItem Selected="True" Value="0">ALL</asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                SelectCommand="SELECT [house_Code], [house_name] FROM [tblhouse]"></asp:SqlDataSource>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <span class="label label-warning" style="background-color: #f0ad4e; float: left;
                                font-size: 20px; position: relative;" id="failStatusLabel" runat="server"></span>
                            <span class="label label-success" style="background-color: #5cb85c; float: left;
                                font-size: 20px; position: relative;" id="successStatusLabel" runat="server">
                            </span>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" Visible="True" AutoDataBind="False"
            Height="1202px" ToolPanelWidth="200px" Width="1104px" EnableDatabaseLogonPrompt="False"
            ToolPanelView="None" />
        <%--  <CR:CrystalReportSource ID="CrystalReportSource1" runat="server" HasCrystalLogo="False" HasRefreshButton="True" HasToggleGroupTreeButton="False" >
           <%-- <Report FileName="~/Reports\StudentListWithRoll.rpt">
            </Report>--%>
        <%--</CR:CrystalReportSource>--%>
    </fieldset>
</asp:Content>
