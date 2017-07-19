<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ShowAllStudent.aspx.cs" Inherits="StudentInfoEntryShowAllStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
     <script type="text/javascript">

         function SetTarget() {

             document.forms[0].target = "_blank";

         }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <fieldset>
        <legend>
            <h1>
                All Applicant Student</h1>
        </legend>
        <table>
            <tr>
                <td>
                    <b>Session</b>
                    <br />
                    <asp:DropDownList ID="sessionDropDownList" runat="server" DataSourceID="SqlDataSource1"
                        DataTextField="VarSessionName" DataValueField="VarSessionId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo] ORDER BY [VarSessionName] DESC">
                    </asp:SqlDataSource>
                </td>
                <td>
                    <b>Class</b><br />
                    <asp:DropDownList ID="classDropDownList" runat="server" AppendDataBoundItems="True"
                        DataSourceID="SqlDataSource2" DataTextField="VarClassName" DataValueField="VarClassID"
                        AutoPostBack="False">
                        <asp:ListItem Selected="True" Value="0">--All--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [VarClassID], [VarClassName] FROM [Class]"></asp:SqlDataSource>
                </td>
                <td>
                    <asp:RadioButtonList ID="admissionRadioButtonList" runat="server">
                        <asp:ListItem Value="0"><b>Select For Interview</b></asp:ListItem>
                        <asp:ListItem Value="1"><b>Select For Admission</b></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <br />
                    <asp:Button ID="ShowButton" runat="server" Text="Show" OnClick="ShowButton_Click" />
                </td>
                <td>
                    <asp:TextBox ID="radioValueTextBox" runat="server" Visible="False" />
                </td>
            </tr>
            <tr>
                <td colspan="4" class="">
                    <span class="label label-warning" style="background-color: #f0ad4e; float: left;
                        font-size: 20px; position: relative;" id="failStatusLabel" runat="server"></span>
                    <span class="label label-success" style="background-color: #5cb85c; float: left;
                        font-size: 20px; position: relative; position: absolute; z-index: 1;" id="successStatusLabel"
                        runat="server"></span>
                </td>
            </tr>
        </table>
        <br />
        <div>
            <asp:GridView ID="allApplicantGridView" runat="server" CellPadding="2" AutoGenerateColumns="False"
                ForeColor="#333333" GridLines="Both" Width="100%" HorizontalAlign="Center">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="SL#">
                        <ItemTemplate>
                            <%#Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Form ID">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("varRegistrationId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("varStudentFirstName") + " " + Eval("varStudentMiddleName") + " " + Eval("varStudentLastName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date Of Birth">
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
                        <%--<HeaderTemplate>
                            <label>
                                Interview No.</label><br />
                            <asp:DropDownList ID="headinterviewDropDown" runat="server" Width="120px" DataSourceID="SqlDataSource6"
                                DataTextField="InterviewSlot" DataValueField="Id" AppendDataBoundItems="true"
                                AutoPostBack="True" OnSelectedIndexChanged="headinterviewDropDown_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="">--Select--</asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                SelectCommand="SELECT [Id], [InterviewSlot] FROM [tbl_InterviewSlot]"></asp:SqlDataSource>
                        </HeaderTemplate>--%>
                        <ItemTemplate>
                            <asp:DropDownList ID="interviewDropDown" runat="server" Width="120px" DataSourceID="SqlDataSource15"
                                DataTextField="InterviewSlot" AutoPostBack="False" Enabled="True" DataValueField="Id"
                                AppendDataBoundItems="true" SelectedValue='<%# Bind("InterviewSlot") %>'>
                                <asp:ListItem  Value="">--Select--</asp:ListItem>
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
            <br />
        </div>
        <div>
            <asp:GridView ID="admissionSelectionGridView" runat="server" CellPadding="2" AutoGenerateColumns="False" OnRowCommand="admissionSelectionGridView_RowCommand"
                ForeColor="#333333" GridLines="Both" Width="100%" HorizontalAlign="Center">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="SL#">
                        <ItemTemplate>
                            <%#Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Form ID">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("varRegistrationId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("varStudentFirstName") + " " + Eval("varStudentMiddleName") + " " + Eval("varStudentLastName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date Of Birth">
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
                                <asp:ListItem Selected="True" Value="2">Selected for Interview</asp:ListItem>
                                <asp:ListItem Selected="True" Value="3">Selected for Admission</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Admission Date" SortExpression="AdmissionDate">
                        <ItemTemplate>
                            <asp:TextBox ID="dateTextBox" runat="server" Width="80px" Text='<%# Eval("AdmissionDate", "{0:dd/MM/yyyy}") %>'></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                TargetControlID="dateTextBox" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                                <asp:Button ID="btnEdit" runat="server" Width="60" Text="Report" OnClientClick="SetTarget()"
                                        CommandName="EditButton" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:TemplateField HeaderText="Time" SortExpression="VarShiftCode">
                        <ItemTemplate>
                            <asp:DropDownList ID="timeDropDownList" runat="server" Width="100px" AppendDataBoundItems="False"
                                SelectedValue='<%# Bind("Status") %>'>
                                
                            </asp:DropDownList>
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
            <br />
        </div>
        <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
    </fieldset>
</asp:Content>
