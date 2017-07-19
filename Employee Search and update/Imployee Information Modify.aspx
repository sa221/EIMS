<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Imployee Information Modify.aspx.cs" Inherits="Employee_Imployee_Information_Modify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1 {
            height: auto;
            width: 735px;
        }

        .style2 { width: 300px; }

        .style3 { width: 272px; }

        .style4 { width: 350px; }

        .style5 {
            height: 250;
            width: 250px;
        }
    </style>
    <script type="text/javascript">

        function previewFile() {
            var preview = document.querySelector('#<%= imgEmployee.ClientID %>');
            var file = document.querySelector('#<%= FileUpload1.ClientID %>').files[0];
            var reader = new FileReader();

            reader.onloadend = function() {
                preview.src = reader.result;
            };
            if (file) {
                reader.readAsDataURL(file);
            } else {
                preview.src = "";
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <fieldset>
        <legend><b>
                    <h2>
                        Employee Information</h2>
                </b></legend>
        <table class="style1">
            <tr>
                <td class="style4">
                    User Name</td>
                <td class="style3">
                    <asp:TextBox ID="Textuid" runat="server" Text='<%# Session["uid"] %>'></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Branch Name
                </td>
                <td class="style3">
                    <asp:DropDownList ID="DropDownBranch" runat="server" 
                                      DataSourceID="SqlDataSource1" DataTextField="VarBranchName" 
                                      DataValueField="VarBranchID" Enabled="false">
                    </asp:DropDownList>
                    <br />
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT * FROM [Branch]"></asp:SqlDataSource>
                </td>
                <td> Shift Name</td>
                <td>
                    <asp:DropDownList ID="drpshift" runat="server" DataSourceID="SqlDataSource5" 
                                      DataTextField="VarShiftName" DataValueField="VarShiftCode" Enabled="false">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT * FROM [ShiftInfo]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Employee ID
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtEmpId" runat="server" Width="130px"></asp:TextBox>
                </td>
                <td class="style3">
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" Width="81px" onclick="btnSearch_Click" 
                        /></td>
            </tr>
            <tr>
                <td class="style4">
                    Employee Name
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtEmpName" runat="server" Width="130px" placeholder="Type your full Name which will be used in admission form"></asp:TextBox>
                </td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    Present Address
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtPresentAdd" runat="server" TextMode="MultiLine" Width="226px"
                                 Height="51px"></asp:TextBox>
                </td>
                <td class="style2">
                    Permanent Address
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtPermanentAdd" runat="server" TextMode="MultiLine" Width="226px"
                                 Height="51px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Employee City
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtEmpCity" runat="server" Width="130px"></asp:TextBox>
                </td>
                <td class="style2">
                    Employee Sex
                </td>
                <td class="style3">
                    <asp:RadioButton ID="radioMale" runat="server" Text="Male" GroupName="sex" />
                    <asp:RadioButton ID="radioFemale" runat="server" Text="Female" GroupName="sex" /></td>
            </tr>
            <tr>
                <td class="style4">
                    Blood Group
                </td>
                <td>
                    <asp:DropDownList ID="dropDownBlood" runat="server">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem>A+</asp:ListItem>
                        <asp:ListItem>A-</asp:ListItem>
                        <asp:ListItem>B+</asp:ListItem>
                        <asp:ListItem>B-</asp:ListItem>
                        <asp:ListItem>AB+</asp:ListItem>
                        <asp:ListItem>AB-</asp:ListItem>
                        <asp:ListItem>O+</asp:ListItem>
                        <asp:ListItem>O-</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style4">
                    Date Of Birth
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtDoB" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Employee Mobile No
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtEmpMob" runat="server" Width="130px"></asp:TextBox>
                </td>
                <td class="style4">
                    Employee Email
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtEmpEmail" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table class="style1">
            <tr>
                <td class="style4">
                    Father&#39;s Name
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtfather" runat="server" 
                                 Width="130px"></asp:TextBox>
                </td>
                <td class="style4">
                    Mother&#39;s Name
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtmother" runat="server" 
                                 Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Father&#39;s Occupation
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtfocc" runat="server" 
                                 Width="130px"></asp:TextBox>
                </td>
                <td class="style4">
                    Mother&#39;s Occupation
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtmotheroc" runat="server" 
                                 Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Father&#39;s Office Address
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtfoff" runat="server" 
                                 Width="226px" Height="51px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="style4">
                    Mother&#39;s Office Address
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtmadd" runat="server" TextMode="MultiLine" Width="226px" Height="51px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Father Contact No
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtfmob" runat="server" 
                                 Width="130px"></asp:TextBox>
                </td>
                <td class="style4">
                    Mother Contact No
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtmothermob" runat="server" 
                                 Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Religion
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtReligion" runat="server" Width="130px"></asp:TextBox>
                </td>
                <td class="style4">
                    Employee Scale
                </td>
                <td class="style3">
                    <asp:DropDownList ID="dropDownSalaryscale" runat="server" 
                                      DataSourceID="SqlDataSource2" DataTextField="VarScaleName" 
                                      DataValueField="VarScaleid">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT * FROM [SalaryScale]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Employee Department
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtEmpDepartment" runat="server" Width="130px"></asp:TextBox>
                </td>
                <td class="style4">
                    Employee Designation
                </td>
                <td class="style3">
                    <asp:DropDownList ID="dropDownDesignation" runat="server" 
                                      DataSourceID="SqlDataSource3" DataTextField="VarDesignationName" 
                                      DataValueField="NumDesignationId">
                        <asp:ListItem>---Select---</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT * FROM [Designation]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    Joining Date
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtJoinDate" runat="server" Width="130px"></asp:TextBox>
                </td>
                <td class="style4">
                    Leave Date
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtLeaveDate" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Leaved For
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtLeavedFor" runat="server" Width="130px"></asp:TextBox>
                </td>
                <td class="style4">
                    Status
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtEmpStatus" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    Employee Photo
                </td>
                <td class="style5">
                    <asp:Image ID="imgEmployee" runat="server" Width="150px" Height="150px" />
                    <br />
                    <br />
                    <asp:FileUpload ID="FileUpload1" runat="server" onchange="previewFile()" type="file"
                                    name="file" />
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Employee NID
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtNID" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Bank Name
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtBankName" runat="server" Width="130px"></asp:TextBox>
                </td>
                <td class="style4">
                    Bank Account No
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtAcc" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Extra Curriculam Note
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtExCuNote" runat="server" Width="130px"></asp:TextBox>
                </td>
                <td class="style4">
                    Interested Hobby
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtHobby" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Any Bad Note
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtBadNote" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend><b>
                    <h2>
                        Employee Marital Status</h2>
                </b></legend>
        <table class="style1">
            <tr>
                <td class="style4">
                    Marital Status
                </td>
                <td class="style3">
                    <asp:RadioButton ID="sradio1" runat="server" Text="Yes" GroupName="genderG"/>
                    <asp:RadioButton ID="sradio2" runat="server" Text="No" GroupName="genderG"/>
                </td>
                <%-- <asp:ValidationSummary ID="ValidationSummary1" runat="server" />--%>
                <td class="style2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Spouse Name
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtSpoName" runat="server" Width="130px"></asp:TextBox>
                </td>
                <td class="style2">
                    Spouse Address
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtSpoAdd" runat="server" TextMode="MultiLine" Width="226px" Height="51px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Spouse Occupation
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtSpoOcu" runat="server" Width="130px"></asp:TextBox>
                </td>
                <td class="style4">
                    Spouse Phone No
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtSpoPhn" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
        </table>
    </fieldset>

    <table>
        <tr>
            <td>
                <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                            onclick="btnUpdate_Click" />
            </td> 

            
       

       
            <td>
                <asp:Literal ID="Literal2" runat="server"></asp:Literal>
            </td> 
        
        
        </tr>
    </table>
   
</asp:Content>