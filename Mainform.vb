Imports System.Net
Imports System.Net.Mail
Imports System.Data.SQLite
Imports Windows.Win32.System

Public Class Mainform
    Private Sub Mainform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        Dim connectionString As String = "Data Source=users"
        Dim query As String = "SELECT * FROM Tbl_Users"

        Try
            Using con As New SQLiteConnection(connectionString)
                con.Open()
                Using cmd As New SQLiteCommand(query, con)
                    Dim adapter As New SQLiteDataAdapter(cmd)
                    Dim dataTable As New DataTable()
                    adapter.Fill(dataTable)
                    DataGridView1.DataSource = dataTable
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim rowData As String = ""

            For Each cell As DataGridViewCell In selectedRow.Cells
                rowData += cell.Value.ToString() & vbCrLf
            Next

            MessageBox.Show(rowData, "Record Details")
        End If
    End Sub
End Class