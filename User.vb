Imports System.Data.OleDb
Public Class User
    Private Sub User_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksi() : Cn.Open()
        Da = New OleDbDataAdapter("select * from login", Cn)
        Ds = New DataSet
        Ds.Clear()
        Da.Fill(Ds, "login")
        DataGridView1.DataSource = Ds.Tables("login")
    End Sub

    Private Sub DataBukuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataBukuToolStripMenuItem.Click
        Home.Show()
        Me.Hide()
    End Sub

    Private Sub BuatAkunToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuatAkunToolStripMenuItem.Click
        daftar.Show()

    End Sub
End Class