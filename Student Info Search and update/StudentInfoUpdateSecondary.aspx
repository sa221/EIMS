<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="StudentInfoUpdateSecondary.aspx.cs" Inherits="Student_Info_Search_and_update_StudentInfoUpdateSecondary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            height: auto;
            width: 100%;
        }
        
        .style2
        {
            width: 209px;
        }
        
        .style3
        {
            z-index: -1;
        }
        
        .FixedHeader
        {
            font-weight: bold;
            position: absolute;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <legend><b>
            <h2>
                Student Information Update</h2>
        </b></legend>
        <table class="style1">
            <tr>
                <td>
                    <b><i>Select Session</i></b>
                    <br />
                    <asp:DropDownList ID="pSessionDropDownList" runat="server" DataSourceID="SqlDataSource2"
                        DataTextField="VarSessionName" DataValueField="VarSessionId" AppendDataBoundItems="true">
                        <asp:ListItem Selected="True" Value="0">--Select Session--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo] ORDER BY [VarSessionName] DESC">
                    </asp:SqlDataSource>
                </td>
                <td>
                    <b>Select Class:</b>
                    <br />
                    <asp:DropDownList ID="classDropDownList" runat="server" AppendDataBoundItems="True"
                        DataSourceID="SqlDataSource1" DataTextField="VarClassName" DataValueField="VarClassID"
                        AutoPostBack="True" OnSelectedIndexChanged="classDropDownList_SelectedIndexChanged">
                        <asp:ListItem Value="0">--All--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [VarClassName], [VarClassID] FROM [Class]"></asp:SqlDataSource>
                </td>
                <td>
                    <b>Section:</b>
                    <br />
                    <asp:DropDownList ID="sectionDropDownList" runat="server" DataSourceID="SqlDataSource3"
                        DataTextField="varSectionName" DataValueField="SectionId" AppendDataBoundItems="true">
                        <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                        SelectCommand="SELECT [SectionId], [varSectionName], [ClassID] FROM [tblSection] WHERE ([ClassID] = @ClassID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="classDropDownList" Name="ClassID" PropertyName="SelectedValue"
                                Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <%--<td>
                    <b>Select Class:</b>
                    <br />
                    <asp:DropDownList ID="classDropDownList" runat="server" AppendDataBoundItems="True"
                                      DataSourceID="SqlDataSource1" DataTextField="VarClassName" DataValueField="VarClassID">
                        <asp:ListItem Value="0">--All--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT [VarClassName], [VarClassID] FROM [Class]"></asp:SqlDataSource>
                </td>--%>
                <td>
                    <b>Student ID</b>
                    <br />
                    <asp:TextBox ID="studentIdTextBox" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
                </td>
            </tr>
            <%--<tr>
                <td>
                    <asp:CheckBox ID="nameSortCheckBox" runat="server" Text="Name Sort"/>
                </td>
               
            </tr>--%>
            <tr>
                <td colspan="4">
                    <%-- <div style="height: 400px; overflow: auto" align="center">--%>
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" AutoGenerateColumns="False"
                        ForeColor="#333333" GridLines="None" AllowPaging="True" PageSize="50" HorizontalAlign="Center" OnRowCommand="GridView1_RowCommand"
                        Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging">
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
                            <%--<asp:TemplateField HeaderText="Class">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("VarClassName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Class" SortExpression="ClassName">
                                <ItemTemplate>
                                    <asp:DropDownList ID="clsDropDown" runat="server" Width="140px" DataSourceID="SqlDataSource15"
                                        DataTextField="VarClassName" AutoPostBack="True" Enabled="False" DataValueField="VarClassID"
                                        AppendDataBoundItems="True" SelectedValue='<%# Bind("PClassID") %>'>
                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource15" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                        SelectCommand="SELECT [VarClassName], [VarClassID] FROM [Class] ">
                                        <%--<SelectParameters>
                                            <asp:ControlParameter ControlID="classDropDownList" Name="VarClassID" PropertyName="SelectedValue" Type="String" />
                                        </SelectParameters>--%>
                                    </asp:SqlDataSource>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--SelectedValue='<%# Bind("RecommendAdmissionSection") %>'?--%>
                            <asp:TemplateField HeaderText="Section" SortExpression="RecommendAdmissionSection">
                                <ItemTemplate>
                                    <asp:DropDownList ID="sectionDropDownList" runat="server" DataSourceID="SqlDataSource11"
                                        DataTextField="varSectionName" AppendDataBoundItems="True" DataValueField="SectionId"
                                        SelectedValue='<%# Bind("RecommendAdmissionSection") %>'>
                                        <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource11" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                        SelectCommand="SELECT [SectionId], [varSectionName], [ClassID] FROM [tblSection] WHERE ([ClassID] = @ClassID)">
                                        <%-- <FilterParameters>
                                            <asp:ControlParameter ControlID="clsDropDown" Name="ClassID" PropertyName="SelectedValue" Type="String" />
                                        </FilterParameters>--%>
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="clsDropDown" Name="ClassID" PropertyName="SelectedValue"
                                                Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Shift" SortExpression="VarShiftCode">
                                <ItemTemplate>
                                    <asp:DropDownList ID="tShiftDropDown" runat="server" Width="80px" DataSourceID="SqlDataSource8"
                                        DataTextField="VarShiftName" DataValueField="VarShiftCode" AppendDataBoundItems="true"
                                        SelectedValue='<%# Bind("VarShiftCode") %>'>
                                        <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                        SelectCommand="SELECT [VarShiftCode], [VarShiftName] FROM [ShiftInfo]"></asp:SqlDataSource>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Roll" SortExpression="StudentRoll">
                                <ItemTemplate>
                                    <asp:TextBox ID="rollTextBox" runat="server" Width="50px" Text='<%# Eval("StudentRoll") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Campus" SortExpression="CampusId">
                                <ItemTemplate>
                                    <asp:DropDownList ID="tCampusDropDown" runat="server" Width="140px" DataSourceID="SqlDataSource9"
                                        DataTextField="house_name" DataValueField="house_Code" AppendDataBoundItems="true"
                                        SelectedValue='<%# Bind("CampusId") %>'>
                                        <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource9" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                        SelectCommand="SELECT [house_Code], [house_name] FROM [tblhouse]"></asp:SqlDataSource>
                                </ItemTemplate>
                                
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:Button ID="btnEdit" runat="server" Width="60" Text="Edit" OnClientClick = " SetTarget(); " CommandName="EditButton" 
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
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
                <td style="width: 20%" colspan="4">
                    <asp:Button ID="SaveButton" runat="server" Text="Save" Width="80px" OnClick="SaveButton_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="4" class="">
                    <span class="label label-warning" style="background-color: #f0ad4e; float: left;
                        font-size: 20px; position: relative;" id="failStatusLabel" runat="server"></span>
                    <span class="label label-success" style="background-color: #5cb85c; float: left;
                        font-size: 20px; position: relative; position: absolute; z-index: 1;" id="successStatusLabel"
                        runat="server"></span>
                    <br />
                    <br />
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
