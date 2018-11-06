Imports Microsoft.Reporting.WinForms

Public Class Formreceivefabrpt
    Private Sub Formknitingfrmrpt_Load(sender As Object, e As EventArgs) Handles Me.Load
        ReportViewer1.LocalReport.ReportEmbeddedResource = "XpressPlus.Rptreceivefabform.rdlc"
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 100
        Dim Par2, Par3, Par4, Par5, Par6, Par7, Par8 As ReportParameter
        Par2 = New ReportParameter("Tbdhid", Trim(Tbdhid.Text), True)
        Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {Par2})
        Par3 = New ReportParameter("Tbdhname", Trim(Tbdhname.Text), True)
        Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {Par3})
        Par4 = New ReportParameter("Tbdyedbillno", Trim(Tbdyedbillno.Text), True)
        Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {Par4})
        Par5 = New ReportParameter("Tbknittno", Trim(Tbknittno.Text), True)
        Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {Par5})
        Par6 = New ReportParameter("Tbcolorno", Trim(Tbcolorno.Text), True)
        Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {Par6})
        Par7 = New ReportParameter("Tbrefablotno", Trim(Tbrefablotno.Text), True)
        Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {Par7})
        Par8 = New ReportParameter("Tbdyedcomno", Trim(Tbdyedcomno.Text), True)
        Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {Par8})

        Dim rollid, Mclothno, Clothtype, Dwidth, Mkong, Rollwage As String
        Dim Datareport As New DataTable
        With Datareport
            .Columns.Add("rollid")
            .Columns.Add("Mclothno")
            .Columns.Add("Clothtype")
            .Columns.Add("Dwidth")
            .Columns.Add("Mkong")
            .Columns.Add("Rollwage")
        End With
        Datareport.Rows.Clear()
        For i = 0 To Me.Dgvmas.RowCount - 1
            rollid = Me.Dgvmas.Rows(i).Cells("rollid").Value
            Mclothno = Me.Dgvmas.Rows(i).Cells("Mclothno").Value
            Clothtype = Me.Dgvmas.Rows(i).Cells("Clothtype").Value
            Dwidth = Me.Dgvmas.Rows(i).Cells("Dwidth").Value
            Mkong = Me.Dgvmas.Rows(i).Cells("Mkong").Value
            Rollwage = Me.Dgvmas.Rows(i).Cells("Rollwage").Value
            Datareport.Rows.Add(rollid, Mclothno, Clothtype, Dwidth, Mkong, Rollwage)
        Next

        Dim Rds As New ReportDataSource()
        Rds.Name = "Datareport"
        Rds.Value = Datareport
        ReportViewer1.LocalReport.DataSources.Add(Rds)

        Me.ReportViewer1.RefreshReport()

        'For i = 0 To Me.DataReport.RowCount - 1
        '    Kg4 = Me.Dgvmas.Rows(i).Cells("rollid").Value
        '    Dgvmas.Rows.Add()
        'Next


    End Sub

    Private Sub Btmclose_Click(sender As Object, e As EventArgs) Handles Btmclose.Click
        Me.Close()
    End Sub
End Class