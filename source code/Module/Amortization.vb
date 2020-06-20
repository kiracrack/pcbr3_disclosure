Imports MySql.Data.MySqlClient
Module Amortization
    Public Function PrintAmortization(ByVal pnnumber As String, ByVal principalamount As Double, ByVal paymentmode As String, ByVal form As Windows.Forms.Form)
        Dim TableHead As String = "" : Dim TableRow As String = "" : Dim TableFooter As String = "" : Dim TableServiceTransaction As String = "" : Dim TablePartsTransaction As String = "" : Dim Total As Double = 0
        Dim Template As String = Application.StartupPath.ToString & "\amortization.html"
        Dim SaveLocation As String = Application.StartupPath.ToString & "\loans\" & pnnumber & ".html"
        If Not System.IO.Directory.Exists(Application.StartupPath.ToString & "\loans") = True Then
            System.IO.Directory.CreateDirectory(Application.StartupPath.ToString & "\loans")
        End If
        If System.IO.File.Exists(SaveLocation) = True Then
            System.IO.File.Delete(SaveLocation)
        End If
        Dim dst As New DataSet
        My.Computer.FileSystem.CopyFile(Template, SaveLocation)


        dst = New DataSet
        msda = New MySqlDataAdapter("select *, UCASE((select concat(fname,' ',lname) from master.client where custcode=l.custcode)) as cname, " _
                                        + " (select concat(res_street, ', ', res_city, ', ',res_province,' ', res_zipcode) from master.client where custcode=l.custcode) as address, " _
                                        + " (select prodname from loanprod where prodcode = l.loanprod) as 'product', " _
                                        + " ifnull((select chgdesc from master.charges where chgcode = l.chgcode1),'')  as 'charges1',ifnull((select chgdesc from master.charges where chgcode = l.chgcode2),'')  as 'charges2',ifnull((select chgdesc from master.charges where chgcode = l.chgcode3),'')  as 'charges3',ifnull((select chgdesc from master.charges where chgcode = l.chgcode4),'')  as 'charges4',ifnull((select chgdesc from master.charges where chgcode = l.chgcode5),'')  as 'charges5',ifnull((select chgdesc from master.charges where chgcode = l.chgcode6),'')  as 'charges6' from master.loanwithterm as l where l.refno='" & pnnumber & "'", conn)
        msda.SelectCommand.CommandTimeout = 9000000
        msda.Fill(dst, 0)
        For cnt = 0 To dst.Tables(0).Rows.Count - 1
            With (dst.Tables(0))
                My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[refno]", pnnumber), False)
                My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[cname]", .Rows(cnt)("cname").ToString), False)
                My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[loandate]", CDate(.Rows(cnt)("loandate").ToString).ToString("MMMM dd, yyyy")), False)
                My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[maturity]", CDate(.Rows(cnt)("maturity").ToString).ToString("MMMM dd, yyyy")), False)
                My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[branch]", qrysingledata("brhead", "ucase(branchname) as brhead", "`master`.`branches` where branchcode='" & .Rows(cnt)("branchcode").ToString & "'")), False)
                My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[loanprod]", .Rows(cnt)("product").ToString), False)
                My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[numofinstallement]", .Rows(cnt)("numbinst").ToString), False)
                My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[installmentmode]", paymentmode), False)
                My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[manager]", qrysingledata("brhead", "ucase(branchhead) as brhead", "`master`.`branches` where branchcode='" & .Rows(cnt)("branchcode").ToString & "'")), False)
            End With

        Next
       


        Dim Amortbalance As Double = principalamount
        Dim totalAmortPayment As Double = 0
        Dim totalPrincipal As Double = 0 : Dim TotalInterest As Double = 0
        Dim ttlchg1 As Double = 0 : Dim ttlchg2 As Double = 0 : Dim ttlchg3 As Double = 0 : Dim ttlchg4 As Double = 0 : Dim ttlchg5 As Double = 0 : Dim ttlchg6 As Double = 0

        msda = New MySqlDataAdapter("select amortsched from master.lnamortsked where refno='" & pnnumber & "'", conn)
        msda.SelectCommand.CommandTimeout = 9000000
        msda.Fill(dst, 0)
        For cnt = 0 To dst.Tables(0).Rows.Count - 1
            With (dst.Tables(0))
                Dim getfirstline As String = ""

                Dim cnnw As Integer = 0 : Dim cnn As Integer = 0
                For Each word In .Rows(cnt)("amortsched").ToString().Split(New Char() {"|"c})
                    If cnnw = 0 Then
                        getfirstline = word
                    End If
                    cnnw = cnnw + 1
                Next
                TableHead = "" : TableRow = "" : TableFooter = "" : Total = 0
                TableHead = createHeader(getfirstline, principalamount) & Chr(13)

                Dim totalRow As Integer = 0
                For Each word In .Rows(cnt)("amortsched").ToString().Split(New Char() {"|"c})
                    totalRow = totalRow + 1
                Next
                Dim getAllAmortNumber(totalRow + 1) As Double

                For Each words In .Rows(cnt)("amortsched").ToString().Split(New Char() {"|"c})
                    Dim DateAmort As String = "" : Dim principal As Double = 0 : Dim interest As Double = 0
                    Dim chgcode1 As String = "" : Dim chgacct1 As String = "" : Dim chgamt1 As Double = 0 : Dim chgdesc1 As String = ""
                    Dim chgcode2 As String = "" : Dim chgacct2 As String = "" : Dim chgamt2 As Double = 0 : Dim chgdesc2 As String = ""
                    Dim chgcode3 As String = "" : Dim chgacct3 As String = "" : Dim chgamt3 As Double = 0 : Dim chgdesc3 As String = ""
                    Dim chgcode4 As String = "" : Dim chgacct4 As String = "" : Dim chgamt4 As Double = 0 : Dim chgdesc4 As String = ""
                    Dim chgcode5 As String = "" : Dim chgacct5 As String = "" : Dim chgamt5 As Double = 0 : Dim chgdesc5 As String = ""
                    Dim chgcode6 As String = "" : Dim chgacct6 As String = "" : Dim chgamt6 As Double = 0 : Dim chgdesc6 As String = ""
                    Dim cns As Integer = 0

                    For Each word In words.Split(New Char() {":"c})
                        If cns = 0 Then
                            DateAmort = word
                        ElseIf cns = 1 Then
                            principal = word
                        ElseIf cns = 2 Then
                            interest = word
                        ElseIf cns = 3 Then
                            chgcode1 = word
                        ElseIf cns = 4 Then
                            chgacct1 = word
                        ElseIf cns = 5 Then
                            chgamt1 = word
                        ElseIf cns = 6 Then
                            chgcode2 = word
                        ElseIf cns = 7 Then
                            chgacct2 = word
                        ElseIf cns = 8 Then
                            chgamt2 = word
                        ElseIf cns = 9 Then
                            chgcode3 = word
                        ElseIf cns = 10 Then
                            chgacct3 = word
                        ElseIf cns = 11 Then
                            chgamt3 = word
                        ElseIf cns = 12 Then
                            chgcode4 = word
                        ElseIf cns = 13 Then
                            chgacct4 = word
                        ElseIf cns = 14 Then
                            chgamt4 = word
                        ElseIf cns = 15 Then
                            chgcode5 = word
                        ElseIf cns = 16 Then
                            chgacct5 = word
                        ElseIf cns = 17 Then
                            chgamt5 = word
                        ElseIf cns = 18 Then
                            chgcode6 = word
                        ElseIf cns = 19 Then
                            chgacct6 = word
                        ElseIf cns = 20 Then
                            chgamt6 = word
                        End If
                        cns = cns + 1
                    Next
                    cnn = cnn + 1

                    totalPrincipal = totalPrincipal + principal
                    TotalInterest = TotalInterest + interest
                    ttlchg1 = ttlchg1 + chgamt1
                    ttlchg2 = ttlchg2 + chgamt2
                    ttlchg3 = ttlchg3 + chgamt3
                    ttlchg4 = ttlchg4 + chgamt4
                    ttlchg5 = ttlchg5 + chgamt5
                    ttlchg6 = ttlchg6 + chgamt6
                    totalAmortPayment = principal + interest + chgamt1 + chgamt2 + chgamt3 + chgamt4 + chgamt5 + chgamt6

                    Amortbalance = Amortbalance - principal
                    If DateAmort <> "" Then
                        TableRow += "<tr  class='tr' > " _
                        + " <td class='td' align='center'>" & cnn & "</td> " _
                        + " <td class='td' align='center'>" & DateAmort & "</td> " _
                        + " <td class='td' align='right'>" & FormatNumber(principal, 2) & "</td> " _
                        + " <td class='td' align='right'>" & FormatNumber(interest, 2) & "</td> " _
                        + If(chgamt1 = 0, "", " <td class='td' align='right'>" & FormatNumber(chgamt1, 2) & "</td> ") _
                        + If(chgamt2 = 0, "", " <td class='td' align='right'>" & FormatNumber(chgamt2, 2) & "</td> ") _
                        + If(chgamt3 = 0, "", " <td class='td' align='right'>" & FormatNumber(chgamt3, 2) & "</td> ") _
                        + If(chgamt4 = 0, "", " <td class='td' align='right'>" & FormatNumber(chgamt4, 2) & "</td> ") _
                        + If(chgamt5 = 0, "", " <td class='td' align='right'>" & FormatNumber(chgamt5, 2) & "</td> ") _
                        + If(chgamt6 = 0, "", " <td class='td' align='right'>" & FormatNumber(chgamt6, 2) & "</td> ") _
                        + " <td class='td' align='right'>" & FormatNumber(totalAmortPayment, 2) & "</td> " _
                        + " <td class='td' align='right'>" & FormatNumber(Amortbalance, 2) & "</td> " _
                        + " </tr> " & Chr(13)

                    End If
                Next
  
                TableRow += "<tr> " _
                       + " <td align='center'>&nbsp</td><td align='center'></td> <td align='right'> </td> <td align='right'> </td></tr> " & Chr(13)
                TableRow += "<tr class='tr' > " _
                       + " <td class='td' align='center'> </td> " _
                       + " <td class='td' align='center'> </td> " _
                       + " <td class='td' align='right'>" & FormatNumber(totalPrincipal, 2) & "</td> " _
                       + " <td class='td' align='right'>" & FormatNumber(TotalInterest, 2) & "</td> " _
                        + If(ttlchg1 = 0, "", " <td class='td' align='right'>" & FormatNumber(ttlchg1, 2) & "</td> ") _
                        + If(ttlchg2 = 0, "", " <td class='td' align='right'>" & FormatNumber(ttlchg2, 2) & "</td> ") _
                        + If(ttlchg3 = 0, "", " <td class='td' align='right'>" & FormatNumber(ttlchg3, 2) & "</td> ") _
                        + If(ttlchg4 = 0, "", " <td class='td' align='right'>" & FormatNumber(ttlchg4, 2) & "</td> ") _
                        + If(ttlchg5 = 0, "", " <td class='td' align='right'>" & FormatNumber(ttlchg5, 2) & "</td> ") _
                        + If(ttlchg6 = 0, "", " <td class='td' align='right'>" & FormatNumber(ttlchg6, 2) & "</td> ") _
                        + " <td class='td' align='center'> </td> " _
                        + " <td class='td' align='center'> </td> " _
                 + " </tr> " & Chr(13)
            End With
        Next

        TableFooter = "</table>"
        TablePartsTransaction = TableHead + TableRow + TableFooter
        My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[amortsched]", TablePartsTransaction), False)
        PrintLXReceipt(SaveLocation.Replace("\", "/"), form)
    End Function

    Public Function createHeader(ByVal amortsked As String, ByVal principalbal As Double) As String
        For Each words In amortsked.Split(New Char() {"|"c})
            Dim DateAmort As String = "" : Dim principal As Double = 0 : Dim interest As Double = 0
            Dim chgcode1 As String = "" : Dim chgacct1 As String = "" : Dim chgamt1 As Double = 0 : Dim chgdesc1 As String = ""
            Dim chgcode2 As String = "" : Dim chgacct2 As String = "" : Dim chgamt2 As Double = 0 : Dim chgdesc2 As String = ""
            Dim chgcode3 As String = "" : Dim chgacct3 As String = "" : Dim chgamt3 As Double = 0 : Dim chgdesc3 As String = ""
            Dim chgcode4 As String = "" : Dim chgacct4 As String = "" : Dim chgamt4 As Double = 0 : Dim chgdesc4 As String = ""
            Dim chgcode5 As String = "" : Dim chgacct5 As String = "" : Dim chgamt5 As Double = 0 : Dim chgdesc5 As String = ""
            Dim chgcode6 As String = "" : Dim chgacct6 As String = "" : Dim chgamt6 As Double = 0 : Dim chgdesc6 As String = ""
            Dim cns As Integer = 0

            For Each word In words.Split(New Char() {":"c})
                If cns = 3 Then
                    chgcode1 = word
                ElseIf cns = 4 Then
                    chgacct1 = word
                ElseIf cns = 5 Then
                    chgamt1 = word
                ElseIf cns = 6 Then
                    chgcode2 = word
                ElseIf cns = 7 Then
                    chgacct2 = word
                ElseIf cns = 8 Then
                    chgamt2 = word
                ElseIf cns = 9 Then
                    chgcode3 = word
                ElseIf cns = 10 Then
                    chgacct3 = word
                ElseIf cns = 11 Then
                    chgamt3 = word
                ElseIf cns = 12 Then
                    chgcode4 = word
                ElseIf cns = 13 Then
                    chgacct4 = word
                ElseIf cns = 14 Then
                    chgamt4 = word
                ElseIf cns = 15 Then
                    chgcode5 = word
                ElseIf cns = 16 Then
                    chgacct5 = word
                ElseIf cns = 17 Then
                    chgamt5 = word
                ElseIf cns = 18 Then
                    chgcode6 = word
                ElseIf cns = 19 Then
                    chgacct6 = word
                ElseIf cns = 20 Then
                    chgamt6 = word
                End If
                cns = cns + 1
            Next
            createHeader = "<table border='1'> " _
                           + " <tr class='tr'> " _
                                + " <th class='th'>No. of Installment</th> " _
                                + " <th class='th'width='80'>Date</th> " _
                                + " <th class='th'width='80'>Principal</th> " _
                                + " <th class='th'width='80'>Interest</th> " _
                                + If(chgcode1 = "", If(checksavingsAccount(chgacct1) = True, getSavingsAccount(chgacct1), getPartyAccount(chgacct1)), getCharges(chgcode1)) _
                                + If(chgcode2 = "", If(checksavingsAccount(chgacct2) = True, getSavingsAccount(chgacct2), getPartyAccount(chgacct2)), getCharges(chgcode2)) _
                                + If(chgcode3 = "", If(checksavingsAccount(chgacct3) = True, getSavingsAccount(chgacct3), getPartyAccount(chgacct3)), getCharges(chgcode3)) _
                                + If(chgcode4 = "", If(checksavingsAccount(chgacct4) = True, getSavingsAccount(chgacct4), getPartyAccount(chgacct4)), getCharges(chgcode4)) _
                                + If(chgcode5 = "", If(checksavingsAccount(chgacct5) = True, getSavingsAccount(chgacct5), getPartyAccount(chgacct5)), getCharges(chgcode5)) _
                                + If(chgcode6 = "", If(checksavingsAccount(chgacct6) = True, getSavingsAccount(chgacct6), getPartyAccount(chgacct6)), getCharges(chgcode6)) _
                                + " <th class='th'>Total Amortization</th> " _
                                + " <th class='th' width='80'>Balance</th> " _
                            + " </tr> "
            createHeader += "<tr  class='tr' > " _
                        + " <td class='td' align='center'> </td> " _
                        + " <td class='td' align='center' </td> " _
                        + " <td class='td' align='right'> </td> " _
                        + " <td class='td' align='right'> </td> " _
                        + If(chgcode1 = "", "", " <td class='td' align='right'></td> ") _
                        + If(chgcode2 = "", "", " <td class='td' align='right'> </td> ") _
                        + If(chgcode3 = "", "", " <td class='td' align='right'> </td> ") _
                        + If(chgcode4 = "", "", " <td class='td' align='right'></td> ") _
                        + If(chgcode5 = "", "", " <td class='td' align='right'></td> ") _
                        + If(chgcode5 = "", "", " <td class='td' align='right'></td> ") _
                        + " <td class='td' align='right'></td> " _
                        + " <td class='td' align='right'></td> " _
                        + " <td class='td' align='right'>" & FormatNumber(principalbal, 2) & "</td> " _
                        + " </tr> " & Chr(13)
        Next
    End Function
    Public Function GetvalueAmortizationCode(ByVal amorthmode As String) As Integer
        If amorthmode = "MONTHLY" Then
            GetvalueAmortizationCode = 24
        ElseIf amorthmode = "WEEKLY" Then
            GetvalueAmortizationCode = 6
        ElseIf amorthmode = "SNGLPMNT" Then
            GetvalueAmortizationCode = 24
        ElseIf amorthmode = "SEMIMOS" Then
            GetvalueAmortizationCode = 12
        ElseIf amorthmode = "WEEKLYDEM" Then
            GetvalueAmortizationCode = 6
        ElseIf amorthmode = "QUARTERLY" Then
            GetvalueAmortizationCode = 8
        End If
        Return GetvalueAmortizationCode
    End Function
    Public Function checksavingsAccount(ByVal acct As String) As Boolean
        checksavingsAccount = CBool(countqry("master.depositaccounts", "acctnumber='" & acct & "' limit 1"))
        Return checksavingsAccount
    End Function

    Public Function getSavingsAccount(ByVal acct As String) As String
        getSavingsAccount = rchar(qrysingledata("acctnumber", "acctnumber", "master.depositaccounts where acctnumber='" & acct & "'"))
        If getSavingsAccount <> "" Then
            getSavingsAccount = " <th class='th'>Savings <br/>" & getSavingsAccount & "</th> "
        End If
        Return getSavingsAccount
    End Function

    Public Function getPartyAccount(ByVal acct As String) As String
        getPartyAccount = rchar(qrysingledata("entitysvaccount", "entitysvaccount", "master.3rdpartyaccount where entitycode='" & acct & "'"))
        If getPartyAccount <> "" Then
            getPartyAccount = " <th class='th'>Savings <br/>" & getPartyAccount & "</th> "
        End If
        Return getPartyAccount
    End Function

    Public Function getCharges(ByVal code As String) As String
        getCharges = rchar(qrysingledata("chgdesc", "chgdesc", "master.charges where chgcode='" & code & "'"))
        If getCharges <> "" Then
            getCharges = " <th class='th'>" & StrConv(getCharges.Replace("-", " "), vbProperCase) & "</th> "
        End If
        Return getCharges
    End Function
    Public Sub PrintLXReceipt(ByVal location As String, ByVal form As Windows.Forms.Form)
        Dim printProcess As New Diagnostics.ProcessStartInfo()
        printProcess.FileName = location
        Try
            Process.Start(printProcess)
            Form.WindowState = FormWindowState.Minimized
        Catch ex As Exception
            MessageBox.Show("File not found!", _
                          "Error Reprint Transaction", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Module
