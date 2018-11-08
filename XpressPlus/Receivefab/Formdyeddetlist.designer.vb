<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Formdyeddetlist
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl()
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
        Me.Dgvmas = New System.Windows.Forms.DataGridView()
        Me.BDyedcomno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BClothidyed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BClothnoyed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BFtypeyed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BFwidthyed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BQtyroll = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BQtykg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BShadeid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BShadedesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FilterAllyed = New System.Windows.Forms.DataGridView()
        Me.Dyedcomno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Clothidyed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Clothnoyed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ftypeyed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fwidthyed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qtykg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qtyroll = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Knittcomid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Knittbill = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Shadeid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Shadedesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Filterfab = New System.Windows.Forms.DataGridView()
        Me.Billdyedno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Clothid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Clothno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ftype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fwidth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rollwage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qtyrollfab = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Allyed = New System.Windows.Forms.DataGridView()
        Me.Allfab = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Btmsearch = New System.Windows.Forms.ToolStripButton()
        Me.Tbkeyword = New System.Windows.Forms.ToolStripTextBox()
        Me.Tbcancel = New System.Windows.Forms.ToolStripTextBox()
        Me.Tbknitbill = New System.Windows.Forms.ToolStripTextBox()
        Me.Tbdyedbillno = New System.Windows.Forms.ToolStripTextBox()
        Me.Btcancel = New DevComponents.DotNetBar.ButtonX()
        Me.Btok = New DevComponents.DotNetBar.ButtonX()
        Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        CType(Me.Dgvmas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FilterAllyed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Filterfab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Allyed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Allfab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControl1.CanReorderTabs = True
        Me.TabControl1.Controls.Add(Me.TabControlPanel1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.ForeColor = System.Drawing.Color.Black
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl1.SelectedTabIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(757, 331)
        Me.TabControl1.TabIndex = 9
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.TabItem1)
        Me.TabControl1.Text = "TabControl1"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.Dgvmas)
        Me.TabControlPanel1.Controls.Add(Me.FilterAllyed)
        Me.TabControlPanel1.Controls.Add(Me.Filterfab)
        Me.TabControlPanel1.Controls.Add(Me.Allyed)
        Me.TabControlPanel1.Controls.Add(Me.Allfab)
        Me.TabControlPanel1.Controls.Add(Me.ToolStrip1)
        Me.TabControlPanel1.Controls.Add(Me.Btcancel)
        Me.TabControlPanel1.Controls.Add(Me.Btok)
        Me.TabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(757, 305)
        Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabIndex = 1
        Me.TabControlPanel1.TabItem = Me.TabItem1
        '
        'Dgvmas
        '
        Me.Dgvmas.AllowUserToAddRows = False
        Me.Dgvmas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dgvmas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgvmas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BDyedcomno, Me.BClothidyed, Me.BClothnoyed, Me.BFtypeyed, Me.BFwidthyed, Me.BQtyroll, Me.BQtykg, Me.BShadeid, Me.BShadedesc})
        Me.Dgvmas.Location = New System.Drawing.Point(12, 53)
        Me.Dgvmas.Name = "Dgvmas"
        Me.Dgvmas.ReadOnly = True
        Me.Dgvmas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgvmas.Size = New System.Drawing.Size(735, 175)
        Me.Dgvmas.TabIndex = 33
        '
        'BDyedcomno
        '
        Me.BDyedcomno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.BDyedcomno.HeaderText = "เลขที่ใบสั่งย้อม"
        Me.BDyedcomno.Name = "BDyedcomno"
        Me.BDyedcomno.ReadOnly = True
        '
        'BClothidyed
        '
        Me.BClothidyed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.BClothidyed.HeaderText = "Clothidyed"
        Me.BClothidyed.Name = "BClothidyed"
        Me.BClothidyed.ReadOnly = True
        Me.BClothidyed.Visible = False
        '
        'BClothnoyed
        '
        Me.BClothnoyed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.BClothnoyed.HeaderText = "เบอร์ผ้า"
        Me.BClothnoyed.Name = "BClothnoyed"
        Me.BClothnoyed.ReadOnly = True
        '
        'BFtypeyed
        '
        Me.BFtypeyed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.BFtypeyed.HeaderText = "ประเภทผ้า"
        Me.BFtypeyed.Name = "BFtypeyed"
        Me.BFtypeyed.ReadOnly = True
        '
        'BFwidthyed
        '
        Me.BFwidthyed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.BFwidthyed.DefaultCellStyle = DataGridViewCellStyle1
        Me.BFwidthyed.HeaderText = "หน้ากว้าง"
        Me.BFwidthyed.Name = "BFwidthyed"
        Me.BFwidthyed.ReadOnly = True
        '
        'BQtyroll
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.BQtyroll.DefaultCellStyle = DataGridViewCellStyle2
        Me.BQtyroll.HeaderText = "พับคงเหลือ"
        Me.BQtyroll.Name = "BQtyroll"
        Me.BQtyroll.ReadOnly = True
        '
        'BQtykg
        '
        Me.BQtykg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.BQtykg.DefaultCellStyle = DataGridViewCellStyle3
        Me.BQtykg.HeaderText = "น้ำหนักคงเหลือ"
        Me.BQtykg.Name = "BQtykg"
        Me.BQtykg.ReadOnly = True
        Me.BQtykg.Visible = False
        '
        'BShadeid
        '
        Me.BShadeid.HeaderText = "BShadeid"
        Me.BShadeid.Name = "BShadeid"
        Me.BShadeid.ReadOnly = True
        Me.BShadeid.Visible = False
        '
        'BShadedesc
        '
        Me.BShadedesc.HeaderText = "BShadedesc"
        Me.BShadedesc.Name = "BShadedesc"
        Me.BShadedesc.ReadOnly = True
        Me.BShadedesc.Visible = False
        '
        'FilterAllyed
        '
        Me.FilterAllyed.AllowUserToAddRows = False
        Me.FilterAllyed.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FilterAllyed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.FilterAllyed.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Dyedcomno, Me.Clothidyed, Me.Clothnoyed, Me.Ftypeyed, Me.Fwidthyed, Me.Qtykg, Me.Qtyroll, Me.Knittcomid, Me.Knittbill, Me.Shadeid, Me.Shadedesc})
        Me.FilterAllyed.Location = New System.Drawing.Point(607, 143)
        Me.FilterAllyed.Name = "FilterAllyed"
        Me.FilterAllyed.Size = New System.Drawing.Size(138, 85)
        Me.FilterAllyed.TabIndex = 32
        '
        'Dyedcomno
        '
        Me.Dyedcomno.HeaderText = "Dyedcomno"
        Me.Dyedcomno.Name = "Dyedcomno"
        '
        'Clothidyed
        '
        Me.Clothidyed.HeaderText = "Clothidyed"
        Me.Clothidyed.Name = "Clothidyed"
        '
        'Clothnoyed
        '
        Me.Clothnoyed.HeaderText = "Clothnoyed"
        Me.Clothnoyed.Name = "Clothnoyed"
        '
        'Ftypeyed
        '
        Me.Ftypeyed.HeaderText = "Ftypeyed"
        Me.Ftypeyed.Name = "Ftypeyed"
        '
        'Fwidthyed
        '
        Me.Fwidthyed.HeaderText = "Fwidthyed"
        Me.Fwidthyed.Name = "Fwidthyed"
        '
        'Qtykg
        '
        Me.Qtykg.HeaderText = "Qtykg"
        Me.Qtykg.Name = "Qtykg"
        '
        'Qtyroll
        '
        Me.Qtyroll.HeaderText = "Qtyroll"
        Me.Qtyroll.Name = "Qtyroll"
        '
        'Knittcomid
        '
        Me.Knittcomid.HeaderText = "Knittcomid"
        Me.Knittcomid.Name = "Knittcomid"
        '
        'Knittbill
        '
        Me.Knittbill.HeaderText = "Knittbill"
        Me.Knittbill.Name = "Knittbill"
        '
        'Shadeid
        '
        Me.Shadeid.HeaderText = "Shadeid"
        Me.Shadeid.Name = "Shadeid"
        '
        'Shadedesc
        '
        Me.Shadedesc.HeaderText = "Shadedesc"
        Me.Shadedesc.Name = "Shadedesc"
        '
        'Filterfab
        '
        Me.Filterfab.AllowUserToAddRows = False
        Me.Filterfab.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Filterfab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Filterfab.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Billdyedno, Me.Clothid, Me.Clothno, Me.Ftype, Me.Fwidth, Me.Rollwage, Me.Qtyrollfab})
        Me.Filterfab.Location = New System.Drawing.Point(609, 58)
        Me.Filterfab.Name = "Filterfab"
        Me.Filterfab.Size = New System.Drawing.Size(138, 79)
        Me.Filterfab.TabIndex = 31
        '
        'Billdyedno
        '
        Me.Billdyedno.HeaderText = "Billdyedno"
        Me.Billdyedno.Name = "Billdyedno"
        '
        'Clothid
        '
        Me.Clothid.HeaderText = "Clothid"
        Me.Clothid.Name = "Clothid"
        '
        'Clothno
        '
        Me.Clothno.HeaderText = "Clothno"
        Me.Clothno.Name = "Clothno"
        '
        'Ftype
        '
        Me.Ftype.HeaderText = "Ftype"
        Me.Ftype.Name = "Ftype"
        '
        'Fwidth
        '
        Me.Fwidth.HeaderText = "Fwidth"
        Me.Fwidth.Name = "Fwidth"
        '
        'Rollwage
        '
        Me.Rollwage.HeaderText = "Rollwage"
        Me.Rollwage.Name = "Rollwage"
        '
        'Qtyrollfab
        '
        Me.Qtyrollfab.HeaderText = "Qtyrollfab"
        Me.Qtyrollfab.Name = "Qtyrollfab"
        '
        'Allyed
        '
        Me.Allyed.AllowUserToAddRows = False
        Me.Allyed.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Allyed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Allyed.Location = New System.Drawing.Point(559, 143)
        Me.Allyed.Name = "Allyed"
        Me.Allyed.Size = New System.Drawing.Size(42, 85)
        Me.Allyed.TabIndex = 30
        '
        'Allfab
        '
        Me.Allfab.AllowUserToAddRows = False
        Me.Allfab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Allfab.Location = New System.Drawing.Point(561, 58)
        Me.Allfab.Name = "Allfab"
        Me.Allfab.Size = New System.Drawing.Size(42, 79)
        Me.Allfab.TabIndex = 29
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Btmsearch, Me.Tbkeyword, Me.Tbcancel, Me.Tbknitbill, Me.Tbdyedbillno})
        Me.ToolStrip1.Location = New System.Drawing.Point(1, 1)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(755, 49)
        Me.ToolStrip1.TabIndex = 28
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Btmsearch
        '
        Me.Btmsearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Btmsearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Btmsearch.Image = Global.XpressPlus.My.Resources.Resources.Findicon
        Me.Btmsearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Btmsearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btmsearch.Name = "Btmsearch"
        Me.Btmsearch.Size = New System.Drawing.Size(48, 46)
        Me.Btmsearch.Text = "ค้นหา"
        Me.Btmsearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Tbkeyword
        '
        Me.Tbkeyword.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Tbkeyword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Tbkeyword.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tbkeyword.Name = "Tbkeyword"
        Me.Tbkeyword.Size = New System.Drawing.Size(120, 49)
        '
        'Tbcancel
        '
        Me.Tbcancel.Name = "Tbcancel"
        Me.Tbcancel.Size = New System.Drawing.Size(25, 49)
        Me.Tbcancel.Visible = False
        '
        'Tbknitbill
        '
        Me.Tbknitbill.Name = "Tbknitbill"
        Me.Tbknitbill.Size = New System.Drawing.Size(25, 49)
        Me.Tbknitbill.Visible = False
        '
        'Tbdyedbillno
        '
        Me.Tbdyedbillno.Name = "Tbdyedbillno"
        Me.Tbdyedbillno.Size = New System.Drawing.Size(25, 49)
        Me.Tbdyedbillno.Visible = False
        '
        'Btcancel
        '
        Me.Btcancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btcancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btcancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Btcancel.Location = New System.Drawing.Point(420, 245)
        Me.Btcancel.Name = "Btcancel"
        Me.Btcancel.Size = New System.Drawing.Size(73, 34)
        Me.Btcancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.Btcancel.TabIndex = 1
        Me.Btcancel.Text = "ยกเลิก"
        '
        'Btok
        '
        Me.Btok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btok.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btok.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Btok.Location = New System.Drawing.Point(245, 245)
        Me.Btok.Name = "Btok"
        Me.Btok.Size = New System.Drawing.Size(73, 34)
        Me.Btok.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.Btok.TabIndex = 0
        Me.Btok.Text = "ตกลง"
        '
        'TabItem1
        '
        Me.TabItem1.AttachedControl = Me.TabControlPanel1
        Me.TabItem1.Name = "TabItem1"
        Me.TabItem1.Text = "สั่งย้อม"
        '
        'Formdyeddetlist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(757, 331)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Formdyeddetlist"
        Me.Text = "รายการ สั่งย้อม"
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabControlPanel1.ResumeLayout(False)
        Me.TabControlPanel1.PerformLayout()
        CType(Me.Dgvmas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FilterAllyed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Filterfab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Allyed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Allfab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Btmsearch As ToolStripButton
    Friend WithEvents Tbkeyword As ToolStripTextBox
    Friend WithEvents Tbcancel As ToolStripTextBox
    Friend WithEvents Btcancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btok As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents Tbknitbill As ToolStripTextBox
    Friend WithEvents Tbdyedbillno As ToolStripTextBox
    Friend WithEvents Dgvmas As DataGridView
    Friend WithEvents FilterAllyed As DataGridView
    Friend WithEvents Filterfab As DataGridView
    Friend WithEvents Billdyedno As DataGridViewTextBoxColumn
    Friend WithEvents Clothid As DataGridViewTextBoxColumn
    Friend WithEvents Clothno As DataGridViewTextBoxColumn
    Friend WithEvents Ftype As DataGridViewTextBoxColumn
    Friend WithEvents Fwidth As DataGridViewTextBoxColumn
    Friend WithEvents Rollwage As DataGridViewTextBoxColumn
    Friend WithEvents Qtyrollfab As DataGridViewTextBoxColumn
    Friend WithEvents Allyed As DataGridView
    Friend WithEvents Allfab As DataGridView
    Friend WithEvents Dyedcomno As DataGridViewTextBoxColumn
    Friend WithEvents Clothidyed As DataGridViewTextBoxColumn
    Friend WithEvents Clothnoyed As DataGridViewTextBoxColumn
    Friend WithEvents Ftypeyed As DataGridViewTextBoxColumn
    Friend WithEvents Fwidthyed As DataGridViewTextBoxColumn
    Friend WithEvents Qtykg As DataGridViewTextBoxColumn
    Friend WithEvents Qtyroll As DataGridViewTextBoxColumn
    Friend WithEvents Knittcomid As DataGridViewTextBoxColumn
    Friend WithEvents Knittbill As DataGridViewTextBoxColumn
    Friend WithEvents Shadeid As DataGridViewTextBoxColumn
    Friend WithEvents Shadedesc As DataGridViewTextBoxColumn
    Friend WithEvents BDyedcomno As DataGridViewTextBoxColumn
    Friend WithEvents BClothidyed As DataGridViewTextBoxColumn
    Friend WithEvents BClothnoyed As DataGridViewTextBoxColumn
    Friend WithEvents BFtypeyed As DataGridViewTextBoxColumn
    Friend WithEvents BFwidthyed As DataGridViewTextBoxColumn
    Friend WithEvents BQtyroll As DataGridViewTextBoxColumn
    Friend WithEvents BQtykg As DataGridViewTextBoxColumn
    Friend WithEvents BShadeid As DataGridViewTextBoxColumn
    Friend WithEvents BShadedesc As DataGridViewTextBoxColumn
End Class
