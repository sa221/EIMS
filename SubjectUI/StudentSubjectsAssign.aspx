<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    MaintainScrollPositionOnPostback="true" CodeFile="StudentSubjectsAssign.aspx.cs"
    Inherits="SubjectUI_StudentSubjectsAssign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            CheckBoxCount();
        });

        function CheckBoxCount() {
            var gv = document.getElementById("<%= studentSubjectGridView.ClientID %>");

            var inputList = gv.getElementsByTagName("input");
            var numChecked = 0;

            for (var i = 0; i < inputList.length; i++) {
                if (inputList[i].type == "checkbox" && inputList[i].checked) {
                    numChecked = numChecked + 1;
                }
            }

            document.getElementById("<%= subCountTextBox.ClientID %>").value = numChecked;
            //            if (numChecked < 7) {
            //                document.getElementById("errfn").innerHTML = "<p style=color:Red>Minimum Requirement is Seven Subject..! ";
            //            }
        }
    </script>
    <style type="text/css">
        .tdWidth
        {
            width: 30%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <legend><b>
            <h2>
                O-Level Course Assign</h2>
        </b></legend>
        <table class="style1">
            <tr>
                <td class="tdWidth">
                    <b><i>Session</i></b>
                    <br />
                    <asp:DropDownList ID="sessionDropDownList" runat="server" Width="90%" DataSourceID="SqlDataSource3"
                        DataTextField="VarSessionName" DataValueField="VarSessionId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo] ORDER BY [VarSessionId] DESC">
                    </asp:SqlDataSource>
                </td>
                <td>
                    <b><i>Student ID</i></b>
                    <br />
                    <asp:TextBox ID="branchInitialTextBox" runat="server" Width="20%"></asp:TextBox>
                    <asp:TextBox ID="txtStdId" runat="server" Width="70%"></asp:TextBox>
                </td>
                <td>
                    <br />
                    <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
                </td>
                <td class="tdWidth">
                    <asp:Literal ID="stdSearchLiteral" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td class="tdWidth">
                    <b><i>Class</i></b><br />
                    <asp:DropDownList ID="classDropDown" runat="server" AppendDataBoundItems="True" Width="90%"
                        DataTextField="VarClassName" DataValueField="VarClassID" AutoPostBack="True"
                        DataSourceID="SqlDataSource4">
                        <asp:ListItem Value="">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [VarClassID], [VarClassName] FROM [Class] WHERE ([VarClassID] &lt; @VarClassID)">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="126" Name="VarClassID" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td class="tdWidth">
                    <b><i>Select Section</i></b>
                    <br />
                    <asp:DropDownList ID="sectionDropDownList" runat="server" Width="90%" DataSourceID="SqlDataSource1" 
                        DataTextField="varSectionName" DataValueField="SectionId" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT * FROM [tblSection] WHERE ([ClassID] = @ClassID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="classDropDown" Name="ClassID" PropertyName="SelectedValue"
                                Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    <b><i>Total Student</i></b>
                    <br />
                    <asp:Label ID="totalStudentLabel" runat="server" Text="" Font-Bold="True" ForeColor="#006600"></asp:Label>
                </td>
                <%--   <td>

                    <asp:DropDownList ID="classDropDown" runat="server" AppendDataBoundItems="True"
                      DataSourceID="SqlDataSource1" DataTextField="VarClassName"
                        DataValueField="VarClassID" AutoPostBack="True">
                        <asp:ListItem Value="0">--Class--</asp:ListItem>
                    </asp:DropDownList>

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                        ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT * FROM [Class]"></asp:SqlDataSource>

                </td>--%>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="studentNameLabel" runat="server" Font-Bold="True" ForeColor="#006600"></asp:Label>
                </td>
            </tr>
        </table>
    </fieldset>
    <br />
    <div align="center">
        <p>
            Student Subject Assign:
        </p>
        <asp:GridView ID="studentSubjectGridView" runat="server" AllowPaging="False" AllowSorting="True"
            AutoGenerateColumns="False" DataKeyNames="VarSubjectCode" DataSourceID="SqlDataSource2"
            CellPadding="4" ForeColor="#333333" GridLines="None" Width="390px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField SortExpression="VarSubjectCode">
                    <ItemTemplate>
                        <asp:CheckBox ID="subCheckBox" runat="server" onclick="CheckBoxCount();" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="VarSubjectName" HeaderText="Subject Name" SortExpression="VarSubjectName" />
                <asp:BoundField DataField="VarSubjectCode" HeaderText="Subject Code" ReadOnly="True"
                    SortExpression="VarSubjectCode" />
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
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
            DeleteCommand="DELETE FROM [tbl_Subject] WHERE [VarSubjectCode] = @VarSubjectCode"
            InsertCommand="INSERT INTO [tbl_Subject] ([VarSubjectCode], [VarSubjectName], [ClassId], [VarClassName]) VALUES (@VarSubjectCode, @VarSubjectName, @ClassId, @VarClassName)"
            SelectCommand="SELECT * FROM [tbl_Subject] WHERE ([ClassId] = @ClassId)" UpdateCommand="UPDATE [tbl_Subject] SET [VarSubjectName] = @VarSubjectName, [ClassId] = @ClassId, [VarClassName] = @VarClassName WHERE [VarSubjectCode] = @VarSubjectCode">
            <DeleteParameters>
                <asp:Parameter Name="VarSubjectCode" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="VarSubjectCode" Type="String" />
                <asp:Parameter Name="VarSubjectName" Type="String" />
                <asp:Parameter Name="ClassId" Type="Int32" />
                <asp:Parameter Name="VarClassName" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="classDropDown" Name="ClassId" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="VarSubjectName" Type="String" />
                <asp:Parameter Name="ClassId" Type="Int32" />
                <asp:Parameter Name="VarClassName" Type="String" />
                <asp:Parameter Name="VarSubjectCode" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
        <%-- <asp:CheckBox ID="remissionLabFeesCheckBox" runat="server" Text="If Remission Lab Fee" 
             />--%>
        <br />
        Total Number of Subjects:
        <%--    <div id="errfn">   </div>--%>
        <asp:TextBox ID="subCountTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
        <asp:Button ID="backButton" runat="server" Text="Back" OnClick="backButton_Click" />
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </div>
    <%-- <asp:GridView ID="studentSubjectGridView" runat="server" AllowPaging="True"
        AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="VarSubjectCode"
        DataSourceID="SqlDataSource2" CellPadding="4" ForeColor="#333333" 
        GridLines="None" Width="390px">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="subCheckBox" runat="server" onclick="CheckBoxCount();" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="VarSubjectName" HeaderText="Subject Name"
                SortExpression="VarSubjectName" />
            <asp:BoundField DataField="VarSubjectCode" HeaderText="Subject Code"
                ReadOnly="True" SortExpression="VarSubjectCode" />



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
    </asp:GridView>--%>
    <%-- <asp:SqlDataSource ID="SqlDataSource2" runat="server"
        ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
        DeleteCommand="DELETE FROM [tbl_Subject] WHERE [VarSubjectCode] = @VarSubjectCode"
        InsertCommand="INSERT INTO [tbl_Subject] ([VarSubjectCode], [VarSubjectName], [ClassId], [VarClassName]) VALUES (@VarSubjectCode, @VarSubjectName, @ClassId, @VarClassName)"
        SelectCommand="SELECT * FROM [tbl_Subject] WHERE ([ClassId] = @ClassId)"
        UpdateCommand="UPDATE [tbl_Subject] SET [VarSubjectName] = @VarSubjectName, [ClassId] = @ClassId, [VarClassName] = @VarClassName WHERE [VarSubjectCode] = @VarSubjectCode">
        <DeleteParameters>
            <asp:Parameter Name="VarSubjectCode" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="VarSubjectCode" Type="String" />
            <asp:Parameter Name="VarSubjectName" Type="String" />
            <asp:Parameter Name="ClassId" Type="Int32" />
            <asp:Parameter Name="VarClassName" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="classDropDown" Name="ClassId"
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="VarSubjectName" Type="String" />
            <asp:Parameter Name="ClassId" Type="Int32" />
            <asp:Parameter Name="VarClassName" Type="String" />
            <asp:Parameter Name="VarSubjectCode" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />
    Total Number of Subjects: 
    <%--    <div id="errfn">   </div>--%>
    <%-- <asp:TextBox ID="subCountTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>--%>
</asp:Content>
