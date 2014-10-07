<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" MasterPageFile="~/Site.master" %>

<asp:Content runat="server" ContentPlaceHolderID="FeaturedContent">
    <style>
        h2 {

            text-decoration-color: aqua;
        }

        .auto-style1 {
            width: 50%;
        height: 284px;
    }
       

    .auto-style3 {
        height: 281px;
    }
    .auto-style4 {
        height: 47px;
    }
    .auto-style5 {
        height: 48px;
    }
       

    </style>
    
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       
       <ContentTemplate>
                  
             <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1" DataSourceID="SqlDataSource1" DataTextField="cat_name" DataValueField="cat_id" Width="200px" Height="26px"></asp:DropDownList>
                
          
             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Database1ConnectionString %>" SelectCommand="SELECT [cat_id], [cat_name] FROM [Categories]"></asp:SqlDataSource>
             <asp:DropDownList ID="DropDownList2" runat="server" Width="200px" Height="26px">
             </asp:DropDownList>
                
          
           <asp:TextBox ID="TextBox1" runat="server" Width="67px" Height="16px">1</asp:TextBox>
             
             <asp:Button ID="Button1" runat="server" Font-Size="Medium" Height="32px" Text="Add to Cart" BorderStyle="Groove" OnClick="Button1_Click" Width="132px" />
             
             <br />
             <br />
             &nbsp;&nbsp;<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
             
             <br />
             <table class="auto-style1" style="border-spacing: 4px">
                 <tr>
                     <td class="auto-style4">&nbsp;&nbsp; Product Name</td>
                     <td class="auto-style4">
                         <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                     </td>
                     <td rowspan="6" class="auto-style3">
                         <br />
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style4">&nbsp;&nbsp; Qty</td>
                     <td class="auto-style4">
                         <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style4">&nbsp;&nbsp; Unit Price</td>
                     <td class="auto-style4">
                         <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style4">&nbsp;&nbsp; Tax Amount</td>
                     <td class="auto-style4">
                         <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style5">&nbsp;&nbsp; Total</td>
                     <td class="auto-style5">
                         <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style5">&nbsp;</td>
                     <td class="auto-style5">
                         <asp:Button ID="Button2" runat="server" BorderStyle="Groove" Font-Size="Medium" Height="32px" OnClick="Button2_Click" Text="Place Order" Width="132px" />
                     </td>
                 </tr>
             </table>
             <br />
             <br />
             
             &nbsp; Previous Balance<br />
             &nbsp;
             <asp:TextBox ID="TextBox2" runat="server" Width="149px"></asp:TextBox>
             <br />
             <br />
             <br />
             <h2>Check your order status below.</h2>
             <br />
             <asp:GridView ID="GridView3" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
                 <AlternatingRowStyle BackColor="#DCDCDC" />
                 <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                 <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                 <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                 <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                 <SortedAscendingCellStyle BackColor="#F1F1F1" />
                 <SortedAscendingHeaderStyle BackColor="#0000A9" />
                 <SortedDescendingCellStyle BackColor="#CAC9C9" />
                 <SortedDescendingHeaderStyle BackColor="#000065" />
             </asp:GridView>
             <br />
             
             <br />
             <br />
             <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Database1ConnectionString %>" SelectCommand="SELECT * FROM [Orders]"></asp:SqlDataSource>
             
       </ContentTemplate>
        
    </asp:UpdatePanel>


</asp:Content>