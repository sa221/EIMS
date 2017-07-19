<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SubjectWiseTabulationSheetALevel.aspx.cs" Inherits="ReportsUI_SubjectWiseTabulationSheetALevel" %>
<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <fieldset>
        <legend>
            <h1>
                Subject wise Tabulation Sheet(A-LEVEL)</h1>
        </legend>
        <table>
            <tr>
                <td>
                    <b>Session:</b>
                    <br />
                    <asp:DropDownList ID="sessionDropDownList" runat="server" DataSourceID="getSession"
                                      DataTextField="VarSessionName" DataValueField="VarSessionId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getSession" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo] ORDER BY [VarSessionId] DESC">
                    </asp:SqlDataSource>
                </td>
                <td>
                    <b>Class:</b>
                    <br />
                    <asp:DropDownList ID="classDropDownList" runat="server" AutoPostBack="True" AppendDataBoundItems="True"
                                      DataSourceID="getClass" DataTextField="VarClassName" DataValueField="VarClassID"
                                      OnSelectedIndexChanged="classDropDownList_SelectedIndexChanged">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getClass" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       
                        SelectCommand="SELECT [VarClassID], [VarClassName] FROM [Class] WHERE ([VarClassID] &gt; @VarClassID)">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="125" Name="VarClassID" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    <b>Section:</b>
                    <br />
                    <asp:DropDownList ID="sectionDropDownList" runat="server" AppendDataBoundItems="True"
                                      DataSourceID="getSection" DataTextField="varSectionName" DataValueField="SectionId">
                        <asp:ListItem Value="0">--ALL--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getSection" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT [SectionId], [varSectionName] FROM [tblSection] WHERE ([ClassID] = @ClassID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="classDropDownList" Name="ClassID" PropertyName="SelectedValue"
                                                  Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Subject:</b>
                    <br />
                    <asp:DropDownList ID="subjectDropDownList" runat="server" DataSourceID="getSubject"
                                      DataTextField="VarSubjectName" DataValueField="VarSubjectCode" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getSubject" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT [VarSubjectCode], [VarSubjectName] FROM [tbl_Subject] WHERE ([ClassId] = @ClassId)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="classDropDownList" Name="ClassId" PropertyName="SelectedValue"
                                                  Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    <b>Unit Code:</b>
                    <br />
                    <asp:DropDownList ID="unitcodeDropDownList" runat="server" DataSourceID="getUnitCode"
                                      DataTextField="UnitCode" DataValueField="UnitCode">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getUnitCode" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT [UnitCode], [UnitCodeSpeCode] FROM [tbl_EdexelunitCode] WHERE (([SpecificationCode] = @SpecificationCode) AND ([Class] = @Class))">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="subjectDropDownList" Name="SpecificationCode" PropertyName="SelectedValue"
                                                  Type="String" />
                            <asp:ControlParameter ControlID="classDropDownList" Name="Class" PropertyName="SelectedValue"
                                                  Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    <b>Exam Name:</b>
                    <br />
                    <asp:DropDownList ID="examNameDropDownList" runat="server" DataSourceID="getExamName"
                                      DataTextField="ExamName" DataValueField="ExamCode">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getExamName" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT [ExamCode], [ExamName] FROM [tbl_ExamName]"></asp:SqlDataSource>
                </td>
                <td>
                    <br />
                    <asp:Button ID="showButton" runat="server" Text="Show" 
                                onclick="showButton_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="4" class="">
                    <span class="label label-warning" style="background-color: #f0ad4e; float: left; font-size: 20px; position: relative;" id="failStatusLabel" runat="server"></span><span class="label label-success"
                                                                                                                                                                                                                    style="background-color: #5cb85c; float: left; font-size: 20px; position: relative; position: absolute; z-index: 1;" id="successStatusLabel" runat="server">
                                                                                                                                                                                                              </span>
                    <br />
                    <br />
                </td>
            </tr>
        </table>
        <div>
            <CR:CrystalReportViewer ID="SubjectWiseTabulation" runat="server" 
                                    AutoDataBind="true" ToolPanelView="None" />
        </div>
    </fieldset>
</asp:Content>

