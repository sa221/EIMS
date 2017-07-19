<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="House.aspx.cs" Inherits="All_Set_Up_House" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1 {
            height: 189px;
            width: 534px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <fieldset>
    <legend><b>House SetUp</b></legend>

    <table class="style1">
           
        <tr>
            <td class="style4">
                House Code</td>
            <td class="style3">
                <asp:TextBox ID="txthousecode" runat="server"></asp:TextBox>
                <br />
            </td>
            <td> Address</td>
            <td>
                <asp:TextBox ID="txtaddress" runat="server"></asp:TextBox>
                <br />
            </td>
        </tr>

        <tr>
            <td class="style4">
                House Name</td>
            <td class="style3">
                <asp:TextBox ID="txthouse" runat="server"></asp:TextBox>
                <br />
            </td>
            <td> Remarks</td>
            <td>
                <asp:TextBox ID="txtremarks" runat="server" Height="55px" TextMode="MultiLine" 
                             Width="179px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td> &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
            <td class="style4">
                <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save" />
            </td>
            <td class="style3">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </td>
            <td> &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>


    </table>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                  DataKeyNames="house_Code" DataSourceID="SqlDataSource2" AllowPaging="True">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="house_Code" HeaderText="House Code" 
                            SortExpression="house_Code" />
            <asp:BoundField DataField="house_name" HeaderText="House Name" 
                            SortExpression="house_name" />
            <asp:BoundField DataField="address" HeaderText="Address" 
                            SortExpression="address" />
            <asp:BoundField DataField="remarks" HeaderText="Remarks" 
                            SortExpression="remarks" />
            <asp:BoundField DataField="uid" HeaderText="User Name" SortExpression="uid" 
                            ReadOnly="True" />
        </Columns>
    </asp:GridView>



    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                       DeleteCommand="DELETE FROM [tblhouse] WHERE [house_Code] = @house_Code" 
                       InsertCommand="INSERT INTO [tblhouse] ([house_Code], [house_name], [address], [remarks], [uid]) VALUES (@house_Code, @house_name, @address, @remarks, @uid)" 
                       SelectCommand="SELECT [house_Code], [house_name], [address], [remarks], [uid] FROM [tblhouse]" 
            
                       UpdateCommand="UPDATE [tblhouse] SET [house_Code] = @house_Code,[house_name] = @house_name, [address] = @address, [remarks] = @remarks WHERE [house_Code] = @house_Code">
        <DeleteParameters>
            <asp:Parameter Name="house_Code" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="house_Code" Type="String" />
            <asp:Parameter Name="house_name" Type="String" />
            <asp:Parameter Name="address" Type="String" />
            <asp:Parameter Name="remarks" Type="String" />
            <asp:Parameter Name="uid" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="house_name" Type="String" />
            <asp:Parameter Name="address" Type="String" />
            <asp:Parameter Name="remarks" Type="String" />
            <asp:Parameter Name="uid" Type="String" />
            <asp:Parameter Name="house_Code" Type="String" />
               
        </UpdateParameters>
    </asp:SqlDataSource>




</asp:Content>