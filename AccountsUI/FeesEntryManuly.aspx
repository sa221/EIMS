<%--<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" 
CodeFile="FeesEntryManuly.aspx.cs" Inherits="AccountsUI_FeesEntryManuly" %>--%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeFile="FeesEntryManuly.aspx.cs" Inherits="AccountsUI_FeesEntryManuly" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script type="text/javascript">

        $(document).ready(function() {
            $("#MainContent_feesAmountTextBox").focusout(function() {
                var x = parseInt($("#MainContent_feesAmountTextBox").val());
                var y = (x * 0.075);
                $("#MainContent_VatTextBox").val(y);
                $("#MainContent_netAmountTextBox").val(x + y);

            });

        });


    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <fieldset>
        <legend> Student Fees Entry</legend>
        <table>
            <tr>
                <td>Session:<asp:DropDownList ID="sessionDropDownList" runat="server" 
                                              DataSourceID="SqlDataSource1" DataTextField="VarSessionName" 
                                              DataValueField="VarSessionId">
                            </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo] ORDER BY [VarSessionId] DESC">
                    </asp:SqlDataSource>
                </td>
                <td >Student ID:<asp:TextBox ID="studentIdTextBox" runat="server"></asp:TextBox></td>
                <td colspan="2">
                    <asp:Button ID="searchButton" runat="server" Text="Search" 
                                onclick="searchButton_Click" />
                    <asp:Literal ID="msgLiteral" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>
                    Class:<asp:DropDownList ID="classDropDownList" 
                                            runat="server" >
                          </asp:DropDownList>
                   
                </td>
                <td>Fees Name:<asp:DropDownList ID="feesNameDropDownList" runat="server" 
                                                AutoPostBack="True" 
                                                onselectedindexchanged="feesNameDropDownList_SelectedIndexChanged">
                              </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Fees Amount:<asp:TextBox ID="feesAmountTextBox" runat="server" ></asp:TextBox></td>
                <td>Vat:<asp:TextBox ID="VatTextBox" runat="server"></asp:TextBox></td>
                <td>Net Amount:<asp:TextBox ID="netAmountTextBox" runat="server"></asp:TextBox></td>
                <td>
                    <asp:Button ID="saveButton" runat="server" Text="Save" 
                                onclick="saveButton_Click" /></td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:GridView ID="feesHistoryGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="feesHistoryGridView_RowCommand"
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
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:Button ID="btnDelete" runat="server" Width="50" Text="Delete" CssClass="btn btn-default"  CommandName="DeleteButton" 
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
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