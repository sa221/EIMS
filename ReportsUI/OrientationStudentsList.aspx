<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="OrientationStudentsList.aspx.cs" Inherits="ReportsUI_OrientationStudentsList" %>
<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <fieldset>
        <legend>
            <h1>
                Student List</h1>
        </legend>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
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
                        <td>
                            Time:
                            <br />
                            <asp:TextBox ID="timeTextBox" runat="server"></asp:TextBox>
                        </td>
                       
                        <td>
                            
                            <br />
                            <%--<asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />--%>
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
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" Visible="True" AutoDataBind="False"
            Height="1202px" ToolPanelWidth="200px" Width="1104px" EnableDatabaseLogonPrompt="False"
            ToolPanelView="None" />
        <%--  <CR:CrystalReportSource ID="CrystalReportSource1" runat="server" HasCrystalLogo="False" HasRefreshButton="True" HasToggleGroupTreeButton="False" >
           <%-- <Report FileName="~/Reports\StudentListWithRoll.rpt">
            </Report>--%>
        <%--</CR:CrystalReportSource>--%>
    </fieldset>
</asp:Content>

