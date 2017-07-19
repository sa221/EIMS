<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EmployeeEducation.aspx.cs" Inherits="Employee_EmployeeEducation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <fieldset>
        <legend><b>
                    <h2>
                        Employee Education</h2>
                </b></legend>
        <table class="style1">
            <tr>
                <td class="style4">
                    User Name</td>
                <td class="style3">
                    <asp:TextBox ID="Textuid" runat="server" Text='<%# Session["uid"] %>'></asp:TextBox>
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
                    Exam Name
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtEmpExmName" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Exam Year
                </td>
                <td class="style3">
                    <asp:DropDownList ID="dropDownExmYear" runat="server">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Exam Session
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtExmSession" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Exam Pass
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtExmPass" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Exam Result
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtExmResult" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Button ID="Add" runat="server" Text="Add" Width="81px" onclick="Add_Click"  
                        />
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
        </table>
    </fieldset>

    <br />
    <br />
    <asp:GridView ID="addEmployyeEducationGridView" AutoGenerateColumns="False" OnRowDataBound="OnRowDataBound"
                  runat="server" OnRowDeleting="OnRowDeleting" CellPadding="4" ForeColor="#333333"
                  GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="VarEmployeeid" HeaderText="Employee Id" />
            <asp:BoundField DataField="NumSlNo" HeaderText="Serial No" />
            <asp:BoundField DataField="VarExamName" HeaderText="Exam Name" />
            <asp:BoundField DataField="NumExamYear" HeaderText="ExamYear" />
            <asp:BoundField DataField="VarExamSession" HeaderText="Exam Session" />
            <asp:BoundField DataField="VarExamPass" HeaderText="Exam Pass" />
            <asp:BoundField DataField="VarExamResult" HeaderText="Exam Result" />
            <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
    <br />
    <asp:Button ID="empEduSave" runat="server" Text="Save" Width="81px" 
                OnClientClick=" return validate(); " onclick="empEduSave_Click" 
        />
    &nbsp;&nbsp;
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    
    <br />
    <br />
    <br />
                   
    <fieldset>
        <legend><b>
                    <h2>
                        Employee Education Modify</h2>
                    <p>
                        User name :
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" />
                    </p>
                </b></legend>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                      DataKeyNames="Empeduid" DataSourceID="SqlDataSource2">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="VarEmployeeid" HeaderText="VarEmployeeid" 
                                ReadOnly="True" SortExpression="VarEmployeeid" />
                <asp:BoundField DataField="NumSlNo" HeaderText="NumSlNo"  
                                SortExpression="NumSlNo" />
                <asp:BoundField DataField="VarExamName" HeaderText="VarExamName" 
                                SortExpression="VarExamName" />
                <asp:BoundField DataField="NumExamYear" HeaderText="NumExamYear" 
                                SortExpression="NumExamYear" />
                <asp:BoundField DataField="VarExamSession" HeaderText="VarExamSession" 
                                SortExpression="VarExamSession" />
                <asp:BoundField DataField="VarExamPass" HeaderText="VarExamPass" 
                                SortExpression="VarExamPass" />
                <asp:BoundField DataField="VarExamResult" HeaderText="VarExamResult" 
                                SortExpression="VarExamResult" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                           ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                           DeleteCommand="DELETE FROM [EmployeeEducation] WHERE [Empeduid] = @Empeduid" 
                           InsertCommand="INSERT INTO [EmployeeEducation] ([VarEmployeeid], [NumSlNo], [VarExamName], [NumExamYear], [VarExamSession], [VarExamPass], [VarExamResult], [uid], [VarShiftCode], [VarBranchId]) VALUES (@VarEmployeeid, @NumSlNo, @VarExamName, @NumExamYear, @VarExamSession, @VarExamPass, @VarExamResult, @uid, @VarShiftCode, @VarBranchId)" 
                           SelectCommand="SELECT * FROM [EmployeeEducation] WHERE ([VarEmployeeid] = @VarEmployeeid)" 
                           UpdateCommand="UPDATE [EmployeeEducation] SET  [NumSlNo] = @NumSlNo, [VarExamName] = @VarExamName, [NumExamYear] = @NumExamYear, [VarExamSession] = @VarExamSession, [VarExamPass] = @VarExamPass, [VarExamResult] = @VarExamResult WHERE [Empeduid] = @Empeduid">
            <DeleteParameters>
                <asp:Parameter Name="Empeduid" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="VarEmployeeid" Type="Int32" />
                <asp:Parameter Name="NumSlNo" Type="Int32" />
                <asp:Parameter Name="VarExamName" Type="String" />
                <asp:Parameter Name="NumExamYear" Type="String" />
                <asp:Parameter Name="VarExamSession" Type="String" />
                <asp:Parameter Name="VarExamPass" Type="String" />
                <asp:Parameter Name="VarExamResult" Type="String" />
                <asp:Parameter Name="uid" Type="String" />
                <asp:Parameter Name="VarShiftCode" Type="String" />
                <asp:Parameter Name="VarBranchId" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox1" Name="VarEmployeeid" 
                                      PropertyName="Text" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                         
                <asp:Parameter Name="VarExamName" Type="String" />
                <asp:Parameter Name="NumExamYear" Type="String" />
                <asp:Parameter Name="VarExamSession" Type="String" />
                <asp:Parameter Name="VarExamPass" Type="String" />
                <asp:Parameter Name="VarExamResult" Type="String" />
                               
            </UpdateParameters>
        </asp:SqlDataSource>

    </fieldset> 
</asp:Content>