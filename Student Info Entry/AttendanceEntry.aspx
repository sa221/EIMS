<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    MaintainScrollPositionOnPostback="true" CodeFile="AttendanceEntry.aspx.cs" Inherits="StudentInfoEntryAttendanceEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .tdWidth
        {
            float: left;
        }
    </style>
    <style type="text/css">
        .tWidth
        {
            float: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <fieldset>
        <legend>
            <h1>
                Student Attendance</h1>
        </legend>
        <div class="col-lg-12">
            <fieldset class="col-lg-6 tdWidth" style="width: 55%;">
                <legend>
                    <h3>
                        Attendance Entry</h3>
                </legend>
                <div>
                    <table>
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
                            <td>
                                Session:
                                <br />
                                <asp:DropDownList ID="sessionAtdDropDownList" runat="server" DataSourceID="SqlDataSource1"
                                    DataTextField="VarSessionName" DataValueField="VarSessionId">
                                </asp:DropDownList><br /><br />
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                    SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo] ORDER BY [VarSessionName] DESC">
                                </asp:SqlDataSource>
                            </td>
                            <td>
                                <b>Date</b><br />
                                <asp:TextBox ID="dateAtdTextBox" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                    Format="dd-MM-yyyy" TargetControlID="dateAtdTextBox"></ajaxToolkit:CalendarExtender>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Date."
                                    ForeColor="red" ControlToValidate="dateAtdTextBox" ValidationGroup="Gr1"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
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
                                    Width="140px" DataSourceID="SqlDataSource3" DataTextField="varSectionName" DataValueField="SectionId">
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
                                <br />
                                <asp:Button ID="showButton" runat="server" Text="Find" ValidationGroup="Gr1" OnClick="showButton_Click"
                                    CssClass="btn btn-danger" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:GridView ID="attendanceGridView" runat="server" CellPadding="2" AutoGenerateColumns="False"
                                    ForeColor="#333333" GridLines="Both" Width="100%" HorizontalAlign="Center">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL#">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Student ID">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("VarStudentID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("VarStudentFirstName") +" " + Eval("VarStudentLastName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Roll">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("StudentRoll") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Attendance">
                                            <ItemTemplate>
                                                <asp:RadioButtonList ID="attRadioButtonList" runat="server" RepeatColumns="4" SelectedValue='<%#Bind("AttendanceStatus")%>'>
                                                    <asp:ListItem Value="" style="display: none"></asp:ListItem>
                                                    <asp:ListItem Value="P">Present</asp:ListItem>
                                                    <asp:ListItem Value="A">Absent</asp:ListItem>
                                                    <asp:ListItem Value="L">Late</asp:ListItem>
                                                </asp:RadioButtonList>
                                            
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ForeColor="red"
                                                    ControlToValidate="attRadioButtonList" ValidationGroup="Gr3">*</asp:RequiredFieldValidator>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%-- <asp:TemplateField>
                                            <ItemTemplate>
                                                
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <%--<asp:TemplateField HeaderText="Attendance">
                                            <ItemTemplate>
                                                <asp:RadioButton ID="presentRadioButton" Text="P" runat="server" GroupName="a" />
                                                <asp:RadioButton ID="absentRadioButton" Text="A" runat="server" GroupName="a" />
                                                
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    </Columns>
                                    <EditRowStyle BackColor="#7C6F57" />
                                    <FooterStyle BackColor="#4286F4" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#4286F4" Font-Bold="True" ForeColor="White" />
                                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#E3EAEB" />
                                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                                </asp:GridView>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                    DisplayMode="SingleParagraph" HeaderText="Select Present or Absent" ShowSummary="False"
                                    ValidationGroup="Gr3" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="atdSaveButton" runat="server" Text="Save" OnClick="atdSaveButton_Click"
                                    ValidationGroup="Gr3" />
                            </td>
                        </tr>
                    </table>
                </div>
            </fieldset>
            <fieldset class="col-lg-6 tWidth" style="width: 35%;">
                <legend>
                    <h3>
                        Offday Entry</h3>
                </legend>
                <div>
                    <table style="width: 100%" class="tWidth">
                        <tr>
                            <td>
                                Session:
                                <br />
                                <asp:DropDownList ID="sessionDropDownList" runat="server" DataSourceID="SqlDataSource10"
                                    DataTextField="VarSessionName" DataValueField="VarSessionId">
                                </asp:DropDownList>
                                <br />
                                <br />
                                <asp:SqlDataSource ID="SqlDataSource10" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                    SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo] ORDER BY [VarSessionName] DESC">
                                </asp:SqlDataSource>
                            </td>
                            <td>
                                <b>Date</b><br />
                                <asp:TextBox ID="dateTextBox" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="txtDate_CalendarExtender" runat="server" Enabled="True"
                                    Format="dd/MM/yyyy" TargetControlID="dateTextBox"></ajaxToolkit:CalendarExtender>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="Please Enter Date."
                                    ForeColor="red" ControlToValidate="dateTextBox" ValidationGroup="Gr2"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>Comment</b><br />
                                <asp:TextBox ID="commentTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="saveOffdayButton" runat="server" Text="Save" ValidationGroup="Gr2"
                                    OnClick="saveOffdayButton_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="offDayGridView" runat="server" CellPadding="2" AutoGenerateColumns="False"
                                    ForeColor="#333333" GridLines="Both" Width="100%" HorizontalAlign="Center">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <%--<asp:TemplateField HeaderText="SL#">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Session Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("VarSession") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("DatDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Comments">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("VarStatus") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle BackColor="#7C6F57" />
                                    <FooterStyle BackColor="#4286F4" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#4286F4" Font-Bold="True" ForeColor="White" />
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
                    </table>
                </div>
            </fieldset>
        </div>
    </fieldset>
</asp:Content>
