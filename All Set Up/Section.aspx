<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true"
         CodeFile="Section.aspx.cs" Inherits="Section" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <legend><b>
                    <h2>
                        Section Entry</h2>
                </b></legend>
        <table>
            <%--<tr>
                <td>
                    Session Name
                </td>
                <td>
                    <asp:DropDownList ID="sessionDropDownList" runat="server" 
                        AppendDataBoundItems="True" DataSourceID="SqlDataSource1" 
                        DataTextField="VarSessionName" DataValueField="VarSessionId">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                   
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                        SelectCommand="SELECT * FROM [SessionInfo]"></asp:SqlDataSource>
                   
                </td>
            </tr>--%>
            <tr>
                <td>
                    Class Name
                </td>
                <td>
                    <asp:DropDownList ID="classDropDownList" runat="server" 
                                      AppendDataBoundItems="True" DataSourceID="SqlDataSource2" 
                                      DataTextField="VarClassName" DataValueField="VarClassID" 
                        >
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                   
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                       SelectCommand="SELECT * FROM [Class]"></asp:SqlDataSource>
                   
                </td>
            </tr>
            <%-- <tr>
                <td>
                    Subject Name
                </td>
                <td>
                    <asp:DropDownList ID="subjectDropDownList" runat="server" 
                        AppendDataBoundItems="False" DataSourceID="SqlDataSource3" 
                        DataTextField="VarSubjectName" DataValueField="SpecificationCode" 
                        AutoPostBack="True">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                   
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                        SelectCommand="SELECT * FROM [AllClassSubject] WHERE ([ClassId] = @ClassId)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="classDropDownList" Name="ClassId" 
                                PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                   
                </td>
            </tr>
            <tr>
                <td>
                    Unit Code
                </td>
                <td>
                    <asp:DropDownList ID="unitCodeDropDownList" runat="server" 
                        AppendDataBoundItems="False" DataSourceID="SqlDataSource4" 
                        DataTextField="UnitCode" DataValueField="ID" AutoPostBack="True">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                   
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                        SelectCommand="SELECT * FROM [tbl_EdexelunitCode] WHERE ([SpecificationCode] = @SpecificationCode)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="subjectDropDownList" Name="SpecificationCode" 
                                PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                   
                </td>
            </tr>--%>
            <tr>
                <td>
                    Section Name
                </td>
                <td>
                    <asp:TextBox ID="txtsection" runat="server"></asp:TextBox>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                </td>
                <td>
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </fieldset>
    
    <fieldset>
        <legend><b>
                    <h2>
                        ALL  Section Info</h2>
                </b></legend>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
                      AutoGenerateColumns="False" DataKeyNames="SectionId" 
                      DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" 
            >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="varSectionName" HeaderText="Section Name" 
                                SortExpression="varSectionName" ReadOnly="True" />
                <asp:TemplateField HeaderText="Class" SortExpression="ClassID" >
                  
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" 
                                          DataSourceID="SqlDataSource1" DataTextField="VarClassName" 
                                          DataValueField="VarClassID" SelectedValue='<%# Bind("ClassID") %>'>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                           ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                                           SelectCommand="SELECT * FROM [Class]"></asp:SqlDataSource>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                           ConnectionString="<%$ ConnectionStrings:SWISConnectionString %>" 
                           DeleteCommand="DELETE FROM [tblSection] WHERE [SectionId] = @SectionId" 
                           InsertCommand="INSERT INTO [tblSection] ([varSectionName], [ClassID], [uid]) VALUES (@varSectionName, @ClassID, @uid)" 
                           SelectCommand="SELECT [SectionId], [varSectionName], [ClassID], [uid] FROM [tblSection] Order By [ClassID]" 
                           
            UpdateCommand="UPDATE [tblSection] SET [varSectionName] = @varSectionName, [ClassID] = @ClassID WHERE [SectionId] = @SectionId">
            <DeleteParameters>
                <asp:Parameter Name="SectionId" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="varSectionName" Type="String" />
                <asp:Parameter Name="ClassID" Type="Int32" />
                <asp:Parameter Name="uid" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="varSectionName" Type="String" />
                <asp:Parameter Name="ClassID" Type="Int32" />
                <asp:Parameter Name="SectionId" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </fieldset>
</asp:Content>