<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    MaintainScrollPositionOnPostback="true" CodeFile="StudentAddmission.aspx.cs"
    Inherits="StudentAddmission" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            height: auto;
            width: 100%;
        }
        .textBoxMargin
        {
            margin-bottom: 20px;
            margin-top: 20px;
            margin-left: 5px;
            margin-right: 5px;
        }
        .upper-case {
            text-transform: uppercase;
        }
    </style>
    <script type="text/javascript">

        function SetTarget() {

            //            document.forms[0].target = "_blank";

        }

    </script>
    <%--<script type="text/javascript">
        function ValidateForm() {
            var ret = true;
            if (document.getElementById('<%=txtfname.ClientID %>').value == "") {
                document.getElementById('<%=txtfnameLabel.ClientID %>').innerText = "Patient ID is required";
                ret = false;
            } else {
                document.getElementById('<%=txtfnameLabel.ClientID %>').innerText = "";
            }
            return ret;
        }
    </script>--%>
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        function previewFile() {
            var preview = document.querySelector('#<%= imgstudent.ClientID %>');
            var file = document.querySelector('#<%= FileUpload1.ClientID %>').files[0];
            var reader = new FileReader();

            reader.onloadend = function () {
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

            reader.onloadend = function () {
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

            reader.onloadend = function () {
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
        
        
        function Radio_Click() {
            var radio1 = document.getElementById("<%=sradio1.ClientID %>");
            var siblingsIdTextBox = document.getElementById("<%=siblingsIdTextBox.ClientID %>");
            var addButton = document.getElementById("<%=siblingsIdButton.ClientID %>");
            siblingsIdTextBox.disabled = !radio1.checked;
            addButton.disabled = !radio1.checked;
            siblingsIdTextBox.focus();
        }
        function Radio1_Click() {
            var radio1 = document.getElementById("<%=sradio2.ClientID %>");
            var siblingsIdTextBox = document.getElementById("<%=siblingsIdTextBox.ClientID %>");
            var siblingsNameTextBox = document.getElementById("<%=txtsibilingsname.ClientID %>");
            var siblingsClassTextBox = document.getElementById("<%=txtsclass.ClientID %>");
            var siblingsSecTextBox = document.getElementById("<%=txtssec.ClientID %>");
            var siblingsShiftTextBox = document.getElementById("<%=txtsshift.ClientID %>");
            var siblingsRollTextBox = document.getElementById("<%=txtsroll.ClientID %>");
            var addButton = document.getElementById("<%=siblingsIdButton.ClientID %>"); 
            siblingsIdTextBox.disabled = radio1.checked;
            siblingsIdTextBox.value = '';
//            siblingsNameTextBox.disabled = radio1.checked;
            siblingsNameTextBox.value = '';
//            siblingsClassTextBox.disabled = radio1.checked;
            siblingsClassTextBox.value = '';
//            siblingsSecTextBox.disabled = radio1.checked;
            siblingsSecTextBox.value = '';
//            siblingsShiftTextBox.disabled = radio1.checked;
            siblingsShiftTextBox.value = '';
//            siblingsRollTextBox.disabled = radio1.checked;
            siblingsRollTextBox.value = '';
            addButton.disabled = radio1.checked;
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
    <script type="text/javascript">

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
    <script type="text/javascript">


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
    <script type="text/javascript">
        window.onload = function () {
            var scrollY = parseInt('<%= Request.Form["scrollY"] %>');
            if (!isNaN(scrollY)) {
                window.scrollTo(0, scrollY);
            }
        };
        window.onscroll = function () {
            var scrollY = document.body.scrollTop;
            if (scrollY == 0) {
                if (window.pageYOffset) {
                    scrollY = window.pageYOffset;
                } else {
                    scrollY = (document.body.parentElement) ? document.body.parentElement.scrollTop : 0;
                }
            }
            if (scrollY > 0) {
                var input = document.getElementById("scrollY");
                if (input == null) {
                    input = document.createElement("input");
                    input.setAttribute("type", "hidden");
                    input.setAttribute("id", "scrollY");
                    input.setAttribute("name", "scrollY");
                    document.forms[0].appendChild(input);
                }
                input.value = scrollY;
            }
        };
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%--    <asp:UpdatePanel runat="server">
        <ContentTemplate>--%>
    <%-- <script type="text/javascript" >
        function ValidateForm() {
            var ret = true;
            if (document.getElementById("MainContent_txtdob").value == "") {
                document.getElementById("MainContent_doblvl").innerText = "Date of birth is required";
                ret = false;
            } else {
                document.getElementById("MainContent_doblvl").innerText = "";
            }
            //if (document.getElementById("ContentPlaceHolder1_degreeTextBox").value == "") {
            //    document.getElementById("ContentPlaceHolder1_degreeLabel").innerText = "Degree is required";
            //    ret = false;
            //} else {
            //    document.getElementById("ContentPlaceHolder1_degreeLabel").innerText = "";
            //}
            //if (document.getElementById("ContentPlaceHolder1_specializationTextBox").value == "") {
            //    document.getElementById("ContentPlaceHolder1_specializationLabel").innerText = "Specialization is required";
            //    ret = false;
            //} else {
            //    document.getElementById("ContentPlaceHolder1_specializationLabel").innerText = "";
            //}
            return ret;
        }
    </script>--%>
    <fieldset>
        <legend><b>
            <h2>
                Student Information Details</h2>
        </b></legend>
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" Enabled="false"
            PopupControlID="PanelMonthly" TargetControlID="previousAttendedDropDownList">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="PanelMonthly" runat="server" align="center" Style="display: none">
            <div class="modal-dialog">
                <div class="modal-content" style="background-color: #31B0D5">
                    <div class="modal-header">
                        <h2 class="modal-title" style="color: #FFFFFF">
                            <label class="textBoxMargin">
                                Add New School</label>
                        </h2>
                    </div>
                    <div class="modal-body">
                        <b style="color: #FFFFFF">&nbsp; &nbsp;School Name:</b><asp:TextBox ID="TextBox1"
                            runat="server" CssClass="textBoxMargin"></asp:TextBox>
                    </div>
                    <div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="saveButton" runat="server" ForeColor="#FFFFFF" BackColor="#449D44"
                            Text="Save" OnClick="saveButton_OnClick_OnClick_" CausesValidation="False" CssClass="textBoxMargin" />
                        <asp:Button ID="btnClose" runat="server" ForeColor="#FFFFFF" BackColor="#C9302C"
                            Text="Close" OnClick="btnClose_OnClick_" CausesValidation="False" CssClass="textBoxMargin" />
                    </div>
                </div>
            </div>
        </asp:Panel>
        <ajaxToolkit:ModalPopupExtender ID="raModalPopupExtender" runat="server" Enabled="false"
            PopupControlID="raPanel" TargetControlID="rAreaDropDownList">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="raPanel" runat="server" align="center" Style="display: none">
            <div class="modal-dialog">
                <div class="modal-content" style="background-color: #31B0D5">
                    <div class="modal-header">
                        <h2 class="modal-title" style="color: #FFFFFF">
                            <label class="textBoxMargin">
                                Add New Area</label>
                        </h2>
                    </div>
                    <div class="modal-body">
                        <b style="color: #FFFFFF">&nbsp; &nbsp;Area Name:</b><asp:TextBox ID="areaNameTextBox"
                            runat="server" CssClass="textBoxMargin"></asp:TextBox>
                    </div>
                    <div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="areaSaveButton" runat="server" ForeColor="#FFFFFF" BackColor="#449D44"
                            Text="Save" OnClick="areaSaveButton_OnClick" CausesValidation="False" CssClass="textBoxMargin" />
                        <asp:Button ID="areaCloseButton" runat="server" ForeColor="#FFFFFF" BackColor="#C9302C"
                            Text="Close" OnClick="areaCloseButton_OnClick" CausesValidation="False" CssClass="textBoxMargin" />
                    </div>
                </div>
            </div>
        </asp:Panel>
        <table class="style1">
            <tr>
                
                <td>
                    <b>Form ID&nbsp;</b>
                    <br />
                    <asp:TextBox ID="txtregid" runat="server" Width="90px" OnTextChanged="btnsearch_Click"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnsearch" runat="server" OnClick="btnsearch_Click" OnClientClick=" return true "
                        Text="Search" CausesValidation="False" Width="55px" /><br />
                    <asp:Literal ID="searchButtonLiteral" runat="server"></asp:Literal><br />
                </td>
                <td>
                    <b>Student ID</b>
                    <br />
                    <asp:TextBox ID="txtmdmu" runat="server" Width="40px"></asp:TextBox>
                    <asp:TextBox ID="txtid" runat="server" Width="100px" OnTextChanged="btnsearch_Click"></asp:TextBox><br />
                    <br />
                </td>
                <td>
                    <asp:CheckBox ID="idCheckBox" runat="server" Text="<strong> If manually enter ID then check."
                        AutoPostBack="True" OnCheckedChanged="idCheckBox_CheckedChanged" />
                </td>
                <td>
                    <b>Branch Name</b>
                    <br />
                    <asp:TextBox ID="branchTextBox" runat="server" Width="170px" ReadOnly="True"></asp:TextBox>
                    <br />
                    <br />
                </td>
                <td>
                    <b>Session Name</b>
                    <br />
                    <asp:DropDownList ID="drpsession" runat="server" DataSourceID="SqlDataSource2" DataTextField="VarSessionName"
                        DataValueField="VarSessionId" Width="170px">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT * FROM [SessionInfo] ORDER BY [VarSessionName] DESC"></asp:SqlDataSource>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <b>Student First Name</b>
                    <br />
                    <asp:TextBox ID="txtfname" runat="server" Width="170px" CssClass="upper-case"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtfname"
                        ErrorMessage="Please Insert First Name" ForeColor="red"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <b>Student Last Name</b>
                    <br />
                    <asp:TextBox ID="txtlname" runat="server" Width="170px" CssClass="upper-case"></asp:TextBox>
                    <br />
                    <br />
                </td>
                <td>
                    <b>Date Of Birth</b>
                    <br />
                    <asp:TextBox ID="txtdob" runat="server" Width="170px" placeholder="DD-MM-YYYY"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="txtdob"
                        Format="dd-MM-yyyy"></cc1:CalendarExtender>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="Please Enter Date of Birth"
                        ForeColor="red" ControlToValidate="txtdob"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <b>Gender</b>
                    <br />
                    <asp:RadioButton ID="malerbutton" runat="server" Text="Male" GroupName="sex" Width="70px" />
                    <asp:RadioButton ID="femalerbutton" runat="server" Text="Female" GroupName="sex"
                        Width="70px" /><br />
                    <br />
                </td>
                <td>
                    <b>Nationality</b>
                    <br />
                    <asp:TextBox ID="txtnational" runat="server" Width="170px" CssClass="upper-case"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <b>Religion</b>
                    <br />
                    <%--<asp:TextBox ID="txtrel" runat="server" ></asp:TextBox>--%>
                    <asp:DropDownList ID="religionDropDownList" runat="server" Width="170px">
                        <asp:ListItem Value="0">--SELECT--</asp:ListItem>
                        <asp:ListItem Value="1">ISLAM</asp:ListItem>
                        <asp:ListItem Value="2">HINDUISM</asp:ListItem>
                        <asp:ListItem Value="3"> BUDDHISM</asp:ListItem>
                        <asp:ListItem Value="4">CHRISTIANITY</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <br />
                </td>
                <td>
                    <b>Blood Group</b>
                    <br />
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="170px">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem Value="1">A+</asp:ListItem>
                        <asp:ListItem Value="2">A-</asp:ListItem>
                        <asp:ListItem Value="3">B+</asp:ListItem>
                        <asp:ListItem Value="4">B-</asp:ListItem>
                        <asp:ListItem Value="5">AB+</asp:ListItem>
                        <asp:ListItem Value="6">AB-</asp:ListItem>
                        <asp:ListItem Value="7">O+</asp:ListItem>
                        <asp:ListItem Value="8">O-</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <br />
                </td>
                <td>
                    <b>Mobile No(For SMS)</b>
                    <br />
                    <asp:TextBox ID="txtmobile" runat="server" placeholder="Like..01xxxxxxxxxx" Width="170px"></asp:TextBox>
                    <br />
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True"
                        FilterType="Numbers,Custom" ValidChars="+" TargetControlID="txtmobile"></cc1:FilteredTextBoxExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Please Insert Correct Phone no"
                        ForeColor="red" ValidationExpression="^[0-9]{7,13}" ControlToValidate="txtmobile"></asp:RegularExpressionValidator>
                </td>
                <td>
                    <b>Phone (Residence)</b>
                    <br />
                    <asp:TextBox ID="txtphone" runat="server" placeholder="Like..01xxxxxxxxxx" Width="170px"></asp:TextBox>
                    <br />
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True"
                        FilterType="Numbers,Custom" ValidChars="+" TargetControlID="txtphone"></cc1:FilteredTextBoxExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please Insert Correct Phone no"
                        ForeColor="red" ValidationExpression="^[0-9]{7,13}" ControlToValidate="txtphone"></asp:RegularExpressionValidator>
                </td>
                <td>
                    <b>Privious School Attended</b>
                    <br />
                    <asp:DropDownList ID="previousAttendedDropDownList" runat="server" AutoPostBack="True"
                        Width="170px" OnSelectedIndexChanged="previousAttendedDropDownList_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <b>Present Class</b>
                    <br />
                    <asp:DropDownList ID="presentClassDropDownList" runat="server" DataSourceID="SqlDataSource6"
                        Width="170px" AutoPostBack="true" AppendDataBoundItems="True" DataTextField="VarClassName"
                        DataValueField="VarClassID" OnSelectedIndexChanged="presentClassDropDownList_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please select Present Class"
                        ForeColor="red" ControlToValidate="presentClassDropDownList" InitialValue="0"></asp:RequiredFieldValidator>
                    <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT VarClassID, VarClassName FROM Class"></asp:SqlDataSource>
                </td>
                <td>
                    <b>Section</b>
                    <%--DataSourceID="SqlDataSource4"  DataTextField="varSectionName" DataValueField="SectionId"--%>
                    <br />
                    <asp:DropDownList ID="sectionDropDownList" runat="server" Width="170px" AppendDataBoundItems="true">
                        <%--<asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>--%>
                    </asp:DropDownList>
                    <%--<asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [varSectionName], [SectionId] FROM [tblSection] WHERE ([ClassID] = @ClassID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="presentClassDropDownList" Name="ClassID" PropertyName="SelectedValue"
                                Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>--%>
                    <br />
                    <br />
                </td>
                <td>
                    <b>Roll No.</b>
                    <br />
                    <asp:TextBox ID="rollTextBox" runat="server" Width="170px"></asp:TextBox>
                    <br />
                    <br />
                </td>
                <td>
                    <b>&nbsp; Shift</b>
                    <br />
                    <asp:DropDownList ID="drpshift" runat="server" DataSourceID="SqlDataSource3" DataTextField="VarShiftName"
                        Width="170px" AppendDataBoundItems="True" DataValueField="VarShiftCode">
                        <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [VarShiftName], [VarShiftCode] FROM [ShiftInfo]"></asp:SqlDataSource>
                    <br />
                    <br />
                </td>
                <td>
                    <b>Campus</b>
                    <br />
                    <asp:DropDownList ID="campusDropDownList" runat="server" AppendDataBoundItems="True"
                        Width="170px" DataSourceID="SqlDataSource7" DataTextField="house_name" DataValueField="house_Code">
                        <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [house_Code], [house_name] FROM [tblhouse]"></asp:SqlDataSource>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Literal ID="statusLiteral" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Status</b>
                    <br />
                    <asp:DropDownList ID="statusDropDownList" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource5"
                        Width="170px" DataTextField="PresentStatus" DataValueField="StatusInitial">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [PresentStatus], [StatusInitial] FROM [tbl_StudentPresentStatus]">
                    </asp:SqlDataSource>
                    <br />
                    <br />
                </td>
                <td>
                    <b>Leave Date</b>
                    <br />
                    <asp:TextBox ID="leaveDateTextBox" runat="server" Width="170px" placeholder="DD-MM-YYYY"></asp:TextBox><br />
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="leaveDateTextBox"
                        Format="dd-MM-yyyy"></cc1:CalendarExtender>
                    <br />
                </td>
                <td>
                    <b>Remarks</b>
                    <br />
                    <asp:TextBox ID="remarksTextBox" runat="server" Width="170px" placeholder="Leave Reason" CssClass="upper-case"></asp:TextBox>
                    <br />
                    <br />
                </td>
                <td>
                    <b>Admitted Class</b>
                    <br />
                    <asp:DropDownList ID="drpclass" runat="server" DataSourceID="SqlDataSource1" DataTextField="VarClassName"
                        Width="170px" AppendDataBoundItems="True" DataValueField="VarClassID">
                        <asp:ListItem Selected="True" Value="0">--Select Class--</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Rec. Class"
                        ForeColor="red" ControlToValidate="drpclass" InitialValue="0"></asp:RequiredFieldValidator>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [VarClassID], [VarClassName] FROM [Class]"></asp:SqlDataSource>
                </td>
                <td>
                    <b>Admission Date</b>
                    <br />
                    <asp:TextBox ID="txtrdate" runat="server" Width="170px" placeholder="DD-MM-YYYY"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtrdate"
                        ErrorMessage="Please enter recomendend date" ForeColor="red"></asp:RequiredFieldValidator>--%>
                    <cc1:CalendarExtender ID="txtrdate_CalendarExtender" runat="server" Enabled="True"
                        Format="dd-MM-yyyy" TargetControlID="txtrdate"></cc1:CalendarExtender>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Rec. Date."
                        ForeColor="red" ControlToValidate="txtrdate"></asp:RequiredFieldValidator>
                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                        TargetControlID="RequiredFieldValidator23">
                    </cc1:ValidatorCalloutExtender>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <b>Principal Remarks</b>
                    <br />
                    <asp:TextBox ID="txtpremarks" runat="server" Width="170px" TextMode="MultiLine" Height="102px" CssClass="upper-case"
                        placeholder="Admission Remarks"></asp:TextBox>
                    <br />
                    <br />
                </td>
                <td>
                    <b>Student Address</b>
                    <br />
                    <asp:TextBox ID="txtpresent" runat="server" TextMode="MultiLine" Width="170px" Height="46px" CssClass="upper-case"></asp:TextBox>
                    <br />
                    <b>Area</b>
                    <br />
                    <asp:DropDownList ID="rAreaDropDownList" runat="server" Width="170px" AutoPostBack="True"
                        OnSelectedIndexChanged="rAreaDropDownList_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                    <br />
                    <br />
                </td>
                <td>
                    <b>Student Photo </b>
                    <br />
                    <asp:Image ID="imgstudent" runat="server" Width="100px" Height="100px" />
                    <br />
                    <asp:FileUpload ID="FileUpload1" runat="server" onchange="previewFile()" type="file"
                        name="file" Width="170px" />
                </td>
                <td>
                    <b>Birth Certificate</b>
                    <br />
                    <asp:Image ID="Image2" runat="server" Width="100px" Height="100px" />
                    <br />
                    <asp:FileUpload ID="FileUpload2" runat="server" onchange="previewFile1()" type="file"
                        name="file" Width="170px" />
                </td>
                <td>
                    <b>Admission Form</b>
                    <br />
                    <asp:Image ID="Image3" runat="server" Width="100px" Height="100px" />
                    <br />
                    <asp:FileUpload ID="FileUpload3" runat="server" onchange="previewFile2()" type="file"
                        name="file" Width="170px" />
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
                <td>
                    <b>Father&#39;s Name</b>
                    <br />
                    <asp:TextBox ID="txtfather" runat="server" Width="170px" CssClass="upper-case"></asp:TextBox>
                    <br />
                    <br />
                    <br />
                </td>
                <td>
                    <b>Father&#39;s Occupation</b>
                    <br />
                    <asp:TextBox ID="txtfocc" runat="server" Width="170px" CssClass="upper-case"></asp:TextBox>
                    <br />
                    <br />
                    <br />
                </td>
                <td>
                    <b>Father&#39;s Office Address</b>
                    <br />
                    <asp:TextBox ID="txtfoff" runat="server" Width="170px" Height="51px" CssClass="upper-case" TextMode="MultiLine"></asp:TextBox>
                    <br />
                </td>
                <td>
                    <b>Father Mobile No</b>
                    <br />
                    <asp:TextBox ID="txtfmob" runat="server" Width="170px"></asp:TextBox>
                    <br />
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" Enabled="True"
                        FilterType="Numbers,Custom" ValidChars="+" TargetControlID="txtfmob"></cc1:FilteredTextBoxExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Please Insert Correct Phone no"
                        ForeColor="red" ValidationExpression="^[0-9]{7,11}" ControlToValidate="txtfmob"></asp:RegularExpressionValidator>
                </td>
                <td>
                    <b>Father E-mail</b>
                    <br />
                    <asp:TextBox ID="txtfemail" runat="server" placeholder="Like..yyy@xxx.com" Width="170px"></asp:TextBox>
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <b>Mother&#39;s Name</b>
                    <br />
                    <asp:TextBox ID="txtmother" runat="server" Width="170px" CssClass="upper-case"></asp:TextBox>
                    <br />
                    <br />
                    <br />
                </td>
                <td>
                    <b>Mother&#39;s Occupation</b>
                    <br />
                    <asp:TextBox ID="txtmotheroc" runat="server" Width="170px" CssClass="upper-case"></asp:TextBox>
                    <br />
                    <br />
                    <br />
                </td>
                <td>
                    <b>Mother Office Address</b>
                    <br />
                    <asp:TextBox ID="txtmadd" runat="server" TextMode="MultiLine" Width="170px" Height="51px" CssClass="upper-case"></asp:TextBox>
                </td>
                <td>
                    <b>Mother mobile No</b>
                    <br />
                    <asp:TextBox ID="txtmothermob" runat="server" Width="170px"></asp:TextBox>
                    <br />
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" Enabled="True"
                        FilterType="Numbers,Custom" ValidChars="+" TargetControlID="txtmothermob"></cc1:FilteredTextBoxExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Please Insert Correct Phone no"
                        ForeColor="red" ValidationExpression="^[0-9]{7,11}" ControlToValidate="txtmothermob"></asp:RegularExpressionValidator>
                </td>
                <td>
                    <b>Mother E-mail</b>
                    <br />
                    <asp:TextBox ID="txtmemail" runat="server" placeholder="Like..yyy@xxx.com" Width="170px"></asp:TextBox>
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
        </table>
    </fieldset>
    <%-- <p>
        If There is any sibilings Students then Click this</p>
    <asp:CheckBox ID="CheckBox1" Text="Show" runat="server" onClick="return fnToogleTable(this);" />
    <asp:CheckBox ID="CheckBox2" Text="Hide" runat="server" onClick="return fnToogleTable1(this);" />--%>
    <fieldset>
        <legend><b>
            <h2>
                Sibilings Information</h2>
        </b></legend>
        <table id="tblsibilings" class="style1">
            <tr>
                <td>
                    <b><i>Any sibilings that studied in this school</i></b>
                </td>
                <td>
                    <asp:RadioButton ID="sradio1" runat="server" Text="Yes" GroupName="genderG" Checked="True" onclick="Radio_Click()" />
                    <asp:RadioButton ID="sradio2" runat="server" Text="No" GroupName="genderG" onclick="Radio1_Click()" />
                </td>
                <td>
                    <b>Sibilings ID</b><br />
                    <asp:TextBox ID="siblingsIdTextBox" runat="server" Width="170px" Enabled="True"></asp:TextBox>
                </td>
                <td>
                    <br />
                    <asp:Button ID="siblingsIdButton" runat="server" Text="ADD" ValidationGroup="siblings"
                        OnClick="siblingsIdButton_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <b>Sibilings Name</b>
                    <br />
                    <asp:TextBox ID="txtsibilingsname" runat="server" Width="170px" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <b>Sibilings Class</b><br />
                    <asp:TextBox ID="txtsclass" runat="server" Width="170px" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <b>Sibilings Section</b><br />
                    <asp:TextBox ID="txtssec" runat="server" Width="170px" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <b>Contact No.</b><br />
                    <asp:TextBox ID="txtsshift" runat="server" Width="170px" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <b>Sibilings Roll </b>
                    <br />
                    <asp:TextBox ID="txtsroll" runat="server" Width="170px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
        </table>
    </fieldset>
    <table>
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" Width="81px" OnClick="btnSave_Click" />
                <cc1:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" runat="server" ConfirmText="Do You want to Save?"
                    Enabled="True" TargetControlID="btnSave"></cc1:ConfirmButtonExtender>
            </td>
            <td>
                <asp:Button ID="subAssignButton" runat="server" Text="Subject Assign" CausesValidation="False"
                    Visible="False" OnClick="subAssignButton_Click" OnClientClick="SetTarget()" />
            </td>
            <td colspan="3">
                <span class="label label-warning" style="background-color: #f0ad4e; float: left;
                    font-size: 20px; position: relative;" id="failStatusLabel" runat="server"></span>
                <span class="label label-success" style="background-color: #5cb85c; float: left;
                    font-size: 20px; position: relative;" id="successStatusLabel" runat="server">
                </span>
                <br />
                <br />
            </td>
            <%--<td>
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                <asp:Label ID="lblStInfoid" runat="server" Text=""></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>--%>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="stdIdTextBox" runat="server" Visible="False"></asp:TextBox>
            </td>
        </tr>
    </table>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
