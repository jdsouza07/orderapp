<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default5.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Upload excel data to database</h2>
        <p>
            This demo shows how to use the <code>SqlBulkCopy</code> class to efficiently load data into a SQL Server database.
        </p>
        <p>
            Start by choosing a properly-formatted Excel spreadsheet to upload (please use the <code>CustomerImport.xls</code>
            spreadsheet included in the download):<br />
            <asp:FileUpload ID="fupExcel" runat="server" />
            <asp:RequiredFieldValidator ID="rfvUpload" runat="server" 
                ControlToValidate="fupExcel" ErrorMessage="[Required]"></asp:RequiredFieldValidator>
        </p>
        <p>
            Use: 
            <asp:DropDownList ID="ddlImportChoice" runat="server">
                <asp:ListItem Value="0">SqlBulkCopy Without Transaction</asp:ListItem>
               
            </asp:DropDownList>
        </p>
        <p>
            <asp:Button ID="btnUploadAndImport" runat="server" Text="Import Excel Data Into SQL Server" />
        </p>
        <hr />
        <p>
            <asp:Label ID="lblResults" runat="server"></asp:Label>
        </p>
    </div>
    </form>
</body>
</html>
