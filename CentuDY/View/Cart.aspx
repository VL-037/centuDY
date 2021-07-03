<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="CentuDY.View.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2><asp:Label ID="lblTitle" runat="server" Text="Your Cart"></asp:Label></h2>
            <br />

            <asp:GridView ID="gvAllCartItems" runat="server" >
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnRemove" runat="server" CommandArgument='<%# Eval("MedicineId") %>' Text="Remove" OnClick="btnRemove_Click"/>
                            <asp:CheckBox ID="chkCheckout" value='<%# Eval("MedicineId") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            
            <asp:Label ID="Label1" runat="server" Text="Grand Total: "></asp:Label>
            <asp:Label ID="lblGrandTotal" runat="server" Text=""></asp:Label>

            
            <div>
                <asp:Button ID="btnCheckOut" runat="server" Text="Checkout" OnClick="btnCheckOut_Click"/>
            </div>
            <div>
                <asp:Button ID="btnMedicinePage" runat="server" Text="See Medicine" OnClick="btnMedicinePage_Click"/>
            </div>
            <div>
                <asp:Button ID="btnHomePage" runat="server" Text="Home Page" OnClick="btnHomePage_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
