<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRSBACapture
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRSBACapture))
        Me.cmdset = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDatePcbr3 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdCapturepcbrclient = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdExportData = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdset
        '
        Me.cmdset.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmdset.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdset.Location = New System.Drawing.Point(75, 254)
        Me.cmdset.Name = "cmdset"
        Me.cmdset.Size = New System.Drawing.Size(249, 30)
        Me.cmdset.TabIndex = 0
        Me.cmdset.Text = "Search and Matching RSBSA client"
        Me.cmdset.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.25!)
        Me.TextBox1.Location = New System.Drawing.Point(75, 201)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(365, 50)
        Me.TextBox1.TabIndex = 900
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(72, 185)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Searching client..."
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(304, 186)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(35, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 37)
        Me.Label3.TabIndex = 901
        Me.Label3.Text = "1."
        '
        'txtDatePcbr3
        '
        Me.txtDatePcbr3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDatePcbr3.Location = New System.Drawing.Point(77, 34)
        Me.txtDatePcbr3.Name = "txtDatePcbr3"
        Me.txtDatePcbr3.ReadOnly = True
        Me.txtDatePcbr3.Size = New System.Drawing.Size(234, 20)
        Me.txtDatePcbr3.TabIndex = 903
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(78, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 15)
        Me.Label5.TabIndex = 904
        Me.Label5.Text = "PCBR3 Database Date."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(33, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 37)
        Me.Label4.TabIndex = 905
        Me.Label4.Text = "2."
        '
        'cmdCapturepcbrclient
        '
        Me.cmdCapturepcbrclient.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmdCapturepcbrclient.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdCapturepcbrclient.Location = New System.Drawing.Point(75, 109)
        Me.cmdCapturepcbrclient.Name = "cmdCapturepcbrclient"
        Me.cmdCapturepcbrclient.Size = New System.Drawing.Size(234, 30)
        Me.cmdCapturepcbrclient.TabIndex = 906
        Me.cmdCapturepcbrclient.Text = "Capture PCBR3 Client List"
        Me.cmdCapturepcbrclient.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(31, 190)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 37)
        Me.Label6.TabIndex = 907
        Me.Label6.Text = "3."
        '
        'cmdExportData
        '
        Me.cmdExportData.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmdExportData.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdExportData.Location = New System.Drawing.Point(77, 310)
        Me.cmdExportData.Name = "cmdExportData"
        Me.cmdExportData.Size = New System.Drawing.Size(234, 30)
        Me.cmdExportData.TabIndex = 909
        Me.cmdExportData.Text = "Export RSBSA client list"
        Me.cmdExportData.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(35, 301)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 37)
        Me.Label7.TabIndex = 908
        Me.Label7.Text = "4."
        '
        'frmRSBACapture
        '
        Me.AcceptButton = Me.cmdset
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(457, 366)
        Me.Controls.Add(Me.cmdExportData)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmdCapturepcbrclient)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDatePcbr3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.cmdset)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmRSBACapture"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RSBSA Exported"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdset As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDatePcbr3 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdCapturepcbrclient As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdExportData As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
