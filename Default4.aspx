<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default4.aspx.cs" Inherits="Default4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.1/themes/smoothness/jquery-ui.css" />
  <script src="//code.jquery.com/jquery-1.10.2.js"></script>
  <script src="//code.jquery.com/ui/1.11.1/jquery-ui.js"></script>
  <link rel="stylesheet" href="/resources/demos/style.css" />
  
   
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

        #menu li {
           
        }

        body {
            background-color: lightblue;
        }

        
  </style>

    
</head>

    

<body>
    <form id="form2" runat="server">
        
    <div  >
        <ul id="menu" >
            <li  > Home</li>
             <li> Current Orders</li>
            <li> Reports</li>
             <li> Import Data</li>








        </ul>
    </div>
        
        <br />
         <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
         <br />
        <br />
         <br />


        
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Load Excel Data"  />
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
          
        <br />
        <div>

    
        

            <asp:Button ID="Button2" runat="server"  Text="Upload Data to Server" Width="166px" OnClick="Button2_Click1" />

    
        

            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>

           
   

        

        </div>
         
    </form>
</body>
</html>