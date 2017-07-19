<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeFile="EdexcelSubjectAssign.aspx.cs" Inherits="SubjectUI_EdexcelSubjectAssign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .tdWidth { width: 20%; }
    </style>
    <script type="text/javascript">
        window.onload = function() {
            var scrollY = parseInt('<%= Request.Form["scrollY"] %>');
            if (!isNaN(scrollY)) {
                window.scrollTo(0, scrollY);
            }
        };
        window.onscroll = function() {
            var scrollY = document.body.scrollTop;
            if (scrollY == 0) {
                if (window.pageYOffset) {
                    scrollY = window.pageYOffset;
                } else {
                    scrollY = (document.body.parentElement) ? document.body.parentElement.scrollTop : 0;
                }
            }
            if (scrollY > 0) {
                var input = document.getElementById("scrollY");
                if (input == null) {
                    input = document.createElement("input");
                    input.setAttribute("type", "hidden");
                    input.setAttribute("id", "scrollY");
                    input.setAttribute("name", "scrollY");
                    document.forms[0].appendChild(input);
                }
                input.value = scrollY;
            }
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <legend><b>
                    <h2>
                        A-Level Course Assign</h2>
                </b></legend>
        <table class="style1">
            <tr>
                <td class="tdWidth">
                    <b><i>Session</i></b>
                    <br />
                    <asp:DropDownList ID="sessionDropDownList" runat="server" Width="90%" DataSourceID="SqlDataSource11"
                                      DataTextField="VarSessionName" DataValueField="VarSessionId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource11" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo] ORDER BY [VarSessionId] DESC">
                    </asp:SqlDataSource>
                </td>
                <td class="tdWidth">
                    <br />
                    <b><i>Student ID</i></b>
                    <br />
                    <asp:TextBox ID="branchInitialTextBox" runat="server" Width="20%"></asp:TextBox>
                    <asp:TextBox ID="txtStdId" runat="server" Width="60%"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtStdId"
                                                ErrorMessage="Please Insert Student ID" ForeColor="red"></asp:RequiredFieldValidator>
                </td>
                <td class="tdWidth">
                    <br />
                    <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
                </td>
                <td class="tdWidth">
                    <asp:Literal ID="stdSearchLiteral" runat="server"></asp:Literal>
                </td>
            </tr>
            <%-- <tr>
                <td>
                    Student ID:
                </td>
                <td>
                    
                    <asp:TextBox ID="branchInitialTextBox" runat="server" Width="50px"></asp:TextBox>
                    <asp:TextBox ID="txtStdId" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Literal ID="stdSearchLiteral" runat="server"></asp:Literal></td>
            </tr>--%>
            <tr>
                <td class="tdWidth">
                    <b><i>Select Class</i></b>
                    <br />
                    <asp:DropDownList ID="classDropDown" runat="server" DataTextField="VarClassName"
                                      DataValueField="VarClassID" AutoPostBack="True" OnSelectedIndexChanged="classDropDown_SelectedIndexChanged">
                        <%--<asp:ListItem Value="0">--Select--</asp:ListItem>--%>
                    </asp:DropDownList>
                    <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT * FROM [Class] WHERE ([VarClassID] &gt; @VarClassID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="unitCodeGrid" DefaultValue="125" Name="VarClassID"
                                PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>--%>
                </td>
                <td class="tdWidth">
                    <b><i>Select Subject</i></b>
                    <br />
                    <asp:DropDownList ID="subjectDropDown" runat="server" AppendDataBoundItems="True"
                                      DataSourceID="SqlDataSource2" DataTextField="VarSubjectName" DataValueField="VarSubjectCode"
                                      AutoPostBack="True" OnSelectedIndexChanged="subjectDropDown_SelectedIndexChanged">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT * FROM [tbl_Subject] WHERE ([ClassId] = @ClassId)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="classDropDown" Name="ClassId" PropertyName="SelectedValue"
                                                  Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    </fieldset>
    <br />
    <div>
        <fieldset>
            <table align="center">
                <tr>
                    <td colspan="6">
                        <br />
                        <span class="label label-warning" style="background-color: #f0ad4e; float: left; font-size: 20px; position: relative;" id="failStatusLabel" runat="server"></span><span class="label label-success"
                                                                                                                                                                                                                            style="background-color: #5cb85c; float: left; font-size: 20px; position: relative;"
                                                                                                                                                                                                                            id="successStatusLabel" runat="server"></span>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <div style="height: 400px; overflow: auto" align="center">
                            <asp:GridView ID="unitCodeGrid" runat="server" CellPadding="4" ForeColor="#333333"
                                          GridLines="None" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource3">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:BoundField DataField="UnitCode" HeaderText="Unit Code" SortExpression="UnitCode" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Section">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="sectionDropDown" runat="server" Width="100px" DataSourceID="SqlDataSource4"
                                                              DataTextField="varSectionName" DataValueField="SectionId" AppendDataBoundItems="True"
                                                              AutoPostBack="True" OnSelectedIndexChanged="sectionDropDown_SelectedIndexChanged">
                                                <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                                               SelectCommand="SELECT [SectionId], [varSectionName] FROM [tblSection] WHERE ([ClassID] = @ClassID)">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="classDropDown" Name="ClassID" PropertyName="SelectedValue"
                                                                          Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Taken">
                                        <ItemTemplate>
                                            <asp:TextBox ID="takenTextBox" runat="server" Width="40px" Enabled="False"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                               SelectCommand="SELECT * FROM [tbl_EdexelunitCode] WHERE ([SpecificationCode] = @SpecificationCode)">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="subjectDropDown" Name="SpecificationCode" PropertyName="SelectedValue"
                                                          Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:Button ID="addButton" runat="server" Text="Add" OnClick="addButton_Click1" />
                        </div>
                    </td>
                    <td>
                    </td>
                    <td colspan="3">
                        <div style="height: 400px; overflow: auto" align="center">
                            <asp:GridView ID="addSubjectGridView" AutoGenerateColumns="False" HorizontalAlign="Center" OnRowCommand="addSubjectGridView_RowCommand"
                                          runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <%--<asp:BoundField DataField="ClassId" HeaderText="Class ID" />
                            <asp:BoundField DataField="StudentId" HeaderText="Student ID" />--%>
                                    <asp:TemplateField HeaderText="Subject">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelSubject" runat="server" Text='<%# Eval("VarSubjectName") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:BoundField DataField="SubjectCode" HeaderText="Subject Code" />--%>
                                    <asp:BoundField DataField="UnitCode" HeaderText="Unit Code" />
                                    <asp:BoundField DataField="varSectionName" HeaderText="Section" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                        Text="Delete" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#7C6F57" />
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#E3EAEB" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                            </asp:GridView>
                            <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
                            <asp:Button runat="server" ID="clearButton" Text="Clear" OnClick="clearButton_Click" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>