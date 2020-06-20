<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBranchConnectionSetup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBranchConnectionSetup))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtConnection = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(110, 46)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(153, 33)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Activate System"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'txtConnection
        '
        Me.txtConnection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtConnection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.txtConnection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtConnection.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtConnection.FormattingEnabled = True
        Me.txtConnection.Items.AddRange(New Object() {"CORPORATE LIVE (ONLINE DATABASE)", "OROQUIETA BRANCH", "TAGOLOAN BRANCH", "BRTI - CDO BRANCH", "DUMAGUETE BRANCH", "TAGBILARAN BRANCH", "LIBERTAD MICRO", "LIBERTAD REGULAR"})
        Me.txtConnection.Location = New System.Drawing.Point(12, 11)
        Me.txtConnection.Name = "txtConnection"
        Me.txtConnection.Size = New System.Drawing.Size(344, 29)
        Me.txtConnection.TabIndex = 0
        '
        'frmBranchConnectionSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(369, 91)
        Me.Controls.Add(Me.txtConnection)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmBranchConnectionSetup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "On-Time Setup Connection"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtConnection As System.Windows.Forms.ComboBox

End Class
