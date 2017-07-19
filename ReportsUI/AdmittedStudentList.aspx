<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="AdmittedStudentList.aspx.cs" Inherits="ReportsUI_AdmittedStudentList" %>

<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <fieldset>
        <legend>
            <h1>
               Admitted Student List</h1>
        </legend>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <%--<td>
                            <b>Session:</b>
                            <br />
                            <asp:DropDownList ID="sessionDropDownList" runat="server" DataSourceID="SqlDataSource1"
                                DataTextField="VarSessionName" DataValueField="VarSessionId">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo] ORDER BY [VarSessionName] DESC">
                            </asp:SqlDataSource>
                        </td>--%>
                        <td>
                            <b>Date:</b>
                            <br />
                            <asp:TextBox ID="dateTextBox" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" 
                                TargetControlID="dateTextBox"></ajaxToolkit:CalendarExtender>
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
        <CR:CrystalReportViewer ID="AdmittedStudentReport" runat="server" Visible="True"
            AutoDataBind="False" Height="1202px" ToolPanelWidth="200px" Width="1104px" EnableDatabaseLogonPrompt="False"
            ToolPanelView="None" />
        <%--  <CR:CrystalReportSource ID="CrystalReportSource1" runat="server" HasCrystalLogo="False" HasRefreshButton="True" HasToggleGroupTreeButton="False" >
           <%-- <Report FileName="~/Reports\StudentListWithRoll.rpt">
            </Report>--%>
        <%--</CR:CrystalReportSource>--%>
    </fieldset>
</asp:Content>
