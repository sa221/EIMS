<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeFile="MarksEntry.aspx.cs" Inherits="ResultProcessing_MarksEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <style type="text/css">
        .tdWidth { float: left; }
    </style>
    <style type="text/css">
        .tWidth { float: right; }
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

//        $("#MainContent_GridView1").click(function () {
//            console.log("Hello");
//            $(this).keyup(function () {
//                alert(this.value);
//            }); 
//        });
//        $(document).ready(function() {

//            $("#MainContent_GridView1 input").focusout(function() {

//                var id = $(this).val();
//                alert(id);
//                /*console.log("Hello");
//                $(this).keyup(function () {
//                    alert(this.value);
//                });
//                */
//            });
//        });

    </script>
    <script type="text/javascript">
        function ValidateTextBox() {
            var textvalue = $(".textClass").attr('value');
            if (textvalue == "") {
                alert("Please enter value in all textboxes.");
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <fieldset>
        <legend>
            <h1>
                Exam Wise Marks Entry</h1>
        </legend>
        <table>
            <tr>
                <td>
                    <b>Session:</b>
                    <br />
                    <asp:DropDownList ID="sessionDropDownList" runat="server" DataSourceID="getSession"
                                      DataTextField="VarSessionName" DataValueField="VarSessionId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getSession" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo] ORDER BY [VarSessionId] DESC">
                    </asp:SqlDataSource>
                </td>
                <td>
                    <b>Class:</b>
                    <br />
                    <asp:DropDownList ID="classDropDownList" runat="server" AutoPostBack="True" AppendDataBoundItems="True"
                                      DataSourceID="getClass" DataTextField="VarClassName" DataValueField="VarClassID"
                                      OnSelectedIndexChanged="classDropDownList_SelectedIndexChanged">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getClass" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT [VarClassID], [VarClassName] FROM [Class]"></asp:SqlDataSource>
                </td>
                <td>
                    <b>Section:</b>
                    <br />
                    <asp:DropDownList ID="sectionDropDownList" runat="server" AppendDataBoundItems="True"
                                      DataSourceID="getSection" DataTextField="varSectionName" DataValueField="SectionId">
                        <asp:ListItem Value="0">--ALL--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getSection" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT [SectionId], [varSectionName] FROM [tblSection] WHERE ([ClassID] = @ClassID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="classDropDownList" Name="ClassID" PropertyName="SelectedValue"
                                                  Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Subject:</b>
                    <br />
                    <asp:DropDownList ID="subjectDropDownList" runat="server" DataSourceID="getSubject"
                                      DataTextField="VarSubjectName" DataValueField="VarSubjectCode" AutoPostBack="True">
                        
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getSubject" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT [VarSubjectCode], [VarSubjectName] FROM [tbl_Subject] WHERE ([ClassId] = @ClassId)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="classDropDownList" Name="ClassId" PropertyName="SelectedValue"
                                                  Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    <b>Unit Code:</b>
                    <br />
                    <asp:DropDownList ID="unitcodeDropDownList" runat="server" DataSourceID="getUnitCode"
                                      DataTextField="UnitCode" DataValueField="UnitCodeSpeCode">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getUnitCode" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT [UnitCode], [UnitCodeSpeCode] FROM [tbl_EdexelunitCode] WHERE (([SpecificationCode] = @SpecificationCode) AND ([Class] = @Class))">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="subjectDropDownList" Name="SpecificationCode" PropertyName="SelectedValue"
                                                  Type="String" />
                            <asp:ControlParameter ControlID="classDropDownList" Name="Class" PropertyName="SelectedValue"
                                                  Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    <b>Exam Name:</b>
                    <br />
                    <asp:DropDownList ID="examNameDropDownList" runat="server" DataSourceID="getExamName"
                                      DataTextField="ExamName" DataValueField="ExamCode">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getExamName" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT [ExamCode], [ExamName] FROM [tbl_ExamName]"></asp:SqlDataSource>
                </td>
                <td>
                    <br />
                    <asp:Button ID="showButton" runat="server" Text="Show" OnClick="showButton_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="4" class="">
                    <span class="label label-warning" style="background-color: #f0ad4e; float: left; font-size: 20px; position: relative;" id="failStatusLabel" runat="server"></span><span class="label label-success"
                                                                                                                                                                                                                    style="background-color: #5cb85c; float: left; font-size: 20px; position: relative; position: absolute; z-index: 1;" id="successStatusLabel" runat="server">
                                                                                                                                                                                                              </span>
                    <br />
                    <br />
                </td>
            </tr>
        </table>
        <%-- <div>
            <asp:RangeValidator ID="Range1"  ControlToValidate="firstStMarks" MaximumValue="30" MinimumValue='<%# Eval("First_ST_Marks") %>'
                                Type="Double" Text="The value must be integer and greater or equal than mark"
                                runat="server" />
        </div>--%>
        <div>
            <%-- <div style="height: 400px; overflow: auto" align="center" OnPageIndexChanging="GridView1_PageIndexChanging">--%>
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" AutoGenerateColumns="False"
                          ForeColor="#333333" GridLines="None" AllowPaging="True" PageSize="100" HorizontalAlign="Center"
                          Width="100%">
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
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("VarStudentFirstName") + " " + Eval("VarStudentMeddleName") + " " + Eval("VarStudentLastName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Roll">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("StudentRoll") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>                   
                    <%--<asp:TemplateField HeaderText="Section">
                        <ItemTemplate>
                            <asp:Label ID="sectionLabel" runat="server" Text='<%#Bind("varSectionName")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> --%>                                                     <%--(String.IsNullOrEmpty(Eval("varSectionName").ToString()) ? "N/A" : Eval("varSectionName"))--%>
                    <asp:TemplateField HeaderText="1st S.T" SortExpression="First_ST_Marks">
                        <ItemTemplate>
                            <asp:TextBox ID="firstStMarks" runat="server" Width="50px" Text='<%# Eval("First_ST_Marks") %>'></asp:TextBox>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="2nd S.T" SortExpression="Second_ST_Marks">
                        <ItemTemplate>
                            <asp:TextBox ID="secondStMarks" runat="server" Width="50px" Text='<%# Eval("Second_ST_Marks") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="3rd S.T" SortExpression="Third_ST_Marks">
                        <ItemTemplate>
                            <asp:TextBox ID="thirdStMarks" runat="server" Width="50px" Text='<%# Eval("Third_ST_Marks") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Final" SortExpression="Final_Marks">
                        <ItemTemplate>
                            <asp:TextBox ID="finalMarks" runat="server" Width="50px" Text='<%# Eval("Final_Marks") %>'></asp:TextBox>
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
        </div>
        <div>
            <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" OnClientClick=" return ValidateTextBox(); " /></div>
    </fieldset>
</asp:Content>