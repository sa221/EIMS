<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="PerformanceChart.aspx.cs" Inherits="ReportsUI.ReportsUiPerformanceChart" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .upper-case {
            text-transform: uppercase;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <legend>
            <h1>
                Performance Chart</h1>
        </legend>
        <table>
            <tr>
                <td>
                    <b>Session: </b><br/>
                    <asp:DropDownList ID="sessionDropDownList" runat="server" DataSourceID="getSession"
                        DataTextField="VarSessionName" DataValueField="VarSessionId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getSession" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo] ORDER BY [VarSessionId] DESC">
                    </asp:SqlDataSource>
                </td>
                <td>
                    <b>Student ID: </b><br/>
                    <asp:TextBox ID="studentIdTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <b>Description: </b><br/>
                    <asp:TextBox ID="descTextBox" runat="server" Width="250%"  CssClass="upper-case"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <%--<td><b>Student Id: </b>
                    <asp:TextBox ID="studentIdTextBox" runat="server"></asp:TextBox></td>--%>
                <td>
                    <b>Class: </b><br/>
                    <asp:DropDownList ID="classDropDownList" runat="server" AppendDataBoundItems="True"
                        DataSourceID="getAllClass" DataTextField="VarClassName" DataValueField="VarClassID"
                        AutoPostBack="True" OnSelectedIndexChanged="classDropDownList_SelectedIndexChanged1">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getAllClass" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [VarClassID], [VarClassName] FROM [Class]"></asp:SqlDataSource>
                </td>
                <td>
                    <b>Section: </b><br/>
                    <asp:DropDownList ID="sectionDropDownList" runat="server" AppendDataBoundItems="True"
                        DataSourceID="SqlDataSource3" DataTextField="varSectionName" DataValueField="SectionId">
                        <asp:ListItem Value="0">--All--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [SectionId], [varSectionName], [ClassID] FROM [tblSection] WHERE ([ClassID] = @ClassID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="classDropDownList" Name="ClassID" PropertyName="SelectedValue"
                                Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    <asp:Button ID="ShowButton" runat="server" Text="Show" OnClick="ShowButton_Click" />
                </td>
            </tr>
        </table>
        <CR:CrystalReportViewer ID="performanceChartCrystalReportViewer" runat="server" AutoDataBind="True"
            EnableDatabaseLogonPrompt="False" GroupTreeImagesFolderUrl="" Height="50px" ToolbarImagesFolderUrl=""
            ToolPanelView="None" ToolPanelWidth="200px" Width="350px" />
        <%--<CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="~\Reports\StudentPerformanceChart.rpt">
            </Report>
        </CR:CrystalReportSource>--%>
    </fieldset>
</asp:Content>
