Imports System.IO
Imports System.Diagnostics
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports connection

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub btnUploadAndImport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadAndImport.Click
        If Not Page.IsValid Then Exit Sub

        'Make sure the demo Excel file was uploaded
        If Path.GetExtension(fupExcel.FileName).ToLower() <> ".xls" Then
            Response.Write("<h1>ERROR: Demo only works with Excel 97-2003 file format...</h1>")
            Exit Sub
        End If

        'Save the uploaded Excel spreadsheet to ~/Uploads
        Dim uploadFileName As String = Server.MapPath("~/Uploads/" & Path.GetFileName(fupExcel.FileName))
        fupExcel.SaveAs(uploadFileName)

        Dim connectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
            "Data Source=" & uploadFileName & ";" & _
            "Extended Properties=Excel 8.0;"

        Dim excelData As New DataTable

        Using myConnection As New OleDbConnection(connectionString)
            'Get all data from the InventoryData worksheet
            Dim myCommand As New OleDbCommand
            myCommand.CommandText = "SELECT * FROM [Sheet1$]"
            myCommand.Connection = myConnection

            'Read data into DataTable
            Dim myAdapter As New OleDbDataAdapter
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(excelData)

            myConnection.Close()
        End Using


        'Output starting rowcount
        lblResults.Text = String.Format("STARTING ROW COUNT: {0:N0}<br />", InventoryTableRowCount())

        'Start timing!
        Dim sw As Stopwatch = Stopwatch.StartNew()

        'Now determine how to insert the data
        Select Case ddlImportChoice.SelectedValue
            Case "0"
                lblResults.Text &= String.Format("Importing {0} records using {1}...<br />", excelData.Rows.Count, ddlImportChoice.SelectedItem.Text)
                InsertViaSqlBulkCopyWithoutTransaction(excelData)

        End Select

        lblResults.Text &= String.Format("<br />Operation took {0} milliseconds...", sw.ElapsedMilliseconds)

        'Output ending rowcount
        lblResults.Text &= String.Format("<br />ENDING ROW COUNT: {0:N0}<br />", InventoryTableRowCount())


        'Finally, delete the uploaded file
        File.Delete(uploadFileName)
    End Sub

#Region "SqlBulkCopy Methods"
    Private Sub InsertViaSqlBulkCopyWithoutTransaction(ByVal excelData As DataTable)
        Using destinationConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("Database1ConnectionString").ConnectionString)
            destinationConnection.Open()

            Using bulkCopy As New SqlBulkCopy(destinationConnection)
                bulkCopy.DestinationTableName = "Products"

                'You can optionally specify the batch size... by default, all records are sent to the database in one batch
                'bulkCopy.BatchSize = 100

                'Define column mappings
                For Each col As DataColumn In excelData.Columns
                    bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName)
                Next


                bulkCopy.WriteToServer(excelData)
            End Using

            destinationConnection.Close()
        End Using
    End Sub
#End Region

    Public Function InventoryTableRowCount() As Integer
        Dim rowCount As Integer = 0
        Dim c1 As New connect
        Using destinationConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("Database1ConnectionString").ConnectionString)
            destinationConnection.Open()

            Dim myCommand As New SqlCommand
            myCommand.CommandText = "SELECT COUNT(*) FROM Products"
            myCommand.Connection = destinationConnection

            rowCount = Convert.ToInt32(myCommand.ExecuteScalar())

            destinationConnection.Close()
        End Using

        Return rowCount
    End Function
End Class
