Public Class Formdyeddetlist
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
        'Filtermastergrid()
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

    'Private Sub Bindingmaster()
    '    Tmaster = New DataTable
    '    Tmaster = SQLCommand("SELECT '' AS Stat,* FROM Vdyedcomdet WHERE Comid = '" & Gscomid & "' AND Dyedcomno = '" & Trim(Tbdyedbillno.Text) & "'")
    '    Dgvmas.DataSource = Tmaster
    'End Sub


    Private Sub Filtermastergrid(Sval As String)
        If Trim(Sval) = "" Then
            BindingBalance()
            Exit Sub
        End If
        FilterAllyed.Rows.Clear()
        Dgvmas.Rows.Clear()
        tlistyed.DefaultView.RowFilter = String.Format("Dyedcomno Like '%{0}%' or Clothno Like '%{0}%' or Ftype Like '%{0}%' or Fwidth Like '%{0}%'", Trim(Sval))
        FilteryedGrid()
        Bindingmaster()
    End Sub

    Private Sub BindingBalance()
        Filterfab.Rows.Clear()
        FilterAllyed.Rows.Clear()
        Dgvmas.Rows.Clear()
        Bindinglistfab()
        Bindinglistyed()
        FilterfabGrid()
        FilteryedGrid()
        Bindingmaster()
    End Sub

    Private Sub Formdyeddetlist_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'Dgvmas.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        'Dgvmas.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        Dgvmas.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        Dgvmas.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
    End Sub

    Private Sub Bindinglistfab()
        tlistfab = New DataTable
        tlistfab = SQLCommand("SELECT * FROM Vrecfabcoldet
                                WHERE Comid = '" & Gscomid & "' AND Billdyedno = '" & Tbdyedbillno.Text & "' ")
        Allfab.DataSource = tlistfab
    End Sub
    Private Sub Bindinglistyed()
        tlistyed = New DataTable
        tlistyed = SQLCommand("SELECT * FROM Vdyedcomdet
                                WHERE Comid = '" & Gscomid & "' AND Dyedcomno = '" & Tbdyedbillno.Text & "' ")
        Allyed.DataSource = tlistyed
    End Sub

    Private Sub FilterfabGrid()
        Dim BilldyednoArray, ClothidArray,
            ClothnoArray, FtypeArray, FwidthArray, RollwageArray, QtyrollArray, QtyrollfabArray As New List(Of String)()

        BilldyednoArray.Add("")
        ClothidArray.Add("")
        ClothnoArray.Add("")
        FtypeArray.Add("")
        FwidthArray.Add("")
        RollwageArray.Add("")
        QtyrollArray.Add("")
        QtyrollfabArray.Add("")

        For I = 0 To Allfab.RowCount - 1
            For Filters = 0 To BilldyednoArray.Count - 1

                If BilldyednoArray(Filters) = Allfab.Rows(I).Cells("Billdyedno").Value And
                    FwidthArray(Filters) = Allfab.Rows(I).Cells("Fwidth").Value And
                    ClothidArray(Filters) = Allfab.Rows(I).Cells("Clothid").Value Then

                    RollwageArray(Filters) = RollwageArray(Filters) + Allfab.Rows(I).Cells("Rollwage").Value
                    QtyrollfabArray(Filters) = QtyrollfabArray(Filters) + 1
                    Exit For
                End If

                If Filters = BilldyednoArray.Count - 1 Then
                    BilldyednoArray.Add(Allfab.Rows(I).Cells("Billdyedno").Value)
                    ClothidArray.Add(Allfab.Rows(I).Cells("Clothid").Value)
                    ClothnoArray.Add(Allfab.Rows(I).Cells("Clothno").Value)
                    FtypeArray.Add(Allfab.Rows(I).Cells("Ftype").Value)
                    FwidthArray.Add(Allfab.Rows(I).Cells("Fwidth").Value)
                    RollwageArray.Add(Allfab.Rows(I).Cells("Rollwage").Value)
                    QtyrollfabArray.Add(1)
                End If
            Next
        Next

        Dim PontArray As Integer = 0
        For i = 0 To BilldyednoArray.Count - 2
            PontArray = i + 1
            Filterfab.Rows.Add()
            Filterfab.Rows(i).Cells("Billdyedno").Value = BilldyednoArray(PontArray)
            Filterfab.Rows(i).Cells("Clothid").Value = ClothidArray(PontArray)
            Filterfab.Rows(i).Cells("Clothno").Value = ClothnoArray(PontArray)
            Filterfab.Rows(i).Cells("Ftype").Value = FtypeArray(PontArray)
            Filterfab.Rows(i).Cells("Fwidth").Value = FwidthArray(PontArray)
            Filterfab.Rows(i).Cells("Rollwage").Value = RollwageArray(PontArray)
            Filterfab.Rows(i).Cells("Qtyrollfab").Value = QtyrollfabArray(PontArray)
        Next

    End Sub

    Private Sub FilteryedGrid()

        'Clothid
        Dim DyedcomnoArray, KnittcomidArray, ClothidArray, ClothnoArray, FtypeArray, FwidthArray,
            QtyrollArray, QtykgArray, KnittbillArray, ShadeidArray, ShadedescArray As New List(Of String)()

        DyedcomnoArray.Add("")
        KnittcomidArray.Add("")
        ClothidArray.Add("")
        ClothnoArray.Add("")
        FtypeArray.Add("")
        FwidthArray.Add("")
        QtyrollArray.Add("")
        QtykgArray.Add("")
        KnittbillArray.Add("")
        ShadeidArray.Add("")
        ShadedescArray.Add("")

        For I = 0 To Allyed.RowCount - 1
            For Filters = 0 To DyedcomnoArray.Count - 1

                If DyedcomnoArray(Filters) = Allyed.Rows(I).Cells("Dyedcomno").Value And
                    FwidthArray(Filters) = Allyed.Rows(I).Cells("Fwidth").Value And
                    ClothidArray(Filters) = Allyed.Rows(I).Cells("Clothid").Value Then

                    QtykgArray(Filters) = QtykgArray(Filters) + Allyed.Rows(I).Cells("Qtykg").Value
                    QtyrollArray(Filters) = QtyrollArray(Filters) + Allyed.Rows(I).Cells("Qtyroll").Value
                    Exit For
                End If

                If Filters = DyedcomnoArray.Count - 1 Then
                    DyedcomnoArray.Add(Allyed.Rows(I).Cells("Dyedcomno").Value)
                    KnittcomidArray.Add(Allyed.Rows(I).Cells("Knittcomid").Value)
                    ClothidArray.Add(Allyed.Rows(I).Cells("Clothid").Value)
                    ClothnoArray.Add(Allyed.Rows(I).Cells("Clothno").Value)
                    FtypeArray.Add(Allyed.Rows(I).Cells("Ftype").Value)
                    FwidthArray.Add(Allyed.Rows(I).Cells("Fwidth").Value)
                    QtyrollArray.Add(Allyed.Rows(I).Cells("Qtyroll").Value)
                    QtykgArray.Add(Allyed.Rows(I).Cells("Qtykg").Value)
                    KnittbillArray.Add(Allyed.Rows(I).Cells("Knittbill").Value)
                    ShadeidArray.Add(Allyed.Rows(I).Cells("Shadeid").Value)
                    ShadedescArray.Add(Allyed.Rows(I).Cells("Shadedesc").Value)
                End If
            Next
        Next

        Dim PontArray As Integer = 0
        For i = 0 To DyedcomnoArray.Count - 2
            PontArray = i + 1
            FilterAllyed.Rows.Add()
            FilterAllyed.Rows(i).Cells("Dyedcomno").Value = DyedcomnoArray(PontArray)
            FilterAllyed.Rows(i).Cells("Knittcomid").Value = KnittcomidArray(PontArray)
            FilterAllyed.Rows(i).Cells("Clothidyed").Value = ClothidArray(PontArray)
            FilterAllyed.Rows(i).Cells("Clothnoyed").Value = ClothnoArray(PontArray)
            FilterAllyed.Rows(i).Cells("Ftypeyed").Value = FtypeArray(PontArray)
            FilterAllyed.Rows(i).Cells("Fwidthyed").Value = FwidthArray(PontArray)
            FilterAllyed.Rows(i).Cells("Qtyroll").Value = QtyrollArray(PontArray)
            FilterAllyed.Rows(i).Cells("Qtykg").Value = QtykgArray(PontArray)
            FilterAllyed.Rows(i).Cells("Knittbill").Value = KnittbillArray(PontArray)
            FilterAllyed.Rows(i).Cells("Shadeid").Value = ShadeidArray(PontArray)
            FilterAllyed.Rows(i).Cells("Shadedesc").Value = ShadedescArray(PontArray)
        Next
    End Sub

    Private Sub Bindingmaster()
        For i = 0 To FilterAllyed.Rows.Count - 1
            Dgvmas.Rows.Add()
            Dgvmas.Rows(i).Cells("BDyedcomno").Value = FilterAllyed.Rows(i).Cells("Dyedcomno").Value
            Dgvmas.Rows(i).Cells("BClothidyed").Value = FilterAllyed.Rows(i).Cells("Clothidyed").Value
            Dgvmas.Rows(i).Cells("BClothnoyed").Value = FilterAllyed.Rows(i).Cells("Clothnoyed").Value
            Dgvmas.Rows(i).Cells("BFtypeyed").Value = FilterAllyed.Rows(i).Cells("Ftypeyed").Value
            Dgvmas.Rows(i).Cells("BFwidthyed").Value = FilterAllyed.Rows(i).Cells("Fwidthyed").Value
            Dgvmas.Rows(i).Cells("BQtykg").Value = FilterAllyed.Rows(i).Cells("Qtykg").Value
            Dgvmas.Rows(i).Cells("BQtyroll").Value = FilterAllyed.Rows(i).Cells("Qtyroll").Value
            Dgvmas.Rows(i).Cells("BShadeid").Value = FilterAllyed.Rows(i).Cells("Shadeid").Value
            Dgvmas.Rows(i).Cells("BShadedesc").Value = FilterAllyed.Rows(i).Cells("Shadedesc").Value
        Next

        For i = 0 To Filterfab.Rows.Count - 1
            For Balan = 0 To Dgvmas.Rows.Count - 1
                'MsgBox(i & ":" & Balan)

                If Filterfab.Rows(i).Cells("Billdyedno").Value = Dgvmas.Rows(Balan).Cells("BDyedcomno").Value And
                      Filterfab.Rows(i).Cells("Clothid").Value = Dgvmas.Rows(Balan).Cells("BClothidyed").Value And
                      Filterfab.Rows(i).Cells("Fwidth").Value = Dgvmas.Rows(Balan).Cells("BFwidthyed").Value Then
                    Dgvmas.Rows(Balan).Cells("BQtyroll").Value = FilterAllyed.Rows(Balan).Cells("Qtyroll").Value - Filterfab.Rows(i).Cells("Qtyrollfab").Value
                    Dgvmas.Rows(Balan).Cells("BQtykg").Value = FilterAllyed.Rows(Balan).Cells("Qtykg").Value - Filterfab.Rows(i).Cells("Rollwage").Value
                End If

            Next
        Next

        For i = 0 To Dgvmas.Rows.Count - 1
            If i <= Dgvmas.Rows.Count - 1 Then
                If Dgvmas.Rows(i).Cells("BQtyroll").Value <= 0 Then
                    Dgvmas.Rows.RemoveAt(i)
                    i -= 1
                End If
            End If
        Next

    End Sub

End Class