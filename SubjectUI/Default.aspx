<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="SubjectUI_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem Value="0">A</asp:ListItem>
        <asp:ListItem Value="1">B</asp:ListItem>
        <asp:ListItem Value="2">C</asp:ListItem>
        <asp:ListItem></asp:ListItem>
    </asp:DropDownList>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" Enabled="false"
        PopupControlID="PanelMonthly" TargetControlID="DropDownList1">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="PanelMonthly" runat="server" align="center" Style="display: none">
        <div class="modal-dialog">
            <div class="modal-content" style="background-color: #ededed">
                <div class="modal-header"> 
                    <h2 class="modal-title">
                        Add School Name</h2>
                </div>
                <div class="modal-body">
                    <b>School Name:</b><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_OnClick_OnClick_" />
                    <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_OnClick_" />
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
