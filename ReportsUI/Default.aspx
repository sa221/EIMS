<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ReportsUI_Default" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        #CrystalReportViewer1 { z-index: 1; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <fieldset>
        <legend><h1>Student List</h1></legend>
        <table>
            <tr>
                <td>Session:
                    <br/>
                    <asp:DropDownList ID="sessionDropDownList" runat="server" 
                                      DataSourceID="SqlDataSource1" DataTextField="VarSessionName" 
                                      DataValueField="VarSessionId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo] ORDER BY [VarSessionName] DESC">
                    </asp:SqlDataSource>
                </td>
                <td>
                    Class:<br/>
                    <asp:DropDownList ID="classDropDownList" runat="server" AppendDataBoundItems="True" 
                                      DataSourceID="SqlDataSource2" DataTextField="VarClassName" 
                                      DataValueField="VarClassID" AutoPostBack="True">
                        <asp:ListItem Selected="True" Value="0">--Class--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT [VarClassID], [VarClassName] FROM [Class]">
                    </asp:SqlDataSource>
                </td>
                <td>
                    Section:
                    <br/>
                    <asp:DropDownList ID="sectionDropDownList" runat="server" 
                                      DataSourceID="SqlDataSource3" DataTextField="varSectionName" 
                                      DataValueField="SectionId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT [SectionId], [varSectionName], [ClassID] FROM [tblSection] WHERE ([ClassID] = @ClassID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="classDropDownList" Name="ClassID" 
                                                  PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td><br />
                    <asp:Button ID="searchButton" runat="server" Text="Search" 
                                onclick="searchButton_Click" />
                </td>
            </tr>
        </table>

        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" style="position: relative; z-index: 0;"
                                AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="1202px" 
                                ReportSourceID="CrystalReportSource1" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="1104px" EnableDatabaseLogonPrompt="False" ToolPanelView="None" />

        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="~\Reports\CrystalReport.rpt">
            </Report>
        </CR:CrystalReportSource>

    </fieldset>
</asp:Content>