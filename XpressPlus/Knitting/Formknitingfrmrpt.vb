Imports Microsoft.Reporting.WinForms
Public Class Formknitingfrmrpt
    Private Sub Formknitingfrmrpt_Load(sender As Object, e As EventArgs) Handles Me.Load

        ReportViewer1.LocalReport.ReportEmbeddedResource = "XpressPlus.Rptknittingform.rdlc"
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 100
        Dim Par2, Par3, Par4, Par5, Par6 As ReportParameter
        Par2 = New ReportParameter("Parto", Trim(Tbto.Text), True)
        Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {Par2})
        Par3 = New ReportParameter("Pardate", Trim(Tbdate.Text), True)
        Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {Par3})
        Par4 = New ReportParameter("Parbill", Trim(Tbknitcomno.Text), True)
        Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {Par4})
        Par5 = New ReportParameter("Parredate", Trim(Tbredate.Text), True)
        Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {Par5})
        Par6 = New ReportParameter("Parremark", Trim(Tbremark.Text), True)
        Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {Par6})
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Btmclose_Click(sender As Object, e As EventArgs) Handles Btmclose.Click
        Me.Close()
    End Sub
End Class