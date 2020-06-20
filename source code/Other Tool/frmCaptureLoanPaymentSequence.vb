Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System
Imports System.IO
Imports System.ComponentModel

Public Class frmCaptureLoanPaymentSequence
    Dim bw As BackgroundWorker = New BackgroundWorker
    Dim datequery As Date
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
        Dim dbase As String = "db" & txtTRansactionDate.Value.ToString("yyyy").ToString & txtTRansactionDate.Value.ToString("MM").ToString

        If countqry("information_schema.SCHEMATA", "schema_name = '" & dbase & "'") = 0 And ckCaptureAllLoansAccounts.Checked = False Then
            MsgBox("Transaction selected date not available", MsgBoxStyle.Critical)
            Exit Sub
        ElseIf txtBranch.Text = "" And CheckBox1.Checked = False Then
            MsgBox("Please select branch", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If MessageBox.Show("Are you sure you want to continue? " & Environment.NewLine & Environment.NewLine & "Note: There's no undo function. please make sure you doing correctly!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = vbYes Then
            If Not bw.IsBusy = True Then
                cmdset.Enabled = False
                Me.ControlBox = False
                bw.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Sub bw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
       
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
        loadBranch()
        bw.WorkerSupportsCancellation = True
        bw.WorkerReportsProgress = True
        txtTRansactionDate.Text = Format(Now)
        com.CommandText = "CREATE DATABASE IF NOT EXISTS migration" : com.ExecuteNonQuery()
        com.CommandText = "CREATE TABLE IF NOT EXISTS `migration`.`tblloanpaymentcharges` (  `refno` varchar(20) NOT NULL,  `chgcode1` varchar(400) DEFAULT '',  `chgdesc1` varchar(400) DEFAULT '',  `chgcode2` varchar(400) DEFAULT '',  `chgdesc2` varchar(400) DEFAULT '',  `chgcode3` varchar(400) DEFAULT '',  `chgdesc3` varchar(400) DEFAULT '',  `chgcode4` varchar(400) DEFAULT '',  `chgdesc4` varchar(400) DEFAULT '',  `chgcode5` varchar(400) DEFAULT '',  `chgdesc5` varchar(400) DEFAULT '',  `chgcode6` varchar(400) DEFAULT '',  `chgdesc6` varchar(400) DEFAULT '',  PRIMARY KEY (`refno`) USING BTREE) ENGINE=MyISAM DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;" : com.ExecuteNonQuery()
        com.CommandText = "CREATE TABLE IF NOT EXISTS `migration`.`bosledger` (  `branchcode` char(10) COLLATE utf8_unicode_ci NOT NULL,  `lnrefno` text COLLATE utf8_unicode_ci NOT NULL,  `trndate` date NOT NULL DEFAULT '0000-00-00',  `reference` text COLLATE utf8_unicode_ci,  `transcode` text CHARACTER SET utf8,  `debit` double NOT NULL DEFAULT '0',  `credit` double NOT NULL DEFAULT '0',  `amtpaid` double NOT NULL DEFAULT '0',  `description` text CHARACTER SET latin1,  `ledgertype` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,  `remarks` text CHARACTER SET utf8,  `recby` varchar(5) COLLATE utf8_unicode_ci DEFAULT NULL) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci ROW_FORMAT=FIXED;" : com.ExecuteNonQuery()
    End Sub
    Public Sub loadBranch()
        LoadToComboBox("select * from master.branches order by branchname asc", "branchname", "branchcode", txtBranch)
    End Sub

    Private Sub txtBranch_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtBranch.SelectedValueChanged
        If txtBranch.Text <> "" Then
            branchcode.Text = DirectCast(txtBranch.SelectedItem, ComboBoxItem).HiddenValue()
        Else
            branchcode.Text = ""
        End If
        loadTotalTrn()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txtBranch.Enabled = False
            txtBranch.SelectedIndex = -1
        Else
            txtBranch.Enabled = True
        End If
        loadTotalTrn()
    End Sub

    Public Sub loadTotalTrn()
        Dim dbase As String = "db" & txtTRansactionDate.Value.ToString("yyyy").ToString & txtTRansactionDate.Value.ToString("MM").ToString
        If countqry("information_schema.SCHEMATA", "schema_name = '" & dbase & "'") = 0 Then
            txtTotalPayment.Text = "0"
            txtTotalAdjustment.Text = "0"
        Else
            txtTotalPayment.Text = FormatNumber(countRecord(dbase & ".lnwtermdet where cancelled=0 And pmntdate='" & ConvertDate(txtTRansactionDate.Value) & "'"), 0)
            txtTotalAdjustment.Text = FormatNumber(countRecord(dbase & ".loanadj where approvedby<>'' and adjdate='" & ConvertDate(txtTRansactionDate.Value) & "'"), 0)
        End If
        txtTotalLoanReleased.Text = FormatNumber(countRecord("master.loanwithterm where cancelled=0 " & If(ckCaptureAllLoansAccounts.Checked = True, "", " and loandate='" & ConvertDate(txtTRansactionDate.Value) & "'") & "  " & If(CheckBox1.Checked = True, "", " and branchcode='" & branchcode.Text & "'")), 0)
    End Sub

    Private Sub ckCaptureAllLoansAccounts_CheckedChanged(sender As Object, e As EventArgs) Handles ckCaptureAllLoansAccounts.CheckedChanged
        If ckCaptureAllLoansAccounts.Checked = True Then
            txtTRansactionDate.Enabled = False
        Else
            txtTRansactionDate.Enabled = True
        End If
        loadTotalTrn()
    End Sub

    Private Sub txtTRansactionDate_ValueChanged(sender As Object, e As EventArgs) Handles txtTRansactionDate.ValueChanged
        loadTotalTrn()
    End Sub

    Private Sub txtBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtBranch.SelectedIndexChanged

    End Sub
End Class