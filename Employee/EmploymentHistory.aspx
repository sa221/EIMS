<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EmploymentHistory.aspx.cs" Inherits="Employee_EmploymentHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <fieldset>
        <legend><b>
                    <h2>
                        Employee Employment History</h2>
                </b></legend>
        <table class="style1">
            <tr>
                <td class="style4">
                    Employee ID
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtEmpId" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Employee Serial No
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtEmpSlNo" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Organization Name
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtOrgName" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Organization Address
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtOrgAdd" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Organization Contact
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtOrgContact" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Employee Designation ID
                </td>
                <td class="style3">
                    <asp:DropDownList ID="dropDownDegId" runat="server" 
                                      DataSourceID="SqlDataSource1" DataTextField="VarDesignationName" 
                                      DataValueField="NumDesignationId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT * FROM [Designation]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Employee Duty Responsibility
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtDutyResp" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Job Duration
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtJobDur" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Job Start Date
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtJobStart" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Job End Date
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtJobEnd" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Leave Note
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtLeaveNote" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Button ID="empEmploymentHistorySave" runat="server" Text="Save" Width="81px" 
                                OnClientClick=" return validate(); " onclick="empEmploymentHistorySave_Click" 
                        />
                </td>
                <td class="style3">
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    
                </td>
            </tr>

        </table>
    </fieldset>
</asp:Content>