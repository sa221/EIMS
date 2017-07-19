<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="department.aspx.cs" Inherits="All_Set_Up_department" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <fieldset>
        <legend><b>
                    <h2>
                        DEPARTMENT Information</h2>
                </b></legend>
        <table class="style1">
           
            <tr>
                <td class="style4">
                    Department ID
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtdptid" runat="server" Width="130px"></asp:TextBox>
                    <br />
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtdptid" ErrorMessage="Please Enter Department Id" 
                        ForeColor="Red"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Department Name
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtdptname" runat="server" Width="130px"></asp:TextBox>
                    <br />
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtdptname" ErrorMessage="Please Enter Department Name" 
                        ForeColor="Red"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <br />
            <tr>
                <td class="style4">
                    <asp:Button ID="dptSave" runat="server" Text="Save" Width="81px" onclick="dptSave_Click" 
                       
                        />
                </td>
                <td class="style3">
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend><b>
                    <h2>
                        <b>
                            DEPARTMENT
                        </b>&nbsp;Information Details</h2>
                </b></legend>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                      DataKeyNames="dep_id" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="dep_id" HeaderText="Department Id" ReadOnly="True" 
                                SortExpression="dep_id" />
                <asp:BoundField DataField="dep_name" HeaderText="Department Name" 
                                SortExpression="dep_name" />
                <asp:BoundField DataField="uid" HeaderText="User Name" SortExpression="uid" 
                                ReadOnly="True" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                           ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                           DeleteCommand="DELETE FROM [tbl_department] WHERE [dep_id] = @dep_id" 
                           InsertCommand="INSERT INTO [tbl_department] ([dep_id], [dep_name], [uid]) VALUES (@dep_id, @dep_name, @uid)" 
                           SelectCommand="SELECT [dep_id], [dep_name], [uid] FROM [tbl_department]" 
            
            
                           UpdateCommand="UPDATE [tbl_department] SET [dep_name] = @dep_name WHERE [dep_id] = @dep_id">
            <DeleteParameters>
                <asp:Parameter Name="dep_id" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="dep_id" Type="String" />
                <asp:Parameter Name="dep_name" Type="String" />
                <asp:Parameter Name="uid" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="dep_name" Type="String" />
                <asp:Parameter Name="uid" Type="String" />
                <asp:Parameter Name="dep_id" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>

    </fieldset>
</asp:Content>