<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EmployeeAttendanceUpdate.aspx.cs" Inherits="Employee_EmployeeAttendanceUpdate" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <fieldset>
        <legend>Student Attendence Sheet</legend>



   
        <table class="style1">
            <tr>
                <td>
                    Attendance Date</td>
                <td>
                    <asp:TextBox ID="txtdate" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" 
                                          Enabled="True" TargetControlID="txtdate">
                    </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td>
                    Employee Designation</td>
                <td>


                    <asp:DropDownList ID="drpDesgnation" runat="server" 
                                      AppendDataBoundItems="true"   DataSourceID="SqlDataSource1" DataTextField="VarDesignationName" 
                                      DataValueField="NumDesignationId" AutoPostBack="True">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT * FROM [Designation]"></asp:SqlDataSource>

                </td>
            </tr>
        </table>

        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                      AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="VarEmployeeid" 
                      DataSourceID="SqlDataSource2" Height="228px" Width="479px">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="VarEmployeeid" HeaderText="VarEmployeeid" 
                                ReadOnly="True" SortExpression="VarEmployeeid" />
                <asp:BoundField DataField="VarEmployeeName" HeaderText="VarEmployeeName" 
                                ReadOnly="True" SortExpression="VarEmployeeName" />
         
                <asp:BoundField DataField="AttendDate" HeaderText="AttendDate" 
                                SortExpression="AttendDate" />
                <asp:CheckBoxField DataField="present" HeaderText="Present" />
                <asp:CheckBoxField DataField="late" HeaderText="Late" />
                <asp:CheckBoxField DataField="absent" HeaderText="Absent" />
                <asp:BoundField DataField="In_Time" HeaderText="In_Time" 
                                SortExpression="In_Time" />
                <asp:BoundField DataField="Out_Time" HeaderText="Out_Time" 
                                SortExpression="Out_Time" />
                <asp:BoundField DataField="Comments" HeaderText="Comments" 
                                SortExpression="Comments" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                           ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                           DeleteCommand="DELETE FROM [tbl_employee_attendence] WHERE [VarEmployeeid] = @VarEmployeeid" 
                           InsertCommand="INSERT INTO [tbl_employee_attendence] ([VarEmployeeid], [VarEmployeeName], [NumDesignationid], [AttendDate], [In_Time], [Out_Time], [Comments], [present], [absent], [late]) VALUES (@VarEmployeeid, @VarEmployeeName, @NumDesignationid, @AttendDate, @In_Time, @Out_Time, @Comments, @present, @absent, @late)" 
                           SelectCommand="SELECT * FROM [tbl_employee_attendence] WHERE (([NumDesignationid] = @NumDesignationid) AND ([AttendDate] = @AttendDate))" 
                           UpdateCommand="UPDATE [tbl_employee_attendence] SET [AttendDate] = @AttendDate, [In_Time] = @In_Time, [Out_Time] = @Out_Time, [Comments] = @Comments, [present] = @present, [absent] = @absent, [late] = @late WHERE [VarEmployeeid] = @VarEmployeeid">
            <DeleteParameters>
                <asp:Parameter Name="VarEmployeeid" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="VarEmployeeid" Type="Int32" />
                <asp:Parameter Name="VarEmployeeName" Type="String" />
                <asp:Parameter Name="NumDesignationid" Type="Int32" />
                <asp:Parameter DbType="Date" Name="AttendDate" />
                <asp:Parameter Name="In_Time" Type="String" />
                <asp:Parameter Name="Out_Time" Type="String" />
                <asp:Parameter Name="Comments" Type="String" />
                <asp:Parameter Name="present" Type="String" />
                <asp:Parameter Name="absent" Type="String" />
                <asp:Parameter Name="late" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="drpDesgnation" Name="NumDesignationid" 
                                      PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="txtdate" DbType="Date" Name="AttendDate" 
                                      PropertyName="Text" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="VarEmployeeName" Type="String" />
                <asp:Parameter Name="NumDesignationid" Type="Int32" />
                <asp:Parameter DbType="Date" Name="AttendDate" />
                <asp:Parameter Name="In_Time" Type="String" />
                <asp:Parameter Name="Out_Time" Type="String" />
                <asp:Parameter Name="Comments" Type="String" />
                <asp:Parameter Name="present" Type="String" />
                <asp:Parameter Name="absent" Type="String" />
                <asp:Parameter Name="late" Type="String" />
                <asp:Parameter Name="VarEmployeeid" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </fieldset>
</asp:Content>