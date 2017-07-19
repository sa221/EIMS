<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Role Entry.aspx.cs" Inherits="Admin_Role_Entry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <fieldset>
        <legend>
            <b>Role Entry</b>
        </legend>
        <asp:TextBox ID="txtrole" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
        <br />
        <br />
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                      DataKeyNames="role_id" DataSourceID="SqlDataSource1" AllowPaging="True" 
                      AllowSorting="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="role_id" HeaderText="role_id" InsertVisible="False" 
                                ReadOnly="True" SortExpression="role_id" />
                <asp:BoundField DataField="role_name" HeaderText="role_name" 
                                SortExpression="role_name" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                           ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                           SelectCommand="SELECT * FROM [tbl_role]" 
                           DeleteCommand="DELETE FROM [tbl_role] WHERE [role_id] = @role_id" 
                           InsertCommand="INSERT INTO [tbl_role] ([role_name]) VALUES (@role_name)" 
                           UpdateCommand="UPDATE [tbl_role] SET [role_name] = @role_name WHERE [role_id] = @role_id">
            <DeleteParameters>
                <asp:Parameter Name="role_id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="role_name" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="role_name" Type="String" />
                <asp:Parameter Name="role_id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </fieldset>
</asp:Content>