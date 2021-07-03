<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="CentuDY.View.Users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2><asp:Label ID="lblTitle" runat="server" Text="User Page"></asp:Label></h2>
            <br />

            <asp:GridView ID="gvAllUsers" runat="server" >
                <Columns>                    
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("userId") %>' Text="Delete" OnClick="btnDelete_Click"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            
            <br />
            <br />
            <asp:Button ID="btnHomePage" runat="server" Text="Home Page" OnClick="btnHomePage_Click"/>
        </div>
    </form>
</body>
</html>
