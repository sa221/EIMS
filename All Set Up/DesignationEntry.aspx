<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeFile="DesignationEntry.aspx.cs" Inherits="Employee_DesignationEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <legend><b>
                    <h2>
                        Designation Information</h2>
                </b></legend>
        <table class="style1">
       
            <tr>
                <td class="style4">
                    Designation ID
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtEmpDegId" runat="server" Width="130px"></asp:TextBox>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Designation Name
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtEmpDegName" runat="server" Width="130px"></asp:TextBox>
                    <br />
                </td>
            </tr>
            <br />
            <tr>
                <td class="style4">
                    <asp:Button ID="desigSave" runat="server" Text="Save" Width="81px" 
                                OnClientClick=" return validate(); " 
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
                        Designation Information Details</h2>
                </b></legend>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                      DataKeyNames="NumDesignationId" DataSourceID="SqlDataSource1" 
                      AllowPaging="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="NumDesignationId" HeaderText="Designation Id" 
                                ReadOnly="True" SortExpression="NumDesignationId" />
                <asp:BoundField DataField="VarDesignationName" HeaderText="Designation Name" 
                                SortExpression="VarDesignationName" />
                <asp:BoundField DataField="uid" HeaderText="User Name" ReadOnly="true" 
                                SortExpression="uid" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                           ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                           SelectCommand="SELECT [NumDesignationId], [VarDesignationName], [uid] FROM [Designation]" 
                           DeleteCommand="DELETE FROM [Designation] WHERE [NumDesignationId] = @NumDesignationId" 
                           InsertCommand="INSERT INTO [Designation] ([NumDesignationId], [VarDesignationName], [uid]) VALUES (@NumDesignationId, @VarDesignationName, @uid)" 
            
            
                           UpdateCommand="UPDATE [Designation] SET [VarDesignationName] = @VarDesignationName WHERE [NumDesignationId] = @NumDesignationId">
            <DeleteParameters>
                <asp:Parameter Name="NumDesignationId" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="NumDesignationId" Type="Int32" />
                <asp:Parameter Name="VarDesignationName" Type="String" />
                <asp:Parameter Name="uid" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="VarDesignationName" Type="String" />
                <asp:Parameter Name="uid" Type="String" />
                <asp:Parameter Name="NumDesignationId" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>

    </fieldset>
</asp:Content>