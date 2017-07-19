<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeFile="Applicant_student_modify.aspx.cs" Inherits="Student_Info_Search_and_update_Applicant_student_modify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <fieldset>
        <legend><b>
                    <h2>
                        Student Information</h2>
                </b></legend>
        <table class="style1">
            <tr>
                <td>
                    Branch Name
                </td>
                <td>
                    <asp:DropDownList ID="drpbranch" runat="server" DataSourceID="SqlDataSource2" DataTextField="VarBranchName"
                                      DataValueField="VarBranchID" Enabled="False">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT * FROM [Branch]"></asp:SqlDataSource>
                </td>
                <td class="style5">
                    Shift Name
                </td>
                <td>
                    <asp:DropDownList ID="drpshift" runat="server" DataSourceID="SqlDataSource3" Enabled="False"
                                      DataTextField="VarShiftName" DataValueField="VarShiftCode">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT DISTINCT * FROM [ShiftInfo]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    Form ID
                </td>
                <td>
                    <asp:TextBox ID="txtregId" runat="server"></asp:TextBox>
                    <br />
                </td>
                <td class="style5">
                    <asp:Button ID="Search" runat="server" Text="Search" OnClick="Search_Click" />
                    <br />
                </td>
                <td>
                    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    Student's First Name
                </td>
                <td>
                    <br />
                    <asp:TextBox ID="txtsName" runat="server" placeholder="According To the certificate Name"></asp:TextBox>
                </td>
                <td>
                    Student's Middle Name
                </td>
                <td>
                    <asp:TextBox ID="middleNameTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Student's Last Name
                </td>
                <td>
                    <asp:TextBox ID="lastNameTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    
                </td>
                <td>
                    
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Father&#39;s Name
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtfather" runat="server" placeholder="According To the certificate Name"
                                 Width="130px"></asp:TextBox>
                    <br />
                </td>
                <td class="style5">
                    Mother&#39;s Name
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtmother" runat="server" placeholder="According To the certificate Name"
                                 Width="130px"></asp:TextBox>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Father&#39;s Occupation
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtfocc" runat="server" placeholder="According To the certificate Name"
                                 Width="130px"></asp:TextBox>
                    <br />
                </td>
                <td class="style5">
                    Mother&#39;s Occupation
                </td>
                <td class="style3">
                <asp:TextBox ID="txtmotheroc" runat="server" placeholder="According To the certificate Name"
                             Width="130px"></asp:TextBox>
                <br />
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;Father Mobile No
                </td>
                <td class="style3">
                    <br />
                    <asp:TextBox ID="txtfmob" runat="server" placeholder="According To the certificate Name"
                                 Width="130px"></asp:TextBox>
                    <br />
                </td>
                <td class="style5">
                    Mother mobile No&nbsp;
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtmothermob" runat="server" placeholder="According To the certificate Name"
                                 Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <br />
                    Present Address
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtpresentaddress" runat="server" Height="45px" TextMode="MultiLine"
                                 Width="191px"></asp:TextBox>
                    <br />
                </td>
                <td class="style5">
                    &nbsp;Emergency Contact No
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtemrgency" runat="server" Width="157px"></asp:TextBox>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="style4">
                    E-mail
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtfemail" runat="server" placeholder="Like..yyy@xxx.com" Width="207px"></asp:TextBox>
                </td>
                <td class="style5">
                    Referred By
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtReferred" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Admission Sought For Class
                </td>
                <td class="style3">
                    <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource1"
                                      DataTextField="VarClassName" AppendDataBoundItems="true" DataValueField="VarClassID">
                        <asp:ListItem Value="0">--select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT * FROM [Class]"></asp:SqlDataSource>
                </td>
                <td class="style5">
                    &nbsp;
                </td>
                <td class="style3">
                    <br />
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Student Image
                </td>
                <td class="style3">
                    <asp:Image ID="imgstudent" runat="server" Height="146px" Width="120px" />
                    <br />
                    <br />
                    <asp:FileUpload ID="FileUpload1" runat="server" onchange="previewFile()" type="file"
                                    name="file" />
                </td>
                <td class="style5">
                    Date Of birth
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtdob" runat="server"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend><b>
                    <h2>
                        Privious School Information</h2>
                </b></legend>
        <table class="style1">
            <tr>
                <td class="style4">
                    Name Of The School
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <br />
                </td>
                <td>
                    Class
                </td>
                <td class="style4">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Year
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                    --TO--
                    <asp:DropDownList ID="DropDownList2" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
                <td class="style4">
                    &nbsp;
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend><b>
                    <h2>
                        SIBILING&#39;S Information</h2>
                </b></legend>
        <table class="style1">
            <tr>
                <td class="style4">
                    Sibilings name
                </td>
                <td class="style3">
                    <br />
                    <asp:TextBox ID="txtsibilingsname" runat="server" placeholder="Like..01xxxxxxxxxx"
                                 Width="226px"></asp:TextBox>
                    <br />
                    &nbsp;
                </td>
                <td class="style4">
                    Sibilings roll
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtsroll" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Sibilings class
                </td>
                <td class="style3">
                    <asp:DropDownList ID="drpClass" runat="server" DataSourceID="SqlDataSource5" AppendDataBoundItems="true"
                                      DataTextField="VarClassName" DataValueField="VarClassID">
                        <asp:ListItem Value="0">--select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT * FROM [Class]"></asp:SqlDataSource>
                </td>
                <td class="style4">
                    Sibilings section
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtssec" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;
                </td>
                <td class="style3">
                    &nbsp;
                </td>
                <td class="style2">
                    &nbsp;
                    <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
                </td>
                <td>
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>