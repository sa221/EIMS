<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BoardExamSubjectList.aspx.cs" Inherits="ReportsUI_BoardExamSubjectList" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
   <style type="text/css">
        .tdWidth
        {
            width: 20%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <fieldset>
        <legend>
            Board Exam Student List With Subject
        </legend>
        <table width="100%">
            <tr>
                <td colspan="4">
                    <span class="label label-warning" style="background-color: #f0ad4e; float: left;
                                          font-size: 20px; position: relative;" id="failStatusLabel" runat="server"></span>
                    <span class="label label-success" style="background-color: #5cb85c; float: left;
                                                                                                                      font-size: 20px; position: relative;" id="successStatusLabel" runat="server">
                    </span>
                </td>
            </tr>
            <tr>
                <td class="tdWidth">
                    <b><i>Session</i></b>
                    <br />
                    <asp:DropDownList ID="sessionDropDownList" runat="server" DataSourceID="SqlDataSource1"
                        AppendDataBoundItems="True" DataTextField="VarSessionName" DataValueField="VarSessionId"
                        OnSelectedIndexChanged="sessionDropDownList_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Value="0">--SELECT--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo] ORDER BY [VarSessionId] DESC">
                    </asp:SqlDataSource>
                </td>
                <td class="tdWidth">
                    <b>Exam Session</b><br />
                    <asp:DropDownList ID="examSessionDropDownList" runat="server" Width="90px">
                    </asp:DropDownList>
                </td>
                <td class="tdWidth">
                    <b><i>Class</i></b>
                    <br />
                    <asp:DropDownList ID="classDropDownList" runat="server">
                        <asp:ListItem Value="0">O-LEVEL</asp:ListItem>
                        <asp:ListItem Value="1">A-LEVEL</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="tdWidth">
                    <b>Board</b><br />
                    <asp:DropDownList ID="boardDropDownList" runat="server">
                        <asp:ListItem Value="0">EDEXCEL</asp:ListItem>
                        <asp:ListItem Value="1">CAMBRIDGE</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="tdWidth">
                    <asp:Button ID="showButton" runat="server" Text="Report" 
                        onclick="showButton_Click" />
                </td></tr>
        </table>
        <div>
            <CR:CrystalReportViewer ID="boardExamSubjeciViewer" runat="server" 
                AutoDataBind="true" EnableParameterPrompt="False" ToolPanelView="None" />
        </div>
    </fieldset>
</asp:Content>

