<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeFile="FeesSetup.aspx.cs" Inherits="AccountsUI_FeesSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <legend><h1><b>
                        Fees Setup
                    </b></h1></legend>
        <table>
            <tr>
                <td>
                    Class Name
                </td>
                <td>
                    <asp:DropDownList ID="classDropDownList" runat="server" AutoPostBack="True" AppendDataBoundItems="True"
                                      DataSourceID="SqlDataSource1" DataTextField="VarClassName" 
                                      DataValueField="VarClassID">
                        <asp:ListItem Value="0">--Select Class--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT * FROM [Class]"></asp:SqlDataSource>
                </td>
                <td>
                    
                </td>
                <td colspan="2" rowspan="20">
                    <div style="height: auto; overflow: auto; position: relative; top: -3px" >
                        <asp:GridView ID="classAllFeesGridView" runat="server" 
                                      AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource3" 
                                      ForeColor="#333333" GridLines="None" AllowPaging="True" PageSize="5">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="VarFeesName" HeaderText="Fees Name" 
                                                SortExpression="VarFeesName" />
                                <asp:BoundField DataField="Fees" HeaderText="Fees" SortExpression="Fees" />
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
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                                           ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                           SelectCommand="SELECT [VarFeesName], [Fees] FROM [tbl_feesInfo] WHERE ([VarClassId] = @VarClassId)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="classDropDownList" Name="VarClassId" 
                                                      PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    Fees Name
                </td>
                <td>
                    <asp:DropDownList ID="feesNameDropDownList" runat="server" AppendDataBoundItems="True"
                                      DataSourceID="SqlDataSource2" DataTextField="FeesType" 
                                      DataValueField="Id">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT * FROM [tbl_feesType]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    Fees Amount
                </td>
                <td>
                    <asp:TextBox ID="feesAmountTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="typeCheckBox" runat="server" Text="If Yearly Fees" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="saveButton" runat="server" Text="Save" 
                                onclick="saveButton_Click" />
                </td>
                <td>
                    <asp:Literal ID="msgLiteral" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>