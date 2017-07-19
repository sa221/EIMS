<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    MaintainScrollPositionOnPostback="true" CodeFile="EmployeeInformation.aspx.cs"
    Inherits="Employee_EmployeeInformation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            height: auto;
            width: 100%;
        }
        
        .style2
        {
            width: 100%;
        }
        .style3
        {
            width: 25%;
        }
        .style4
        {
            width: 350px;
        }
        .style6
        {
            width: 350px;
            height: 59px;
        }
        .style7
        {
            width: 272px;
            height: 59px;
        }
        .upper-case {
            text-transform: uppercase;
        }
    </style>
    <script type="text/javascript">
        function Radio_Click() {
            var radio1 = document.getElementById("<%=sradio1.ClientID %>");
            var nameTextBox = document.getElementById("<%=txtSpoName.ClientID %>");
            var ocuTextBox = document.getElementById("<%=txtSpoOcu.ClientID %>");
            var contactTextBox = document.getElementById("<%=txtSpoPhn.ClientID %>");
            nameTextBox.disabled = !radio1.checked;
            ocuTextBox.disabled = !radio1.checked;
            contactTextBox.disabled = !radio1.checked;
            nameTextBox.focus();

        }
        function Radio1_Click() {
            var radio1 = document.getElementById("<%=sradio2.ClientID %>");
            var nameTextBox = document.getElementById("<%=txtSpoName.ClientID %>");
            var ocuTextBox = document.getElementById("<%=txtSpoOcu.ClientID %>");
            var contactTextBox = document.getElementById("<%=txtSpoPhn.ClientID %>");
            nameTextBox.disabled = radio1.checked;
            ocuTextBox.disabled = radio1.checked;
            contactTextBox.disabled = radio1.checked;
        }
    </script>
    <script type="text/javascript">
        function addRow() {
            var tr = document.createElement("tr");

            for (var c = 0; c < tbl.rows[0].childNodes.length; c++) {
                var td = document.createElement("td");
                td.innerText = c;
                tr.appendChild(td);

                tr.style.backgroundColor = "lightgrey";
                td.onmouseover = function () {
                    this.style.backgroundColor = "lightyellow";
                }
                td.onmouseout = function () {
                    this.style.backgroundColor = "lightgrey";
                }
                td.onclick = function () {
                    alert(this.innerText);
                }
            }

            tbl.children[0].appendChild(tr);
        }
    </script>
    <script type='text/javascript' language='javascript'>
        function AddNewRecord() {
            var grd = document.getElementById('MainContent_Gridview1');
            var tbod = grd.rows[-0].parentNode;
            var newRow = grd.rows[grd.rows.length - 1].cloneNode(true);
            tbod.appendChild(newRow);
            return false;

        }
    </script>
    <script type="text/javascript">

        function previewFile() {
            var preview = document.querySelector('#<%=imgEmployee.ClientID %>');
            var file = document.querySelector('#<%=FileUpload1.ClientID %>').files[0];
            var reader = new FileReader();

            reader.onloadend = function () {
                preview.src = reader.result;
            }

            if (file) {
                reader.readAsDataURL(file);
            } else {
                preview.src = "";
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%--<asp:UpdatePanel runat="server">
        <ContentTemplate>--%>
    <fieldset>
        <legend><b>
            <h2>
                Employee Information</h2>
        </b></legend>
         <ajaxToolkit:ModalPopupExtender ID="degreeModalPopupExtender" runat="server" Enabled="false"
            PopupControlID="raPanel" TargetControlID="degreeNameDropDownList">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="raPanel" runat="server" align="center" Style="display: none">
            <div class="modal-dialog">
                <div class="modal-content" style="background-color: #31B0D5">
                    <div class="modal-header">
                        <h2 class="modal-title" style="color: #FFFFFF">
                            <label class="textBoxMargin">
                                Add New Degree</label>
                        </h2>
                    </div>
                    <div class="modal-body">
                        <b style="color: #FFFFFF">&nbsp; &nbsp;Degree Name:</b><asp:TextBox ID="dgNameTextBox"
                            runat="server" CssClass="textBoxMargin"></asp:TextBox>
                    </div>
                    <div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="degreeSaveButton" runat="server" ForeColor="#FFFFFF" BackColor="#449D44"
                            Text="Save" OnClick="degreeSaveButton_OnClick" CausesValidation="False" CssClass="textBoxMargin" />
                        <asp:Button ID="degreeCloseButton" runat="server" ForeColor="#FFFFFF" BackColor="#C9302C"
                            Text="Close" OnClick="degreeCloseButton_OnClick" CausesValidation="False" CssClass="textBoxMargin" />
                    </div>
                </div>
            </div>
        </asp:Panel>
        <table class="style1">
            <tr class="style2">
                <td class="style3">
                    <b>Employee ID</b><br />
                    <asp:TextBox ID="txtEmpId" runat="server" Width="100px"> </asp:TextBox><asp:Button
                        ID="searchButton" CssClass="btn btn-primary" runat="server" Text="Search" CausesValidation="False"
                        OnClick="searchButton_Click" />
                    <br />
                    <asp:Literal ID="searchLiteral" runat="server" ></asp:Literal>
                </td>
                <td class="style3">
                    <b>Employee Category</b><br />
                    <asp:DropDownList ID="ctgDropDownList" runat="server" Width="100px" DataSourceID="getEmpCategory"
                        DataTextField="CategoryName" DataValueField="CategoryId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getEmpCategory" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [CategoryId], [CategoryName] FROM [EmployeeCategory]">
                    </asp:SqlDataSource>
                    <br />
                </td>
                <td class="style3">
                    <b>Employee Designation</b><br />
                    <asp:DropDownList ID="designationDropDownList" runat="server" Width="100px" DataSourceID="getDesignation"
                        DataTextField="VarDesignationName" DataValueField="NumDesignationId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getDesignation" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [NumDesignationId], [VarDesignationName] FROM [EmployeeDesignation]">
                    </asp:SqlDataSource>
                    <br />
                </td>
                <td class="style3">
                    <b>Current Status</b><br />
                    <asp:DropDownList ID="currentStatusDropDownList" runat="server">
                        <asp:ListItem Value="A">Active</asp:ListItem>
                        <asp:ListItem Value="L">Left</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </td>
            </tr>
            <tr class="style2">
                <td class="style3">
                    <b>Employee Name <span style="color: red">*</span></b><br />
                    <asp:TextBox ID="txtEmpName" runat="server" Width="130px" CssClass="upper-case"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmpName"
                        ErrorMessage="Please Enter Employee Name" ForeColor="red"></asp:RequiredFieldValidator>
                    <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender"
                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                    </cc1:ValidatorCalloutExtender>
                </td>
                <td class="style3">
                    <b>Date Of Birth <span style="color: red">*</span></b><br />
                    <asp:TextBox ID="txtDoB" runat="server" Width="130px"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtDoB_CalendarExtender" runat="server" Enabled="True"
                        Format="dd-MM-yyyy" TargetControlID="txtDoB"></cc1:CalendarExtender>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDoB"
                        ErrorMessage="Please enter date of Birth" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="style3">
                    <b>Blood Group</b><br />
                    <asp:DropDownList ID="dropDownBlood" runat="server">
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
                </td>
                <td class="style3">
                    <b>Religion</b><br />
                    <%--<asp:TextBox ID="txtReligion" runat="server" Width="130px"></asp:TextBox>--%>
                    <asp:DropDownList ID="religionDropDownList" runat="server" Width="130px">
                        <asp:ListItem Value="0">--SELECT--</asp:ListItem>
                        <asp:ListItem Value="1">ISLAM</asp:ListItem>
                        <asp:ListItem Value="2">HINDUISM</asp:ListItem>
                        <asp:ListItem Value="3"> BUDDHISM</asp:ListItem>
                        <asp:ListItem Value="4">CHRISTIANITY</asp:ListItem>
                    </asp:DropDownList>
                    <br /><br/>
                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtReligion"
                                ErrorMessage="Please Enter religion" ForeColor="Red"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator7">
                            </cc1:ValidatorCalloutExtender>--%>
                </td>
            </tr>
            <tr class="style2">
                <td class="style3">
                    <b>Mobile No <span style="color: red">*</span></b><br />
                    <asp:TextBox ID="txtEmpMob" runat="server" Width="130px"></asp:TextBox>
                    <br />
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True"
                        FilterType="Numbers,Custom" ValidChars="+" TargetControlID="txtEmpMob"></cc1:FilteredTextBoxExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please Insert Correct Phone no"
                        ValidationExpression="^[0-9]{7,11}" ControlToValidate="txtEmpMob" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
                <td class="style3">
                    <b>Nationality</b><br />
                    <asp:TextBox ID="nationalityTextBox" runat="server" CssClass="upper-case"></asp:TextBox><br />
                    <br />
                </td>
                <td class="style3">
                    <b>National ID <span style="color: red">*</span></b><br />
                    <asp:TextBox ID="nidTextBox" runat="server"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Please EnterEmployee NID"
                        ControlToValidate="nidTextBox" ForeColor="Red"></asp:RequiredFieldValidator>
                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True"
                        TargetControlID="RequiredFieldValidator10">
                    </cc1:ValidatorCalloutExtender>
                </td>
                <td class="style3">
                    <b>Employee Gender <span style="color: red">*</span></b><br />
                    <asp:RadioButton ID="radioMale" runat="server" Text="Male" GroupName="sex" />
                    <asp:RadioButton ID="radioFemale" runat="server" Text="Female" GroupName="sex" /><br />
                    <br />
                </td>
            </tr>
            <tr class="style2">
                <td class="style3">
                    <b>Present Address</b><br />
                    <asp:TextBox ID="txtPresentAdd" runat="server" TextMode="MultiLine" CssClass="upper-case" Width="" Height="100px"></asp:TextBox><br />
                    <br />
                </td>
                <td class="style3">
                    <b>Permanent Address</b><br />
                    <asp:TextBox ID="txtPermanentAdd" runat="server" CssClass="upper-case" TextMode="MultiLine" Width="" Height="100px"></asp:TextBox><br />
                    <br />
                </td>
                <td class="style3">
                    <b>Driving Lic./Passport No.</b><br />
                    <asp:TextBox ID="driPassNoTextBox" runat="server"></asp:TextBox><br />
                    <br />
                    <b>Campus</b><br />
                     <asp:DropDownList ID="campusDropDownList" runat="server" AppendDataBoundItems="True"
                        Width="143px" DataSourceID="SqlDataSource7" DataTextField="house_name" DataValueField="house_Code">
                        <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [house_Code], [house_name] FROM [tblhouse]"></asp:SqlDataSource>
                    <br />
                </td>
                <td class="style3">
                    <b>Employee Photo</b><br />
                    <asp:Image ID="imgEmployee" runat="server" Width="100px" Height="100px" />
                    <br />
                    <asp:FileUpload ID="FileUpload1" runat="server" onchange="previewFile()" type="file"
                        name="file" />
                </td>
            </tr>
            <tr class="style2">
                <td colspan="4" class="style3">
                    <h2>
                        Joining Information</h2>
                </td>
            </tr>
            <tr class="style2">
                <td class="style3">
                    <b>Joining Subject</b><br />
                    <asp:TextBox ID="joinSubTextBox" runat="server"></asp:TextBox>
                    <br />
                    <br />
                </td>
                <td class="style3">
                    <b>Joining Date <span style="color: red">*</span></b><br />
                    <asp:TextBox ID="txtJoinDate" runat="server" Width="130px"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtJoinDate_CalendarExtender" runat="server" Enabled="True"
                        Format="dd-MM-yyyy" TargetControlID="txtJoinDate"></cc1:CalendarExtender>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please Enter Joining Date"
                        ControlToValidate="txtJoinDate" ForeColor="Red"></asp:RequiredFieldValidator>
                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True"
                        TargetControlID="RequiredFieldValidator9">
                    </cc1:ValidatorCalloutExtender>
                </td>
                <td class="style3">
                    <b>Joining Salary</b><br />
                    <input id="joiningSalaryTextBox" class="form-control input-sm" runat="server" />
                    <%--<asp:TextBox ID="joiningSalaryTextBox" runat="server" Width="130px"></asp:TextBox>--%><br />
                    <br />
                </td>
                <td class="style3">
                    <b>Current Salary</b><br />
                    <asp:TextBox ID="currentSalaryTextBox" runat="server" Width="130px"></asp:TextBox><br />
                    <br />
                </td>
            </tr>
            <tr class="style2">
                <td class="style3">
                    <b>Leave Date</b><br />
                    <asp:TextBox ID="txtLeaveDate" runat="server" Width=""></asp:TextBox><br />
                    <br />
                </td>
                <td class="style3">
                    <b>Reason</b><br />
                    <asp:TextBox ID="txtLeavedFor" runat="server" Width="130px"></asp:TextBox><br />
                    <br />
                </td>
                <td class="style3">
                    <b>Add. Note</b><br />
                    <asp:TextBox ID="addNoteTextBox" runat="server" Width="130px"></asp:TextBox><br />
                    <br />
                </td>
                <td class="style3">
                    <b>Experience</b><br />
                    <asp:TextBox ID="expTextBox" runat="server" Width="130px"></asp:TextBox><br />
                    <br />
                </td>
            </tr>
            <tr class="style2">
                <td colspan="4" class="style3">
                    <h2>
                        QUALIFICATION</h2>
                </td>
            </tr>
            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
                    <tr class="style2">
                        <td class="style3">
                            <b>Degree Name</b><br />
                            <%--<asp:TextBox ID="degreeNameTextBox" runat="server" ValidationGroup="qualification"></asp:TextBox>--%>
                            <asp:DropDownList ID="degreeNameDropDownList" runat="server" AutoPostBack="True"
                                onselectedindexchanged="degreeNameDropDownList_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td class="style3">
                            <b>Institute Name</b><br />
                            <asp:TextBox ID="instituteTextBox" runat="server" CssClass="upper-case"></asp:TextBox>
                        </td>
                        <td class="style3">
                            <b>Result</b><br />
                            <asp:TextBox ID="resultTextBox" runat="server"></asp:TextBox>
                        </td>
                        <td class="style3">
                            <b>Passing Year</b><br />
                            <asp:TextBox ID="passYearTextBox" runat="server" Width="120px"></asp:TextBox>
                            <asp:Button ID="degreeAddButton" runat="server" Text="Add Degree" ValidationGroup="qualification"
                                OnClick="degreeAddButton_Click" />
                        </td>
                       <%-- <td class="style3">
                           
                        </td>--%>
                    </tr>
                    <tr class="style2">
                        <td colspan="3" class="style3">
                            <asp:GridView ID="degreeGridView" runat="server" CellPadding="2" AutoGenerateColumns="False"
                                OnRowDeleting="OnRowDeletingDegree" ForeColor="#31869B" GridLines="Both" Width="100%"
                                HorizontalAlign="Center">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr#">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <ItemStyle Width="2%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="DegreeName" HeaderText="Degree Name" />
                                    <asp:BoundField DataField="InstituteName" HeaderText="Institute Name" />
                                    <asp:BoundField DataField="PassingYear" HeaderText="Passing Year" />
                                    <asp:BoundField DataField="Result" HeaderText="Result" />
                                    <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                                </Columns>
                                <EditRowStyle BackColor="#7C6F57" />
                                <FooterStyle BackColor="#72C8B6" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#72C8B6" Font-Bold="True" ForeColor="White" />
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#E3EAEB" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                            </asp:GridView>
                        </td>
                    </tr>
                <%--</ContentTemplate 72C8B6>
            </asp:UpdatePanel>--%>
            <tr class="style2">
                <td class="style3">
                    <b>Degree Name</b><br />
                    <asp:TextBox ID="degree1TextBox" runat="server"></asp:TextBox><br />
                    <asp:FileUpload ID="degree1FileUpload" runat="server" Width="200px" />
                </td>
                <td class="style3">
                    <b>Degree Name</b><br />
                    <asp:TextBox ID="degree2TextBox" runat="server"></asp:TextBox><br />
                    <asp:FileUpload ID="degree2FileUpload" runat="server" Width="200px" />
                </td>
                <td class="style3">
                    <b>Degree Name</b><br />
                    <asp:TextBox ID="degree3TextBox" runat="server"></asp:TextBox><br />
                    <asp:FileUpload ID="degree3FileUpload" runat="server" Width="200px" />
                </td>
                <td class="style3">
                    <b>Degree Name</b><br />
                    <asp:TextBox ID="degree4TextBox" runat="server"></asp:TextBox><br />
                    <asp:FileUpload ID="degree4FileUpload" runat="server" Width="200px" />
                </td>
            </tr>
        </table>
        <h2>
            Additional Information</h2>
        <table class="style1">
            <tr class="style2">
                <td class="style3">
                    <b>Father's Name <span style="color: red">*</span></b><br />
                    <asp:TextBox ID="txtfather" runat="server" Width="" CssClass="upper-case"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtfather"
                        ErrorMessage="Please Enter Father's  Name" ForeColor="Red"></asp:RequiredFieldValidator>
                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                        TargetControlID="RequiredFieldValidator5">
                    </cc1:ValidatorCalloutExtender>
                </td>
                <td class="style3">
                    <b>Contact No</b><br />
                    <asp:TextBox ID="txtfmob" runat="server" Width=""></asp:TextBox><br />
                    <br />
                </td>
                <td class="style3">
                    <b>Mother's Name <span style="color: red">*</span></b><br />
                    <asp:TextBox ID="txtmother" runat="server" Width="" CssClass="upper-case"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtmother"
                        ErrorMessage="Please Enter Mother's Name" ForeColor="Red"></asp:RequiredFieldValidator>
                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                        TargetControlID="RequiredFieldValidator6">
                    </cc1:ValidatorCalloutExtender>
                </td>
                <td class="style3">
                    <b>Contact No.</b><br />
                    <asp:TextBox ID="txtmothermob" runat="server" Width=""></asp:TextBox><br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <b>Marital Status</b><br />
                    <asp:RadioButton ID="sradio1" runat="server" Text="Yes" GroupName="genderG" onclick="Radio_Click()" />
                    <asp:RadioButton ID="sradio2" runat="server" Text="No" GroupName="genderG" onclick="Radio1_Click()" />
                </td>
                <td class="style3">
                    <b>Spouse Name</b><br />
                    <asp:TextBox ID="txtSpoName" runat="server" Enabled="False" Width="" CssClass="upper-case"></asp:TextBox>
                </td>
                <td class="style3">
                    <b>Spouse Occupation</b><br />
                    <asp:TextBox ID="txtSpoOcu" runat="server" Enabled="False" Width="" CssClass="upper-case"></asp:TextBox>
                </td>
                <td class="style3">
                    <b>Contact No.</b><br />
                    <asp:TextBox ID="txtSpoPhn" runat="server" Enabled="False" Width=""></asp:TextBox>
                </td>
            </tr>
        </table>
        <h2>
            Emargency Contact</h2>
        <table class="style1">
            <tr class="style2">
                <td class="style3">
                    <b>Name</b><br />
                    <asp:TextBox ID="emgContactNameTextBox" runat="server" CssClass="upper-case"></asp:TextBox>
                </td>
                <td class="style3">
                    <b>Relation</b><br />
                    <asp:TextBox ID="emgContRelationTextBox" runat="server" CssClass="upper-case"></asp:TextBox>
                </td>
                <td class="style3">
                    <b>Contact No.</b><br />
                    <asp:TextBox ID="emgContNoTextBox" runat="server"></asp:TextBox>
                </td>
                <td class="style3">
                    <br/>
                    <asp:Button ID="addButton" runat="server" Text="Add" OnClick="addButton_Click" CausesValidation="False" />
                </td>
            </tr>
            <tr class="style2">
                <td colspan="4" class="style3">
                    <asp:GridView ID="emergencyContactGridView" runat="server" CellPadding="2" AutoGenerateColumns="False"
                        OnRowDeleting="OnRowDeleting" ForeColor="#31869B" GridLines="Both" Width="100%"
                        HorizontalAlign="Center">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Serial No">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle Width="2%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="ContactPersonName" HeaderText="Name" />
                            <asp:BoundField DataField="ContactPersonRelation" HeaderText="Relation" />
                            <asp:BoundField DataField="ContactNumber" HeaderText="Contact" />
                            <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                            <%-- <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("ContactPersonName") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_Name" runat="server" Text='<%#Eval("ContactPersonName") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Relation">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Relation" runat="server" Text='<%#Eval("ContactPersonRelation") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_Relation" runat="server" Text='<%#Eval("ContactPersonRelation") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Contact" runat="server" Text='<%#Eval("ContactNumber") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_Contact" runat="server" Text='<%#Eval("ContactNumber") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#72C8B6" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#72C8B6" Font-Bold="True" ForeColor="White" />
                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#FFFFFF" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    <table>
        <tr class="style2">
            <td class="style3">
                <asp:Button ID="btnSave" runat="server" Text="Save" Width="" OnClick="btnSave_Click" />
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
        </tr>
    </table>
    <style>
        .ui-menu.ui-widget.ui-widget-content.ui-autocomplete.ui-front {
            max-height: 200px;
            overflow-y: auto;
        }
    </style>
    <script src="../Scripts/jquery-3.1.0.min.js" type="text/javascript"></script>
    <link href="../Content/searchableDDL.css" rel="stylesheet" />
    <script src="../Scripts/jquery-ui.js"></script>
    <script src="../Scripts/MyScripts/employee.js"></script>
</asp:Content>
