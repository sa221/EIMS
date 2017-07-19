<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeFile="SalaryScaleEntry.aspx.cs" Inherits="Employee_SalaryScaleEntry" %>

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
                    Scale ID
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtScaleId" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Scale Name
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtScaleName" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Basic
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtBasic" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    House Rent
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtHouseRent" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Medical
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtMedical" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Transport
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtTransport" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Increment
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtIncrement" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    PF
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtPf" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Others
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtOthers" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <br />
            <tr>
            <td class="style4">
                <asp:Button ID="scaleSave" runat="server" Text="Save" Width="81px" 
                            OnClientClick=" return validate(); " onclick="scaleSave_Click" />
            </td>
            <td class="style3">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </td>
        </table>
    </fieldset>
    <fieldset>
        <legend><b>
                    <h2>
                        Salary Scale Details</h2>
                </b></legend>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                      AutoGenerateColumns="False" DataKeyNames="VarScaleid" 
                      DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="VarScaleid" HeaderText="VarScaleid" ReadOnly="True" 
                                SortExpression="VarScaleid" />
                <asp:BoundField DataField="VarScaleName" HeaderText="VarScaleName" 
                                SortExpression="VarScaleName" />
                <asp:BoundField DataField="FltBasic" HeaderText="FltBasic" 
                                SortExpression="FltBasic" />
                <asp:BoundField DataField="FltHouseRent" HeaderText="FltHouseRent" 
                                SortExpression="FltHouseRent" />
                <asp:BoundField DataField="FltMedical" HeaderText="FltMedical" 
                                SortExpression="FltMedical" />
                <asp:BoundField DataField="FltTransport" HeaderText="FltTransport" 
                                SortExpression="FltTransport" />
                <asp:BoundField DataField="FltIncrement" HeaderText="FltIncrement" 
                                SortExpression="FltIncrement" />
                <asp:BoundField DataField="FltPF" HeaderText="FltPF" 
                                SortExpression="FltPF" />
                <asp:BoundField DataField="FltOther" HeaderText="FltOther" 
                                SortExpression="FltOther" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                           ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                           SelectCommand="SELECT * FROM [SalaryScale]" 
                           DeleteCommand="DELETE FROM [SalaryScale] WHERE [VarScaleid] = @VarScaleid" 
                           InsertCommand="INSERT INTO [SalaryScale] ([VarScaleid], [VarScaleName], [FltBasic], [FltHouseRent], [FltMedical], [FltTransport], [FltIncrement], [FltPF], [FltOther]) VALUES (@VarScaleid, @VarScaleName, @FltBasic, @FltHouseRent, @FltMedical, @FltTransport, @FltIncrement, @FltPF, @FltOther)" 
                           UpdateCommand="UPDATE [SalaryScale] SET [VarScaleName] = @VarScaleName, [FltBasic] = @FltBasic, [FltHouseRent] = @FltHouseRent, [FltMedical] = @FltMedical, [FltTransport] = @FltTransport, [FltIncrement] = @FltIncrement, [FltPF] = @FltPF, [FltOther] = @FltOther WHERE [VarScaleid] = @VarScaleid">
            <DeleteParameters>
                <asp:Parameter Name="VarScaleid" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="VarScaleid" Type="Int32" />
                <asp:Parameter Name="VarScaleName" Type="String" />
                <asp:Parameter Name="FltBasic" Type="Double" />
                <asp:Parameter Name="FltHouseRent" Type="Double" />
                <asp:Parameter Name="FltMedical" Type="Double" />
                <asp:Parameter Name="FltTransport" Type="Double" />
                <asp:Parameter Name="FltIncrement" Type="Double" />
                <asp:Parameter Name="FltPF" Type="Double" />
                <asp:Parameter Name="FltOther" Type="Double" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="VarScaleName" Type="String" />
                <asp:Parameter Name="FltBasic" Type="Double" />
                <asp:Parameter Name="FltHouseRent" Type="Double" />
                <asp:Parameter Name="FltMedical" Type="Double" />
                <asp:Parameter Name="FltTransport" Type="Double" />
                <asp:Parameter Name="FltIncrement" Type="Double" />
                <asp:Parameter Name="FltPF" Type="Double" />
                <asp:Parameter Name="FltOther" Type="Double" />
                <asp:Parameter Name="VarScaleid" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </fieldset>
</asp:Content>