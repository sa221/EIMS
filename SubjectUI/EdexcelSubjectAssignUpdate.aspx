<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EdexcelSubjectAssignUpdate.aspx.cs" Inherits="SubjectUI_EdexcelSubjectAssignUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .tdWidth { float: left; }
    </style>
    <style type="text/css">
        .tWidth { float: right; }
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <fieldset>
        <legend><h1>A-Level Subject Assign & Modify</h1></legend>
        <div class="col-lg-12">
            <fieldset class="col-lg-6 tdWidth" style="width: 45%;">
                <legend><h3>Assigned Subject</h3></legend>
                
                <div >
                    <table class="style1"  >
                        <tr>
                
                            <td>
                                <br/>
                                <b><i>Student ID</i></b>
                                <br />
                                <asp:TextBox ID="branchInitialTextBox" runat="server" Width="15%"></asp:TextBox>
                                <asp:TextBox ID="txtStdId" runat="server" Width="40%"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtStdId"
                                                            ErrorMessage="Please Insert Student ID" ForeColor="red"></asp:RequiredFieldValidator>
                   
                            </td>
                            <td>
                                <b><i>Class</i></b>
                                <br/>
                                <asp:DropDownList ID="classDropDownList" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <b><i>Session</i></b>
                                <br />
                                <asp:DropDownList ID="sessionDropDownList" runat="server" DataSourceID="SqlDataSource1"
                                                  DataTextField="VarSessionName" DataValueField="VarSessionId">
                                </asp:DropDownList>
                    
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                                   SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo] ORDER BY [VarSessionId] DESC">
                                </asp:SqlDataSource>
                            </td>
               
                            <td>
                                <asp:Literal ID="stdSearchLiteral" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="studentNameLabel" runat="server" Font-Bold="True" 
                                           ForeColor="#006600"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="searchButton" runat="server" Text="Search" 
                                            onclick="searchButton_Click"  />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
                                              AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
                                              ForeColor="#333333" GridLines="None" 
                                              Width="100%"
                                    >
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                               
                                        <asp:TemplateField HeaderText="Subject">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("VarSubjectName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Unit">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("UnitCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Section">
                                    
                                            <ItemTemplate>
                                                <asp:DropDownList ID="sectionDropDown" runat="server" Width="100px" DataSourceID="SqlDataSource4"
                                                                  DataTextField="varSectionName" DataValueField="SectionId" AppendDataBoundItems="True" SelectedValue='<%# Bind("Section") %>'
                                                                  AutoPostBack="True"  OnSelectedIndexChanged="sectionDropDown_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                                                   SelectCommand="SELECT [SectionId], [varSectionName] FROM [tblSection] WHERE ([ClassID] = @ClassID)">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="classDropDownList" Name="ClassID" PropertyName="SelectedValue"
                                                                              Type="String" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Taken">
                                            <ItemTemplate>
                                                <asp:TextBox ID="countTextBox" runat="server" Width="20px" Enabled="False"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                              
                                        <asp:TemplateField HeaderText="">
                                    
                                            <ItemTemplate>
                                                <asp:Button ID="btnSave" runat="server" Width="50" Text="Save"  CommandName="SaveButton" 
                                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                           
                                            </ItemTemplate>
                                    
                                        </asp:TemplateField>
                                
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnDelete" runat="server" Width="50" Text="Delete"  CommandName="DeleteButton" 
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
                    </table>
                </div>
            </fieldset>
            <fieldset class="col-lg-6 tWidth" style="width: 45%;">
                <legend><h3>New Subject Assign</h3></legend>
                <div >
            
                    <table style="width: 50%" class="tWidth">
            
                        <%-- <tr>
                <td colspan="1">
                    Unit No:
                </td>
                <td colspan="3">
                    <asp:TextBox ID="unitNoTextBox" runat="server"></asp:TextBox></td>
                    <td colspan="1">
                        <asp:Button ID="findButton" runat="server" Text="Find" 
                            onclick="findButton_Click" />
                    </td>
            </tr>
            <tr>
                <td style="width: 130px">
                    <asp:Label ID="subjectNameLabel" runat="server" ForeColor="#00CC99" Width="130px"></asp:Label>
                </td>
                <td style="width: 25px">
                    <asp:Label ID="unitCodeLabel" runat="server" ForeColor="#00CC99" Width="25px"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="sectionDropDownList" runat="server" AppendDataBoundItems="True"
                        DataSourceID="SqlDataSource2" DataTextField="varSectionName" 
                        DataValueField="SectionId" AutoPostBack="True" 
                        onselectedindexchanged="sectionDropDownList_SelectedIndexChanged">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                        SelectCommand="SELECT [SectionId], [varSectionName] FROM [tblSection] WHERE ([ClassID] = @ClassID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="classDropDownList" Name="ClassID" 
                                PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    <asp:TextBox ID="countTextBox" runat="server" Width="30px"></asp:TextBox>
                    
                </td>
                <td>
                    <asp:Button ID="addButton" runat="server" Text="Add" 
                        onclick="addButton_Click" />
                </td>
            </tr>--%>
                        <tr>
                            <td colspan="4">
                                <asp:GridView ID="GridView2" runat="server" CellPadding="4" AutoGenerateColumns="False" OnRowCommand="GridView2_RowCommand"
                                              ForeColor="#333333" GridLines="None" 
                                              Width="100%">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                               
                                        <asp:TemplateField HeaderText="Subject">
                                            <ItemTemplate>
                                                <asp:Label ID="subjectLabel" runat="server" Text='<%# Eval("VarSubjectName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Unit">
                                            <ItemTemplate>
                                                <asp:Label ID="unitCodeLabel" runat="server" Text='<%# Eval("UnitCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Section">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="sectionDropDownList" runat="server" Width="100px" DataSourceID="SqlDataSource4"
                                                                  DataTextField="varSectionName" DataValueField="SectionId" AppendDataBoundItems="True" 
                                                                  AutoPostBack="True" OnSelectedIndexChanged="sectionDropDownList_SelectedIndexChanged" >
                                                    <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                                                   SelectCommand="SELECT [SectionId], [varSectionName] FROM [tblSection] WHERE ([ClassID] = @ClassID)">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="classDropDownList" Name="ClassID" PropertyName="SelectedValue"
                                                                              Type="String" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Taken">
                                            <ItemTemplate>
                                                <asp:TextBox ID="takenTextBox" runat="server" Width="20px" Enabled="False"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                              
                                        <asp:TemplateField HeaderText="">
                                    
                                            <ItemTemplate>
                                                <asp:Button ID="btnAdd" runat="server" Width="50" Text="Add"  CommandName="AddButton" 
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
                            <td colspan="5">
                                <br />
                                <span class="label label-warning" style="background-color: #f0ad4e; float: left; font-size: 20px; position: relative;" id="failStatusLabel" runat="server"></span><span class="label label-success"
                                                                                                                                                                                                                                style="background-color: #5cb85c; float: left; font-size: 20px; position: relative;"
                                                                                                                                                                                                                                id="successStatusLabel" runat="server"></span>
                                <br />
                            </td>
                        </tr>
                    </table>
                </div>
            </fieldset>
        
        </div>
       
    </fieldset>
</asp:Content>