<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProgramDetails.aspx.cs" Inherits="ProgramDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <center>
        <asp:Panel ID="pnlPrograms" runat="server">
        <br /><br />
       <asp:GridView ID="grdPrograms" runat="server" AutoGenerateColumns="False" Height="118px" Width="590px">
       <Columns>
           <asp:TemplateField HeaderText="Program ID">  
                            <ItemTemplate>  
                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("ProgramId") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>
           <asp:TemplateField HeaderText="Name">  
                            <ItemTemplate>  
                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("name") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField> 
           <asp:TemplateField HeaderText="Description">  
                             
                            <ItemTemplate>  
                                <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>
           <asp:TemplateField HeaderText="Start Time">  
                             
                            <ItemTemplate>  
                                <asp:Label ID="lblStartTime" runat="server" Text='<%# Bind("StartTime") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>
           <asp:TemplateField HeaderText="End Time">  
                            
                            <ItemTemplate>  
                                <asp:Label ID="lblEndTime" runat="server" Text='<%# Bind("EndTime") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>
           <asp:TemplateField HeaderText="Is On Air Now">  
                              
                            <ItemTemplate>  
                                <asp:Label ID="lblIsOnAirNow" runat="server" Text='<%# Bind("IsOnAirNow") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>
           <asp:TemplateField HeaderText="Program Image">   
                            <ItemTemplate>  
                                <asp:Label ID="lblProgramImage" runat="server" Text='<%# Bind("ProgramImage") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>
           <asp:TemplateField HeaderText="Is Paid Program">   
                            <ItemTemplate>  
                                <asp:Label ID="lblIsPaidProgram" runat="server" Text='<%# Bind("IsPaidProgram") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField> 
       </Columns>
       </asp:GridView>
            
        </asp:Panel>
    </center>
    </form>
</body>
</html>
