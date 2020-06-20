Imports System.Globalization
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmBranchConnectionSetup
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim detailsFile As StreamWriter = Nothing
        If txtConnection.Text = "" Then
            MsgBox("Please select Connection!", MsgBoxStyle.Critical)
            txtConnection.Focus()
            Exit Sub
        End If

        If MessageBox.Show("Are you sure you want to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then
            detailsFile = Nothing
            detailsFile = New StreamWriter(file_conn, True)
            If txtConnection.Text = "DUMAGUETE BRANCH" Or txtConnection.Text = "LIBERTAD MICRO" Or txtConnection.Text = "OROQUIETA BRANCH" Then
                detailsFile.WriteLine(EncryptTripleDES(txtConnection.Text & ",10.1.0.100,3306,100,1210010134"))
            Else
                detailsFile.WriteLine(EncryptTripleDES(txtConnection.Text & ",10.1.0.200,3306,100,1210010134"))
            End If
            detailsFile.Close()
            If SingleConnectionVerify() = False Then
                MsgBox("Connection Aborted! please make sure you have select correct connection", MsgBoxStyle.Critical)
                Exit Sub
            End If
            MsgBox("System utility successfully configured! Please re-open the system.", MsgBoxStyle.Information)
            Me.Close()
        End If
    End Sub

    
    Private Function OpenNewServer(ByVal host As String, ByVal port As String, ByVal user As String, ByVal pass As String) As Boolean
        Try
            connclient = New MySql.Data.MySqlClient.MySqlConnection
            connclient.ConnectionString = "server=" & host & "; Port=" & port & "; user id=" & user & "; password=" & pass & "; database=master"
            connclient.Open()
            comclient.Connection = connclient
            comclient.CommandTimeout = 0
            OpenNewServer = True

        Catch errMYSQL As MySqlException
            MessageBox.Show("Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            OpenNewServer = False
            Return False
        Catch errMS As Exception
            MessageBox.Show("Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            OpenNewServer = False
            Return False
        End Try
    End Function
 
    Private Sub txtConnection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtConnection.SelectedIndexChanged

    End Sub
End Class
