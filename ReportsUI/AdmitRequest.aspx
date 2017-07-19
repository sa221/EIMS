<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeFile="AdmitRequest.aspx.cs" Inherits="ReportsUI.ReportsUiAdmitRequest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
             Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    
    <%--  <script>
        $(document).ready(function () {
            $("#MainContent_dateTextBox").datepicker({
                autoclose: true,
                todayHighlight: true
            });
        });

    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <fieldset>
        <legend>
            <h1>
                Admission Letter</h1>
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
                <td>
                    <b>From ID:</b><br/>
                        <asp:TextBox ID="fromIdTextBox" runat="server"></asp:TextBox>
                </td>
                <%--<td>
                    <b>Date:
                        <asp:TextBox ID="dateTextBox" runat="server"></asp:TextBox></b>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="dateTextBox" Format="dd-MMMM-yyyy">
                    </cc1:CalendarExtender>
                </td>--%>
                <td><br/>
                    <asp:Button ID="createButton" runat="server" Text="Create" OnClick="createButton_Click" />
                </td>
              
            </tr>
            <tr>
                <td colspan="3">
                    <span class="label label-warning" style="background-color: #f0ad4e; float: left; font-size: 20px; position: relative;"  id="failStatusLabel" runat="server"></span>
                    <span class="label label-success" style="background-color: #5cb85c; float: left; font-size: 20px; position: relative;" id="successStatusLabel" runat="server"></span>
                    <br />
                     
                </td>
            </tr>
        </table>
        <CR:CrystalReportViewer ID="AdmitRequestReport" runat="server" AutoDataBind="True"
                                EnableDatabaseLogonPrompt="False" GroupTreeImagesFolderUrl="" Height="1269px"
                                ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="1082px" ToolPanelView="None" />
        <%--<CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="~\Reports\AdmitRequest.rpt">
        </Report>
    </CR:CrystalReportSource>--%>
    </fieldset>
</asp:Content>