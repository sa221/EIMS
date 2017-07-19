<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="InterviewListReport.aspx.cs" Inherits="ReportsUI.ReportsUiInterviewListReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
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
                        DataSourceID="getAllClass" DataTextField="VarClassName" DataValueField="VarClassID">
                        <%--<asp:ListItem Value="0">--Select--</asp:ListItem>--%>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getAllClass" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [VarClassID], [VarClassName] FROM [Class]"></asp:SqlDataSource>
                </td>
                 <td>
                    <b>Date:</b><br/>
                        <asp:TextBox ID="dateTextBox" runat="server" placehlder="DD-MM-YYYY"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="dateTextBox"
                                          Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender><br/>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="Please Enter Date."
                        ForeColor="red" ControlToValidate="dateTextBox"></asp:RequiredFieldValidator>
                </td>
                <td><b>Slot:</b><br/>
                    <asp:DropDownList ID="interviewDropDown" runat="server" Width="120px" DataSourceID="SqlDataSource15"
                                DataTextField="InterviewSlot" AutoPostBack="False" Enabled="True" DataValueField="Id"
                                AppendDataBoundItems="True" >

                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource15" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                SelectCommand="SELECT [InterviewSlot], [Id] FROM [tbl_InterviewSlot] "></asp:SqlDataSource><br /><br />
                </td>
                <td><b>Time:</b><br/>
                    <asp:DropDownList ID="interviewTimeDropDown" runat="server" Width="80px" DataSourceID="getInterviewTime"
                                DataTextField="InterViewTime" AutoPostBack="False" Enabled="True" DataValueField="Id"
                                AppendDataBoundItems="True" >

                            </asp:DropDownList>
                            <asp:SqlDataSource ID="getInterviewTime" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                SelectCommand="SELECT [InterViewTime], [Id] FROM [tbl_InterviewTime] "></asp:SqlDataSource><br /><br />
                </td>
                <td>
                    <asp:Button ID="showButton" runat="server" Text="Show" 
                        onclick="showButton_Click" />
                </td>
            </tr>
        </table>
        <CR:CrystalReportViewer ID="interviwResultViewer" runat="server" 
            AutoDataBind="true" EnableParameterPrompt="False" ToolPanelView="None" />
    </fieldset>
</asp:Content>
