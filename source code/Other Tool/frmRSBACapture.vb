Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System
Imports System.IO
Imports System.ComponentModel

Public Class frmRSBACapture
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


        If MessageBox.Show("Are you sure you want to continue? " & Environment.NewLine & Environment.NewLine & "Note: There's no undo function. please make sure you doing correctly!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = vbYes Then
            If Not bw.IsBusy = True Then
                cmdset.Enabled = False
                cmdExportData.Enabled = False
                Me.ControlBox = False
                bw.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Sub bw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        Dim a As Double = 0
        Dim dst As New DataSet
        msda = New MySqlDataAdapter("select fullname from action_query.rsbsa_master_list", conn)
        msda.SelectCommand.CommandTimeout = 9000000
        msda.Fill(dst, 0)
        For cnt = 0 To dst.Tables(0).Rows.Count - 1
            With (dst.Tables(0))
                If bw.CancellationPending = True Then
                    e.Cancel = True
                    Exit For
                Else
                    System.Threading.Thread.Sleep(0)
                    com.CommandText = "UPDATE action_query.rsbsa_" & datequery.ToString("yyyyMMdd") & " set onthelist=1 where fullname = '" & rchar(.Rows(cnt)("fullname").ToString()) & "'" : com.ExecuteNonQuery()
                    bw.ReportProgress(cnt)
                End If
            End With
        Next
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
            Me.TextBox1.Text = "Done Search"
        End If
        Me.ControlBox = True
        cmdset.Enabled = True
        cmdExportData.Enabled = True
    End Sub

    Private Sub frmRSBACapture_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        datequery = qrysingledata("trndate", "trndate", "master.syscalendar where forsystem=1")
        txtDatePcbr3.Text = datequery.ToString("yyyy-MM-dd")
        bw.WorkerSupportsCancellation = True
        bw.WorkerReportsProgress = True
        PCBRCapture()
        Label2.Text = FormatNumber(countRecord("action_query.rsbsa_master_list"), 0)
    End Sub

    Public Sub PCBRCapture()
        If countqry("information_schema.tables", "table_schema = 'action_query' AND table_name = 'rsbsa_" & datequery.ToString("yyyyMMdd") & "'") = 0 Then
            cmdCapturepcbrclient.Enabled = True
            cmdCapturepcbrclient.Text = "Capture PCBR3 Client List"
            cmdExportData.Enabled = False
        Else
            cmdCapturepcbrclient.Enabled = False
            cmdCapturepcbrclient.Text = "PCBR3 Client already Captured"
            cmdExportData.Enabled = True
        End If
    End Sub
 
    Private Sub cmdCapturepcbrclient_Click(sender As Object, e As EventArgs) Handles cmdCapturepcbrclient.Click
        If MessageBox.Show("Are you sure you want to continue? " & Environment.NewLine & Environment.NewLine & "Note: There's no undo function. please make sure you doing correctly!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = vbYes Then
            com.CommandText = "create table action_query.rsbsa_" & datequery.ToString("yyyyMMdd") & " (id INTEGER NOT NULL AUTO_INCREMENT, PRIMARY KEY(id), INDEX fullname (fullname), INDEX lname (`Last Name`), index fname (`First Name`)) select (select branchname from master.branches where branchcode = loanwithterm.branchcode) as 'branch',concat(lcase(lname),', ',lcase(fname)) as 'fullname', lname as 'Last Name',fname as 'First Name',left(mname,1) as 'MI',if(sex=0,'M','F') as 'Sex',birthdate,res_street as 'Barangay',res_city as 'Municipality',res_province as 'Province',refno as 'PN Number', (select count(*) from master.loanwithterm as b where b.custcode = client.custcode and cancelled=0) as 'Loan Cycle',loandate as 'Date Release', Maturity as 'Maturity Date', intrate as 'interest', principal as 'Loan Amount', 0 as 'onthelist' from master.loanwithterm inner join master.client on loanwithterm.custcode = client.custcode where pribal>0 and cancelled=0;" : com.ExecuteNonQuery()
            PCBRCapture()
            MessageBox.Show("Database successfully Captured", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub cmdExportData_Click(sender As Object, e As EventArgs) Handles cmdExportData.Click
        Dim f As FolderBrowserDialog = New FolderBrowserDialog
        Try
            If f.ShowDialog() = DialogResult.OK Then
                msda = New MySqlDataAdapter("select * from `action_query`.`rsbsa_" & datequery.ToString("yyyyMMdd") & "` where onthelist=1", conn)
                dst = New DataSet
                msda.SelectCommand.CommandTimeout = 600000
                msda.Fill(dst, 0)
                dst.WriteXml(f.SelectedPath & "\KB CLIENT LIST (FOUND ON RSBSA LIST) AS OF " & datequery.ToString("yyyy-MM-dd") & ".xls")

                msda = New MySqlDataAdapter("select * from `action_query`.`rsbsa_" & datequery.ToString("yyyyMMdd") & "` where onthelist=0", conn)
                dst = New DataSet
                msda.SelectCommand.CommandTimeout = 600000
                msda.Fill(dst, 0)
                dst.WriteXml(f.SelectedPath & "\KB CLIENT LIST (NOT FOUND ON RSBSA LIST) AS OF " & datequery.ToString("yyyy-MM-dd") & ".xls")

                MessageBox.Show("Export done successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK)
        End Try
    End Sub
End Class