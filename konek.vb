Imports System.Data.OleDb
Module konek
    Public Cn As OleDbConnection
    Public Da As New OleDbDataAdapter
    Public DT As DataTable
    Public Ds As New DataSet
    Public Rd As OleDbDataReader
    Public CMD As New OleDbCommand
    Sub koneksi()
        Cn = New OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source=" & Application.StartupPath & "\Data.mdb")
    End Sub
End Module
