<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeFile="LeftStudentInfo.aspx.cs" Inherits="ReportsUI.ReportsUiLeftStudentInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
             Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <fieldset>
        <legend>
            <h1>
                Left Student Report</h1>
        </legend>
        <table>
            <tr>
             <td>
                    <b>Class</b><br/>
                    <asp:DropDownList ID="classDropDownList" runat="server" AppendDataBoundItems="True" 
                                      DataSourceID="SqlDataSource2" DataTextField="VarClassName" 
                                      DataValueField="VarClassID"
                        >
                        <asp:ListItem Selected="True" Value="0">--Class--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       
                        SelectCommand="SELECT [VarClassID], [VarClassName] FROM [Class]">
                       
                    </asp:SqlDataSource>
                </td>
                <td>
                    <b>From Date:</b>
                    <br />
                    <asp:TextBox ID="fromDateTextBox" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="fromDateTextBox" >
                    </cc1:CalendarExtender>
                </td>
                <td>
                    <b>To Date:</b>
                    <br />
                    <asp:TextBox ID="toDateTextBox" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="toDateTextBox">
                    </cc1:CalendarExtender>
                </td>
                <td><br/>
                    <asp:Button ID="showButton" runat="server" Text="Show" 
                                onclick="showButton_Click" />
                </td>
            </tr>
        </table>
        <CR:CrystalReportViewer ID="LeftStudentReportViewer" runat="server" AutoDataBind="True"
                                EnableDatabaseLogonPrompt="False" GroupTreeImagesFolderUrl="" Height="50px" ToolbarImagesFolderUrl=""
                                ToolPanelView="None" ToolPanelWidth="200px" Width="350px" />
    </fieldset>
   
</asp:Content>