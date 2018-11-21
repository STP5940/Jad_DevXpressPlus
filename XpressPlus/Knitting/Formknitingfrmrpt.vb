Imports Microsoft.Reporting.WinForms
Public Class Formknitingfrmrpt
    Private Sub Formknitingfrmrpt_Load(sender As Object, e As EventArgs) Handles Me.Load
        ReportViewer1.LocalReport.ReportEmbeddedResource = "XpressPlus.Rptknittingform.rdlc"
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 100
        Dim Par2, Par3, Par4, Par5, Par6, Par7, Par8, par9 As ReportParameter
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
        Par7 = New ReportParameter("Parfactory", Trim(TextBox1.Text), True)
        Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {Par7})
        Par8 = New ReportParameter("Gscnew", Trim(TextBox2.Text), True)
        Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {Par8})
        Par9 = New ReportParameter("balanhave", Trim(balanhave.Text), True)
        Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {Par9})


        'Dim LBS, Dlvno As String
        'Dim DataTable2 As New DataTable

        'Dim SumSend As New DataTable
        'SumSend = SQLCommand($"SELECT SUM(WgtKgOrder)/0.453592 As LBS ,Dlvno FROM Tknittcomxp WHERE Dlvno = '{Tbdlvyarnno.Text}' GROUP BY Dlvno")
        'GSumSend.DataSource = SumSend

        'With DataTable2
        '    .Columns.Add("LBS")
        '    .Columns.Add("Dlvno")
        'End With
        'DataTable2.Rows.Clear()
        'For i = 0 To Me.GSumSend.RowCount - 1
        '    LBS = Me.GSumSend.Rows(i).Cells("LBS").Value
        '    Dlvno = Me.GSumSend.Rows(i).Cells("Dlvno").Value
        '    DataTable2.Rows.Add(LBS, Dlvno)
        'Next

        'Dim Rds3 As New ReportDataSource()

        'Rds3.Name = "Dsyarndlvk"
        'Rds3.Value = SumSend
        'ReportViewer1.LocalReport.DataSources.Add(Rds3)


        '************************************

        Dim SumSend As New DataTable
        SumSend = SQLCommand($"SELECT SUM(WgtKgOrder)/0.453592 As LBS ,Dlvno FROM Tknittcomxp WHERE Dlvno = '{Tbdlvyarnno.Text}' GROUP BY Dlvno")
        GSumSend.DataSource = SumSend

        Dim LBS, Dlvno As String
        Dim LbSend As New DataTable
        With LbSend
            .Columns.Add("LBS")
            .Columns.Add("Dlvno")
        End With
        LbSend.Rows.Clear()
        For i = 0 To Me.GSumSend.RowCount - 1
            LBS = Me.GSumSend.Rows(i).Cells("LBS").Value
            Dlvno = Me.GSumSend.Rows(i).Cells("Dlvno").Value

            LbSend.Rows.Add(LBS, Dlvno)
        Next

        Dim Rds As New ReportDataSource()
        Rds.Name = "LbSend"
        Rds.Value = LbSend
        ReportViewer1.LocalReport.DataSources.Add(Rds)

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Btmclose_Click(sender As Object, e As EventArgs) Handles Btmclose.Click
        Me.Close()
    End Sub
End Class