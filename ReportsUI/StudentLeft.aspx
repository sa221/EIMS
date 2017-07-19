<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeFile="StudentLeft.aspx.cs" Inherits="ReportsUI_StudentLeft" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
             Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <fieldset>
        <legend>
            <h1>
                Create Transfer Certificate</h1>
        </legend>
        <table>
            <tr>
                <td>
                    <b>Session: </b><br/>
                    <asp:DropDownList ID="sessionDropDownList" runat="server" 
                                      DataSourceID="getSession" DataTextField="VarSessionName" 
                                      DataValueField="VarSessionId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getSession" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo] ORDER BY [VarSessionId] DESC">
                    </asp:SqlDataSource>
                </td>
                <td>
                    <b>Student ID</b>
                    <br />
                    <asp:TextBox ID="studentIdTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <br />
                    <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
                </td>
                <td colspan="3">
                    <br />
                    <span class="label label-warning" style="background-color: #f0ad4e; float: left; font-size: 20px; position: relative;" id="failStatusLabel" runat="server"></span><span class="label label-success"
                                                                                                                                                                                                                    style="background-color: #5cb85c; float: left; font-size: 20px; position: relative;"
                                                                                                                                                                                                                    id="successStatusLabel" runat="server"></span>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Status</b>
                    <br />
                    <asp:DropDownList ID="statusDropDownList" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource5"
                                      DataTextField="PresentStatus" DataValueField="StatusInitial">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT [PresentStatus], [StatusInitial] FROM [tbl_StudentPresentStatus]">
                    </asp:SqlDataSource>
                </td>
                <td>
                    <b>Leave Date</b>
                    <br />
                    <asp:TextBox ID="leaveDateTextBox" runat="server" Width=""></asp:TextBox><br />
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="leaveDateTextBox"
                                          Format="dd/MM/yyyy"></cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Remarks</b>
                    <br />
                    <asp:TextBox ID="remarksTextBox" runat="server" Width=""></asp:TextBox>
                </td>
                <td>
                    <b>Comments</b>
                    <br />
                    <asp:TextBox ID="commentTextBox" runat="server" Width=""></asp:TextBox>
                </td>
                <td><br/>
                    <asp:Button ID="tcButton" runat="server" Text="TC" OnClick="tcButton_Click" />
                </td>
            </tr>
        </table>
        <CR:CrystalReportViewer ID="TransferCertificate" runat="server" 
                                AutoDataBind="true" ToolPanelView="None" />
    </fieldset>
</asp:Content>