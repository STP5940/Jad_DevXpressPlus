Public Class Formreceivablelist
    Private Tlist As DataTable
    Private Sub Formreceivablelist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Bindinglist()
    End Sub
    Private Sub Bindinglist()
        Tlist = New DataTable
        Tlist = SQLCommand("SELECT '' AS Stat,* FROM Vrecfabcolmas
                                WHERE Comid = '" & Gscomid & "'")
        Dgvlist.DataSource = Tlist
    End Sub
End Class