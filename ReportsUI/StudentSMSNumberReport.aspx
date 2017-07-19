<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="StudentSMSNumberReport.aspx.cs" Inherits="ReportsUI_StudentSMSNumberReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <legend>
            <h1>
                Student List with Phone Number</h1>
        </legend>
        <table>
            <tr>
                <td>
                    Session:
                    <br />
                    <asp:DropDownList ID="sessionDropDownList" runat="server" DataSourceID="SqlDataSource1"
                        DataTextField="VarSessionName" DataValueField="VarSessionId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo] ORDER BY [VarSessionName] DESC">
                    </asp:SqlDataSource>
                </td>
                <td>
                    Class:<br />
                    <asp:DropDownList ID="classDropDownList" runat="server" AppendDataBoundItems="True"
                        DataSourceID="SqlDataSource2" DataTextField="VarClassName" DataValueField="VarClassID"
                        AutoPostBack="True" OnSelectedIndexChanged="classDropDownList_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="0">--Class--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [VarClassID], [VarClassName] FROM [Class]"></asp:SqlDataSource>
                </td>
                <td>
                    Section:
                    <br />
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
                    Shift:
                    <br />
                    <asp:DropDownList ID="shiftDropDownList" runat="server" DataSourceID="getShift" DataTextField="VarShiftName"
                        DataValueField="VarShiftCode" AppendDataBoundItems="True">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getShift" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [VarShiftCode], [VarShiftName] FROM [ShiftInfo]"></asp:SqlDataSource>
                </td>
                <%--<td>
                    <asp:CheckBox ID="sortingCheckBox" runat="server" Text="If sort by Roll"/></td>--%>
                <td>
                    <br />
                    <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
                </td>
            </tr>
        </table>
        <CR:CrystalReportViewer ID="StudentSMSNumberReport" runat="server" AutoDataBind="True"
            EnableDatabaseLogonPrompt="False" ToolPanelView="None" GroupTreeImagesFolderUrl=""
            Height="50px" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="350px"
            EnableParameterPrompt="False" />
        <%--<CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
             <Report FileName="~\Reports\StudentListWithSMSNumber.rpt">
             </Report>
         </CR:CrystalReportSource>--%>
    </fieldset>
</asp:Content>
