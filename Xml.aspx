<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Xml.aspx.cs" Inherits="LinQ.Xml" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 33px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 1380px; height: 278px">
            <asp:GridView ID="GridView1" runat="server" Height="280" Width="1520">
            </asp:GridView>
        </div>
        <hr />
        <div>

            <table style="width:100%;">
                <tr>
                    <td>Id</td>
                    <td>
                        <asp:TextBox ID="id" runat="server" Width="584px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Name</td>
                    <td>
                        <asp:TextBox ID="name" runat="server" Width="581px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Cell</td>
                    <td>
                        <asp:TextBox ID="cell" runat="server" Width="583px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Address</td>
                    <td>
                        <asp:TextBox ID="address" runat="server" Width="581px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style1">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Insert" />
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Update" />
                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Delete" />
                        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Search" />
                        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Load From DT" Width="109px" />
                        <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Load From Xml" Width="119px" />
                        <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="DT -&gt; XML" Width="92px" />
                    </td>
                    <td class="auto-style1"></td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
