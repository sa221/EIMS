<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeFile="StudentTransfer.aspx.cs" Inherits="Student_Info_Entry_StudentTransfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1 {
            height: auto;
            width: 100%;
        }

        .style2 {
            height: auto;
            width: 16%;
        }
    </style>
    <script type="text/javascript">
        window.onload = function() {
            var scrollY = parseInt('<%= Request.Form["scrollY"] %>');
            if (!isNaN(scrollY)) {
                window.scrollTo(0, scrollY);
            }
        };
        window.onscroll = function() {
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
    <fieldset>
        <legend><b>
                    <h2>
                        Student Transfer</h2>
                </b></legend>
        <table class="style1">
            <tr>
                <td class="style2">
                    <b><i>Select Session</i></b>
                    <br />
                    <asp:DropDownList ID="pSessionDropDownList" runat="server" Width="100px" AutoPostBack="True"
                                      DataSourceID="SqlDataSource1" DataTextField="VarSessionName" DataValueField="VarSessionId"
                                      AppendDataBoundItems="true">
                        <asp:ListItem Selected="True" Value="0">--Select Session--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo]"></asp:SqlDataSource>
                </td>
                <td class="style2">
                    <b><i>Select Class</i></b>
                    <br />
                    <asp:DropDownList ID="pClassDropDownList" runat="server" Width="180px" DataSourceID="SqlDataSource2"
                                      DataTextField="VarClassName" DataValueField="VarClassID" AutoPostBack="True"
                                      AppendDataBoundItems="true" OnSelectedIndexChanged="pClassDropDownList_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="0">--Select Class--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT [VarClassID], [VarClassName] FROM [Class]"></asp:SqlDataSource>
                </td>
                <td class="style2">
                    <b><i>Select Section</i></b>
                    <br />
                    <asp:DropDownList ID="pSectionDropDownList" runat="server" DataSourceID="SqlDataSource3"
                                      DataTextField="varSectionName" DataValueField="SectionId" AppendDataBoundItems="true">
                        <asp:ListItem Selected="True" Value="0">--Select Section--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT [SectionId], [varSectionName], [ClassID] FROM [tblSection] WHERE ([ClassID] = @ClassID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="pClassDropDownList" Name="ClassID" PropertyName="SelectedValue"
                                                  Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td class="style2">
                    <b><i>Select Shift</i></b>
                    <br />
                    <asp:DropDownList ID="pShiftDropDownList" runat="server" DataSourceID="SqlDataSource4"
                                      DataTextField="VarShiftName" DataValueField="VarShiftCode" AppendDataBoundItems="true">
                        <asp:ListItem Selected="True" Value="0">--Select Shift--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT [VarShiftCode], [VarShiftName] FROM [ShiftInfo]"></asp:SqlDataSource>
                </td>
                <td class="style2">
                    <br />
                    <b><i>TO ===></i></b>
                </td>
                <%--<td class="style2">
                    <b><i>Transfer Class</i></b>
                    <br />
                    <asp:DropDownList ID="trnsClassDropDownList" runat="server" DataSourceID="SqlDataSource10" DataTextField="VarClassName" DataValueField="VarClassID" AutoPostBack="True"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource10" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" SelectCommand="SELECT * FROM [Class] WHERE ([VarClassID] &gt; @VarClassID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="pClassDropDownList" Name="VarClassID" PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>--%>
                <td class="style2">
                    <b><i>Transfer Session</i></b>
                    <br />
                    <asp:DropDownList ID="tSessionDropDownList" runat="server" DataSourceID="SqlDataSource5"
                                      DataTextField="VarSessionName" DataValueField="VarSessionId" AppendDataBoundItems="false"
                                      Enabled="False">
                        <asp:ListItem Selected="True" Value="0">--Select Session--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT VarSessionId, VarSessionName FROM SessionInfo WHERE (VarSessionId &gt; @VarSessionId)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="pSessionDropDownList" Name="VarSessionId" PropertyName="SelectedValue"
                                                  Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <b><i>Student ID</i></b>
                    <br />
                    <asp:TextBox ID="studentIdTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <br />
                    <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
                </td>
                <td colspan="4">
                    <br />
                    <span class="label label-warning" style="background-color: #f0ad4e; float: left; font-size: 20px; position: relative;" id="failStatusLabel" runat="server"></span><span class="label label-success"
                                                                                                                                                                                                                    style="background-color: #5cb85c; float: left; font-size: 20px; position: relative;"
                                                                                                                                                                                                                    id="successStatusLabel" runat="server"></span>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td colspan="2">
                </td>
                <td style="position: relative; right: 22px">
                </td>
                <%--<td>
                     <asp:DropDownList ID="sShiftDropDown" runat="server" Width="80px" 
                         DataSourceID="SqlDataSource8" DataTextField="VarShiftName" 
                         DataValueField="VarShiftCode" AppendDataBoundItems="True" AutoPostBack="True" 
                         onselectedindexchanged="sShiftDropDown_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" SelectCommand="SELECT [VarShiftCode], [VarShiftName] FROM [ShiftInfo]"></asp:SqlDataSource>
                               
                </td>--%>
            </tr>
            <%-- <tr>
                <td colspan="6" align="center">
                    <table align="center" style="width: 100%" border="2">
                        <tr>
                            <td class="style2">Month:
                            </td>
                            <td class="style7">
                                <asp:DropDownList ID="ddlMonths" runat="server">
                                    <asp:ListItem>April</asp:ListItem>
                                    <asp:ListItem>May</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="style3">Mode:
                            </td>
                            <td class="style4">
                                <asp:DropDownList ID="ddlModes" runat="server" AutoPostBack="True">
                                    <asp:ListItem>Cargo</asp:ListItem>
                                    <asp:ListItem>Cargo-2</asp:ListItem>
                                    <asp:ListItem>Express</asp:ListItem>
                                    <asp:ListItem>Logistic</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="style5">Party:
                            </td>
                            <td>
                                <asp:DropDownList ID="transferSectionDropDownList" runat="server" DataSourceID="SqlDataSource22" DataTextField="varSectionName" DataValueField="SectionId" AppendDataBoundItems="False" AutoPostBack="True">
                                    <asp:ListItem Selected="True" Value="0">--Select Section--</asp:ListItem>

                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource22" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" SelectCommand="SELECT * FROM [tblSection] WHERE ([ClassID] = @ClassID)">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="trnsClassDropDownList" Name="ClassID" PropertyName="SelectedValue" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                            <td>
                                 
                                    <asp:DropDownList ID="sShiftDropDown" runat="server" Width="80px" DataSourceID="SqlDataSource8" DataTextField="VarShiftName" DataValueField="VarShiftCode" AppendDataBoundItems="false" AutoPostBack="True">
                                        <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" SelectCommand="SELECT [VarShiftCode], [VarShiftName] FROM [ShiftInfo]"></asp:SqlDataSource>
                               
                            </td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <%--<td class="style4">
                            <asp:Button ID="btnFilter" runat="server" ToolTip="Click to Filter according to Selection"
                                Text="Filter" OnClick="btnFilter_Click" />
                        </td>--%>
            <%--</tr>
                    </table>
                </td>
            </tr>--%>
            <tr>
                <td colspan="6">
                    <asp:GridView ID="GridView1" runat="server" CellPadding="2" AutoGenerateColumns="False"
                                  ForeColor="#333333" GridLines="None" Width="100%" HorizontalAlign="Center">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="SL#">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Student ID">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("VarStudentID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("VarStudentFirstName") + " " + Eval("VarStudentMeddleName") + " " + Eval("VarStudentLastName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Class">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("VarClassName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Transfer Class">
                                <HeaderTemplate>
                                    <label>
                                        Transfer Class</label><br />
                                    <asp:DropDownList ID="headTClassDropDownList" runat="server" Width="150px" DataSourceID="SqlDataSource20"
                                                      DataTextField="VarClassName" DataValueField="VarClassID" AppendDataBoundItems="true"
                                                      AutoPostBack="True" OnSelectedIndexChanged="headTClassDropDownList_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource20" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                                       SelectCommand="SELECT [VarClassID], [VarClassName] FROM [Class]"></asp:SqlDataSource>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:DropDownList ID="trnsClassDropDownList" runat="server" DataSourceID="SqlDataSource10"
                                                      Width="150px" DataTextField="VarClassName" DataValueField="VarClassID" AutoPostBack="True">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource10" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                                       SelectCommand="SELECT * FROM [Class]">
                                        <%-- <SelectParameters>
                                            <asp:ControlParameter ControlID="pClassDropDownList" Name="VarClassID" PropertyName="SelectedValue"
                                                Type="String" />
                                        </SelectParameters>
                                        --%>
                                    </asp:SqlDataSource>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Transfer Section">
                                <ItemTemplate>
                                    <asp:DropDownList ID="tSectionDropDown" runat="server" Width="80px" DataSourceID="SqlDataSource7"
                                                      DataTextField="varSectionName" DataValueField="SectionId" AppendDataBoundItems="False">
                                        <asp:ListItem Selected="True" Value="0">--Select Section--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                                       SelectCommand="SELECT [SectionId], [varSectionName], [ClassID] FROM [tblSection] WHERE ([ClassID] = @ClassID)">
                                        <SelectParameters>
                                            <%--<asp:ControlParameter ControlID="transferSectionDropDownList" Name="SectionId" PropertyName="SelectedValue" Type="String" />--%>
                                            <asp:ControlParameter ControlID="trnsClassDropDownList" Name="ClassID" PropertyName="SelectedValue"
                                                                  Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Transfer Shift">
                                <ItemTemplate>
                                    <asp:DropDownList ID="tShiftDropDown" runat="server" Width="80px" DataSourceID="SqlDataSource8"
                                                      DataTextField="VarShiftName" DataValueField="VarShiftCode" AppendDataBoundItems="True"
                                                      AutoPostBack="False">
                                        <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                                       SelectCommand="SELECT [VarShiftCode], [VarShiftName] FROM [ShiftInfo]">
                                        <SelectParameters>
                                            <%--<asp:ControlParameter ControlID="sShiftDropDown" Name="VarShiftCode" PropertyName="SelectedValue" Type="String"/>--%>
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Roll">
                                <ItemTemplate>
                                    <asp:TextBox ID="rollTextBox" runat="server" Width="30px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Transfer Campus">
                                <HeaderTemplate>
                                    <label>Transfer Campus</label><br/>
                                    <asp:DropDownList ID="headTCampusDropDown" runat="server" Width="100px" DataSourceID="SqlDataSource6"
                                                      DataTextField="house_name" DataValueField="house_Code" AppendDataBoundItems="true"
                                                      AutoPostBack="True"  OnSelectedIndexChanged="headTCampusDropDown_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                                       SelectCommand="SELECT [house_Code], [house_name] FROM [tblhouse]"></asp:SqlDataSource>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:DropDownList ID="tCampusDropDown" runat="server" Width="100px" DataSourceID="SqlDataSource9"
                                                      DataTextField="house_name" DataValueField="house_Code" AppendDataBoundItems="False">
                                        <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource9" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                                       SelectCommand="SELECT [house_Code], [house_name] FROM [tblhouse]">
                                        <%-- <SelectParameters>
                                            <asp:ControlParameter ControlID="headTCampusDropDown" Name="house_Code" PropertyName="SelectedValue"
                                                Type="String" />
                                        </SelectParameters>--%>
                                    </asp:SqlDataSource>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Transfer">
                                <ItemTemplate>
                                    <asp:CheckBox ID="transferConfirmCheckBox" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Repeat">
                                <ItemTemplate>
                                    <asp:CheckBox ID="repeatConfirmCheckBox" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="">
                               
                                <ItemTemplate>
                                    <asp:Button ID="btnEdit" runat="server" Width="60" Text="Edit" CommandName="EditButton"
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
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
            <tr>
                <td>
                    <asp:Button ID="transferButton" runat="server" Text="Transfer" OnClick="transferButton_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>