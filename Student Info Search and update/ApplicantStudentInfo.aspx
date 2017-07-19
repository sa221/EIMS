<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ApplicantStudentInfo.aspx.cs" Inherits="ApplicantStudentInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="varRegistrationId" 
                  DataSourceID="SqlDataSource1" onitemcommand="ListView1_ItemCommand">
       
        <ItemTemplate>
            <tr style="background-color: #DCDCDC; color: #000000;">
                <td>
                    <asp:Label ID="varRegistrationIdLabel" runat="server" 
                               Text='<%# Eval("varRegistrationId") %>' />
                </td>
                <td>
                    <asp:Label ID="varStudentNameLabel" runat="server" 
                       
                               Text='<%#  Eval("varStudentFirstName") + " " + Eval("varStudentMiddleName") + " " + Eval("varStudentLastName") %>' />

                </td>
                <td>
                    <asp:Label ID="VarClassName" runat="server" 
                               Text='<%# Eval("VarClassName") %>' />
                </td>
                <td>
                    <asp:Label ID="EmergencyPhoneLabel" runat="server" 
                               Text='<%# Eval("EmergencyPhone") %>' />
                </td>
                <td> <asp:LinkButton ID="LinkButton1" runat="server" CommandName="cmd" Font-Size="Medium" ForeColor="Red">See More</asp:LinkButton></td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table ID="itemPlaceholderContainer" runat="server" border="1" 
                               style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                                <th runat="server">
                                    Registration Id</th>
                                <th runat="server">
                                    Student Name</th>
                                <th runat="server">
                                    Admission For Class</th>
                                <th runat="server">
                                    Emergency Phone No</th>
                            </tr>
                            <tr ID="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" 
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
        
                       SelectCommand="SELECT ParticipantStudent.varRegistrationId, ParticipantStudent.varStudentFirstName, ParticipantStudent.varStudentMiddleName, ParticipantStudent.varStudentLastName, Class.VarClassName, ParticipantStudent.EmergencyPhone FROM ParticipantStudent INNER JOIN Class ON Class.VarClassID = ParticipantStudent.admissionForClass">
    </asp:SqlDataSource>
</asp:Content>