<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Tabulation_OLevel.aspx.cs" Inherits="ReportsUI_Tabulation_OLevel" %>

<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <legend>
            <h1>
                Tabulation Sheet</h1>
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
                    <b>Class:</b>
                    <br />
                    <asp:DropDownList ID="classDropDownList" runat="server" AutoPostBack="True" AppendDataBoundItems="True"
                        DataSourceID="getClass" DataTextField="VarClassName" DataValueField="VarClassID"
                        OnSelectedIndexChanged="classDropDownList_SelectedIndexChanged">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getClass" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [VarClassID], [VarClassName] FROM [Class]"></asp:SqlDataSource>
                </td>
                <td>
                    <b>Section:</b>
                    <br />
                    <asp:DropDownList ID="sectionDropDownList" runat="server" AppendDataBoundItems="True"
                        DataSourceID="getSection" DataTextField="varSectionName" DataValueField="SectionId">
                        <asp:ListItem Value="0">--ALL--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getSection" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [SectionId], [varSectionName] FROM [tblSection] WHERE ([ClassID] = @ClassID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="classDropDownList" Name="ClassID" PropertyName="SelectedValue"
                                Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    <b>Exam Name:</b>
                    <br />
                    <asp:DropDownList ID="examNameDropDownList" runat="server" DataSourceID="getExamName"
                        DataTextField="ExamName" DataValueField="ExamCode">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getExamName" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [ExamCode], [ExamName] FROM [tbl_ExamName]"></asp:SqlDataSource>
                </td>
                <td>
                    <br />
                    <asp:Button ID="showButton" runat="server" Text="Show" OnClick="showButton_Click" />
                </td>
            </tr>
        </table>
        <CR:CrystalReportViewer ID="TotalStudent" runat="server" AutoDataBind="true" EnableParameterPrompt="False"
            ToolPanelView="None" />
    </fieldset>
</asp:Content>
