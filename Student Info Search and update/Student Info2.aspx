<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Student Info2.aspx.cs" Inherits="Student_Info2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <fieldset>
        <legend><b>SHow All Student</b></legend>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                          DataSourceID="SqlDataSource2" DataTextField="VarClassName" 
                          DataValueField="VarClassID" AppendDataBoundItems="true">
            <asp:ListItem Value="0">--SELECT--</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                           ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                           SelectCommand="SELECT * FROM [Class]"></asp:SqlDataSource>
        <asp:TextBox ID="txtsearch" runat="server"></asp:TextBox><asp:Button ID="btnsearch"
                                                                             runat="server" Text="Search" />
        <br />
        <br />
        <asp:ListView ID="ListView1" runat="server" DataKeyNames="VarStudentID" 
                      DataSourceID="SqlDataSource1" onitemcommand="ListView1_ItemCommand1">
      
       
      
            <ItemTemplate>
                <tr style="background-color: #FFFBD6; color: #333333;">
                    <td>
                        <asp:Label ID="VarRegistrationIDLabel" runat="server" 
                                   Text='<%# Eval("VarRegistrationID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="VarStudentIDLabel" runat="server" 
                                   Text='<%# Eval("VarStudentID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="VarShiftNameLabel" runat="server" 
                                   Text='<%# Eval("VarShiftName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Student_NameLabel" runat="server" 
                                   Text='<%# Eval("[Student Name]") %>' />
                    </td>
                    <td>
                        <asp:Label ID="VarClassNameLabel" runat="server" 
                                   Text='<%# Eval("VarClassName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="VarSessionNameLabel" runat="server" 
                                   Text='<%# Eval("VarSessionName") %>' />
                    </td>
                    <td> <td> <asp:LinkButton ID="LinkButton1" runat="server" CommandName="cmd" Font-Size="Medium" ForeColor="Red">See More</asp:LinkButton></td></td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table ID="itemPlaceholderContainer" runat="server" border="1" 
                                   style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr runat="server" style="background-color: #FFFBD6; color: #333333;">
                                    <th runat="server">
                                        Registration ID</th>
                                    <th runat="server">
                                        Student ID</th>
                                    <th runat="server">
                                        Shift Name</th>
                                    <th runat="server">
                                        Student Name</th>
                                    <th runat="server">
                                        Class Name</th>
                                    <th runat="server">
                                        Session Name</th>
                                </tr>
                                <tr runat="server" ID="itemPlaceholder">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" 
                            style="background-color: #FFCC66; color: #333333; font-family: Verdana, Arial, Helvetica, sans-serif; text-align: center;">
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
        
                           SelectCommand="SELECT Student.VarRegistrationID, Student.VarStudentID, ShiftInfo.VarShiftName, Student.VarStudentFirstName + '  ' + Student.VarStudentMeddleName + ' ' + Student.VarStudentLastName AS [Student Name], Class.VarClassName, SessionInfo.VarSessionName FROM Student INNER JOIN StudentDoc ON Student.VarRegistrationID = StudentDoc.VarRegistrationID INNER JOIN ShiftInfo ON ShiftInfo.VarShiftCode = Student.VarShiftCode INNER JOIN SessionInfo ON SessionInfo.VarSessionId = Student.VarSessionName INNER JOIN Class ON Student.RecommendAdmissionClass = Class.VarClassID WHERE (Student.VarStudentID = @VarStudentID) OR (Class.VarClassName = @VarClassName)">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtsearch" Name="VarStudentID" 
                                      PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="DropDownList1" Name="VarClassName" 
                                      PropertyName="SelectedValue" Type="Int32"/>
            </SelectParameters>
        </asp:SqlDataSource>

    </fieldset>
</asp:Content>