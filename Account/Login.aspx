<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Account/login.master" AutoEventWireup="true"
         CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Log In
    </h2>
    <p>
        Please enter your username and password.
         <asp:LinkButton ID="linkGoSomewhere" runat="server" 
            Click="linkGoSomewhere_Click" Text="Register" onclick="linkGoSomewhere_Click"/> if you don't have an account.
        <%--<asp:HyperLink ID="RegisterHyperLink" runat="server" EnableViewState="False">Register</asp:HyperLink> --%>
    </p>
    <table cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
        <tr>
            <td>
                <table cellpadding="0">
                    <tr>
                        <td align="center" colspan="2">
                            Log In</td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                                        ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                                        ToolTip="User Name is required." ValidationGroup="Login1" ForeColor="red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                                        ControlToValidate="Password" ErrorMessage="Password is required." 
                                                        ToolTip="Password is required." ValidationGroup="Login1" ForeColor="red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" style="color: Red;">
                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">
                            <asp:Label ID="lbllogin" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" 
                                        ValidationGroup="Login1" onclick="LoginButton_Click"   />
                            <br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <tr><td>
            <h3>
                <asp:Label ID="Label1" runat="server" 
                           Text="* If You Can't Access The page You want.... Thats mean you are not authorized To go there. " 
                           ForeColor="Red" Width="662px" Font-Bold="True"></asp:Label>
            </h3></td></tr>
</asp:Content>