<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ShowClassWiseSubject.aspx.cs" Inherits="SubjectUI_ShowClassWiseSubject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <legend>Show Class Wise Subject </legend>
        <table>
            <tr>
                <td>
                    Class
                </td>
                <td>
                    <asp:DropDownList ID="classDropDownList" runat="server" AutoPostBack="True" AppendDataBoundItems="True"
                        DataSourceID="SqlDataSource1" DataTextField="VarClassName" 
                        DataValueField="VarClassID" 
                        onselectedindexchanged="classDropDownList_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="0">--Select Class--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [VarClassName], [VarClassID] FROM [Class]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="allSubjectGridView" runat="server" CellPadding="2" AutoGenerateColumns="False"
                        ForeColor="#333333" GridLines="Both" Width="100%" HorizontalAlign="Center" OnRowCancelingEdit="allSubjectGridView_RowCancelingEdit"
                        OnRowEditing="allSubjectGridView_RowEditing" OnRowUpdating="allSubjectGridView_RowUpdating">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="Subject Name">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_SubjectName" runat="server" Text='<%#Eval("VarSubjectName") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_SubjectName" runat="server" Text='<%#Eval("VarSubjectName") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subject Code">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_SubjectCode" runat="server" Text='<%#Eval("VarSubjectCode") %>'></asp:Label>
                                </ItemTemplate>
                                <%--<EditItemTemplate>
                                    <asp:TextBox ID="txt_SubjectCode" runat="server" Text='<%#Eval("VarSubjectCode") %>'></asp:TextBox>
                                </EditItemTemplate>--%>
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
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
