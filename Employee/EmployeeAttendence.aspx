<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EmployeeAttendence.aspx.cs" Inherits="Employee_EmployeeAttendence" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1 { width: 100%; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <fieldset>
        <legend><b>Employee Attendance</b></legend>


        <table class="style1">
            <tr>
                <td>
                    Attendance Date</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" 
                                          Enabled="True" TargetControlID="TextBox1">
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
        <br />

        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                      DataKeyNames="VarEmployeeid" DataSourceID="SqlDataSource2">
            <Columns>
            
                <asp:TemplateField HeaderText="Employee ID" SortExpression="VarEmployeeid">
                
                    <ItemTemplate>
                        <asp:TextBox ID="txtEmployeeid" runat="server" Text='<%# Eval("VarEmployeeid") %>' 
                                     ReadOnly="True"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            

                <asp:TemplateField HeaderText="Employee Name" SortExpression="VarEmployeeName">
                
                    <ItemTemplate>
                        <asp:TextBox ID="txtEmployeename" runat="server" Text='<%# Eval("VarEmployeeName") %>' 
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
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                           ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                           SelectCommand="SELECT [VarEmployeeid], [VarEmployeeName], [NumDesignationid] FROM [Employee] WHERE ([NumDesignationid] = @NumDesignationid)">
            <SelectParameters>
                <asp:ControlParameter ControlID="drpDesgnation" Name="NumDesignationid" 
                                      PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>

        <br />

        <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
    
        <br />
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </fieldset>
</fieldset>
</asp:Content>