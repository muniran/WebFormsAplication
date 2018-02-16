<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserLogin.aspx.cs" Inherits="UserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <center>
         <asp:Label ID="lblmsg" runat="server"></asp:Label>
        <br /><br />
             <asp:LinkButton ID="lnklogoff" runat="server" OnClick="lnklogoff_Click" Visible="false" Text="Log Off"></asp:LinkButton>
            <asp:LinkButton ID="lnkUpdate" runat="server" OnClick="lnkUpdate_Click" Visible="false" Text="Update"></asp:LinkButton>
     <asp:Panel ID="pnllogin" runat="server">
        
        <div id="login">
            
        <asp:Login ID="logincontrol" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="10pt" OnAuthenticate="logincontrol_Authenticate">
            <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
        </asp:Login>
                
            </div>
    </asp:Panel>
        <br /><br />
        <asp:Panel ID="pnlPrograms" runat="server">
        
       <asp:GridView ID="grdPrograms" runat="server" AutoGenerateColumns="False" Height="118px" Width="590px" OnRowDataBound="grdPrograms_RowDataBound">
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
