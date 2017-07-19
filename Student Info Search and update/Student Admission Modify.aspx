<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Student Admission Modify.aspx.cs" Inherits="Student_Admission_Modify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1 {
            height: auto;
            width: 735px;
        }

        .style2 { width: 300px; }

        .style3 { width: 272px; }

        .style4 { width: 300px; }

        .style5 {
            height: 250;
            width: 250px;
        }
    </style>
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript">
    
    </script>


    <script type="text/javascript">

        function previewFile() {
            var preview = document.querySelector('#<%= imgstudent.ClientID %>');
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
    <script type="text/javascript">

        function previewFile1() {
            var preview = document.querySelector('#<%= Image2.ClientID %>');
            var file = document.querySelector('#<%= FileUpload2.ClientID %>').files[0];
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

    <script type="text/javascript">

        function previewFile2() {
            var preview = document.querySelector('#<%= Image3.ClientID %>');
            var file = document.querySelector('#<%= FileUpload3.ClientID %>').files[0];
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
    <%--For Showing Image--%><%--
    <script type="text/javascript">
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('.StudentImage').attr('src', e.target.result).width(150).height(200)
                };

                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>--%>
  
    <script language='javascript'>

        function fnToogleTable(obj) {
            var objTable = document.getElementById('tblsibilings');

            if (obj.checked) {


                objTable.style.display = "block";

            } else {
                objTable.style.display = "none";


            }

            return false;
        }
    </script>

    <script>

        function fnToogleTable1(obj) {
            var objTable = document.getElementById('tblsibilings');

            if (obj.checked) {


                objTable.style.display = "none";

            } else {
                objTable.style.display = "block";


            }

            return false;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <legend><b>
                    <h2>
                        Student Information</h2>
                </b></legend>
        <table class="style1">
            <tr>
                <td class="style4">
                    User Name</td>
                <td class="style3">
                    <asp:TextBox ID="txtuid" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    Branch Name</td>
                <td class="style3">
                    <asp:DropDownList ID="drpbranch" runat="server" 
                                      DataSourceID="SqlDataSource4" DataTextField="VarBranchName" 
                                      Enabled="false"  DataValueField="VarBranchID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT * FROM [Branch]"></asp:SqlDataSource>
                </td>
                <td class="style2">
                    Shift Name</td>
                <td>
                    <asp:DropDownList ID="drpshift" runat="server" 
                                      Enabled="false" DataSourceID="SqlDataSource5" DataTextField="VarShiftName" 
                                      DataValueField="VarShiftCode">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT * FROM [ShiftInfo]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Student ID
                </td>
                <td class="style3">
                    <%-- <asp:DropDownList ID="drpid" runat="server">
                    <asp:ListItem Value="0">-- Select --</asp:ListItem>
                    </asp:DropDownList>&nbsp;--%>
                    <asp:TextBox ID="txtid" runat="server" Width="130px" 
                        ></asp:TextBox>
                </td>
                <td class="style2">
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" Width="81px" 
                                OnClientClick=" return validate(); " onclick="btnSearch_Click"
                        />
                </td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
           
            <tr>
                <td class="style4">
                    Student First Name
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtfname" runat="server" Width="130px" placeholder="Type your full Name which will be used in admission form"></asp:TextBox>
                </td>
                <td class="style2">
                    Registration ID&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtregid" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Student Middle Name
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtmname" runat="server" Width="130px"></asp:TextBox>
                </td>
            </td>
                <td class="style2">
                    Private
                </td>
                <td>
                    <asp:CheckBox ID="chkprivate" runat="server" Text=" " />
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Student Last Name
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtlname" runat="server" Width="130px" placeholder="Type your full Name which will be used in admission form"></asp:TextBox>
                </td>
                <td class="style2">
                    Session Name
                </td>
                <td>
                    <asp:DropDownList ID="drpsession" runat="server" DataSourceID="SqlDataSource2" 
                                      DataTextField="VarSessionName" DataValueField="VarSessionId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT * FROM [SessionInfo]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Student Address
                </td>
                <td class="style3">
                    <br />
                    <asp:TextBox ID="txtpresent" runat="server" TextMode="MultiLine" Width="226px" Height="51px"></asp:TextBox>
                </td>
                <td class="style2">
                    &nbsp;
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    Date Of Birth
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtdob" runat="server" Width="130px"></asp:TextBox>
                </td>
                <td class="style2">
                    Privious School Attendence
                </td>
                <td>
                    <asp:TextBox ID="txtprivscl" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Sex
                </td>
                <td class="style3">
                    <asp:RadioButton ID="malerbutton" runat="server" Text="Male" GroupName="sex" />
                    <asp:RadioButton ID="femalerbutton" runat="server" Text="Female" GroupName="sex" />
                </td>
                <td class="style4">
                    Nationality
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtnational" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Religion
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtrel" runat="server" Width="130px"></asp:TextBox>
                </td>
                <td class="style4">
                    Phone (Residence)
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtphone" runat="server" placeholder="Like..01xxxxxxxxxx" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Mobile
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtmobile" runat="server" placeholder="Like..01xxxxxxxxxx" Width="130px"></asp:TextBox>
                </td>
                <td class="style4">
                    Blood Group
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
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
            </tr>
            <tr>
                <td class="style5">
                    Student Photo
                </td>
                <td class="style5">
                    <asp:Image ID="imgstudent" runat="server" Width="150px" height="150px"  />
                    <br />
                    <br />
                    <asp:FileUpload ID="FileUpload1" runat="server" onchange="previewFile()" type="file" name="file"  />
                </td>
                <td class="style5">
                    Birth Certificate
                </td>
                <td class="style5">
                    <asp:Image ID="Image2" runat="server" Width="150px" height="150px" />
                    <br />
                    <br />
                    <asp:FileUpload ID="FileUpload2" runat="server" onchange="previewFile1()" type="file" name="file"  />
                </td>
            </tr>
            <tr>
                <td>
                    Admission Form
                </td>
                <td class="style5">
                    <asp:Image ID="Image3" runat="server" Width="150px" height="150px" />
                    <br />
                    <br />
                    <asp:FileUpload ID="FileUpload3" runat="server" onchange="previewFile2()" type="file" name="file"  />
                </td>
            </tr>
           
        </table>
    </fieldset>
    <fieldset>
        <legend><b>
                    <h2>
                        Parent's Information</h2>
                </b></legend>
        <table class="style1">
            <tr>
                <td class="style4">
                    Father&#39;s Name
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtfather" runat="server" placeholder="According To the certificate Name"
                                 Width="130px"></asp:TextBox>
                </td>
                <td class="style4">
                    Mother&#39;s Name
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtmother" runat="server" placeholder="According To the certificate Name"
                                 Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Father&#39;s Occupation
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtfocc" runat="server" placeholder="According To the certificate Name"
                                 Width="130px"></asp:TextBox>
                </td>
                <td class="style4">
                    Mother&#39;s Occupation
                </td>
                <td class="style3">
                <asp:TextBox ID="txtmotheroc" runat="server" placeholder="According To the certificate Name"
                             Width="130px"></asp:TextBox>
            </tr>
            <tr>
                <td class="style4">
                    Father&#39;s Office Address
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtfoff" runat="server" placeholder="According To the certificate Name"
                                 Width="226px" Height="51px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="style4">
                    Mother Office Address
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtmadd" runat="server" TextMode="MultiLine" Width="226px" Height="51px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Father Mobile No
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtfmob" runat="server" placeholder="According To the certificate Name"
                                 Width="130px"></asp:TextBox>
                </td>
                <td class="style4">
                    Mother mobile No
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtmothermob" runat="server" placeholder="According To the certificate Name"
                                 Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Father E-mail
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtfemail" runat="server" placeholder="Like..yyy@xxx.com" Width="228px"></asp:TextBox>
                </td>
                <td class="style4">
                    Mother E-mail
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtmemail" runat="server" placeholder="Like..yyy@xxx.com" Width="228px"></asp:TextBox>
                </td>
            </tr>
        </table>
    </fieldset>
    <p>
        If There is any sibilings Students then Click this</p>
    <asp:CheckBox ID="CheckBox1" Text="Show" runat="server" onClick="return fnToogleTable(this);" />
    <asp:CheckBox ID="CheckBox2" Text="Hide" runat="server" onClick="return fnToogleTable1(this);" />
    <fieldset>
        <legend><b>
                    <h2>
                        SIBILING&#39;S Information</h2>
                </b></legend>
        <table id="tblsibilings" style="display: none;" class="style1">
            <tr>
                <td class="style4">
                    Any sibilings that studied in this school
                </td>
                <td class="style3">
                    <asp:RadioButton ID="sradio1" runat="server" Text="Yes" />
                    <asp:RadioButton ID="sradio2" runat="server" Text="No" />
                </td>
                <%--    <td class="style3"> <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                        <asp:ListItem>yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:RadioButtonList> </td>--%>
                
                <%-- <asp:ValidationSummary ID="ValidationSummary1" runat="server" />--%>
                <td class="style2">
                    &nbsp;
                </td>
            </tr>
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
                    Sibilings shift
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtsshift" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Sibilings class
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtsclass" runat="server" Width="130px"></asp:TextBox>
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
                    Sibilings roll
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtsroll" runat="server" Width="130px"></asp:TextBox>
                </td>
                <td class="style2">
                    &nbsp;
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
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend><b>
                    <h2>
                        For OFfice Use Only</h2>
                </b></legend>
        <table class="style1">
            <tr>
                <td class="style2">
                    Principal Remarks
                </td>
                <td>
                    <asp:TextBox ID="txtpremarks" runat="server" Width="130px"></asp:TextBox>
                </td>
                <td class="style2">
                    Addmission Recomanded Class
                </td>
                <td>
                    <asp:DropDownList ID="drpclass" runat="server" DataSourceID="SqlDataSource1" DataTextField="VarClassName"
                                      DataValueField="VarClassID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT [VarClassID], [VarClassName] FROM [Class]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Recomendend Date
                </td>
                <td>
                    <asp:TextBox ID="txtrdate" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
             
        </table>
    </fieldset>


    
    <table><tr>
               <td class="style4">
                   <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="81px" 
                               OnClientClick=" return validate(); " onclick="btnUpdate_Click"
                       />
               </td>
               <td class="style3">
                   <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                   <asp:Label ID="lblStInfoid" runat="server" Text=""></asp:Label>
               </td>
               <td class="style2">
                   &nbsp;
               </td>
           </tr></table>
  



</asp:Content>