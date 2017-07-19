<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeFile="EmployeeTraining.aspx.cs" Inherits="Employee_EmployeeTraining" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <%--<script>
    $(function () {
        $("#MainContent_txtTrainStart").datepicker();

    });
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <legend><b>
                    <h2>
                        Employee Training</h2>
                </b></legend>
        <table class="style1">
            <tr>
                <td class="style4">
                    User Name</td>
                <td class="style3">
                    <asp:TextBox ID="Textuid" runat="server" Text='<%# Session["uid"] %>' 
                                 ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Branch Name
                </td>
                <td class="style3">
                    <asp:DropDownList ID="DropDownBranch" runat="server" 
                                      DataSourceID="SqlDataSource1" DataTextField="VarBranchName" 
                                      DataValueField="VarBranchID" Enabled="False">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT * FROM [Branch]"></asp:SqlDataSource>
                </td>
                <td> Shift Name</td>
                <td>
                    <asp:DropDownList ID="drpshift" runat="server" DataSourceID="SqlDataSource4" 
                                      DataTextField="VarShiftName" DataValueField="VarShiftCode" Enabled="False">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT * FROM [ShiftInfo]"></asp:SqlDataSource>
                </td>
            </tr>
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
                    Training Titles
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtTrainingTit" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Training Duration
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtTrainDur" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Training Start Date
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtTrainStart" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Training End Date
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtTrainEnd" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Training Achievment
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtTrainAchiv" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Button ID="empTrainingSave" runat="server" Text="Save" Width="81px" 
                                OnClientClick=" return validate(); "   
                        />
                </td>
                <td class="style3">
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    
                </td>
            </tr>
        </table>
    </fieldset>
    <br />
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
</asp:Content>