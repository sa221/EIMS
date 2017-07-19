<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeFile="inputClass.aspx.cs" Inherits="inputClass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <legend><b>
                    <h2>
                        Class Information</h2>
                </b></legend>
        <table class="style1">
            <%--<tr>
                <td class="style4">
                    User Name</td>
                <td class="style3">
                    <asp:TextBox ID="Textuid" runat="server" Text='<%# Session["uid"] %>' 
                        ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Branch Name
                </td>
                <td class="style3">
                    <asp:DropDownList ID="DropDownBranch" runat="server" 
                        DataSourceID="SqlDataSource1" DataTextField="VarBranchName" 
                        DataValueField="VarBranchID" Enabled="False">
                        <asp:ListItem>--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                        SelectCommand="SELECT * FROM [Branch]"></asp:SqlDataSource>
                </td>
                <td> Shift Name</td>
                <td>
                    <asp:DropDownList ID="drpshift" runat="server" DataSourceID="SqlDataSource4" 
                        DataTextField="VarShiftName" DataValueField="VarShiftCode" Enabled="False">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                        SelectCommand="SELECT * FROM [ShiftInfo]"></asp:SqlDataSource>
                </td>
            </tr>--%>
            <tr>
                <td class="style4">
                    <b>Class Code</b>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtClassCode" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <b>Class Name</b>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtclass" runat="server"></asp:TextBox>
                </td>
                <td class="style4">
                    <b>Campus</b>
                </td>
                <td class="style3">
                    <asp:DropDownList ID="houseDropDownList" runat="server" AppendDataBoundItems="True"
                                      DataSourceID="SqlDataSource2" DataTextField="house_name" DataValueField="house_name">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT * FROM [tblhouse]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="typeCheckBox" runat="server" Text="If 'A' Level Class" />
                </td>
                <td>
                    <asp:RadioButton ID="edexcelRB" runat="server" Text="EDEXCEL" GroupName="board" />
                    <asp:RadioButton ID="cambridgeRB" runat="server" Text="CAMBRIDGE" GroupName="board" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Width="57px" />
                </td>
                <td>
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </fieldset>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="VarClassID"
                  DataSourceID="SqlDataSource3" AllowPaging="True" CellPadding="4" 
                  ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="VarClassID" HeaderText="Class ID" 
                            SortExpression="VarClassID" ReadOnly="True" />
            <asp:BoundField DataField="VarClassName" HeaderText="Class Name" 
                            SortExpression="VarClassName" />
            <%-- <asp:TemplateField HeaderText="Campus Name" SortExpression="houseid" >
                  
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="true"
                            DataSourceID="SqlDataSource1" DataTextField="house_name" 
                            DataValueField="house_Code" SelectedValue='<%# Bind("houseid") %>' >
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                            SelectCommand="SELECT * FROM [tblhouse]"></asp:SqlDataSource>
                    </ItemTemplate>
                </asp:TemplateField>--%>
            <asp:BoundField DataField="houseid" HeaderText="Campus Name" 
                            SortExpression="houseid" />
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
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                       SelectCommand="SELECT VarClassID, VarClassName, houseid FROM Class" 
                       DeleteCommand="DELETE FROM [Class] WHERE [VarClassID] = @VarClassID"
        
        
                       UpdateCommand="UPDATE Class SET VarClassID = @VarClassID, VarClassName = @VarClassName , houseid = @houseid WHERE (VarClassID = @VarClassID)">
        <UpdateParameters>
            <asp:Parameter Name="VarClassID" Type="String" />
            <asp:Parameter Name="VarClassName" />
            <asp:Parameter Name="houseid" />
        </UpdateParameters>
        <DeleteParameters>
            <asp:Parameter Name="VarClassID" />
        </DeleteParameters>
    </asp:SqlDataSource>
  
</asp:Content>