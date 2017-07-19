<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="studentAttendanceUpdate.aspx.cs" Inherits="Student_Attendence_studentAttendanceUpdate" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1 {
            height: 97px;
            width: 714px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <fieldset>
        <legend>Student Attendence Sheet</legend>



        <table class="style1">
            <tr>
                <td class="style2">
                    Class Name</td>
                <td class="style3">
                    <asp:DropDownList ID="drpClass" runat="server" DataSourceID="SqlDataSource1" 
                                      AppendDataBoundItems="true"    DataTextField="VarClassName" 
                                      DataValueField="VarClassID" AutoPostBack="True" >
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT * FROM [Class]"></asp:SqlDataSource>
                </td>
                <td class="style4">
                    Section Name</td>
                <td class="style5">
                    <asp:DropDownList ID="drpSection" runat="server" DataSourceID="SqlDataSource2" 
                                      AppendDataBoundItems="true"  DataTextField="varSectionName" DataValueField="sectionId">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT [varSectionName], [sectionId] FROM [tblSection]">
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Shift Name</td>
                <td class="style3">
                    <asp:DropDownList ID="drpShift" runat="server" DataSourceID="SqlDataSource3" 
                                      AppendDataBoundItems="true"  DataTextField="VarShiftName" 
                                      DataValueField="VarShiftCode" AutoPostBack="True">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT * FROM [ShiftInfo]"></asp:SqlDataSource>
                </td>
                <td class="style4">
                    Date</td>
                <td class="style5">
                    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                          Enabled="True" TargetControlID="txtDate">
                    </cc1:CalendarExtender>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                      DataSourceID="SqlDataSource4" AllowPaging="True" AllowSorting="True" 
                      DataKeyNames="VarStudentID" style="margin-right: 2px">
            <Columns>
                <%--<asp:BoundField DataField="VarClassID" HeaderText="VarClassID" 
                  ReadOnly="True" SortExpression="VarClassID" />
                  
                  <asp:BoundField DataField="sectionId" HeaderText="sectionId" 
                   SortExpression="sectionId" />--%>
                <%--<asp:BoundField DataField="varShiftId" HeaderText="varShiftId" 
                  SortExpression="varShiftId" />--%>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="VarStudentID" HeaderText="VarStudentID" 
                                ReadOnly="True" SortExpression="VarStudentID" />
                <asp:CheckBoxField DataField="present" HeaderText="Present" />
                <asp:CheckBoxField DataField="late" HeaderText="Late" />
                <asp:CheckBoxField DataField="absent" HeaderText="Absent" />
                <asp:BoundField DataField="classDate" HeaderText="classDate" 
                                SortExpression="classDate" />
                <asp:BoundField DataField="inTime" HeaderText="inTime" 
                                SortExpression="inTime" />
                <asp:BoundField DataField="outTime" HeaderText="outTime" 
                                SortExpression="outTime" />
                <asp:BoundField DataField="comments" HeaderText="comments" 
                                SortExpression="comments" />
            </Columns>


        </asp:GridView>
    
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                           ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
        
        
        
        
                           SelectCommand="SELECT * FROM [tbl_Student_attendance] WHERE (([classDate] = @classDate) AND ([VarClassID] = @VarClassID) AND ([varShiftId] = @varShiftId))" 
                           DeleteCommand="DELETE FROM [tbl_Student_attendance] WHERE [VarStudentID] = @VarStudentID" 
                           InsertCommand="INSERT INTO [tbl_Student_attendance] ([VarStudentID], [VarClassID], [sectionId], [inTime], [outTime], [comments], [present], [late], [absent], [classDate], [varShiftId]) VALUES (@VarStudentID, @VarClassID, @sectionId, @inTime, @outTime, @comments, @present, @late, @absent, @classDate, @varShiftId)" 
        
                           UpdateCommand="UPDATE [tbl_Student_attendance] SET  [inTime] = @inTime, [outTime] = @outTime, [comments] = @comments, [present] = @present, [late] = @late, [absent] = @absent, [classDate] = @classDate WHERE [VarStudentID] = @VarStudentID">
            <DeleteParameters>
                <asp:Parameter Name="VarStudentID" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="VarStudentID" Type="String" />
                <asp:Parameter Name="VarClassID" Type="Int32" />
                <asp:Parameter Name="sectionId" Type="Int32" />
                <asp:Parameter Name="inTime" Type="String" />
                <asp:Parameter Name="outTime" Type="String" />
                <asp:Parameter Name="comments" Type="String" />
                <asp:Parameter Name="present" Type="String" />
                <asp:Parameter Name="late" Type="String" />
                <asp:Parameter Name="absent" Type="String" />
                <asp:Parameter DbType="Date" Name="classDate" />
                <asp:Parameter Name="varShiftId" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="txtDate" Name="classDate" 
                                      PropertyName="Text" DbType="Date" />
                <asp:ControlParameter ControlID="drpClass" Name="VarClassID" 
                                      PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="drpShift" Name="varShiftId" 
                                      PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="VarClassID" Type="Int32" />
                <asp:Parameter Name="sectionId" Type="Int32" />
                <asp:Parameter Name="inTime" Type="String" />
                <asp:Parameter Name="outTime" Type="String" />
                <asp:Parameter Name="comments" Type="String" />
                <asp:Parameter Name="present" Type="String" />
                <asp:Parameter Name="late" Type="String" />
                <asp:Parameter Name="absent" Type="String" />
                <asp:Parameter DbType="Date" Name="classDate" />
                <asp:Parameter Name="varShiftId" Type="String" />
                <asp:Parameter Name="VarStudentID" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>




        <br />
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </fieldset>
</asp:Content>