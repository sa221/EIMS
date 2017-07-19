<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ShowAllStudent.aspx.cs" Inherits="Student_Info_Search_and_update_ShowAllStudent" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    
    <style type="text/css">
        .style1
        {
            height: auto;
            width: 100%;
        }
        
        .style2
        {
            width: 209px;
        }
       
    </style>
    <script type="text/javascript">
        window.onload = function () {
            var scrollY = parseInt('<%= Request.Form["scrollY"] %>');
            if (!isNaN(scrollY)) {
                window.scrollTo(0, scrollY);
            }
        };
        window.onscroll = function () {
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
    <script type="text/javascript">

        function SetTarget() {

            document.forms[0].target = "_blank";

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <fieldset>
        <legend><b>
            <h2>
                Show All Student</h2>
        </b></legend>
        <table class="style1">
            <tr>
                <td>
                    <b>Select Class:</b>
                    <br />
                    <asp:DropDownList ID="classDropDownList" runat="server" AppendDataBoundItems="True"
                        DataSourceID="SqlDataSource1" DataTextField="VarClassName" DataValueField="VarClassID">
                        <asp:ListItem Value="0">--All--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [VarClassName], [VarClassID] FROM [Class]"></asp:SqlDataSource>
                </td>
                <td>
                    <b>Student ID</b>
                    <br />
                    <asp:TextBox ID="studentIdTextBox" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" AutoGenerateColumns="False"
                        AllowPaging="True" PageSize="15" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand"
                        OnPageIndexChanging="allStudentGridView_PageIndexChanging" Width="100%">
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
                            <asp:TemplateField HeaderText="Father's Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("VarFatherName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Class">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("VarClassName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <%--<Itemtemplate>
                                <a href ='<%#"~/Student Info Entry/StudentAddmission.aspx?VarStudentID="+DataBinder.Eval(Container.DataItem,"VarStudentID") %>'> <%#Eval("VarStudentID")%>  </a>
                            </Itemtemplate>--%>
                                <ItemTemplate>
                                    <asp:Button ID="btnEdit" runat="server" Width="60" Text="Edit" OnClientClick="SetTarget()"
                                        CommandName="EditButton" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnView" runat="server" Width="60" Text="View" OnClientClick="SetTarget()"
                                        CommandName="ViewButton" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
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
    </fieldset>
</asp:Content>
