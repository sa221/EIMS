<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="BoardExamSubjectEntry.aspx.cs" Inherits="BoardExam.BoardExamBoardExamSubjectEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
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
                    <b>Class</b>
                    <br />
                    <asp:DropDownList ID="classDropDownList" runat="server">
                        <asp:ListItem Value="O-LEVEL">O-LEVEL</asp:ListItem>
                        <asp:ListItem Value="A-LEVEL">A-LEVEL</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <b>Board</b>
                    <br />
                    <asp:DropDownList ID="boardDropDownList" runat="server">
                        <asp:ListItem Value="EDEXCEL">EDEXCEL</asp:ListItem>
                        <asp:ListItem Value="CAMBRIDGE">CAMBRIDGE</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <b>Quali. Level</b>
                    <br />
                    <asp:DropDownList ID="qLevelDropDownList" runat="server" Width="90px">
                        <asp:ListItem Value="IAL">IAL</asp:ListItem>
                        <asp:ListItem Value="IGCSE">IGCSE</asp:ListItem>
                        <asp:ListItem Value="A-LEVEL">A-LEVEL</asp:ListItem>
                        <asp:ListItem Value="AS-LEVEL">AS-LEVEL</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <b>Subject Code</b>
                    <br />
                    <asp:TextBox ID="subCodeTextBox" runat="server" Width="70px"></asp:TextBox>
                </td>
                <td>
                    <b>Subject Name</b>
                    <br />
                    <asp:TextBox ID="subNameTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <b>Unit-Code</b>
                    <br />
                    <asp:TextBox ID="unitCodeSpeTextBox" runat="server" Width="70px"></asp:TextBox>
                </td>
                <td>
                    <b>Unit</b>
                    <br />
                    <asp:TextBox ID="unitTextBox" runat="server" Width="70px"></asp:TextBox>
                </td>
                <td>
                    <asp:RadioButton ID="theoryRadioButton" runat="server" Text="Theory" GroupName="type"
                        Width="70px" /><br/>
                    <asp:RadioButton ID="pactricalRadioButton" runat="server" Text="Practical" GroupName="type"
                        Width="70px" /><br />
                    <br />
                </td>
                <td>
                    <asp:Button ID="courseSave" runat="server" Text="Save" Width="81px" 
                        onclick="courseSave_Click" />
                </td>
            </tr>
            <tr>
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
                <td colspan="8">
                    <asp:GridView ID="showSubjectGridView" runat="server" AutoGenerateColumns="False"
                        Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                        CellPadding="4">
                        <Columns>
                            <asp:TemplateField HeaderText="SL#">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Class">
                                <ItemTemplate>
                                    <asp:Label ID="classLabel" runat="server" Text='<%# Eval("ClassLevel") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Board">
                                <ItemTemplate>
                                    <asp:Label ID="boardLabel" runat="server" Text='<%# Eval("Board") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Qualification level">
                                <ItemTemplate>
                                    <asp:Label ID="qualificationLabel" runat="server" Text='<%# Eval("QualificationLevel") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subject Code">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("SubCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subject Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("SubName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unit Code">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("UnitCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unit Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("UnitName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Type">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("SubType") %>'></asp:Label>
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
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
