<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="ReportsUI_Default2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <%--<script language="JavaScript" type="text/javascript">
        $(document).ready(function () {
            $("#MainContent_dateTextBox").datepicker({
                autoclose: true,
                todayHighlight: true
            });
        });

    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table>
        <tr>
            <td>
                <b>From ID:
                    <asp:TextBox ID="fromIdTextBox" runat="server"></asp:TextBox></b>
            </td>
            <td>
                <b>Date:</b>
                <asp:TextBox ID="txtdob" runat="server" Width="226px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="txtdob">
                </cc1:CalendarExtender>
                <br />
                   
            </td>
        </tr>
    </table>
</asp:Content>