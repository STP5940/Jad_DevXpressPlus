Imports System.ComponentModel
Imports Microsoft.Reporting.WinForms
Public Class Formknittingform
    Private Tmasterknit, Tdetailsknit, Tmasterdlv, Tdetailsdlv, Tlist, TYanlist, Dttemp, Vdeliyarndet, Tmaster, Trollperkg As DataTable
    Private Pagecount, Maxrec, Pagesize, Currentpage, Recno As Integer
    Private WithEvents Dtplistfm As New DateTimePicker
    Private WithEvents Dtplistto As New DateTimePicker
    Private Bs As BindingSource
    Private Sub Formknittingform_Load(sender As Object, e As EventArgs) Handles Me.Load
        Controls.Add(Dtplistfm)
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
        GroupPanel2.Visible = True
        ' Setauthorize() 'Suphat
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
        Createnew()
        TbfactoryName.Text = ""
        Tbdlvyarnno.Enabled = True
        Btfinddlvno.Enabled = False
        Dtprecdate.Enabled = True
        ButtonX1.Enabled = True
        Tbknitid.Text = "10000"
        Tbknitname.Text = "เซียงเฮง"
        TbfactoryName.Enabled = False
        TbfactoryName.Select()
        ToolStrip6.Visible = False
        Dgvyarn.Visible = False
        Paneloth.Visible = True
        Cbfromgsc.Checked = False
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
        ButtonX1.Enabled = True
        Dtpknitcomdate.Enabled = True
        Btfinddlvno.Enabled = True
        Listfactory.Enabled = True
        Btfindyarn.Enabled = True
        Tblbs.Enabled = True
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
        If Cbfromgsc.Checked = True Then
            SelectData()
        Else
        End If
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
        If WgtKgStore.Text > Tstbsumkg.Text OrElse WgtKgStore.Text < Tstbsumkg.Text Then
            Informmessage("น้ำหนักผ้าที่สั่งทอต้องเท่ากับเส้นด้ายที่ส่งไป")
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
        Tsbwsave.Visible = False
        Btmreports_Click(sender, e)
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
        ButtonX1.Enabled = False
        BindingNavigator1.Enabled = False
        Dtprecdate.Enabled = False
        Dtpknitcomdate.Enabled = False
        Dgvyarn.Enabled = False
        Btfinddlvno.Enabled = False
        GroupPanel2.Visible = False
        Tblbs.Enabled = False
        Listfactory.Enabled = False
        Btfindyarn.Enabled = False
        TbfactoryID.Text = ""
        Tbqtyroll.Text = ""
        Tbwgtkg.Text = ""
        Tbwgtlbs.Text = ""
        QtyrollStore.Text = ""
        WgtKgStore.Text = ""
        Tbyarnid.Text = ""
        Tbyarnname.Text = ""
        Tblbs.Text = ""
        Tbkg.Text = ""
    End Sub
    Private Sub OpenMaster()
        Listfactory.Enabled = True
        Btfindyarn.Enabled = True
        Tblbs.Enabled = True
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
        Binddetailsknit()
        Dim Frm As New Formknitingfrmrpt
        Frm.ReportViewer1.Reset()
        Frm.Tbdate.Text = Format(Dtpknitcomdate.Value, "dd/MM/yyyy")
        Frm.Tbto.Text = Trim(Tbknitname.Text)
        Frm.Tbknitcomno.Text = Trim(Tbknitcomno.Text)
        Frm.Tbredate.Text = Format(Dtprecdate.Value, "dd/MM/yyyy")
        Frm.Tbremark.Text = Trim(Tbremark.Text)
        Frm.TextBox1.Text = Trim(TbfactoryName.Text)
        If Gsexpau = False Then
            Frm.ReportViewer1.ShowExportButton = False
        End If
        If Gspriau = False Then
            Frm.ReportViewer1.ShowPrintButton = False
        End If
        Dim Rds, Rds1 As New ReportDataSource()
        Rds.Name = "DataSet1"
        If Cbfromgsc.Checked = True Then
            Binddetailsdlv()
            Rds.Value = Tdetailsdlv
        Else
            Dim Tmpmasdlv As New DataTable
            Tmpmasdlv = SQLCommand("SELECT '' AS Custname,dbo.Tknittcomxp.yarnid,dbo.Tyarnxp.Yarndesc, '' AS Lotno,0 as Nwkgpc,0 as Nwppc,0 as Gwkgpc,
                                    0 AS Gwppc,0 AS Nofc,'' AS Sremark, dbo.Tknittcomxp.Dlvno,dbo.Tknittcomxp.Dlvlbs, dbo.Tknittcomxp.Dlvkg
                                    FROM dbo.Tknittcomxp LEFT OUTER JOIN
                                    dbo.Tyarnxp ON dbo.Tknittcomxp.Yarnid = dbo.Tyarnxp.Yarnid
                                    WHERE dbo.Tknittcomxp.Dlvno = '" & Trim(Tbdlvyarnno.Text) & "'")
            Rds.Value = Tmpmasdlv
        End If
        Frm.ReportViewer1.LocalReport.DataSources.Add(Rds)
        Rds1.Name = "DataSet2"
        Rds1.Value = Tdetailsknit
        Frm.ReportViewer1.LocalReport.DataSources.Add(Rds1)
        'Showform(Frm) 'Suphat
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
        Clrdetails()
        TabControl1.SelectedTabIndex = 2
        Tbknitcomno.Text = Trim(Dgvlist.CurrentRow.Cells("Knitcomno").Value)
        Tbknitcomno.Enabled = False
        Btfinddlvno.Enabled = False
        Dtpknitcomdate.Enabled = False
        Tbknitcomno.DataBindings.Clear()
        Tbknitcomno.Text = ""
        Bs.Position = Bs.Find("Knitcomno", Trim(Dgvlist.CurrentRow.Cells("Knitcomno").Value))
        Tbknitcomno.DataBindings.Add("Text", Bs, "Knitcomno")
        Tbknitcomno.Enabled = False
        Bindmasterknit()
        If Cbfromgsc.Checked = True Then
            Bindmasterdlv()
        End If
        Binddetailsdlv()
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
    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Dim Frm As New Formknittinglist
        Showdiaformcenter(Frm, Me)
        If Frm.Tbcancel.Text = "C" Then
            Exit Sub
        End If
        Tbknitid.Text = Frm.Dgvmas.CurrentRow.Cells("Mid").Value
        Tbknitname.Text = Frm.Dgvmas.CurrentRow.Cells("Mname").Value
    End Sub
    Private Sub Btfindyarn_Click(sender As Object, e As EventArgs) Handles Btfindyarn.Click
        Dim Frm As New Formyarnlist
        Showdiaformcenter(Frm, Me)
        If Frm.Tbcancel.Text = "C" Then
            Exit Sub
        End If
        Tbyarnid.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("Mid").Value)
        Tbyarnname.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("Mname").Value)
        Tblbs.Select()
    End Sub
    Private Sub Dgvyarn_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgvyarn.CellClick
        If Dgvyarn.RowCount = 0 Then
            Exit Sub
        End If
        Dgvyarn.CurrentRow.Selected = True
    End Sub
    Private Sub Btfindfabtypeid_Click(sender As Object, e As EventArgs) Handles Btfindfabtypeid.Click
        If Validmas() = False Then
            Informmessage("กรุณากรอกข้อมูลใบส่งด้าย ")
            Exit Sub
        End If
        Dim Frm As New FormfabrictypelistForknitt
        If Cbfromgsc.Checked = True Then
            Frm.Dyarnid.Text = Trim(Dgvyarn.Rows(0).Cells("Dyarnid").Value)
        Else
            If Tbyarnid.Text = "" Then
                Informmessage("กรุณาเลือกเส้นด้าย")
                Exit Sub
            End If
            Frm.Dyarnid.Text = Tbyarnid.Text
        End If
        Showdiaformcenter(Frm, Me)
        If Frm.Tbcancel.Text = "C" Then
            Exit Sub
        End If
        Tbclothid.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("Mid").Value)
        Tbclothno.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("Mname").Value)
        Tbtypename.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("Ftype").Value)
        Tbfinwidth.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("Fwidth").Value)
        QtyrollOrder.Focus()
        If Trim(Frm.Dgvmas.CurrentRow.Cells("Havedoz").Value) = True Then
            Tbdozen.Text = ""
            Tbdozen.Visible = True
            Label_dozen.Visible = True
        Else
            Tbdozen.Text = "0"
            Tbdozen.Visible = False
            Label_dozen.Visible = False
            Exit Sub
        End If
    End Sub
    Private Sub Show_Vdeliyarndet()
        Dim Kgproll As Double
        Trollperkg = New DataTable
        Trollperkg = SQLCommand("SELECT Rate FROM Twgtperkgxp 
                                WHERE Comid = '" & Gscomid & "'")
        If Trollperkg.Rows.Count > 0 Then
            Kgproll = Trollperkg.Rows(0)("Rate")
        Else
            Kgproll = 20
        End If
        If Cbfromgsc.Checked = True Then
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
                Tbqtyroll.Text = Format(CLng(Tbwgtkg.Text / Kgproll), "###,##0")
                If Tbqtyroll.Text = 0 Then
                    Tbqtyroll.Text = 1
                End If
                Tbwgtlbs.Text = Convert.ToDouble(Tbwgtkg.Text * 2.2046).ToString("N2")
                ShowRollOrder.Text = Tstbsumroll.Text
                ShowKgOrder.Text = Tstbsumkg.Text
                QtyrollStore.Text = Format(CLng(Tbwgtkg.Text / Kgproll), "###,##0")
                If QtyrollStore.Text = 0 Then
                    QtyrollStore.Text = 1
                End If
                WgtKgStore.Text = Convert.ToDouble(Tbsumdlvwgtkg.Text).ToString("N2")
                QtyrollStore.Text = Format(CLng(WgtKgStore.Text / Kgproll), "###,##0")
            End If
        Else
            If Dgvmas.RowCount <= 0 Then
                Exit Sub
            End If
            QtyrollStore.Text = Format(CLng(Tbkg.Text / Kgproll), "###,##0")
            WgtKgStore.Text = Convert.ToDouble(Tbkg.Text).ToString("N2")
        End If
    End Sub
    Private Sub Btdadd_Click(sender As Object, e As EventArgs) Handles Btdadd.Click
        If Validinput() = False Then
            Informmessage("กรุณาเลือกเบอร์ผ้าที่ต้องการ")
            Btfindfabtypeid.PerformClick()
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
        If CDbl(WgtKgOrder.Text) > CDbl(WgtKgStore.Text) Then
            Informmessage("น้ำหนักผ้าที่สั่งทอมากกว่าเส้นด้ายที่ส่งไป")
            WgtKgOrder.Focus()
            Exit Sub
        End If
        If Tbfinwgt.Text = "" Then
            Informmessage("กรุณาใส่ข้อมูล Finished Weigth")
            Tbfinwgt.Focus()
            Exit Sub
        End If
        If Tbdozen.Text = "" Then
            Informmessage("กรุณาใส่ข้อมูล Dozen")
            Tbdozen.Focus()
            Exit Sub
        End If
        If Tbaddedit.Text = "เพิ่ม" Then
            If Chkdupyarnidingrid() = True Then
                Informmessage("ผ้าเบอร์นี้ มีแล้ว")
                Exit Sub
            End If
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
                If Label_dozen.Visible = True Then
                    Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Havedoz").Value = True
                Else
                    Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Havedoz").Value = False
                End If
            Case "แก้ไข"
                Tsbwsave.Visible = True
                Dgvmas.CurrentRow.Cells("Mcomid").Value = Gscomid
                Dgvmas.CurrentRow.Cells("Mclothid").Value = Trim(Tbclothid.Text)
                Dgvmas.CurrentRow.Cells("Mclothno").Value = Trim(Tbclothno.Text)
                Dgvmas.CurrentRow.Cells("Mftypename").Value = Trim(Tbtypename.Text)
                Dgvmas.CurrentRow.Cells("Mfinwidth").Value = Trim(Tbfinwidth.Text)
                Dgvmas.CurrentRow.Cells("Mqty").Value = CLng(QtyrollOrder.Text)
                Dgvmas.CurrentRow.Cells("Mkg").Value = CDbl(WgtKgOrder.Text)
                Dgvmas.CurrentRow.Cells("Mfinwgt").Value = Trim(Tbfinwgt.Text)
                Dgvmas.CurrentRow.Cells("Mdozen").Value = Trim(Tbdozen.Text)
                If Label_dozen.Visible = True Then
                    Dgvmas.CurrentRow.Cells("Havedoz").Value = True
                Else
                    Dgvmas.CurrentRow.Cells("Havedoz").Value = False
                End If
        End Select
        Sumall()
        Btdcancel_Click(sender, e)
        Btfindfabtypeid.Focus()
    End Sub
    Private Sub Btdcancel_Click(sender As Object, e As EventArgs) Handles Btdcancel.Click
        Clrdetails()
    End Sub
    Private Sub Btdbadd_Click(sender As Object, e As EventArgs) Handles Btdbadd.Click
        Tblbs_TextChanged(sender, e)
        Tbkg_KeyDown(sender, e)
        'Btfindfabtypeid.Focus()
        SelectData()
        GroupPanel2.Visible = True
        Tbaddedit.Text = "เพิ่ม"
        Tbclothid.Text = ""
        Tbclothno.Text = ""
        Tbtypename.Text = ""
        Tbfinwidth.Text = ""
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
        If Dgvmas.CurrentRow.Cells("Havedoz").Value = True Then
            Tbdozen.Text = ""
            Tbdozen.Visible = True
            Label_dozen.Visible = True
        Else
            Tbdozen.Text = "0"
            Tbdozen.Visible = False
            Label_dozen.Visible = False
        End If
        GroupPanel2.Visible = True
        Tbaddedit.Text = "แก้ไข"
        Tbclothid.Text = Trim(Dgvmas.CurrentRow.Cells("Mclothid").Value)
        Tbclothno.Text = Trim(Dgvmas.CurrentRow.Cells("Mclothno").Value)
        Tbtypename.Text = Trim(Dgvmas.CurrentRow.Cells("Mftypename").Value)
        Tbfinwidth.Text = Trim(Dgvmas.CurrentRow.Cells("Mfinwidth").Value)
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
            'My.Forms.Formmain.Panel1.Visible = True ' Suphat
            Exit Sub
        End If
        If Confirmcloseform("สั่งทอ") Then
            e.Cancel = False
            ' My.Forms.Formmain.Panel1.Visible = True  'Suphat
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
    End Sub
    Private Sub Bindmasterknit()
        Tmasterknit = New DataTable
        Tmasterknit = SQLCommand("SELECT * FROM Tknittcomxp 
                                WHERE Comid = '" & Gscomid & "' AND Knitcomno = '" & Trim(Tbknitcomno.Text) & "'")
        If Tmasterknit.Rows.Count > 0 Then
            If IsDBNull(Tmasterknit.Rows(0)("Yarnfrom")) Then
                TbfactoryName.Text = "GSC"
            Else
                TbfactoryID.Text = Trim(Tmasterknit.Rows(0)("Yarnfactid"))
                TbfactoryName.Text = Trim(Tmasterknit.Rows(0)("Yarnfrom"))
                Tbknitid.Text = Trim(Tmasterknit.Rows(0)("Knitid"))
            End If
            Dtpknitcomdate.Value = Tmasterknit.Rows(0)("Knitcomdate")
            Dtprecdate.Value = Tmasterknit.Rows(0)("Rcdate")
            Tbdlvyarnno.Text = Trim(Tmasterknit.Rows(0)("Dlvno"))
            Tbremark.Text = Trim(Tmasterknit.Rows(0)("Dremark"))
            If TbfactoryName.Text = "GSC" Then
                Cbfromgsc.Checked = True
                Bindmasterdlv()
                Btfinddlvno.Enabled = False
                Tbdlvyarnno.Enabled = False
                TbfactoryName.Enabled = False
                ToolStrip6.Visible = True
                Dgvyarn.Visible = True
                Paneloth.Visible = False
            Else
                Cbfromgsc.Checked = False
                If IsDBNull(Tmasterknit.Rows(0)("Yarnid")) Then
                    Tbyarnid.Text = ""
                Else
                    Tbyarnid.Text = Trim(Tmasterknit.Rows(0)("Yarnid"))
                End If
                Findknithouse()
                Findyarn()
                Tblbs.Text = Format(Tmasterknit.Rows(0)("Dlvlbs"), "###,###.#0")
                Tbkg.Text = Format(Tmasterknit.Rows(0)("Dlvkg"), "###,###.#0")
                Paneloth.Visible = True
                ToolStrip6.Visible = False
                Dgvyarn.Visible = False
            End If
            Binddetailsknit()
        End If
    End Sub
    Private Sub Findyarn()
        Dim Tfyarnd As New DataTable
        Tfyarnd = SQLCommand("SELECT Yarnid,Yarndesc FROM Tyarnxp
                                WHERE Yarnid = '" & Trim(Tbyarnid.Text) & "'")
        If Tfyarnd.Rows.Count > 0 Then
            Tbyarnname.Text = Trim(Tfyarnd.Rows(0)("Yarndesc"))
        Else
            Tbyarnname.Text = ""
        End If
    End Sub
    Private Sub Findknithouse()
        Dim Tknitt As New DataTable
        Tknitt = SQLCommand("SELECT Knitid,Knitdesc FROM Tknitingxp
                                WHERE Comid = '" & Gscomid & "' AND Knitid = '" & Trim(Tbknitid.Text) & "'")
        If Tknitt.Rows.Count > 0 Then
            Tbknitname.Text = Trim(Tknitt.Rows(0)("Knitdesc"))
        Else
            Tbknitid.Text = Trim(Tmasterknit.Rows(0)("Knitid"))
            Tbknitname.Text = "เซียงเฮง"
        End If
    End Sub
    Private Sub Bindmasterdlv()
        Tmasterdlv = New DataTable
        Tmasterdlv = SQLCommand("SELECT * FROM Vdeliyarnmas 
                                WHERE Comid = '" & Gscomid & "' AND Dlvno = '" & Trim(Tbdlvyarnno.Text) & "'")
        If Tmasterdlv.Rows.Count > 0 Then
            Tbknitid.Text = Trim(Tmasterdlv.Rows(0)("Knitid"))
            Tbknitname.Text = Trim(Tmasterdlv.Rows(0)("Knitdesc"))
            Dtprecdate.Text = Trim(Tmasterdlv.Rows(0)("Dyarndate"))
            Binddetailsdlv()
        End If
    End Sub
    Private Sub Binddetailsdlv()
        Tdetailsdlv = New DataTable
        Tdetailsdlv = SQLCommand("SELECT *,0 AS Dlvlbs, 0 AS Dlvkg FROM VdeliyarnCalculate
                                WHERE Comid = '" & Gscomid & "' AND Dlvno = '" & Trim(Tbdlvyarnno.Text) & "'")
        Dgvyarn.DataSource = Tdetailsdlv
        Sumdlvyarn()
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
    Private Sub Insertmaster()
        Dim Tyarnid As String
        Dim Sumlbs, Sumkg As Double
        Sumlbs = 0
        Sumkg = 0
        If Cbfromgsc.Checked = True Then
            Sumkg = CDbl(Tbsumdlvwgtkg.Text)
            Sumlbs = CDbl(Tbsumdlvwgtkg.Text) * 2.20462
            Tyarnid = ""
        Else
            Sumkg = CDbl(Tbkg.Text)
            Sumlbs = CDbl(Tblbs.Text)
            Tyarnid = Tbyarnid.Text
        End If
        SQLCommand("INSERT INTO Tknittcomxp(Comid,Knitcomdate,Knitcomno,Rcdate,Dlvno,
                    Dremark,WgtKgOrder,WgtKgStore,QtyrollOrder,QtyrollStore,
                    Updusr,Uptype,Uptime,Knitid,Yarnfactid,Yarnfrom,
                    Dlvlbs,Dlvkg,Yarnid)
                    VALUES('" & Gscomid & "','" & Formatshortdatesave(Dtpknitcomdate.Value) & "','" & Trim(Tbknitcomno.Text) & "','" & Formatshortdatesave(Dtprecdate.Value) & "','" & Trim(Tbdlvyarnno.Text) & "',
                    '" & Trim(Tbremark.Text) & "'," & CDbl(Tstbsumkg.Text) & ",0," & CDbl(Tstbsumroll.Text) & ",0,
                    '" & Gsuserid & "','A','" & Formatdatesave(Now) & "','" & Trim(Tbknitid.Text) & "','" & TbfactoryID.Text & "','" & Trim(TbfactoryName.Text) & "',
                    " & Sumlbs & "," & Sumkg & ",'" & Tyarnid & "')")
    End Sub
    Private Sub Editmaster()
        Dim Tyarnid As String
        Dim Sumlbs, Sumkg As Double
        Sumlbs = 0
        Sumkg = 0
        If Cbfromgsc.Checked = True Then
            Sumkg = CDbl(Tbsumdlvwgtkg.Text)
            Sumlbs = CDbl(Tbsumdlvwgtkg.Text) * 2.20462
            Tyarnid = ""
            Tblbs.Text = 0
            Tbkg.Text = 0

        Else
            Sumkg = CDbl(Tbkg.Text)
            Sumlbs = CDbl(Tblbs.Text)
            Tyarnid = Tbyarnid.Text
        End If
        SQLCommand("UPDATE Tknittcomxp SET Knitcomdate = '" & Formatshortdatesave(Dtpknitcomdate.Value) & "',Rcdate = '" & Formatshortdatesave(Dtprecdate.Value) & "',
                    Dlvno = '" & Trim(Tbdlvyarnno.Text) & "',Dremark = '" & Trim(Tbremark.Text) & "',WgtKgOrder = " & CDbl(Tstbsumkg.Text) & ",WgtKgStore = 0,
                    QtyrollOrder = " & CDbl(Tstbsumroll.Text) & ",QtyrollStore = 0,Updusr = '" & Gsuserid & "',Uptype = 'E',Uptime = '" & Formatdatesave(Now) & "',
                    Knitid = '" & Trim(Tbknitid.Text) & "',Yarnfactid = '" & TbfactoryID.Text & "',Yarnfrom = '" & TbfactoryName.Text & "',Dlvlbs = " & CDbl(Tblbs.Text) & ",Dlvkg = " & CDbl(Tbkg.Text) & ",Yarnid = '" & Tyarnid & "'
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
            SQLCommand("INSERT INTO Tknittcomdetxp(Comid,Knitcomno,Ord,Clothid,Qtyroll,Wgtkg,
                        Finwgt,Dozen,Updusr,Uptype,Uptime)
                        VALUES ('" & Gscomid & "','" & Trim(Tbknitcomno.Text) & "'," & I + 1 & ",'" & Tclothid & "'," & Tqtyroll & "," & Twgkg & ",
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
        YanList.DataSource = TYanlist
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
        If Tbdlvyarnno.Text <> "" And Tbknitcomno.Text <> "" And TbfactoryName.Text <> "" Then
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
        If Tbclothid.Text <> "" And Tbclothno.Text <> "" And Tbtypename.Text <> "" And Tbfinwidth.Text <> "" Then
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
        Tbaddedit.Text = "เพิ่ม"
        TbfactoryName.Text = ""
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
        Createnew()
        Tbdlvyarnno.Text = Trim(YanList.CurrentRow.Cells("DlvnoDyed").Value)
        Bindmasterdlv()
        If Dgvyarn.RowCount > 0 Then
            Dgvyarn.Rows(0).Selected = False
        End If
        Btfinddlvno.Enabled = False
        Tbdlvyarnno.Enabled = False
        TbfactoryName.Text = "GSC"
        TbfactoryName.Enabled = False
        TbfactoryID.Text = "10000"
        TbfactoryID.Enabled = False
        ToolStrip6.Visible = True
        Dgvyarn.Visible = True
        Paneloth.Visible = False
        Cbfromgsc.Checked = True
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
            Bindmasterknit()
        End If
    End Sub
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
    Private Sub Tblbs_KeyDown(sender As Object, e As KeyEventArgs) Handles Tblbs.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Tblbs.Text = "" Then
                Tbkg.Text = "0"
                Exit Sub
            End If
            Tbkg.Text = Format(Findkg(Tblbs.Text), "###,###.#0")
        End If
    End Sub

    'Private Sub Tblbs_LostFocus(sender As Object, e As EventArgs) Handles Tblbs.LostFocus

    'End Sub

    Private Sub Tblbs_TextChanged(sender As Object, e As EventArgs) Handles Tblbs.LostFocus
        If Tblbs.Text <> "" Then
            Tbkg.Text = Format(Findkg(Tblbs.Text), "###,###.#0")
        Else
            Tbkg.Text = 0
        End If
    End Sub
    Private Sub Tbkg_KeyDown(sender As Object, e As EventArgs) Handles Tbkg.LostFocus
        If Tbkg.Text <> "" Then
            Tblbs.Text = Format(FindRekg(Tbkg.Text), "###,###.#0")
        Else
            Tblbs.Text = 0
        End If
    End Sub
    Private Sub Tbkg_TextChanged(sender As Object, e As EventArgs) Handles Tbkg.TextChanged
        If Tbkg.Text <> "" Then
            SelectData()
        End If
    End Sub

    Private Sub Listfactory_Click(sender As Object, e As EventArgs) Handles Listfactory.Click
        Dim Frm As New Formfactorylist
        Showdiaformcenter(Frm, Me)
        If Frm.Tbcancel.Text = "C" Then
            Exit Sub
        End If
        TbfactoryID.Text = Frm.Dgvmas.CurrentRow.Cells("factoryID").Value
        TbfactoryName.Text = Frm.Dgvmas.CurrentRow.Cells("factoryName").Value
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
        Tbdlvyarnno.Enabled = False
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
        Tbfinwgt.Text = ""
        Tbdozen.Text = ""
        TbNwkgpc.Text = ""
        TbNofc.Text = ""
        ShowRollOrder.Text = ""
        ShowKgOrder.Text = ""
        QtyrollOrder.Text = ""
        WgtKgOrder.Text = ""
    End Sub

    Private Sub ShowText()
        QtyrollStore.Text = (Tbqtyroll.Text - ShowRollOrder.Text)
        WgtKgStore.Text = Convert.ToDouble(Tbwgtkg.Text - ShowKgOrder.Text).ToString("N2")
        QtyrollOrder.Text = "0"
        WgtKgOrder.Text = "0"
    End Sub
    Private Sub SelectData()
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
    Private Sub Createnew()
        Clrdgrid()
        Clrtxtbox()
        OpenMaster()
        TabControl1.SelectedTabIndex = 2
        BindingNavigator1.Enabled = False
        Mainbuttonaddedit()
        Tbremark.Enabled = True
        Dgvmas.Enabled = True
    End Sub
    Private Function Findkg(Tpound As String) As Double
        Dim Tkg As Double = 0.0
        If Tpound = "" Then
            Tkg = 0
        Else
            Tkg = CDbl(Tpound) * 0.453592
        End If
        Return Tkg
    End Function

    Private Function FindRekg(Tbkg As String) As Double
        Dim Tpound As Double = 0.0
        If Tbkg = "" Then
            Tpound = 0
        Else
            Tpound = CDbl(Tbkg) / 0.453592
        End If
        Return Tpound
    End Function
End Class