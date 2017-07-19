<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="WaiverAssign.aspx.cs" Inherits="AccountsUI_WaiverAssign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <fieldset>
        <legend><h1>Student Waiver Assign</h1></legend>
        <table>
            <tr>
                <td><b>Session: </b>
                    <asp:DropDownList ID="sessionDropDownList" runat="server" 
                                      DataSourceID="sessionSqlDataSource" DataTextField="VarSessionName" 
                                      DataValueField="VarSessionId">
                        <%--<asp:ListItem Value="0">--ALL--</asp:ListItem>--%>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="sessionSqlDataSource" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo] ORDER BY [VarSessionId] DESC">
                    </asp:SqlDataSource>
                </td>
                <td><b>Student ID: </b>
                    <asp:TextBox ID="studentIdTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="searchButton" runat="server" Text="Search" 
                                onclick="searchButton_Click" /></td>
            </tr>
            <tr>
                <td>
                    <b>Name: </b>
                    <asp:Label ID="nameLabel" runat="server" BorderStyle="Groove" Font-Bold="True" 
                               ForeColor="#000066"></asp:Label>
                </td>
               
            </tr>
            <tr>
                <td>
                    <b>Class: </b>
                    <asp:DropDownList ID="classDropDownList" runat="server">
                    </asp:DropDownList>
                </td>
                <td><b>From Month: </b>
                    <asp:DropDownList ID="fromMonthDropDownList" runat="server" AutoPostBack="True" 
                                      DataSourceID="SqlDataSource1" DataTextField="MonthName" 
                                      DataValueField="MonthId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT * FROM [tbl_Month]"></asp:SqlDataSource>
                </td>
                <td><b>To Month: </b>
                    <asp:DropDownList ID="toMonthDropDownList" runat="server" 
                                      DataSourceID="SqlDataSource2" DataTextField="MonthName" 
                                      DataValueField="MonthId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT * FROM [tbl_Month] WHERE ([MonthId] &gt; @MonthId)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="fromMonthDropDownList" Name="MonthId" 
                                                  PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    <asp:Button ID="saveButton" runat="server" Text="Save" 
                                onclick="saveButton_Click" /></td>
            </tr>
            <tr>
                <td colspan="4" class="">
                    <span class="label label-warning" style="background-color: #f0ad4e; float: left; font-size: 20px; position: relative;"
                          id="failStatusLabel" runat="server"></span>
                    <span class="label label-success"
                          style="background-color: #5cb85c; float: left; font-size: 20px; position: relative; position: absolute; z-index: 1;"
                          id="successStatusLabel" runat="server"></span>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:GridView ID="waiverHistoryGridView" runat="server" AutoGenerateColumns="False"
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
                                    <asp:Label ID="Label10" runat="server" Text='<%# Eval("InputDate", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Month">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("FromMonth") + " -TO- " + Eval("ToMonth") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="Invoice No">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("VarInvoiceNo") %>'></asp:Label>
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