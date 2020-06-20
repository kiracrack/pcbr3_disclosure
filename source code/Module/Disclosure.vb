Imports MySql.Data.MySqlClient

Module Disclosure
    Public Function PrintDisclosure(ByVal pnnumber As String, ByVal principalamount As Double, ByVal existsfilingfee As Boolean, ByVal filingfee As Double, ByVal existsprocessingfee As Boolean, ByVal processingfee As Double, ByVal paymentmode As String, ByVal form As Windows.Forms.Form)
        Dim TableHead As String = "" : Dim TableRow As String = "" : Dim TableFooter As String = "" : Dim bankcharges As String = "" : Dim othercharges As String = "" : Dim TablePartsTransaction As String = "" : Dim Total As Double = 0
        Dim Template As String = Application.StartupPath.ToString & "\desclosure.html"
        Dim SaveLocation As String = Application.StartupPath.ToString & "\disclosure\" & pnnumber & ".html"
        If Not System.IO.Directory.Exists(Application.StartupPath.ToString & "\disclosure") = True Then
            System.IO.Directory.CreateDirectory(Application.StartupPath.ToString & "\disclosure")
        End If
        If System.IO.File.Exists(SaveLocation) = True Then
            System.IO.File.Delete(SaveLocation)
        End If
        My.Computer.FileSystem.CopyFile(Template, SaveLocation)
        Dim dst As New DataSet
        Dim TotalCharges As Double = 0 : Dim EIRcharges As Double = 0 : Dim gracePeriod As Integer = 0
        dst = New DataSet
        msda = New MySqlDataAdapter("select *, UCASE((select concat(fname,' ',lname) from master.client where custcode=l.custcode)) as cname, " _
                                        + " (select concat(res_street, ', ', res_city, ', ',res_province,' ', res_zipcode) from master.client where custcode=l.custcode) as address, " _
                                        + " (select prodname from loanprod where prodcode = l.loanprod) as 'product', " _
                                        + " ifnull((select chgdesc from master.charges where chgcode = l.chgcode1),'')  as 'charges1',ifnull((select chgdesc from master.charges where chgcode = l.chgcode2),'')  as 'charges2',ifnull((select chgdesc from master.charges where chgcode = l.chgcode3),'')  as 'charges3',ifnull((select chgdesc from master.charges where chgcode = l.chgcode4),'')  as 'charges4',ifnull((select chgdesc from master.charges where chgcode = l.chgcode5),'')  as 'charges5',ifnull((select chgdesc from master.charges where chgcode = l.chgcode6),'')  as 'charges6' from master.loanwithterm as l where l.refno='" & pnnumber & "'", conn)
        msda.SelectCommand.CommandTimeout = 9000000
        msda.Fill(dst, 0)
        For cnt = 0 To dst.Tables(0).Rows.Count - 1
            With (dst.Tables(0))

                If .Rows(cnt)("charges1").ToString <> "" And Val(.Rows(cnt)("chgamt1").ToString) > 0 Then
                    TotalCharges = TotalCharges + Val(.Rows(cnt)("chgamt1").ToString)
                    If countqry("action_query.tbldisclosurecharges", "chargecode='" & .Rows(cnt)("chgcode1").ToString & "' and includeeir=1") > 0 Then
                        EIRcharges = EIRcharges + Val(.Rows(cnt)("chgamt1").ToString)
                        bankcharges = bankcharges + "<tr><td width='300'>" & UCase(.Rows(cnt)("charges1").ToString) & "</td><td width='50'>:</td><td  width='100'>" & FormatNumber(.Rows(cnt)("chgamt1").ToString, 2) & "</td></tr>"
                    Else
                        othercharges = othercharges + "<tr><td width='300'>" & UCase(.Rows(cnt)("charges1").ToString) & "</td><td width='50'>:</td><td  width='100'>" & FormatNumber(.Rows(cnt)("chgamt1").ToString, 2) & "</td></tr>"
                    End If
                End If
                If .Rows(cnt)("charges2").ToString <> "" And Val(.Rows(cnt)("chgamt2").ToString) > 0 Then
                    TotalCharges = TotalCharges + Val(.Rows(cnt)("chgamt2").ToString)
                    If countqry("action_query.tbldisclosurecharges", "chargecode='" & .Rows(cnt)("chgcode2").ToString & "' and includeeir=1") > 0 Then
                        EIRcharges = EIRcharges + Val(.Rows(cnt)("chgamt2").ToString)
                        bankcharges = bankcharges + "<tr><td width='300'>" & UCase(.Rows(cnt)("charges2").ToString) & "</td><td width='50'>:</td><td  width='100'>" & FormatNumber(.Rows(cnt)("chgamt2").ToString, 2) & "</td></tr>"
                    Else
                        othercharges = othercharges + "<tr><td width='300'>" & UCase(.Rows(cnt)("charges2").ToString) & "</td><td width='50'>:</td><td  width='100'>" & FormatNumber(.Rows(cnt)("chgamt2").ToString, 2) & "</td></tr>"
                    End If
                End If
                If .Rows(cnt)("charges3").ToString <> "" And Val(.Rows(cnt)("chgamt3").ToString) > 0 Then
                    TotalCharges = TotalCharges + Val(.Rows(cnt)("chgamt3").ToString)
                    If countqry("action_query.tbldisclosurecharges", "chargecode='" & .Rows(cnt)("chgcode3").ToString & "' and includeeir=1") > 0 Then
                        EIRcharges = EIRcharges + Val(.Rows(cnt)("chgamt3").ToString)
                        bankcharges = bankcharges + "<tr><td width='300'>" & UCase(.Rows(cnt)("charges3").ToString) & "</td><td width='50'>:</td><td  width='100'>" & FormatNumber(.Rows(cnt)("chgamt3").ToString, 2) & "</td></tr>"
                    Else
                        othercharges = othercharges + "<tr><td width='300'>" & UCase(.Rows(cnt)("charges3").ToString) & "</td><td width='50'>:</td><td  width='100'>" & FormatNumber(.Rows(cnt)("chgamt3").ToString, 2) & "</td></tr>"
                    End If
                End If
                If .Rows(cnt)("charges4").ToString <> "" And Val(.Rows(cnt)("chgamt4").ToString) > 0 Then
                    TotalCharges = TotalCharges + Val(.Rows(cnt)("chgamt4").ToString)
                    If countqry("action_query.tbldisclosurecharges", "chargecode='" & .Rows(cnt)("chgcode4").ToString & "' and includeeir=1") > 0 Then
                        EIRcharges = EIRcharges + Val(.Rows(cnt)("chgamt4").ToString)
                        bankcharges = bankcharges + "<tr><td width='300'>" & UCase(.Rows(cnt)("charges4").ToString) & "</td><td width='50'>:</td><td  width='100'>" & FormatNumber(.Rows(cnt)("chgamt4").ToString, 2) & "</td></tr>"
                    Else
                        othercharges = othercharges + "<tr><td width='300'>" & UCase(.Rows(cnt)("charges4").ToString) & "</td><td width='50'>:</td><td  width='100'>" & FormatNumber(.Rows(cnt)("chgamt4").ToString, 2) & "</td></tr>"
                    End If
                End If
                If .Rows(cnt)("charges5").ToString <> "" And Val(.Rows(cnt)("chgamt5").ToString) > 0 Then
                    TotalCharges = TotalCharges + Val(.Rows(cnt)("chgamt5").ToString)
                    If countqry("action_query.tbldisclosurecharges", "chargecode='" & .Rows(cnt)("chgcode5").ToString & "' and includeeir=1") > 0 Then
                        EIRcharges = EIRcharges + Val(.Rows(cnt)("chgamt5").ToString)
                        bankcharges = bankcharges + "<tr><td width='300'>" & UCase(.Rows(cnt)("charges5").ToString) & "</td><td width='50'>:</td><td  width='100'>" & FormatNumber(.Rows(cnt)("chgamt5").ToString, 2) & "</td></tr>"
                    Else
                        othercharges = othercharges + "<tr><td width='300'>" & UCase(.Rows(cnt)("charges5").ToString) & "</td><td width='50'>:</td><td  width='100'>" & FormatNumber(.Rows(cnt)("chgamt5").ToString, 2) & "</td></tr>"
                    End If
                End If
                If .Rows(cnt)("charges6").ToString <> "" And Val(.Rows(cnt)("chgamt6").ToString) > 0 Then
                    TotalCharges = TotalCharges + Val(.Rows(cnt)("chgamt6").ToString)
                    If countqry("action_query.tbldisclosurecharges", "chargecode='" & .Rows(cnt)("chgcode6").ToString & "' and includeeir=1") > 0 Then
                        EIRcharges = EIRcharges + Val(.Rows(cnt)("chgamt6").ToString)
                        bankcharges = bankcharges + "<tr><td width='300'>" & UCase(.Rows(cnt)("charges6").ToString) & "</td><td width='50'>:</td><td  width='100'>" & FormatNumber(.Rows(cnt)("chgamt6").ToString, 2) & "</td></tr>"
                    Else
                        othercharges = othercharges + "<tr><td width='300'>" & UCase(.Rows(cnt)("charges6").ToString) & "</td><td width='50'>:</td><td  width='100'>" & FormatNumber(.Rows(cnt)("chgamt6").ToString, 2) & "</td></tr>"
                    End If
                End If
                If existsfilingfee = False And Val(filingfee) > 0 Then
                    EIRcharges = EIRcharges + Val(filingfee)
                    TotalCharges = TotalCharges + Val(filingfee)
                    bankcharges = bankcharges + "<tr><td width='300'>FILING FEE</td><td width='50'>:</td><td  width='100'>" & FormatNumber(filingfee, 2) & "</td></tr>"
                End If
                If existsprocessingfee = False And Val(processingfee) > 0 Then
                    EIRcharges = EIRcharges + Val(processingfee)
                    TotalCharges = TotalCharges + Val(processingfee)
                    bankcharges = bankcharges + "<tr><td width='300'>PROCESSING FEE</td><td width='50'>:</td><td  width='100'>" & FormatNumber(processingfee, 2) & "</td></tr>"
                End If
                My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[refno]", pnnumber), False)
                My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[cname]", .Rows(cnt)("cname").ToString), False)
                My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[address]", StrConv(.Rows(cnt)("address").ToString, vbProperCase)), False)
                My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[loanprod]", .Rows(cnt)("product").ToString), False)
                My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[numofinstallement]", .Rows(cnt)("numbinst").ToString), False)
                My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[installmentmode]", paymentmode), False)

                My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[loanamount]", FormatNumber(principalamount, 2)), False)
                My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[bankcharges]", "<table style='margin-left:50px; width: 500px'>" & bankcharges & "</table>"), False)
                My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[othercharges]", "<table style='margin-left:50px; width: 500px'>" & othercharges & "</table>"), False)

                My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[maturity]", If(paymentmode = "SINGLE", .Rows(cnt)("firstpmnt").ToString, "")), False)
                My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[cir]", FormatPercent(Val(Val(.Rows(cnt)("intrate").ToString) / 100) / 12)), False)
                My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[anir]", FormatPercent(Val(.Rows(cnt)("intrate").ToString) / 100)), False)
                My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[pastdueint]", FormatPercent((Val(.Rows(cnt)("intrate").ToString) / 100) + (10 / 100))), False)
                My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[penaltyint]", FormatNumber(qrysingledata("penaltyint", "penaltyint", "`action_query`.`tblloangraceperiod` where productid='" & .Rows(cnt)("loanprod").ToString & "'"), 2) + "%"), False)
                My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[manager]", qrysingledata("brhead", "ucase(branchhead) as brhead", "`master`.`branches` where branchcode='" & .Rows(cnt)("branchcode").ToString & "'")), False)
                My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[date]", CDate(.Rows(cnt)("loandate").ToString).ToString("MMMM dd, yyyy")), False)
                gracePeriod = qrysingledata("graceperiod", "graceperiod", "`action_query`.`tblloangraceperiod` where productid='" & .Rows(cnt)("loanprod").ToString & "'")
            End With
        Next

        Dim gracePeriodCount As Integer
        'Create services transaction
        Dim Amortbalance As Double = principalamount
        Dim netProceed As Double = 0
        Dim netProceedEir As Double = 0
        Dim totalAmortPayment As Double = 0
        Dim totalAmortEir As Double = 0
        Dim totalPrincipal As Double = 0 : Dim TotalInterest As Double = 0
        Dim ttlchg1 As Double = 0 : Dim ttlchg2 As Double = 0 : Dim ttlchg3 As Double = 0 : Dim ttlchg4 As Double = 0 : Dim ttlchg5 As Double = 0 : Dim ttlchg6 As Double = 0
        dst = New DataSet
        msda = New MySqlDataAdapter("select amortsched from master.lnamortsked where refno='" & pnnumber & "'", conn)
        msda.SelectCommand.CommandTimeout = 9000000
        msda.Fill(dst, 0)
        For cnt = 0 To dst.Tables(0).Rows.Count - 1
            With (dst.Tables(0))
                Dim getfirstline As String = ""

                Dim cnnw As Integer = 0
                For Each word In .Rows(cnt)("amortsched").ToString().Split(New Char() {"|"c})
                    If cnnw = 0 Then
                        getfirstline = word
                    End If
                    cnnw = cnnw + 1
                Next
                TableHead = "" : TableRow = "" : TableFooter = "" : Total = 0
                TableHead = createHeader(getfirstline) & Chr(13)

                Dim totalRow As Integer = 0
                For Each word In .Rows(cnt)("amortsched").ToString().Split(New Char() {"|"c})
                    totalRow = totalRow + 1
                Next
                gracePeriodCount = If(gracePeriod = 0, 0, gracePeriod / 30)
                Dim getAllAmortNumber(totalRow + 15) As Double

                netProceed = principalamount - TotalCharges
                netProceedEir = principalamount - EIRcharges

                getAllAmortNumber(0) = netProceedEir
                If gracePeriodCount > 0 Then
                    For i = 1 To gracePeriodCount + 1
                        getAllAmortNumber(i) = 0
                    Next
                End If
               
                Dim cnn As Integer = If(gracePeriodCount = 0, 1, gracePeriodCount)
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


                    totalPrincipal = totalPrincipal + principal
                    TotalInterest = TotalInterest + interest
                    ttlchg1 = ttlchg1 + chgamt1
                    ttlchg2 = ttlchg2 + chgamt2
                    ttlchg3 = ttlchg3 + chgamt3
                    ttlchg4 = ttlchg4 + chgamt4
                    ttlchg5 = ttlchg5 + chgamt5
                    ttlchg6 = ttlchg6 + chgamt6
                    totalAmortPayment = principal + interest + chgamt1 + chgamt2 + chgamt3 + chgamt4 + chgamt5 + chgamt6
                    totalAmortEir = principal + interest + GetServiceChargeEIR(chgcode1, chgamt1, chgcode2, chgamt2, chgcode3, chgamt3, chgcode4, chgamt4, chgcode5, chgamt5, chgcode6, chgamt6)
  
                    getAllAmortNumber(cnn) = -Math.Round(totalAmortEir, 2)
                    Amortbalance = Amortbalance - principal
                    cnn = cnn + 1
                Next
                Dim getEffectiveIntRate As Double = 0

                getEffectiveIntRate = (1 + IRR(getAllAmortNumber, 0.001)) ^ ((cnn - 1) / GetvalueAmortizationCode(paymentmode, cnn - 1)) - 1

                My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[totaldeduction]", FormatNumber(TotalCharges, 2)), False)
                My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[netproceed]", FormatNumber(netProceed, 2)), False)
                My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[eir]", FormatPercent(getEffectiveIntRate)), False)

                'My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[eir]", FormatNumber(getEffectiveIntRate, 2)), False)
            End With
        Next
        PrintLXReceipt(SaveLocation.Replace("\", "/"), form)
    End Function

    Public Function GetServiceChargeEIR(ByVal chg1 As String, ByVal chgamt1 As Double, ByVal chg2 As String, ByVal chgamt2 As Double, ByVal chg3 As String, ByVal chgamt3 As Double, ByVal chg4 As String, ByVal chgamt4 As Double, ByVal chg5 As String, ByVal chgamt5 As Double, ByVal chg6 As String, ByVal chgamt6 As Double) As Double
        GetServiceChargeEIR = 0
        If countqry("action_query.tbldisclosurecharges", "chargecode='" & chg1 & "' and servicecharge=1") > 0 Then
            GetServiceChargeEIR = chgamt1
        ElseIf countqry("action_query.tbldisclosurecharges", "chargecode='" & chg2 & "' and servicecharge=1") > 0 Then
            GetServiceChargeEIR = chgamt2
        ElseIf countqry("action_query.tbldisclosurecharges", "chargecode='" & chg3 & "' and servicecharge=1") > 0 Then
            GetServiceChargeEIR = chgamt3
        ElseIf countqry("action_query.tbldisclosurecharges", "chargecode='" & chg4 & "' and servicecharge=1") > 0 Then
            GetServiceChargeEIR = chgamt4
        ElseIf countqry("action_query.tbldisclosurecharges", "chargecode='" & chg5 & "' and servicecharge=1") > 0 Then
            GetServiceChargeEIR = chgamt5
        ElseIf countqry("action_query.tbldisclosurecharges", "chargecode='" & chg6 & "' and servicecharge=1") > 0 Then
            GetServiceChargeEIR = chgamt6
        End If
        Return GetServiceChargeEIR
    End Function
    Public Function createHeader(ByVal amortsked As String) As String
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
                           + " <tr> " _
                                + " <th>No. of Installment</th> " _
                                + " <th width='80'>Date</th> " _
                                + " <th width='80'>Principal</th> " _
                                + " <th width='80'>Interest</th> " _
                                + If(chgcode1 = "", If(checksavingsAccount(chgacct1) = True, getSavingsAccount(chgacct1), getPartyAccount(chgacct1)), getCharges(chgcode1)) _
                                + If(chgcode2 = "", If(checksavingsAccount(chgacct2) = True, getSavingsAccount(chgacct2), getPartyAccount(chgacct2)), getCharges(chgcode2)) _
                                + If(chgcode3 = "", If(checksavingsAccount(chgacct3) = True, getSavingsAccount(chgacct3), getPartyAccount(chgacct3)), getCharges(chgcode3)) _
                                + If(chgcode4 = "", If(checksavingsAccount(chgacct4) = True, getSavingsAccount(chgacct4), getPartyAccount(chgacct4)), getCharges(chgcode4)) _
                                + If(chgcode5 = "", If(checksavingsAccount(chgacct5) = True, getSavingsAccount(chgacct5), getPartyAccount(chgacct5)), getCharges(chgcode5)) _
                                + If(chgcode6 = "", If(checksavingsAccount(chgacct6) = True, getSavingsAccount(chgacct6), getPartyAccount(chgacct6)), getCharges(chgcode6)) _
                                + " <th>Total Amortization</th> " _
                                + " <th width='80'>Balance</th> " _
                            + " </tr> "
        Next
    End Function
    Public Function GetvalueAmortizationCode(ByVal amorthmode As String, ByVal numberofInstallment As Integer) As Double
        If amorthmode = "MONTHLY" Then
            GetvalueAmortizationCode = numberofInstallment / 1
        ElseIf amorthmode = "WEEKLY" Then
            GetvalueAmortizationCode = numberofInstallment / 4
        ElseIf amorthmode = "SNGLPMNT" Then
            GetvalueAmortizationCode = numberofInstallment / 1
        ElseIf amorthmode = "SEMIMOS" Then
            GetvalueAmortizationCode = numberofInstallment / 2
        ElseIf amorthmode = "WEEKLYDEM" Then
            GetvalueAmortizationCode = numberofInstallment / 4
        ElseIf amorthmode = "QUARTERLY" Then
            GetvalueAmortizationCode = numberofInstallment / 3
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
            getSavingsAccount = " <th>Personal Savings <br/>" & getSavingsAccount & "</th> "
        End If
        Return getSavingsAccount
    End Function

    Public Function getPartyAccount(ByVal acct As String) As String
        getPartyAccount = rchar(qrysingledata("entitysvaccount", "entitysvaccount", "master.3rdpartyaccount where entitycode='" & acct & "'"))
        If getPartyAccount <> "" Then
            getPartyAccount = " <th>Contractual Savings <br/>" & getPartyAccount & "</th> "
        End If
        Return getPartyAccount
    End Function

    Public Function getCharges(ByVal code As String) As String
        getCharges = rchar(qrysingledata("chgdesc", "chgdesc", "master.charges where chgcode='" & code & "'"))
        If getCharges <> "" Then
            getCharges = " <th>" & StrConv(getCharges.Replace("-", " "), vbProperCase) & "</th> "
        End If
        Return getCharges
    End Function
    Public Sub PrintLXReceipt(ByVal location As String, ByVal form As Windows.Forms.Form)
        Dim printProcess As New Diagnostics.ProcessStartInfo()
        printProcess.FileName = location
        Try
            Process.Start(printProcess)
            form.WindowState = FormWindowState.Minimized
        Catch ex As Exception
            MessageBox.Show("File not found!", _
                          "Error Reprint Transaction", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Module
