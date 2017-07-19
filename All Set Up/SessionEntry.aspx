<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeFile="SessionEntry.aspx.cs" Inherits="SessionEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <legend><b>
                    <h2>
                        Session Information</h2>
                </b></legend>
        <table class="style1">
            <tr>
                <td class="style4">
                    Session Code
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtSessionCode" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Session Name
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtSessiontName" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <br />
            <tr>
            <td class="style4">
                <asp:Button ID="sessionSave" runat="server" Text="Save" Width="81px" 
                            OnClientClick=" return validate(); " onclick="sessionSave_Click"
                    />
            </td>
            <td class="style3">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </td>
        </table>
    </fieldset>
    <br />
    <br />
    <fieldset>
        <legend><b>
                    <h2>
                        Session All Information</h2>
                </b></legend>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                      DataKeyNames="VarSessionId" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="VarSessionId" HeaderText="Session Id" 
                                ReadOnly="True" SortExpression="VarSessionId" />
                <asp:BoundField DataField="VarSessionName" HeaderText="Session Name" 
                                SortExpression="VarSessionName" />
                <asp:BoundField DataField="uid" HeaderText="User Name" SortExpression="uid" 
                                ReadOnly="True" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                           ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                           DeleteCommand="DELETE FROM [SessionInfo] WHERE [VarSessionId] = @VarSessionId" 
                           InsertCommand="INSERT INTO [SessionInfo] ([VarSessionId], [VarSessionName], [uid]) VALUES (@VarSessionId, @VarSessionName, @uid)" 
                           SelectCommand="SELECT [VarSessionId], [VarSessionName], [uid] FROM [SessionInfo]" 
                           UpdateCommand="UPDATE [SessionInfo] SET [VarSessionName] = @VarSessionName WHERE [VarSessionId] = @VarSessionId">
            <DeleteParameters>
                <asp:Parameter Name="VarSessionId" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="VarSessionId" Type="String" />
                <asp:Parameter Name="VarSessionName" Type="String" />
                <asp:Parameter Name="uid" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="VarSessionName" Type="String" />
                <asp:Parameter Name="uid" Type="String" />
                <asp:Parameter Name="VarSessionId" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </fieldset>
</asp:Content>