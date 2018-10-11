<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Formsaleyarnrpt
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Btmclose = New System.Windows.Forms.ToolStripButton()
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl()
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel()
        Me.TabItem2 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
        Me.Tbsumnw = New System.Windows.Forms.TextBox()
        Me.Tbsumgw = New System.Windows.Forms.TextBox()
        Me.Tbsumqty = New System.Windows.Forms.TextBox()
        Me.Tbsumctn = New System.Windows.Forms.TextBox()
        Me.Tbdlvno = New System.Windows.Forms.TextBox()
        Me.Tbdate = New System.Windows.Forms.TextBox()
        Me.Tbcustname = New System.Windows.Forms.TextBox()
        Me.Tbcustaddr = New System.Windows.Forms.TextBox()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.ReportViewer2 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabControlPanel2.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Btmclose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1008, 47)
        Me.ToolStrip1.TabIndex = 69
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
        Me.TabControl1.Controls.Add(Me.TabControlPanel2)
        Me.TabControl1.Controls.Add(Me.TabControlPanel1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TabControl1.ForeColor = System.Drawing.Color.Black
        Me.TabControl1.Location = New System.Drawing.Point(0, 47)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl1.SelectedTabIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1008, 682)
        Me.TabControl1.TabIndex = 70
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.TabItem2)
        Me.TabControl1.Tabs.Add(Me.TabItem1)
        Me.TabControl1.Text = "TabControl1"
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.ReportViewer2)
        Me.TabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(1008, 656)
        Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = 90
        Me.TabControlPanel2.TabIndex = 5
        Me.TabControlPanel2.TabItem = Me.TabItem2
        '
        'TabItem2
        '
        Me.TabItem2.AttachedControl = Me.TabControlPanel2
        Me.TabItem2.Name = "TabItem2"
        Me.TabItem2.Text = "ใบส่งด้าย(ขาย)"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.Tbsumnw)
        Me.TabControlPanel1.Controls.Add(Me.Tbsumgw)
        Me.TabControlPanel1.Controls.Add(Me.Tbsumqty)
        Me.TabControlPanel1.Controls.Add(Me.Tbsumctn)
        Me.TabControlPanel1.Controls.Add(Me.Tbdlvno)
        Me.TabControlPanel1.Controls.Add(Me.Tbdate)
        Me.TabControlPanel1.Controls.Add(Me.Tbcustname)
        Me.TabControlPanel1.Controls.Add(Me.Tbcustaddr)
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
        'Tbsumnw
        '
        Me.Tbsumnw.Location = New System.Drawing.Point(400, 354)
        Me.Tbsumnw.Name = "Tbsumnw"
        Me.Tbsumnw.Size = New System.Drawing.Size(100, 22)
        Me.Tbsumnw.TabIndex = 170
        Me.Tbsumnw.Visible = False
        '
        'Tbsumgw
        '
        Me.Tbsumgw.Location = New System.Drawing.Point(400, 382)
        Me.Tbsumgw.Name = "Tbsumgw"
        Me.Tbsumgw.Size = New System.Drawing.Size(100, 22)
        Me.Tbsumgw.TabIndex = 169
        Me.Tbsumgw.Visible = False
        '
        'Tbsumqty
        '
        Me.Tbsumqty.Location = New System.Drawing.Point(509, 354)
        Me.Tbsumqty.Name = "Tbsumqty"
        Me.Tbsumqty.Size = New System.Drawing.Size(100, 22)
        Me.Tbsumqty.TabIndex = 168
        Me.Tbsumqty.Visible = False
        '
        'Tbsumctn
        '
        Me.Tbsumctn.Location = New System.Drawing.Point(509, 382)
        Me.Tbsumctn.Name = "Tbsumctn"
        Me.Tbsumctn.Size = New System.Drawing.Size(100, 22)
        Me.Tbsumctn.TabIndex = 167
        Me.Tbsumctn.Visible = False
        '
        'Tbdlvno
        '
        Me.Tbdlvno.Location = New System.Drawing.Point(400, 326)
        Me.Tbdlvno.Name = "Tbdlvno"
        Me.Tbdlvno.Size = New System.Drawing.Size(100, 22)
        Me.Tbdlvno.TabIndex = 166
        Me.Tbdlvno.Visible = False
        '
        'Tbdate
        '
        Me.Tbdate.Location = New System.Drawing.Point(506, 326)
        Me.Tbdate.Name = "Tbdate"
        Me.Tbdate.Size = New System.Drawing.Size(100, 22)
        Me.Tbdate.TabIndex = 165
        Me.Tbdate.Visible = False
        '
        'Tbcustname
        '
        Me.Tbcustname.Location = New System.Drawing.Point(400, 298)
        Me.Tbcustname.Name = "Tbcustname"
        Me.Tbcustname.Size = New System.Drawing.Size(100, 22)
        Me.Tbcustname.TabIndex = 164
        Me.Tbcustname.Visible = False
        '
        'Tbcustaddr
        '
        Me.Tbcustaddr.Location = New System.Drawing.Point(506, 298)
        Me.Tbcustaddr.Name = "Tbcustaddr"
        Me.Tbcustaddr.Size = New System.Drawing.Size(100, 22)
        Me.Tbcustaddr.TabIndex = 163
        Me.Tbcustaddr.Visible = False
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
        Me.TabItem1.Text = "Packinglist"
        '
        'ReportViewer2
        '
        Me.ReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer2.Location = New System.Drawing.Point(1, 1)
        Me.ReportViewer2.Name = "ReportViewer2"
        Me.ReportViewer2.Size = New System.Drawing.Size(1006, 654)
        Me.ReportViewer2.TabIndex = 0
        '
        'Formsaleyarnrpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "Formsaleyarnrpt"
        Me.Text = "ใบส่งด้าย(ขาย)"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabControlPanel2.ResumeLayout(False)
        Me.TabControlPanel1.ResumeLayout(False)
        Me.TabControlPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Btmclose As ToolStripButton
    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents Tbsumnw As TextBox
    Friend WithEvents Tbsumgw As TextBox
    Friend WithEvents Tbsumqty As TextBox
    Friend WithEvents Tbsumctn As TextBox
    Friend WithEvents Tbdlvno As TextBox
    Friend WithEvents Tbdate As TextBox
    Friend WithEvents Tbcustname As TextBox
    Friend WithEvents Tbcustaddr As TextBox
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem2 As DevComponents.DotNetBar.TabItem
    Friend WithEvents ReportViewer2 As Microsoft.Reporting.WinForms.ReportViewer
End Class
