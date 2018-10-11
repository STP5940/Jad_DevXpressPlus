Imports Microsoft.Reporting.WinForms
Public Class Formsaleyarnrpt
    Private Sub Formsaleyarnrpt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Setauthorize()
        ReportViewer1.LocalReport.ReportEmbeddedResource = "XpressPlus.Rptsaleyarn.rdlc"
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 100
        ReportViewer2.LocalReport.ReportEmbeddedResource = "XpressPlus.Rptyarndnsale.rdlc"
        ReportViewer2.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer2.ZoomMode = ZoomMode.Percent
        ReportViewer2.ZoomPercent = 100
        Dim Par1, Par2, Par3, Par8, Par9, Par10, Par11, Par12 As ReportParameter
        Par1 = New ReportParameter("Pcustname", Trim(Tbcustname.Text), True)
        Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {Par1})
        Par2 = New ReportParameter("Pcustship", Trim(Tbcustaddr.Text), True)
        Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {Par2})
        Par3 = New ReportParameter("Pdate", Trim(Tbdate.Text), True)
        Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {Par3})
        Par8 = New ReportParameter("Pdlvno", Trim(Tbdlvno.Text), True)
        Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {Par8})
        Me.ReportViewer1.RefreshReport()
        Par9 = New ReportParameter("Pcust", Trim(Tbcustname.Text), True)
        Me.ReportViewer2.LocalReport.SetParameters(New ReportParameter() {Par9})
        Par10 = New ReportParameter("Padd", Trim(Tbcustaddr.Text), True)
        Me.ReportViewer2.LocalReport.SetParameters(New ReportParameter() {Par10})
        Par11 = New ReportParameter("Pdate", Trim(Tbdate.Text), True)
        Me.ReportViewer2.LocalReport.SetParameters(New ReportParameter() {Par11})
        Par12 = New ReportParameter("Pdlvno", Trim(Tbdlvno.Text), True)
        Me.ReportViewer2.LocalReport.SetParameters(New ReportParameter() {Par12})
        Me.ReportViewer2.RefreshReport()
    End Sub
    Private Sub Btmclose_Click(sender As Object, e As EventArgs) Handles Btmclose.Click
        Me.Close()
    End Sub
    Private Sub Setauthorize()
        If Gsexpau = False Then
            ReportViewer1.ShowExportButton = False
            ReportViewer2.ShowExportButton = False
        End If
        If Gspriau = False Then
            ReportViewer1.ShowPrintButton = False
            ReportViewer2.ShowPrintButton = False
        End If
    End Sub

End Class