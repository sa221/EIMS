<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeFile="ExamNameAndTypeSetup.aspx.cs" Inherits="ResultProcessing_ExamNameAndTypeSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <fieldset>
        <legend>
            <h1>
                Exam name setup</h1>
        </legend>
        <div class="col-lg-12">
            <div>
                <table class="style1">
                    <tr>
                        <td>
                            <span class="label label-warning" style="background-color: #f0ad4e; float: left; font-size: 20px; position: relative;" id="failStatusLabel" runat="server"></span><span class="label label-success"
                                                                                                                                                                                                                                    style="background-color: #5cb85c; float: left; font-size: 20px; position: relative;"
                                                                                                                                                                                                                                    id="successStatusLabel" runat="server"></span>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b><i>Exam Code</i></b>
                            <br />
                            <asp:TextBox ID="examCodeTextBox" runat="server" Width="350px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b><i>Exam Name</i></b>
                            <br />
                            <asp:TextBox ID="examNameTextBox" runat="server" Width="350px"></asp:TextBox>
                            <%-- <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="examNameTextBox"
                                    ErrorMessage="Please Insert Exam Name" ForeColor="red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="allExamGridView" runat="server" UseAccessibleHeader="true" Width="100%"
                                          CssClass="table table-hover table-striped table table-bordered" GridLines="Both"
                                          OnRowCommand="allExamGridView_RowCommand" AutoGenerateColumns="False">
                                <Columns>
                                    <%--<asp:TemplateField HeaderText="Sr#">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>   
                                        </ItemTemplate>
                                        <ItemStyle Width="2%" />
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Exam Code">
                                        <HeaderStyle Width="70px" />
                                        <ItemStyle Width="70px" />
                                        <ItemTemplate>
                                            <asp:Label ID="examCodeLabel" runat="server" Font-Bold="True" ForeColor="#3A4F63"
                                                       Text='<%# Eval("ExamCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Exam Name">
                                        <HeaderStyle Width="220px" />
                                        <ItemStyle Width="220px" />
                                        <ItemTemplate>
                                            <asp:Label ID="examNameLabel" runat="server" Font-Bold="True" ForeColor="#3A4F63"
                                                       Text='<%# Eval("ExamName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <HeaderStyle Width="60px" />
                                        <ItemStyle Width="60px" />
                                        <ItemTemplate>
                                            <asp:Button ID="btnSave" runat="server" Width="60px" Text="Edit" CommandName="EditButton"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                        </ItemTemplate>
                                        <%--<ItemStyle Width="120px" />--%>
                                        <%--<FooterStyle Width="120px" />--%>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle CssClass="cursor-pointer" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </fieldset>
</asp:Content>