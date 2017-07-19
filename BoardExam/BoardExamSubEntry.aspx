<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="BoardExamSubEntry.aspx.cs" Inherits="BoardExam.BoardExamBoardExamSubEntry"
    MaintainScrollPositionOnPostback="true" %>

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
    <fieldset>
        <legend>
            <h1>
                A-Level Board Exam Subject Entry & Modify</h1>
        </legend>
        <div class="col-lg-12">
            <fieldset class="col-lg-6 tdWidth" style="width: 45%;">
                <legend>
                    <h3>
                        Taken Subject</h3>
                </legend>
                <div>
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
                                <b>Exam Session</b>
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
                            <%--<td>
                                <asp:Literal ID="stdSearchLiteral" runat="server"></asp:Literal>
                            </td>--%>
                        </tr>
                        <tr>
                            <td>
                                <b>Quali. Level</b>
                                <br />
                                <asp:DropDownList ID="qLevelDropDownList" runat="server" Width="90px">
                                    <asp:ListItem Value="IAL">IAL</asp:ListItem>
                                    <asp:ListItem Value="IGCSE">IGCSE</asp:ListItem>
                                    <asp:ListItem Value="A-LEVEL">A-LEVEL</asp:ListItem>
                                    <asp:ListItem Value="AS-LEVEL">AS-LEVEL</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <b><i>Class</i></b>
                                <br />
                                <asp:TextBox ID="classTextBox" runat="server" Width="90px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <%--<td>
                                <b>Board</b><br />
                                <asp:TextBox ID="boardTextBox" runat="server" Width="" ReadOnly="True"></asp:TextBox>
                            </td>--%>
                            <td>
                                <b>Board</b>
                                <br />
                                <asp:DropDownList ID="boardDropDownList" runat="server">
                                    <asp:ListItem Value="EDEXCEL">EDEXCEL</asp:ListItem>
                                    <asp:ListItem Value="CAMBRIDGE">CAMBRIDGE</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <b>Mobile No(For SMS)</b>
                                <br />
                                <asp:TextBox ID="numberTextBox" runat="server" placeholder="Like..01xxxxxxxxxx" ></asp:TextBox>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Please Insert Correct Phone no"
                                    ForeColor="red" ValidationExpression="^[0-9]{7,13}" ControlToValidate="numberTextBox"></asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="studentNameLabel" runat="server" Font-Bold="True" ForeColor="#006600"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:GridView ID="GridView1" runat="server" CellPadding="4" AutoGenerateColumns="False"
                                    OnRowCommand="GridView1_RowCommand" ForeColor="#333333" GridLines="None" Width="100%">
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
                                        <asp:TemplateField HeaderText="Unit Code">
                                            <ItemTemplate>
                                                <asp:Label ID="unitCodeLabel" runat="server" Text='<%# Eval("UnitCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Unit">
                                            <ItemTemplate>
                                                <asp:Label ID="unitNameLabel" runat="server" Text='<%# Eval("UnitCodeName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="uniqueIdLabel" runat="server" Text='<%# Eval("UniqueId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="">
                                    
                                            <ItemTemplate>
                                                <asp:Button ID="btnSave" runat="server" Width="50" Text="Save"  CommandName="SaveButton" 
                                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                           
                                            </ItemTemplate>
                                    
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnDelete" runat="server" Width="50" Text="Delete" CommandName="DeleteButton"
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
                    </table>
                </div>
            </fieldset>
            <fieldset class="col-lg-6 tWidth" style="width: 45%;">
                <legend>
                    <h3>
                        All Subject List</h3>
                </legend>
                <div>
                    <table style="width: 100%" class="tWidth">
                        <%-- <tr>
                <td colspan="1">
                    Unit No:
                </td>
                <td colspan="3">
                    <asp:TextBox ID="unitNoTextBox" runat="server"></asp:TextBox></td>
                    <td colspan="1">
                        <asp:Button ID="findButton" runat="server" Text="Find" 
                            onclick="findButton_Click" />
                    </td>
            </tr>
            <tr>
                <td style="width: 130px">
                    <asp:Label ID="subjectNameLabel" runat="server" ForeColor="#00CC99" Width="130px"></asp:Label>
                </td>
                <td style="width: 25px">
                    <asp:Label ID="unitCodeLabel" runat="server" ForeColor="#00CC99" Width="25px"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="sectionDropDownList" runat="server" AppendDataBoundItems="True"
                        DataSourceID="SqlDataSource2" DataTextField="varSectionName" 
                        DataValueField="SectionId" AutoPostBack="True" 
                        onselectedindexchanged="sectionDropDownList_SelectedIndexChanged">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                        SelectCommand="SELECT [SectionId], [varSectionName] FROM [tblSection] WHERE ([ClassID] = @ClassID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="classDropDownList" Name="ClassID" 
                                PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    <asp:TextBox ID="countTextBox" runat="server" Width="30px"></asp:TextBox>
                    
                </td>
                <td>
                    <asp:Button ID="addButton" runat="server" Text="Add" 
                        onclick="addButton_Click" />
                </td>
            </tr>--%>
                        <tr>
                            <td colspan="4">
                                <asp:GridView ID="GridView2" runat="server" CellPadding="4" AutoGenerateColumns="False"
                                    OnRowCommand="GridView2_RowCommand" ForeColor="#333333" GridLines="None" Width="100%">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Subject Code" Visible="True">
                                            <ItemTemplate>
                                                <asp:Label ID="subjectCodeLabel" runat="server" Text='<%# Eval("SubCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Subject">
                                            <ItemTemplate>
                                                <asp:Label ID="subjectLabel" runat="server" Text='<%# Eval("SubName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Unit Code">
                                            <ItemTemplate>
                                                <asp:Label ID="unitCodeLabel" runat="server" Text='<%# Eval("UnitCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Unit">
                                            <ItemTemplate>
                                                <asp:Label ID="unitNameLabel" runat="server" Text='<%# Eval("UnitName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="uniqueIdLabel" runat="server" Text='<%# Eval("UniqueId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
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
                    </table>
                </div>
            </fieldset>
        </div>
    </fieldset>
</asp:Content>
