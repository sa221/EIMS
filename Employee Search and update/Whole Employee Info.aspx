<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Whole Employee Info.aspx.cs" Inherits="Employee_Whole_Employee_Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <fieldset>
        <legend><b>Employee Information</b></legend>

        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch"
                    runat="server" Text="Search" onclick="btnSearch_Click" />
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <br />
        <asp:ListView ID="ListView1" runat="server" DataKeyNames="VarEmployeeid" 
                      DataSourceID="SqlDataSource1" onitemcommand="ListView1_ItemCommand">
        
     
        
            <ItemTemplate>
                <tr style="background-color: #DCDCDC; color: #000000;">
                    <td>
               
                        <asp:Label ID="VarEmployeeidLabel" runat="server" 
                                   Text='<%# Eval("VarEmployeeid") %>' />
                    </td>
                    <td>
                        <asp:Label ID="VarEmployeeNameLabel" runat="server" 
                                   Text='<%# Eval("VarEmployeeName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="VarEmployeePhoneNoLabel" runat="server" 
                                   Text='<%# Eval("VarEmployeePhoneNo") %>' />
                    </td>
                    <td>
                        <asp:Label ID="VarDesignationNameLabel" runat="server" 
                                   Text='<%# Eval("VarDesignationName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DatJoiningdateLabel" runat="server" 
                                   Text='<%# Eval("DatJoiningdate") %>' />
                    </td>
                    <td>
                        <asp:Label ID="VarBranchIdLabel" runat="server" 
                                   Text='<%# Eval("VarBranchName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" 
                                   Text='<%# Eval("VarShiftCode") %>' />
                    </td>
                    <td> <td> <asp:LinkButton ID="LinkButton1" runat="server" CommandName="cmd" Font-Size="Medium" ForeColor="Red">See More</asp:LinkButton></td></td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table id="Table1" runat="server">
                    <tr id="Tr1" runat="server">
                        <td id="Td1" runat="server">
                            <table ID="itemPlaceholderContainer" runat="server" border="1" 
                                   style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr id="Tr2" runat="server" style="background-color: #DCDCDC; color: #000000;">
                                    <th id="Th1" runat="server">
                                        Employee Id</th>
                                    <th id="Th2" runat="server">
                                        Employee Name</th>
                                    <th id="Th3" runat="server">
                                        Employee Phone No</th>
                                    <th id="Th4" runat="server">
                                        Designation Name</th>
                                    <th id="Th5" runat="server">
                                        Joining date</th>
                                    <th id="Th6" runat="server">
                                        Branch Name</th>
                                    <th id="Th7" runat="server">
                                        Shift Name</th>
                                </tr>
                                <tr runat="server" ID="itemPlaceholder">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="Tr3" runat="server">
                        <td id="Td2" runat="server" 
                            style="background-color: #CCCCCC; color: #000000; font-family: Verdana, Arial, Helvetica, sans-serif; text-align: center;">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                                                ShowLastPageButton="True" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
       
       
       
        </asp:ListView>



        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                           ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
        
        
        
        
        
        
                           SelectCommand="SELECT Employee.VarEmployeeid, Employee.VarEmployeeName, Employee.VarEmployeePhoneNo, Designation.VarDesignationName, Employee.DatJoiningdate, Branch.VarBranchName, ShiftInfo.VarShiftCode FROM Employee INNER JOIN Designation ON Employee.NumDesignationid = Designation.NumDesignationId INNER JOIN Branch ON Employee.VarBranchId = Branch.VarBranchID INNER JOIN ShiftInfo ON ShiftInfo.VarShiftCode = Employee.VarShiftCode WHERE (Employee.VarEmployeeName = @VarEmployeeName) OR (Employee.VarEmployeeid = @VarEmployeeid)">
            <SelectParameters>
       
                <asp:ControlParameter ControlID="TextBox1" Name="VarEmployeeName" 
                                      PropertyName="Text" Type="String" />
            </SelectParameters>
            <SelectParameters>
       
                <asp:ControlParameter ControlID="TextBox1" Name="VarEmployeeid" 
                                      PropertyName="Text" Type="String" />
            </SelectParameters>
    
      
        </asp:SqlDataSource>

    </fieldset>
</asp:Content>