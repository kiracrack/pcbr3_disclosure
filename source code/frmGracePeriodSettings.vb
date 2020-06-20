Imports System.Globalization
Imports MySql.Data.MySqlClient

Public Class frmGracePeriodSettings
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()

        End If
        Return ProcessCmdKey
    End Function
    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        If e.KeyChar() = Chr(13) Then
            LoadLoanProduct()
        End If
    End Sub

    Public Sub LoadLoanProduct()
        dst = New DataSet
        msda = New MySqlDataAdapter("select productid as 'Code', productname as 'Product Name', graceperiod as 'Grace Period',penaltyint as 'Penalty Interest' from action_query.tblloangraceperiod where productname like '%" & txtSearch.Text & "%'order by productname asc", conn)
        MyDataGridView.DataSource = Nothing
        msda.Fill(dst, 0)
        MyDataGridView.DataSource = dst.Tables(0)
        GridCurrencyColumn(MyDataGridView, {"Penalty Interest"})
        GridColumnAlignment(MyDataGridView, {"Code", "Grace Period", "Penalty Interest"}, DataGridViewContentAlignment.MiddleCenter)
    End Sub

    Public Function UpdatePastdueInterest(ByVal pastdueint As Double)
        For Each rw As DataGridViewRow In MyDataGridView.SelectedRows
            com.CommandText = "update action_query.tblloangraceperiod set penaltyint=" & pastdueint & " where productid='" & rw.Cells("Code").Value.ToString & "'" : com.ExecuteNonQuery()
            rw.Cells("Penalty Interest").Value = pastdueint
        Next
        Return True
    End Function

    Public Function UpdateGracePeriod(ByVal graceperiod As Integer)
        For Each rw As DataGridViewRow In MyDataGridView.SelectedRows
            com.CommandText = "update action_query.tblloangraceperiod set graceperiod='" & graceperiod & "' where productid='" & rw.Cells("Code").Value.ToString & "'" : com.ExecuteNonQuery()
            rw.Cells("Grace Period").Value = graceperiod
        Next
        Return True
    End Function
 
    Private Sub frmUnblockClearLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If countqry("information_schema.tables", "table_schema = 'action_query' AND table_name = 'tblloangraceperiod'") = 0 Then
            com.CommandText = "CREATE TABLE  `action_query`.`tblloangraceperiod` (  `productid` varchar(50) NOT NULL,  `productname` varchar(500) NOT NULL,  `graceperiod` int(10) unsigned NOT NULL DEFAULT '0',  `penaltyint` double NOT NULL DEFAULT '0',  PRIMARY KEY (`productid`)) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=FIXED;" : com.ExecuteNonQuery()
        End If
        com.CommandText = "INSERT INTO action_query.tblloangraceperiod (productid,productname) SELECT prodcode,prodname FROM master.loanprod WHERE prodcode not in (SELECT productid FROM action_query.tblloangraceperiod);" : com.ExecuteNonQuery()
        LoadLoanProduct()
    End Sub

    Private Sub ViewTransactionDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewTransactionDetailsToolStripMenuItem.Click
        frmSetGracePeriod.Show(Me)
    End Sub

    Private Sub SetPasdueInterestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetPasdueInterestToolStripMenuItem.Click
        frmSetPastDueInterest.Show(Me)
    End Sub

End Class
