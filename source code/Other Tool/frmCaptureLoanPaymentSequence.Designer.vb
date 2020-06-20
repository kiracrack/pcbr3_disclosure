<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCaptureLoanPaymentSequence
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCaptureLoanPaymentSequence))
        Me.cmdset = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtBranch = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.branchcode = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.txtTRansactionDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ckCaptureAllLoansAccounts = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTotalPayment = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotalAdjustment = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotalLoanReleased = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdset
        '
        Me.cmdset.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmdset.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdset.Location = New System.Drawing.Point(74, 277)
        Me.cmdset.Name = "cmdset"
        Me.cmdset.Size = New System.Drawing.Size(249, 30)
        Me.cmdset.TabIndex = 0
        Me.cmdset.Text = "CAPTURE PCBR3 DATA"
        Me.cmdset.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.25!)
        Me.TextBox1.Location = New System.Drawing.Point(12, 131)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(365, 50)
        Me.TextBox1.TabIndex = 900
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBranch
        '
        Me.txtBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.txtBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtBranch.FormattingEnabled = True
        Me.txtBranch.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.txtBranch.Location = New System.Drawing.Point(12, 107)
        Me.txtBranch.Name = "txtBranch"
        Me.txtBranch.Size = New System.Drawing.Size(211, 21)
        Me.txtBranch.TabIndex = 910
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(10, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 15)
        Me.Label3.TabIndex = 911
        Me.Label3.Text = "Please select branch"
        '
        'branchcode
        '
        Me.branchcode.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.branchcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.branchcode.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.branchcode.ForeColor = System.Drawing.Color.Gray
        Me.branchcode.Location = New System.Drawing.Point(318, 334)
        Me.branchcode.Margin = New System.Windows.Forms.Padding(4)
        Me.branchcode.MaxLength = 3
        Me.branchcode.Name = "branchcode"
        Me.branchcode.Size = New System.Drawing.Size(59, 22)
        Me.branchcode.TabIndex = 912
        Me.branchcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.branchcode.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(229, 110)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(37, 17)
        Me.CheckBox1.TabIndex = 913
        Me.CheckBox1.Text = "All"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'txtTRansactionDate
        '
        Me.txtTRansactionDate.CustomFormat = "MMMM dd, yyyy"
        Me.txtTRansactionDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTRansactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtTRansactionDate.Location = New System.Drawing.Point(12, 58)
        Me.txtTRansactionDate.Name = "txtTRansactionDate"
        Me.txtTRansactionDate.Size = New System.Drawing.Size(211, 23)
        Me.txtTRansactionDate.TabIndex = 915
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(10, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 15)
        Me.Label1.TabIndex = 914
        Me.Label1.Text = "Select Transaction Date"
        '
        'ckCaptureAllLoansAccounts
        '
        Me.ckCaptureAllLoansAccounts.AutoSize = True
        Me.ckCaptureAllLoansAccounts.Location = New System.Drawing.Point(12, 12)
        Me.ckCaptureAllLoansAccounts.Name = "ckCaptureAllLoansAccounts"
        Me.ckCaptureAllLoansAccounts.Size = New System.Drawing.Size(380, 17)
        Me.ckCaptureAllLoansAccounts.TabIndex = 917
        Me.ckCaptureAllLoansAccounts.Text = "One type setup only (Capture all PCBR3 Accounts and Charges Sequence)"
        Me.ckCaptureAllLoansAccounts.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(25, 208)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(187, 15)
        Me.Label2.TabIndex = 918
        Me.Label2.Text = "Total row of payments transaction"
        '
        'txtTotalPayment
        '
        Me.txtTotalPayment.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTotalPayment.Location = New System.Drawing.Point(272, 208)
        Me.txtTotalPayment.Name = "txtTotalPayment"
        Me.txtTotalPayment.Size = New System.Drawing.Size(105, 15)
        Me.txtTotalPayment.TabIndex = 919
        Me.txtTotalPayment.Text = "0"
        Me.txtTotalPayment.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 189)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 17)
        Me.Label5.TabIndex = 920
        Me.Label5.Text = "Summary"
        '
        'txtTotalAdjustment
        '
        Me.txtTotalAdjustment.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTotalAdjustment.Location = New System.Drawing.Point(272, 225)
        Me.txtTotalAdjustment.Name = "txtTotalAdjustment"
        Me.txtTotalAdjustment.Size = New System.Drawing.Size(105, 15)
        Me.txtTotalAdjustment.TabIndex = 922
        Me.txtTotalAdjustment.Text = "0"
        Me.txtTotalAdjustment.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(25, 225)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(195, 15)
        Me.Label7.TabIndex = 921
        Me.Label7.Text = "Total row of adjustment transaction"
        '
        'txtTotalLoanReleased
        '
        Me.txtTotalLoanReleased.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTotalLoanReleased.Location = New System.Drawing.Point(272, 241)
        Me.txtTotalLoanReleased.Name = "txtTotalLoanReleased"
        Me.txtTotalLoanReleased.Size = New System.Drawing.Size(105, 15)
        Me.txtTotalLoanReleased.TabIndex = 924
        Me.txtTotalLoanReleased.Text = "0"
        Me.txtTotalLoanReleased.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(25, 241)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(165, 15)
        Me.Label9.TabIndex = 923
        Me.Label9.Text = "Total row of new loan releases"
        '
        'frmCaptureLoanPaymentSequence
        '
        Me.AcceptButton = Me.cmdset
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(398, 319)
        Me.Controls.Add(Me.txtTotalLoanReleased)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtTotalAdjustment)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTotalPayment)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ckCaptureAllLoansAccounts)
        Me.Controls.Add(Me.txtTRansactionDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.branchcode)
        Me.Controls.Add(Me.txtBranch)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.cmdset)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCaptureLoanPaymentSequence"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Capture Data for BOS System"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdset As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtBranch As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents branchcode As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents txtTRansactionDate As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents ckCaptureAllLoansAccounts As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTotalPayment As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTotalAdjustment As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtTotalLoanReleased As Label
    Friend WithEvents Label9 As Label
End Class
