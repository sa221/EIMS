<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeFile="SubjectWiseStudentList.aspx.cs" Inherits="ReportsUI_SubjectWiseStudentList" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
             Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <legend>
            <h1>
                Subject Wise Student List</h1>
        </legend>
        <table>
            <tr>
                <td>
                    <b>Session:</b>
                    <br />
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
                    <b>Class:</b>
                    <br />
                    <asp:DropDownList ID="classDropDownList" runat="server" AutoPostBack="True" AppendDataBoundItems="True"
                                      DataSourceID="getClass" DataTextField="VarClassName" 
                                      DataValueField="VarClassID" 
                                      onselectedindexchanged="classDropDownList_SelectedIndexChanged">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getClass" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT [VarClassID], [VarClassName] FROM [Class]">
                    </asp:SqlDataSource>
                </td>
                <td>
                    <b>Subject:</b>
                    <br />
                    <asp:DropDownList ID="subjectDropDownList" runat="server" 
                                      DataSourceID="getSubject" DataTextField="VarSubjectName" 
                                      DataValueField="VarSubjectCode" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getSubject" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT [VarSubjectCode], [VarSubjectName] FROM [tbl_Subject] WHERE ([ClassId] = @ClassId)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="classDropDownList" Name="ClassId" 
                                                  PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    <b>Unit Code:</b>
                    <br />
                    <asp:DropDownList ID="unitcodeDropDownList" runat="server" 
                                      DataSourceID="getUnitCode" DataTextField="UnitCode" DataValueField="UnitCode">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getUnitCode" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT [UnitCode], [UnitCodeSpeCode] FROM [tbl_EdexelunitCode] WHERE (([SpecificationCode] = @SpecificationCode) AND ([Class] = @Class))">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="subjectDropDownList" Name="SpecificationCode" 
                                                  PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="classDropDownList" Name="Class" 
                                                  PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    <b>Section:</b>
                    <br />
                    <asp:DropDownList ID="sectionDropDownList" runat="server" AppendDataBoundItems="True"
                                      DataSourceID="getSection" DataTextField="varSectionName" 
                                      DataValueField="SectionId">
                        <asp:ListItem Value="0">--ALL--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getSection" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT [SectionId], [varSectionName] FROM [tblSection] WHERE ([ClassID] = @ClassID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="classDropDownList" Name="ClassID" 
                                                  PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td><br/>
                    <asp:Button ID="showButton" runat="server" Text="Show" 
                                onclick="showButton_Click" />
                </td>
            </tr>
           
        </table>
        <CR:CrystalReportViewer ID="SubjectWiseStudentList" runat="server" 
                                AutoDataBind="true" EnableParameterPrompt="False" ToolPanelView="None" />
    </fieldset>
</asp:Content>