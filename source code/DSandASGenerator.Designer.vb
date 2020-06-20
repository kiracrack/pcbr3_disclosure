<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DSandASGenerator
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DSandASGenerator))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtrefcode = New System.Windows.Forms.TextBox()
        Me.txtClientName = New System.Windows.Forms.TextBox()
        Me.cmdPrintDisclosure = New System.Windows.Forms.Button()
        Me.txtLoanAmount = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdPrintAmortization = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFilingFee = New System.Windows.Forms.TextBox()
        Me.txtProcessingFee = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtProductName = New System.Windows.Forms.TextBox()
        Me.txtpaymentMode = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.GracePeriodSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChargesSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ckFillingFee = New System.Windows.Forms.CheckBox()
        Me.ckProcessingfee = New System.Windows.Forms.CheckBox()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(86, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(361, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Please Enter PN Reference Number and press enter to verify"
        '
        'txtrefcode
        '
        Me.txtrefcode.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtrefcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtrefcode.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrefcode.Location = New System.Drawing.Point(222, 63)
        Me.txtrefcode.Name = "txtrefcode"
        Me.txtrefcode.Size = New System.Drawing.Size(122, 25)
        Me.txtrefcode.TabIndex = 0
        Me.txtrefcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtClientName
        '
        Me.txtClientName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClientName.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClientName.Location = New System.Drawing.Point(222, 91)
        Me.txtClientName.Name = "txtClientName"
        Me.txtClientName.ReadOnly = True
        Me.txtClientName.Size = New System.Drawing.Size(317, 25)
        Me.txtClientName.TabIndex = 100
        '
        'cmdPrintDisclosure
        '
        Me.cmdPrintDisclosure.Enabled = False
        Me.cmdPrintDisclosure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrintDisclosure.Location = New System.Drawing.Point(164, 258)
        Me.cmdPrintDisclosure.Name = "cmdPrintDisclosure"
        Me.cmdPrintDisclosure.Size = New System.Drawing.Size(122, 33)
        Me.cmdPrintDisclosure.TabIndex = 3
        Me.cmdPrintDisclosure.Text = "Print Disclosure"
        Me.cmdPrintDisclosure.UseVisualStyleBackColor = True
        '
        'txtLoanAmount
        '
        Me.txtLoanAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLoanAmount.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoanAmount.Location = New System.Drawing.Point(222, 147)
        Me.txtLoanAmount.Name = "txtLoanAmount"
        Me.txtLoanAmount.ReadOnly = True
        Me.txtLoanAmount.Size = New System.Drawing.Size(122, 25)
        Me.txtLoanAmount.TabIndex = 1002
        Me.txtLoanAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(136, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 17)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "PN Number:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(135, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 17)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Client Name:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(128, 150)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 17)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Loan Amount:"
        '
        'cmdPrintAmortization
        '
        Me.cmdPrintAmortization.Enabled = False
        Me.cmdPrintAmortization.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrintAmortization.Location = New System.Drawing.Point(292, 258)
        Me.cmdPrintAmortization.Name = "cmdPrintAmortization"
        Me.cmdPrintAmortization.Size = New System.Drawing.Size(122, 33)
        Me.cmdPrintAmortization.TabIndex = 20
        Me.cmdPrintAmortization.Text = "Print Amortization"
        Me.cmdPrintAmortization.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(63, 178)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(154, 17)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Inspection Fee/ Filing Fee"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(122, 207)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 17)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Processing Fee"
        '
        'txtFilingFee
        '
        Me.txtFilingFee.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFilingFee.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFilingFee.Location = New System.Drawing.Point(222, 175)
        Me.txtFilingFee.Name = "txtFilingFee"
        Me.txtFilingFee.Size = New System.Drawing.Size(122, 25)
        Me.txtFilingFee.TabIndex = 1
        Me.txtFilingFee.Text = "0.00"
        Me.txtFilingFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtProcessingFee
        '
        Me.txtProcessingFee.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProcessingFee.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcessingFee.Location = New System.Drawing.Point(222, 203)
        Me.txtProcessingFee.Name = "txtProcessingFee"
        Me.txtProcessingFee.Size = New System.Drawing.Size(122, 25)
        Me.txtProcessingFee.TabIndex = 2
        Me.txtProcessingFee.Text = "0.00"
        Me.txtProcessingFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(122, 122)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 17)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Product Name"
        '
        'txtProductName
        '
        Me.txtProductName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductName.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductName.Location = New System.Drawing.Point(222, 119)
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.ReadOnly = True
        Me.txtProductName.Size = New System.Drawing.Size(317, 25)
        Me.txtProductName.TabIndex = 1001
        '
        'txtpaymentMode
        '
        Me.txtpaymentMode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtpaymentMode.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpaymentMode.Location = New System.Drawing.Point(347, 147)
        Me.txtpaymentMode.Name = "txtpaymentMode"
        Me.txtpaymentMode.ReadOnly = True
        Me.txtpaymentMode.Size = New System.Drawing.Size(122, 25)
        Me.txtpaymentMode.TabIndex = 1004
        Me.txtpaymentMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GracePeriodSettingsToolStripMenuItem, Me.ChargesSettingsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(571, 24)
        Me.MenuStrip1.TabIndex = 28
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'GracePeriodSettingsToolStripMenuItem
        '
        Me.GracePeriodSettingsToolStripMenuItem.Name = "GracePeriodSettingsToolStripMenuItem"
        Me.GracePeriodSettingsToolStripMenuItem.Size = New System.Drawing.Size(131, 20)
        Me.GracePeriodSettingsToolStripMenuItem.Text = "Grace Period Settings"
        '
        'ChargesSettingsToolStripMenuItem
        '
        Me.ChargesSettingsToolStripMenuItem.Name = "ChargesSettingsToolStripMenuItem"
        Me.ChargesSettingsToolStripMenuItem.Size = New System.Drawing.Size(107, 20)
        Me.ChargesSettingsToolStripMenuItem.Text = "Charges Settings"
        '
        'ckFillingFee
        '
        Me.ckFillingFee.AutoSize = True
        Me.ckFillingFee.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckFillingFee.Location = New System.Drawing.Point(350, 180)
        Me.ckFillingFee.Name = "ckFillingFee"
        Me.ckFillingFee.Size = New System.Drawing.Size(79, 17)
        Me.ckFillingFee.TabIndex = 29
        Me.ckFillingFee.Text = "Filling Fee"
        Me.ckFillingFee.UseVisualStyleBackColor = True
        Me.ckFillingFee.Visible = False
        '
        'ckProcessingfee
        '
        Me.ckProcessingfee.AutoSize = True
        Me.ckProcessingfee.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckProcessingfee.Location = New System.Drawing.Point(350, 208)
        Me.ckProcessingfee.Name = "ckProcessingfee"
        Me.ckProcessingfee.Size = New System.Drawing.Size(102, 17)
        Me.ckProcessingfee.TabIndex = 30
        Me.ckProcessingfee.Text = "Processing Fee"
        Me.ckProcessingfee.UseVisualStyleBackColor = True
        Me.ckProcessingfee.Visible = False
        '
        'DSandASGenerator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(571, 318)
        Me.Controls.Add(Me.ckProcessingfee)
        Me.Controls.Add(Me.ckFillingFee)
        Me.Controls.Add(Me.txtpaymentMode)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtProductName)
        Me.Controls.Add(Me.txtProcessingFee)
        Me.Controls.Add(Me.txtFilingFee)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdPrintAmortization)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtLoanAmount)
        Me.Controls.Add(Me.cmdPrintDisclosure)
        Me.Controls.Add(Me.txtClientName)
        Me.Controls.Add(Me.txtrefcode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "DSandASGenerator"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PCBR3 DS and AS Generator"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtrefcode As System.Windows.Forms.TextBox
    Friend WithEvents txtClientName As System.Windows.Forms.TextBox
    Friend WithEvents cmdPrintDisclosure As System.Windows.Forms.Button
    Friend WithEvents txtLoanAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdPrintAmortization As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFilingFee As System.Windows.Forms.TextBox
    Friend WithEvents txtProcessingFee As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtProductName As System.Windows.Forms.TextBox
    Friend WithEvents txtpaymentMode As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents GracePeriodSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChargesSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ckFillingFee As System.Windows.Forms.CheckBox
    Friend WithEvents ckProcessingfee As System.Windows.Forms.CheckBox

End Class
