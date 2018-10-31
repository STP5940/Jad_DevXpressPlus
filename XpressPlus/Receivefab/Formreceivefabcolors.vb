Imports System.ComponentModel
Imports Microsoft.Reporting.WinForms
Public Class Formreceivefabcolors
    Private Tmaster, Tdetails, Tlist, Dttemp As DataTable
    Private Pagecount, Maxrec, Pagesize, Currentpage, Recno As Integer
    Private WithEvents Dtplistfm As New DateTimePicker
    Private WithEvents Dtplistto As New DateTimePicker
    Private Sub Formreceivefabcolors_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        GroupPanel2.Visible = False
        'Setauthorize()
        Mainbuttoncancel()
        Tbmycom.Text = Trim(Gscomname)

    End Sub
    Private Sub Formreceivefabcolors_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Bindinglist()
    End Sub
    Private Sub Btmnew_Click(sender As Object, e As EventArgs) Handles Btmnew.Click
        Clrdgrid()
        Clrtxtbox()
        Tbkongno.Text = ""
        Clrupdet()
        Btdcancel_Click(sender, e)
        TabControl1.SelectedTabIndex = 1

        BindingNavigator1.Enabled = False
        Mainbuttonaddedit()
        Tbrollid.Text = 1
    End Sub
    Private Sub Btmsave_Click(sender As Object, e As EventArgs) Handles Btmsave.Click
        If Validmas() = False Then
            Informmessage("กรุณาตรวจสอบข้อมูลในการรับผ้าสีให้ครบถ้วน")
            Exit Sub
        End If
        If Validdet() = False Then
            Informmessage("กรุณาตรวจสอบรายละเอียดในการส่งให้ครบถ้วน")
            Exit Sub
        End If
        If Tbdyedbillno.Enabled = True Then
            Newdoc()
        Else
            Editdoc()
        End If
        Btdcancel_Click(sender, e)
        Tbkongno.Text = ""
        Clrupdet()
        Tsbwsave.Visible = False

        Mainbuttoncancel()
    End Sub
    Private Sub Btmdel_Click(sender As Object, e As EventArgs) Handles Btmdel.Click
        If Trim(Tbknittno.Text) = "" Then
            Exit Sub
        End If
        If Confirmdelete() = True Then
            Deldetails()
            SQLCommand("DELETE FROM Trecfabcolxp WHERE Comid = '" & Gscomid & "' 
                        AND Billdyedno = '" & Trim(Tbdyedbillno.Text) & "' AND Dhid = '" & Trim(Tbdhid.Text) & "' AND Lotno = '" & Tbrefablotno.Text & "'")
            Clrdgrid()
            Clrtxtbox()
            Mainbuttoncancel()
        End If
    End Sub
    Private Sub Btmreports_Click(sender As Object, e As EventArgs) Handles Btmreports.Click

    End Sub
    Private Sub Btmfind_Click(sender As Object, e As EventArgs) Handles Btmfind.Click
        TabControl1.SelectedTabIndex = 0
        Tscboth.Checked = True
        Tstbkeyword.Select()
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
    Private Sub Ctmledit_Click(sender As Object, e As EventArgs) Handles Ctmledit.Click
        Clrdgrid()
        'Clrtxtbox() 'เป้
        Btdcancel_Click(sender, e)
        TabControl1.SelectedTabIndex = 1
        Tbdhid.Text = Trim(Dgvlist.CurrentRow.Cells("Ldhid").Value)
        Tbdyedbillno.Text = Trim(Dgvlist.CurrentRow.Cells("Lbilldyedno").Value)
        Tbknittno.Text = Trim(Dgvlist.CurrentRow.Cells("Lbillknitt").Value)
        Tbrefablotno.Text = Trim(Dgvlist.CurrentRow.Cells("Dlotno").Value)
        Btmedit.Enabled = True
        Tbdyedbillno.Enabled = False
        Tbknittno.Enabled = False
        Tbrefablotno.Enabled = False
        Tbcolorno.Enabled = False
        Btmnew.Enabled = False
        Btmdel.Enabled = True
        Btmreports.Enabled = True
        Bindmaster()
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
    Private Sub Btfinddyedh_Click(sender As Object, e As EventArgs) Handles Btfinddyedh.Click
        Dim Frm As New Formdyedlist
        Showdiaformcenter(Frm, Me)
        If Frm.Tbcancel.Text = "C" Then
            Exit Sub
        End If
        Tbdhid.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("Mid").Value)
        Tbdhname.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("Mname").Value)
        Tbdyedbillno.Focus()
    End Sub
    Private Sub Tbdyedbillno_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Tbknittno.Focus()
        End If
    End Sub
    Private Sub Tbknittno_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Tbcolorno.Focus()
        End If
    End Sub
    Private Sub Tbcolorno_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Tbrefablotno.Focus()
        End If
    End Sub
    Private Sub Tbrefablotno_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub
    Private Sub Btfindknitid_Click(sender As Object, e As EventArgs) Handles Btfindknitid.Click
        Dim Frm As New Formdyeddetlist
        Frm.Tbknitbill.Text = Trim(Tbknittno.Text)
        Frm.Tbdyedbillno.Text = Trim(Tbdyedbillno.Text)
        Showdiaformcenter(Frm, Me)
        If Frm.Tbcancel.Text = "C" Then
            Exit Sub
        End If
        AllQtyroll.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("Qtyroll").Value)
        AllQtykg.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("Qtykg").Value)
        Tbclothid.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("Clothid").Value)
        Tbclothno.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("Mclothno").Value)
        Tbclothtype.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("Ftype").Value)
        Tbwidht.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("Fwidth").Value)
        Tbshadeid.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("Shadeid").Value)
        Tbshadename.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("Shadedesc").Value)
        Tbkongno.Focus()
    End Sub
    Private Sub Tbkongno_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Tbkg.Focus()
        End If
    End Sub
    Private Sub Tbkg_KeyDown(sender As Object, e As KeyEventArgs) Handles Tbkg.KeyDown
        If e.KeyCode = Keys.Enter Then
            Btdadd_Click(sender, e)
        End If
    End Sub
    Private Sub Btdadd_Click(sender As Object, e As EventArgs) Handles Btdadd.Click
        If Validmas() = False Then
            Informmessage("กรุณากรอกข้อมูลการรับผ้าสี")
            Exit Sub
        End If
        If Validinput() = False Then
            Informmessage("กรุณาตรวจสอบข้อมูลให้ถูกต้อง ครบถ้วน")
            Exit Sub
        End If
        If Validnumber() = False Then
            Informmessage("กรุณาตรวจจำนวนให้ถูกต้อง ครบถ้วน")
            Exit Sub
        End If
        Select Case Trim(Tbaddedit.Text)
            Case "เพิ่ม"
                If Tbdyedbillno.Enabled = True Then
                    Dgvmas.Rows.Add()
                Else
                    Tdetails.Rows.Add()
                End If
                Tsbwsave.Visible = True
                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("rollid").Value = Trim(Tbrollid.Text)
                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Clothid").Value = Trim(Tbclothid.Text)
                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Mclothno").Value = Trim(Tbclothno.Text)
                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Clothtype").Value = Trim(Tbclothtype.Text)
                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Dwidth").Value = Trim(Tbwidht.Text)
                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Shadeid").Value = Trim(Tbshadeid.Text)
                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Shadedesc").Value = Trim(Tbshadename.Text)
                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Mkong").Value = Trim(Tbkongno.Text)
                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("Rollwage").Value = CDbl(Tbkg.Text)
            Case "แก้ไข"
                Tsbwsave.Visible = True
                Dgvmas.CurrentRow.Cells("rollid").Value = Trim(Tbrollid.Text)
                Dgvmas.CurrentRow.Cells("Clothid").Value = Trim(Tbclothid.Text)
                Dgvmas.CurrentRow.Cells("Mclothno").Value = Trim(Tbclothno.Text)
                Dgvmas.CurrentRow.Cells("Clothtype").Value = Trim(Tbclothtype.Text)
                Dgvmas.CurrentRow.Cells("Dwidth").Value = Trim(Tbwidht.Text)
                Dgvmas.CurrentRow.Cells("Shadeid").Value = Trim(Tbshadeid.Text)
                Dgvmas.CurrentRow.Cells("Shadedesc").Value = Trim(Tbshadename.Text)
                For i = 0 To Dgvmas.RowCount - 1
                    Dgvmas.Rows(i).Cells("Mkong").Value = Trim(Tbkongno.Text)
                Next
                Dgvmas.CurrentRow.Cells("Rollwage").Value = CDbl(Tbkg.Text)
        End Select
        Sumall()
        'Btdcancel_Click(sender, e)
        ClearDetail()
        Tbrollid.Text = Trim(rollidnew(Dgvmas, "rollid") + 1)
        Tbkg.Focus()
    End Sub
    Private Sub Btdcancel_Click(sender As Object, e As EventArgs) Handles Btdcancel.Click
        'Clrtxtbox() ' เป้
        ClearDetail()
        Clrupdet()
        Tbkongno.Text = ""
        Tbkg.Text = ""
    End Sub

    Private Sub ClearMaster()
        Tbdhid.Text = ""
        Tbdhname.Text = ""
        Tbmycom.Text = ""
        Tbdyedbillno.Text = ""
        Tbknittno.Text = ""
        Tbcolorno.Text = ""
        Tbrefablotno.Text = ""
        Dtprecdate.Value = Now
    End Sub
    Private Sub ClearDetail()
        Tbrollid.Text = ""
        Tbclothid.Text = ""
        Tbclothno.Text = ""
        Tbclothtype.Text = ""
        Tbwidht.Text = ""
        Tbshadeid.Text = ""
        Tbshadename.Text = ""
        Tbkongno.Text = ""
        Tbkg.Text = ""
    End Sub

    Private Sub Btdedit_Click(sender As Object, e As EventArgs)
        If Dgvmas.RowCount = 0 Then
            Exit Sub
        End If
        If Validmas() = False Then
            Informmessage("กรุณากรอกเลือกที่ส่ง")
            Exit Sub
        End If
        'GroupPanel2.Visible = True
        Tbaddedit.Text = "แก้ไข"
        Tbclothid.Text = Trim(Dgvmas.CurrentRow.Cells("Clothid").Value)
        Tbclothno.Text = Trim(Dgvmas.CurrentRow.Cells("Mclothno").Value)
        Tbclothtype.Text = Trim(Dgvmas.CurrentRow.Cells("Clothtype").Value)
        Tbwidht.Text = Trim(Dgvmas.CurrentRow.Cells("Dwidth").Value)
        Tbshadeid.Text = Trim(Dgvmas.CurrentRow.Cells("Shadeid").Value)
        Tbshadename.Text = Trim(Dgvmas.CurrentRow.Cells("Shadedesc").Value)
        Tbkongno.Text = Trim(Dgvmas.CurrentRow.Cells("Mkong").Value)
        Tbkg.Text = Format(CDbl(Dgvmas.CurrentRow.Cells("Rollwage").Value), "###,###.#0")
        Tbkg.Focus()
    End Sub
    Private Sub Btddel_Click(sender As Object, e As EventArgs)
        If Dgvmas.RowCount = 0 Then
            Exit Sub
        End If
        Btdcancel_Click(sender, e)
        Tsbwsave.Visible = True
        Dgvmas.Rows.Remove(Dgvmas.CurrentRow)
        Sumall()
    End Sub
    Private Sub Dgvmas_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If Dgvmas.RowCount = 0 Then
            Exit Sub
        End If
        Dgvmas.CurrentRow.Selected = True
    End Sub
    Private Sub Dgvmas_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Me.Dgvmas.Rows.Count < 1 Then Exit Sub
            If e.RowIndex < 0 Then Exit Sub
            Dgvmas.CurrentCell = Dgvmas(9, e.RowIndex)
            Me.Dgvmas.Rows(e.RowIndex).Selected = True
            Editcontextdetmenu()
        End If
    End Sub
    Private Sub Ctdedit_Click(sender As Object, e As EventArgs)
        Btdedit_Click(sender, e)
    End Sub
    Private Sub Ctddel_Click(sender As Object, e As EventArgs)
        Btddel_Click(sender, e)
    End Sub
    Private Sub Formreceivefabcolors_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Tbdyedbillno.Enabled = True And Dgvmas.RowCount = 0 Then
            'My.Forms.Formmain.Panel1.Visible = True
            Exit Sub
        End If
        If Confirmcloseform("รับผ้าสี") Then
            e.Cancel = False
            'My.Forms.Formmain.Panel1.Visible = True
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub Searchlistbyoth(Sval As String)
        If Sval = "" Then
            Bindinglist()
            Exit Sub
        End If
        Tlist = SQLCommand("SELECT '' AS Stat,* FROM Vrecfabcolmas
                                WHERE Comid = '" & Gscomid & "' AND (Billdyedno LIKE '%' + '" & Sval & "' + '%' OR Billknitt LIKE '%' + '" & Sval & "' + '%')")
        FillGrid()
        ShowRecordDetail()
    End Sub
    Private Sub Searchlistbydate()
        Tlist = SQLCommand("SELECT '' AS Stat,* FROM Vrecfabcolmas
                                WHERE Comid = '" & Gscomid & "' AND (Recdate BETWEEN '" & Formatshortdatesave(Dtplistfm.Value) & "' AND '" & Formatshortdatesave(Dtplistto.Value) & "')")
        FillGrid()
        ShowRecordDetail()
    End Sub
    Private Sub Newdoc()
        Insertmaster()
        Upddetails("A")
        If Gsusername = "SUPHATS" Then
        Else
            Insertlog(Gscomid, Gsusergroupid, Gsuserid, Gsusername, "F123", Trim(Tbdyedbillno.Text), "A", "สร้างรายการ รับผ้าสี", Formatdatesave(Now), Computername, Usrproname)
        End If
    End Sub
    Private Sub Editdoc()
        If Tbdyedbillno.Enabled = True Then
            Exit Sub
        End If
        Editmaster()
        Upddetails("E")
        If Gsusername = "SUPHATS" Then
        Else
            Insertlog(Gscomid, Gsusergroupid, Gsuserid, Gsusername, "F124", Trim(Tbdyedbillno.Text), "E", "แก้ไขรายการ รับผ้าสี", Formatdatesave(Now), Computername, Usrproname)
        End If
    End Sub
    Private Sub Insertmaster()
        SQLCommand("INSERT INTO Trecfabcolxp(Comid,Dhid,Billdyedno,Billknitt,Recdate,Lotno,
                    Dyedcolor,Dremark,Updusr,Uptype,Uptime)
                    VALUES('" & Gscomid & "','" & Trim(Tbdhid.Text) & "','" & Tbdyedbillno.Text & "','" & Tbknittno.Text & "','" & Formatshortdatesave(Dtprecdate.Value) & "','" & Trim(Tbrefablotno.Text) & "',
                    '" & Tbcolorno.Text & "','" & Trim(Tbremark.Text) & "','" & Gsuserid & "','A','" & Formatdatesave(Now) & "')")
    End Sub
    Private Sub Editmaster()
        SQLCommand("UPDATE Trecfabcolxp SET Billknitt = '" & Trim(Tbknittno.Text) & "',Recdate = '" & Formatdatesave(Dtprecdate.Value) & "',
                    Dyedcolor = '" & Trim(Tbcolorno.Text) & "',Dremark = '" & Trim(Tbremark.Text) & "',Updusr = '" & Gsuserid & "',
                    Uptype = 'E',Uptime = '" & Formatdatesave(Now) & "'
                    WHERE Comid = '" & Gscomid & "' AND Dhid = '" & Trim(Tbdhid.Text) & "' AND Billdyedno = '" & Trim(Tbdyedbillno.Text) & "' AND
                    Lotno = '" & Tbrefablotno.Text & "'")
    End Sub
    Private Sub Deldetails()
        SQLCommand("DELETE FROM Trecfabcoldetxp 
                    WHERE Comid = '" & Gscomid & "' AND Dhid = '" & Trim(Tbdhid.Text) & "' AND Billdyedno = '" & Trim(Tbdyedbillno.Text) & "' AND
                    Lotno = '" & Tbrefablotno.Text & "'")
    End Sub
    Private Sub Upddetails(Etype As String)
        Deldetails()
        Dim I As Integer
        ProgressBarX1.Value = 0
        Dim Frm As New Formwaitdialoque
        Frm.Show()
        Dim Tkongno, Tclothid, Tshadeid, Tbrollid As String
        Dim Trollwgt As Double
        For I = 0 To Dgvmas.RowCount - 1
            Tkongno = Trim(Dgvmas.Rows(I).Cells("Mkong").Value)
            Tclothid = Trim(Dgvmas.Rows(I).Cells("Clothid").Value)
            Tshadeid = Dgvmas.Rows(I).Cells("Shadeid").Value
            Trollwgt = Dgvmas.Rows(I).Cells("Rollwage").Value
            Tbrollid = Dgvmas.Rows(I).Cells("rollid").Value
            SQLCommand("INSERT INTO Trecfabcoldetxp(Comid,Dhid,Billdyedno,Lotno,Kongno,
                        Pubno,Clothid,Shadeid,Rollwage,
                        Instk,Updusr,Uptype,Uptime)
                        VALUES('" & Gscomid & "','" & Trim(Tbdhid.Text) & "','" & Trim(Tbdyedbillno.Text) & "','" & Trim(Tbrefablotno.Text) & "','" & Tkongno & "',
                        '" & Trim(Tbrollid) & "','" & Tclothid & "','" & Tshadeid & "'," & Trollwgt & ",
                        '1','" & Gsuserid & "','" & Etype & "','" & Formatdatesave(Now) & "')")
            ProgressBarX1.Value = ((I + 1) / Dgvmas.Rows.Count) * 100
            ProgressBarX1.Text = "Saving ... " & ProgressBarX1.Value & "%"
        Next
        Frm.Close()
        ProgressBarX1.Text = "Ready"
        ProgressBarX1.Value = 0
    End Sub
    Private Sub Bindmaster()
        Tmaster = New DataTable
        Tmaster = SQLCommand("SELECT * FROM Vrecfabcolmas
                                WHERE Comid = '" & Gscomid & "' AND Dhid = '" & Trim(Tbdhid.Text) & "' AND Billdyedno = '" & Trim(Tbdyedbillno.Text) & "' AND 
                                Billknitt = '" & Trim(Tbknittno.Text) & "' AND Lotno = '" & Tbrefablotno.Text & "'")
        If Tmaster.Rows.Count > 0 Then
            Tbdhid.Text = Trim(Tmaster.Rows(0)("Dhid"))
            Tbdhname.Text = Trim(Tmaster.Rows(0)("Dyedhdesc"))
            Tbdyedbillno.Text = Trim(Tmaster.Rows(0)("Billdyedno"))
            Tbknittno.Text = Trim(Tmaster.Rows(0)("Billknitt"))
            Tbcolorno.Text = Trim(Tmaster.Rows(0)("Dyedcolor"))
            Tbrefablotno.Text = Trim(Tmaster.Rows(0)("Lotno"))
            Dtprecdate.Value = Tmaster.Rows(0)("Recdate")
            Tbremark.Text = Trim(Tmaster.Rows(0)("Dremark"))
            Binddetails()
            Sumall()
        End If
    End Sub
    Private Sub Binddetails()
        Tdetails = New DataTable
        Tdetails = SQLCommand("SELECT '' AS Stat,* FROM Vrecfabcoldet
                                WHERE Comid = '" & Gscomid & "' AND Dhid = '" & Trim(Tbdhid.Text) & "' 
                                AND Billdyedno = '" & Trim(Tbdyedbillno.Text) & "' AND Lotno = '" & Trim(Tbrefablotno.Text) & "' ORDER BY CAST(Pubno as int)")
        Dgvmas.DataSource = Tdetails
    End Sub
    Private Sub Bindinglist()
        Tlist = New DataTable
        Tlist = SQLCommand("SELECT '' AS Stat,* FROM Vrecfabcolmas
                                WHERE Comid = '" & Gscomid & "'")
        Dgvlist.DataSource = Tlist
        FillGrid()
        ShowRecordDetail()
    End Sub
    Private Sub Sumall()
        Dim Sumkg As Double
        Dim Sumroll As Long
        Sumkg = 0.0
        Sumroll = 0
        If Dgvmas.RowCount = 0 Then
            Tstbsumkg.Text = Sumkg
            Tstbsumroll.Text = Sumroll
            Exit Sub
        End If
        ProgressBarX1.Value = 0
        Dim Frm As New Formwaitdialoque
        Frm.Show()
        Dim I As Integer
        For I = 0 To Dgvmas.RowCount - 1
            Sumkg = Sumkg + CDbl(Dgvmas.Rows(I).Cells("Rollwage").Value)
            ProgressBarX1.Value = ((I + 1) / Dgvmas.Rows.Count) * 100
            ProgressBarX1.Text = "Caculating sum ... " & ProgressBarX1.Value & "%"
        Next
        Sumroll = Dgvmas.RowCount
        Frm.Close()
        ProgressBarX1.Text = "Ready"
        ProgressBarX1.Value = 0
        Tstbsumkg.Text = Format(Sumkg, "###,###.#0")
        Tstbsumroll.Text = Format(Sumroll, "###,###")
    End Sub
    Private Sub Clrdgrid()
        Dgvmas.AutoGenerateColumns = False
        Dgvmas.DataSource = Nothing
        Dgvmas.Rows.Clear()
    End Sub
    Private Sub Clrtxtbox()
        Tbdyedbillno.Enabled = True
        Tbknittno.Enabled = True
        Tbcolorno.Enabled = True
        Tbkongno.Enabled = True
        Tbkg.Enabled = True
        Tbrefablotno.Enabled = True
        Dtprecdate.Enabled = True
        Tbremark.Enabled = True
        Tbdhid.Text = ""
        Tbdhname.Text = ""
        Tbdyedbillno.Text = ""
        Tbknittno.Text = ""
        Tbcolorno.Text = ""
        'Tbkongno.Text = ""
        Tbkg.Text = ""
        Tbrefablotno.Text = ""
        Tbremark.Text = ""
        Dtprecdate.Value = Now
        Tsbwsave.Visible = False
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
        If Tbclothid.Text <> "" And Tbclothno.Text <> "" And Tbclothno.Text <> "" And Tbclothtype.Text <> "" And Tbwidht.Text <> "" And
            Tbshadeid.Text <> "" And Tbshadename.Text <> "" And Tbkongno.Text <> "" And Tbkg.Text <> "" Then
            Valid = True
        End If
        Return Valid
    End Function
    Private Function Validnumber() As Boolean
        Dim Valid As Boolean = False
        If CDbl(Tbkg.Text) > 0 Then
            Valid = True
        End If
        Return Valid
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
    'Test
    Private Sub Btmcancel_Click(sender As Object, e As EventArgs) Handles Btmcancel.Click
        Clrtxtbox()
        Clrupdet()
        Tbkongno.Text = ""
        Tbkg.Text = ""
        Tbrollid.Text = 0
        Clrdgrid()
        TabControl1.SelectedTabIndex = 0

        Mainbuttoncancel()
        GroupPanel2.Visible = False
        'BindingNavigator1.Enabled = False
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
    Private Function Validmas() As Boolean
        Dim Valid As Boolean = False
        If Tbdhid.Text <> "" And Tbdhname.Text <> "" And Tbdyedbillno.Text <> "" And Tbknittno.Text <> "" And Tbcolorno.Text <> "" And Tbrefablotno.Text <> "" Then
            Valid = True
        End If
        Return Valid
    End Function

    Private Sub Btdedit_Click_1(sender As Object, e As EventArgs) Handles Btdedit.Click
        If Validmas() = False Then
            Informmessage("กรุณากรอกข้อมูลการรับผ้าสี")
            Exit Sub
        End If
        GroupPanel2.Visible = True

        Tbaddedit.Text = "แก้ไข"
        Tbrollid.Text = Trim(Dgvmas.CurrentRow.Cells("rollid").Value)
        Tbclothid.Text = Trim(Dgvmas.CurrentRow.Cells("Clothid").Value)
        Tbclothno.Text = Trim(Dgvmas.CurrentRow.Cells("Mclothno").Value)
        Tbclothtype.Text = Trim(Dgvmas.CurrentRow.Cells("Clothtype").Value)
        Tbwidht.Text = Trim(Dgvmas.CurrentRow.Cells("Dwidth").Value)
        Tbshadeid.Text = Trim(Dgvmas.CurrentRow.Cells("Shadeid").Value)
        Tbshadename.Text = Trim(Dgvmas.CurrentRow.Cells("Shadedesc").Value)
        Tbkongno.Text = Trim(Dgvmas.CurrentRow.Cells("Mkong").Value)
        Tbkg.Text = Format(Dgvmas.CurrentRow.Cells("Rollwage").Value, "###,###.#0")
    End Sub

    Private Sub Btfindbillno_Click(sender As Object, e As EventArgs) Handles Btfindbillno.Click
        Dim Frm As New Formbillnolist
        Showdiaformcenter(Frm, Me)
        If Frm.Tbcancel.Text = "C" Then
            Exit Sub
        End If
        Tbdyedbillno.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("Dyecomno").Value)
    End Sub

    Private Sub Btfindknittno_Click(sender As Object, e As EventArgs) Handles Btfindknittno.Click
        Dim Frm As New Formknittnolist
        Frm.Tbdyedbillno.Text = Tbdyedbillno.Text
        Showdiaformcenter(Frm, Me)
        If Frm.Tbcancel.Text = "C" Then
            Exit Sub
        End If
        Tbknittno.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("Knittbill").Value)
    End Sub

    Private Sub Btmedit_Click(sender As Object, e As EventArgs) Handles Btmedit.Click
        BtEdit()
    End Sub

    Private Sub BtEdit()
        Btmcancel.Enabled = True
        Btmedit.Enabled = False
        'Tbdyedbillno.Enabled = True
        Tbknittno.Enabled = True
        Tbcolorno.Enabled = True
        Tbkongno.Enabled = True
        Tbkg.Enabled = True
        Tbrefablotno.Enabled = True
        Dtprecdate.Enabled = True
        Tbremark.Enabled = True
        Tbkongno.Text = ""
        Tbkg.Text = ""
        Tbremark.Text = ""
        Dtprecdate.Value = Now
        Tsbwsave.Visible = False
        Btmsave.Enabled = True
        Btmreports.Enabled = False
        Btmdel.Enabled = False
        Btfinddyedh.Enabled = True
        Btfindbillno.Enabled = True
        Btfindknittno.Enabled = True
        Btfindknitid.Enabled = True
        Tbrollid.Enabled = True
        Btdadd.Enabled = True
        Btdcancel.Enabled = True

        Btdedit.Enabled = True
        Btddel.Enabled = True
        Btdbadd.Enabled = True
    End Sub

    Private Sub Btdbadd_Click(sender As Object, e As EventArgs) Handles Btdbadd.Click
        If Dgvmas.RowCount - 1 > 0 Then
            Tbkongno.Enabled = False
        Else
            Tbkongno.Enabled = True
        End If
        Tbaddedit.Text = "เพิ่ม"
        GroupPanel2.Visible = True
        ClearDetail()
        Tbrollid.Text = Trim(rollidnew(Dgvmas, "rollid") + 1)
    End Sub

    Private Function rollidnew(GridName As Object, RowsName As String)
        Dim MaxNum = 0
        For i = 0 To GridName.RowCount - 1
            Trim(GridName.Rows(i).Cells(RowsName).Value)
            If Trim(GridName.Rows(i).Cells(RowsName).Value) > MaxNum Then
                MaxNum = Trim(GridName.Rows(i).Cells(RowsName).Value)
            End If
        Next
        Return MaxNum
    End Function

    Private Sub Btddel_Click_1(sender As Object, e As EventArgs) Handles Btddel.Click
        If Dgvmas.RowCount = 0 Then
            Exit Sub
        End If
        Dgvmas.Rows.Remove(Dgvmas.CurrentRow)
        Sumall()
        Btdcancel_Click(sender, e)
        Tsbwsave.Visible = True
    End Sub

    Private Function Validdet() As Boolean
        Dim Valid As Boolean = False
        If Dgvmas.RowCount > 0 Then
            Valid = True
        End If
        Return Valid
    End Function
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
    Private Sub Clrupdet()
        Tbclothid.Text = ""
        Tbclothno.Text = ""
        Tbclothtype.Text = ""
        Tbwidht.Text = ""
        Tbshadeid.Text = ""
        Tbshadename.Text = ""
    End Sub

    'Test
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
        Btdedit.Enabled = True
        Btddel.Enabled = True
        Ctdedit.Enabled = True
        Ctddel.Enabled = True
        Btfinddyedh.Enabled = True
        Btfindknitid.Enabled = True
        Btdadd.Enabled = True
        Btdcancel.Enabled = True
    End Sub
    Private Sub Mainbuttoncancel()
        Btfinddyedh.Enabled = False
        Tbdyedbillno.Enabled = False
        Tbknittno.Enabled = False
        Tbcolorno.Enabled = False
        Tbrefablotno.Enabled = False
        Btfindknitid.Enabled = False
        Tbkongno.Enabled = False
        Tbkg.Enabled = False
        Btdadd.Enabled = False
        Btdcancel.Enabled = False
        Dtprecdate.Enabled = False
        Btmnew.Enabled = True
        Btmedit.Enabled = False
        Btmdel.Enabled = False
        Btmsave.Enabled = False
        Btmcancel.Enabled = False
        Btmreports.Enabled = False
        Tbremark.Enabled = False
        Btfindbillno.Enabled = False
        Btfindknittno.Enabled = False
        Tbrollid.Enabled = False
        Disbaledbutton()
    End Sub
    Private Sub Disbaledbutton()
        Btdbadd.Enabled = False
        Btdedit.Enabled = False
        Btddel.Enabled = False
        Ctdedit.Enabled = False
        Ctddel.Enabled = False
    End Sub

End Class