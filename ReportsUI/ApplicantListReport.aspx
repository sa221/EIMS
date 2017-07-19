<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ApplicantListReport.aspx.cs" Inherits="ReportsUI_ApplicantListReport" %>
<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <fieldset>
        <legend>
            <h1>
                Applicant List</h1>
        </legend>
        <table>
            <tr>
                <td>
                    <b>Session: </b>
                    <asp:DropDownList ID="sessionDropDownList" runat="server" DataSourceID="getSession"
                                      DataTextField="VarSessionName" DataValueField="VarSessionId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getSession" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo] ORDER BY [VarSessionId] DESC">
                    </asp:SqlDataSource>
                </td>
                <td>
                    <b>Class: </b>
                    <asp:DropDownList ID="classDropDownList" runat="server" AppendDataBoundItems="True"
                                      DataSourceID="getAllClass" DataTextField="VarClassName" 
                        DataValueField="VarClassID">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getAllClass" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT [VarClassID], [VarClassName] FROM [Class]"></asp:SqlDataSource>
                </td>
                <td>
                    <b>Status:</b><asp:DropDownList ID="applicantStatusDropDownList" runat="server">
                        <asp:ListItem Value="0">--ALL--</asp:ListItem>
                        <asp:ListItem Value="1">Applied</asp:ListItem>
                        <asp:ListItem Value="2">Selected For Interview</asp:ListItem>
                        <asp:ListItem Value="3">Selected For Admission</asp:ListItem>
                        <asp:ListItem Value="4">Admitted</asp:ListItem>
                    </asp:DropDownList>
                       
                </td>
                <td>
                    <asp:Button ID="showButton" runat="server" Text="Show" 
                                onclick="showButton_Click" /></td>
            </tr>
        </table>
        <CR:CrystalReportViewer ID="AdmissionResult" runat="server" AutoDataBind="true" 
                                EnableParameterPrompt="False" ToolPanelView="None" />
    </fieldset>
</asp:Content>

