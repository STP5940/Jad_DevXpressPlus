<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Formreceivefabrpt
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Btmclose = New System.Windows.Forms.ToolStripButton()
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl()
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
        Me.Countfabric = New System.Windows.Forms.DataGridView()
        Me.Cclothno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cclothtype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CDwidth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Count = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CRollwage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tbdyedcomno = New Normtextbox.Normtextbox()
        Me.Tbdhname = New Normtextbox.Normtextbox()
        Me.Tbdhid = New Normtextbox.Normtextbox()
        Me.Tbcolorno = New Normtextbox.Normtextbox()
        Me.Tbdyedbillno = New Normtextbox.Normtextbox()
        Me.Tbrefablotno = New Normtextbox.Normtextbox()
        Me.Tbknittno = New Normtextbox.Normtextbox()
        Me.Dgvmas = New System.Windows.Forms.DataGridView()
        Me.Mstat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rollid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mcomid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Order = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dhid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mdyedhdesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Billdyedno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lotno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Clothid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mclothno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Clothtype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dwidth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Shadeid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Shadedesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mkong = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rollwage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Instk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Tbremark = New System.Windows.Forms.TextBox()
        Me.Tbredate = New System.Windows.Forms.TextBox()
        Me.Tbknitcomno = New System.Windows.Forms.TextBox()
        Me.Tbto = New System.Windows.Forms.TextBox()
        Me.Tbdate = New System.Windows.Forms.TextBox()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.ToolStrip1.SuspendLayout()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        CType(Me.Countfabric, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgvmas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Btmclose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1008, 47)
        Me.ToolStrip1.TabIndex = 71
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Btmclose
        '
        Me.Btmclose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Btmclose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btmclose.Image = Global.XpressPlus.My.Resources.Resources.Closewin
        Me.Btmclose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Btmclose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btmclose.Name = "Btmclose"
        Me.Btmclose.Size = New System.Drawing.Size(28, 44)
        Me.Btmclose.Text = "ปิด"
        Me.Btmclose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'TabControl1
        '
        Me.TabControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControl1.CanReorderTabs = True
        Me.TabControl1.Controls.Add(Me.TabControlPanel1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TabControl1.ForeColor = System.Drawing.Color.Black
        Me.TabControl1.Location = New System.Drawing.Point(0, 47)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl1.SelectedTabIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1008, 682)
        Me.TabControl1.TabIndex = 72
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.TabItem1)
        Me.TabControl1.Text = "TabControl1"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.Countfabric)
        Me.TabControlPanel1.Controls.Add(Me.Tbdyedcomno)
        Me.TabControlPanel1.Controls.Add(Me.Tbdhname)
        Me.TabControlPanel1.Controls.Add(Me.Tbdhid)
        Me.TabControlPanel1.Controls.Add(Me.Tbcolorno)
        Me.TabControlPanel1.Controls.Add(Me.Tbdyedbillno)
        Me.TabControlPanel1.Controls.Add(Me.Tbrefablotno)
        Me.TabControlPanel1.Controls.Add(Me.Tbknittno)
        Me.TabControlPanel1.Controls.Add(Me.Dgvmas)
        Me.TabControlPanel1.Controls.Add(Me.TextBox1)
        Me.TabControlPanel1.Controls.Add(Me.Tbremark)
        Me.TabControlPanel1.Controls.Add(Me.Tbredate)
        Me.TabControlPanel1.Controls.Add(Me.Tbknitcomno)
        Me.TabControlPanel1.Controls.Add(Me.Tbto)
        Me.TabControlPanel1.Controls.Add(Me.Tbdate)
        Me.TabControlPanel1.Controls.Add(Me.ReportViewer1)
        Me.TabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(1008, 656)
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
        'Countfabric
        '
        Me.Countfabric.AllowUserToAddRows = False
        Me.Countfabric.AllowUserToDeleteRows = False
        Me.Countfabric.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Countfabric.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cclothno, Me.Cclothtype, Me.CDwidth, Me.Count, Me.CRollwage})
        Me.Countfabric.Location = New System.Drawing.Point(471, 451)
        Me.Countfabric.Name = "Countfabric"
        Me.Countfabric.Size = New System.Drawing.Size(525, 86)
        Me.Countfabric.TabIndex = 130
        Me.Countfabric.Visible = False
        '
        'Cclothno
        '
        Me.Cclothno.HeaderText = "เบอร์ผ้า"
        Me.Cclothno.Name = "Cclothno"
        '
        'Cclothtype
        '
        Me.Cclothtype.HeaderText = "ประเภทผ้า"
        Me.Cclothtype.Name = "Cclothtype"
        '
        'CDwidth
        '
        Me.CDwidth.HeaderText = "หน้ากว้าง"
        Me.CDwidth.Name = "CDwidth"
        '
        'Count
        '
        Me.Count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Count.HeaderText = "Count"
        Me.Count.Name = "Count"
        '
        'CRollwage
        '
        Me.CRollwage.HeaderText = "CRollwage"
        Me.CRollwage.Name = "CRollwage"
        '
        'Tbdyedcomno
        '
        Me.Tbdyedcomno.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tbdyedcomno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Tbdyedcomno.Enabled = False
        Me.Tbdyedcomno.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tbdyedcomno.Location = New System.Drawing.Point(929, 408)
        Me.Tbdyedcomno.MaxLength = 150
        Me.Tbdyedcomno.Name = "Tbdyedcomno"
        Me.Tbdyedcomno.Size = New System.Drawing.Size(67, 24)
        Me.Tbdyedcomno.TabIndex = 73
        Me.Tbdyedcomno.Text = "NEW"
        Me.Tbdyedcomno.Visible = False
        '
        'Tbdhname
        '
        Me.Tbdhname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Tbdhname.Enabled = False
        Me.Tbdhname.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Tbdhname.Location = New System.Drawing.Point(929, 318)
        Me.Tbdhname.MaxLength = 150
        Me.Tbdhname.Name = "Tbdhname"
        Me.Tbdhname.Size = New System.Drawing.Size(67, 24)
        Me.Tbdhname.TabIndex = 129
        Me.Tbdhname.Visible = False
        '
        'Tbdhid
        '
        Me.Tbdhid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Tbdhid.Enabled = False
        Me.Tbdhid.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Tbdhid.Location = New System.Drawing.Point(851, 318)
        Me.Tbdhid.MaxLength = 150
        Me.Tbdhid.Name = "Tbdhid"
        Me.Tbdhid.Size = New System.Drawing.Size(72, 24)
        Me.Tbdhid.TabIndex = 128
        Me.Tbdhid.Visible = False
        '
        'Tbcolorno
        '
        Me.Tbcolorno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Tbcolorno.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Tbcolorno.Location = New System.Drawing.Point(851, 378)
        Me.Tbcolorno.MaxLength = 80
        Me.Tbcolorno.Name = "Tbcolorno"
        Me.Tbcolorno.Size = New System.Drawing.Size(72, 24)
        Me.Tbcolorno.TabIndex = 126
        Me.Tbcolorno.Visible = False
        '
        'Tbdyedbillno
        '
        Me.Tbdyedbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Tbdyedbillno.Enabled = False
        Me.Tbdyedbillno.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Tbdyedbillno.Location = New System.Drawing.Point(851, 348)
        Me.Tbdyedbillno.MaxLength = 150
        Me.Tbdyedbillno.Name = "Tbdyedbillno"
        Me.Tbdyedbillno.Size = New System.Drawing.Size(72, 24)
        Me.Tbdyedbillno.TabIndex = 124
        Me.Tbdyedbillno.Visible = False
        '
        'Tbrefablotno
        '
        Me.Tbrefablotno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Tbrefablotno.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Tbrefablotno.Location = New System.Drawing.Point(929, 378)
        Me.Tbrefablotno.MaxLength = 150
        Me.Tbrefablotno.Name = "Tbrefablotno"
        Me.Tbrefablotno.Size = New System.Drawing.Size(67, 24)
        Me.Tbrefablotno.TabIndex = 127
        Me.Tbrefablotno.Visible = False
        '
        'Tbknittno
        '
        Me.Tbknittno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Tbknittno.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Tbknittno.Location = New System.Drawing.Point(929, 347)
        Me.Tbknittno.MaxLength = 150
        Me.Tbknittno.Name = "Tbknittno"
        Me.Tbknittno.Size = New System.Drawing.Size(67, 24)
        Me.Tbknittno.TabIndex = 125
        Me.Tbknittno.Visible = False
        '
        'Dgvmas
        '
        Me.Dgvmas.AllowUserToAddRows = False
        Me.Dgvmas.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgvmas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgvmas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgvmas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Mstat, Me.rollid, Me.Mcomid, Me.Order, Me.Dhid, Me.Mdyedhdesc, Me.Billdyedno, Me.Lotno, Me.Clothid, Me.Mclothno, Me.Clothtype, Me.Dwidth, Me.Shadeid, Me.Shadedesc, Me.Mkong, Me.Rollwage, Me.Instk})
        Me.Dgvmas.Location = New System.Drawing.Point(326, 543)
        Me.Dgvmas.Name = "Dgvmas"
        Me.Dgvmas.ReadOnly = True
        Me.Dgvmas.Size = New System.Drawing.Size(670, 101)
        Me.Dgvmas.TabIndex = 99
        Me.Dgvmas.Visible = False
        '
        'Mstat
        '
        Me.Mstat.DataPropertyName = "Stat"
        Me.Mstat.HeaderText = ""
        Me.Mstat.Name = "Mstat"
        Me.Mstat.ReadOnly = True
        Me.Mstat.Width = 20
        '
        'rollid
        '
        Me.rollid.DataPropertyName = "Pubno"
        Me.rollid.HeaderText = "เบอร์พับ"
        Me.rollid.Name = "rollid"
        Me.rollid.ReadOnly = True
        '
        'Mcomid
        '
        Me.Mcomid.DataPropertyName = "Comid"
        Me.Mcomid.HeaderText = "Comid"
        Me.Mcomid.Name = "Mcomid"
        Me.Mcomid.ReadOnly = True
        Me.Mcomid.Visible = False
        '
        'Order
        '
        Me.Order.DataPropertyName = "Pubno"
        Me.Order.HeaderText = "ลำดับที่"
        Me.Order.Name = "Order"
        Me.Order.ReadOnly = True
        Me.Order.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Order.Visible = False
        '
        'Dhid
        '
        Me.Dhid.DataPropertyName = "Dhid"
        Me.Dhid.HeaderText = "Dhid"
        Me.Dhid.Name = "Dhid"
        Me.Dhid.ReadOnly = True
        Me.Dhid.Visible = False
        '
        'Mdyedhdesc
        '
        Me.Mdyedhdesc.DataPropertyName = "Dyedhdesc"
        Me.Mdyedhdesc.HeaderText = "Dyedhdesc"
        Me.Mdyedhdesc.Name = "Mdyedhdesc"
        Me.Mdyedhdesc.ReadOnly = True
        Me.Mdyedhdesc.Visible = False
        '
        'Billdyedno
        '
        Me.Billdyedno.DataPropertyName = "Billdyedno"
        Me.Billdyedno.HeaderText = "Billdyedno"
        Me.Billdyedno.Name = "Billdyedno"
        Me.Billdyedno.ReadOnly = True
        Me.Billdyedno.Visible = False
        '
        'Lotno
        '
        Me.Lotno.DataPropertyName = "Lotno"
        Me.Lotno.HeaderText = "Lotno"
        Me.Lotno.Name = "Lotno"
        Me.Lotno.ReadOnly = True
        Me.Lotno.Visible = False
        '
        'Clothid
        '
        Me.Clothid.DataPropertyName = "Clothid"
        Me.Clothid.HeaderText = "Clothid"
        Me.Clothid.Name = "Clothid"
        Me.Clothid.ReadOnly = True
        Me.Clothid.Visible = False
        '
        'Mclothno
        '
        Me.Mclothno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Mclothno.DataPropertyName = "Clothno"
        Me.Mclothno.HeaderText = "เบอร์ผ้า"
        Me.Mclothno.Name = "Mclothno"
        Me.Mclothno.ReadOnly = True
        Me.Mclothno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Clothtype
        '
        Me.Clothtype.DataPropertyName = "Ftype"
        Me.Clothtype.HeaderText = "ประเภท"
        Me.Clothtype.Name = "Clothtype"
        Me.Clothtype.ReadOnly = True
        Me.Clothtype.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Clothtype.Width = 130
        '
        'Dwidth
        '
        Me.Dwidth.DataPropertyName = "Fwidth"
        Me.Dwidth.HeaderText = "หน้ากว้าง"
        Me.Dwidth.Name = "Dwidth"
        Me.Dwidth.ReadOnly = True
        Me.Dwidth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Shadeid
        '
        Me.Shadeid.DataPropertyName = "Shadeid"
        Me.Shadeid.HeaderText = "Shadeid"
        Me.Shadeid.Name = "Shadeid"
        Me.Shadeid.ReadOnly = True
        Me.Shadeid.Visible = False
        '
        'Shadedesc
        '
        Me.Shadedesc.DataPropertyName = "Shadedesc"
        Me.Shadedesc.HeaderText = "Shadedesc"
        Me.Shadedesc.Name = "Shadedesc"
        Me.Shadedesc.ReadOnly = True
        Me.Shadedesc.Visible = False
        '
        'Mkong
        '
        Me.Mkong.DataPropertyName = "Kongno"
        Me.Mkong.HeaderText = "เบอร์กอง"
        Me.Mkong.Name = "Mkong"
        Me.Mkong.ReadOnly = True
        Me.Mkong.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Mkong.Width = 150
        '
        'Rollwage
        '
        Me.Rollwage.DataPropertyName = "Rollwage"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Rollwage.DefaultCellStyle = DataGridViewCellStyle2
        Me.Rollwage.HeaderText = "น้ำหนัก(ก.ก.)"
        Me.Rollwage.Name = "Rollwage"
        Me.Rollwage.ReadOnly = True
        Me.Rollwage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Instk
        '
        Me.Instk.DataPropertyName = "Instk"
        Me.Instk.HeaderText = "Instk"
        Me.Instk.Name = "Instk"
        Me.Instk.ReadOnly = True
        Me.Instk.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(896, 58)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 22)
        Me.TextBox1.TabIndex = 7
        Me.TextBox1.Visible = False
        '
        'Tbremark
        '
        Me.Tbremark.Location = New System.Drawing.Point(851, 410)
        Me.Tbremark.Name = "Tbremark"
        Me.Tbremark.Size = New System.Drawing.Size(72, 22)
        Me.Tbremark.TabIndex = 6
        Me.Tbremark.Visible = False
        '
        'Tbredate
        '
        Me.Tbredate.Location = New System.Drawing.Point(684, 58)
        Me.Tbredate.Name = "Tbredate"
        Me.Tbredate.Size = New System.Drawing.Size(100, 22)
        Me.Tbredate.TabIndex = 5
        Me.Tbredate.Visible = False
        '
        'Tbknitcomno
        '
        Me.Tbknitcomno.Location = New System.Drawing.Point(896, 30)
        Me.Tbknitcomno.Name = "Tbknitcomno"
        Me.Tbknitcomno.Size = New System.Drawing.Size(100, 22)
        Me.Tbknitcomno.TabIndex = 4
        Me.Tbknitcomno.Visible = False
        '
        'Tbto
        '
        Me.Tbto.Location = New System.Drawing.Point(684, 30)
        Me.Tbto.Name = "Tbto"
        Me.Tbto.Size = New System.Drawing.Size(100, 22)
        Me.Tbto.TabIndex = 3
        Me.Tbto.Visible = False
        '
        'Tbdate
        '
        Me.Tbdate.Location = New System.Drawing.Point(896, 290)
        Me.Tbdate.Name = "Tbdate"
        Me.Tbdate.Size = New System.Drawing.Size(100, 22)
        Me.Tbdate.TabIndex = 2
        Me.Tbdate.Visible = False
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.Location = New System.Drawing.Point(1, 1)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1006, 654)
        Me.ReportViewer1.TabIndex = 0
        '
        'TabItem1
        '
        Me.TabItem1.AttachedControl = Me.TabControlPanel1
        Me.TabItem1.Name = "TabItem1"
        Me.TabItem1.Text = "ใบรับผ้าสีจากโรงย้อม"
        '
        'Formreceivefabrpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "Formreceivefabrpt"
        Me.Text = "ใบรับผ้าสีจากโรงย้อม"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabControlPanel1.ResumeLayout(False)
        Me.TabControlPanel1.PerformLayout()
        CType(Me.Countfabric, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgvmas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Btmclose As ToolStripButton
    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents Tbremark As TextBox
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents Dgvmas As DataGridView
    Friend WithEvents Mstat As DataGridViewTextBoxColumn
    Friend WithEvents rollid As DataGridViewTextBoxColumn
    Friend WithEvents Mcomid As DataGridViewTextBoxColumn
    Friend WithEvents Order As DataGridViewTextBoxColumn
    Friend WithEvents Dhid As DataGridViewTextBoxColumn
    Friend WithEvents Mdyedhdesc As DataGridViewTextBoxColumn
    Friend WithEvents Billdyedno As DataGridViewTextBoxColumn
    Friend WithEvents Lotno As DataGridViewTextBoxColumn
    Friend WithEvents Clothid As DataGridViewTextBoxColumn
    Friend WithEvents Mclothno As DataGridViewTextBoxColumn
    Friend WithEvents Clothtype As DataGridViewTextBoxColumn
    Friend WithEvents Dwidth As DataGridViewTextBoxColumn
    Friend WithEvents Shadeid As DataGridViewTextBoxColumn
    Friend WithEvents Shadedesc As DataGridViewTextBoxColumn
    Friend WithEvents Mkong As DataGridViewTextBoxColumn
    Friend WithEvents Rollwage As DataGridViewTextBoxColumn
    Friend WithEvents Instk As DataGridViewTextBoxColumn
    Friend WithEvents Tbdhname As Normtextbox.Normtextbox
    Friend WithEvents Tbdhid As Normtextbox.Normtextbox
    Friend WithEvents Tbcolorno As Normtextbox.Normtextbox
    Friend WithEvents Tbdyedbillno As Normtextbox.Normtextbox
    Friend WithEvents Tbrefablotno As Normtextbox.Normtextbox
    Friend WithEvents Tbknittno As Normtextbox.Normtextbox
    Friend WithEvents Tbdyedcomno As Normtextbox.Normtextbox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Tbredate As TextBox
    Friend WithEvents Tbknitcomno As TextBox
    Friend WithEvents Tbto As TextBox
    Friend WithEvents Tbdate As TextBox
    Friend WithEvents Countfabric As DataGridView
    Friend WithEvents Cclothno As DataGridViewTextBoxColumn
    Friend WithEvents Cclothtype As DataGridViewTextBoxColumn
    Friend WithEvents CDwidth As DataGridViewTextBoxColumn
    Friend WithEvents Count As DataGridViewTextBoxColumn
    Friend WithEvents CRollwage As DataGridViewTextBoxColumn
End Class
