Imports System.Data.OleDb

Public Class daftar

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If nama.Text = "" Or txt_kontak.Text = "" Or txt_password.Text = "" Or txt_alamat.Text = "" Then
            MsgBox("Jangan ada yang kosong")
        Else
            Call koneksi() : Cn.Open()
            Dim simpan As String = "INSERT INTO login VALUES('""','" & nama.Text & "','" & txt_password.Text & "','" & txt_kontak.Text & "','" & txt_alamat.Text & "','""')"
            CMD = New OleDbCommand(simpan, Cn)
            CMD.ExecuteNonQuery()
            MsgBox("Buat akun Berhasil")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class