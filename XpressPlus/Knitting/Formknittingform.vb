Imports System.ComponentModel
Imports Microsoft.Reporting.WinForms
Public Class Formknittingform
    Private Tmasterknit, Tdetailsknit, Tmasterdlv, Tdetailsdlv, Tlist, TYanlist, Dttemp, Vdeliyarndet, Tmaster As DataTable
    Private Pagecount, Maxrec, Pagesize, Currentpage, Recno As Integer
    Private WithEvents Dtplistfm As New DateTimePicker
    Private WithEvents Dtplistto As New DateTimePicker
    Private Bs As BindingSource
    'Private Bs As BindingSource

    Private Sub Formknittingform_Load(sender As Object, e As EventArgs) Handles Me.Load
        Controls.Add(Dtplistfm)
        'Dtplistfm.Value = Now
        'Dtplistfm.Width = 130
        'Me.ToolStrip4.Items.Insert(5, New ToolStripControlHost(Dtplistfm))
        'Me.ToolStrip4.Items(5).Alignment = ToolStripItemAlignment.Right
        'Controls.Add(Dtplistto)
        'Dtplistto.Value = Now
        'Dtplistto.Width = 130
        'Me.ToolStrip4.Items.Insert(4, New ToolStripControlHost(Dtplistto))
        'Me.ToolStrip4.Items(4).Alignment = ToolStripItemAlignment.Right
        'Dtplistfm.Visible = False
        'Dtplistto.Visible = False

        '------------- Tab Fabric -------------'
        Controls.Add(Dtplistfm)
        Dtplistfm.Value = Now
        Dtplistfm.Width = 130
        Me.ToolStrip4.Items.Insert(5, New ToolStripControlHost(Dtplistfm))
        Me.ToolStrip4.Items(5).Alignment = ToolStripItemAlignment.Right
        Dtplistfm.Visible = False

        Controls.Add(Dtplistto)
        Dtplistto.Value = Now
        Dtplistto.Width = 130
        Me.ToolStrip4.Items.Insert(4, New ToolStripControlHost(Dtplistto))
        Me.ToolStrip4.Items(4).Alignment = ToolStripItemAlignment.Right
        Dtplistto.Visible = False
        '------------- End Tab Fabric -------------'

        GroupPanel2.Visible = True
        'Setauthorize()
        Retdocprefix()
        CloseMaster()
        Tbmycom.Text = Trim(Gscomname)
        Tbremark.Enabled = False
        Dgvmas.Enabled = False
    End Sub
    Private Sub Formknittingform_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dgvlist.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        Dgvlist.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        Dgvmas.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        Dgvmas.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        Bindinglist()

        YanList.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        YanList.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        YanList.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        YanList.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        BindingYanlist()
    End Sub
    Private Sub Btmnew_Click(sender As Object, e As EventArgs) Handles Btmnew.Click
        Clrdgrid()
        Clrtxtbox()
        OpenMaster()
        TabControl1.SelectedTabIndex = 2
        BindingNavigator1.Enabled = False
        Mainbuttonaddedit()

        Tbremark.Enabled = True
        Dgvmas.Enabled = True
        'Btdedit.Enabled = False
        'Btddel.Enabled = False
    End Sub

    Private Sub NewBtn()
        Btfindfabtypeid.Enabled = True
        Dtpknitcomdate.Enabled = True
        QtyrollOrder.Enabled = True
        Btfinddlvno.Enabled = True
        Dtprecdate.Enabled = True
        WgtKgOrder.Enabled = True
        Btdcancel.Enabled = True
        Tbfinwgt.Enabled = True
        Dgvyarn.Enabled = True
        Btdadd.Enabled = True
        Dgvmas.Enabled = True
        GroupPanel2.Visible = True
        QtyrollStore.Text = ""
        WgtKgStore.Text = ""
    End Sub

    Private Sub Btmedit_Click(sender As Object, e As EventArgs) Handles Btmedit.Click
        'If TabControl1.SelectedTabIndex = 0 Then
        '    Exit Sub
        'End If
        'If Confirmedit() = True Then
        '    BindingNavigator1.Enabled = False
        '    Mainbuttonaddedit()
        'End If
        'BindingNavigator1.Enabled = False
        'Mainbuttonaddedit()
        Dtpknitcomdate.Enabled = True
        Btfinddlvno.Enabled = True
        Dgvyarn.Enabled = True
        Tbremark.Enabled = True
        Ctdedit.Enabled = True
        Ctddel.Enabled = True
        Btmnew.Enabled = False
        Tbfinwgt.Enabled = True
        QtyrollOrder.Enabled = True
        WgtKgOrder.Enabled = True
        Btdadd.Enabled = True
        Btdcancel.Enabled = True
        BindingNavigator1.Enabled = False
        Mainbuttonaddedit()
        SelectData()

    End Sub
    Private Sub Btmdel_Click(sender As Object, e As EventArgs) Handles Btmdel.Click
        If Trim(Tbknitcomno.Text) = "NEW" Then
            Exit Sub
        End If
        If Trim(Tbknitcomno.Text) = "" Then
            Exit Sub
        End If
        If Confirmdelete() = True Then
            Deldetails(Trim(Tbknitcomno.Text))
            SQLCommand("DELETE FROM Tknittcomxp WHERE Comid = '" & Gscomid & "' AND Knitcomno = '" & Trim(Tbknitcomno.Text) & "'")
            Clrdgrid()
            Clrtxtbox()
            BindingYanlist()
            Bindinglist()
            TabControl1.SelectedTabIndex = 0
            BindingNavigator1.Enabled = False
            Mainbuttoncancel()
        End If
    End Sub

    Private Sub Btmsave_Click(sender As Object, e As EventArgs) Handles Btmsave.Click
        If Tstbsumroll.Text > QtyrollStore.Text OrElse Tstbsumroll.Text < QtyrollStore.Text Then
            Informmessage("จำนวน (Roll) ไม่ตรงกับจำนวนที่มีในระบบ")
            Exit Sub
        End If
        If WgtKgStore.Text > Tstbsumkg.Text OrElse WgtKgStore.Text < Tstbsumkg.Text Then
            Informmessage("น้ำหนัก (KG) ไม่ตรงกับน้ำหนักที่มีในระบบ")
            Exit Sub
        End If

        Tbremark.Enabled = False
        Dgvmas.Enabled = False

        If Tstbdocpre.Text = "" Then
            Informmessage("กรุณาติดต่อ Admin เพื่อกำหนด Prefix ของเลขที่เอกสาร")
            Exit Sub
        End If
        If Validmas() = False Then
            Informmessage("กรุณาตรวจสอบข้อมูลในการสั่งทอให้ครบถ้วน")
            Exit Sub
        End If
        If Validdet() = False Then
            Informmessage("กรุณาตรวจสอบรายละเอียดในการสั่งทอให้ครบถ้วน")
            Exit Sub
        End If
        If Trim(Tbknitcomno.Text) = "NEW" Then
            Newdoc()
        Else
            Editdoc()
        End If
        Btmreports_Click(sender, e)
        Tsbwsave.Visible = False
        Clrdgrid()
        Clrtxtbox()
        TabControl1.SelectedTabIndex = 0
        BindingYanlist()
        Bindinglist()
        BindingNavigator1.Enabled = False
        Mainbuttoncancel()
        Btmcancel_Click(sender, e)
    End Sub
    Private Sub Btmcancel_Click(sender As Object, e As EventArgs) Handles Btmcancel.Click
        Clrtxtbox()
        Clrdgrid()
        CloseMaster()
        TabControl1.SelectedTabIndex = 0
        BindingNavigator1.Enabled = False
        Tbremark.Enabled = False
        Dgvmas.Enabled = False
        Mainbuttoncancel()
    End Sub
    Private Sub CloseMaster()
        BindingNavigator1.Enabled = False
        Dtprecdate.Enabled = False
        Dtpknitcomdate.Enabled = False
        Dgvyarn.Enabled = False
        Btfinddlvno.Enabled = False
        GroupPanel2.Visible = False
        Tbqtyroll.Text = ""
        Tbwgtkg.Text = ""
        Tbwgtlbs.Text = ""
        QtyrollStore.Text = ""
        WgtKgStore.Text = ""
    End Sub
    Private Sub OpenMaster()
        Dtprecdate.Enabled = False
        Dtpknitcomdate.Enabled = True
        Dgvyarn.Enabled = True
        Btfinddlvno.Enabled = True
    End Sub

    Private Sub CloseDetiel()
        GroupPanel2.Visible = False
        Tbfinwgt.Enabled = False
        Dgvmas.Enabled = False
        Btfindfabtypeid.Enabled = False
        WgtKgOrder.Enabled = False
        Btdcancel.Enabled = False
        Btdadd.Enabled = False
        QtyrollOrder.Enabled = False
        QtyrollStore.Text = ""
        WgtKgStore.Text = ""
    End Sub
    Private Sub Btmreports_Click(sender As Object, e As EventArgs) Handles Btmreports.Click
        If Dgvmas.RowCount = 0 Then
            Exit Sub
        End If
        If Tsbwsave.Visible = True Then
            Informmessage("มีการเปลี่ยนแปลงและยังไม่ทำการบันทึก")
            Exit Sub
        End If
        Binddetailsdlv()
        Binddetailsknit()
        Dim Frm As New Formknitingfrmrpt
        Frm.ReportViewer1.Reset()
        Frm.Tbdate.Text = Format(Dtpknitcomdate.Value, "dd/MM/yyyy")
        Frm.Tbto.Text = Trim(Tbknitname.Text)
        Frm.Tbknitcomno.Text = Trim(Tbknitcomno.Text)
        Frm.Tbredate.Text = Format(Dtprecdate.Value, "dd/MM/yyyy")
        Frm.Tbremark.Text = Trim(Tbremark.Text)
        If Gsexpau = False Then
            Frm.ReportViewer1.ShowExportButton = False
        End If
        If Gspriau = False Then
            Frm.ReportViewer1.ShowPrintButton = False
        End If
        Dim Rds, Rds1 As New ReportDataSource()
        Rds.Name = "DataSet1"
        Rds.Value = Tdetailsdlv
        Frm.ReportViewer1.LocalReport.DataSources.Add(Rds)
        Rds1.Name = "DataSet2"
        Rds1.Value = Tdetailsknit
        Frm.ReportViewer1.LocalReport.DataSources.Add(Rds1)
        'showform(Frm)
        Frm.Show()

        Clrtxtbox()
        Clrdgrid()
        BindingNavigator1.Enabled = False
        Mainbuttoncancel()
        TabControl1.SelectedTabIndex = 0
    End Sub
    Private Sub Btmfind_Click(sender As Object, e As EventArgs) Handles Btmfind.Click
        TabControl1.SelectedTabIndex = 0
        Tscboth.Checked = True
        Tstbkeyword.Select()
        Tstbkeyword.Focus()

        Clrtxtbox()
        Clrdgrid()
        BindingNavigator1.Enabled = False
        Mainbuttoncancel()
    End Sub
    Private Sub Btmclose_Click(sender As Object, e As EventArgs) Handles Btmclose.Click
        Me.Close()
    End Sub
    Private Sub Tscbdate_CheckedChanged(sender As Object, e As EventArgs) Handles Tscbdate.CheckedChanged
        If Tscbdate.Checked = True Then
            Tscboth.Checked = False
            Tstbkeyword.Visible = False
            Dtplistfm.Visible = True
            Dtplistto.Visible = True
            Btrefresh.Visible = True
        Else
            Tscboth.Checked = True
            Btrefresh.Visible = False
            Dtplistfm.Visible = False
            Dtplistto.Visible = False
            Tstbkeyword.Visible = True
            Tstbkeyword.Select()
            Tstbkeyword.Focus()
        End If
    End Sub
    Private Sub Tscboth_CheckedChanged(sender As Object, e As EventArgs) Handles Tscboth.CheckedChanged
        If Tscboth.Checked = True Then
            Tscbdate.Checked = False
            Btrefresh.Visible = False
            Dtplistfm.Visible = False
            Dtplistto.Visible = False
            Tstbkeyword.Visible = True
            Tstbkeyword.Select()
            Tstbkeyword.Focus()
        Else
            Tstbkeyword.Visible = False
            Tscbdate.Checked = True
            Dtplistfm.Visible = True
            Dtplistto.Visible = True
            Btrefresh.Visible = True
        End If
    End Sub
    Private Sub Tstbkeyword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tstbkeyword.KeyPress
        e.Handled = (Asc(e.KeyChar) = 39)
    End Sub
    Private Sub Tstbkeyword_TextChanged(sender As Object, e As EventArgs) Handles Tstbkeyword.TextChanged
        If Me.Created Then
            Btlistfind_Click(sender, e)
        End If
    End Sub
    Private Sub Btlistfind_Click(sender As Object, e As EventArgs) Handles Btlistfind.Click
        If Tscbdate.Checked = True Then
            Searchlistbydate()
        End If
        If Tscboth.Checked = True Then
            Searchlistbyoth(Trim(Tstbkeyword.Text))
        End If
    End Sub
    Private Sub Btrefresh_Click(sender As Object, e As EventArgs) Handles Btrefresh.Click
        Bindinglist()
    End Sub
    Private Sub Dgvlist_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgvlist.CellClick
        If Dgvlist.RowCount = 0 Then
            Exit Sub
        End If
        Dgvlist.CurrentRow.Selected = True
    End Sub
    Private Sub Dgvlist_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Dgvlist.CellMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Me.Dgvlist.Rows.Count < 1 Then Exit Sub
            If e.RowIndex < 0 Then Exit Sub
            Dgvlist.CurrentCell = Dgvlist(3, e.RowIndex)
            Me.Dgvlist.Rows(e.RowIndex).Selected = True
            Editcontextlistmenu()
        End If
    End Sub

    Private Sub YanList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles YanList.CellClick
        If YanList.RowCount = 0 Then
            Exit Sub
        End If
        YanList.CurrentRow.Selected = True
    End Sub

    Private Sub YanList_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles YanList.CellMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Me.YanList.Rows.Count < 1 Then Exit Sub
            If e.RowIndex < 0 Then Exit Sub
            YanList.CurrentCell = YanList(2, e.RowIndex)
            Me.YanList.Rows(e.RowIndex).Selected = True
            EditcontextYanList()
        End If
    End Sub

    Private Sub Ctmledit_Click(sender As Object, e As EventArgs) Handles Ctmledit.Click
        Clrdgrid()
        'Clrtxtbox()
        Clrdetails()
        Tbknitcomno.Text = Trim(Dgvlist.CurrentRow.Cells("Knitcomno").Value)
        'Bs.Position = Bs.Find("Knitcomno", Trim(Dgvlist.CurrentRow.Cells("Knitcomno").Value))
        'Tbdlvyarnno.DataBindings.Add("Text", Bs, "Knitcomno")
        Tbknitcomno.Enabled = False
        Btfinddlvno.Enabled = False
        Dtpknitcomdate.Enabled = False
        Tbknitcomno.DataBindings.Clear()
        Tbknitcomno.Text = ""
        Bs.Position = Bs.Find("Knitcomno", Trim(Dgvlist.CurrentRow.Cells("Knitcomno").Value))
        Tbknitcomno.DataBindings.Add("Text", Bs, "Knitcomno")
        Tbknitcomno.Enabled = False
        Bindmasterknit()
        Bindmasterdlv()
        Binddetailsdlv()
        TabControl1.SelectedTabIndex = 2
        'BindingNavigator1.Enabled = True

        If Dgvyarn.RowCount > 0 Then
            Dgvyarn.Rows(0).Selected = False
        End If
        If Dgvmas.RowCount > 0 Then
            Dgvmas.Rows(0).Selected = False
        End If

        BindingNavigator1.Enabled = True
        Btmnew.Enabled = False
        Btmedit.Enabled = True
        Btmdel.Enabled = True
        Btmsave.Enabled = False
        Btmcancel.Enabled = True
        Btmreports.Enabled = True
        Tbremark.Enabled = False
        Btdedit.Enabled = False
        Tbfinwgt.Enabled = False
        QtyrollOrder.Enabled = False
        WgtKgOrder.Enabled = False
        Btdadd.Enabled = False
        Btdcancel.Enabled = False
        Tbdozen.Visible = False
        Label_dozen.Visible = False
        GroupPanel2.Visible = False
        Btdbadd.Enabled = False
        Btddel.Enabled = False
        'Btdbadd.Enabled = True
        'Btdedit.Enabled = True
        'Btddel.Enabled = True
        Dgvmas.Enabled = False
        Dgvyarn.Enabled = False
    End Sub
    Private Sub Btfirst_Click(sender As Object, e As EventArgs) Handles Btfirst.Click
        Befirst()
    End Sub
    Private Sub Btprev_Click(sender As Object, e As EventArgs) Handles Btprev.Click
        Beprev()
    End Sub
    Private Sub Btnext_Click(sender As Object, e As EventArgs) Handles Btnext.Click
        Benext()
    End Sub
    Private Sub Btlast_Click(sender As Object, e As EventArgs) Handles Btlast.Click
        Belast()
    End Sub
    Private Sub Btfinddlvno_Click(sender As Object, e As EventArgs) Handles Btfinddlvno.Click
        Dim Frm As New Formdlvnoknittlist
        Showdiaformcenter(Frm, Me)
        If Frm.Tbcancel.Text = "C" Then
            Exit Sub
        End If
        Tbdlvyarnno.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("Mdevno").Value)
        Bindmasterdlv()
        SelectData()
    End Sub
    Private Sub Dgvyarn_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgvyarn.CellClick
        If Dgvyarn.RowCount = 0 Then
            Exit Sub
        End If
        Dgvyarn.CurrentRow.Selected = True
    End Sub
    Private Sub Btfindfabtypeid_Click(sender As Object, e As EventArgs) Handles Btfindfabtypeid.Click
        'MsgBox(Dgvyarn.Rows(0).Cells("Dyarnid").Value)

        If Validmas() = False Then
            Informmessage("กรุณากรอกข้อมูลใบส่งด้าย ")
            Exit Sub
        End If

        Dim Frm As New Formfabrictypelist
        Frm.Dyarnid.Text = Trim(Dgvyarn.Rows(0).Cells("Dyarnid").Value)
        Showdiaformcenter(Frm, Me)
        If Frm.Tbcancel.Text = "C" Then
            Exit Sub
        End If

        Tbclothid.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("Mid").Value)
        Tbclothno.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("Mname").Value)
        Tbtypename.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("Ftype").Value)
        Tbfinwidth.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("Fwidth").Value)
        QtyrollOrder.Focus()

        If Tbtypename.Text = "RIB" Then
            Tbdozen.Text = ""
            Tbdozen.Visible = True
            Label_dozen.Visible = True
            'Tbdozen.Focus()
        Else
            Tbdozen.Text = "0"
            Tbdozen.Visible = False
            Label_dozen.Visible = False
            'Tbfinwgt.Focus()
            Exit Sub
        End If

        'Show_Vdeliyarndet2()
    End Sub
    'Private Sub Tbqtyroll_KeyDown(sender As Object, e As KeyEventArgs) Handles Tbqtyroll.KeyDown
    '    If (e.KeyCode = Keys.Enter) Then
    '        Tbdozen.Focus()
    '    End If
    'End Sub

    'Private Sub Tbwgtkg_KeyDown(sender As Object, e As KeyEventArgs) Handles Tbwgtkg.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        If Tbwgtkg.Text = "" Then
    '            Tbwgtlbs.Text = "0"
    '            Tbfinwgt.Focus()
    '            Exit Sub
    '        End If
    '        Tbwgtlbs.Text = Format(Findpoud(Tbwgtkg.Text), "###,###")
    '        Tbfinwgt.Focus()
    '    End If
    'End Sub

    'Test  QtyrollOrder.Focus()
    'Private Sub QtyrollOrder_KeyDown(sender As Object, e As KeyEventArgs)
    '    If (e.KeyCode = Keys.Enter) Then
    '        WgtKgOrder.Focus()
    '    End If
    'End Sub
    ''Test  WgtKgOrder.Focus()
    'Private Sub WgtKgOrder_KeyDown(sender As Object, e As KeyEventArgs)
    '    If (e.KeyCode = Keys.Enter) Then
    '        Btdadd_Click(sender, e)
    '        Show_Vdeliyarndet2()
    '    End If
    'End Sub




    'test---
    'Private Sub Ctmledit2_Click(sender As Object, e As EventArgs) Handles Ctmledit2.Click
    '    MsgBox("Hello Word")
    '    Tbdozen.Text = "0"
    '    Tbfinwgt.Text = "-"

    '    'QtyrollStore.Text = "0"
    '    'WgtKgStore.Text = "0"

    '    'Tstbsumroll.Text = "0"
    '    'Tstbsumkg.Text = "0"
    '    'QtyrollOrder.Text = "0"
    '    'WgtKgOrder.Text = "0"
    '    'ShowRollOrder.Text = "0"
    '    'ShowKgOrder.Text = "0"
    '    Show_Vdeliyarndet()

    'End Sub
    'Private Sub Show_Vdeliyarndet()
    '    Vdeliyarndet = New DataTable
    '    'Vdeliyarndet = SQLCommand("SELECT * FROM Vdeliyarndet
    '    '                        WHERE Comid = '" & Gscomid & "' AND Dlvno = '" & Trim(Tbdlvyarnno.Text) & "'")
    '    Vdeliyarndet = SQLCommand("SELECT * FROM VdeliyarnCalculate
    '                            WHERE Comid = '" & Gscomid & "' AND Dlvno = '" & Trim(Tbdlvyarnno.Text) & "'")
    '    If Vdeliyarndet.Rows.Count > 0 Then
    '        'TbNwkgpc.Text = Trim(Vdeliyarndet.Rows(0)("Nwkgpc"))
    '        'TbNofc.Text = Trim(Vdeliyarndet.Rows(0)("Nofc"))
    '        'Tbwgtkg.Text = Trim(Vdeliyarndet.Rows(0)("WgtKG"))
    '        'Tbqtyroll.Text = Math.Round(Tbwgtkg.Text / 20)
    '        'Tbwgtlbs.Text = Math.Round(Tbwgtkg.Text * 2.2046)
    '        TbNwkgpc.Text = Vdeliyarndet.Rows(0)("Nwkgpc")
    '        TbNofc.Text = Vdeliyarndet.Rows(0)("Nofc")
    '        Tbwgtkg.Text = Convert.ToDouble(Vdeliyarndet.Rows(0)("WgtKG")).ToString("N2")
    '        Tbqtyroll.Text = Format(CLng(Tbwgtkg.Text / 20), "###,###")
    '        Tbwgtlbs.Text = Convert.ToDouble(Tbwgtkg.Text * 2.2046).ToString("N2")
    '        '----------

    '        ShowRollOrder.Text = Tstbsumroll.Text
    '        ShowKgOrder.Text = Tstbsumkg.Text

    '        QtyrollStore.Text = (Tbqtyroll.Text - ShowRollOrder.Text)
    '        WgtKgStore.Text = Convert.ToDouble(Tbwgtkg.Text - ShowKgOrder.Text).ToString("N2")


    '        'Binddetailsdlv()
    '    End If
    'End Sub
    Private Sub Show_Vdeliyarndet()
        If Dgvyarn.RowCount = 0 Then
            QtyrollStore.Text = 0
            WgtKgStore.Text = 0
            Exit Sub
        End If
        Vdeliyarndet = New DataTable
        Vdeliyarndet = SQLCommand("SELECT * FROM VdeliyarnCalculate
                                WHERE Comid = '" & Gscomid & "' AND Dlvno = '" & Trim(Tbdlvyarnno.Text) & "'")
        If Vdeliyarndet.Rows.Count > 0 Then
            TbNwkgpc.Text = Vdeliyarndet.Rows(0)("Nwkgpc")
            TbNofc.Text = Vdeliyarndet.Rows(0)("Nofc")
            Tbwgtkg.Text = Convert.ToDouble(Vdeliyarndet.Rows(0)("WgtKG")).ToString("N2")
            Tbqtyroll.Text = Format(CLng(Tbwgtkg.Text / 20), "###,##0")
            If Tbqtyroll.Text = 0 Then
                Tbqtyroll.Text = 1
            End If
            Tbwgtlbs.Text = Convert.ToDouble(Tbwgtkg.Text * 2.2046).ToString("N2")
            '----------

            ShowRollOrder.Text = Tstbsumroll.Text
            ShowKgOrder.Text = Tstbsumkg.Text
            QtyrollStore.Text = Format(CLng(Tbwgtkg.Text / 20), "###,##0")
            If QtyrollStore.Text = 0 Then
                QtyrollStore.Text = 1
            End If
            WgtKgStore.Text = Convert.ToDouble(Vdeliyarndet.Rows(0)("WgtKG")).ToString("N2")

            'If Tbqtyroll.Text = "" Then
            '    QtyrollStore.Text = Format(CLng(Tbwgtkg.Text / 20), "###,###")
            '    WgtKgStore.Text = Convert.ToDouble(Vdeliyarndet.Rows(0)("WgtKG")).ToString("N2")
            '    Exit Sub
            '    QtyrollStore.Text = (Tbqtyroll.Text - ShowRollOrder.Text)
            '    WgtKgStore.Text = Convert.ToDouble(Tbwgtkg.Text - ShowKgOrder.Text).ToString("N2")
            'End If

            'QtyrollStore.Text = (Tbqtyroll.Text - ShowRollOrder.Text)
            'WgtKgStore.Text = Convert.ToDouble(Tbwgtkg.Text - ShowKgOrder.Text).ToString("N2")


        End If
    End Sub
    '*******************************************
    Private Sub Show_Vdeliyarndet2()
        Vdeliyarndet = New DataTable
        Vdeliyarndet = SQLCommand("SELECT * FROM VdeliyarnCalculate
                                WHERE Comid = '" & Gscomid & "' AND Dlvno = '" & Trim(Tbdlvyarnno.Text) & "'")
        If Vdeliyarndet.Rows.Count > 0 Then
            TbNwkgpc.Text = Vdeliyarndet.Rows(0)("Nwkgpc")
            TbNofc.Text = Vdeliyarndet.Rows(0)("Nofc")
            Tbwgtkg.Text = Convert.ToDouble(Vdeliyarndet.Rows(0)("WgtKG")).ToString("N2")
            Tbqtyroll.Text = Format(CLng(Tbwgtkg.Text / 20), "###,###")
            Tbwgtlbs.Text = Convert.ToDouble(Tbwgtkg.Text * 2.2046).ToString("N2")
            '----------

            ShowRollOrder.Text = Tstbsumroll.Text
            ShowKgOrder.Text = Tstbsumkg.Text
            QtyrollStore.Text = (Tbqtyroll.Text - ShowRollOrder.Text)
            WgtKgStore.Text = Convert.ToDouble(Tbwgtkg.Text - ShowKgOrder.Text).ToString("N2")

        End If
    End Sub
    Private Sub Btdadd_Click(sender As Object, e As EventArgs) Handles Btdadd.Click
        If Validinput() = False Then
            Informmessage("กรุณาตรวจสอบข้อมูลให้ถูกต้อง ครบถ้วน")
            Exit Sub
        End If

        If Validnumber() = False Then
            Informmessage("กรุณาตรวจจำนวนให้ถูกต้อง ครบถ้วน(พับ,ก.ก.)")
            Exit Sub
        End If

        If QtyrollOrder.Text = "" OrElse WgtKgOrder.Text = "" Then
            Informmessage("กรุณาตรวจสอบจำนวนพับ หรือน้ำหนักสั่งทอให้ถูกต้องครบถ้วน")
            If QtyrollOrder.Text = "" Then
                QtyrollOrder.Select()
            Else
                WgtKgOrder.Select()
            End If
            Exit Sub
        End If
        If CDbl(QtyrollOrder.Text) = 0 OrElse CDbl(WgtKgOrder.Text) = 0 Then
            Informmessage("จำนวนพับ หรือน้ำหนักสั่งทอต้องมากกว่า 0")
            If QtyrollOrder.Text = 0 Then
                QtyrollOrder.Select()
            Else
                WgtKgOrder.Select()
            End If
            Exit Sub
        End If

        If Tbaddedit.Text = "เพิ่ม" Then
            If Chkdupyarnidingrid() = True Then
                Informmessage("ผ้าเบอร์นี้ มีแล้ว")
                Exit Sub
            End If
        End If
        If CLng(QtyrollOrder.Text) > CLng(QtyrollStore.Text) Then
            Informmessage("จำนวน(Roll) ที่สั่งทอ มากกว่าจำนวนที่มีในระบบ")
            Exit Sub
        End If
        If CDbl(WgtKgOrder.Text) > CDbl(WgtKgStore.Text) Then
            Informmessage("น้ำหนัก(KG) ที่สั่งทอ มากกว่าน้ำหนักที่มีในระบบ")
            Exit Sub
        End If

        Select Case Trim(Tbaddedit.Text)
            Case "เพิ่ม"
                If Tbknitcomno.Text = "NEW" Then
                    Dgvmas.Rows.Add()
                Else
                    Tdetailsknit.Rows.Add()
                End If
                'Tsbwsave.Visible = True

                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Mcomid").Value = Gscomid
                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Mclothid").Value = Trim(Tbclothid.Text)
                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Mclothno").Value = Trim(Tbclothno.Text)
                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Mftypename").Value = Trim(Tbtypename.Text)
                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Mfinwidth").Value = Trim(Tbfinwidth.Text)
                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Mqty").Value = CLng(QtyrollOrder.Text)
                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Mkg").Value = CDbl(WgtKgOrder.Text)
                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Mfinwgt").Value = Trim(Tbfinwgt.Text)
                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Mdozen").Value = Trim(Tbdozen.Text)

            Case "แก้ไข"
                'Tsbwsave.Visible = True

                Dgvmas.CurrentRow.Cells("Mcomid").Value = Gscomid
                Dgvmas.CurrentRow.Cells("Mclothid").Value = Trim(Tbclothid.Text)
                Dgvmas.CurrentRow.Cells("Mclothno").Value = Trim(Tbclothno.Text)
                Dgvmas.CurrentRow.Cells("Mftypename").Value = Trim(Tbtypename.Text)
                Dgvmas.CurrentRow.Cells("Mfinwidth").Value = Trim(Tbfinwidth.Text)
                Dgvmas.CurrentRow.Cells("Mqty").Value = CLng(QtyrollOrder.Text)
                Dgvmas.CurrentRow.Cells("Mkg").Value = CDbl(WgtKgOrder.Text)
                Dgvmas.CurrentRow.Cells("Mfinwgt").Value = Trim(Tbfinwgt.Text)
                Dgvmas.CurrentRow.Cells("Mdozen").Value = Trim(Tbdozen.Text)

        End Select
        Sumall()
        Btdcancel_Click(sender, e)
        Btfindfabtypeid.Focus()

    End Sub
    Private Sub Btdcancel_Click(sender As Object, e As EventArgs) Handles Btdcancel.Click
        Clrdetails()
    End Sub
    Private Sub Btdbadd_Click(sender As Object, e As EventArgs) Handles Btdbadd.Click
        'Btdcancel_Click(sender, e)
        SelectData()
        GroupPanel2.Visible = True
        Tbaddedit.Text = "เพิ่ม"
        Tbclothid.Text = ""
        Tbclothno.Text = ""
        Tbtypename.Text = ""
        Tbfinwidth.Text = ""
        'Tbqtyroll.Text = ""
        'Tbwgtkg.Text = ""
        'Tbwgtlbs.Text = ""
        Tbfinwgt.Text = ""
        Tbdozen.Text = ""
        Btdedit.Enabled = True
        Btddel.Enabled = True

        QtyrollOrder.Enabled = True
        WgtKgOrder.Enabled = True
        Tbfinwgt.Enabled = True
        Btdadd.Enabled = True
        Btdcancel.Enabled = True


    End Sub

    Private Sub Btdedit_Click(sender As Object, e As EventArgs) Handles Btdedit.Click
        SelectData()
        GroupPanel2.Visible = True

        If Dgvmas.RowCount = 0 Then
            Exit Sub
        End If
        If Validmas() = False Then
            Informmessage("กรุณาตรวจสอบข้อมูลในการสั่งทอให้ครบถ้วน")
            Exit Sub
        End If
        GroupPanel2.Visible = True
        Tbaddedit.Text = "แก้ไข"
        Tbclothid.Text = Trim(Dgvmas.CurrentRow.Cells("Mclothid").Value)
        Tbclothno.Text = Trim(Dgvmas.CurrentRow.Cells("Mclothno").Value)
        Tbtypename.Text = Trim(Dgvmas.CurrentRow.Cells("Mftypename").Value)
        Tbfinwidth.Text = Trim(Dgvmas.CurrentRow.Cells("Mfinwidth").Value)
        'Tbqtyroll.Text = Format(CLng(Dgvmas.CurrentRow.Cells("Mqty").Value), "###,###")
        'Tbwgtkg.Text = Format(CDbl(Dgvmas.CurrentRow.Cells("Mkg").Value), "###,###")
        QtyrollOrder.Text = Format(CLng(Dgvmas.CurrentRow.Cells("Mqty").Value), "###,###")
        WgtKgOrder.Text = Format(CDbl(Dgvmas.CurrentRow.Cells("Mkg").Value), "###,###.#0")

        Tbfinwgt.Text = Trim(Dgvmas.CurrentRow.Cells("Mfinwgt").Value)
        Tbdozen.Text = Trim(Dgvmas.CurrentRow.Cells("Mdozen").Value)
        Tbqtyroll.Focus()

        Binddetailsdlv()
        Show_Vdeliyarndet()
    End Sub
    Private Sub Btddel_Click(sender As Object, e As EventArgs) Handles Btddel.Click
        If Dgvmas.RowCount = 0 Then
            Exit Sub
        End If
        Dgvmas.Rows.Remove(Dgvmas.CurrentRow)
        Sumall()
        Btdcancel_Click(sender, e)
        Tsbwsave.Visible = True
    End Sub
    Private Sub Dgvmas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgvmas.CellClick
        If Dgvmas.RowCount = 0 Then
            Exit Sub
        End If
        Dgvmas.CurrentRow.Selected = True
    End Sub
    Private Sub Dgvmas_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Dgvmas.CellMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Me.Dgvmas.Rows.Count < 1 Then Exit Sub
            If e.RowIndex < 0 Then Exit Sub
            Dgvmas.CurrentCell = Dgvmas(4, e.RowIndex)
            Me.Dgvmas.Rows(e.RowIndex).Selected = True
            Editcontextdetmenu()
        End If
    End Sub
    Private Sub Ctdedit_Click(sender As Object, e As EventArgs) Handles Ctdedit.Click
        Btdedit_Click(sender, e)
    End Sub
    Private Sub Ctddel_Click(sender As Object, e As EventArgs) Handles Ctddel.Click
        Btddel_Click(sender, e)
    End Sub
    Private Sub Tbremark_KeyDown(sender As Object, e As KeyEventArgs) Handles Tbremark.KeyDown
        If (e.KeyCode = Keys.Enter) Then
        End If
    End Sub
    Private Sub Formknittingform_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Tbknitcomno.Text = "NEW" And Dgvmas.RowCount = 0 Then
            'My.Forms.Formmain.Panel1.Visible = True
            Exit Sub
        End If
        If Confirmcloseform("สั่งทอ") Then
            e.Cancel = False
            'My.Forms.Formmain.Panel1.Visible = True
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub Retdocprefix()
        Dim Tdocpre = New DataTable
        Tdocpre = SQLCommand("SELECT Docid,Prefix FROM Tdocprexp WHERE Comid = '" & Gscomid & "' AND 
                            Docid = (SELECT Docid FROM Tdocpredetxp WHERE Comid = '" & Gscomid & "' AND Mid = '" & Trim(Me.Tag) & "')")
        If Tdocpre.Rows.Count > 0 Then
            Tstbdocpreid.Text = Trim(Tdocpre.Rows(0)("Docid"))
            Tstbdocpre.Text = Trim(Tdocpre.Rows(0)("Prefix"))
        Else
            Tstbdocpreid.Text = ""
            Tstbdocpre.Text = ""
        End If
    End Sub
    Private Sub Bindinglist()
        Tlist = New DataTable
        Tlist = SQLCommand("SELECT '' AS Stat,* FROM Vknitcommas WHERE Comid = '" & Gscomid & "'")
        Dgvlist.DataSource = Tlist
        Bs = New BindingSource
        Bs.DataSource = Tlist
        BindingNavigator1.BindingSource = Bs
        FillGrid()
        ShowRecordDetail()
    End Sub
    Private Sub BindingYanlist()
        TYanlist = New DataTable
        TYanlist = SQLCommand($"SELECT *  FROM Tdeliyarndetxp
                            WHERE  Dlvno NOT IN (SELECT Dlvno FROM Tknittcomxp) AND Comid = '{Gscomid}'")
        YanList.DataSource = TYanlist
        'FillGrid()
        'ShowRecordDetail()
    End Sub
    Private Sub Bindmasterknit()
        Tmasterknit = New DataTable
        Tmasterknit = SQLCommand("SELECT * FROM Tknittcomxp 
                                WHERE Comid = '" & Gscomid & "' AND Knitcomno = '" & Trim(Tbknitcomno.Text) & "'")
        If Tmasterknit.Rows.Count > 0 Then
            Dtpknitcomdate.Value = Tmasterknit.Rows(0)("Knitcomdate")
            Dtprecdate.Value = Tmasterknit.Rows(0)("Rcdate")
            Tbdlvyarnno.Text = Trim(Tmasterknit.Rows(0)("Dlvno"))
            Tbremark.Text = Trim(Tmasterknit.Rows(0)("Dremark"))
            Binddetailsknit()
        End If
    End Sub

    Private Sub Bindmasterdlv()
        Tmasterdlv = New DataTable
        Tmasterdlv = SQLCommand("SELECT * FROM Vdeliyarnmas 
                                WHERE Comid = '" & Gscomid & "' AND Dlvno = '" & Trim(Tbdlvyarnno.Text) & "'")
        If Tmasterdlv.Rows.Count > 0 Then
            Tbknitid.Text = Trim(Tmasterdlv.Rows(0)("Knitid"))
            Tbknitname.Text = Trim(Tmasterdlv.Rows(0)("Knitdesc"))
            'Test
            Dtprecdate.Text = Trim(Tmasterdlv.Rows(0)("Dyarndate"))
            'Test

            Binddetailsdlv()
        End If
    End Sub
    Private Sub Binddetailsdlv()
        Tdetailsdlv = New DataTable
        'Tdetailsdlv = SQLCommand("SELECT * FROM Vdeliyarndet
        '                        WHERE Comid = '" & Gscomid & "' AND Dlvno = '" & Trim(Tbdlvyarnno.Text) & "'")
        Tdetailsdlv = SQLCommand("SELECT * FROM VdeliyarnCalculate
                                WHERE Comid = '" & Gscomid & "' AND Dlvno = '" & Trim(Tbdlvyarnno.Text) & "'")
        Dgvyarn.DataSource = Tdetailsdlv
        Sumdlvyarn()
        'Test
    End Sub
    Private Sub Binddetailsknit()
        Tdetailsknit = New DataTable
        Tdetailsknit = SQLCommand("SELECT * FROM Vknitcomdet
                                WHERE Comid = '" & Gscomid & "' AND Knitcomno = '" & Trim(Tbknitcomno.Text) & "'")
        Dgvmas.DataSource = Tdetailsknit
        Sumall()
    End Sub
    Private Sub Deldetails(Tdlvno As String)
        SQLCommand("DELETE FROM Tknittcomdetxp
                    WHERE Comid = '" & Gscomid & "' AND Knitcomno = '" & Tdlvno & "'")
    End Sub
    Private Sub Newdoc()
        Tbknitcomno.Text = Trim(Tstbdocpre.Text) & Genid()
        Insertmaster()
        SQLCommand("UPDATE Tdocprexp SET Lvalue = '" & Trim(Tbknitcomno.Text).Remove(0, 2) & "',Updusr = '" & Gsuserid & "',Uptype = 'E',Uptime = '" & Formatdatesave(Now) & "' 
                        WHERE  Comid = '" & Gscomid & "' AND Docid = '" & Tstbdocpreid.Text & "' AND Prefix = '" & Trim(Tstbdocpre.Text) & "'")
        Upddetails("A")
        If Gsusername = "SUPHATS" Then
        Else
            Insertlog(Gscomid, Gsusergroupid, Gsuserid, Gsusername, "F121", Trim(Tbknitcomno.Text), "A", "สร้างรายการ ใบสั่งทอ", Formatdatesave(Now), Computername, Usrproname)
        End If
    End Sub
    Private Sub Editdoc()
        If Tbknitcomno.Text = "NEW" Then
            Exit Sub
        End If
        Editmaster()
        Upddetails("E")
        If Gsusername = "SUPHATS" Then
        Else
            Insertlog(Gscomid, Gsusergroupid, Gsuserid, Gsusername, "F121", Trim(Tbknitcomno.Text), "E", "แก้ไขรายการ ใบสั่งทอ", Formatdatesave(Now), Computername, Usrproname)
        End If
    End Sub
    'Private Sub Insertmaster()
    '    SQLCommand("INSERT INTO Tknittcomxp(Comid,Knitcomdate,Knitcomno,Rcdate,Dlvno,
    '                Dremark,Updusr,Uptype,Uptime)
    '                VALUES('" & Gscomid & "','" & Formatshortdatesave(Dtpknitcomdate.Value) & "','" & Trim(Tbknitcomno.Text) & "','" & Formatshortdatesave(Dtprecdate.Value) & "','" & Trim(Tbdlvyarnno.Text) & "',
    '                '" & Trim(Tbremark.Text) & "','" & Gsuserid & "','A','" & Formatdatesave(Now) & "')")
    'End Sub
    'Private Sub Editmaster()
    '    SQLCommand("UPDATE Tknittcomxp SET Knitcomdate = '" & Formatshortdatesave(Dtpknitcomdate.Value) & "',Rcdate = '" & Formatshortdatesave(Dtprecdate.Value) & "',
    '                Dlvno = '" & Trim(Tbdlvyarnno.Text) & "',Dremark = '" & Trim(Tbremark.Text) & "',Updusr = '" & Gsuserid & "',Uptype = 'E',
    '                Uptime = '" & Formatdatesave(Now) & "'
    '                WHERE Comid = '" & Gscomid & "' AND Knitcomno = '" & Tbknitcomno.Text & "'")
    'End Sub
    Private Sub Insertmaster()
        SQLCommand("INSERT INTO Tknittcomxp(Comid,Knitcomdate,Knitcomno,Rcdate,Dlvno,
                    Dremark,WgtKgOrder,WgtKgStore,QtyrollOrder,QtyrollStore,Updusr,Uptype,Uptime)
                    VALUES('" & Gscomid & "','" & Formatshortdatesave(Dtpknitcomdate.Value) & "','" & Trim(Tbknitcomno.Text) & "','" & Formatshortdatesave(Dtprecdate.Value) & "','" & Trim(Tbdlvyarnno.Text) & "',
                    '" & Trim(Tbremark.Text) & "','" & WgtKgOrder.Text & "','" & ShowKgOrder.Text & "','" & QtyrollOrder.Text & "','" & ShowRollOrder.Text & "','" & Gsuserid & "','A','" & Formatdatesave(Now) & "')")
    End Sub
    Private Sub Editmaster()
        SQLCommand("UPDATE Tknittcomxp SET Knitcomdate = '" & Formatshortdatesave(Dtpknitcomdate.Value) & "',Rcdate = '" & Formatshortdatesave(Dtprecdate.Value) & "',
                    Dlvno = '" & Trim(Tbdlvyarnno.Text) & "',Dremark = '" & Trim(Tbremark.Text) & "',WgtKgOrder = '" & ShowKgOrder.Text & "',WgtKgStore = '" & WgtKgStore.Text & "',QtyrollOrder = '" & ShowRollOrder.Text & "',QtyrollStore = '" & QtyrollStore.Text & "',Updusr = '" & Gsuserid & "',Uptype = 'E',
                    Uptime = '" & Formatdatesave(Now) & "'
                    WHERE Comid = '" & Gscomid & "' AND Knitcomno = '" & Tbknitcomno.Text & "'")
    End Sub
    Private Sub Upddetails(Etype As String)
        Deldetails(Tbknitcomno.Text)
        Dim I As Integer
        ProgressBarX1.Value = 0
        Dim Frm As New Formwaitdialoque
        Frm.Show()
        Dim Tclothid, Tfinwgt, Tdozen As String
        Dim Tqtyroll As Long
        Dim Twgkg As Double

        For I = 0 To Dgvmas.RowCount - 1
            Tclothid = Trim(Dgvmas.Rows(I).Cells("Mclothid").Value)
            Tqtyroll = Dgvmas.Rows(I).Cells("Mqty").Value
            Twgkg = Dgvmas.Rows(I).Cells("Mkg").Value
            Tfinwgt = Trim(Dgvmas.Rows(I).Cells("Mfinwgt").Value)
            Tdozen = Trim(Dgvmas.Rows(I).Cells("Mdozen").Value)
            SQLCommand("INSERT INTO Tknittcomdetxp(Comid,Knitcomno,Clothid,Qtyroll,Wgtkg,
                        Finwgt,Dozen,Updusr,Uptype,Uptime)
                        VALUES ('" & Gscomid & "','" & Trim(Tbknitcomno.Text) & "','" & Tclothid & "'," & Tqtyroll & "," & Twgkg & ",
                                '" & Tfinwgt & "','" & Tdozen & "','" & Gsuserid & "','" & Etype & "','" & Formatdatesave(Now) & "')")
            ProgressBarX1.Value = ((I + 1) / Dgvmas.Rows.Count) * 100
            ProgressBarX1.Text = "Saving ... " & ProgressBarX1.Value & "%"
        Next
        Frm.Close()
        ProgressBarX1.Text = "Ready"
        ProgressBarX1.Value = 0
    End Sub
    Private Sub Searchlistbyoth(Sval As String)
        If Sval = "" Then
            Bindinglist()
            Exit Sub
        End If
        Tlist = SQLCommand("SELECT '' AS Stat,* FROM Vknitcommas
                                WHERE Comid = '" & Gscomid & "' AND  
                                (Knitcomno LIKE '%' + '" & Sval & "' + '%' OR Knitdesc LIKE '%' + '" & Sval & "' + '%' OR Dremark LIKE '%' + '" & Sval & "' + '%')")
        FillGrid()
        ShowRecordDetail()
    End Sub
    Private Sub SearchlistYan(Sval As String)
        If Sval = "" Then
            BindingYanlist()
            Exit Sub
        End If
        TYanlist = SQLCommand($"SELECT *  FROM Tdeliyarndetxp WHERE  Dlvno NOT IN (SELECT Dlvno FROM Tknittcomxp)
AND Comid = '{Gscomid}' AND ( Dlvno LIKE '%{Sval}%' OR Yarnid LIKE '%{Sval}%' OR Lotno LIKE '%{Sval}%' OR 
Nwkgpc LIKE '%{Sval}%'OR Nwppc LIKE '%{Sval}%' OR Gwkgpc LIKE '%{Sval}%' OR Gwppc LIKE '%{Sval}%' OR Nofc LIKE '%{Sval}%')")

        'SELECT *  FROM Tdeliyarndetxp
        'WHERE  Dlvno Not IN (SELECT Dlvno FROM Tknittcomxp) And Comid = '100'

        YanList.DataSource = TYanlist
        'FillGrid()
        'ShowRecordDetail()
    End Sub
    Private Sub Searchlistbydate()
        Tlist = SQLCommand("SELECT '' AS Stat,* FROM Vknitcommas
                                WHERE Comid = '" & Gscomid & "' AND 
                                (Knitcomdate BETWEEN '" & Formatshortdatesave(Dtplistfm.Value) & "' AND '" & Formatshortdatesave(Dtplistto.Value) & "')")
        FillGrid()
        ShowRecordDetail()
    End Sub
    Private Function Validmas() As Boolean
        Dim Valid As Boolean = False
        If Tbdlvyarnno.Text <> "" And Tbknitcomno.Text <> "" Then
            Valid = True
        End If
        Return Valid
    End Function
    Private Function Validdet() As Boolean
        Dim Valid As Boolean = False
        If Dgvmas.RowCount > 0 Then
            Valid = True
        End If
        Return Valid
    End Function
    Private Function Validinput() As Boolean
        Dim Valid As Boolean = False
        If Tbclothid.Text <> "" And Tbclothno.Text <> "" And Tbtypename.Text <> "" And Tbfinwidth.Text <> "" And Tbqtyroll.Text <> "" And Tbwgtkg.Text <> "" And Tbfinwgt.Text <> "" And Tbdozen.Text <> "" Then
            Valid = True
        End If
        Return Valid
    End Function
    Private Function Validnumber() As Boolean
        Dim Valid As Boolean = False
        If CLng(Tbqtyroll.Text) > 0 And CDbl(Tbwgtkg.Text) > 0 Then
            Valid = True
        End If
        Return Valid
    End Function
    Private Function Chkdupyarnidingrid() As Boolean
        Dim Dup As Boolean = False
        If Dgvmas.RowCount = 0 Then
            Dup = False
        Else
            Dim I As Integer
            For I = 0 To Dgvmas.RowCount - 1
                If Trim(Tbclothid.Text) = Trim(Dgvmas.Rows(I).Cells("Mclothid").Value) Then
                    Dup = True
                    Exit For
                End If
            Next
        End If
        Return Dup
    End Function
    Private Sub Sumdlvyarn()
        Dim Sumnwkg, Sumgwkg, Sumwgtkg As Double
        Dim Sumctn As Long
        Sumnwkg = 0.0
        Sumgwkg = 0.0
        Sumctn = 0
        Sumwgtkg = 0.0
        If Dgvyarn.RowCount = 0 Then
            Tbsumdlvnwkg.Text = Sumnwkg
            Tbsumdlvgwkg.Text = Sumgwkg
            Tbsumdlvctn.Text = Sumctn
            Tbsumdlvwgtkg.Text = Sumwgtkg
            Exit Sub
        End If
        ProgressBarX1.Value = 0
        Dim Frm As New Formwaitdialoque
        Frm.Show()
        Dim I As Integer
        For I = 0 To Dgvyarn.RowCount - 1
            Sumnwkg = Sumnwkg + Dgvyarn.Rows(I).Cells("Nwkgpc").Value
            Sumgwkg = Sumgwkg + Dgvyarn.Rows(I).Cells("Gwkgpc").Value
            Sumctn = Sumctn + Dgvyarn.Rows(I).Cells("Dynopack").Value
            Sumwgtkg = Sumwgtkg + Dgvyarn.Rows(I).Cells("Wgtkg").Value
            ProgressBarX1.Value = ((I + 1) / Dgvyarn.Rows.Count) * 100
            ProgressBarX1.Text = "Caculating sumyarn ... " & ProgressBarX1.Value & "%"
        Next
        Frm.Close()
        ProgressBarX1.Text = "Ready"
        ProgressBarX1.Value = 0
        Tbsumdlvnwkg.Text = Format(Sumnwkg, "###,####.#0")
        Tbsumdlvgwkg.Text = Format(Sumgwkg, "###,###.#0")
        Tbsumdlvctn.Text = Sumctn
        Tbsumdlvwgtkg.Text = Format(Sumwgtkg, "###,###.#0")
    End Sub
    Private Sub Sumall()
        Dim Sumkg As Double
        Dim Sumroll As Long
        Sumkg = 0.0
        Sumroll = 0
        If Dgvmas.RowCount = 0 Then
            Tstbsumroll.Text = Sumroll
            Tstbsumkg.Text = Sumkg
            Exit Sub
        End If
        ProgressBarX1.Value = 0
        Dim Frm As New Formwaitdialoque
        Frm.Show()
        Dim I As Integer
        For I = 0 To Dgvmas.RowCount - 1
            Sumroll = Sumroll + CLng(Dgvmas.Rows(I).Cells("Mqty").Value)
            Sumkg = Sumkg + CDbl(Dgvmas.Rows(I).Cells("Mkg").Value)
            ProgressBarX1.Value = ((I + 1) / Dgvmas.Rows.Count) * 100
            ProgressBarX1.Text = "Caculating sum(LB) ... " & ProgressBarX1.Value & "%"
        Next
        Frm.Close()
        ProgressBarX1.Text = "Ready"
        ProgressBarX1.Value = 0
        Tstbsumroll.Text = Sumroll
        Tstbsumkg.Text = Format(Sumkg, "###,###.#0")

        Frm.Close()
        ProgressBarX1.Text = "Ready"
        ProgressBarX1.Value = 0
    End Sub
    Private Function Genid() As String
        Dim Genbill As New DataTable
        Dim Sautoid, Tmpyear, Tmpmonth, Tmpday, Tmpsearch As String
        Tmpyear = Now.Year - 2000
        If Now.Month < 10 Then
            Tmpmonth = "0" & Now.Month
        Else
            Tmpmonth = Now.Month
        End If
        If Now.Day < 10 Then
            Tmpday = "0" & Now.Day
        Else
            Tmpday = Now.Day
        End If
        Tmpsearch = Tmpyear & Tmpmonth
        Sautoid = ""
        Genbill = SQLCommand("SELECT ISNULL(MAX(CAST(Lvalue as BIGINT)), 0) + 1 as Autoid FROM Tdocprexp 
                                WHERE LEFT(Lvalue,4) = '" & Tmpsearch & "' AND  Comid = '" & Gscomid & "' 
                                AND Docid = '" & Trim(Tstbdocpreid.Text) & "' AND Prefix = '" & Trim(Tstbdocpre.Text) & "'")
        If Genbill.Rows.Count > 0 Then
            Sautoid = Genbill.Rows(0)("Autoid")
        Else
            Sautoid = "1"
        End If
        If Sautoid = "1" Then
            Sautoid = Tmpsearch & "00001"
        Else
            Sautoid = Sautoid
        End If
        Return Sautoid
    End Function
    Private Sub Clrdgrid()
        Dgvmas.AutoGenerateColumns = False
        Dgvmas.DataSource = Nothing
        Dgvmas.Rows.Clear()
        Dgvyarn.AutoGenerateColumns = False
        Dgvyarn.DataSource = Nothing
        Dgvyarn.Rows.Clear()
    End Sub
    Private Sub Clrtxtbox()
        Tbdlvyarnno.Text = ""
        Tbknitid.Text = ""
        Tbknitname.Text = ""
        Tbknitcomno.Text = "NEW"
        Dtpknitcomdate.Value = Now
        Dtprecdate.Value = Now
        Tbsumdlvgwkg.Text = ""
        Tbsumdlvnwkg.Text = ""
        Tbsumdlvctn.Text = ""
        Tbsumdlvwgtkg.Text = ""
        Tstbsumroll.Text = ""
        Tstbsumkg.Text = ""

        Tsbwsave.Visible = False
        'GroupPanel2.Visible = True
        Tbaddedit.Text = "เพิ่ม"
        Tbclothid.Text = ""
        Tbclothno.Text = ""
        Tbtypename.Text = ""
        Tbfinwidth.Text = ""
        Tbqtyroll.Text = ""
        Tbwgtkg.Text = ""
        Tbfinwgt.Text = ""
        Tbdozen.Text = ""
        Tbremark.Text = ""
        Tbwgtlbs.Text = ""
        Label_dozen.Visible = False
        Tbdozen.Visible = False

    End Sub
    Private Sub Setauthorize()
        If Gswriau = False Then
            Btmsave.Visible = False
            Btdadd.Visible = False
            Btdedit.Visible = False
            Ctdedit.Visible = False
        End If
        If Gscreau = False Then
            Btdadd.Visible = False
        End If
        If Gsdelau = False Then
            Btmdel.Visible = False
            Btddel.Visible = False
            Ctddel.Visible = False
        End If
        If Gspriau = False Then
            Btmreports.Visible = False
        End If
    End Sub
    Private Function Checkfillbutton() As Boolean
        If Pagesize = 0 Then
            Informmessage("Set the Page Size, And Then click the ""Fill Grid"" button!")
            Checkfillbutton = False
        Else
            Checkfillbutton = True
        End If
    End Function
    Private Sub Befirst()
        Try
            If Not Checkfillbutton() Then Return
            If Currentpage = 1 Then
                Informmessage("You are at the First Page!")
                Return
            End If
            Currentpage = 1
            Recno = 0
            LoadPage()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Beprev()
        Try
            If Not Checkfillbutton() Then Return
            Currentpage = Currentpage - 1
            If Currentpage < 1 Then
                Informmessage("You are at the First Page!")
                Currentpage = 1
                Return
            Else
                Recno = Pagesize * (Currentpage - 1)
            End If
            LoadPage()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Benext()
        Try
            If Not Checkfillbutton() Then Return
            If Pagesize = 0 Then
                Informmessage("Set the Page Size, and then click the ""Fill Grid"" button!")
                Return
            End If
            Currentpage = Currentpage + 1
            If Currentpage > Pagecount Then
                Currentpage = Pagecount
                If Recno = Maxrec Then
                    Informmessage("You are at the Last Page!")
                    Return
                End If
            End If
            LoadPage()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Belast()
        Try
            If Not Checkfillbutton() Then Return
            If Recno = Maxrec Then
                Informmessage("You are at the Last Page!")
                Return
            End If
            Currentpage = Pagecount
            Recno = Pagesize * (Currentpage - 1)
            LoadPage()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub LoadPage()
        Dim I, Startrec, Endrec As Integer
        Dttemp = Tlist.Clone
        If Currentpage = Pagecount Then
            Endrec = Maxrec
        Else
            Endrec = Pagesize * Currentpage
        End If
        Startrec = Recno
        If Tlist.Rows.Count > 0 Then
            For I = Startrec To Endrec - 1
                Dttemp.ImportRow(Tlist.Rows(I))
                Recno = Recno + 1
            Next
        End If
        Dgvlist.DataSource = Dttemp
        DisplayPageInfo()
        ShowRecordDetail()
    End Sub
    'Private Sub Dgvyarn_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Dgvyarn.CellMouseClick
    '    If e.Button = Windows.Forms.MouseButtons.Right Then
    '        If Me.Dgvyarn.Rows.Count < 1 Then Exit Sub
    '        If e.RowIndex < 0 Then Exit Sub
    '        Dgvyarn.CurrentCell = Dgvyarn(3, e.RowIndex)
    '        Me.Dgvyarn.Rows(e.RowIndex).Selected = True
    '        Editcontextlistmenu2()
    '    End If
    'End Sub

    Private Sub FillGrid()
        Pagesize = (CInt(Dgvlist.Height) \ CInt(Dgvlist.RowTemplate.Height)) - 2
        Maxrec = Tlist.Rows.Count
        Pagecount = Maxrec \ Pagesize
        If (Maxrec Mod Pagesize) > 0 Then
            Pagecount = Pagecount + 1
        End If
        Currentpage = 1
        Recno = 0
        LoadPage()
    End Sub

    Private Sub DisplayPageInfo()
        Tbpage.Text = "หน้า " & Currentpage.ToString & "/" & Pagecount.ToString
    End Sub

    Private Sub OrderDyed_Click(sender As Object, e As EventArgs) Handles OrderDyed.Click
        CloseMaster()
        Btdcancel_Click(sender, e)
        Btmnew_Click(sender, e)
        Tbdlvyarnno.Text = Trim(YanList.CurrentRow.Cells("DlvnoDyed").Value)
        Bindmasterdlv()
        If Dgvyarn.RowCount > 0 Then
            Dgvyarn.Rows(0).Selected = False
        End If
        'Dgvyarn_CellClick(sender, e)
        'DlvnoDyed
    End Sub

    Private Sub YanKeyword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles YanKeyword.KeyPress
        e.Handled = (Asc(e.KeyChar) = 39)
    End Sub
    Private Sub YanKeyword_TextChanged(sender As Object, e As EventArgs) Handles YanKeyword.TextChanged
        YanSearch_Click(sender, e)
    End Sub

    Private Sub YanSearch_Click(sender As Object, e As EventArgs) Handles YanSearch.Click
        SearchlistYan(Trim(YanKeyword.Text))
    End Sub

    Private Sub BtrefreshYan_Click(sender As Object, e As EventArgs) Handles BtrefreshYan.Click
        BindingYanlist()
    End Sub

    Private Sub BindingNavigator1_RefreshItems(sender As Object, e As EventArgs) Handles BindingNavigator1.RefreshItems
        Tsbwsave.Visible = False
        Tbknitcomno.Enabled = False
        If Btmedit.Enabled = True Then
            'Bindmaster()
            Bindmasterknit()
            'Bindmasterdlv()
            'Binddetailsdlv()
        End If
    End Sub

    'Private Sub BindingNavigator1_RefreshItems(sender As Object, e As EventArgs) Handles BindingNavigator1.RefreshItems
    '    Tsbwsave.Visible = False
    '    'Tbdyedcomno.Enabled = False
    '    If Btmedit.Enabled = True Then
    '        Bindinglist()
    '    End If
    'End Sub

    Private Sub ShowRecordDetail()
        Tbrecord.Text = "แสดง " & (Dgvlist.RowCount) & " รายการ จาก " & Tlist.Rows.Count & " รายการ"
    End Sub
    Private Sub Editcontextdetmenu()
        Ctmmenudetgrid.Displayed = False
        Ctmmenudetgrid.PopupMenu(Control.MousePosition)
    End Sub
    Private Sub Editcontextlistmenu()
        Ctmmenugrid.Displayed = False
        Ctmmenugrid.PopupMenu(Control.MousePosition)
    End Sub
    Private Sub EditcontextYanList()
        CtmmenuYanList.Displayed = False
        CtmmenuYanList.PopupMenu(Control.MousePosition)
    End Sub
    'TEST
    'Private Sub Editcontextlistmenu2()
    '    Ctmmenugrid2.Displayed = False
    '    Ctmmenugrid2.PopupMenu(Control.MousePosition)
    'End Sub
    Private Sub Mainbuttonaddedit()
        Btmnew.Enabled = False
        Btmedit.Enabled = False
        Btmdel.Enabled = False
        Btmsave.Enabled = True
        Btmcancel.Enabled = True
        Btmreports.Enabled = False
        Enabledbutton()
        Dgvmas.Enabled = True
    End Sub
    Private Sub Enabledbutton()
        Btdedit.Enabled = True
        Btddel.Enabled = True
        Ctdedit.Enabled = True
        Ctddel.Enabled = True
        Btdbadd.Enabled = True
    End Sub
    Private Sub Mainbuttoncancel()
        Btmnew.Enabled = True
        Btmedit.Enabled = False
        Btmdel.Enabled = False
        Btmsave.Enabled = False
        Btmcancel.Enabled = False
        Btmreports.Enabled = False
        Disbaledbutton()
    End Sub
    Private Sub Disbaledbutton()
        Btdedit.Enabled = False
        Btddel.Enabled = False
        Ctdedit.Enabled = False
        Ctddel.Enabled = False
        Btdbadd.Enabled = False
    End Sub

    Private Function Findpoud(Tkg As String) As Double
        Dim Rpound As Double = 0.0
        If Tkg = "" Then
            Rpound = 0
        Else
            Rpound = CDbl(Tkg) * 2.2046
        End If
        Return Rpound
    End Function
    Private Sub Clrdetails()
        Tbaddedit.Text = "เพิ่ม"
        Tbclothid.Text = ""
        Tbclothno.Text = ""
        Tbtypename.Text = ""
        Tbfinwidth.Text = ""
        'Tbqtyroll.Text = ""
        'Tbwgtkg.Text = ""
        'Tbwgtlbs.Text = ""
        'QtyrollStore.Text = ""
        'WgtKgStore.Text = ""
        Tbfinwgt.Text = ""
        Tbdozen.Text = ""
        'Tbremark.Text = ""
        TbNwkgpc.Text = ""
        TbNofc.Text = ""

        ShowRollOrder.Text = ""
        ShowKgOrder.Text = ""
        QtyrollOrder.Text = ""
        WgtKgOrder.Text = ""
    End Sub

    Private Sub ShowText()
        '-------Test---
        QtyrollStore.Text = (Tbqtyroll.Text - ShowRollOrder.Text)
        WgtKgStore.Text = Convert.ToDouble(Tbwgtkg.Text - ShowKgOrder.Text).ToString("N2")
        QtyrollOrder.Text = "0"
        WgtKgOrder.Text = "0"
        '----------
    End Sub

    Private Sub SelectData()
        'MsgBox("Hello Word")
        Tbdozen.Text = "0"
        Tbfinwgt.Text = "-"
        Show_Vdeliyarndet()
    End Sub

    Private Sub QtyrollOrder_KeyDown(sender As Object, e As KeyEventArgs) Handles QtyrollOrder.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            WgtKgOrder.Focus()
        End If
    End Sub

    Private Sub WgtKgOrder_KeyDown(sender As Object, e As KeyEventArgs) Handles WgtKgOrder.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            Tbfinwgt.Focus()
        End If
    End Sub
    Private Sub Tbfinwgt_KeyDown(sender As Object, e As KeyEventArgs) Handles Tbfinwgt.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            If Tbdozen.Visible = True Then
                Tbdozen.Focus()
            Else
                Btdadd.Focus()
            End If
        End If
    End Sub
    Private Sub Tbdozen_KeyDown(sender As Object, e As KeyEventArgs) Handles Tbdozen.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            Btdadd.Focus()
        End If
    End Sub

End Class