Imports System.Globalization
Imports MySql.Data.MySqlClient

Public Class frmCharges
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()

        End If
        Return ProcessCmdKey
    End Function

    Public Sub LoadCurrentCharges()
        dst = New DataSet
        msda = New MySqlDataAdapter("select chargecode as 'Code', Description,  includeeir as 'Include EIR Computation' from action_query.tbldisclosurecharges where description like '%" & txtSearch.Text & "%' order by Description asc", conn)
        MyDataGridView.DataSource = Nothing
        msda.Fill(dst, 0)
        MyDataGridView.DataSource = dst.Tables(0)
        GridColumnAlignment(MyDataGridView, {"Code", "Include EIR Computation"}, DataGridViewContentAlignment.MiddleCenter)
    End Sub

    Public Function UpdateCharges(ByVal irrcompute As Boolean)
        For Each rw As DataGridViewRow In MyDataGridView.SelectedRows
            com.CommandText = "update action_query.tbldisclosurecharges set includeeir=" & irrcompute & " where chargecode='" & rw.Cells("Code").Value.ToString & "'" : com.ExecuteNonQuery()
            rw.Cells("Include EIR Computation").Value = irrcompute
        Next
        Return True
    End Function


    Private Sub frmUnblockClearLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If countqry("information_schema.tables", "table_schema = 'action_query' AND table_name = 'tbldisclosurecharges'") = 0 Then
            com.CommandText = "CREATE TABLE  `action_query`.`tbldisclosurecharges` (  `chargecode` varchar(50) NOT NULL,  `description` varchar(500) NOT NULL,  `includeeir` tinyint(1) NOT NULL DEFAULT '0',  `filingfee` tinyint(1) NOT NULL DEFAULT '0',  `processingfee` tinyint(1) NOT NULL DEFAULT '0',  `servicecharge` tinyint(1) NOT NULL DEFAULT '0',  PRIMARY KEY (`chargecode`)) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=FIXED;" : com.ExecuteNonQuery()
        End If
        com.CommandText = "INSERT INTO action_query.tbldisclosurecharges (chargecode,description) SELECT chgcode,chgdesc FROM master.charges WHERE chgcode not in (SELECT chargecode FROM action_query.tbldisclosurecharges);" : com.ExecuteNonQuery()
        com.CommandText = "update `action_query`.`tbldisclosurecharges` set filingfee=1 where description like '%filing%';" : com.ExecuteNonQuery()
        com.CommandText = "update `action_query`.`tbldisclosurecharges` set processingfee=1 where description like '%process%';" : com.ExecuteNonQuery()
        LoadCurrentCharges()
    End Sub

    Private Sub ViewTransactionDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewTransactionDetailsToolStripMenuItem.Click
        frmSetCharges.Show(Me)
    End Sub

  
    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        If e.KeyChar() = Chr(13) Then
            LoadCurrentCharges()
        End If
    End Sub

     
End Class
