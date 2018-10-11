Imports System.ComponentModel
Imports Microsoft.Reporting.WinForms
Public Class Formbooking
    Private Tmaster, Tdetails, Tlist, Dttemp As DataTable
    Private Pagecount, Maxrec, Pagesize, Currentpage, Recno As Integer
    Private WithEvents Dtplistfm As New DateTimePicker
    Private WithEvents Dtplistto As New DateTimePicker
    Private Bs As BindingSource
    Private Sub Formbooking_Load(sender As Object, e As EventArgs) Handles Me.Load
        Controls.Add(Dtplistfm)
        Dtplistfm.Value = Now
        Dtplistfm.Width = 130
        Me.ToolStrip4.Items.Insert(5, New ToolStripControlHost(Dtplistfm))
        Me.ToolStrip4.Items(5).Alignment = ToolStripItemAlignment.Right
        Controls.Add(Dtplistto)
        Dtplistto.Value = Now
        Dtplistto.Width = 130
        Me.ToolStrip4.Items.Insert(4, New ToolStripControlHost(Dtplistto))
        Me.ToolStrip4.Items(4).Alignment = ToolStripItemAlignment.Right
        Dtplistfm.Visible = False
        Dtplistto.Visible = False
        Tbmycom.Text = Trim(Gscomname)
    End Sub
    Private Sub Formbooking_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dgvlist.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        Dgvlist.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        Dgvmas.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        Dgvmas.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        ' Setauthorize()
        Bindinglist()
    End Sub
    Private Sub Btmnew_Click(sender As Object, e As EventArgs) Handles Btmnew.Click
        Clrmaster()
        Clrdetails()
        Clrdgrid()
        TabControl1.SelectedTabIndex = 1
        BindingNavigator1.Enabled = False
        Mainbuttonaddedit()
    End Sub
    Private Sub Btmedit_Click(sender As Object, e As EventArgs) Handles Btmedit.Click
        If TabControl1.SelectedTabIndex = 0 Then
            Exit Sub
        End If
        If Cbreceive.Checked = True Then
            If Confirmedit() = True Then
                BindingNavigator1.Enabled = False
                Mainbuttonaddedit()
            End If
        Else
            BindingNavigator1.Enabled = False
            Mainbuttonaddedit()
        End If
    End Sub
    Private Sub Btmdel_Click(sender As Object, e As EventArgs) Handles Btmdel.Click
        If TabControl1.SelectedTabIndex = 0 Then
            Exit Sub
        End If
        If Tbdlvno.Enabled = True Then
            Exit Sub
        End If
        If Trim(Tbdlvno.Text) = "" Then
            Exit Sub
        End If
        If Chkdocreinstk() = True Then
            Informmessage("ไม่สามารถลบได้ เนื่องจากมีการรับสินค้าแล้ว")
            Exit Sub
        End If
        If Confirmdelete() = True Then
            Deldetails(Trim(Tbdlvno.Text))
            SQLCommand("UPDATE Tbookingxp SET Sstatus = '0' WHERE Comid = '" & Gscomid & "' AND Dlvno = '" & Trim(Tbdlvno.Text) & "'")
            Insertlog(Gscomid, Gsusergroupid, Gsuserid, Gsusername, "F129", Trim(Tbdlvno.Text), "D", "ลบรายการ Booking ด้าย", Formatdatesave(Now), Computername, Usrproname)
            Clrmaster()
            Clrdetails()
            Clrdgrid()
            Bindinglist()
            TabControl1.SelectedTabIndex = 0
            BindingNavigator1.Enabled = False
            Mainbuttoncancel()
        End If
    End Sub
    Private Sub Btmsave_Click(sender As Object, e As EventArgs) Handles Btmsave.Click
        If TabControl1.SelectedTabIndex = 0 Then
            Exit Sub
        End If
        If Tbdlvno.Enabled = True Then
            If Chkdupdlv() = True Then
                Informmessage("เลขที่ใบส่งด้ายนี้มีในระบบแล้ว")
                Exit Sub
            End If
        End If
        If Validmas() = False Then
            Informmessage("กรุณาตรวจสอบข้อมูล Shipping,Supplier และเลขที่ใบส่งให้ครบถ้วน")
            Exit Sub
        End If
        If Validdet() = False Then
            Informmessage("กรุณาตรวจสอบรายละเอียดในการส่งให้ครบถ้วน")
            Exit Sub
        End If
        If Tbdlvno.Enabled = True Then
            Newdoc()
        Else
            Editdoc()
        End If
        Tsbwsave.Visible = False
        Btmreports_Click(sender, e)
        Clrmaster()
        Clrdetails()
        Clrdgrid()
        TabControl1.SelectedTabIndex = 0
        BindingNavigator1.Enabled = False
        Mainbuttoncancel()
    End Sub
    Private Sub Btmcancel_Click(sender As Object, e As EventArgs) Handles Btmcancel.Click
        Clrmaster()
        Clrdetails()
        Clrdgrid()
        TabControl1.SelectedTabIndex = 0
        BindingNavigator1.Enabled = False
        Mainbuttoncancel()
    End Sub
    Private Sub Btmreports_Click(sender As Object, e As EventArgs) Handles Btmreports.Click
        If TabControl1.SelectedTabIndex = 0 Then
            Exit Sub
        End If
        If Gspriau = False Then
            Exit Sub
        End If
        Clrmaster()
        Clrdetails()
        Clrdgrid()
        Bindinglist()
        BindingNavigator1.Enabled = False
        Mainbuttoncancel()
        TabControl1.SelectedTabIndex = 0
    End Sub
    Private Sub Btmfind_Click(sender As Object, e As EventArgs) Handles Btmfind.Click
        Clrmaster()
        Clrdetails()
        Clrdgrid()
        TabControl1.SelectedTabIndex = 0
        BindingNavigator1.Enabled = False
        Mainbuttoncancel()
        Tscboth.Checked = True
        Tstbkeyword.Focus()
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
    Private Sub Dgvlist_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Dgvlist.CellMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Me.Dgvlist.Rows.Count < 1 Then Exit Sub
            If e.RowIndex < 0 Then Exit Sub
            Dgvlist.CurrentCell = Dgvlist(3, e.RowIndex)
            Me.Dgvlist.Rows(e.RowIndex).Selected = True
            Editcontextlistmenu()
        End If
    End Sub
    Private Sub Dgvlist_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgvlist.CellClick
        If Dgvlist.RowCount = 0 Then
            Exit Sub
        End If
        Dgvlist.CurrentRow.Selected = True
    End Sub
    Private Sub Ctmledit_Click(sender As Object, e As EventArgs) Handles Ctmledit.Click
        Clrmaster()
        Clrdetails()
        Clrdgrid()
        TabControl1.SelectedTabIndex = 1
        Tbdlvno.DataBindings.Clear()
        Tbdlvno.Text = ""
        Bs.Position = Bs.Find("Dlvno", Trim(Dgvlist.CurrentRow.Cells("Dlvno").Value))
        Tbdlvno.DataBindings.Add("Text", Bs, "Dlvno")
        Tbdlvno.Enabled = False
        Bindmaster()
        BindingNavigator1.Enabled = True
        Btmnew.Enabled = False
        Btmedit.Enabled = True
        Btmdel.Enabled = True
        Btmsave.Enabled = False
        Btmcancel.Enabled = True
        Btmreports.Enabled = True
        Btdbadd.Enabled = False
        Btdedit.Enabled = False
        Btddel.Enabled = False
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
    Private Sub BindingNavigator1_RefreshItems(sender As Object, e As EventArgs) Handles BindingNavigator1.RefreshItems
        Tsbwsave.Visible = False
        Tbdlvno.Enabled = False
        Bindmaster()
    End Sub
    Private Sub Btfindshipping_Click(sender As Object, e As EventArgs) Handles Btfindshipping.Click
        Dim Frm As New Formshipinglist
        Showdiaformcenter(Frm, Me)
        If Frm.Tbcancel.Text = "C" Then
            Exit Sub
        End If
        Tbshipingid.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("Mid").Value)
        Tbshippingname.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("Mname").Value)
    End Sub
    Private Sub Btfindsuplier_Click(sender As Object, e As EventArgs) Handles Btfindsuplier.Click
        Dim Frm As New Formsupplierslist
        Showdiaformcenter(Frm, Me)
        If Frm.Tbcancel.Text = "C" Then
            Exit Sub
        End If
        Tbsuppid.Text = Frm.Dgvmas.CurrentRow.Cells("Mid").Value
        Tbsuppliername.Text = Frm.Dgvmas.CurrentRow.Cells("Mname").Value
        Tbdlvno.Focus()
    End Sub
    Private Sub Dtpdate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Dtpdate.KeyPress
        e.Handled = True
    End Sub
    Private Sub Btfindyarn_Click(sender As Object, e As EventArgs) Handles Btfindyarn.Click
        If Validmas() = False Then
            Informmessage("กรุณากรอกข้อมูลให้ครบถ้วน Shiping,Supplier,เลขที่ใบส่งด้าย")
            Exit Sub
        End If
        Dim Frm As New Formyarnlist
        Showdiaformcenter(Frm, Me)
        If Frm.Tbcancel.Text = "C" Then
            Exit Sub
        End If
        Tbyarnid.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("Mid").Value)
        Tbyarnname.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("Mname").Value)
        Tblotno.Focus()
    End Sub
    Private Sub Tblotno_KeyDown(sender As Object, e As KeyEventArgs) Handles Tblotno.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            Tbnwpcotkg.Focus()
        End If
    End Sub
    Private Sub Tbnwpcotkg_KeyDown(sender As Object, e As KeyEventArgs) Handles Tbnwpcotkg.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Tbnwpcotkg.Text = "" Then
                Tbnwpcotp.Text = "0"
                Tbgrwpcotkg.Focus()
                Exit Sub
            End If
            Tbnwpcotp.Text = Format(Findpoud(Tbnwpcotkg.Text), "###,###.#0")
            Tbgrwpcotkg.Focus()
        End If
    End Sub
    Private Sub Tbgrwpcotkg_KeyDown(sender As Object, e As KeyEventArgs) Handles Tbgrwpcotkg.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Tbgrwpcotkg.Text = "" Then
                Tbgrwpcotp.Text = "0"
                Tbamtcotton.Focus()
                Exit Sub
            End If
            Tbgrwpcotp.Text = Format(Findpoud(Tbgrwpcotkg.Text), "###,###.#0")
            Tbamtcotton.Focus()
        End If
    End Sub
    Private Sub Tbamtcotton_KeyDown(sender As Object, e As KeyEventArgs) Handles Tbamtcotton.KeyDown
        If e.KeyCode = Keys.Enter Then
            Btdadd_Click(sender, e)
        End If
    End Sub
    Private Sub Btdadd_Click(sender As Object, e As EventArgs) Handles Btdadd.Click
        If Validinput() = False Then
            Informmessage("กรุณาตรวจสอบข้อมูลให้ถูกต้อง ครบถ้วน(เส้นด้าย,N.WT/CTN,GR.WT/CTN,จำนวนกล่อง)")
            Exit Sub
        End If
        If Chkexistyarnlot(Trim(Tbyarnid.Text), Trim(Tblotno.Text)) = True Then
            Informmessage("เส้นด้ายเบอร์และ Lot no นี้ มีในระบบแล้ว")
            Exit Sub
        End If
        If Validnumber() = False Then
            Informmessage("กรุณาตรวจจำนวนให้ถูกต้อง ครบถ้วน(N.WT/CTN,GR.WT/CTN,จำนวนกล่อง)")
            Exit Sub
        End If
        If Tbaddedit.Text = "เพิ่ม" Then
            If Chkdupyarnidingrid() = True Then
                Informmessage("เส้นด้ายประเภทและ Lot No. นี้มีแล้ว")
                Exit Sub
            End If
        End If
        Tbnwpcotp.Text = Format(Findpoud(Tbnwpcotkg.Text), "###,###.#0")
        Tbgrwpcotp.Text = Format(Findpoud(Tbgrwpcotkg.Text), "###,###.#0")
        Select Case Trim(Tbaddedit.Text)
            Case "เพิ่ม"
                If Tbdlvno.Enabled = True Then
                    Dgvmas.Rows.Add()
                Else
                    Tdetails.Rows.Add()
                End If
                Tsbwsave.Visible = True
                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Dcomid").Value = Gscomid
                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Dyarnid").Value = Trim(Tbyarnid.Text)
                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Dyarnname").Value = Trim(Tbyarnname.Text)
                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Dlot").Value = Trim(Tblotno.Text)
                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Nwtkg").Value = CDbl(Tbnwpcotkg.Text)
                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Nwtpound").Value = CDbl(Tbnwpcotp.Text)
                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Grwtkg").Value = CDbl(Tbgrwpcotkg.Text)
                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Grwtp").Value = CDbl(Tbgrwpcotp.Text)
                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Damtcotton").Value = CLng(Tbamtcotton.Text)
                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Qtykg").Value = CLng(Tbamtcotton.Text) * CDbl(Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Nwtkg").Value)
            Case "แก้ไข"
                Tsbwsave.Visible = True
                Dgvmas.CurrentRow.Cells("Dcomid").Value = Gscomid
                Dgvmas.CurrentRow.Cells("Dyarnid").Value = Trim(Tbyarnid.Text)
                Dgvmas.CurrentRow.Cells("Dyarnname").Value = Trim(Tbyarnname.Text)
                Dgvmas.CurrentRow.Cells("Dlot").Value = Trim(Tblotno.Text)
                Dgvmas.CurrentRow.Cells("Nwtkg").Value = CDbl(Tbnwpcotkg.Text)
                Dgvmas.CurrentRow.Cells("Nwtpound").Value = CDbl(Tbnwpcotp.Text)
                Dgvmas.CurrentRow.Cells("Grwtkg").Value = CDbl(Tbgrwpcotkg.Text)
                Dgvmas.CurrentRow.Cells("Grwtp").Value = CDbl(Tbgrwpcotp.Text)
                Dgvmas.CurrentRow.Cells("Damtcotton").Value = CLng(Tbamtcotton.Text)
                Dgvmas.CurrentRow.Cells("Qtykg").Value = CLng(Tbamtcotton.Text) * CDbl(Dgvmas.CurrentRow.Cells("Nwtkg").Value)
        End Select
        Sumall()
        Btdcancel_Click(sender, e)
        Tbremark.Focus()
    End Sub
    Private Sub Btdcancel_Click(sender As Object, e As EventArgs) Handles Btdcancel.Click
        Clrdetails()
    End Sub
    Private Sub Btdbadd_Click(sender As Object, e As EventArgs) Handles Btdbadd.Click
        Btdcancel_Click(sender, e)
        GroupPanel2.Visible = True
        Tbaddedit.Text = "เพิ่ม"
    End Sub
    Private Sub Btdedit_Click(sender As Object, e As EventArgs) Handles Btdedit.Click
        If Dgvmas.RowCount = 0 Then
            Exit Sub
        End If
        If Validmas() = False Then
            Informmessage("กรุณากรอกข้อมูลให้ครบถ้วน Shiping,Supplier,Lot No.")
            Exit Sub
        End If
        GroupPanel2.Visible = True
        Tbaddedit.Text = "แก้ไข"
        Tbyarnid.Text = Trim(Dgvmas.CurrentRow.Cells("Dyarnid").Value)
        Tbyarnname.Text = Trim(Dgvmas.CurrentRow.Cells("Dyarnname").Value)
        Tblotno.Text = Trim(Dgvmas.CurrentRow.Cells("Dlot").Value)
        Tbnwpcotkg.Text = Format(CDbl(Dgvmas.CurrentRow.Cells("Nwtkg").Value), "###,###.#0")
        Tbnwpcotp.Text = Format(CDbl(Dgvmas.CurrentRow.Cells("Nwtpound").Value), "###,###.#0")
        Tbgrwpcotkg.Text = Format(CDbl(Dgvmas.CurrentRow.Cells("Grwtkg").Value), "###,###.#0")
        Tbgrwpcotp.Text = Format(CDbl(Dgvmas.CurrentRow.Cells("Grwtp").Value), "###,###.#0")
        Tbamtcotton.Text = Format(CLng(Dgvmas.CurrentRow.Cells("Damtcotton").Value), "###,###")
        Tblotno.Focus()
    End Sub
    Private Sub Btddel_Click(sender As Object, e As EventArgs) Handles Btddel.Click
        If Dgvmas.RowCount = 0 Then
            Exit Sub
        End If
        Dim Tyarnid, Tlotno As String
        Tyarnid = Trim(Dgvmas.CurrentRow.Cells("Dyarnid").Value)
        Tlotno = Trim(Dgvmas.CurrentRow.Cells("Dlot").Value)
        If Chkitmcandel(Tyarnid, Tlotno) = False Then
            Informmessage("ไม่สามารถลบรายการนี้ได้")
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
            Dgvmas.CurrentCell = Dgvmas(5, e.RowIndex)
            Me.Dgvmas.Rows(e.RowIndex).Selected = True
            Editcontextdetmenu()
        End If
    End Sub
    Private Sub Ctdedit_Click(sender As Object, e As EventArgs) Handles Ctdedit.Click
        If Btdedit.Enabled = False Then
            Exit Sub
        End If
        Btdedit_Click(sender, e)
    End Sub
    Private Sub Ctddel_Click(sender As Object, e As EventArgs) Handles Ctddel.Click
        If Btddel.Enabled = False Then
            Exit Sub
        End If
        Btddel_Click(sender, e)
    End Sub
    Private Sub Tbremark_KeyDown(sender As Object, e As KeyEventArgs) Handles Tbremark.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            Tblotno.Focus()
        End If
    End Sub
    Private Sub Formbooking_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Tbdlvno.Text = "" And Dgvmas.RowCount = 0 Then
            '   My.Forms.Formmain.Panel1.Visible = True
            Exit Sub
        End If
        If Confirmcloseform("Booking") Then
            e.Cancel = False
            '  My.Forms.Formmain.Panel1.Visible = True
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub Insertmaster()
        SQLCommand("INSERT INTO Tbookingxp(Comid,Dyarndate,Dlvno,Shippingid,Suplierid,
                    Dremark,Rein,Sstatus,Updusr,Uptype,Uptime)
                    VALUES('" & Gscomid & "','" & Formatshortdatesave(Dtpdate.Value) & "','" & Trim(Tbdlvno.Text) & "','" & Trim(Tbshipingid.Text) & "','" & Trim(Tbsuppid.Text) & "',
                    '" & Trim(Tbremark.Text) & "','0','1','" & Gsuserid & "','A','" & Formatdatesave(Now) & "')")
    End Sub
    Private Sub Editmaster()
        SQLCommand("UPDATE Tbookingxp SET  Dyarndate = '" & Formatshortdatesave(Dtpdate.Value) & "',Shippingid = '" & Trim(Tbshipingid.Text) & "',Suplierid = '" & Trim(Tbsuppid.Text) & "'
                   ,Dremark = '" & Trim(Tbremark.Text) & "',Updusr = '" & Gsuserid & "',Uptype = 'E',Uptime = '" & Formatdatesave(Now) & "'
                    WHERE Comid = '" & Gscomid & "' AND Dlvno = '" & Trim(Tbdlvno.Text) & "'")
    End Sub
    Private Sub Deldetails(Tdlvno As String)
        SQLCommand("DELETE FROM Tbookingdetxp
                    WHERE Comid = '" & Gscomid & "' AND Dlvno = '" & Tdlvno & "'")
    End Sub
    Private Sub Upddetails(Etype As String)
        Deldetails(Trim(Tbdlvno.Text))
        Dim I As Integer
        ProgressBarX1.Value = 0
        Dim Frm As New Formwaitdialoque
        Frm.Show()
        Dim Tyarnid, Tlotno As String
        Dim Tnwkg, Tnwp, Tgwkg, Tgwp, Tqty As Double
        Dim Tnbox As Integer
        For I = 0 To Dgvmas.RowCount - 1
            Tyarnid = Trim(Dgvmas.Rows(I).Cells("Dyarnid").Value)
            Tlotno = Trim(Dgvmas.Rows(I).Cells("Dlot").Value)
            Tnwkg = Dgvmas.Rows(I).Cells("Nwtkg").Value
            Tnwp = Dgvmas.Rows(I).Cells("Nwtpound").Value
            Tgwkg = Dgvmas.Rows(I).Cells("Grwtkg").Value
            Tgwp = Dgvmas.Rows(I).Cells("Grwtp").Value
            Tqty = Dgvmas.Rows(I).Cells("Qtykg").Value
            Tnbox = Dgvmas.Rows(I).Cells("Damtcotton").Value
            SQLCommand("INSERT INTO Tbookingdetxp(Comid,Dlvno,Yarnid,Lotno,Nwkgpc,
                        Nwppc,Gwkgpc,Gwppc,Nofc,
                        Updusr,Uptype,Uptime)
                        VALUES('" & Gscomid & "','" & Trim(Tbdlvno.Text) & "','" & Tyarnid & "','" & Tlotno & "'," & Tnwkg & ",
                        " & Tnwp & "," & Tgwkg & "," & Tgwp & "," & Tnbox & ",
                        '" & Gsuserid & "','" & Etype & "','" & Formatdatesave(Now) & "')")
            ProgressBarX1.Value = ((I + 1) / Dgvmas.Rows.Count) * 100
            ProgressBarX1.Text = "Saving ... " & ProgressBarX1.Value & "%"
        Next
        Frm.Close()
        ProgressBarX1.Text = "Ready"
        ProgressBarX1.Value = 0
    End Sub
    Private Sub Bindmaster()
        Tmaster = New DataTable
        Tmaster = SQLCommand("SELECT * FROM Vbookingmas 
                                WHERE Comid = '" & Gscomid & "' AND Dlvno = '" & Trim(Tbdlvno.Text) & "'")
        If Tmaster.Rows.Count > 0 Then
            Dtpdate.Value = Tmaster.Rows(0)("Dyarndate")
            Tbshipingid.Text = Tmaster.Rows(0)("Shippingid")
            Tbshippingname.Text = Trim(Tmaster.Rows(0)("Shippingname"))
            Tbsuppid.Text = Trim(Tmaster.Rows(0)("Suplierid"))
            Tbsuppliername.Text = Trim(Tmaster.Rows(0)("Supname"))
            If IsDBNull(Tmaster.Rows(0)("Dremark")) Then
            Else
                Tbremark.Text = Trim(Tmaster.Rows(0)("Dremark"))
            End If
            If IsDBNull(Tmaster.Rows(0)("Rein")) Then
                Cbreceive.Checked = False
            Else
                If Tmaster.Rows(0)("Rein") = True Then
                    Cbreceive.Checked = True
                Else
                    Cbreceive.Checked = False
                End If
            End If
            Binddetails()
            Sumall()
        End If
    End Sub
    Private Sub Binddetails()
        Tdetails = New DataTable
        Tdetails = SQLCommand("SELECT '' AS Stat,* FROM Vbookingdet
                                WHERE Comid = '" & Gscomid & "' AND Dlvno = '" & Trim(Tbdlvno.Text) & "'")
        Dgvmas.DataSource = Tdetails
    End Sub
    Private Sub Bindinglist()
        Tlist = New DataTable
        Tlist = SQLCommand("SELECT '' AS Stat,* FROM Vbookingmas
                            WHERE Comid = '" & Gscomid & "' AND Sstatus = '1' AND Rein = '0'
                            ORDER BY Rein ASC,Dyarndate DESC")
        Dgvlist.DataSource = Tlist
        Bs = New BindingSource
        Bs.DataSource = Tlist
        BindingNavigator1.BindingSource = Bs
        FillGrid()
        ShowRecordDetail()
    End Sub
    Private Sub Searchlistbyoth(Sval As String)
        If Sval = "" Then
            Bindinglist()
            Exit Sub
        End If
        Tlist = SQLCommand("SELECT '' AS Stat,* FROM Vbookingmas
                                WHERE Comid = '" & Gscomid & "' AND Sstatus = '1' AND Rein = '0' AND
                                (Dlvno LIKE '%' + '" & Sval & "' + '%' OR Shippingname LIKE '%' + '" & Sval & "' + '%' OR Supname LIKE '%' + '" & Sval & "' + '%')")
        Bs = New BindingSource
        Bs.DataSource = Tlist
        BindingNavigator1.BindingSource = Bs
        FillGrid()
        ShowRecordDetail()
    End Sub
    Private Sub Searchlistbydate()
        Tlist = SQLCommand("SELECT '' AS Stat,* FROM Vbookingmas
                                WHERE Comid = '" & Gscomid & "' AND Sstatus = '1' AND Rein = '0' AND
                                (Dyarndate BETWEEN '" & Formatshortdatesave(Dtplistfm.Value) & "' AND '" & Formatshortdatesave(Dtplistto.Value) & "')")
        Bs = New BindingSource
        Bs.DataSource = Tlist
        BindingNavigator1.BindingSource = Bs
        FillGrid()
        ShowRecordDetail()
    End Sub
    Private Function Chkdocreinstk() As Boolean
        Dim Rein As Boolean = False
        Dim Trein As New DataTable
        Trein = SQLCommand("SELECT * FROM Vbookingmas
                                WHERE Comid = '" & Gscomid & "' AND Rein = '1' AND Sstatus = '1' AND Dlvno = '" & Trim(Tbdlvno.Text) & "'")
        If Trein.Rows.Count > 0 Then
            Rein = True
        Else
            Rein = False
        End If
        Return Rein
    End Function
    Private Function Chkitmcandel(Tyarnid As String, Tlotno As String) As Boolean 'item not receive
        Dim Candel As Boolean = False
        Dim Tcandel As New DataTable
        Tcandel = SQLCommand("SELECT * FROM Vbookingdet
                            WHERE Comid = '" & Gscomid & "' AND Dlvno = '" & Trim(Tbdlvno.Text) & "' 
                            AND Yarnid = '" & Tyarnid & "' AND Lotno = '" & Tlotno & "'  AND Instkdate IS NOT NULL")
        If Tcandel.Rows.Count > 0 Then
            Candel = False
        Else
            Candel = True
        End If
        Return Candel
    End Function
    Private Sub Newdoc()
        Insertmaster()
        Upddetails("A")
        If Gsusername = "SUPHATS" Then
        Else
            Insertlog(Gscomid, Gsusergroupid, Gsuserid, Gsusername, "F129", Trim(Tbdlvno.Text), "A", "สร้างรายการ Booking ด้าย", Formatdatesave(Now), Computername, Usrproname)
        End If
    End Sub
    Private Sub Editdoc()
        If Tbdlvno.Text = "" Then
            Exit Sub
        End If
        Editmaster()
        Upddetails("E")
        If Gsusername = "SUPHATS" Then
        Else
            Insertlog(Gscomid, Gsusergroupid, Gsuserid, Gsusername, "F129", Trim(Tbdlvno.Text), "E", "แก้ไขรายการ Booking ด้าย", Formatdatesave(Now), Computername, Usrproname)
        End If
    End Sub
    Private Function Validmas() As Boolean
        Dim Valid As Boolean = False
        If Tbmycom.Text <> "" And Tbshipingid.Text <> "" And Tbshippingname.Text <> "" And Trim(Tbdlvno.Text) <> "" And Tbsuppid.Text <> "" And Tbsuppliername.Text <> "" Then
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
    Private Sub Sumall()
        Dim Sumnwkg, Sumgwkg, Sumqtykg As Double
        Dim Sumctn As Long
        Sumnwkg = 0.0
        Sumgwkg = 0.0
        Sumqtykg = 0.0
        Sumctn = 0
        If Dgvmas.RowCount = 0 Then
            Tstbsumnw.Text = Sumnwkg
            Tstbsumgw.Text = Sumgwkg
            Tstbsumqty.Text = Sumqtykg
            Tstbsumctn.Text = Sumctn
            Exit Sub
        End If
        ProgressBarX1.Value = 0
        Dim Frm As New Formwaitdialoque
        Frm.Show()
        Dim I As Integer
        For I = 0 To Dgvmas.RowCount - 1
            Sumnwkg = Sumnwkg + CDbl(Dgvmas.Rows(I).Cells("Nwtkg").Value)
            Sumgwkg = Sumgwkg + CDbl(Dgvmas.Rows(I).Cells("Grwtkg").Value)
            Sumctn = Sumctn + Dgvmas.Rows(I).Cells("Damtcotton").Value
            Dgvmas.Rows(I).Cells("Qtykg").Value = CLng(Dgvmas.Rows(I).Cells("Damtcotton").Value) * CDbl(Dgvmas.Rows(I).Cells("Nwtkg").Value)
            Sumqtykg = Sumqtykg + CDbl(Dgvmas.Rows(I).Cells("Qtykg").Value)
            ProgressBarX1.Value = ((I + 1) / Dgvmas.Rows.Count) * 100
            ProgressBarX1.Text = "Caculating sum(LB) ... " & ProgressBarX1.Value & "%"
        Next
        Frm.Close()
        ProgressBarX1.Text = "Ready"
        ProgressBarX1.Value = 0
        Tstbsumnw.Text = Format(Sumnwkg, "###,###.#0")
        Tstbsumgw.Text = Format(Sumgwkg, "###,###.#0")
        Tstbsumqty.Text = Format(Sumqtykg, "###,###.#0")
        Tstbsumctn.Text = Sumctn
    End Sub
    Private Sub Clrdgrid()
        Dgvmas.AutoGenerateColumns = False
        Dgvmas.DataSource = Nothing
        Dgvmas.Rows.Clear()
    End Sub
    Private Sub Clrmaster()
        Tbdlvno.Text = ""
        Tbdlvno.Enabled = True
        Dtpdate.Value = Now
        Tbshipingid.Text = ""
        Tbshippingname.Text = ""
        Tbsuppid.Text = ""
        Tbsuppliername.Text = ""
        Tstbsumnw.Text = ""
        Tstbsumgw.Text = ""
        Tstbsumqty.Text = ""
        Tstbsumctn.Text = ""
        Tbremark.Text = ""
        Tsbwsave.Visible = False
    End Sub
    Private Sub Clrdetails()
        Tbyarnid.Text = ""
        Tbyarnname.Text = ""
        Tblotno.Text = ""
        Tbnwpcotkg.Text = ""
        Tbnwpcotp.Text = ""
        Tbgrwpcotkg.Text = ""
        Tbgrwpcotp.Text = ""
        Tbamtcotton.Text = ""
        GroupPanel2.Visible = False
    End Sub
    Private Sub Editcontextdetmenu()
        Ctmmenudetgrid.Displayed = False
        Ctmmenudetgrid.PopupMenu(Control.MousePosition)
    End Sub
    Private Sub Editcontextlistmenu()
        Ctmmenugrid.Displayed = False
        Ctmmenugrid.PopupMenu(Control.MousePosition)
    End Sub

    Private Function Validinput() As Boolean
        Dim Valid As Boolean = False
        If Tbyarnid.Text <> "" And Tbyarnname.Text <> "" And Tblotno.Text <> "" And Tbnwpcotkg.Text <> "" And Tbgrwpcotkg.Text <> "" And Tbamtcotton.Text <> "" Then
            Valid = True
        End If
        Return Valid
    End Function
    Private Function Chkexistyarnlot(Tyarnid, Tlotno) As Boolean
        Dim Ylexist As Boolean = False
        Dim Tyandlotdt As DataTable
        Tyandlotdt = New DataTable
        Tyandlotdt = SQLCommand("SELECT * FROM Tbookingdetxp 
                    WHERE Comid = '" & Gscomid & "' AND Yarnid = '" & Tyarnid & "' AND Lotno = '" & Tlotno & "'")
        If Tyandlotdt.Rows.Count > 0 Then
            Ylexist = True
        Else
            Ylexist = False
        End If
        Return Ylexist
    End Function
    Private Function Validnumber() As Boolean
        Try
            Dim Valid As Boolean = False
            If CDbl(Tbnwpcotkg.Text) > 0 And CDbl(Tbgrwpcotkg.Text) > 0 And CLng(Tbamtcotton.Text) > 0 Then
                Valid = True
            End If
            Return Valid
        Catch ex As Exception
            Return False
        End Try
    End Function
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
    Private Sub ShowRecordDetail()
        Tbrecord.Text = "แสดง " & (Dgvlist.RowCount) & " รายการ จาก " & Tlist.Rows.Count & " รายการ"
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


    Private Function Chkdupyarnidingrid() As Boolean
        Dim Dup As Boolean = False
        If Dgvmas.RowCount = 0 Then
            Dup = False
        Else
            Dim I As Integer
            For I = 0 To Dgvmas.RowCount - 1
                If Trim(Tbyarnid.Text) = Trim(Dgvmas.Rows(I).Cells("Dyarnid").Value) And Trim(Tblotno.Text) = Trim(Dgvmas.Rows(I).Cells("Dlot").Value) Then
                    Dup = True
                    Exit For
                End If
            Next
        End If
        Return Dup
    End Function
    Private Sub Mainbuttonaddedit()
        Btmnew.Enabled = False
        Btmedit.Enabled = False
        Btmdel.Enabled = False
        Btmsave.Enabled = True
        Btmcancel.Enabled = True
        Btmreports.Enabled = False
        Enabledbutton()
    End Sub
    Private Sub Enabledbutton()
        Btdbadd.Enabled = True
        Btdedit.Enabled = True
        Btddel.Enabled = True
        Btfindshipping.Enabled = True
        Btfindsuplier.Enabled = True
        Btfindyarn.Enabled = True
        Ctdedit.Enabled = True
        Ctddel.Enabled = True
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
        Btdbadd.Enabled = False
        Btdedit.Enabled = False
        Btddel.Enabled = False
        Btfindshipping.Enabled = False
        Btfindsuplier.Enabled = False
        Btfindyarn.Enabled = False
        Ctdedit.Enabled = False
        Ctddel.Enabled = False
    End Sub
    Private Function Chkdupdlv() As Boolean
        Dim Dlvdup As Boolean = False
        Dim Tdlvdup As New DataTable
        Tdlvdup = SQLCommand("SELECT * FROM Tbookingxp
                            WHERE Comid = '" & Gscomid & "' AND Dlvno = '" & Trim(Tbdlvno.Text) & "'")
        If Tdlvdup.Rows.Count > 0 Then
            Dlvdup = True
        Else
            Dlvdup = False
        End If
        Return Dlvdup
    End Function
    Private Sub Setauthorize()
        If Gscreau = False Then
            Btmnew.Visible = False
        End If
        If Gswriau = False Then
            Btmedit.Visible = False
        End If
        If Gsdelau = False Then
            Btmdel.Visible = False
        End If
        If Gspriau = False Then
            Btmreports.Visible = False
        End If
        If Gsseaau = False Then
            Btmfind.Visible = False
            Tstbkeyword.Visible = False
            Btlistfind.Visible = False
            Btrefresh.Visible = False
            Tscbdate.Visible = False
            Tscboth.Visible = False
        End If
    End Sub
End Class