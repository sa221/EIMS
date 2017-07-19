<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="StudentCertificate.aspx.cs" Inherits="ReportsUI_StudentCertificate" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
             Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <fieldset>
        <legend><h1>Student Certificate</h1></legend>
        <table>
            <tr>
                <td>
                    <b>Session</b><br/>
                    <asp:DropDownList ID="sessionDropDownList" runat="server" 
                                      DataSourceID="getSession" DataTextField="VarSessionName" 
                                      DataValueField="VarSessionId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getSession" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo] ORDER BY [VarSessionId] DESC">
                    </asp:SqlDataSource>
                </td>
                <td><b>Student ID:<br/><asp:TextBox ID="studentIdTextBox" runat="server"></asp:TextBox></b></td>
                <td>
                    <asp:Button ID="showButton" runat="server" Text="Show" 
                                onclick="showButton_Click" />
                </td>
            </tr>
        </table>
        <CR:CrystalReportViewer ID="StudentCertificate" runat="server" 
                                AutoDataBind="true" ToolPanelView="None" />
    </fieldset>
</asp:Content>