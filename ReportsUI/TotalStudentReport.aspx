<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeFile="TotalStudentReport.aspx.cs" Inherits="ReportsUI.ReportsUiTotalStudentReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
             Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <legend>
            <h1>
                Total Number Of Student</h1>
        </legend>
        <table>
            <tr>
                <td>
                    <b>Session</b>
                    <br />
                    <asp:DropDownList ID="sessionDropDownList" runat="server" DataSourceID="SqlDataSource1"
                                      DataTextField="VarSessionName" DataValueField="VarSessionId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo] ORDER BY [VarSessionName] DESC">
                    </asp:SqlDataSource>
                </td>
                <td><br/>
                    <asp:Button ID="showButton" runat="server" Text="Show" 
                                onclick="showButton_Click" />
                </td>
            </tr>
        </table>
        <CR:CrystalReportViewer ID="TotalStudent" runat="server" AutoDataBind="true" 
                                EnableParameterPrompt="False" ToolPanelView="None" />
    </fieldset>
</asp:Content>