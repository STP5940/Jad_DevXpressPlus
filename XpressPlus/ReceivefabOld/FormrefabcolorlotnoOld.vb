﻿Public Class FormrefabcolorlotnoOld
    Private Tmaster As DataTable
    Private Sub Formrefabcolorlotno_Load(sender As Object, e As EventArgs) Handles Me.Load
        Bindingmaster()
    End Sub
    Private Sub Tbkeyword_TextChanged(sender As Object, e As EventArgs) Handles Tbkeyword.TextChanged
        If Me.Created Then
            Btmsearch_Click(sender, e)
        End If
    End Sub
    Private Sub Tbkeyword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tbkeyword.KeyPress
        e.Handled = (Asc(e.KeyChar) = 39)
    End Sub
    Private Sub Btmsearch_Click(sender As Object, e As EventArgs) Handles Btmsearch.Click
        Filtermastergrid()
    End Sub
    Private Sub Dgvmas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgvmas.CellClick
        If Dgvmas.RowCount = 0 Then
            Exit Sub
        End If
        Dgvmas.CurrentRow.Selected = True
    End Sub
    Private Sub Dgvmas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgvmas.CellDoubleClick
        If Dgvmas.RowCount = 0 Then
            Exit Sub
        End If
        Dgvmas.CurrentRow.Selected = True
        Btok_Click(sender, e)
    End Sub
    Private Sub Btok_Click(sender As Object, e As EventArgs) Handles Btok.Click
        If Dgvmas.RowCount = 0 Then
            Tbcancel.Text = "C"
        End If
        Me.Close()
    End Sub
    Private Sub Btcancel_Click(sender As Object, e As EventArgs) Handles Btcancel.Click
        Tbcancel.Text = "C"
        Me.Close()
    End Sub
    Private Sub Bindingmaster()
        Tmaster = New DataTable
        Tmaster = SQLCommand("SELECT '' AS Stat,Comid,Billdyedh,Billknitt,Recdate,Lotno,Dyedcol,Dremark FROM Trecfabcolxp WHERE Comid = '" & Gscomid & "'")
        Dgvmas.DataSource = Tmaster
    End Sub
    Private Sub Filtermastergrid()
        If Tmaster.Rows.Count < 1 Then
            Exit Sub
        End If
        If Tbkeyword.Text = "" Then
            Tmaster.DefaultView.RowFilter = String.Empty
            Exit Sub
        End If
        Tmaster.DefaultView.RowFilter = String.Format("Billdyedh Like '%{0}%' OR Billknitt LIKE '%{1}%'", Trim(Tbkeyword.Text), Trim(Tbkeyword.Text))
    End Sub

    Private Sub Formrefabcolorlotno_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dgvmas.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        Dgvmas.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
    End Sub
End Class