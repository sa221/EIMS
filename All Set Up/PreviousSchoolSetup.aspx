<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="PreviousSchoolSetup.aspx.cs" Inherits="All_Set_Up_PreviousSchoolSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <legend>
            <h1>
                Previous School Setup</h1>
        </legend>
        <table>
            <tr>
                <td>
                    <b>School Name:</b>
                </td>
                <td>
                    <asp:TextBox ID="schoolNameTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
                </td>
                <td colspan="3">
                    <span class="label label-warning" style="background-color: #f0ad4e; float: left;
                        font-size: 20px; position: relative;" id="failStatusLabel" runat="server"></span>
                    <span class="label label-success" style="background-color: #5cb85c; float: left;
                        font-size: 20px; position: relative; position: absolute; z-index: 1;" id="successStatusLabel"
                        runat="server"></span>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="PreviousSchoolGridView" runat="server" CellPadding="2" AutoGenerateColumns="False"
                        AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" PageSize="10" ForeColor="#333333"
                        GridLines="Both" Width="100%" HorizontalAlign="Center">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Serial No">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle Width="2%" />
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel" />
                                </EditItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="School Name">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("SchoolName") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_Name" runat="server" Text='<%#Eval("SchoolName") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="Relation">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Relation" runat="server" Text='<%#Eval("ContactPersonRelation") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_Relation" runat="server" Text='<%#Eval("ContactPersonRelation") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Contact" runat="server" Text='<%#Eval("ContactNumber") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_Contact" runat="server" Text='<%#Eval("ContactNumber") %>'></asp:TextBox>
                                </EditItemTemplate>
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
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
