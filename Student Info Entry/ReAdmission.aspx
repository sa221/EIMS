<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeFile="ReAdmission.aspx.cs" Inherits="Student_Info_Entry_ReAdmission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1 { width: 200px; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <legend>
            <h1>
                <b>Re-Admission</b></h1>
        </legend>
        <table>
            <tr>
                <td class="style1">
                    <b>Session Name</b>
                    <br />
                    <asp:DropDownList ID="sessionDropdownlist" runat="server" DataSourceID="SqlDataSource2"
                                      DataTextField="VarSessionName" DataValueField="VarSessionId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT * FROM [SessionInfo] ORDER BY [VarSessionName] DESC"></asp:SqlDataSource>
                    <br />
                </td>
                <td class="style1">
                    <b>Student ID</b>
                    <br />
                    <asp:TextBox ID="branchinitialTextBox" runat="server" Width="20px"></asp:TextBox>
                    <asp:TextBox ID="studentIdTexBox" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td>
                    <br />
                    <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
                </td>
                <td colspan="4">
                    <br />
                    <span class="label label-warning" style="background-color: #f0ad4e; float: left; font-size: 15px; position: relative;" id="failStatusLabel" runat="server"></span><span class="label label-success"
                                                                                                                                                                                                                    style="background-color: #5cb85c; float: left; font-size: 15px; position: relative;"
                                                                                                                                                                                                                    id="successStatusLabel" runat="server"></span>
                    <br />
                </td>
            </tr>
            <tr style="width: 100%">
                <td style="width: 40%" colspan="4" valign="top">
                    <fieldset>
                        <legend>
                            <h3>
                                <b><i>Present Class Information</i></b></h3>
                        </legend>
                        <table>
                            <tr>
                                <td>
                                    <b>Student Name</b><br />
                                    <asp:TextBox ID="nameTextBox" runat="server" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td>
                                    <b>Class</b><br />
                                    <asp:TextBox ID="classTextBox" runat="server" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>Section</b><br />
                                    <asp:TextBox ID="sectionTextBox" runat="server" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td>
                                    <b>Roll</b><br />
                                    <asp:TextBox ID="rollTextBox" runat="server" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
                <td style="width: 60%" colspan="4">
                    <fieldset>
                        <legend>
                            <h3>
                                <b><i>Re-Admission Class Information</i></b></h3>
                        </legend>
                        <table>
                            <tr>
                                <td class="style1">
                                    <b>Re-Adm. Session</b>
                                    <br />
                                    <asp:DropDownList ID="tSessionDropDownList" runat="server" DataSourceID="SqlDataSource4"
                                                      DataTextField="VarSessionName" DataValueField="VarSessionId">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                                       SelectCommand="SELECT * FROM [SessionInfo] ORDER BY [VarSessionName] DESC"></asp:SqlDataSource>
                                    <br />
                                </td>
                                <td class="style1">
                                    <b>Re-Adm. Class</b>
                                    <br />
                                    <asp:DropDownList ID="reAddClassDropDownList" runat="server" DataSourceID="SqlDataSource1"
                                                      DataTextField="VarClassName" DataValueField="VarClassID" AutoPostBack="True"
                                                      AppendDataBoundItems="true" OnSelectedIndexChanged="reAddClassDropDownList_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0">--Select Class--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                                       
                                        SelectCommand="SELECT [VarClassID], [VarClassName] FROM [Class] WHERE ([VarClassID] &gt; @VarClassID)">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="125" Name="VarClassID" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                                <td class="style1">
                                    <b><i>Select Shift</i></b>
                                    <br />
                                    <asp:DropDownList ID="pShiftDropDownList" runat="server" DataSourceID="SqlDataSource5"
                                                      DataTextField="VarShiftName" DataValueField="VarShiftCode" AppendDataBoundItems="true">
                                        <asp:ListItem Selected="True" Value="0">--Select Shift--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                                       SelectCommand="SELECT [VarShiftCode], [VarShiftName] FROM [ShiftInfo]"></asp:SqlDataSource>
                                </td>
                               
                            </tr>
                            <tr>
                                <td class="style1">
                                    <b>Section</b><br />
                                    <asp:DropDownList ID="reAddSecDropDownList" runat="server" DataSourceID="SqlDataSource3"
                                                      DataTextField="varSectionName" DataValueField="SectionId" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="0">--Select Section--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                                       SelectCommand="SELECT [SectionId], [varSectionName], [ClassID] FROM [tblSection] WHERE ([ClassID] = @ClassID)">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="reAddClassDropDownList" Name="ClassID" PropertyName="SelectedValue"
                                                                  Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                                <td>
                                    <b>Campus</b><br />
                                    <asp:DropDownList ID="headTCampusDropDown" runat="server" Width="100px" DataSourceID="SqlDataSource6"
                                                      DataTextField="house_name" DataValueField="house_Code" AppendDataBoundItems="true">
                                        <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                                       SelectCommand="SELECT [house_Code], [house_name] FROM [tblhouse]"></asp:SqlDataSource>
                                </td>
                                
                                <td>
                                    <b>Roll</b><br />
                                    <asp:TextBox ID="newRollTextBox" runat="server" Width="50px"></asp:TextBox>
                                </td>
                               
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                    <asp:Button ID="reAddButton" runat="server" Text="Re-Admission" OnClick="reAddButton_Click" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>