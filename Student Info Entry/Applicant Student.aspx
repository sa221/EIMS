<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Applicant Student.aspx.cs" Inherits="Applicant_Student" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            height: 100px;
            margin-right: 25px;
            width: 100%;
        }
        
        .style2
        {
            width: 33%;
        }
        
        .style3
        {
            width: 109px;
        }
        
        .style4
        {
            width: 110px;
        }
        
        .style5
        {
            width: 132px;
        }
        
        .style6
        {
            width: 328px;
        }
    </style>
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript">
    
    </script>
    <%--<script type="text/javascript">

        function previewFile() {
            var preview = document.querySelector('#<%=imgstudent.ClientID %>');
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
    </script>--%>
    <script type="text/javascript">
        $(document).ready(function () {

            var $jqDate = jQuery('input[name="ctl00$MainContent$txtdob"]');

            //Bind keyup/keydown to the input
            $jqDate.bind('keyup', 'keydown', function (e) {

                //To accomdate for backspacing, we detect which key was pressed - if backspace, do nothing:
                if (e.which !== 8) {
                    var numChars = $jqDate.val().length;
                    if (numChars === 2 || numChars === 5) {
                        var thisVal = $jqDate.val();
                        thisVal += '-';
                        if (numChars < 11) {
                            $jqDate.val(thisVal);
                        } else {
                            alert("");
                        }
                    }
                }
            });
        });
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
    <fieldset>
        <legend><b>
            <h2>
                Applicant Student Information</h2>
        </b></legend>
        <table class="style1">
            <tr>
                <td class="style2">
                    <b><i>Session</i></b><asp:TextBox ID="idTextBox" runat="server" Visible="False"></asp:TextBox>
                    <br />
                    <asp:DropDownList ID="sessionDropDownList" runat="server" DataSourceID="SqlDataSource2"
                        CssClass="form-control" DataTextField="VarSessionName" DataValueField="VarSessionId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo] ORDER BY [VarSessionName] DESC">
                    </asp:SqlDataSource>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="sessionDropDownList"
                        ErrorMessage="Please select Session" ForeColor="red"></asp:RequiredFieldValidator>
                    <%--<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                        TargetControlID="RequiredFieldValidator2">
                    </cc1:ValidatorCalloutExtender>--%>
                </td>
                <td class="style2">
                    <b><i>Form ID</i></b>
                    <br />
                    <asp:TextBox ID="txtregId" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Button ID="searchButton" runat="server" Text="Search" CausesValidation="False"
                        onclick="searchButton_Click" />
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="Please...Enter Form ID"
                        ForeColor="red" ControlToValidate="txtregId"></asp:RequiredFieldValidator>
                    <%--<cc1:ValidatorCalloutExtender ID="RequiredFieldValidator19_ValidatorCalloutExtender"
                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator19">
                    </cc1:ValidatorCalloutExtender>--%>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <b><i>Student's First Name</i></b>
                    <br />
                    <asp:TextBox ID="txtsName" CssClass="form-control" placeholder="First Name" Width="160px"
                        runat="server"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtsName"
                        ErrorMessage="Please enter student name" ForeColor="red"></asp:RequiredFieldValidator>
                    <%--<cc1:ValidatorCalloutExtender ID="RequiredFieldValidator17_ValidatorCalloutExtender"
                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator17">
                    </cc1:ValidatorCalloutExtender>--%>
                </td>
                <td class="style2">
                    <b><i>Student's Last Name</i></b>
                    <br />
                    <asp:TextBox ID="lastNameTextBox" CssClass="form-control" Width="160px" runat="server"
                        placeholder="Last Name"></asp:TextBox>
                    <br />
                    <br />
                </td>
                <%--<td>
                    Student&#39;s Middle Name
                </td>
                <td>
                    <asp:TextBox ID="middleNameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                </td>--%>
            </tr>
            <tr>
                <td class="style2">
                    <b><i>Date Of birth</i></b>
                    <br />
                    <asp:TextBox ID="txtdob" CssClass="form-control" Width="160px" runat="server" placeholder="DD-MM-YYYY"></asp:TextBox>
                    <%--<ajaxToolkit:CalendarExtender ID="txtdob_CalendarExtender" runat="server" Enabled="True" Format="dd-MM-yyyy"
                                                  TargetControlID="txtdob">
                    </ajaxToolkit:CalendarExtender>--%>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="Please Enter Date of Birth"
                        ForeColor="red" ControlToValidate="txtdob"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator123" runat="server"
                        ErrorMessage="Please Insert Valid Date" ForeColor="red" ValidationExpression="^[\s\S]{10,10}$"
                        ControlToValidate="txtdob"></asp:RegularExpressionValidator>
                    <%--<cc1:ValidatorCalloutExtender ID="RequiredFieldValidator23_ValidatorCalloutExtender"
                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator23">
                    </cc1:ValidatorCalloutExtender>--%>
                    <br />
                </td>
                <td>
                    <b>Gender</b>
                    <br />
                    <asp:RadioButton ID="malerbutton" runat="server" Text="Male" GroupName="sex" />
                    <asp:RadioButton ID="femalerbutton" runat="server" Text="Female" GroupName="sex" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <b><i>Father&#39;s Name</i></b>
                    <br />
                    <asp:TextBox ID="txtfather" CssClass="form-control" placeholder="Father's Name" runat="server"
                        Width="160px"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtfather"
                        ErrorMessage="Please Insert Father Name" ForeColor="red"></asp:RequiredFieldValidator>
                    <%--<cc1:ValidatorCalloutExtender ID="RequiredFieldValidator9_ValidatorCalloutExtender"
                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator9">
                    </cc1:ValidatorCalloutExtender>--%>
                </td>
                <td class="style2">
                    <b><i>Mother&#39;s Name</i></b>
                    <br />
                    <asp:TextBox ID="txtmother" CssClass="form-control" placeholder="Mother's Name" runat="server"
                        Width="160px"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Please Enter mother name"
                        ForeColor="red" ControlToValidate="txtmother"></asp:RequiredFieldValidator>
                    <%--<cc1:ValidatorCalloutExtender ID="RequiredFieldValidator14_ValidatorCalloutExtender"
                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator14">
                    </cc1:ValidatorCalloutExtender>--%>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <b><i>Emergency Contact No(For SMS)</i></b>
                    <br />
                    <asp:TextBox ID="txtemrgency" CssClass="form-control" runat="server" Width="160px"
                        placeholder="Like..01xxxxxxxxxx" Text="880"></asp:TextBox>
                    <%--onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"--%>
                    <br />
                    <%--<cc1:FilteredTextBoxExtender ID="txtphone_FilteredTextBoxExtender" runat="server"
                        Enabled="True" FilterType="Numbers,Custom" ValidChars="+" TargetControlID="txtemrgency">
                    </cc1:FilteredTextBoxExtender>--%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Please Insert Correct Phone no"
                        ForeColor="red" ValidationExpression="^[0-9]{7,13}" ControlToValidate="txtemrgency"></asp:RegularExpressionValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="emergencyContact" runat="server" ControlToValidate="txtemrgency"
                        ErrorMessage="Provide Contact No. for Emergency Contact.! " ForeColor="red"></asp:RequiredFieldValidator>
                </td>
                <td class="style2">
                    <b><i>Admission Sought For Class</i></b>
                    <br />
                    <asp:DropDownList ID="DropDownList3" CssClass="form-control" runat="server" DataSourceID="SqlDataSource1"
                        DataTextField="VarClassName" AppendDataBoundItems="true" DataValueField="VarClassID">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT * FROM [Class]"></asp:SqlDataSource>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownList3"
                        ErrorMessage="Please select Sought Class" InitialValue="0" ForeColor="red"></asp:RequiredFieldValidator>
                    <%--<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                        TargetControlID="RequiredFieldValidator3">
                    </cc1:ValidatorCalloutExtender>--%>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;
                    <asp:Button ID="Button1" CssClass="btn btn-default" runat="server" Text="Save" OnClick="Button1_Click" />
                </td>
                <td colspan="3">
                    <span class="label label-warning" style="background-color: #f0ad4e; float: left;
                        font-size: 20px; position: relative;" id="failStatusLabel" runat="server"></span>
                    <span class="label label-success" style="background-color: #5cb85c; float: left;
                        font-size: 20px; position: relative;" id="successStatusLabel" runat="server">
                    </span>
                    <br />
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
