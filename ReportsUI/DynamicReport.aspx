<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="DynamicReport.aspx.cs" Inherits="ReportsUI_DynamicReport" %>
<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <fieldset>
        <legend>
            <h1>
                Student List</h1>
        </legend>
        
                <table>
                    <tr>
                        <td>
                            Session:
                            <br />
                            <asp:DropDownList ID="sessionDropDownList" runat="server" DataSourceID="SqlDataSource1"
                                DataTextField="VarSessionName" DataValueField="VarSessionId">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo] ORDER BY [VarSessionName] DESC">
                            </asp:SqlDataSource>
                        </td>
                        <td>
                            Class:<br />
                            <asp:DropDownList ID="classDropDownList" runat="server" AppendDataBoundItems="True"
                                DataSourceID="SqlDataSource2" DataTextField="VarClassName" DataValueField="VarClassID"
                                AutoPostBack="True" OnSelectedIndexChanged="classDropDownList_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="0">--Class--</asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                SelectCommand="SELECT [VarClassID], [VarClassName] FROM [Class]"></asp:SqlDataSource>
                        </td>
                        <td>
                            Section:
                            <br />
                            <asp:DropDownList ID="sectionDropDownList" runat="server" AppendDataBoundItems="True"
                                DataSourceID="SqlDataSource3" DataTextField="varSectionName" DataValueField="SectionId">
                                <asp:ListItem Value="0">--All--</asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                SelectCommand="SELECT [SectionId], [varSectionName], [ClassID] FROM [tblSection] WHERE ([ClassID] = @ClassID)">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="classDropDownList" Name="ClassID" PropertyName="SelectedValue"
                                        Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                        <td>
                            Shift:
                            <br />
                            <asp:DropDownList ID="shiftDropDownList" runat="server" DataSourceID="getShift" DataTextField="VarShiftName"
                                DataValueField="VarShiftCode" AppendDataBoundItems="True">
                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="getShift" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                SelectCommand="SELECT [VarShiftCode], [VarShiftName] FROM [ShiftInfo]"></asp:SqlDataSource>
                        </td>
                        <td>
                            <br />
                            <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
                        </td>
                        <td style="width: 340px">
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <span class="label label-warning" style="background-color: #f0ad4e; float: left;
                                font-size: 20px; position: relative;" id="failStatusLabel" runat="server"></span>
                            <span class="label label-success" style="background-color: #5cb85c; float: left;
                                font-size: 20px; position: relative;" id="successStatusLabel" runat="server">
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="9">
                            <asp:GridView ID="GridView2" runat="server" CellPadding="4" AutoGenerateColumns="False"
                                OnRowCommand="GridView2_RowCommand" ForeColor="#333333" GridLines="None" Width="100%">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Student ID" Visible="True">
                                        <ItemTemplate>
                                            <asp:Label ID="idLabel" runat="server" Text='<%# Eval("VarStudentID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Student Name">
                                        <ItemTemplate>
                                            <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Roll">
                                        <ItemTemplate>
                                            <asp:Label ID="rollLabel" runat="server" Text='<%# Eval("StudentRoll") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Section">
                                        <ItemTemplate>
                                            <asp:Label ID="sectionLabel" runat="server" Text='<%# Eval("varSectionName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Phone" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="phoneLabel" runat="server" Text='<%# Eval("VarStudenHomeCell") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Shift" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="shiftLabel" runat="server" Text='<%# Eval("VarShiftName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Class" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="classLabel" runat="server" Text='<%# Eval("VarClassName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Session" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="sessionLabel" runat="server" Text='<%# Eval("VarSessionName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:Button ID="btnAdd" runat="server" Width="50" Text="Add" CommandName="AddButton"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#7C6F57" />
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#E3EAEB" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Button ID="reportButton" runat="server" Text="Show Report" 
                                onclick="reportButton_Click" />
                        </td>
                    </tr>
                    
                </table>
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" Visible="True" AutoDataBind="False"
            Height="1202px" ToolPanelWidth="200px" Width="1104px" EnableDatabaseLogonPrompt="False"
            ToolPanelView="None" />
    </fieldset>
</asp:Content>
