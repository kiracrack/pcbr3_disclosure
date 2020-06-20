Imports System.Globalization
Imports MySql.Data.MySqlClient

Public Class frmSetCharges
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()

        End If
        Return ProcessCmdKey
    End Function

    Private Sub cmdPrintAmortization_Click(sender As Object, e As EventArgs) Handles cmdPrintAmortization.Click
        frmCharges.UpdateCharges(ckirr.CheckState)
        Me.Close()
    End Sub

End Class
