<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="http://localhost:6335/code.jquery.com/ui/1.11.1/themes/smoothness/jquery-ui.css" />
  <script src="//code.jquery.com/jquery-1.10.2.js"></script>
  <script src="//code.jquery.com/ui/1.11.1/jquery-ui.js"></script>
  <link rel="stylesheet" href="/resources/demos/style.css">
    <script>
        $(function () {
            $('#menu').menu({ position: { my: "center bottom" } });
        });
       
  </script>
    <style>
        .ui-menu .ui-menu-item {
            margin:10px;
            padding: 0;
            zoom: 0;
            float: left;

            clear: none;
            width: auto;
            font-size:small;
            }
            #menu li { width: auto; clear: none; 
                        
            }

            .ui-menu .ui-menu-item a{
            padding: 2px .2em;
          
             }

        
  
        
        .auto-style1 {
            width: 100%;
            float: left;
        }
      
        
  
        
  </style>
</head>
<body>
    <form id="form1" runat="server">
    <div  >
        <ul id="menu">
            <li  > Home</li>
             <li> Current Orders</li>
            <li> Reports</li>
             <li> Import Data</li>

        </ul>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <table align="center" class="auto-style1">
            <tr>
                <td>
                    &nbsp;</td>
                <td class="auto-style2">
                    Tax Rate
                    <asp:TextBox ID="TextBox3" runat="server" BackColor="#EAFFEA" Height="16px" Width="41px"></asp:TextBox>
&nbsp;<asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Update" Width="60px" Height="21px" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="Order Id"></asp:Label>
                &nbsp;<asp:TextBox ID="TextBox1" runat="server" BackColor="#E5E5E5" Enabled="False" Width="148px" Height="17px"></asp:TextBox>
            <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="132px">
                <asp:ListItem>Received</asp:ListItem>
                <asp:ListItem>Processing</asp:ListItem>
                <asp:ListItem>Dispatched</asp:ListItem>
                <asp:ListItem>Delivered</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Update" Width="91px" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
        </table>
        <p>
&nbsp;
            <asp:Label ID="Label3" runat="server"></asp:Label>
            </p>
    </div>

        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="order_id" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="order_id" HeaderText="order_id" ReadOnly="True" SortExpression="order_id" />
                <asp:BoundField DataField="prod_id" HeaderText="prod_id" SortExpression="prod_id" />
                <asp:BoundField DataField="sub_total" HeaderText="sub_total" SortExpression="sub_total" />
                <asp:BoundField DataField="tax_amt" HeaderText="tax_amt" SortExpression="tax_amt" />
                <asp:BoundField DataField="total" HeaderText="total" SortExpression="total" />
                <asp:BoundField DataField="qty" HeaderText="qty" SortExpression="qty" />
                <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                <asp:BoundField DataField="status_date" HeaderText="status_date" SortExpression="status_date" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Database1ConnectionString %>" SelectCommand="SELECT * FROM [Orders]"></asp:SqlDataSource>

    &nbsp;&nbsp;&nbsp;

    </form>
</body>
</html>
