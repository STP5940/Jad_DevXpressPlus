<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Formknitingfrmrpt
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
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
        Me.balanhave = New Normtextbox.Normtextbox()
        Me.GSumSend = New System.Windows.Forms.DataGridView()
        Me.Tbdlvyarnno = New Normtextbox.Normtextbox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
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
        CType(Me.GSumSend, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Btmclose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1008, 47)
        Me.ToolStrip1.TabIndex = 70
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
        Me.TabControl1.TabIndex = 71
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.TabItem1)
        Me.TabControl1.Text = "TabControl1"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.balanhave)
        Me.TabControlPanel1.Controls.Add(Me.GSumSend)
        Me.TabControlPanel1.Controls.Add(Me.Tbdlvyarnno)
        Me.TabControlPanel1.Controls.Add(Me.TextBox2)
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
        'balanhave
        '
        Me.balanhave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.balanhave.Enabled = False
        Me.balanhave.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.balanhave.Location = New System.Drawing.Point(896, 114)
        Me.balanhave.MaxLength = 150
        Me.balanhave.Name = "balanhave"
        Me.balanhave.Size = New System.Drawing.Size(100, 24)
        Me.balanhave.TabIndex = 79
        Me.balanhave.Visible = False
        '
        'GSumSend
        '
        Me.GSumSend.AllowUserToAddRows = False
        Me.GSumSend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GSumSend.Location = New System.Drawing.Point(568, 141)
        Me.GSumSend.Name = "GSumSend"
        Me.GSumSend.Size = New System.Drawing.Size(240, 150)
        Me.GSumSend.TabIndex = 78
        Me.GSumSend.Visible = False
        '
        'Tbdlvyarnno
        '
        Me.Tbdlvyarnno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Tbdlvyarnno.Enabled = False
        Me.Tbdlvyarnno.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Tbdlvyarnno.Location = New System.Drawing.Point(730, 86)
        Me.Tbdlvyarnno.MaxLength = 150
        Me.Tbdlvyarnno.Name = "Tbdlvyarnno"
        Me.Tbdlvyarnno.Size = New System.Drawing.Size(160, 24)
        Me.Tbdlvyarnno.TabIndex = 77
        Me.Tbdlvyarnno.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(896, 86)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 22)
        Me.TextBox2.TabIndex = 72
        Me.TextBox2.Visible = False
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
        Me.Tbremark.Location = New System.Drawing.Point(790, 58)
        Me.Tbremark.Name = "Tbremark"
        Me.Tbremark.Size = New System.Drawing.Size(100, 22)
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
        Me.Tbdate.Location = New System.Drawing.Point(790, 30)
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
        Me.TabItem1.Text = "ใบสังทอ"
        '
        'Formknitingfrmrpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "Formknitingfrmrpt"
        Me.Text = "ใบสั่งทอ"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabControlPanel1.ResumeLayout(False)
        Me.TabControlPanel1.PerformLayout()
        CType(Me.GSumSend, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Btmclose As ToolStripButton
    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents Tbremark As TextBox
    Friend WithEvents Tbredate As TextBox
    Friend WithEvents Tbknitcomno As TextBox
    Friend WithEvents Tbto As TextBox
    Friend WithEvents Tbdate As TextBox
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Tbdlvyarnno As Normtextbox.Normtextbox
    Friend WithEvents GSumSend As DataGridView
    Friend WithEvents balanhave As Normtextbox.Normtextbox
End Class
