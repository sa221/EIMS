<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="StudentListWithPhone.aspx.cs" Inherits="ReportsUI_StudentListWithPhone" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
             Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .tdWidth { width: 20%; }
    </style>
    <script type="text/javascript">
        window.onload = function() {
            var scrollY = parseInt('<%= Request.Form["scrollY"] %>');
            if (!isNaN(scrollY)) {
                window.scrollTo(0, scrollY);
            }
        };
        window.onscroll = function() {
            var scrollY = document.body.scrollTop;
            if (scrollY == 0) {
                if (window.pageYOffset) {
                    scrollY = window.pageYOffset;
                } else {
                    scrollY = (document.body.parentElement) ? document.body.parentElement.scrollTop : 0;
                }
            }
            if (scrollY > 0) {
                var input = document.getElementById("scrollY");
                if (input == null) {
                    input = document.createElement("input");
                    input.setAttribute("type", "hidden");
                    input.setAttribute("id", "scrollY");
                    input.setAttribute("name", "scrollY");
                    document.forms[0].appendChild(input);
                }
                input.value = scrollY;
            }
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <fieldset>
        <legend><h1>Student List With Contact Number</h1></legend>
        <table width="100%">
            <tr >
                <td class="tdWidth">
                    <b><i>Class</i></b><br/>
                    <asp:DropDownList ID="classDropDownList" runat="server" AutoPostBack="True" AppendDataBoundItems="True"
                                      DataSourceID="SqlDataSource1" DataTextField="VarClassName" 
                                      DataValueField="VarClassID">
                        <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT [VarClassID], [VarClassName] FROM [Class]">
                    </asp:SqlDataSource>
                </td>
                <td class="tdWidth">
                    <b><i>Section</i></b><br/>
                    <asp:DropDownList ID="sectionDropDownList" runat="server" 
                                      DataSourceID="SqlDataSource2" DataTextField="varSectionName" 
                                      DataValueField="SectionId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT [SectionId], [varSectionName], [ClassID] FROM [tblSection] WHERE ([ClassID] = @ClassID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="classDropDownList" Name="ClassID" 
                                                  PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td class="tdWidth">
                    <asp:Button ID="searchButton" runat="server" Text="Search" 
                                onclick="searchButton_Click" />
                </td>
                <td></td>
                <td></td>
            </tr>
        </table>
        <div align="center">
            <CR:CrystalReportViewer ID="StudentListWithMobileViewer" runat="server" 
                                    AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="50px" 
                                    ReportSourceID="CrystalReportSource1" ToolbarImagesFolderUrl="" 
                                    ToolPanelView="None" ToolPanelWidth="200px" Width="350px" 
                                    EnableDatabaseLogonPrompt="False" />
            <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                <Report FileName="~\Reports\StudentListWithPhone.rpt">
                </Report>
            </CR:CrystalReportSource>
        </div>
    </fieldset>
</asp:Content>