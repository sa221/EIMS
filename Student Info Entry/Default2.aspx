<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeFile="Default2.aspx.cs" Inherits="Student_Info_Entry_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script language="javascript" type="text/javascript">

        function PrintPage() {

            var printContent = document.getElementById('<%= pnlGridView.ClientID %>');

            var printWindow = window.open("All Records", "Print Panel", 'left=50000,top=50000,width=0,height=0');

            printWindow.document.write(printContent.innerHTML);

            printWindow.document.close();

            printWindow.focus();

            printWindow.print();

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="70%" id="pnlGridView" runat="server" align="center" class="ContentTable">
        <tr>
            <td colspan="2" align="center">
                <h1>
                    All Products in Store</h1>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView runat="server" ID="gvProducts" AutoGenerateColumns="false" AllowPaging="false"
                              AlternatingRowStyle-BackColor="Linen" HeaderStyle-BackColor="SkyBlue" Width="100%"
                              EmptyDataText="Sorry! No Products to List. First Add from Add Product Link.">
                    <Columns>
                        <asp:TemplateField HeaderText="Product ID">
                            <ItemTemplate>
                                <asp:Label ID="lblProductID" runat="server" Text='<%#Eval("ProductID") %>' ToolTip="ID of Product as stored in Database."></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <Columns>
                        <asp:TemplateField HeaderText="Product Name">
                            <ItemTemplate>
                                <asp:Label ID="lblProductName" runat="server" ToolTip="Name of Product" Text='<%#Eval("ProductName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <Columns>
                        <asp:TemplateField HeaderText="Brand">
                            <ItemTemplate>
                                <asp:Label ID="lblBrandName" runat="server" ToolTip="Brand of Product" Text='<%#Eval("BrandName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <Columns>
                        <asp:TemplateField HeaderText="Category">
                            <ItemTemplate>
                                <asp:Label ID="lblProductCat" runat="server" ToolTip="Category of Product" Text='<%#Eval("CategoryName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <Columns>
                        <asp:TemplateField HeaderText="In Stock">
                            <ItemTemplate>
                                <asp:Label ID="lblProductinStock" runat="server" ToolTip="Quantity available in Stock"
                                           Text='<%#Eval("UnitsInStock") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:LinkButton ID="lnkPrint" runat="server" ToolTip="Click to Print All Records"
                                Text="Print Data"></asp:LinkButton>
                <asp:LinkButton ID="lnkExportAll" runat="server" ToolTip="Export this List" Text="Export to Excel"></asp:LinkButton>
                <asp:LinkButton ID="lnkAddNew" runat="server" ToolTip="Add New Product" Text="Add New"></asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>