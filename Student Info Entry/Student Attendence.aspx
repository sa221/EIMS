<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Student Attendence.aspx.cs" Inherits="Student_Attendence_Student_Attendence" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1 { width: 100%; }

        .style2 { width: 132px; }

        .style3 { width: 140px; }

        .style4 { width: 151px; }

        .style5 { width: 296px; }
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
                                      DataValueField="VarClassID" AutoPostBack="True" 
                                      onselectedindexchanged="drpClass_SelectedIndexChanged">
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
        <br />
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                      DataSourceID="SqlDataSource4" AllowPaging="True" 
            >
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:TemplateField HeaderText="Student ID" SortExpression="VarStudentID">
                
                    <ItemTemplate>
                        <asp:TextBox ID="txtstudId" runat="server" Text='<%# Eval("VarStudentID") %>' 
                                     ReadOnly="True"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Attendence" SortExpression="present">
                 
                    <ItemTemplate>
                        <asp:CheckBox ID="chkPresent" runat="server" Text="Present" />
                        <br />
                        <asp:CheckBox ID="chkAbsent" runat="server" Text="Absent" />
                        <br />
                        <asp:CheckBox ID="chkLate" runat="server" Text="Late" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="inTime" SortExpression="inTime">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtInTime" runat="server" Text='<%# Eval("inTime") %>'></asp:TextBox>
                    </EditItemTemplate>
             
                
                    <ItemTemplate>
                        <asp:TextBox ID="txtInTime" runat="server"></asp:TextBox>
                        <cc1:NumericUpDownExtender ID="NumericUpDownExtender" runat="server" 
                                                   targetcontrolid="txtInTime"  width="60" 
                                                   refvalues="00;01;02;03;04;05;06;07;08;09;10;11;12"
                                                   servicedownmethod="" 
                                                   serviceupmethod="" 
                                                   targetbuttondownid="" 
                                                   targetbuttonupid="" />
             
                     

                        <asp:TextBox ID="txtMin1" runat="server"></asp:TextBox>
                        <cc1:NumericUpDownExtender ID="NumericUpDownExtender1" runat="server" 
                                                   targetcontrolid="txtMin1"  width="60" 
                                                   refvalues="00;01;02;03;04;05;06;07;08;09;10;11;12;13;14;15;16;17;18;19;20;21;22;23;24;25;26;27;28;29;30;31;32;33;34;35;36;37;38;39;40;41;42;43;44;45;46;47;48;49;50;51;52;53;54;55;56;57;58;59;60"
                                                   servicedownmethod="" 
                                                   serviceupmethod="" 
                                                   targetbuttondownid="" 
                                                   targetbuttonupid="" />
             
                        <asp:TextBox ID="txtAmPm" runat="server"></asp:TextBox>
                        <cc1:NumericUpDownExtender ID="NumericUpDownExtender2" runat="server" 
                                                   targetcontrolid="txtAmPm"  width="60" 
                                                   refvalues="AM;PM"
                                                   servicedownmethod="" 
                                                   serviceupmethod="" 
                                                   targetbuttondownid="" 
                                                   targetbuttonupid="" />
                 
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="outTime" SortExpression="outTime">
                    <EditItemTemplate>
                        <asp:TextBox ID="outTime" runat="server" Text='<%# Eval("outTime") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="outTime" runat="server"></asp:TextBox>
                        <cc1:NumericUpDownExtender ID="TextBox1_NumericUpDownExtender" runat="server" 
                                                   targetcontrolid="outTime"  width="60" 
                                                   refvalues="00;01;02;03;04;05;06;07;08;09;10;11;12"
                                                   servicedownmethod="" 
                                                   serviceupmethod="" 
                                                   targetbuttondownid="" 
                                                   targetbuttonupid="" />

                        <asp:TextBox ID="TextBoxminout" runat="server"></asp:TextBox>
                        <cc1:NumericUpDownExtender ID="NumericUpDownExtender5" runat="server" 
                                                   targetcontrolid="TextBoxminout"  width="60" 
                                                   refvalues="00;01;02;03;04;05;06;07;08;09;10;11;12;13;14;15;16;17;18;19;20;21;22;23;24;25;26;27;28;29;30;31;32;33;34;35;36;37;38;39;40;41;42;43;44;45;46;47;48;49;50;51;52;53;54;55;56;57;58;59;60"
                                                   servicedownmethod="" 
                                                   serviceupmethod="" 
                                                   targetbuttondownid="" 
                                                   targetbuttonupid="" />
                        <asp:TextBox ID="TextBoxamout" runat="server"></asp:TextBox>
                        <cc1:NumericUpDownExtender ID="NumericUpDownExtender4" runat="server" 
                                                   targetcontrolid="TextBoxamout"  width="60" 
                                                   refvalues="AM;PM"
                                                   servicedownmethod="" 
                                                   serviceupmethod="" 
                                                   targetbuttondownid="" 
                                                   targetbuttonupid="" />

                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Comments" SortExpression="comments">
                    <ItemTemplate>
                        <asp:TextBox ID="txtComments" runat="server" Height="50px" TextMode="MultiLine" 
                                     Width="165px"></asp:TextBox>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtComments" runat="server" Text='<%# Eval("comments") %>' TextMode="MultiLine"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>


        </asp:GridView>
    
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                           ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
        
        
        
        
        
                           SelectCommand="SELECT Student.VarBranchID, Student.VarRegistrationID, Student.VarSessionName, Student.VarShiftCode, Student.VarStudentID, Student.VarStudentFirstName, Student.VarStudentMeddleName, Student.VarStudentLastName, Student.VarStudentGender, Student.VarStudentBirth, Student.VarStudentNationality, Student.VarStudenAddress, Student.VarStudenHomePhone, Student.VarStudenHomeCell, Student.VarReligion, Student.VarFatherName, Student.VarFatherOccupation, Student.VarFatherOfficeAddress, Student.VarFatherMobile, Student.VarFatherEmail, Student.VarMotherName, Student.VarMotherOccupation, Student.VarMotherOfficeAddress, Student.VarMotherMobile, Student.VarMotherEmail, Student.VarSiblingYesNo, Student.VarSiblingName, Student.VarSiblingShift, Student.VarSiblingClass, Student.VarSiblingSection, Student.VarSiblingRoll, Student.VarPreviousSchoolAttended, Student.VarPrivateYes, Student.VarPrincipalRemarks, Student.RecommendAdmissionClass, Student.RecommendDate, Student.BloodGroup, tbl_Student_attendance.VarStudentID AS Expr1, tbl_Student_attendance.VarClassID, tbl_Student_attendance.sectionId, tbl_Student_attendance.inTime, tbl_Student_attendance.outTime, tbl_Student_attendance.comments, tbl_Student_attendance.present, tbl_Student_attendance.late, tbl_Student_attendance.absent, tbl_Student_attendance.classDate, tbl_Student_attendance.VarShiftCode AS Expr3, tbl_Student_attendance.VarBranchId AS Expr2, tbl_Student_attendance.uid FROM tbl_Student_attendance RIGHT OUTER JOIN Student ON tbl_Student_attendance.VarStudentID = Student.VarStudentID WHERE (Student.RecommendAdmissionClass = @RecommendAdmissionClass) AND (tbl_Student_attendance.VarShiftCode = @VarShiftCode)">
            <SelectParameters>
                <asp:ControlParameter ControlID="drpClass" Name="RecommendAdmissionClass" 
                                      PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="drpShift" Name="VarShiftCode" 
                                      PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>




        <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
    
        <br />
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </fieldset>
    
   
   

</asp:Content>