<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Formreceivablelist
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
        Me.Dgvlist = New System.Windows.Forms.DataGridView()
        CType(Me.Dgvlist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Dgvlist
        '
        Me.Dgvlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgvlist.Location = New System.Drawing.Point(34, 38)
        Me.Dgvlist.Name = "Dgvlist"
        Me.Dgvlist.Size = New System.Drawing.Size(927, 659)
        Me.Dgvlist.TabIndex = 0
        '
        'Formreceivablelist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.Dgvlist)
        Me.Name = "Formreceivablelist"
        Me.Text = "Formreceivablelist"
        CType(Me.Dgvlist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Dgvlist As DataGridView
End Class
