<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeFile="StudentAccountHistory.aspx.cs" Inherits="AccountsUI_StudentAccountHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <legend>
            <h1>
                Student Payment Ledger</h1>
        </legend>
        <table style="width: 100%">
            <tr>
                <td class="style1">
                    <b>Session Name</b>
                    <br />
                    <asp:DropDownList ID="sessionDropdownlist" runat="server" DataSourceID="SqlDataSource2"
                                      AppendDataBoundItems="True" DataTextField="VarSessionName" DataValueField="VarSessionId">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT * FROM [SessionInfo] ORDER BY [VarSessionName] DESC"></asp:SqlDataSource>
                    <br />
                </td>
                <td class="style1">
                    <br />
                    <b>Student ID</b>
                    <br />
                    <%--<asp:TextBox ID="branchinitialTextBox" runat="server" Width="20px"></asp:TextBox>--%>
                    <asp:TextBox ID="studentIdTexBox" runat="server"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="studentIdTexBox"
                                                ErrorMessage="Please Insert Student ID." ForeColor="red"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <br />
                    <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
                </td>
                <td style="text-align: center">
                    <asp:Label ID="Label6" runat="server" Text="Total Receivable:" Font-Size="20px"></asp:Label>
                    <asp:Label ID="receivaleLabel" runat="server" Text="" Font-Size="20px"></asp:Label>
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="Total Paid:" Font-Size="20px"></asp:Label>
                    <asp:Label ID="paidLabel" runat="server" Text="" Font-Size="20px"></asp:Label>
                    <br />
                    <asp:Label ID="Label8" runat="server" Text="Total Due:" Font-Size="20px"></asp:Label>
                    <asp:Label ID="dueLabel" runat="server" Text="" Font-Size="20px"></asp:Label>
                </td>
            </tr>
            <%-- <tr>
                <td colspan="4">
                    <br />
                    <span class="label label-warning" style="float: left; font-size: 15px; position: relative;
                        background-color: #f0ad4e" id="failStatusLabel" runat="server"></span><span class="label label-success"
                            style="float: left; font-size: 15px; position: relative; background-color: #5cb85c"
                            id="successStatusLabel" runat="server"></span>
                    <br />
                </td>
            </tr>--%>
            <tr>
                <td colspan="5">
                    <asp:GridView ID="feesHistoryGridView" runat="server" AutoGenerateColumns="False"
                                  ShowFooter="true" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
                                  BorderWidth="1px" Width="100%" CellPadding="4">
                        <%-- <HeaderStyle HorizontalAlign="Center" />--%>
                        <RowStyle HorizontalAlign="Center" />
                        <AlternatingRowStyle HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField HeaderText="SL#">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date">
                                <ItemTemplate>
                                    <asp:Label ID="Label10" runat="server" Text='<%# Eval("FeesAssignDate", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Session">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("VarSessionName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="Invoice No">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("VarInvoiceNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Receipt No">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("ReceiptNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fees Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("FeesType") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Receivable" SortExpression="PayableAmount">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("NetPayable") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Paid">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("NetPaid") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="Month To">
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("MonthTo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <%--<asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Vat">
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("Vat") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Net Amount">
                                <ItemTemplate>
                                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("NetAmount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="Black" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                        <SortedDescendingHeaderStyle BackColor="#002876" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>