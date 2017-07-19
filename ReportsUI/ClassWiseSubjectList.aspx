<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ClassWiseSubjectList.aspx.cs" Inherits="ReportsUI_ClassWiseSubjectList" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
             Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <fieldset>
        <legend><b>
                    <h2>
                        Class Wise Subject List</h2>
                </b></legend>
        <table class="style1">
            <tr>
                <td>
                    <b>Select Class:</b>
                </td>
                <td>
                    <asp:DropDownList ID="classDropDownList" runat="server" AppendDataBoundItems="True"
                                      DataSourceID="SqlDataSource1" DataTextField="VarClassName" 
                                      DataValueField="VarClassID" 
                                      onselectedindexchanged="classDropDownList_SelectedIndexChanged" 
                                      AutoPostBack="True">
                        <asp:ListItem Selected="True" Value="0">--Class--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT * FROM [Class]"></asp:SqlDataSource>
                </td>
            </tr>
            
            
        </table>
        <div>
            <CR:CrystalReportViewer ID="SubjectList" runat="server" AutoDataBind="true" 
                                    EnableParameterPrompt="False" ToolPanelView="None" />
        </div>
    </fieldset>
</asp:Content>