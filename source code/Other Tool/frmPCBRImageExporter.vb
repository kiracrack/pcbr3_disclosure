Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System
Imports System.IO
Imports System.ComponentModel
Imports System.Net.Mail
Imports System.Text
Imports System.Net
Imports System.Collections.Generic
Public Class frmPCBRImageExporter
    Dim bw As BackgroundWorker = New BackgroundWorker
    Dim picbox As PictureBox = New PictureBox
    Dim sigbox As PictureBox = New PictureBox
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function

    Private Sub cmdset_Click(sender As Object, e As EventArgs) Handles cmdset.Click
        AddHandler bw.DoWork, AddressOf bw_DoWork
        AddHandler bw.ProgressChanged, AddressOf bw_ProgressChanged
        AddHandler bw.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted
        Dim f As FolderBrowserDialog = New FolderBrowserDialog
        Try
            If f.ShowDialog() = DialogResult.OK Then
                If MessageBox.Show("Are you sure you want to continue? " & Environment.NewLine & Environment.NewLine & "Note: There's no undo function. please make sure you doing correctly!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = vbYes Then
                    txtlocation.Text = f.SelectedPath
                    If Not bw.IsBusy = True Then
                        cmdset.Enabled = False
                        Me.ControlBox = False
                        bw.RunWorkerAsync()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub bw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        On Error Resume Next
        If System.IO.Directory.Exists(txtlocation.Text & "\Photos") = False Then
            System.IO.Directory.CreateDirectory(txtlocation.Text & "\Photos")
        End If
        If System.IO.Directory.Exists(txtlocation.Text & "\Signatures") = False Then
            System.IO.Directory.CreateDirectory(txtlocation.Text & "\Signatures")
        End If
        Dim cnt As Integer = 1

        If CheckBox1.Checked = True Then
            com.CommandText = "select * from image.binaryinfo where sizepicture<>2250 and sizepicture<>2257 and sizepicture<>2070 and sizepicture<>0;" : rst = com.ExecuteReader
        Else
            com.CommandText = "select binaryinfo.* from master.client inner join image.binaryinfo on client.custcode = binaryinfo.custcode where branchcode='" & branchcode.Text & "' and sizepicture<>2250 and sizepicture<>2257 and sizepicture<>2070 and sizepicture<>0;" : rst = com.ExecuteReader
        End If

        While rst.Read
            If bw.CancellationPending = True Then
                e.Cancel = True
            Else
                '  picbox = Nothing
                System.Threading.Thread.Sleep(1)
                ShowImage("custpicture", picbox)
                If System.IO.File.Exists(txtlocation.Text & "\Photos\" & rst("custcode").ToString() & ".jpg") = True Then
                    System.IO.File.Delete(txtlocation.Text & "\Photos\" & rst("custcode").ToString() & ".jpg")
                End If
                picbox.Image.Save(txtlocation.Text & "\Photos\" & rst("custcode").ToString() & ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg)

                If Val(rst("sizesignature")) <> 0 Then
                    ShowImage("custsignature", sigbox)
                    If System.IO.File.Exists(txtlocation.Text & "\Signatures\" & rst("custcode").ToString() & ".jpg") = True Then
                        System.IO.File.Delete(txtlocation.Text & "\Signatures\" & rst("custcode").ToString() & ".jpg")
                    End If
                    sigbox.Image.Save(txtlocation.Text & "\Signatures\" & rst("custcode").ToString() & ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
                End If
                bw.ReportProgress(cnt)
            End If
            cnt = cnt + 1
        End While
        rst.Close()
    End Sub

    Private Sub bw_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs)
        TextBox1.Text = FormatNumber(e.ProgressPercentage.ToString(), 0)
    End Sub

    Private Sub bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        If e.Cancelled = True Then
            Me.TextBox1.Text = "Canceled!"
        ElseIf e.Error IsNot Nothing Then
            Me.TextBox1.Text = "Error: " & e.Error.Message
        Else
            Me.TextBox1.Text = "DONE CAPTURED"
        End If
        Me.ControlBox = True
        cmdset.Enabled = True

    End Sub

    Private Sub frmRSBACapture_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bw.WorkerSupportsCancellation = True
        bw.WorkerReportsProgress = True

        loadBranch()
    End Sub
    Public Sub loadBranch()
        LoadToComboBox("select * from master.branches order by branchname asc", "branchname", "branchcode", txtBranch)
    End Sub
 
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txtBranch.Enabled = False
            txtBranch.SelectedIndex = -1
        Else
            txtBranch.Enabled = True
        End If
        countTotalImage()
    End Sub

    Private Sub txtBranch_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtBranch.SelectedValueChanged
        If txtBranch.Text <> "" Then
            branchcode.Text = DirectCast(txtBranch.SelectedItem, ComboBoxItem).HiddenValue()
        Else
            branchcode.Text = ""
        End If
        countTotalImage()
    End Sub

    Public Sub countTotalImage()
        If CheckBox1.Checked = True Then
            lblTotalImage.Text = FormatNumber(countqry("image.binaryinfo", "sizepicture<>2250 and sizepicture<>2257 and sizepicture<>2070 and sizepicture<>0"), 2)
        Else
            lblTotalImage.Text = FormatNumber(countqry("master.client inner join image.binaryinfo on client.custcode = binaryinfo.custcode", "branchcode='" & branchcode.Text & "' and sizepicture<>2250 and sizepicture<>2257 and sizepicture<>2070 and sizepicture<>0"), 2)
        End If
    End Sub

End Class