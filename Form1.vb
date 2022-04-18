Imports System.Data.OleDb
Imports System.IO
Public Class Form1
    Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\DATA.accdb")
    Dim dr As OleDbDataReader
    Dim i As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conn.Open()
            lbl_koneksi.Text = "Connected"
            lbl_koneksi.ForeColor = Color.Lime
        Catch ex As Exception
            lbl_koneksi.Text = "Dis-Connected"
            lbl_koneksi.ForeColor = Color.Red

        End Try
        conn.Close()
        txt_id.Text = "[AUTO INCREMENT]"
        txt_id.Enabled = False

        loadingDataGridView()
    End Sub

    Sub loadingDataGridView()
        Try
            DataGridView1.Rows.Clear()
            conn.Open()
            Dim cmd As New OleDbCommand("select * from buku", conn)
            dr = cmd.ExecuteReader
            While dr.Read
                DataGridView1.Rows.Add(dr.Item("Id"), dr.Item("JudulBuku"), dr.Item("Penulis"), dr.Item("Penerbit"), dr.Item("TahunTerbit"), dr.Item("Stok"))
            End While
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        conn.Close()
    End Sub

    Sub kosong()
        loadingDataGridView()
        txt_judul.Clear()
        txt_penulis.Clear()
        txt_penerbit.Clear()
        txt_tahun.Clear()
        txt_stok.Clear()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        txt_id.Text = DataGridView1.CurrentRow.Cells(0).Value
        txt_judul.Text = DataGridView1.CurrentRow.Cells(1).Value
        txt_penulis.Text = DataGridView1.CurrentRow.Cells(2).Value
        txt_penerbit.Text = DataGridView1.CurrentRow.Cells(3).Value
        txt_tahun.Text = DataGridView1.CurrentRow.Cells(4).Value
        txt_stok.Text = DataGridView1.CurrentRow.Cells(5).Value
    End Sub

    Sub simpan()
        Try
            If MsgBox("Simpan Data Baru?", vbQuestion + vbYesNo) = vbYes Then
                conn.Open()
                Dim cmd As New OleDbCommand("Insert into buku(`JudulBuku`,`Penulis`,`Penerbit`,`TahunTerbit`,`Stok`) values(@JudulBuku,@Penulis,@Penerbit,@TahunTerbit,@Stok)", conn)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@JudulBuku", txt_judul.Text)
                cmd.Parameters.AddWithValue("@Penulis", txt_penulis.Text)
                cmd.Parameters.AddWithValue("@Penerbit", txt_penerbit.Text)
                cmd.Parameters.AddWithValue("@TahunTerbit", txt_tahun.Text)
                cmd.Parameters.AddWithValue("@Stok", txt_stok.Text)
                i = cmd.ExecuteNonQuery
                If i > 0 Then
                    MsgBox("Simpan data baru sukses", vbInformation)
                Else
                    MsgBox("Simpan data gagal", vbCritical)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
        loadingDataGridView()
        kosong()
    End Sub

    Private Sub btn_tambah_Click(sender As Object, e As EventArgs) Handles btn_tambah.Click
        simpan()
    End Sub

    Sub edit()
        Try
            conn.Open()
            Dim cmd As New OleDb.OleDbCommand("UPDATE buku SET `JudulBuku`=@JudulBuku,`Penulis`=@Penulis,`Penerbit`=@Penerbit,`TahunTerbit`=@Tahun,`Stok`=@Stok Where Id=@Id ", conn)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@JudulBuku", txt_judul.Text)
            cmd.Parameters.AddWithValue("@Penulis", txt_penulis.Text)
            cmd.Parameters.AddWithValue("@Penerbit", txt_penerbit.Text)
            cmd.Parameters.AddWithValue("@Tahun", txt_tahun.Text)
            cmd.Parameters.AddWithValue("@Stok", txt_stok.Text)
            cmd.Parameters.AddWithValue("@Id", txt_id.Text)
            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("Update Data Berhasil !", vbInformation)
            Else
                MsgBox("Update Data Gagal", vbCritical)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
        loadingDataGridView()
        kosong()
    End Sub

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        edit()
    End Sub

    Sub hapus()
        Try
            If MsgBox("lanjut Hapus data?", vbQuestion + vbYesNo) = vbYes Then
                conn.Open()
                Dim cmd As New OleDb.OleDbCommand("Delete from buku Where Id=@Id", conn)
                cmd.Parameters.Clear()

                cmd.Parameters.AddWithValue("@Id", txt_id.Text)
                i = cmd.ExecuteNonQuery
                If i > 0 Then
                    MsgBox("Hapus data sukses !", vbInformation)
                Else
                    MsgBox("Hapus data gagal", vbCritical)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
        loadingDataGridView()
        kosong()
    End Sub

    Private Sub btn_hapus_Click(sender As Object, e As EventArgs) Handles btn_hapus.Click
        hapus()
    End Sub

    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        kosong()
    End Sub

    Sub cari()
        Try
            DataGridView1.Rows.Clear()
            conn.Open()
            Dim cmd As New OleDb.OleDbCommand("Select * from buku WHERE `JudulBuku` like '%" & txt_cari.Text & "%' or `TahunTerbit` like '%" & txt_cari.Text & "%' or `Penulis` like '%" & txt_cari.Text & "' or `Penerbit` like '%" & txt_cari.Text & "%' ", conn)
            dr = cmd.ExecuteReader
            While dr.Read
                DataGridView1.Rows.Add(dr.Item("Id"), dr.Item("JudulBuku"), dr.Item("Penulis"), dr.Item("Penerbit"), dr.Item("TahunTerbit"), dr.Item("Stok"))

            End While
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub

    Private Sub txt_cari_TextChanged(sender As Object, e As EventArgs) Handles txt_cari.TextChanged
        cari()
    End Sub
End Class
