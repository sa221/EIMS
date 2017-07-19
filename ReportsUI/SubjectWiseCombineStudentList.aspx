<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SubjectWiseCombineStudentList.aspx.cs" Inherits="ReportsUI_SubjectWiseCombineStudentList" %>
<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script type="text/javascript">
        function unchecXI() {
            var xiCheckBox = document.getElementById("<%=XIClassCheckBox.ClientID %>");
            var xiiCheckBox = document.getElementById("<%=XIIClassCheckBox.ClientID %>");
            if (xiCheckBox.checked == true) {
                document.getElementById("MainContent_XIIClassCheckBox").checked = false;
            }
            else if (xiiCheckBox.checked == true) {
                document.getElementById("MainContent_XIClassCheckBox").checked = false;
            }
        }
//        function unchecXII() {
//            var xiiCheckBox = document.getElementById("<%=XIIClassCheckBox.ClientID %>");
//            if (xiiCheckBox.checked == false) {
//                document.getElementById("MainContent_XIClassCheckBox").checked = false;
//            }
//        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
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
                <%--<td>
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
                </td>--%>
                <td>
                    <b>Class:</b>
                    <br />
                    <asp:CheckBox ID="XIClassCheckBox" runat="server" AutoPostBack="True" Text="Class XI"
                        oncheckedchanged="XIClassCheckBox_CheckedChanged" onClick="unchecXI();"/><br/>
                    <asp:CheckBox ID="XIIClassCheckBox" runat="server" AutoPostBack="True" Text="Class XII"
                        oncheckedchanged="XIIClassCheckBox_CheckedChanged" onClick="unchecXI();"/>
                    <%--<asp:CheckBoxList ID="classCheckBoxList" runat="server" AutoPostBack="True"
                        DataSourceID="combineClass" DataTextField="VarClassName" 
                        DataValueField="VarClassID" 
                        onselectedindexchanged="classCheckBoxList_SelectedIndexChanged">
                    </asp:CheckBoxList>
                    <asp:SqlDataSource ID="combineClass" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                        SelectCommand="SELECT [VarClassID], [VarClassName] FROM [Class] WHERE ([VarClassID] &gt; @VarClassID)">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="125" Name="VarClassID" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>--%>
                </td>
                <td>
                    <b>Subject:</b>
                    <br />
                    <asp:DropDownList ID="subjectDropDownList" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="subjectDropDownList_SelectedIndexChanged">
                    </asp:DropDownList>
                    <%--<asp:SqlDataSource ID="getSubject" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT [VarSubjectCode], [VarSubjectName] FROM [tbl_Subject] WHERE ([ClassId] = @ClassId)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="classDropDownList" Name="ClassId" 
                                                  PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>--%>
                </td>
                <td>
                    <b>Unit Code:</b>
                    <br />
                    <asp:DropDownList ID="unitcodeDropDownList" runat="server">
                    </asp:DropDownList>
                    <%--<asp:SqlDataSource ID="getUnitCode" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT [UnitCode], [UnitCodeSpeCode] FROM [tbl_EdexelunitCode] WHERE (([SpecificationCode] = @SpecificationCode) AND ([Class] = @Class))">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="subjectDropDownList" Name="SpecificationCode" 
                                                  PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="classDropDownList" Name="Class" 
                                                  PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>--%>
                </td>
                <%--<td>
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
                </td>--%>
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

