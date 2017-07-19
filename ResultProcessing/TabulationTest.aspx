<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TabulationTest.aspx.cs" Inherits="ResultProcessing_TabulationTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <fieldset>
        <legend>Test</legend>
         <asp:GridView ID="GridView1" runat="server"
        onrowdatabound="GridView1_RowDataBound">
    </asp:GridView>
    
    </fieldset>
</asp:Content>

