Imports System.Globalization
Imports MySql.Data.MySqlClient

Public Class DSandASGenerator

    Private Sub txtrefcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtrefcode.KeyPress
        If e.KeyChar() = Chr(13) Then
            If countqry("information_schema.tables", "table_schema = 'action_query' AND table_name = 'tbldisclosurecharges'") = 0 Then
                MsgBox("Charges settings currently not set")
                Exit Sub
            ElseIf countqry("information_schema.tables", "table_schema = 'action_query' AND table_name = 'tblloangraceperiod'") = 0 Then
                MsgBox("Grace period settings currently not set")
                Exit Sub
            End If

            If countqry("master.loanwithterm", "refno='" & txtrefcode.Text & "'") = 0 Then
                txtClientName.Text = "" : txtLoanAmount.Text = "" : txtProductName.Text = "" : txtpaymentMode.Text = ""
                cmdPrintDisclosure.Enabled = False
                cmdPrintAmortization.Enabled = False
                MsgBox("No record found", vbExclamation)
            Else
                dst = New DataSet
                msda = New MySqlDataAdapter("select *, (select concat(ucase(lname) ,', ', ucase(fname)) from master.client  where custcode =  loanwithterm.custcode)  as cname,(select prodname from loanprod where prodcode=loanwithterm.loanprod) as 'product' from master.loanwithterm where refno='" & txtrefcode.Text & "'", conn)
                msda.SelectCommand.CommandTimeout = 9000000
                msda.Fill(dst, 0)
                If dst.Tables(0).Rows.Count > 0 Then
                    For cnt = 0 To dst.Tables(0).Rows.Count - 1
                        With (dst.Tables(0))
                            cmdPrintDisclosure.Enabled = True
                            cmdPrintAmortization.Enabled = True
                            txtClientName.Text = .Rows(cnt)("cname").ToString
                            txtLoanAmount.Text = FormatNumber(.Rows(cnt)("principal").ToString, 2)
                            txtProductName.Text = .Rows(cnt)("product").ToString
                            txtpaymentMode.Text = .Rows(cnt)("amortcode").ToString

                            'GET FILLING FEE
                            If countqry("action_query.tbldisclosurecharges", "chargecode='" & .Rows(cnt)("chgcode1").ToString & "' and filingfee=1") > 0 Then
                                txtFilingFee.Text = FormatNumber(.Rows(cnt)("chgamt1").ToString, 2)
                                ckFillingFee.Checked = True
                            End If
                            If countqry("action_query.tbldisclosurecharges", "chargecode='" & .Rows(cnt)("chgcode2").ToString & "' and filingfee=1") > 0 Then
                                txtFilingFee.Text = FormatNumber(.Rows(cnt)("chgamt2").ToString, 2)
                                ckFillingFee.Checked = True
                            End If
                            If countqry("action_query.tbldisclosurecharges", "chargecode='" & .Rows(cnt)("chgcode3").ToString & "' and filingfee=1") > 0 Then
                                txtFilingFee.Text = FormatNumber(.Rows(cnt)("chgamt3").ToString, 2)
                                ckFillingFee.Checked = True
                            End If
                            If countqry("action_query.tbldisclosurecharges", "chargecode='" & .Rows(cnt)("chgcode4").ToString & "' and filingfee=1") > 0 Then
                                txtFilingFee.Text = FormatNumber(.Rows(cnt)("chgamt4").ToString, 2)
                                ckFillingFee.Checked = True
                            End If
                            If countqry("action_query.tbldisclosurecharges", "chargecode='" & .Rows(cnt)("chgcode5").ToString & "' and filingfee=1") > 0 Then
                                txtFilingFee.Text = FormatNumber(.Rows(cnt)("chgamt5").ToString, 2)
                                ckFillingFee.Checked = True
                            End If
                            If countqry("action_query.tbldisclosurecharges", "chargecode='" & .Rows(cnt)("chgcode6").ToString & "' and filingfee=1") > 0 Then
                                txtFilingFee.Text = FormatNumber(.Rows(cnt)("chgamt6").ToString, 2)
                                ckFillingFee.Checked = True
                            End If

                            'GET PROCESSING FEE
                            If countqry("action_query.tbldisclosurecharges", "chargecode='" & .Rows(cnt)("chgcode1").ToString & "' and processingfee=1") > 0 Then
                                txtProcessingFee.Text = FormatNumber(.Rows(cnt)("chgamt1").ToString, 2)
                                ckProcessingfee.Checked = True
                            End If
                            If countqry("action_query.tbldisclosurecharges", "chargecode='" & .Rows(cnt)("chgcode2").ToString & "' and processingfee=1") > 0 Then
                                txtProcessingFee.Text = FormatNumber(.Rows(cnt)("chgamt2").ToString, 2)
                                ckProcessingfee.Checked = True
                            End If
                            If countqry("action_query.tbldisclosurecharges", "chargecode='" & .Rows(cnt)("chgcode3").ToString & "' and processingfee=1") > 0 Then
                                txtProcessingFee.Text = FormatNumber(.Rows(cnt)("chgamt3").ToString, 2)
                                ckProcessingfee.Checked = True
                            End If
                            If countqry("action_query.tbldisclosurecharges", "chargecode='" & .Rows(cnt)("chgcode4").ToString & "' and processingfee=1") > 0 Then
                                txtProcessingFee.Text = FormatNumber(.Rows(cnt)("chgamt4").ToString, 2)
                                ckProcessingfee.Checked = True
                            End If
                            If countqry("action_query.tbldisclosurecharges", "chargecode='" & .Rows(cnt)("chgcode5").ToString & "' and processingfee=1") > 0 Then
                                txtProcessingFee.Text = FormatNumber(.Rows(cnt)("chgamt5").ToString, 2)
                                ckProcessingfee.Checked = True
                            End If
                            If countqry("action_query.tbldisclosurecharges", "chargecode='" & .Rows(cnt)("chgcode6").ToString & "' and processingfee=1") > 0 Then
                                txtProcessingFee.Text = FormatNumber(.Rows(cnt)("chgamt6").ToString, 2)
                                ckProcessingfee.Checked = True
                            End If
                        End With
                    Next
                    txtFilingFee.Focus()
                Else
                    txtClientName.Text = ""
                    txtLoanAmount.Text = ""
                    txtProductName.Text = ""
                    txtpaymentMode.Text = ""
                    cmdPrintDisclosure.Enabled = False
                    cmdPrintAmortization.Enabled = False
                    MsgBox("No record found", vbExclamation)
                End If
            End If
        End If
    End Sub
  
    Private Sub frmLoanAdjustment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If conn.State = ConnectionState.Closed Then
            If System.IO.File.Exists(file_conn) = False Then
                frmConnectionSetup.ShowDialog()
                End
            Else
                SingleConnectionVerify()
            End If
        End If
        GlobalFullname = "utilitytool"
    End Sub

    Private Sub cmdPrintAmortization_Click(sender As Object, e As EventArgs) Handles cmdPrintAmortization.Click
        PrintAmortization(txtrefcode.Text, Val(CC(txtLoanAmount.Text)), txtpaymentMode.Text, Me)
    End Sub

    Private Sub GracePeriodSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GracePeriodSettingsToolStripMenuItem.Click
        frmGracePeriodSettings.ShowDialog(Me)
    End Sub

    Private Sub ChargesSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChargesSettingsToolStripMenuItem.Click
        frmCharges.ShowDialog(Me)
    End Sub

    Private Sub cmdPrintDisclosure_Click(sender As Object, e As EventArgs) Handles cmdPrintDisclosure.Click
        PrintDisclosure(txtrefcode.Text, Val(CC(txtLoanAmount.Text)), ckFillingFee.CheckState, Val(CC(txtFilingFee.Text)), ckProcessingfee.CheckState, Val(CC(txtProcessingFee.Text)), txtpaymentMode.Text, Me)
    End Sub
End Class
