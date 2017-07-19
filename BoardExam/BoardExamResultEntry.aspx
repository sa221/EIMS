<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="BoardExamResultEntry.aspx.cs" Inherits="BoardExam.BoardExamBoardExamResultEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <legend>
            <h1>
                A-Level Board Exam Result</h1>
        </legend>
        <table class="style1">
            <tr>
                <td colspan="4">
                    <span class="label label-warning" style="background-color: #f0ad4e; float: left;
                        font-size: 20px; position: relative;" id="failStatusLabel" runat="server"></span>
                    <span class="label label-success" style="background-color: #5cb85c; float: left;
                        font-size: 20px; position: relative;" id="successStatusLabel" runat="server">
                    </span>
                </td>
            </tr>
            <tr>
                <td>
                    <b><i>Session</i></b>
                    <br />
                    <asp:DropDownList ID="sessionDropDownList" runat="server" DataSourceID="SqlDataSource1"
                        AppendDataBoundItems="True" DataTextField="VarSessionName" DataValueField="VarSessionId"
                        OnSelectedIndexChanged="sessionDropDownList_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Value="0">--SELECT--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo] ORDER BY [VarSessionId] DESC">
                    </asp:SqlDataSource>
                </td>
                <td>
                    <b>Exam Session</b><br />
                    <asp:DropDownList ID="examSessionDropDownList" runat="server" Width="90px">
                    </asp:DropDownList>
                </td>
                <td>
                    <br />
                    <b><i>Student ID</i></b>
                    <br />
                    <asp:TextBox ID="branchInitialTextBox" runat="server" Width="15%"></asp:TextBox>
                    <asp:TextBox ID="txtStdId" runat="server" Width="40%"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtStdId"
                        ErrorMessage="Please Insert Student ID" ForeColor="red"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Literal ID="stdSearchLiteral" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
                </td>
                <td>
                    <b><i>Class</i></b>
                    <br />
                    <asp:TextBox ID="classTextBox" runat="server" Width="90px" ReadOnly="True"></asp:TextBox>
                </td>
                <td>
                    <b>Board</b><br />
                    <asp:TextBox ID="boardTextBox" runat="server" Width="" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="studentNameLabel" runat="server" Font-Bold="True" ForeColor="#006600"></asp:Label>
                </td>
            </tr>
            <tr style="width: 100%">
                <td colspan="5">
                    <asp:GridView ID="resultEntryGridView" runat="server" CellPadding="4" AutoGenerateColumns="False"
                        ForeColor="#333333" GridLines="None" Width="100%">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Subject Code" Visible="True">
                                <ItemTemplate>
                                    <asp:Label ID="subjectCodeLabel" runat="server" Text='<%# Eval("SubjectId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subject">
                                <ItemTemplate>
                                    <asp:Label ID="subjectLabel" runat="server" Text='<%# Eval("SubjectName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Grade">
                                <ItemTemplate>
                                    <asp:TextBox ID="gradeTextBox" runat="server" Text='<%#Eval("Grade") %>' Width="50px" ></asp:TextBox>
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
                 <td>
                     <asp:Button ID="saveButton" runat="server" Text="Save" 
                         onclick="saveButton_Click" />
                 </td>
             </tr>
        </table>
    </fieldset>
</asp:Content>
