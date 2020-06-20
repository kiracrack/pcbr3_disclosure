<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPCBRImageExporter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPCBRImageExporter))
        Me.cmdset = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTotalImage = New System.Windows.Forms.Label()
        Me.txtlocation = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.txtBranch = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.branchcode = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmdset
        '
        Me.cmdset.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmdset.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdset.Location = New System.Drawing.Point(76, 128)
        Me.cmdset.Name = "cmdset"
        Me.cmdset.Size = New System.Drawing.Size(249, 30)
        Me.cmdset.TabIndex = 0
        Me.cmdset.Text = "Confirm Export"
        Me.cmdset.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.25!)
        Me.TextBox1.Location = New System.Drawing.Point(21, 72)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(365, 50)
        Me.TextBox1.TabIndex = 900
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(18, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(148, 15)
        Me.Label3.TabIndex = 911
        Me.Label3.Text = "Total image to be exported"
        '
        'lblTotalImage
        '
        Me.lblTotalImage.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTotalImage.Location = New System.Drawing.Point(238, 54)
        Me.lblTotalImage.Name = "lblTotalImage"
        Me.lblTotalImage.Size = New System.Drawing.Size(148, 15)
        Me.lblTotalImage.TabIndex = 912
        Me.lblTotalImage.Text = "1000"
        Me.lblTotalImage.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtlocation
        '
        Me.txtlocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtlocation.Location = New System.Drawing.Point(76, 301)
        Me.txtlocation.Name = "txtlocation"
        Me.txtlocation.ReadOnly = True
        Me.txtlocation.Size = New System.Drawing.Size(234, 20)
        Me.txtlocation.TabIndex = 913
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(238, 33)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(37, 17)
        Me.CheckBox1.TabIndex = 916
        Me.CheckBox1.Text = "All"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'txtBranch
        '
        Me.txtBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.txtBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtBranch.FormattingEnabled = True
        Me.txtBranch.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.txtBranch.Location = New System.Drawing.Point(21, 30)
        Me.txtBranch.Name = "txtBranch"
        Me.txtBranch.Size = New System.Drawing.Size(211, 21)
        Me.txtBranch.TabIndex = 914
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(19, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 15)
        Me.Label1.TabIndex = 915
        Me.Label1.Text = "Please select branch"
        '
        'branchcode
        '
        Me.branchcode.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.branchcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.branchcode.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.branchcode.ForeColor = System.Drawing.Color.Gray
        Me.branchcode.Location = New System.Drawing.Point(332, 195)
        Me.branchcode.Margin = New System.Windows.Forms.Padding(4)
        Me.branchcode.MaxLength = 3
        Me.branchcode.Name = "branchcode"
        Me.branchcode.Size = New System.Drawing.Size(59, 22)
        Me.branchcode.TabIndex = 917
        Me.branchcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.branchcode.Visible = False
        '
        'frmPCBRImageExporter
        '
        Me.AcceptButton = Me.cmdset
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(398, 177)
        Me.Controls.Add(Me.branchcode)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.txtBranch)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtlocation)
        Me.Controls.Add(Me.lblTotalImage)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.cmdset)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmPCBRImageExporter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Client Image/Signature Exported"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdset As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTotalImage As Label
    Friend WithEvents txtlocation As TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents txtBranch As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents branchcode As System.Windows.Forms.TextBox
End Class
