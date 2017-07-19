<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="User registration.aspx.cs" Inherits="Admin_User_registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>User List</h2>
    <p>Enter User ID
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="btnsearch" runat="server"  Text="Search" />
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                      BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
                      CellPadding="4" DataKeyNames="uid" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="user_full_name" HeaderText="USer Full Name" 
                                SortExpression="user_full_name" />
                <asp:BoundField DataField="uid" HeaderText="User Name" ReadOnly="True" 
                                SortExpression="uid" />
                <asp:BoundField DataField="upass" HeaderText="User Password" 
                                SortExpression="upass" />
                <asp:BoundField DataField="urole" HeaderText="User Role" 
                                SortExpression="urole" />
                <asp:TemplateField HeaderText="Branch Name" SortExpression="VarBranchId">
               
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" 
                                          DataSourceID="SqlDataSource1" DataTextField="VarBranchName" 
                                          DataValueField="VarBranchID" SelectedValue='<%# Bind("VarBranchID") %>'>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                           ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                           SelectCommand="SELECT * FROM [Branch]"></asp:SqlDataSource>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Shift Name" SortExpression="VarShiftCode">
               
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownList2" runat="server" 
                                          DataSourceID="SqlDataSource2" DataTextField="VarShiftName" 
                                          DataValueField="VarShiftCode" SelectedValue='<%# Bind("VarShiftCode") %>'>
                            <asp:ListItem Value="All">All</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                           ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                           SelectCommand="SELECT * FROM [ShiftInfo]"></asp:SqlDataSource>
                    </ItemTemplate>
                </asp:TemplateField>
            
                <asp:BoundField DataField="activationDate" HeaderText="Activation Date" 
                                SortExpression="activationDate" />
                <asp:CheckBoxField DataField="isactive" HeaderText="Active" />
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                           ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                           DeleteCommand="DELETE FROM [tbl_user_info] WHERE [uid] = @uid" 
                           InsertCommand="INSERT INTO [tbl_user_info] ([uid], [upass], [urole], [VarBranchId], [VarShiftCode], [isactive], [activationDate], [user_full_name]) VALUES (@uid, @upass, @urole, @VarBranchId, @VarShiftCode, @isactive, @activationDate, @user_full_name)" 
                           SelectCommand="SELECT * FROM [tbl_user_info] WHERE ([uid] = @uid)" 
                           UpdateCommand="UPDATE [tbl_user_info] SET [upass] = @upass, [urole] = @urole, [VarBranchId] = @VarBranchId, [VarShiftCode] = @VarShiftCode, [isactive] = @isactive, [activationDate] = @activationDate, [user_full_name] = @user_full_name WHERE [uid] = @uid">
            <DeleteParameters>
                <asp:Parameter Name="uid" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="uid" Type="String" />
                <asp:Parameter Name="upass" Type="String" />
                <asp:Parameter Name="urole" Type="String" />
                <asp:Parameter Name="VarBranchId" Type="String" />
                <asp:Parameter Name="VarShiftCode" Type="String" />
                <asp:Parameter Name="isactive" Type="String" />
                <asp:Parameter DbType="Date" Name="activationDate" />
                <asp:Parameter Name="user_full_name" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox1" Name="uid" PropertyName="Text" 
                                      Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="upass" Type="String" />
                <asp:Parameter Name="urole" Type="String" />
                <asp:Parameter Name="VarBranchId" Type="String" />
                <asp:Parameter Name="VarShiftCode" Type="String" />
                <asp:Parameter Name="isactive" Type="String" />
                <asp:Parameter DbType="Date" Name="activationDate" />
                <asp:Parameter Name="user_full_name" Type="String" />
                <asp:Parameter Name="uid" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
    
</asp:Content>