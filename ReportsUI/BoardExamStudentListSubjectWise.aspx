<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="BoardExamStudentListSubjectWise.aspx.cs" Inherits="ReportsUI_BoardExamStudentListSubjectWise" %>

<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <legend>
            <h1>
                Subject Wise Student List (Board Exam)</h1>
        </legend>
        <table>
            <tr>
                <td>
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
                <td>
                    <b>Exam Session</b><br/>
                    <asp:DropDownList ID="examSessionDropDownList" runat="server" Width="150px">
                    </asp:DropDownList>
                </td>
                <td>
                    <b>Quali. Level</b>
                    <br />
                    <asp:DropDownList ID="qLevelDropDownList" runat="server" Width="90px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="qLevelDropDownList_SelectedIndexChanged">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem Value="IAL">IAL</asp:ListItem>
                        <asp:ListItem Value="IGCSE">IGCSE</asp:ListItem>
                        <asp:ListItem Value="A-LEVEL">A-LEVEL</asp:ListItem>
                        <asp:ListItem Value="AS-LEVEL">AS-LEVEL</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <b>Subject:</b>
                    <br />
                    <asp:DropDownList ID="subjectDropDownList" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="subjectDropDownList_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    <b>Unit Code:</b>
                    <br />
                    <asp:DropDownList ID="unitcodeDropDownList" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <br />
                    <asp:Button ID="showButton" runat="server" Text="Show" OnClick="showButton_Click" />
                </td>
            </tr>
        </table>
        <CR:CrystalReportViewer ID="SubjectWiseStudentListBoardExam" runat="server" AutoDataBind="true"
            EnableParameterPrompt="False" ToolPanelView="None" />
    </fieldset>
</asp:Content>
