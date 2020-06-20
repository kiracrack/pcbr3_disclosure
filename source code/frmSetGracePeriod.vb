Imports System.Globalization
Imports MySql.Data.MySqlClient

Public Class frmSetGracePeriod
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()

        End If
        Return ProcessCmdKey
    End Function

   
    Private Sub cmdPrintAmortization_Click(sender As Object, e As EventArgs) Handles cmdPrintAmortization.Click
        frmGracePeriodSettings.UpdateGracePeriod(Val(txtSearch.Text))
        Me.Close()
    End Sub
End Class
