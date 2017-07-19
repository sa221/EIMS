<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeFile="FeesCollection.aspx.cs" Inherits="AccountsUI_FeesCollection" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function() {
                $('#<%= feesTableGridView.ClientID %>').Scrollable();
            }
        )
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <fieldset>
        <legend><b>Fees Collection </b></legend>
        <table>
            <tr>
                <td>
                    Session
                    <br />
                    <asp:DropDownList ID="sessionDropDownList" runat="server" AppendDataBoundItems="False"
                                      DataSourceID="SqlDataSource5" DataTextField="VarSessionName" DataValueField="VarSessionId"
                                      AutoPostBack="True" OnSelectedIndexChanged="sessionDropDownList_SelectedIndexChanged">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT * FROM [SessionInfo] ORDER BY [VarSessionName] DESC"></asp:SqlDataSource>
                </td>
                
                <td>
                    Student ID
                    <br />
                    <asp:DropDownList ID="branchDropDownList" runat="server" DataSourceID="SqlDataSource1" Width="50px"
                                      DataTextField="VarBranchInitial" DataValueField="VarBranchID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT * FROM [Branch] ORDER BY [VarBranchInitial] DESC"></asp:SqlDataSource>
                    <asp:TextBox ID="txtStudentId" runat="server" Width="80px"></asp:TextBox>
                </td>
                <td><br/>
                    <asp:Button ID="SearchButton" runat="server" Text="Search" BorderStyle="Solid" OnClick="SearchButton_Click" />
                </td>
                <td>
                    <asp:Label ID="msgLabel" runat="server" Text=""></asp:Label>
                </td>
                <td colspan="2" rowspan="4">
                    <asp:GridView ID="feesTableGridView" runat="server" AutoGenerateColumns="False" Height="150px"
                                  CellPadding="4" DataSourceID="SqlDataSource6" ForeColor="#333333" GridLines="None"
                                  AllowPaging="True" PageSize="5">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="VarFeesName" HeaderText="Fees Name" SortExpression="VarFeesName" />
                            <asp:BoundField DataField="Fees" HeaderText="Fees" SortExpression="Fees" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT [VarFeesName], [Fees] FROM [tbl_feesInfo] WHERE ([VarClassId] = @VarClassId)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="classIdTextBox" Name="VarClassId" PropertyName="Text"
                                                  Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    Student Name
                    <br />
                    <asp:TextBox ID="studentNameTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    Father Name
                    <br />
                    <asp:TextBox ID="fatherNameTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    Class Name
                    <br />
                    <asp:TextBox ID="classTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <%--Class Code--%>
                    <br />
                    <asp:TextBox ID="classIdTextBox" runat="server" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Section/Shift
                    <br />
                    <asp:TextBox ID="sectionTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    Roll
                    <br />
                    <asp:TextBox ID="rollTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    Date
                    <br />
                    <asp:TextBox ID="dateTextBox" runat="server"></asp:TextBox>
                    <br />
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dateTextBox">
                    </cc1:CalendarExtender>
                </td>
               
            </tr>
            <tr>
                <td>
                    Fees Name
                    <br/>
                    <asp:DropDownList ID="feesTypeDropDownList" runat="server" >
                    </asp:DropDownList>
                    <%--<asp:DropDownList ID="feesTypeDropDownList" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2"
                        AppendDataBoundItems="True" DataTextField="VarFeesName" DataValueField="FeesId"
                        OnSelectedIndexChanged="feesTypeDropDownList_SelectedIndexChanged">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT * FROM [tbl_feesInfo] WHERE ([VarClassId] = @VarClassId)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="classIdTextBox" Name="VarClassId" PropertyName="Text"
                                Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>--%>
                </td>
                <td>
                    Receipt No.
                    <br />
                    <asp:TextBox ID="receiptTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="feesMsgLabel" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <%-- <tr>
                <td>
                    <asp:TextBox ID="monthTextBox" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="dtPickerFrom" runat="server" CssClass="calendarClass" Enabled="true"
                        Format="MMM-yy"  TargetControlID="monthTextBox"
                        >
                    </cc1:CalendarExtender>
                </td>
            </tr>--%>
            <tr>
                <td>
                    Month From
                    <br />
                    <asp:DropDownList ID="monthFromDropDownList" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource3"
                                      AppendDataBoundItems="True" DataTextField="MonthName" DataValueField="MonthId">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT * FROM [tbl_Month]"></asp:SqlDataSource>
                </td>
                <td>
                    Month To
                    <br />
                    <asp:DropDownList ID="monthToDropDownList" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource4"
                                      DataTextField="MonthName" DataValueField="MonthId" OnSelectedIndexChanged="monthToDropDownList_SelectedIndexChanged">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT * FROM [tbl_Month] WHERE ([MonthId] &gt;= @MonthId)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="monthFromDropDownList" Name="MonthId" PropertyName="SelectedValue"
                                                  Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    Amount
                    <br />
                    <asp:TextBox ID="amountTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    Vat
                    <br />
                    <asp:TextBox ID="vatTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    Net Amount
                    <br />
                    <asp:TextBox ID="netAmountTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <br />
                    <asp:Button ID="addButton" runat="server" Text="Add" OnClick="addButton_Click" AccessKey="a" />
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:GridView ID="addFeesGridView" AutoGenerateColumns="False" OnRowDataBound="OnRowDataBound" ShowFooter="true"
                                  runat="server" OnRowDeleting="OnRowDeleting" CellPadding="4" ForeColor="#333333"
                                  GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <%-- <asp:BoundField DataField="SiNo" HeaderText="Serial No." />--%>
                            <asp:TemplateField HeaderText="Serial No">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle Width="2%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="FeesName" HeaderText="Fees Name" />
                            <asp:BoundField DataField="MonthFrom" HeaderText="Month From" />
                            <asp:BoundField DataField="MonthTo" HeaderText="Month To" />
                            <asp:BoundField DataField="Session" HeaderText="Session" />
                            <asp:BoundField DataField="Amount" HeaderText="Amount" />
                            <asp:BoundField DataField="Vat" HeaderText="Vat7.5%" />
                            <asp:BoundField DataField="NetAmount" HeaderText="Net Amount" />
                            <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
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
                </td>
            </tr>
            <br />
            <tr>
                <td>
                    <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
                </td>
                <td>
                    <asp:Literal ID="saveMsgLiteral" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:GridView ID="feesHistoryGridView" runat="server" AutoGenerateColumns="False"
                                  BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                                  CellPadding="4">
                        <Columns>
                            <asp:TemplateField HeaderText="SL#">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Invoice No">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("VarInvoiceNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Receipt No">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("ReceiptNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fees Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("FeesName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Session">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Session") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Month From">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("MonthFrom") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Month To">
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("MonthTo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
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
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date">
                                <ItemTemplate>
                                    <asp:Label ID="Label10" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
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