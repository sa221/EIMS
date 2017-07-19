<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager> <h2>
                             Create a New Account
                         </h2>
    <p>
        Use the form below to create a new account.
    </p>
    <p>
        Passwords are required to be a minimum of <%= Membership.MinRequiredPasswordLength %> characters in length.
    </p>
    <span class="failureNotification">
        <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
    </span>
    <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification" 
                           ValidationGroup="RegisterUserValidationGroup"/>
    <div class="accountInfo">
        <fieldset class="register">
            <legend>Account Information</legend>
            <p>
                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User ID:</asp:Label>
                <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                                            CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." 
                                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
            </p>
                            
            <p>
                <asp:Label ID="Label2" runat="server" AssociatedControlID="UserName">User Full Name:</asp:Label>
                <asp:TextBox ID="txtUserFull" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserFull" 
                                            CssClass="failureNotification" ErrorMessage="User Full Name is required." ToolTip="User Name is required." 
                                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
            </p> 
                            
            <p>
                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                <cc1:PasswordStrength ID="Password_PasswordStrength" runat="server" 
                                      Enabled="True" TargetControlID="Password">
                </cc1:PasswordStrength>
                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                                            CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>

            </p>
            <p>
                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
                <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                <cc1:PasswordStrength ID="ConfirmPassword_PasswordStrength" runat="server" 
                                      Enabled="True" TargetControlID="ConfirmPassword">
                </cc1:PasswordStrength>
            </p>
            <p>
                <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" CssClass="failureNotification" Display="Dynamic" 
                                            ErrorMessage="Confirm Password is required." ID="ConfirmPasswordRequired" runat="server" 
                                            ToolTip="Confirm Password is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                      CssClass="failureNotification" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
                                      ValidationGroup="RegisterUserValidationGroup"></asp:CompareValidator>
            </p>
            <p>
                Branch</p>
                                
            <p>
                <asp:DropDownList ID="DropDownList1" runat="server" 
                                  AppendDataBoundItems="true"   DataSourceID="SqlDataSource1" DataTextField="VarBranchName" 
                                  DataValueField="VarBranchID">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                   ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                   SelectCommand="SELECT * FROM [Branch]"></asp:SqlDataSource>
            </p>
            <p>
                Shift
                <br />
                <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" 
                                  AppendDataBoundItems="True"   DataTextField="VarShiftName" DataValueField="VarShiftCode">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                   ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                   SelectCommand="SELECT * FROM [ShiftInfo]"></asp:SqlDataSource>
            </p>
            <p>
                Role</p>
            <p>
                <asp:DropDownList ID="DropDownList3" runat="server" 
                                  DataSourceID="SqlDataSource3" DataTextField="role_name" 
                                  DataValueField="role_name">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                                   ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                   SelectCommand="SELECT * FROM [tbl_role]"></asp:SqlDataSource>
            </p>
                                     

        </fieldset>
        <p class="submitButton">
                           
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                           
            <asp:Button ID="CreateUserButton" runat="server"  Text="Create User" 
                        ValidationGroup="RegisterUserValidationGroup" 
                        onclick="CreateUserButton_Click"/>
        </p>
    </div>
</asp:Content>