<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SendDyelist = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dyecomno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dyeddate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DhidDye = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dyedhdesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pickarea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dremark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.SendDyelist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SendDyelist
        '
        Me.SendDyelist.AllowUserToAddRows = False
        Me.SendDyelist.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SendDyelist.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.SendDyelist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SendDyelist.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.Comid, Me.Dyecomno, Me.Dyeddate, Me.DhidDye, Me.Dyedhdesc, Me.Pickarea, Me.Dremark})
        Me.SendDyelist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SendDyelist.Location = New System.Drawing.Point(0, 0)
        Me.SendDyelist.Name = "SendDyelist"
        Me.SendDyelist.ReadOnly = True
        Me.SendDyelist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.SendDyelist.Size = New System.Drawing.Size(284, 261)
        Me.SendDyelist.TabIndex = 73
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Stat"
        Me.DataGridViewTextBoxColumn1.HeaderText = ""
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 20
        '
        'Comid
        '
        Me.Comid.DataPropertyName = "Comid"
        Me.Comid.HeaderText = "Comid"
        Me.Comid.Name = "Comid"
        Me.Comid.ReadOnly = True
        Me.Comid.Visible = False
        '
        'Dyecomno
        '
        Me.Dyecomno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Dyecomno.DataPropertyName = "Dyecomno"
        Me.Dyecomno.HeaderText = "เลขที่ใบสั่งย้อม"
        Me.Dyecomno.Name = "Dyecomno"
        Me.Dyecomno.ReadOnly = True
        '
        'Dyeddate
        '
        Me.Dyeddate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Dyeddate.DataPropertyName = "Dyeddate"
        Me.Dyeddate.HeaderText = "วันที่สั่งย้อม"
        Me.Dyeddate.Name = "Dyeddate"
        Me.Dyeddate.ReadOnly = True
        '
        'DhidDye
        '
        Me.DhidDye.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DhidDye.DataPropertyName = "Dhid"
        Me.DhidDye.HeaderText = "DhidDye"
        Me.DhidDye.Name = "DhidDye"
        Me.DhidDye.ReadOnly = True
        Me.DhidDye.Visible = False
        '
        'Dyedhdesc
        '
        Me.Dyedhdesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Dyedhdesc.DataPropertyName = "Dyedhdesc"
        Me.Dyedhdesc.HeaderText = "โรงย้อม"
        Me.Dyedhdesc.Name = "Dyedhdesc"
        Me.Dyedhdesc.ReadOnly = True
        '
        'Pickarea
        '
        Me.Pickarea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Pickarea.DataPropertyName = "Pickarea"
        Me.Pickarea.HeaderText = "หมายเหตุโรงย้อม"
        Me.Pickarea.Name = "Pickarea"
        Me.Pickarea.ReadOnly = True
        '
        'Dremark
        '
        Me.Dremark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Dremark.DataPropertyName = "Dremark"
        Me.Dremark.HeaderText = "หมายเหตุใบสั่งย้อม"
        Me.Dremark.Name = "Dremark"
        Me.Dremark.ReadOnly = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.SendDyelist)
        Me.Name = "Form2"
        Me.Text = "Form2"
        CType(Me.SendDyelist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SendDyelist As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents Comid As DataGridViewTextBoxColumn
    Friend WithEvents Dyecomno As DataGridViewTextBoxColumn
    Friend WithEvents Dyeddate As DataGridViewTextBoxColumn
    Friend WithEvents DhidDye As DataGridViewTextBoxColumn
    Friend WithEvents Dyedhdesc As DataGridViewTextBoxColumn
    Friend WithEvents Pickarea As DataGridViewTextBoxColumn
    Friend WithEvents Dremark As DataGridViewTextBoxColumn
End Class
