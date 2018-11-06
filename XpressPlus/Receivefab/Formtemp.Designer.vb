<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Formtemp
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
        Me.Allfab = New System.Windows.Forms.DataGridView()
        Me.Allyed = New System.Windows.Forms.DataGridView()
        Me.Filterfab = New System.Windows.Forms.DataGridView()
        Me.Billdyedno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Clothid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Clothno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ftype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fwidth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rollwage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qtyrollfab = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FilterAllyed = New System.Windows.Forms.DataGridView()
        Me.Balance = New System.Windows.Forms.DataGridView()
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
        Me.BDyedcomno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BClothidyed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BClothnoyed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BFtypeyed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BFwidthyed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BQtykg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BQtyroll = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BShadeid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BShadedesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Allfab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Allyed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Filterfab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FilterAllyed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Balance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Allfab
        '
        Me.Allfab.AllowUserToAddRows = False
        Me.Allfab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Allfab.Location = New System.Drawing.Point(12, 12)
        Me.Allfab.Name = "Allfab"
        Me.Allfab.Size = New System.Drawing.Size(475, 224)
        Me.Allfab.TabIndex = 0
        '
        'Allyed
        '
        Me.Allyed.AllowUserToAddRows = False
        Me.Allyed.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Allyed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Allyed.Location = New System.Drawing.Point(12, 242)
        Me.Allyed.Name = "Allyed"
        Me.Allyed.Size = New System.Drawing.Size(475, 244)
        Me.Allyed.TabIndex = 1
        '
        'Filterfab
        '
        Me.Filterfab.AllowUserToAddRows = False
        Me.Filterfab.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Filterfab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Filterfab.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Billdyedno, Me.Clothid, Me.Clothno, Me.Ftype, Me.Fwidth, Me.Rollwage, Me.Qtyrollfab})
        Me.Filterfab.Location = New System.Drawing.Point(493, 12)
        Me.Filterfab.Name = "Filterfab"
        Me.Filterfab.Size = New System.Drawing.Size(503, 224)
        Me.Filterfab.TabIndex = 2
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
        'FilterAllyed
        '
        Me.FilterAllyed.AllowUserToAddRows = False
        Me.FilterAllyed.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FilterAllyed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.FilterAllyed.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Dyedcomno, Me.Clothidyed, Me.Clothnoyed, Me.Ftypeyed, Me.Fwidthyed, Me.Qtykg, Me.Qtyroll, Me.Knittcomid, Me.Knittbill, Me.Shadeid, Me.Shadedesc})
        Me.FilterAllyed.Location = New System.Drawing.Point(493, 242)
        Me.FilterAllyed.Name = "FilterAllyed"
        Me.FilterAllyed.Size = New System.Drawing.Size(503, 244)
        Me.FilterAllyed.TabIndex = 3
        '
        'Balance
        '
        Me.Balance.AllowUserToAddRows = False
        Me.Balance.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Balance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Balance.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BDyedcomno, Me.BClothidyed, Me.BClothnoyed, Me.BFtypeyed, Me.BFwidthyed, Me.BQtykg, Me.BQtyroll, Me.BShadeid, Me.BShadedesc})
        Me.Balance.Location = New System.Drawing.Point(12, 492)
        Me.Balance.Name = "Balance"
        Me.Balance.Size = New System.Drawing.Size(984, 225)
        Me.Balance.TabIndex = 5
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
        'BDyedcomno
        '
        Me.BDyedcomno.HeaderText = "Dyedcomno"
        Me.BDyedcomno.Name = "BDyedcomno"
        '
        'BClothidyed
        '
        Me.BClothidyed.HeaderText = "Clothidyed"
        Me.BClothidyed.Name = "BClothidyed"
        '
        'BClothnoyed
        '
        Me.BClothnoyed.HeaderText = "Clothnoyed"
        Me.BClothnoyed.Name = "BClothnoyed"
        '
        'BFtypeyed
        '
        Me.BFtypeyed.HeaderText = "Ftypeyed"
        Me.BFtypeyed.Name = "BFtypeyed"
        '
        'BFwidthyed
        '
        Me.BFwidthyed.HeaderText = "Fwidthyed"
        Me.BFwidthyed.Name = "BFwidthyed"
        '
        'BQtykg
        '
        Me.BQtykg.HeaderText = "Qtykg"
        Me.BQtykg.Name = "BQtykg"
        '
        'BQtyroll
        '
        Me.BQtyroll.HeaderText = "Qtyroll"
        Me.BQtyroll.Name = "BQtyroll"
        '
        'BShadeid
        '
        Me.BShadeid.HeaderText = "BShadeid"
        Me.BShadeid.Name = "BShadeid"
        '
        'BShadedesc
        '
        Me.BShadedesc.HeaderText = "BShadedesc"
        Me.BShadedesc.Name = "BShadedesc"
        '
        'Formtemp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.Balance)
        Me.Controls.Add(Me.FilterAllyed)
        Me.Controls.Add(Me.Filterfab)
        Me.Controls.Add(Me.Allyed)
        Me.Controls.Add(Me.Allfab)
        Me.Name = "Formtemp"
        Me.Text = "Formtemp"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Allfab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Allyed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Filterfab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FilterAllyed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Balance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Allfab As DataGridView
    Friend WithEvents Allyed As DataGridView
    Friend WithEvents Filterfab As DataGridView
    Friend WithEvents FilterAllyed As DataGridView
    Friend WithEvents Balance As DataGridView
    Friend WithEvents Billdyedno As DataGridViewTextBoxColumn
    Friend WithEvents Clothid As DataGridViewTextBoxColumn
    Friend WithEvents Clothno As DataGridViewTextBoxColumn
    Friend WithEvents Ftype As DataGridViewTextBoxColumn
    Friend WithEvents Fwidth As DataGridViewTextBoxColumn
    Friend WithEvents Rollwage As DataGridViewTextBoxColumn
    Friend WithEvents Qtyrollfab As DataGridViewTextBoxColumn
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
    Friend WithEvents BQtykg As DataGridViewTextBoxColumn
    Friend WithEvents BQtyroll As DataGridViewTextBoxColumn
    Friend WithEvents BShadeid As DataGridViewTextBoxColumn
    Friend WithEvents BShadedesc As DataGridViewTextBoxColumn
End Class
