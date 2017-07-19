<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeFile="AdmitCardGenerator.aspx.cs" Inherits="ReportsUI.ReportsUiAdmitCardGenerator" %>

<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <fieldset>
        <legend>
            <h1>
                Admit Card Generator</h1>
        </legend>
        <table>
            <tr>
                <td>
                    <b>Session</b><br/>
                    <asp:DropDownList ID="sessionDropDownList" runat="server" 
                                      DataSourceID="getSession" DataTextField="VarSessionName" 
                                      DataValueField="VarSessionId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getSession" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo] ORDER BY [VarSessionId] DESC">
                    </asp:SqlDataSource>
                </td>
                <td>
                    <b>Student ID</b><br />
                    <asp:TextBox ID="studentIdTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                
                <td>
                    <b>Class</b><br />
                    <asp:DropDownList ID="classDropDownList" runat="server" AppendDataBoundItems="True"
                                      DataSourceID="getAllClass" DataTextField="VarClassName" 
                                      DataValueField="VarClassID" AutoPostBack="True" 
                                      onselectedindexchanged="classDropDownList_SelectedIndexChanged1">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getAllClass" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT [VarClassID], [VarClassName] FROM [Class]"></asp:SqlDataSource>
                </td>
                <td>
                    <b>Section</b><br />
                    <asp:DropDownList ID="sectionDropDownList" runat="server" AppendDataBoundItems="True"
                                      DataSourceID="getSection" DataTextField="varSectionName" 
                                      DataValueField="SectionId">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getSection" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT [SectionId], [varSectionName], [ClassID] FROM [tblSection] WHERE ([ClassID] = @ClassID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="classDropDownList" Name="ClassID" 
                                                  PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td><b>Exam Name</b><br/>
                    <asp:DropDownList ID="examDropDownList" runat="server" 
                                      DataSourceID="getExamName" DataTextField="ExamName" DataValueField="Id">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getExamName" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT * FROM [tbl_ExamName]"></asp:SqlDataSource>
                </td>
                <td><br />
                    <asp:Button ID="ShowButton" runat="server" Text="Show" 
                                onclick="ShowButton_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <span class="label label-warning" style="background-color: #f0ad4e; float: left; font-size: 20px; position: relative;"  id="failStatusLabel" runat="server"></span>
                    <span class="label label-success" style="background-color: #5cb85c; float: left; font-size: 20px; position: relative;" id="successStatusLabel" runat="server"></span>
                    <br />
                    <br />     
                </td>
            </tr>
        </table>
        <CR:CrystalReportViewer ID="AdmitCardGenerator" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="False"
                                ToolPanelView="None" />
    </fieldset>
</asp:Content>