Public Class FormdyeddetlistOld
    Private Tmaster, tlistfab, tlistyed As DataTable
    Private Sub Formdyeddetlist_Load(sender As Object, e As EventArgs) Handles Me.Load
        BindingBalance()
    End Sub
    Private Sub Tbkeyword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tbkeyword.KeyPress
        e.Handled = (Asc(e.KeyChar) = 39)
    End Sub
    Private Sub Tbkeyword_TextChanged(sender As Object, e As EventArgs) Handles Tbkeyword.TextChanged
        Btmsearch_Click(sender, e)
    End Sub
    Private Sub Btmsearch_Click(sender As Object, e As EventArgs) Handles Btmsearch.Click
        Filtermastergrid(Tbkeyword.Text)
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

    Private Sub Filtermastergrid(Sval As String)
        If Trim(Sval) = "" Then
            BindingBalance()
            Exit Sub
        End If
        Dgvmas.Rows.Clear()
        tlistyed.DefaultView.RowFilter = String.Format("Dyedcomno Like '%{0}%' or Clothno Like '%{0}%' or Ftype Like '%{0}%' or Fwidth Like '%{0}%'", Trim(Sval))
    End Sub

    Private Sub BindingBalance()
        Dgvmas.Rows.Clear()
        Tmaster = SQLCommand("SELECT Clothid, Clothno, Ftype, Fwidth FROM Tclothxp WHERE Sstatus = '1' ")
        Dgvmas.DataSource = Tmaster
    End Sub

    Private Sub Formdyeddetlist_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dgvmas.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        Dgvmas.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
    End Sub

End Class