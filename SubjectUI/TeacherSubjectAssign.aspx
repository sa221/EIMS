<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="TeacherSubjectAssign.aspx.cs" Inherits="SubjectUI_TeacherSubjectAssign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            height: auto;
            width: 100%;
        }
        
        .style2
        {
            width: 100%;
        }
        .style3
        {
            width: 25%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <legend>Show Class Wise Subject </legend>
        <table class="style1">
            <tr class="style2">
                <td class="style3">
                    <b><i>Session</i></b>
                    <br />
                    <asp:DropDownList ID="sessionDropDownList" runat="server" Width="90%" DataSourceID="SqlDataSource3"
                        DataTextField="VarSessionName" DataValueField="VarSessionId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo] ORDER BY [VarSessionId] DESC">
                    </asp:SqlDataSource>
                </td>
                <td class="style3">
                    <b><i>Class</i></b>
                    <br />
                    <asp:DropDownList ID="classDropDownList" runat="server" AutoPostBack="True" AppendDataBoundItems="True"
                        DataSourceID="SqlDataSource1" DataTextField="VarClassName" DataValueField="VarClassID" 
                        OnSelectedIndexChanged="classDropDownList_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="0">--Select Class--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [VarClassName], [VarClassID] FROM [Class]"></asp:SqlDataSource>
                </td>
                <td class="style3">
                    <b>Section:</b>
                    <br/>
                    <asp:DropDownList ID="sectionDropDownList" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="sectionDropDownList_SelectedIndexChanged">
                        
                    </asp:DropDownList>
                 
                   <%-- <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" SelectCommand="SELECT [SectionId], [varSectionName], [ClassID] FROM [tblSection] WHERE ([ClassID] = @ClassID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="classDropDownList" Name="ClassID" PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>--%>
                </td>
                <td class="style3"></td>
            </tr>
            <tr class="style2">
                <td colspan="4" class="style3">
                    <asp:GridView ID="allSubjectAssignGridView" runat="server" CellPadding="2" AutoGenerateColumns="False"
                        ForeColor="#333333" GridLines="Both" Width="100%" HorizontalAlign="Center">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="SL#">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subject Code">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("FullCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subject Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("FUllSubject") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Teacher" SortExpression="Id">
                                <ItemTemplate>
                                    <asp:DropDownList ID="teacherDropDownList" runat="server" AppendDataBoundItems="True"
                                        DataSourceID="getTeacher" DataTextField="VarEmployeeName" DataValueField="VarEmployeeid" SelectedValue='<%# Bind("VarEmpId") %>' Width="100%">
                                        <asp:ListItem Value="">--Select Teacher--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="getTeacher" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                        SelectCommand="SELECT [VarEmployeeid], [VarEmployeeName], [EmployeeCategory], [VarCurrentStatus] FROM [Employee] WHERE (([EmployeeCategory] = @EmployeeCategory) AND ([VarCurrentStatus] = @VarCurrentStatus) AND ([VarBranchId] = @VarBranchId))">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="1" Name="EmployeeCategory" Type="String" />
                                            <asp:Parameter DefaultValue="A" Name="VarCurrentStatus" Type="String" />
                                            <asp:SessionParameter Name="VarBranchId" SessionField="VarBranchId" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="Date Of Birth">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("dob", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Applied Class">
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("VarClassName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status" SortExpression="VarShiftCode">
                                <ItemTemplate>
                                    <asp:DropDownList ID="statusDropDown" runat="server" Width="150px" AppendDataBoundItems="False"
                                        SelectedValue='<%# Bind("Status") %>'>
                                        <asp:ListItem Selected="True" Value="1">Applied</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="2">Selected for Interview</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Interview Date" SortExpression="InterviewDate">
                                <ItemTemplate>
                                    <asp:TextBox ID="interviewDateTextBox" runat="server" Width="80px" Text='<%# Eval("InterviewDate", "{0:dd/MM/yyyy}") %>'></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                        TargetControlID="interviewDateTextBox" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Interview No." SortExpression="Id">
                                <ItemTemplate>
                                    <asp:DropDownList ID="interviewDropDown" runat="server" Width="120px" DataSourceID="SqlDataSource15"
                                        DataTextField="InterviewSlot" AutoPostBack="False" Enabled="True" DataValueField="Id"
                                        AppendDataBoundItems="true" SelectedValue='<%# Bind("InterviewSlot") %>'>
                                        <asp:ListItem Value="">--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource15" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                        SelectCommand="SELECT [InterviewSlot], [Id] FROM [tbl_InterviewSlot] "></asp:SqlDataSource>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Time" SortExpression="Id">
                                <ItemTemplate>
                                    <asp:DropDownList ID="interviewTimeDropDown" runat="server" Width="80px" DataSourceID="getInterviewTime"
                                        DataTextField="InterViewTime" AutoPostBack="False" Enabled="True" DataValueField="Id"
                                        AppendDataBoundItems="True" SelectedValue='<%# Bind("IntrviewTime") %>'>
                                        <asp:ListItem Value="">--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="getInterviewTime" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                        SelectCommand="SELECT [InterViewTime], [Id] FROM [tbl_InterViewTime] "></asp:SqlDataSource>
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
                        <SortedAscendingCellStyle BackColor="#F8FAFA"></SortedAscendingCellStyle>
                        <SortedAscendingHeaderStyle BackColor="#246B61"></SortedAscendingHeaderStyle>
                        <SortedDescendingCellStyle BackColor="#D4DFE1"></SortedDescendingCellStyle>
                        <SortedDescendingHeaderStyle BackColor="#15524A"></SortedDescendingHeaderStyle>
                    </asp:GridView>
                </td>
            </tr>
            <tr class="style2">
                <td class="style3">
                    <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
                </td>
                <td colspan="3" class="style3">
                    <span class="label label-warning" style="background-color: #f0ad4e; float: left;
                                          font-size: 20px; position: relative;" id="failStatusLabel" runat="server"></span>
                    <span class="label label-success" style="background-color: #5cb85c; float: left;
                                                                                                                      font-size: 20px; position: relative; position: absolute; z-index: 1;" id="successStatusLabel"
                        runat="server"></span>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
