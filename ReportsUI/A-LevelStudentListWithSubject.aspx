<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="A-LevelStudentListWithSubject.aspx.cs" Inherits="ReportsUI_A_LevelStudentListWithSubject" %>
<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <fieldset>
        <legend><h1>Student List With All Subject & Unit Code</h1></legend>
        <table>
            <tr>
                <td><b>Session</b>
                    <br/>
                    <asp:DropDownList ID="sessionDropDownList" runat="server" 
                                      DataSourceID="SqlDataSource1" DataTextField="VarSessionName" 
                                      DataValueField="VarSessionId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo] ORDER BY [VarSessionName] DESC">
                    </asp:SqlDataSource>
                </td>
                <td>
                    <b>Class</b><br/>
                    <asp:DropDownList ID="classDropDownList" runat="server" AppendDataBoundItems="True" 
                                      DataSourceID="SqlDataSource2" DataTextField="VarClassName" 
                                      DataValueField="VarClassID" AutoPostBack="True" onselectedindexchanged="classDropDownList_SelectedIndexChanged" 
                        >
                        <asp:ListItem Selected="True" Value="0">--Class--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                        
                                       SelectCommand="SELECT [VarClassID], [VarClassName] FROM [Class] WHERE ([VarClassID] &gt;= @VarClassID)">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="114" Name="VarClassID" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    <b>Section</b>&nbsp;
                    <br/>
                    <asp:DropDownList ID="sectionDropDownList" runat="server" AppendDataBoundItems="True"
                                      DataSourceID="SqlDataSource3" DataTextField="varSectionName" 
                                      DataValueField="SectionId">
                        <asp:ListItem Value="0">--All--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT [SectionId], [varSectionName], [ClassID] FROM [tblSection] WHERE ([ClassID] = @ClassID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="classDropDownList" Name="ClassID" 
                                                  PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                
            </tr>
            <tr>
              
                
                <%--<td>Shift:
                    <br/>
                    <asp:DropDownList ID="shiftDropDownList" runat="server" DataSourceID="getShift" DataTextField="VarShiftName" DataValueField="VarShiftCode" AppendDataBoundItems="True">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getShift" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" SelectCommand="SELECT [VarShiftCode], [VarShiftName] FROM [ShiftInfo]"></asp:SqlDataSource>
                </td>--%>
                <td>
                    <asp:Button ID="ShowButton" runat="server" Text="Show" onclick="ShowButton_Click" 
                        /></td>
            </tr>
           
        </table>
        <CR:CrystalReportViewer ID="StudentAllSubjectList" runat="server" 
                                AutoDataBind="true" EnableParameterPrompt="False" ToolPanelView="None" />
    </fieldset>

</asp:Content>