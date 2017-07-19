<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    MaintainScrollPositionOnPostback="true" EnableEventValidation="false" CodeFile="EmpCategoryAndDesignationEntry.aspx.cs"
    Inherits="AllSetUpEmpCategoryAndDesignationEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            height: auto;
            width: 100%;
        }
        
        .style2
        {
            width: 100%;
        }
        .style3
        {
            width: 25%;
        }
        .tWidth
        {
            float: right;
        }
        .tdWidth
        {
            float: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <legend>
            <h1>
                Employee Category And Designation Entry</h1>
        </legend>
        <table class="style1">
            <tr>
                <td colspan="3">
                    <span class="label label-warning" style="background-color: #f0ad4e; float: left;
                        font-size: 20px; position: relative;" id="failStatusLabel" runat="server"></span>
                    <span class="label label-success" style="background-color: #5cb85c; float: left;
                        font-size: 20px; position: relative; position: absolute; z-index: 1;" id="successStatusLabel"
                        runat="server"></span>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="style3" style="vertical-align: top">
                    <fieldset>
                        <legend>
                            <h3>
                                Category Entry</h3>
                        </legend>
                        <table>
                            <tr>
                                <td>
                                    <b>Category Name:</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="ctgNameTextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="ctgSaveButton" runat="server" Text="Save" OnClick="ctgSaveButton_Click1" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:GridView ID="categoryGridView" runat="server" CellPadding="2" AutoGenerateColumns="False"
                                        ForeColor="#333333" GridLines="Both" Width="100%" HorizontalAlign="Center" OnRowDeleting="OnRowDeletingCategory">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="SL#">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Category Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:CommandField ButtonType="Button" HeaderText="Delete" ShowDeleteButton="True"
                                                ShowHeader="True" />
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
                </td>
                <td class="style3" style="vertical-align: top">
                    <fieldset>
                        <legend>
                            <h3>
                                Designation Entry</h3>
                        </legend>
                        <table>
                            <tr>
                                <td>
                                    <b>Designation Name:</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="degnationTextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="degSaveButton" runat="server" Text="Save" OnClick="degSaveButton_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:GridView ID="designationGridView" runat="server" CellPadding="2" AutoGenerateColumns="False"
                                        ForeColor="#333333" Width="100%" HorizontalAlign="Center" OnRowDeleting="OnRowDeletingDesegnation">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="SL#">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Category Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("VarDesignationName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:CommandField ButtonType="Button" HeaderText="Delete" ShowDeleteButton="True"
                                                ShowHeader="True" />
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
                                        <SortedAscendingCellStyle BackColor="#F8FAFA"></SortedAscendingCellStyle>
                                        <SortedAscendingHeaderStyle BackColor="#246B61"></SortedAscendingHeaderStyle>
                                        <SortedDescendingCellStyle BackColor="#D4DFE1"></SortedDescendingCellStyle>
                                        <SortedDescendingHeaderStyle BackColor="#15524A"></SortedDescendingHeaderStyle>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td class="style3" style="vertical-align: top">
                    <fieldset>
                        <legend>
                            <h3>
                                Qualification Degree Entry</h3>
                        </legend>
                        <table>
                            <tr>
                                <td>
                                    <b>Degree Name:</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="degreeTextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="degreeSaveButton" runat="server" Text="Save" 
                                        onclick="degreeSaveButton_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:GridView ID="degreeGridView" runat="server" CellPadding="2" AutoGenerateColumns="False"
                                        ForeColor="#333333" GridLines="Both" Width="100%" HorizontalAlign="Center" OnRowDeleting="OnRowDeletingDegree">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="SL#">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Degree Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("VarExamName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:CommandField ButtonType="Button" HeaderText="Delete" ShowDeleteButton="True"
                                                ShowHeader="True" />
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
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
