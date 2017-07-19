<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeFile="ShowUpdatedStudent.aspx.cs" Inherits="Student_Info_Search_and_update_ShowUpdatedStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="../Scripts/quicksearch.js"></script>
    <script type="text/javascript">
        $(function () {
            $('.search_textbox').each(function (i) {
                $(this).quicksearch("[id*=GridView1] tr:not(:has(th))", {
                    'testQuery': function (query, txt, row) {
                        return $(row).children(":eq(" + i + ")").text().toLowerCase().indexOf(query[0].toLowerCase()) != -1;
                    }
                });
            });
        });
    </script>
    <style type="text/css">
        .CompanyHeadline {
            display: block;
            margin-bottom: 10px;
            text-align: center;
        }

        .style1 {
            height: auto;
            width: 100%;
        }

        .style2 { width: 209px; }
         #MainContent_GridView1 tbody tr:nth-of-type(2) th input{
            display: none;
        }
        #MainContent_GridView1 tbody tr:nth-of-type(2) th:nth-of-type(2)  input, #MainContent_GridView1 tbody tr:nth-of-type(2) th:nth-of-type(3)  input, #MainContent_GridView1 tbody tr:nth-of-type(2) th:nth-of-type(4)  input, #MainContent_GridView1 tbody tr:nth-of-type(2) th:nth-of-type(5)  input{
            display: block;
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
    <script language="javascript" type="text/javascript">

        function PrintPage() {

            var printContent = document.getElementById('<%= pnlGridView.ClientID %>');

            var printWindow = window.open("All Records", "Print Panel", 'left=50000,top=50000,width=0,height=0,align=center');

            printWindow.document.write(printContent.innerHTML);

            printWindow.document.close();

            printWindow.focus();

            printWindow.print();

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <legend><b>
                    <h2>
                        Student Search</h2>
                </b></legend>
        <table class="style1">
            <tr width="90%">
                <td>
                    <b>Select Session:</b>
                    <br />
                    <asp:DropDownList ID="sessionDropDownList" runat="server" DataSourceID="SqlDataSource2" AppendDataBoundItems="True"
                                      DataTextField="VarSessionName" DataValueField="VarSessionId">
                        <asp:ListItem Selected="True" Value="0">--All--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT [VarSessionId], [VarSessionName] FROM [SessionInfo] ORDER BY [VarSessionName] DESC"></asp:SqlDataSource>
                </td>
                <td>
                    <b>Select Class:</b>
                    <br />
                    <asp:DropDownList ID="classDropDownList" runat="server" AppendDataBoundItems="True"
                                      DataSourceID="SqlDataSource1" DataTextField="VarClassName" DataValueField="VarClassID" AutoPostBack="True" OnSelectedIndexChanged="classDropDownList_SelectedIndexChanged">
                        <asp:ListItem Value="0">--All--</asp:ListItem>
                    </asp:DropDownList>
                    
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>"
                                       SelectCommand="SELECT [VarClassName], [VarClassID] FROM [Class]"></asp:SqlDataSource>
                    
                   
                </td>
                <td>
                    <b>Section:</b>
                    <br/>
                    <asp:DropDownList ID="sectionDropDownList" runat="server" DataSourceID="SqlDataSource3" DataTextField="varSectionName" DataValueField="SectionId" AppendDataBoundItems="true">
                        <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                 
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" SelectCommand="SELECT [SectionId], [varSectionName], [ClassID] FROM [tblSection] WHERE ([ClassID] = @ClassID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="classDropDownList" Name="ClassID" PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    <b>Shift:</b>
                    <br/>
                    <asp:DropDownList ID="shiftDropDownList" runat="server" 
                                      AppendDataBoundItems="True" DataSourceID="SqlDataSource4" 
                                      DataTextField="VarShiftName" DataValueField="VarShiftCode">
                        <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT [VarShiftCode], [VarShiftName] FROM [ShiftInfo]">
                    </asp:SqlDataSource>
                    <asp:Button ID="searchButton" runat="server" Text="Search" 
                                onclick="searchButton_Click" />
                </td>
                
            </tr>
            <table width="90%" id="pnlGridView" runat="server" align="center">
                <tr>
                    <td colspan="2"></td>
                    <td colspan="1">
                    
                        <div style="display: block; margin-bottom: 10px; text-align: center;">
                            <h1><strong>
                                    <asp:Label ID="schoolLabel" runat="server" Text=""></asp:Label></strong></h1>
                            <h1>
                                <b><asp:Label ID="SessionLabel" runat="server" Text="" ></asp:Label></b>
                            </h1>
                            <h3><asp:Label ID="classLabel" runat="server" Text=""></asp:Label></h3> 
                        </div>
                        
                    </td>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="2px" CellPadding="4" 
                                      Width="100%" OnDataBound="OnDataBound">
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
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("VarStudentFirstName") + " " + Eval("VarStudentLastName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Session Name">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("VarSessionName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Class">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("VarClassName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Roll No.">
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("StudentRoll") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Section">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("varSectionName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            
                                <asp:TemplateField HeaderText="Campus">
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("house_name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Shift">
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("VarShiftName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="">
                                
                                <ItemTemplate>
                                    <asp:Button ID="btnEdit" runat="server" Width="60" Text="Edit" CommandName="EditButton"
                                         CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />

                                </ItemTemplate>
                            </asp:TemplateField>--%>
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
                            <PagerSettings FirstPageText="First" LastPageText="Last" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <%--<tr>
                <td align="right">
                    <asp:LinkButton ID="lnkPrint" runat="server" ToolTip="Click to Print All Records"
                                    Text="Print"  OnClientClick=" PrintPage() "></asp:LinkButton>
                </td>
            </tr>--%>
        </table>
    </fieldset>
</asp:Content>