Public Class Formtemp

    Private tlistfab, tlistyed As DataTable
    'Dim Title() = {"Dhid", "Dyedhdesc", "Billdyedno", "Lotno", "Kongno", "Pubno", "Clothid", "Clothno", "Ftype", "Fwidth", "Shadeid", "Shadedesc", "Rollwage"}
    Private Sub Formtemp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Bindinglistfab()
        Bindinglistyed()
        FilterfabGrid()
        FilteryedGrid()
        For i = 0 To FilterAllyed.Rows.Count - 1
            Balance.Rows.Add()
            Balance.Rows(i).Cells("BDyedcomno").Value = FilterAllyed.Rows(i).Cells("Dyedcomno").Value
            Balance.Rows(i).Cells("BClothidyed").Value = FilterAllyed.Rows(i).Cells("Clothidyed").Value
            Balance.Rows(i).Cells("BClothnoyed").Value = FilterAllyed.Rows(i).Cells("Clothnoyed").Value
            Balance.Rows(i).Cells("BFtypeyed").Value = FilterAllyed.Rows(i).Cells("Ftypeyed").Value
            Balance.Rows(i).Cells("BFwidthyed").Value = FilterAllyed.Rows(i).Cells("Fwidthyed").Value
            Balance.Rows(i).Cells("BQtykg").Value = FilterAllyed.Rows(i).Cells("Qtykg").Value
            Balance.Rows(i).Cells("BQtyroll").Value = FilterAllyed.Rows(i).Cells("Qtyroll").Value
        Next

        For i = 0 To Balance.Rows.Count - 1
            If Filterfab.Rows(i).Cells("Billdyedno").Value = Balance.Rows(i).Cells("BDyedcomno").Value And
                  Filterfab.Rows(i).Cells("Clothid").Value = Balance.Rows(i).Cells("BClothidyed").Value And
                  Filterfab.Rows(i).Cells("Fwidth").Value = Balance.Rows(i).Cells("BFwidthyed").Value Then
                Balance.Rows(i).Cells("BQtyroll").Value = FilterAllyed.Rows(i).Cells("Qtyroll").Value - Filterfab.Rows(i).Cells("Qtyrollfab").Value
                Balance.Rows(i).Cells("BQtykg").Value = FilterAllyed.Rows(i).Cells("Qtykg").Value - Filterfab.Rows(i).Cells("Rollwage").Value
            End If
        Next

        For i = 0 To Balance.Rows.Count - 1
            If Balance.Rows(i).Cells("BQtyroll").Value <= 0 Then
                Balance.Rows.RemoveAt(i)
                i += 1
            End If
        Next

    End Sub

    Private Sub Bindinglistfab()
        tlistfab = New DataTable
        tlistfab = SQLCommand("SELECT * FROM Vrecfabcoldet
                                WHERE Comid = '" & Gscomid & "'")
        Allfab.DataSource = tlistfab
    End Sub
    Private Sub Bindinglistyed()
        tlistyed = New DataTable
        tlistyed = SQLCommand("SELECT * FROM Vdyedcomdet
                                WHERE Comid = '" & Gscomid & "'")
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
        QtyrollfabArray.add("")

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
            QtyrollArray, QtykgArray, KnittbillArray As New List(Of String)()

        DyedcomnoArray.Add("")
        KnittcomidArray.Add("")
        ClothidArray.Add("")
        ClothnoArray.Add("")
        FtypeArray.Add("")
        FwidthArray.Add("")
        QtyrollArray.Add("")
        QtykgArray.Add("")
        KnittbillArray.Add("")

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
        Next
    End Sub

End Class