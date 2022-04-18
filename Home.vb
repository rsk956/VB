Imports System.Data.OleDb

Public Class Home
    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksi() : Cn.Open()
        Da = New OleDbDataAdapter("select * from tbl_buku", Cn)
        Ds = New DataSet
        Ds.Clear()
        Da.Fill(Ds, "tbl_buku")
        DataGridView1.DataSource = Ds.Tables("tbl_buku")
    End Sub

    Private Sub KelolaPenggunaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KelolaPenggunaToolStripMenuItem.Click
        User.Show()
        Me.Hide()
    End Sub

    Private Sub BuatAkunToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuatAkunToolStripMenuItem.Click
        daftar.Show()
    End Sub
End Class