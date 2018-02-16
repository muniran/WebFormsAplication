<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditMyProfile.aspx.cs" Inherits="EditMyProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <center>
         <asp:Label ID="lblmsg" runat="server" Visible="false"></asp:Label>
        <br /><br />
        <asp:Panel ID="pnlRegistartion" runat="server" Visible="false">
        <div id="Registartion">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbluserID" runat="server" Text="User Name"></asp:Label>
                    </td>
                    
                    <td>
                         <asp:TextBox ID="txtuserid" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
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
                    <td><asp:Button  Text="Save Changes" ValidationGroup="VG" ID="btnSave" runat="server" OnClick="btnSave_Click"/></td>
               </tr>
            </table>
            
           </div>
          
        </asp:Panel>
    </center>
    </form>
</body>
</html>
