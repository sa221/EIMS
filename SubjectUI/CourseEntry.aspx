<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="CourseEntry.aspx.cs" Inherits="SubjectUI_CourseEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        //    function DisableEnable() {
        //        var dropDownClass = document.getElementById("<%= dropDownClass.ClientID %>")
        //        var txtUnitCode = document.getElementById("<%= txtUnitCode.ClientID %>")

        //        var txtSpeId = document.getElementById("<%= txtSpeId.ClientID %>")
        //        var CheckBox1 = document.getElementById("<%= CheckBox1.ClientID %>")

        //        if (dropDownClass.options[dropDownClass.selectedIndex].text == "KG-II") {
        ////            txtSpeId.disabled = true;
        ////            document.getElementById("errSubSpeId").innerHTML = "Not required for KG-II";
        //            txtUnitCode.disabled = true;
        //            document.getElementById("errfn").innerHTML = "Not required for KG-II ";

        //        }
        //        else if (dropDownClass.options[dropDownClass.selectedIndex].text == "KG-I") {
        ////            txtSpeId.disabled = true;
        ////            document.getElementById("errSubSpeId").innerHTML = "Not required for KG-I";
        //            txtUnitCode.disabled = true;
        //            document.getElementById("errfn").innerHTML = "Not required for KG-I ";

        //        }
        //        else if (dropDownClass.options[dropDownClass.selectedIndex].text == "CLASS-I & II") {

        //            txtUnitCode.disabled = true;
        //            document.getElementById("errfn").innerHTML = "Not required for KG-I ";
        //        }
        //        else if (dropDownClass.options[dropDownClass.selectedIndex].text == "CLASS-III TO VII") {

        //            txtUnitCode.disabled = true;
        //            document.getElementById("errfn").innerHTML = "Not required for KG-I ";
        //        }
        //        else if (dropDownClass.options[dropDownClass.selectedIndex].text == "CLASS-VIII") {

        //            txtUnitCode.disabled = true;
        //            document.getElementById("errfn").innerHTML = "Not required for KG-I ";
        //        }

        //        else if (dropDownClass.options[dropDownClass.selectedIndex].text == "O-Level(Science)") {

        //            txtUnitCode.disabled = true;
        //            document.getElementById("errfn").innerHTML = "Not required for O-Level(Science) ";
        //        }
        //        else if (dropDownClass.options[dropDownClass.selectedIndex].text == "O-Level(Combined)") {

        //            txtUnitCode.disabled = true;
        //            document.getElementById("errfn").innerHTML = "Not required for O-Level(Combined) ";
        //        }
        //        else if (dropDownClass.options[dropDownClass.selectedIndex].text == "O-Level(Commerce)") {

        //            txtUnitCode.disabled = true;
        //            document.getElementById("errfn").innerHTML = "Not required for O-Level(Commerce) ";
        //        }

        //        else if (dropDownClass.options[dropDownClass.selectedIndex].text == "A-Level(Chambridge)") {

        //            txtUnitCode.disabled = true;
        //            document.getElementById("errfn").innerHTML = "Not required for A-Level(Chambridge) ";
        //          
        //        }

        //        else {
        //            txtSpeId.disabled = false;
        //            txtUnitCode.disabled = false;
        //            CheckBox1.disabled = false;
        //            document.getElementById("errfn").innerHTML = "";
        //            document.getElementById("erfn").innerHTML = "";
        //            document.getElementById("errSubSpeId").innerHTML = "";
        //        }
        //    }
    
    </script>
    <style type="text/css">
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <legend><b>
            <h2>
                Course Entry</h2>
        </b></legend>
        <table class="style1">
            <tr>
                <td>
                    <b>Select Class: </b>
                </td>
                <td>
                    <div>
                        <asp:DropDownList ID="dropDownClass" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1"
                            DataTextField="VarClassName" DataValueField="VarClassID" AutoPostBack="True"
                            OnSelectedIndexChanged="dropDownClass_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="0">--Select Class--</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT * FROM [Class]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Subject Name: </b>
                </td>
                <td>
                    <asp:TextBox ID="txtSubTitle" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Subject Code: </b>
                </td>
                <td>
                    <asp:TextBox ID="txtSpeId" runat="server"></asp:TextBox>
                </td>
               
            <tr>
                <td>
                    <b>Unit: </b>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtUnitCode" runat="server" Width="130px"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td>
                    <b>Unit-Code: </b>
                </td>
                <td>
                    <asp:TextBox ID="unitCodeSpeTextBox" runat="server" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="<b>If Compulsary</b>" />
                </td>
                <td>
                    <asp:CheckBox ID="labCheckBox" runat="server" Text="<b>If Lab</b>" />
                    <asp:CheckBox ID="examTypeCheckBox" runat="server" Text="<b>If Oral</b>" />
                </td>
                <%--<td>
                    <div id="erfn" >   </div>
                    </td>--%>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Button ID="courseSave" runat="server" Text="Save" Width="81px" OnClientClick=" return validate(); "
                        OnClick="courseSave_Click" />
                </td>
                <td class="style1">
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </td>
                <td colspan="4">
                    <span class="label label-warning" style="background-color: #f0ad4e; float: left;
                        font-size: 20px; position: relative;" id="failStatusLabel" runat="server"></span>
                    <span class="label label-success" style="background-color: #5cb85c; float: left;
                        font-size: 20px; position: relative;" id="successStatusLabel" runat="server">
                    </span>
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="showSubjectGridView" runat="server" AutoGenerateColumns="False"
                        BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                        CellPadding="4" DataSourceID="SqlDataSource2">
                        <Columns>
                            <asp:TemplateField HeaderText="SL#">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subject Code">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("VarSubjectCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subject Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("VarSubjectName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unit Code Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("UnitCode") %>'></asp:Label>
                                    <%--<asp:Label ID="Label3" runat="server"  Text='<%# if(Eval("UnitCode")& "" <> "", Eval("UnitCode"), "N/A") %>'></asp:Label>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="Black" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                        <SortedDescendingHeaderStyle BackColor="#002876" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand=" SELECT [VarSubjectCode], [VarSubjectName],UnitCode FROM [tbl_Subject] left join tbl_EdexelunitCode on tbl_Subject.VarSubjectCode=tbl_EdexelunitCode.SpecificationCode and tbl_Subject.ClassId=tbl_EdexelunitCode.Class WHERE ([ClassId] = @ClassId)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="dropDownClass" Name="ClassId" PropertyName="SelectedValue"
                                Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
          
        </table>
    </fieldset>
</asp:Content>
