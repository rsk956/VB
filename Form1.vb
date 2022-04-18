Imports System.Data.OleDb
Public Class Form1
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call koneksi() : Cn.Open()
        CMD = New OleDbCommand("SELECT * FROM login where nama='" & _username.Text & "'And Password='" & _password.Text & "'", Cn)
        Rd = CMD.ExecuteReader
        Rd.Read()
        If Rd.HasRows = True Then
            Home.Show()
            Me.Hide()
        Else
            MsgBox("Login Salah", 64, "Informasi")
            username.Clear() : password.Clear() : username.Focus()
        End If
        Cn.Close()

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        daftar.Show()
        Me.Hide()
    End Sub
End Class
