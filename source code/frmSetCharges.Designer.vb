<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetCharges
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSetCharges))
        Me.cms_em = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewTransactionDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditChapterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdPrintAmortization = New System.Windows.Forms.Button()
        Me.ckirr = New System.Windows.Forms.CheckBox()
        Me.cms_em.SuspendLayout()
        Me.SuspendLayout()
        '
        'cms_em
        '
        Me.cms_em.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewTransactionDetailsToolStripMenuItem, Me.EditChapterToolStripMenuItem})
        Me.cms_em.Name = "ContextMenuStrip1"
        Me.cms_em.Size = New System.Drawing.Size(183, 48)
        '
        'ViewTransactionDetailsToolStripMenuItem
        '
        Me.ViewTransactionDetailsToolStripMenuItem.Image = Global.Disclosure.My.Resources.Resources.Time_Hot
        Me.ViewTransactionDetailsToolStripMenuItem.Name = "ViewTransactionDetailsToolStripMenuItem"
        Me.ViewTransactionDetailsToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.ViewTransactionDetailsToolStripMenuItem.Text = "Update Grace Period"
        '
        'EditChapterToolStripMenuItem
        '
        Me.EditChapterToolStripMenuItem.Image = Global.Disclosure.My.Resources.Resources.document_excel_table
        Me.EditChapterToolStripMenuItem.Name = "EditChapterToolStripMenuItem"
        Me.EditChapterToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.EditChapterToolStripMenuItem.Text = "Export to Excel"
        '
        'cmdPrintAmortization
        '
        Me.cmdPrintAmortization.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrintAmortization.Location = New System.Drawing.Point(38, 43)
        Me.cmdPrintAmortization.Name = "cmdPrintAmortization"
        Me.cmdPrintAmortization.Size = New System.Drawing.Size(130, 33)
        Me.cmdPrintAmortization.TabIndex = 394
        Me.cmdPrintAmortization.Text = "OK"
        Me.cmdPrintAmortization.UseVisualStyleBackColor = True
        '
        'ckirr
        '
        Me.ckirr.AutoSize = True
        Me.ckirr.Location = New System.Drawing.Point(38, 12)
        Me.ckirr.Name = "ckirr"
        Me.ckirr.Size = New System.Drawing.Size(327, 25)
        Me.ckirr.TabIndex = 396
        Me.ckirr.Text = "Include Effective Interest Rate Computation"
        Me.ckirr.UseVisualStyleBackColor = True
        '
        'frmSetCharges
        '
        Me.AcceptButton = Me.cmdPrintAmortization
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 98)
        Me.Controls.Add(Me.ckirr)
        Me.Controls.Add(Me.cmdPrintAmortization)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmSetCharges"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Set Grace Period Settings"
        Me.cms_em.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cms_em As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditChapterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewTransactionDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrintAmortization As System.Windows.Forms.Button
    Friend WithEvents ckirr As System.Windows.Forms.CheckBox

End Class
