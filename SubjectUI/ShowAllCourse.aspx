<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeFile="ShowAllCourse.aspx.cs" Inherits="SubjectUI_ShowAllCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <legend><b>
                    <h2>
                        Course Information</h2>
                </b></legend>
        <table class="style1">
            <tr>
                <td>
                    Select Class:
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True"
                                      DataSourceID="SqlDataSource1" DataTextField="VarClassName" 
                                      DataValueField="VarClassID">
                        <asp:ListItem Selected="True" Value="0">--Class--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT * FROM [Class]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>Show All Subject:</td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource2">
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>