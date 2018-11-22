Imports System.ComponentModel
Imports Microsoft.Reporting.WinForms
Imports System.Text.RegularExpressions
Public Class FormreceivefabcolorsOld
    Private Tmaster, Tdetails, Tlist, TSendDyelist, Dttemp, tlistfab, tlistyed, tlistnittno, tlistnamebill, ListLotNo As DataTable
    Private Pagecount, Maxrec, Pagesize, Currentpage, Recno As Integer
    Private WithEvents Dtplistfm As New DateTimePicker
    Private WithEvents Dtplistto As New DateTimePicker
    Private Bs As BindingSource
    Private Sub Formreceivefabcolors_Load(sender As Object, e As EventArgs) Handles Me.Load

        Controls.Add(Dtplistfm)
        Dtplistfm.Value = Now
        Dtplistfm.Width = 130
        Me.ToolStrip4.Items.Insert(5, New ToolStripControlHost(Dtplistfm))
        Me.ToolStrip4.Items(5).Alignment = ToolStripItemAlignment.Right
        Me.ToolStrip4.Items(5).Visible = False
        Dtplistfm.Visible = False

        Controls.Add(Dtplistto)
        Dtplistto.Value = Now
        Dtplistto.Width = 130
        Me.ToolStrip4.Items.Insert(4, New ToolStripControlHost(Dtplistto))
        Me.ToolStrip4.Items(4).Alignment = ToolStripItemAlignment.Right
        Me.ToolStrip4.Items(4).Visible = False
        Dtplistto.Visible = False


        GroupPanel2.Visible = False
        Retdocprefix()
        'Setauthorize()
        Mainbuttoncancel()
        Tbmycom.Text = Trim(Gscomname)
        BindingBalance()
        TabControl1.SelectedTabIndex = 1
    End Sub
    Private Sub Formreceivefabcolors_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dgvmas.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        Dgvmas.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        Balance.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        Balance.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        ''SendDyelist.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        ''SendDyelist.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        Dgvlist.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        Dgvlist.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        Bindinglist()
        'BindingSendDyelist()

    End Sub

    Private Sub Boxnew()
        Tbdyedbillno.Enabled = True
        Tbrefablotno.Enabled = True
        Tbknittno.Enabled = True
        Tbcolorno.Enabled = True
    End Sub
    Private Sub Btmnew_Click(sender As Object, e As EventArgs) Handles Btmnew.Click
        Clrdgrid()
        Boxnew()
        'Clrtxtbox()
        Tbkongno.Text = ""
        Clrupdet()
        Btdcancel_Click(sender, e)
        TabControl1.SelectedTabIndex = 2

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

        Countfabric.Rows.Clear()
        CountfabricFilter()
        For i = 0 To Balance.Rows.Count - 1
            For x = 0 To Countfabric.Rows.Count - 1
                If Balance.Rows(i).Cells("BDyedcomno").Value = Tbdyedbillno.Text AndAlso
                   Balance.Rows(i).Cells("BClothnoyed").Value.ToString.ToUpper = Countfabric.Rows(x).Cells("Cclothno").Value.ToString.ToUpper AndAlso
                   Balance.Rows(i).Cells("BFtypeyed").Value.ToString.ToUpper = Countfabric.Rows(x).Cells("Cclothtype").Value.ToString.ToUpper AndAlso
                   Balance.Rows(i).Cells("BFwidthyed").Value.ToString.ToUpper = Countfabric.Rows(x).Cells("CDwidth").Value.ToString.ToUpper Then
                    If Balance.Rows(i).Cells("BQtyroll").Value < Countfabric.Rows(x).Cells("Count").Value Then
                        If Tbdyedcomno.Text <> "NEW" Then
                            '
                            For ReCount = 0 To Countfabric.Rows.Count - 1
                                Countfabric.Rows(ReCount).Cells("Count").Value = -1
                            Next

                            For Dmas = 0 To Dgvmas.Rows.Count - 1
                                If Dgvmas.Rows(Dmas).Cells("News").Value = 1 Then

                                    For Cfab = 0 To Countfabric.Rows.Count - 1
                                        If Countfabric.Rows(Cfab).Cells("Cclothno").Value.ToString.ToUpper = Dgvmas.Rows(Dmas).Cells("Mclothno").Value.ToString.ToUpper AndAlso
                                           Countfabric.Rows(Cfab).Cells("Cclothtype").Value.ToString.ToUpper = Dgvmas.Rows(Dmas).Cells("Clothtype").Value.ToString.ToUpper AndAlso
                                           Countfabric.Rows(Cfab).Cells("CDwidth").Value.ToString.ToUpper = Dgvmas.Rows(Dmas).Cells("Dwidth").Value.ToString.ToUpper Then
                                            If Countfabric.Rows(Cfab).Cells("Count").Value = -1 Then
                                                Countfabric.Rows(Cfab).Cells("Count").Value = 1
                                            Else
                                                Countfabric.Rows(Cfab).Cells("Count").Value += 1
                                            End If

                                        End If
                                    Next

                                End If
                            Next

                            For Balan = 0 To Balance.Rows.Count - 1
                                For Countfab = 0 To Countfabric.Rows.Count - 1
                                    If Balance.Rows(Balan).Cells("BDyedcomno").Value = Tbdyedbillno.Text AndAlso
                                       Balance.Rows(Balan).Cells("BClothnoyed").Value.ToString.ToUpper = Countfabric.Rows(Countfab).Cells("Cclothno").Value.ToString.ToUpper AndAlso
                                       Balance.Rows(Balan).Cells("BFtypeyed").Value.ToString.ToUpper = Countfabric.Rows(Countfab).Cells("Cclothtype").Value.ToString.ToUpper AndAlso
                                       Balance.Rows(Balan).Cells("BFwidthyed").Value.ToString.ToUpper = Countfabric.Rows(Countfab).Cells("CDwidth").Value.ToString.ToUpper Then
                                        If Balance.Rows(Balan).Cells("BQtyroll").Value < Countfabric.Rows(Countfab).Cells("Count").Value Then
                                            If MessageBox.Show($"คุณทำการรับผ้า {Balance.Rows(Balan).Cells("BClothnoyed").Value} เกินมา {Countfabric.Rows(Countfab).Cells("Count").Value - Balance.Rows(i).Cells("BQtyroll").Value} พับ", "ข้อความแจ้ง", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.Cancel Then
                                                Countfabric.Rows.Clear()
                                                Exit Sub
                                            Else
                                                GoTo BypassFilter
                                            End If
                                        End If
                                    End If
                                Next
                            Next
                        Else
                            If MessageBox.Show($"คุณทำการรับผ้า {Balance.Rows(i).Cells("BClothnoyed").Value} เกินมา {Countfabric.Rows(x).Cells("Count").Value - Balance.Rows(i).Cells("BQtyroll").Value} พับ", "ข้อความแจ้ง", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.Cancel Then
                                Countfabric.Rows.Clear()
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            Next
        Next

BypassFilter:

        If Tbdyedcomno.Text = "NEW" Then
            ListLotNo = SQLCommand($"SELECT Lotno FROM Trecfabcoldetxp where Lotno = '{Trim(Tbrefablotno.Text)}'")
            If ListLotNo.Rows.Count > 0 Then
                Informmessage("มีเลข Lot No นี้แล้วในระบบ")
                Exit Sub
            End If
            Newdoc()
        Else
            Editdoc()
        End If
        Tsbwsave.Visible = False
        Btmreports_Click(sender, e)
        Btdcancel_Click(sender, e)
        Tbkongno.Text = ""
        Clrupdet()
        Mainbuttoncancel()
        Bindinglist()
        Btmcancel_Click(sender, e)
        BindingBalance()
    End Sub

    Private Sub Btmdel_Click(sender As Object, e As EventArgs) Handles Btmdel.Click
        'If Trim(Tbknittno.Text) = "" Then
        '    Exit Sub
        'End If
        If Confirmdelete() = True Then
            Deldetails()
            SQLCommand("DELETE FROM Trecfabcolxp WHERE Comid = '" & Gscomid & "' 
                        AND Billdyedno = '" & Trim(Tbdyedbillno.Text) & "' AND Dhid = '" & Trim(Tbdhid.Text) & "' AND Lotno = '" & Tbrefablotno.Text & "'")
            Clrdgrid()
            Clrtxtbox()
            Mainbuttoncancel()
            Tstbsumroll.Text = ""
            TabControl1.SelectedTabIndex = 1
            GroupPanel2.Visible = False
            Bindinglist()
            BindingBalance()
        End If
    End Sub

    Private Sub Btmfind_Click(sender As Object, e As EventArgs) Handles Btmfind.Click
        TabControl1.SelectedTabIndex = 1
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
    Private Sub Balance_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Balance.CellMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Me.Balance.Rows.Count < 1 Then Exit Sub
            If e.RowIndex < 0 Then Exit Sub
            Balance.CurrentCell = Balance(3, e.RowIndex)
            Me.Balance.Rows(e.RowIndex).Selected = True
            EditBalancelistmenu()
        End If
    End Sub
    Private Sub Ctmledit_Click(sender As Object, e As EventArgs) Handles Ctmledit.Click
        Clrdgrid()
        'Clrtxtbox() 'เป้
        Btdcancel_Click(sender, e)
        Mainbuttoncancel()
        GroupPanel2.Visible = False
        TabControl1.SelectedTabIndex = 2
        Tbdhid.Text = Trim(Dgvlist.CurrentRow.Cells("Ldhid").Value)
        Tbdyedbillno.Text = Trim(Dgvlist.CurrentRow.Cells("Lbilldyedno").Value)
        Tbknittno.Text = Trim(Dgvlist.CurrentRow.Cells("Lbillknitt").Value)
        Tbrefablotno.Text = Trim(Dgvlist.CurrentRow.Cells("Dlotno").Value)
        Tbdyedcomno.Text = Trim(Dgvlist.CurrentRow.Cells("Reid").Value)
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
        Dim Frm As New FormdyedlistOld
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
        Dim Frm As New FormdyeddetlistOld
        Frm.Tbknitbill.Text = Trim(Tbknittno.Text)
        Frm.Tbdyedbillno.Text = Trim(Tbdyedbillno.Text)
        Showdiaformcenter(Frm, Me)
        If Frm.Tbcancel.Text = "C" Then
            Exit Sub
        End If
        'AllQtyroll.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("BQtyroll").Value)
        'AllQtykg.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("BQtykg").Value)
        Tbclothid.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("BClothidyed").Value)
        Tbclothno.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("BClothnoyed").Value)
        Tbclothtype.Text = InputGrid(Frm.Dgvmas.CurrentRow.Cells("BFtypeyed").Value)
        Tbwidht.Text = InputGrid(Frm.Dgvmas.CurrentRow.Cells("BFwidthyed").Value)
        'Tbshadeid.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("BShadeid").Value)
        'Tbshadename.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("BShadedesc").Value)
        'DemoColor(Tbshadeid.Text)
        Tbkongno.Focus()
    End Sub
    Private Function InputGrid(Data As Object)
        Dim Redata As String = IIf(IsDBNull(Data), "", Data)
        Return Trim(Redata)
    End Function
    Private Sub DemoColor(RBGColor As Object)
        Try
            If Dgvmas.RowCount <> 0 OrElse Tbdyedcomno.Text = "NEW" Then
                Dim EBGColor As New DataTable
                EBGColor = SQLCommand($"SELECT Rcolor,Gcolor,Bcolor FROM Tshadexp WHERE Shadeid = '{RBGColor}'")
                If IsDBNull(EBGColor(0)(0)) OrElse IsDBNull(EBGColor(0)(1)) OrElse IsDBNull(EBGColor(0)(2)) Then
                    Informmessage("Shade นี้ยังไม่มีสีตัวอย่าง")
                    DemoCode.BackColor = Color.White
                    Exit Sub
                End If
                DemoCode.BackColor = Color.FromArgb(EBGColor(0)(0), EBGColor(0)(1), EBGColor(0)(2))
            End If
        Catch ex As Exception
            If Tbdyedcomno.Text <> "NEW" Then
                Informmessage("เกิดข้อผิดพลาดในการเปลี่ยนสีตัวอย่าง")
            End If
            DemoCode.BackColor = Color.White
        End Try
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

        If Trim(Tbdhid.Text) = "" OrElse Trim(Tbdhname.Text) = "" Then
            Informmessage("กรุณาเลือกโรงย้อม")
            Exit Sub
        End If
        If Trim(Tbdyedbillno.Text) = "" Then
            Informmessage("กรุณาเลือกเลขที่ใบสั่งย้อม")
            Exit Sub
        End If
        If Trim(Tbcolorno.Text) = "" Then
            Informmessage("กรุณาใส่เบอร์สี")
            Tbcolorno.Focus()
            Exit Sub
        End If
        If Trim(Tbrefablotno.Text) = "" Then
            Informmessage("กรุณาใส่ Lot No")
            Tbrefablotno.Focus()
            Exit Sub
        End If
        If Trim(Tbclothid.Text) = "" OrElse Trim(Tbclothno.Text) = "" _
        OrElse Trim(Tbclothtype.Text) = "" OrElse Trim(Tbwidht.Text) = "" _
        OrElse Trim(Tbshadeid.Text) = "" OrElse Trim(Tbshadename.Text) = "" Then
            Informmessage("กรุณาใส่ข้อมูลผ้าให้ครบ")
            Btfindknitid.Focus()
            Exit Sub
        End If
        If Trim(Tbkongno.Text) = "" Then
            Informmessage("กรุณาใส่เบอร์กอง")
            Tbkongno.Focus()
            Exit Sub
        End If
        If Trim(Tbrollid.Text) = "" Then
            Informmessage("กรุณาใส่เบอร์พับ")
            Tbrollid.Focus()
            Exit Sub
        End If
        If Trim(Tbkg.Text) = "" Then
            Informmessage("กรุณาใส่น้ำหนัก")
            Tbkg.Focus()
            Exit Sub
        End If




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
                For i = 0 To Dgvmas.RowCount - 1
                    If Trim(Tbrollid.Text) = Trim(Dgvmas.Rows(i).Cells("rollid").Value) Then
                        Informmessage($"มีเบอร์พับหมายเลข {Dgvmas.Rows(i).Cells("rollid").Value} ในรายแล้ว")
                        Exit Sub
                    End If
                Next

                If Tbdyedcomno.Text = "NEW" Then
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
                Dgvmas.Rows(Dgvmas.RowCount - 1).Cells("News").Value = 1
                Tbkongno.Enabled = False
                Tbkg.Text = ""
                Tbkg.Focus()
            Case "แก้ไข"
                Dim Countnum As Long = 0
                Dim CurrenRow As Long = Dgvmas.CurrentRow.Cells("rollid").Value
                Dgvmas.CurrentRow.Cells("rollid").Value = Trim(Tbrollid.Text)
                For i = 0 To Dgvmas.RowCount - 1
                    If Trim(Tbrollid.Text) = Trim(Dgvmas.Rows(i).Cells("rollid").Value) Then
                        Countnum += 1
                        If Countnum > 1 Then
                            Dgvmas.CurrentRow.Cells("rollid").Value = CurrenRow
                            Informmessage($"มีเบอร์พับหมายเลข {Tbrollid.Text} ในรายแล้ว")
                            Tbrollid.Text = CurrenRow
                            Exit Sub
                        End If
                    End If
                Next

                Tsbwsave.Visible = True
                Btdadd.Enabled = False
                Btdcancel.Enabled = False
                Tbkongno.Enabled = False
                Tbrollid.Enabled = False
                Tbkg.Enabled = False
                Btfindknitid.Enabled = False
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
                ClearDetail()
        End Select
        Sumall()
        'Btdcancel_Click(sender, e)
        'ClearDetail() 'เป้
        If Tbaddedit.Text = "เพิ่ม" Then
            Tbkongno.Text = Dgvmas.Rows(0).Cells("Mkong").Value
            Tbrollid.Text = Trim(rollidnew(Dgvmas, "rollid") + 1)
        End If
        Tbkg.Focus()
    End Sub
    Private Sub Btdcancel_Click(sender As Object, e As EventArgs) Handles Btdcancel.Click
        'Clrtxtbox() ' เป้
        ClearDetail()
        Clrupdet()
        'Tbkongno.Text = ""
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
        'Tbkongno.Text = ""
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
        If Tbdyedcomno.Text = "NEW" And Dgvmas.RowCount = 0 Then
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
        Tlist = SQLCommand("Select '' AS Stat,* FROM Vrecfabcolmas
                                WHERE Comid = '" & Gscomid & "' AND (Billdyedno LIKE '%' + '" & Sval & "' + '%' OR Billknitt LIKE '%' + '" & Sval & "' + '%' OR Reid LIKE '%' + '" & Sval & "' + '%' OR Dremark LIKE '%' + '" & Sval & "' + '%')")
        FillGrid()
        ShowRecordDetail()
    End Sub
    Private Sub Searchlistbydate()
        Tlist = SQLCommand("SELECT '' AS Stat,* FROM Vrecfabcolmas
                                WHERE Comid = '" & Gscomid & "' AND (Recdate BETWEEN '" & Formatshortdatesave(Dtplistfm.Value) & "' AND '" & Formatshortdatesave(Dtplistto.Value) & "')")
        FillGrid()
        ShowRecordDetail()
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
    Private Sub Newdoc()
        If Trim(Tstbdocpre.Text) = "" Then
            Informmessage("กรุณาติดต่อ Admin เพื่อขอเลข Prefix")
            Exit Sub
        End If
        Tbdyedcomno.Text = Trim(Tstbdocpre.Text) & Genid()
        Insertmaster()
        SQLCommand("UPDATE Tdocprexp SET Lvalue = '" & Trim(Tbdyedcomno.Text).Remove(0, 2) & "',Updusr = '" & Gsuserid & "',Uptype = 'E',Uptime = '" & Formatdatesave(Now) & "' 
                        WHERE  Comid = '" & Gscomid & "' AND Docid = '" & Tstbdocpreid.Text & "' AND Prefix = '" & Trim(Tstbdocpre.Text) & "'")
        Upddetails("A")
        If Gsusername = "SUPHATS" Then
        Else
            Insertlog(Gscomid, Gsusergroupid, Gsuserid, Gsusername, "F123", Trim(Tbdyedbillno.Text), "A", "สร้างรายการ รับผ้าสี", Formatdatesave(Now), Computername, Usrproname)
        End If
    End Sub
    Private Sub Editdoc()
        If Tbdyedcomno.Text = "NEW" Then
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
        SQLCommand("INSERT INTO Trecfabcolxp(Comid,Reid,Dhid,Billdyedno,Billknitt,Recdate,Lotno,
                    Dyedcolor,Dremark,Updusr,Uptype,Uptime)
                    VALUES('" & Gscomid & "','" & Trim(Tbdyedcomno.Text) & "','" & Trim(Tbdhid.Text) & "','" & Tbdyedbillno.Text & "','" & Tbknittno.Text & "','" & Formatshortdatesave(Dtprecdate.Value) & "','" & Trim(Tbrefablotno.Text) & "',
                    '" & Tbcolorno.Text & "','" & Trim(Tbremark.Text) & "','" & Gsuserid & "','A','" & Formatdatesave(Now) & "')")
    End Sub
    Private Sub Editmaster()
        SQLCommand("UPDATE Trecfabcolxp SET Dhid = '" & Trim(Tbdhid.Text) & "',Billknitt = '" & Trim(Tbknittno.Text) & "',Recdate = '" & Formatdatesave(Dtprecdate.Value) & "',
                    Dyedcolor = '" & Trim(Tbcolorno.Text) & "',Dremark = '" & Trim(Tbremark.Text) & "',Updusr = '" & Gsuserid & "',
                    Uptype = 'E',Uptime = '" & Formatdatesave(Now) & "'
                    WHERE Comid = '" & Gscomid & "' AND Reid = '" & Trim(Tbdyedcomno.Text) & "'")
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
    ''Private Sub BindingSendDyelist()
    ''    TSendDyelist = New DataTable
    ''    TSendDyelist = SQLCommand("SELECT '' AS Stat,* FROM Vdyedcommas WHERE Comid = '" & Gscomid & "'")
    ''    SendDyelist.DataSource = TSendDyelist
    ''    Bs = New BindingSource
    ''    Bs.DataSource = TSendDyelist
    ''    BindingNavigator1.BindingSource = Bs
    ''    'FillGrid()
    ''    'ShowRecordDetail()
    ''End Sub
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
        'Tbdyedbillno.Enabled = True
        Tbdyedcomno.Text = "NEW"
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
    Private Sub EditBalancelistmenu()
        CtmBalance.Displayed = False
        CtmBalance.PopupMenu(Control.MousePosition)
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
        Tstbsumroll.Text = ""
        Tstbsumkg.Text = ""
        Tbkongno.Text = ""
        Tbrollid.Text = 0
        Tbkg.Text = ""
        Clrdgrid()
        TabControl1.SelectedTabIndex = 1

        Mainbuttoncancel()
        GroupPanel2.Visible = False
        Bindinglist()
        DemoCode.BackColor = Color.White
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
        If Tbdhid.Text <> "" And Tbdhname.Text <> "" And Tbdyedbillno.Text <> "" And Tbcolorno.Text <> "" And Tbrefablotno.Text <> "" Then
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
        If Dgvmas.RowCount > 0 Then
            Tbrollid.Text = Trim(Dgvmas.CurrentRow.Cells("rollid").Value)
            Tbclothid.Text = Trim(Dgvmas.CurrentRow.Cells("Clothid").Value)
            Tbclothno.Text = Trim(Dgvmas.CurrentRow.Cells("Mclothno").Value)
            Tbclothtype.Text = Trim(Dgvmas.CurrentRow.Cells("Clothtype").Value)
            Tbwidht.Text = Trim(Dgvmas.CurrentRow.Cells("Dwidth").Value)
            Tbshadeid.Text = Trim(Dgvmas.CurrentRow.Cells("Shadeid").Value)
            Tbshadename.Text = Trim(Dgvmas.CurrentRow.Cells("Shadedesc").Value)
            Tbkongno.Text = Trim(Dgvmas.CurrentRow.Cells("Mkong").Value)
            Tbkg.Text = Format(Dgvmas.CurrentRow.Cells("Rollwage").Value, "###,###.#0")
            DemoColor(Tbshadeid.Text)
        Else
            ClearDetail()
            Tbkongno.Enabled = False
            Tbrollid.Enabled = False
            Tbkg.Enabled = False
            Btdadd.Enabled = False
            Btdcancel.Enabled = False
            Btfindknitid.Enabled = False
            Tbkg.Text = ""
            DemoCode.BackColor = Color.White
            Exit Sub
        End If

        Btdadd.Enabled = True
        Btdcancel.Enabled = True
        Tbkongno.Enabled = True
        Tbrollid.Enabled = True
        Tbkg.Enabled = True
        Btfindknitid.Enabled = True
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
        Dim Frm As New FormknittnolistOld
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
        Tbrefablotno.Enabled = False
        Dtprecdate.Enabled = True
        Tbremark.Enabled = True
        Tbkongno.Text = ""
        Tbkg.Text = ""
        'Dtprecdate.Value = Now
        Tsbwsave.Visible = False
        Btmsave.Enabled = True
        Btmreports.Enabled = False
        Btmdel.Enabled = False
        Btfinddyedh.Enabled = True
        'Btfindbillno.Enabled = True
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
        Tbaddedit.Text = "เพิ่ม"
        GroupPanel2.Visible = True
        ClearDetail()

        If Dgvmas.RowCount > 0 Then
            Tbkongno.Enabled = False
            Tbkongno.Text = Dgvmas.Rows(0).Cells("Mkong").Value
        Else
            Tbkongno.Enabled = True
        End If
        Tbrollid.Text = Trim(rollidnew(Dgvmas, "rollid") + 1)
        Btdadd.Enabled = True
        Btdcancel.Enabled = True
        'Tbkongno.Enabled = True
        Tbrollid.Enabled = True
        Tbkg.Enabled = True
        Btfindknitid.Enabled = True
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

    Private Sub Btmreports_Click(sender As Object, e As EventArgs) Handles Btmreports.Click
        If Dgvmas.RowCount = 0 Then
            Exit Sub
        End If
        If Tsbwsave.Visible = True Then
            Informmessage("มีการเปลี่ยนแปลงและยังไม่ทำการบันทึก")
            Exit Sub
        End If
        Dim Frm As New FormreceivefabrptOld
        For i = 0 To Dgvmas.Rows.Count - 1

            Frm.Dgvmas.Rows.Add()
            Frm.Dgvmas.Rows(i).Cells("rollid").Value = Dgvmas.Rows(i).Cells("rollid").Value
            Frm.Dgvmas.Rows(i).Cells("Mclothno").Value = Dgvmas.Rows(i).Cells("Mclothno").Value
            Frm.Dgvmas.Rows(i).Cells("Clothtype").Value = Dgvmas.Rows(i).Cells("Clothtype").Value
            Frm.Dgvmas.Rows(i).Cells("Dwidth").Value = Dgvmas.Rows(i).Cells("Dwidth").Value
            Frm.Dgvmas.Rows(i).Cells("Mkong").Value = Dgvmas.Rows(i).Cells("Mkong").Value
            Frm.Dgvmas.Rows(i).Cells("Rollwage").Value = Dgvmas.Rows(i).Cells("Rollwage").Value
        Next
        Frm.Tbdhid.Text = Tbdhid.Text
        Frm.Tbdhname.Text = Tbdhname.Text
        Frm.Tbdyedbillno.Text = Tbdyedbillno.Text
        Frm.Tbknittno.Text = Tbknittno.Text
        Frm.Tbcolorno.Text = Tbcolorno.Text
        Frm.Tbrefablotno.Text = Tbrefablotno.Text
        Frm.Tbdyedcomno.Text = Tbdyedcomno.Text
        Frm.Tbremark.Text = Tbremark.Text
        Frm.Tbdate.Text = Dtprecdate.Text

        Countfabric.Rows.Clear()
        CountfabricFilter()
        For i = 0 To Countfabric.Rows.Count - 1
            Frm.Countfabric.Rows.Add()
            Frm.Countfabric.Rows(i).Cells("Cclothno").Value = Countfabric.Rows(i).Cells("Cclothno").Value
            Frm.Countfabric.Rows(i).Cells("Cclothtype").Value = Countfabric.Rows(i).Cells("Cclothtype").Value
            Frm.Countfabric.Rows(i).Cells("CDwidth").Value = Countfabric.Rows(i).Cells("CDwidth").Value
            Frm.Countfabric.Rows(i).Cells("Count").Value = Countfabric.Rows(i).Cells("Count").Value
            Frm.Countfabric.Rows(i).Cells("CRollwage").Value = Countfabric.Rows(i).Cells("CRollwage").Value
        Next

        Frm.ReportViewer1.Reset()
        Frm.Show()
        Clrtxtbox()
        Clrdgrid()
        BindingNavigator1.Enabled = False
        Mainbuttoncancel()
        TabControl1.SelectedTabIndex = 1
        Countfabric.Rows.Clear()
        Btmcancel_Click(sender, e)
    End Sub

    Private Sub CountfabricFilter()

        Dim Frm As New FormreceivefabrptOld
        Countfabric.Rows.Add("")
        Dim Count As Long = 1
        Dim CountSum As Long = 0
        For I = 0 To Dgvmas.RowCount - 1
            For Filters = 0 To Countfabric.Rows.Count - 1
                If Countfabric.Rows(Filters).Cells("Cclothno").Value.ToString.ToUpper = Dgvmas.Rows(I).Cells("Mclothno").Value.ToString.ToUpper AndAlso
                   Countfabric.Rows(Filters).Cells("Cclothtype").Value.ToString.ToUpper = Dgvmas.Rows(I).Cells("Clothtype").Value.ToString.ToUpper AndAlso
                   Countfabric.Rows(Filters).Cells("CDwidth").Value.ToString.ToUpper = Dgvmas.Rows(I).Cells("Dwidth").Value.ToString.ToUpper Then
                    Countfabric.Rows(Filters).Cells("Count").Value += 1
                    Countfabric.Rows(Filters).Cells("CRollwage").Value += Dgvmas.Rows(I).Cells("Rollwage").Value
                    Exit For
                End If


                If Filters = Countfabric.Rows.Count - 1 Then
                    If Countfabric.Rows(Countfabric.Rows.Count - 1).Cells("Cclothno").Value.ToString.ToUpper <> "" Then
                        Countfabric.Rows.Add("")
                    End If
                    Countfabric.Rows(CountSum).Cells("Cclothno").Value = Dgvmas.Rows(I).Cells("Mclothno").Value
                    Countfabric.Rows(CountSum).Cells("Cclothtype").Value = Dgvmas.Rows(I).Cells("Clothtype").Value
                    Countfabric.Rows(CountSum).Cells("CDwidth").Value = Dgvmas.Rows(I).Cells("Dwidth").Value
                    Countfabric.Rows(CountSum).Cells("Count").Value = Count
                    Countfabric.Rows(CountSum).Cells("CRollwage").Value = Dgvmas.Rows(I).Cells("Rollwage").Value
                    CountSum += 1
                End If
            Next
        Next
        'If Countfabric.Rows(Countfabric.Rows.Count - 1).Cells("Cclothno").Value = "" Then
        '    For i = 0 To Countfabric.Rows.Count - 1
        '        If i = Countfabric.Rows.Count - 1 Then
        '            'Countfabric.Rows.Remove(Countfabric.SelectedRows(i))
        '        End If
        '    Next
        'End If

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
            Filterfab.Rows(i).Cells("FBilldyedno").Value = BilldyednoArray(PontArray)
            Filterfab.Rows(i).Cells("FClothid").Value = ClothidArray(PontArray)
            Filterfab.Rows(i).Cells("Clothno").Value = ClothnoArray(PontArray)
            Filterfab.Rows(i).Cells("Ftype").Value = FtypeArray(PontArray)
            Filterfab.Rows(i).Cells("Fwidth").Value = FwidthArray(PontArray)
            Filterfab.Rows(i).Cells("FRollwage").Value = RollwageArray(PontArray)
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
            FilterAllyed.Rows(i).Cells("FShadeid").Value = ShadeidArray(PontArray)
            FilterAllyed.Rows(i).Cells("FShadedesc").Value = ShadedescArray(PontArray)
        Next
    End Sub

    Private Sub FilterMaster()
        For i = 0 To FilterAllyed.Rows.Count - 1
            Balance.Rows.Add()
            Balance.Rows(i).Cells("BDyedcomno").Value = FilterAllyed.Rows(i).Cells("Dyedcomno").Value
            Balance.Rows(i).Cells("BClothidyed").Value = FilterAllyed.Rows(i).Cells("Clothidyed").Value
            Balance.Rows(i).Cells("BClothnoyed").Value = FilterAllyed.Rows(i).Cells("Clothnoyed").Value
            Balance.Rows(i).Cells("BFtypeyed").Value = FilterAllyed.Rows(i).Cells("Ftypeyed").Value
            Balance.Rows(i).Cells("BFwidthyed").Value = FilterAllyed.Rows(i).Cells("Fwidthyed").Value
            Balance.Rows(i).Cells("BQtykg").Value = FilterAllyed.Rows(i).Cells("Qtykg").Value
            Balance.Rows(i).Cells("BQtyroll").Value = FilterAllyed.Rows(i).Cells("Qtyroll").Value
            Balance.Rows(i).Cells("BShadeid").Value = FilterAllyed.Rows(i).Cells("FShadeid").Value
            Balance.Rows(i).Cells("BShadedesc").Value = FilterAllyed.Rows(i).Cells("FShadedesc").Value
        Next

        For i = 0 To Filterfab.Rows.Count - 1
            For Balan = 0 To Balance.Rows.Count - 1
                If Filterfab.Rows(i).Cells("FBilldyedno").Value = Balance.Rows(Balan).Cells("BDyedcomno").Value And
                      Filterfab.Rows(i).Cells("FClothid").Value = Balance.Rows(Balan).Cells("BClothidyed").Value And
                      Filterfab.Rows(i).Cells("Fwidth").Value = Balance.Rows(Balan).Cells("BFwidthyed").Value Then
                    Balance.Rows(Balan).Cells("BQtyroll").Value = FilterAllyed.Rows(Balan).Cells("Qtyroll").Value - Filterfab.Rows(i).Cells("Qtyrollfab").Value
                    Balance.Rows(Balan).Cells("BQtykg").Value = FilterAllyed.Rows(Balan).Cells("Qtykg").Value - Filterfab.Rows(i).Cells("FRollwage").Value
                End If
            Next
        Next

        For i = 0 To Balance.Rows.Count - 1
            If i <= Balance.Rows.Count - 1 Then
                If Balance.Rows(i).Cells("BQtyroll").Value <= 0 Then
                    Balance.Rows.RemoveAt(i)
                    i -= 1
                End If
            End If
        Next

    End Sub

    Private Sub BindingBalance()
        Filterfab.Rows.Clear()
        FilterAllyed.Rows.Clear()
        Balance.Rows.Clear()
        Bindinglistfab()
        Bindinglistyed()
        FilterfabGrid()
        FilteryedGrid()
        FilterMaster()
    End Sub

    Private Sub Filtermastergrid()
        If Trim(ToolStripTextBox3.Text) = "" Then
            BindingBalance()
            Exit Sub
        End If
        FilterAllyed.Rows.Clear()
        Balance.Rows.Clear()
        tlistyed.DefaultView.RowFilter = String.Format("Dyedcomno Like '%{0}%' or Clothno Like '%{0}%' or Ftype Like '%{0}%' or Fwidth Like '%{0}%'", Trim(ToolStripTextBox3.Text))
        FilteryedGrid()
        FilterMaster()
    End Sub


    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles ButtonItem2.Click
        Btmnew_Click(sender, e)
        Btdbadd_Click(sender, e)
        Tbdyedbillno.Text = Trim(Balance.CurrentRow.Cells("BDyedcomno").Value)
        Tbclothid.Text = Trim(Balance.CurrentRow.Cells("BClothidyed").Value)
        Tbclothno.Text = Trim(Balance.CurrentRow.Cells("BClothnoyed").Value)
        Tbclothtype.Text = Trim(Balance.CurrentRow.Cells("BFtypeyed").Value)
        Tbwidht.Text = Trim(Balance.CurrentRow.Cells("BFwidthyed").Value)
        Tbshadeid.Text = Trim(Balance.CurrentRow.Cells("BShadeid").Value)
        Tbshadename.Text = Trim(Balance.CurrentRow.Cells("BShadedesc").Value)
        DemoColor(Tbshadeid.Text)
        Bindinglistnittno()
        Bindingnamebill()
        Tstbsumroll.Text = ""
    End Sub

    Private Sub Bindinglistnittno()
        tlistnittno = New DataTable
        tlistnittno = SQLCommand($"SELECT DISTINCT Knittbill FROM Vdyedcomdet
                                    WHERE Dyedcomno = '{Tbdyedbillno.Text}' AND Comid = '{Gscomid}'")
        For i = 0 To tlistnittno.Rows.Count - 1
            If i > 0 Then
                Tbknittno.Text += ","
            End If
            Tbknittno.Text += tlistnittno(i)(0)
        Next
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Dim Frm As New FormsheadbyfabOld
        Showdiaformcenter(Frm, Me)
        If Frm.Tbcancel.Text = "C" Then
            Exit Sub
        End If
        Tbshadeid.Text = CLng(Frm.Dgvmas.CurrentRow.Cells("Mid").Value)
        Tbshadename.Text = Trim(Frm.Dgvmas.CurrentRow.Cells("Shade").Value)
    End Sub

    Private Sub Bindingnamebill()
        tlistnamebill = New DataTable
        tlistnamebill = SQLCommand($"SELECT Dyedhid, Dyedhdesc FROM Tdyedhousexp
                                        WHERE Comid = '101' AND Dyedhid = (SELECT Dhid FROM Tdyedcomxp
                                        WHERE Dyecomno = '{Tbdyedbillno.Text}' AND Comid = '101')
                                        AND Sstatus = 1 AND Sactive = '1'")
        'MsgBox(tlistnamebill(0)(0))
        Tbdhid.Text = tlistnamebill(0)(0)
        Tbdhname.Text = tlistnamebill(0)(1)
    End Sub

    Private Sub ToolStripTextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ToolStripTextBox3.KeyPress
        e.Handled = (Asc(e.KeyChar) = 39)
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        BindingBalance()
    End Sub

    Private Sub ToolStripTextBox3_TextChanged(sender As Object, e As EventArgs) Handles ToolStripTextBox3.TextChanged
        Balancefind_Click(sender, e)
    End Sub

    Private Sub Balancefind_Click(sender As Object, e As EventArgs) Handles Balancefind.Click
        Filtermastergrid()
    End Sub

    Private Sub Btddel_Click_1(sender As Object, e As EventArgs) Handles Btddel.Click
        If Dgvmas.RowCount = 0 Then
            Exit Sub
        End If
        Dgvmas.Rows.Remove(Dgvmas.CurrentRow)
        Sumall()
        Btdcancel_Click(sender, e)
        Tsbwsave.Visible = True

        Tbkongno.Enabled = False
        Btfindknitid.Enabled = False
        Tbrollid.Enabled = False
        Tbkg.Enabled = False
        Btdadd.Enabled = False
        Btdcancel.Enabled = False
        DemoCode.BackColor = Color.White
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
        Btfinddyedh.Enabled = True
        Btfindbillno.Enabled = True
        Btfindknittno.Enabled = True
        Btdbadd.Enabled = True
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
        Tbdyedcomno.Text = "NEW"
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