<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserPanel.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <center>
    <form id="form1" runat="server">
        <br /><br />
         <asp:Panel ID="pnlmainpage" runat="server">
        <asp:LinkButton Text="Registration" ID="btnReg" runat="server" BorderStyle="Groove" OnClick="btnReg_Click"></asp:LinkButton>
            
            <asp:LinkButton Text="Login" ID="btnLogin" runat="server" BorderStyle="Groove"  OnClick="btnLogin_Click"></asp:LinkButton>
        </asp:Panel>
        <br /><br />
        <asp:Label ID="lblmsg" runat="server" Visible="false"></asp:Label>
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
        <br /><br />
    <asp:Panel ID="pnlRegistartion" runat="server" Visible="false">
        <div id="Registartion">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblUserName" runat="server" Text="User Name"></asp:Label>
                    </td>
                    
                    <td>
                         <asp:TextBox ID="txtUsername" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvusername" runat="server" ControlToValidate="txtUsername" ValidationGroup="VG" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                    </td> 
                    
                    

                    <td>
                         <asp:TextBox ID="txtPassword" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ValidationGroup="VG" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFirstname" runat="server" Text="First name"></asp:Label>
                    </td>

                    <td>
                         <asp:TextBox ID="txtFirstname" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblLastName" runat="server" Text="Last name"></asp:Label>
                    </td>

                    <td>
                         <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><asp:Button  Text="Submit" ValidationGroup="VG" ID="regSubmit" runat="server" OnClick="regSubmit_Click"/></td>
                <td></tr>
            </table>
            
           </div>
          
        </asp:Panel>
    <asp:Panel ID="pnlUpdate" runat="server" Visible="false">
            <asp:GridView ID="updGridview" runat="server" AutoGenerateColumns="False" >

                <Columns>
           <asp:TemplateField HeaderText="User ID">  
                            <ItemTemplate>  
                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("UserID") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>
           <asp:TemplateField HeaderText="User Name">  
                            <ItemTemplate>  
                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("Username") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>  
       </Columns>
            </asp:GridView>


        </asp:Panel>
    
           
    </form>
     </center>
</body>
</html>
