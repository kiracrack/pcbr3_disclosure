Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Security.Cryptography

Module Connection

    Public conn As New MySqlConnection 'for MySQLDatabase Connection
    Public msda As MySqlDataAdapter 'is use to update the dataset and datasource
    Public dst As New DataSet 'miniature of your table - cache table to client
    Public msda2 As MySqlDataAdapter 'is use to update the dataset and datasource
    Public dst2 As New DataSet 'miniature of your table - cache table to client
    Public com As New MySqlCommand
    Public rst As MySqlDataReader
    Public GlobalFullname As String
    Public GlobalApprover As Boolean
    Public GlobalApproverSequence As Integer
    Public GlobalReportViewOnly As Boolean
    Public GlobalLimited As Boolean

    Public sqlservername As String
    Public sqlipaddress As String
    Public sqlPort As String
    Public sqlusername As String
    Public sqlpassword As String
    Public sqlbranchcode As String

    Public file_conn As String = Application.StartupPath.ToString & "\" & My.Application.Info.AssemblyName & ".conn"
    Public single_conn As String = System.IO.Path.GetTempPath & "\" & My.Application.Info.AssemblyName & ".conn"
    Public file_conn_dir As String = Application.StartupPath.ToString & "\Connection"
    Public file_central_live As String = Application.StartupPath.ToString & "\Config\central_live.conn"
    Public file_central_backup As String = Application.StartupPath.ToString & "\Config\central_backup.conn"
    Public file_central_batchfile As String = Application.StartupPath.ToString & "\Config\centralreport.bat"

    Public connclient As New MySqlConnection 'for MySQLDatabase Connection
    Public msdaclient As MySqlDataAdapter 'is use to update the dataset and datasource
    Public dstclient As New DataSet 'miniature of your table - cache table to client
    Public comclient As New MySqlCommand
    Public rstclient As MySqlDataReader

    Public conngenapp As New MySqlConnection 'for MySQLDatabase Connection
    Public msdagenapp As MySqlDataAdapter 'is use to update the dataset and datasource
    Public dstgenapp As New DataSet 'miniature of your table - cache table to client
    Public comgenapp As New MySqlCommand
    Public rstgenapp As MySqlDataReader

    Public clientserver As String
    Public clientport As String
    Public clientuser As String
    Public clientpass As String

    Public genappserver As String
    Public genappport As String
    Public genappuser As String
    Public genapppass As String
    Public iticketdb As String
    Public systemaccess As String

    Public removechar As Char() = "\".ToCharArray()
    Public sb As New System.Text.StringBuilder
    Public imgBytes As Byte() = Nothing
    Public stream As MemoryStream = Nothing
    Public img As Image = Nothing
    Public sqlcmd As New MySqlCommand
    Public sql As String
    Public arrImage() As Byte = Nothing
    Public proFileImg As Boolean

    Public Sub ConnectVerify()
        Dim strSetup As String = ""
        Dim sr As StreamReader = File.OpenText(file_conn)
        Dim br As String = sr.ReadLine() : sr.Close()
        strSetup = DecryptTripleDES(br) : Dim cnt As Integer = 0
        For Each word In strSetup.Split(New Char() {","c})
            If cnt = 0 Then
                sqlipaddress = word
            ElseIf cnt = 1 Then
                sqlPort = word
            ElseIf cnt = 2 Then
                sqlusername = word
            ElseIf cnt = 3 Then
                sqlpassword = word
            End If
            cnt = cnt + 1
        Next

        conn = New MySql.Data.MySqlClient.MySqlConnection
        conn.ConnectionString = "server=" & sqlipaddress & "; Port=" & sqlPort & "; user id=" & sqlusername & "; password=" & sqlpassword & "; database=master; Connection Timeout=6000000"
        conn.Open()
        com.Connection = conn
        com.CommandTimeout = 6000000
    End Sub

    Public Function SingleConnectionVerify() As Boolean
        Dim strSetup As String = ""
        Try
            Dim sr As StreamReader = File.OpenText(file_conn)
            Dim br As String = sr.ReadLine() : sr.Close()
            strSetup = DecryptTripleDES(br) : Dim cnt As Integer = 0
            For Each word In strSetup.Split(New Char() {","c})
                 If cnt = 0 Then
                    sqlipaddress = word
                ElseIf cnt = 1 Then
                    sqlPort = word
                ElseIf cnt = 2 Then
                    sqlusername = word
                ElseIf cnt = 3 Then
                    sqlpassword = word
                End If
                cnt = cnt + 1
            Next

            conn = New MySql.Data.MySqlClient.MySqlConnection
            conn.ConnectionString = "server=" & sqlipaddress & "; Port=" & sqlPort & "; user id=" & sqlusername & "; password=" & sqlpassword & "; database=master; Connection Timeout=6000000"
            conn.Open()
            com.Connection = conn
            com.CommandTimeout = 6000000
            SingleConnectionVerify = True

        Catch errMYSQL As MySqlException
            MessageBox.Show("Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SingleConnectionVerify = False
            Return False
        Catch errMS As Exception
            MessageBox.Show("Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SingleConnectionVerify = False
            Return False
        End Try
      
    End Function

    Public Sub ChangeConnection(ByVal connection_file As String)
        Dim strSetup As String = ""
        Dim sr As StreamReader = File.OpenText(connection_file)
        Dim br As String = sr.ReadLine() : sr.Close()
        strSetup = DecryptTripleDES(br) : Dim cnt As Integer = 0
        For Each word In strSetup.Split(New Char() {","c})
            If cnt = 0 Then
                sqlservername = word
            ElseIf cnt = 1 Then
                sqlipaddress = word
            ElseIf cnt = 2 Then
                sqlPort = word
            ElseIf cnt = 3 Then
                sqlusername = word
            ElseIf cnt = 4 Then
                sqlpassword = word
            End If
            cnt = cnt + 1
        Next
        If conn.State = ConnectionState.Open Then
            conn.Close()
            com.Connection.Close()
        End If
        conn = New MySql.Data.MySqlClient.MySqlConnection
        conn.ConnectionString = "server=" & sqlipaddress & "; Port=" & sqlPort & "; user id=" & sqlusername & "; password=" & sqlpassword & "; database=master; Connection Timeout=6000000"
        conn.Open()
        com.Connection = conn
        com.CommandTimeout = 6000000
        CreateNotExistingTable()
    End Sub

    Public Function OpenClientServer() As Boolean
        Try
            If connclient.State = ConnectionState.Open Then
                connclient.Close()
                comclient.Connection.Close()
            End If
            connclient = New MySql.Data.MySqlClient.MySqlConnection
            connclient.ConnectionString = "server=" & clientserver & "; Port=" & clientport & "; user id=" & clientuser & "; password=" & clientpass & "; database=master"
            connclient.Open()
            comclient.Connection = connclient
            comclient.CommandTimeout = 0
            OpenClientServer = True

        Catch errMYSQL As MySqlException
            MessageBox.Show("Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            OpenClientServer = False
            Return False
        Catch errMS As Exception
            MessageBox.Show("Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            OpenClientServer = False
            Return False
        End Try
    End Function

    Public Function OpenCentralServer(ByVal connection_file As String) As Boolean
        Try
            Dim strSetup As String = ""
            Dim sr As StreamReader = File.OpenText(connection_file)
            Dim br As String = sr.ReadLine() : sr.Close()
            strSetup = DecryptTripleDES(br) : Dim cnt As Integer = 0
            For Each word In strSetup.Split(New Char() {","c})
                If cnt = 0 Then
                ElseIf cnt = 1 Then
                    clientserver = word
                ElseIf cnt = 2 Then
                    clientport = word
                ElseIf cnt = 3 Then
                    clientuser = word
                ElseIf cnt = 4 Then
                    clientpass = word
                End If
                cnt = cnt + 1
            Next
            If connclient.State = ConnectionState.Open Then
                connclient.Close()
                comclient.Connection.Close()
            End If
            connclient = New MySql.Data.MySqlClient.MySqlConnection
            connclient.ConnectionString = "server=" & clientserver & "; Port=" & clientport & "; user id=" & clientuser & "; password=" & clientpass & "; database=master"
            connclient.Open()
            comclient.Connection = connclient
            comclient.CommandTimeout = 0
            OpenCentralServer = True

        Catch errMYSQL As MySqlException
            'MessageBox.Show("Can't connect database host " & clientserver, _
            '                 "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            OpenCentralServer = False
        Catch errMS As Exception
            OpenCentralServer = False
        End Try
    End Function
    Public Function OpenGenAppServer() As Boolean
        Try
            conngenapp = New MySql.Data.MySqlClient.MySqlConnection
            conngenapp.ConnectionString = "server=" & genappserver & "; Port=" & genappport & "; user id=" & genappuser & "; password=" & genapppass & "; database=mysql"
            conngenapp.Open()
            comgenapp.Connection = conngenapp
            comgenapp.CommandTimeout = 0
            OpenGenAppServer = True

        Catch errMYSQL As MySqlException
            MessageBox.Show("Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            OpenGenAppServer = False
            Return False
        Catch errMS As Exception
            MessageBox.Show("Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            OpenGenAppServer = False
            Return False
        End Try
    End Function


    Public Sub Connection100()
        If conn.State = ConnectionState.Open Then
            conn.Close()
            com.Connection.Close()
        End If
        conn = New MySql.Data.MySqlClient.MySqlConnection
        conn.ConnectionString = "server=10.1.0.100; Port=3306; user id=100; password=1210010134; database=master; Connection Timeout=6000000"
        conn.Open()
        com.Connection = conn
        com.CommandTimeout = 6000000
        'CreateNotExistingTable()
    End Sub

    Public Sub Connection200()
        If conn.State = ConnectionState.Open Then
            conn.Close()
            com.Connection.Close()
        End If
        conn = New MySql.Data.MySqlClient.MySqlConnection
        conn.ConnectionString = "server=10.1.0.200; Port=3306; user id=100; password=1210010134; database=master; Connection Timeout=6000000"
        conn.Open()
        com.Connection = conn
        com.CommandTimeout = 6000000
        'CreateNotExistingTable()
    End Sub
    Public Function countqry(ByVal tbl As String, ByVal cond As String)
        Dim cnt As Integer = 0
        Try
            com.CommandText = "select count(*) as cnt from " & tbl & " where " & cond
            rst = com.ExecuteReader
            While rst.Read
                cnt = Val(rst("cnt").ToString)
            End While
            rst.Close()
        Catch errMYSQL As MySqlException
            MessageBox.Show("Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            MessageBox.Show("Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return cnt
    End Function
    Public Function countqryClient(ByVal tbl As String, ByVal cond As String)
        Dim cnt As Integer = 0
        Try
            comclient.CommandText = "select count(*) as cnt from " & tbl & " where " & cond
            rstclient = comclient.ExecuteReader
            While rstclient.Read
                cnt = Val(rstclient("cnt").ToString)
            End While
            rstclient.Close()
        Catch errMYSQL As MySqlException
            MessageBox.Show("Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            MessageBox.Show("Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return cnt
    End Function
    Public Function countRecord(ByVal tbl As String)
        Dim cnt As Integer = 0
        Try
            com.CommandText = "select count(*) as cnt from " & tbl
            rst = com.ExecuteReader
            While rst.Read
                cnt = Val(rst("cnt").ToString)
            End While
            rst.Close()
        Catch errMYSQL As MySqlException
            MessageBox.Show("Message:" & errMYSQL.Message & vbCrLf,
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            MessageBox.Show("Message:" & errMS.Message & vbCrLf,
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return cnt
    End Function

    Public Function ShowImage(ByVal fld As String, ByVal picbox As System.Windows.Forms.PictureBox)
        Try
            If rst(fld).ToString <> "" Then
                imgBytes = CType(rst(fld), Byte())
                stream = New MemoryStream(imgBytes, 0, imgBytes.Length)
                img = Image.FromStream(stream)
                picbox.Image = img
                proFileImg = True
            End If
        Catch errMYSQL As MySqlException
            MessageBox.Show("Message:" & errMYSQL.Message & vbCrLf,
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch errMS As Exception
            MessageBox.Show("Message:" & errMS.Message & vbCrLf,
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return 0
    End Function

    Public Function CC(ByVal m As String)
        Return Val(m.Replace(",", ""))
    End Function

    Public Function LoadToComboBox(ByVal query As String, ByVal fields As String, ByVal id As String, ByVal cb As Windows.Forms.ComboBox)
        cb.Items.Clear()
        com.CommandText = query : rst = com.ExecuteReader
        While rst.Read
            If rst(fields).ToString <> "" Then
                cb.Items.Add(New ComboBoxItem(StrConv(rst(fields).ToString.Replace("_", " "), vbProperCase), rst(id.ToString)))
            End If
        End While
        rst.Close()
        Return 0
    End Function
    Public Function LoadToComboBoxPre(ByVal query As String, ByVal fields As String, ByVal id As String, ByVal cb As Windows.Forms.ComboBox)
        cb.Items.Clear()
        com.CommandText = query : rst = com.ExecuteReader
        While rst.Read
            If rst(fields).ToString <> "" Then
                cb.Items.Add(New ComboBoxItem(rst(fields).ToString, rst(id.ToString)))
            End If
        End While
        rst.Close()
        Return 0
    End Function
    Public Class ComboBoxItem
        Private displayValue As String
        Private m_hiddenValue As String

        Public Sub New(ByVal d As String, ByVal h As String)
            displayValue = d
            m_hiddenValue = h
        End Sub

        Public ReadOnly Property HiddenValue() As String
            Get
                Return m_hiddenValue
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return displayValue
        End Function
    End Class

    Const sKey As String = "kira"

    Public Function EncryptTripleDES(ByVal sIn As String) As String
        Dim DES As New TripleDESCryptoServiceProvider()
        Dim hashMD5 As New MD5CryptoServiceProvider()

        ' Compute the MD5 hash.
        DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(sKey))
        ' Set the cipher mode.
        DES.Mode = CipherMode.ECB
        ' Create the encryptor.
        Dim DESEncrypt As ICryptoTransform = DES.CreateEncryptor()
        ' Get a byte array of the string.
        Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(sIn)
        ' Transform and return the string.
        Return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length))
    End Function

    Public Function DecryptTripleDES(ByVal sOut As String) As String
        Dim DES As New TripleDESCryptoServiceProvider()
        Dim hashMD5 As New MD5CryptoServiceProvider()

        ' Compute the MD5 hash.
        DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(sKey))
        ' Set the cipher mode.
        DES.Mode = CipherMode.ECB
        ' Create the decryptor.
        Dim DESDecrypt As ICryptoTransform = DES.CreateDecryptor()
        Dim Buffer As Byte() = Convert.FromBase64String(sOut)
        ' Transform and return the string.
        Return System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length))
    End Function
    Public Function rchar(ByVal str As String)
        str = str.Replace("'", "''")
        str = str.Replace("\", "\\")
        Return str
    End Function
    Public Function qrysingledata(ByVal field As String, ByVal fqry As String, ByVal tblandqry As String)
        Dim def As String = ""
        com.CommandText = "select " & fqry & " from " & tblandqry : rst = com.ExecuteReader
        While rst.Read
            def = rst(field).ToString
        End While
        rst.Close()
        Return def
    End Function
    Public Function qrysingledataClient(ByVal field As String, ByVal fqry As String, ByVal tblandqry As String)
        Dim def As String = ""
        comclient.CommandText = "select " & fqry & " from " & tblandqry : rstclient = comclient.ExecuteReader
        While rstclient.Read
            def = rstclient(field).ToString
        End While
        rstclient.Close()
        Return def
    End Function
    Public Function ConvertDate(ByVal d As Date)
        Return d.ToString("yyyy-MM-dd")
    End Function
    Public Function ConvertDateTime(ByVal d As Date)
        Return d.ToString("yyyy-MM-dd hh:mm:ss")
    End Function

    Public Function ConvertTime(ByVal d As DateTime)
        Return d.ToString("hh:mm:ss")
    End Function

    Public Function GridColumnAlignment(ByVal grdView As DataGridView, ByVal column As Array, ByVal alignment As DataGridViewContentAlignment) As DataGridView
        '   Dim array() As String = {a}
        For Each valueArr As String In column
            For i = 0 To grdView.ColumnCount - 1
                If valueArr = grdView.Columns(i).Name Then
                    grdView.Columns(i).DefaultCellStyle.Alignment = alignment
                    grdView.Columns(i).HeaderCell.Style.Alignment = alignment
                End If
            Next
        Next
        Return grdView
    End Function
    Public Function GridCurrencyColumn(ByVal grdView As DataGridView, ByVal column As Array) As DataGridView
        For Each valueArr As String In column
            For i = 0 To grdView.ColumnCount - 1
                If valueArr = grdView.Columns(i).Name Then
                    ' grdView.Columns(i).ValueType = System.Type.GetType("System.Decimal")
                    grdView.Columns(i).ValueType = GetType(Decimal)
                    grdView.Columns(i).DefaultCellStyle.Format = "n2"
                    grdView.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    grdView.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

                End If
            Next
        Next
        Return grdView
    End Function
    Public Sub RunCommandCom(command As String, permanent As Boolean, minimizewindow As Boolean)
        Dim p As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.Arguments = " " + If(permanent = True, "/K", "/C") + " " + command
        pi.FileName = "cmd.exe"
        If minimizewindow = True Then
            pi.WindowStyle = ProcessWindowStyle.Minimized
        End If
        p.StartInfo = pi
        p.Start()
    End Sub

    Public Function defaultCombobox(ByVal combo As System.Windows.Forms.ComboBox, ByVal form As System.Windows.Forms.Form, ByVal showcode As Boolean)
        Dim DefaultglItemLocation As String = "" : Dim defaultCode As String = "" : Dim defaultItem As String = "" : Dim Result As String = ""
        If System.IO.File.Exists(Application.StartupPath & "\Config\default_" & form.Name & "_" & combo.Name) = True Then
            DefaultglItemLocation = Application.StartupPath & "\Config\default_" & form.Name & "_" & combo.Name
            Dim sr As StreamReader = File.OpenText(DefaultglItemLocation)
            Try
                Dim str As String = sr.ReadLine() : Dim cnt As Integer = 0
                For Each strresult In DecryptTripleDES(str).Split(New Char() {","c})
                    If cnt = 0 Then
                        defaultItem = strresult
                    ElseIf cnt = 1 Then
                        defaultCode = strresult
                    End If
                    cnt = cnt + 1
                Next
                sr.Close()
            Catch errMS As Exception
                sr.Close()
            End Try
            If showcode = True Then
                Result = defaultCode
            Else
                Result = defaultItem
            End If
            Return Result
        End If
    End Function
    Public Function getReportTemplateID()
        Dim strng = ""
        Try
            If CInt(countRecord("pcbr3.tblreporttemplate")) = 0 Then
                strng = "RPT100001"
            Else
                com.CommandText = "select rptid from pcbr3.tblreporttemplate order by right(rptid,6) desc limit 1" : rst = com.ExecuteReader()
                Dim removechar As Char() = "ABCDEFGHIJKLMNOPQRSTUVWXYZ-".ToCharArray()
                Dim sb As New System.Text.StringBuilder
                While rst.Read
                    Dim str As String = rst("rptid").ToString
                    For Each ch As Char In str
                        If Array.IndexOf(removechar, ch) = -1 Then
                            sb.Append(ch)
                        End If
                    Next
                End While
                rst.Close()
                strng = "RPT" & Val(sb.ToString) + 1
            End If
        Catch errMYSQL As MySqlException
            MessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            MessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return strng.ToString
    End Function

    Public Function DeleteExistingFile(ByVal file As String)
        If System.IO.File.Exists(file) = True Then
            System.IO.File.Delete(file)
        End If
    End Function
    Public Sub CreateNotExistingTable()
        On Error Resume Next
        'PATCHING MASTER TABLE
        If countqry("information_schema.COLUMNS", "TABLE_SCHEMA='master' and TABLE_NAME = 'userinfo' AND COLUMN_NAME = 'defaultpassword'") = 0 Then
            com.CommandText = "ALTER TABLE `master`.`userinfo` ADD COLUMN `defaultpassword` TEXT AFTER `requesttime`;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.COLUMNS", "TABLE_SCHEMA='master' and TABLE_NAME = 'userinfo' AND COLUMN_NAME = 'datepasswordexpiry'") = 0 Then
            com.CommandText = "ALTER TABLE `master`.`userinfo` ADD COLUMN `datepasswordexpiry` TEXT AFTER `defaultpassword`;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.COLUMNS", "TABLE_SCHEMA='master' and TABLE_NAME = 'userinfo' AND COLUMN_NAME = 'maintainancemode'") = 0 Then
            com.CommandText = "ALTER TABLE `master`.`userinfo` ADD COLUMN `maintainancemode` BOOLEAN NOT NULL DEFAULT 0 AFTER `datepasswordexpiry`;" : com.ExecuteNonQuery()
        End If

      
        'ACTION QUERY
        com.CommandText = "create database if not exists action_query ;" : com.ExecuteNonQuery()
        If countqry("information_schema.tables", "table_schema = 'action_query' AND table_name = 'prodgltemplatefilter'") = 0 Then
            com.CommandText = "CREATE TABLE  `action_query`.`prodgltemplatefilter` (  `template_code` char(15) NOT NULL DEFAULT '',  `template_description` char(40) NOT NULL DEFAULT '',  `loanproducts` text NOT NULL,  `gl_items` text NOT NULL,  `cashtrntemplates` text NOT NULL,  `cashtransfertemplates` text NOT NULL) ENGINE=MyISAM DEFAULT CHARSET=utf8;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'action_query' AND table_name = 'depositaccounts'") = 0 Then
            com.CommandText = "CREATE TABLE  `action_query`.`depositaccounts` (  `acctnumber` char(9) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `psbknumber` char(10) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `dormant` tinyint(1) NOT NULL DEFAULT '0',  `statusdate` date NOT NULL DEFAULT '1900-01-01',  `branchcode` char(4) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `depcode` char(15) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `opendate` date NOT NULL DEFAULT '1900-01-01',  `renewaldate` date NOT NULL DEFAULT '1900-01-01',  `renewed` tinyint(1) NOT NULL DEFAULT '0',  `openamount` double(12,2) NOT NULL DEFAULT '0.00',  `intrate` double(6,2) NOT NULL DEFAULT '0.00',  `termindays` int(6) NOT NULL DEFAULT '0',  `maturity` date NOT NULL DEFAULT '1900-01-01',  `sourceacct` char(9) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `accountname` char(50) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `signatory1` char(5) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `signatory2` char(5) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `signatory3` char(5) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `signatory4` char(5) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `role1` tinyint(1) NOT NULL DEFAULT '0',  `role2` tinyint(1) NOT NULL DEFAULT '0',  `role3` tinyint(1) NOT NULL DEFAULT '0',  `role4` tinyint(1) NOT NULL DEFAULT '0',  `conn1` tinyint(1) NOT NULL DEFAULT '0',  `conn2` tinyint(1) NOT NULL DEFAULT '0',  `conn3` tinyint(1) NOT NULL DEFAULT '0',  `currbalance` double(12,2) NOT NULL DEFAULT '0.00',  `floatbal` double(12,2) NOT NULL DEFAULT '0.00',  `credittrnamount` double(12,2) NOT NULL DEFAULT '0.00',  `debittrnamount` double(12,2) NOT NULL DEFAULT '0.00',  `lasttransaction` date NOT NULL DEFAULT '1900-01-01',  `prevbalance` double(12,2) NOT NULL DEFAULT '0.00',  `eom_balance` double(12,2) NOT NULL DEFAULT '0.00',  `appliedbelowmindate` date NOT NULL DEFAULT '1900-01-01',  `appliedbelowmin` double(7,2) NOT NULL DEFAULT '0.00',  `applieddormdate` date NOT NULL DEFAULT '1900-01-01',  `applieddorm` double(7,2) NOT NULL DEFAULT '0.00',  `accruedint` double(12,2) NOT NULL DEFAULT '0.00',  `curraccruedint` double(12,2) NOT NULL DEFAULT '0.00',  `curraccruedintdate` date NOT NULL DEFAULT '1900-01-01',  `lastaccruedintdate` date NOT NULL DEFAULT '1900-01-01',  `appliedintdate` date NOT NULL DEFAULT '1900-01-01',  `appliedint` double(12,2) NOT NULL DEFAULT '0.00',  `withholdingtax` double(12,2) NOT NULL DEFAULT '0.00',  `recby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `recdate` date NOT NULL DEFAULT '1900-01-01',  `oldpcacctnumber` char(8) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `oldpcbalance` double(12,2) NOT NULL DEFAULT '0.00',  `oldpccaptdate` date NOT NULL DEFAULT '1900-01-01',  `trnlocked` tinyint(1) NOT NULL DEFAULT '0',  `trnlockedby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `trnlockdesc` char(250) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `trnlockedbranch` char(4) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `intrustfor` char(5) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `insurancebeneficiaries` char(120) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `withpairedsavingsaccount` tinyint(1) NOT NULL DEFAULT '0',  `depositaccountinterestrecipient` char(9) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `closeonage` tinyint(2) NOT NULL DEFAULT '0',  `monthdayfundtransfer` tinyint(2) NOT NULL DEFAULT '0',  `amountoffundtransfer` double(12,2) NOT NULL DEFAULT '0.00',  `lastfundtransfer` date NOT NULL DEFAULT '1900-01-01',  `numberoffailedfundtransfer` tinyint(1) NOT NULL DEFAULT '0',  `exemptfromwtax` tinyint(1) NOT NULL DEFAULT '0',  `exemptfromwtaxby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `exemptfromwtaxrecdate` date NOT NULL DEFAULT '1900-01-01',  `cumulativeinterestcredited` double(12,2) NOT NULL DEFAULT '0.00',  `cumulativewtaxdebited` double(12,2) NOT NULL DEFAULT '0.00',  `cumulativedailybalance` double(14,2) NOT NULL DEFAULT '0.00',  `adbcurrentmonth` double(12,2) NOT NULL DEFAULT '0.00',  `adbpreviousmonth` double(12,2) NOT NULL DEFAULT '0.00',  PRIMARY KEY (`acctnumber`),  KEY `depositaccounts_branchcode` (`branchcode`),  KEY `depositaccounts_dormant` (`dormant`),  KEY `depositaccounts_depcode` (`depcode`),  KEY `depositaccounts_signatory1` (`signatory1`),  KEY `depositaccounts_signatory2` (`signatory2`),  KEY `depositaccounts_signatory3` (`signatory3`),  KEY `depositaccounts_signatory4` (`signatory4`),  KEY `depositaccounts_oldpcacctnumber` (`oldpcacctnumber`),  KEY `depositaccounts_sourceacct` (`sourceacct`)) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'action_query' AND table_name = 'deposittransactions'") = 0 Then
            com.CommandText = "CREATE TABLE  `action_query`.`deposittransactions` (  `acctnumber` char(9) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `transactiondate` date NOT NULL DEFAULT '1900-01-01',  `maturitydate` date NOT NULL DEFAULT '1900-01-01',  `intrate` double(6,2) NOT NULL DEFAULT '0.00',  `trncode` char(15) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `transactionamount` double(12,2) NOT NULL DEFAULT '0.00',  `chequenumber` char(15) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `addthistobal` tinyint(1) NOT NULL DEFAULT '0',  `brcode` char(4) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `trnbrcode` char(4) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `reference` char(18) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `recby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `recdate` date NOT NULL DEFAULT '1900-01-01',  `rectime` char(8) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `clearmaxtrnamt` tinyint(1) NOT NULL DEFAULT '0',  `clearfloattrnamt` tinyint(1) NOT NULL DEFAULT '0',  `clearjnldrtrnamt` tinyint(1) NOT NULL DEFAULT '0',  `clearblockaccttrnamt` tinyint(1) NOT NULL DEFAULT '0',  `cleardormtrnamt` tinyint(1) NOT NULL DEFAULT '0',  `clearclosingtrnamt` tinyint(1) NOT NULL DEFAULT '0',  `foroverride` tinyint(1) NOT NULL DEFAULT '0',  `doneoverride` tinyint(1) NOT NULL DEFAULT '0',  `overrideby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `overridedate` date NOT NULL DEFAULT '1900-01-01',  `overridetime` char(8) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `validated` tinyint(1) NOT NULL DEFAULT '0',  `correctionentry` tinyint(1) NOT NULL DEFAULT '0',  `correctioncode` char(15) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  PRIMARY KEY (`reference`),  KEY `deposittransactions_acctnumber` (`acctnumber`)) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'action_query' AND table_name = 'disbmain'") = 0 Then
            com.CommandText = "CREATE TABLE  `action_query`.`disbmain` (  `disbrefno` char(7) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `disbtype` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `disbdate` date NOT NULL DEFAULT '1988-08-08',  `payee` char(45) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `refno` char(6) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `disbamt` double(12,2) NOT NULL DEFAULT '0.00',  `pmntcode` char(10) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `cashtrn` tinyint(1) NOT NULL DEFAULT '0',  `issuecheck` tinyint(1) NOT NULL DEFAULT '0',  `checknumb` char(20) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `recby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `cancelled` tinyint(1) NOT NULL DEFAULT '0',  `cancelledby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `branchcode` char(4) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `trnbranch` char(4) COLLATE utf8_unicode_ci NOT NULL DEFAULT '') ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'action_query' AND table_name = 'fullpmntwterm'") = 0 Then
            com.CommandText = "CREATE TABLE  `action_query`.`fullpmntwterm` (  `refno` char(10) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `trackingnumber` char(17) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `pmntdate` date NOT NULL DEFAULT '1988-08-08',  `lnrefno` char(6) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `branchcode` char(4) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `trnbranch` char(4) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `interbranch` tinyint(1) NOT NULL DEFAULT '0',  `amtpaid` double(12,2) NOT NULL DEFAULT '0.00',  `principal` double(12,2) NOT NULL DEFAULT '0.00',  `interest` double(12,2) NOT NULL DEFAULT '0.00',  `chgpmnt1` double(9,2) NOT NULL DEFAULT '0.00',  `chgpmnt2` double(9,2) NOT NULL DEFAULT '0.00',  `chgpmnt3` double(9,2) NOT NULL DEFAULT '0.00',  `chgpmnt4` double(9,2) NOT NULL DEFAULT '0.00',  `chgpmnt5` double(9,2) NOT NULL DEFAULT '0.00',  `chgpmnt6` double(9,2) NOT NULL DEFAULT '0.00',  `penalty` double(12,2) NOT NULL DEFAULT '0.00',  `recby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `timerec` char(8) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `intdisc` double(12,2) NOT NULL DEFAULT '0.00',  `pendisc` double(12,2) NOT NULL DEFAULT '0.00',  `chgdisc1` double(9,2) NOT NULL DEFAULT '0.00',  `chgdisc2` double(9,2) NOT NULL DEFAULT '0.00',  `chgdisc3` double(9,2) NOT NULL DEFAULT '0.00',  `chgdisc4` double(9,2) NOT NULL DEFAULT '0.00',  `chgdisc5` double(9,2) NOT NULL DEFAULT '0.00',  `chgdisc6` double(9,2) NOT NULL DEFAULT '0.00',  `approved` tinyint(1) NOT NULL DEFAULT '0',  `approvedby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `approvedtime` char(8) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `executionrefno` char(10) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `trnexecuted` tinyint(1) NOT NULL DEFAULT '0',  `trnexecutedby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `trnexecutedtime` char(8) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  KEY `lnwtermdet_refno` (`refno`),  KEY `lnwtermdet_lnrefno` (`lnrefno`),  KEY `lnwtermdet_branchcode` (`branchcode`)) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'action_query' AND table_name = 'g_chargesdeposits'") = 0 Then
            com.CommandText = "CREATE TABLE  `action_query`.`g_chargesdeposits` (  `refno` char(6) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `chgcateg1` tinyint(1) NOT NULL DEFAULT '0',  `amortchgcode1` char(2) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `svacct1` char(20) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `amortamt1` double(8,2) NOT NULL DEFAULT '0.00',  `amortstart1` int(3) NOT NULL DEFAULT '0',  `chgreg1` double(8,2) NOT NULL DEFAULT '0.00',  `chglast1` double(8,2) NOT NULL DEFAULT '0.00',  `amortbal1` double(8,2) NOT NULL DEFAULT '0.00',  `chgcateg2` tinyint(1) NOT NULL DEFAULT '0',  `amortchgcode2` char(2) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `svacct2` char(20) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `amortamt2` double(8,2) NOT NULL DEFAULT '0.00',  `amortstart2` int(3) NOT NULL DEFAULT '0',  `chgreg2` double(8,2) NOT NULL DEFAULT '0.00',  `chglast2` double(8,2) NOT NULL DEFAULT '0.00',  `amortbal2` double(8,2) NOT NULL DEFAULT '0.00',  `chgcateg3` tinyint(1) NOT NULL DEFAULT '0',  `amortchgcode3` char(2) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `svacct3` char(20) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `amortamt3` double(8,2) NOT NULL DEFAULT '0.00',  `amortstart3` int(3) NOT NULL DEFAULT '0',  `chgreg3` double(8,2) NOT NULL DEFAULT '0.00',  `chglast3` double(8,2) NOT NULL DEFAULT '0.00',  `amortbal3` double(8,2) NOT NULL DEFAULT '0.00',  `chgcateg4` tinyint(1) NOT NULL DEFAULT '0',  `amortchgcode4` char(2) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `svacct4` char(20) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `amortamt4` double(8,2) NOT NULL DEFAULT '0.00',  `amortstart4` int(3) NOT NULL DEFAULT '0',  `chgreg4` double(8,2) NOT NULL DEFAULT '0.00',  `chglast4` double(8,2) NOT NULL DEFAULT '0.00',  `amortbal4` double(8,2) NOT NULL DEFAULT '0.00',  `chgcateg5` tinyint(1) NOT NULL DEFAULT '0',  `amortchgcode5` char(2) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `svacct5` char(20) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `amortamt5` double(8,2) NOT NULL DEFAULT '0.00',  `amortstart5` int(3) NOT NULL DEFAULT '0',  `chgreg5` double(8,2) NOT NULL DEFAULT '0.00',  `chglast5` double(8,2) NOT NULL DEFAULT '0.00',  `amortbal5` double(8,2) NOT NULL DEFAULT '0.00',  `chgcateg6` tinyint(1) NOT NULL DEFAULT '0',  `amortchgcode6` char(2) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `svacct6` char(20) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `amortamt6` double(8,2) NOT NULL DEFAULT '0.00',  `amortstart6` int(3) NOT NULL DEFAULT '0',  `chgreg6` double(8,2) NOT NULL DEFAULT '0.00',  `chglast6` double(8,2) NOT NULL DEFAULT '0.00',  `amortbal6` double(8,2) NOT NULL DEFAULT '0.00',  `chgcurr1` double(8,2) NOT NULL DEFAULT '0.00',  `chgarr1` double(8,2) NOT NULL DEFAULT '0.00',  `chgcurr2` double(8,2) NOT NULL DEFAULT '0.00',  `chgarr2` double(8,2) NOT NULL DEFAULT '0.00',  `chgcurr3` double(8,2) NOT NULL DEFAULT '0.00',  `chgarr3` double(8,2) NOT NULL DEFAULT '0.00',  `chgcurr4` double(8,2) NOT NULL DEFAULT '0.00',  `chgarr4` double(8,2) NOT NULL DEFAULT '0.00',  `chgcurr5` double(8,2) NOT NULL DEFAULT '0.00',  `chgarr5` double(8,2) NOT NULL DEFAULT '0.00',  `chgcurr6` double(8,2) NOT NULL DEFAULT '0.00',  `chgarr6` double(8,2) NOT NULL DEFAULT '0.00',  `controlkey1` char(10) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `controlkey2` char(10) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `controlkey3` char(10) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `controlkey4` char(10) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `controlkey5` char(10) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `controlkey6` char(10) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  KEY `g_chargesdeposits_refno` (`refno`)) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'action_query' AND table_name = 'lnamortsked'") = 0 Then
            com.CommandText = "CREATE TABLE  `action_query`.`lnamortsked` (  `refno` char(6) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `amortsched` text COLLATE utf8_unicode_ci NOT NULL) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'action_query' AND table_name = 'lnwtermdet'") = 0 Then
            com.CommandText = "CREATE TABLE  `action_query`.`lnwtermdet` (  `refno` char(10) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `pmntdate` date NOT NULL DEFAULT '1988-08-08',  `lnrefno` char(6) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `branchcode` char(4) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `trnbranch` char(4) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `amtpaid` double(12,2) NOT NULL DEFAULT '0.00',  `principal` double(12,2) NOT NULL DEFAULT '0.00',  `interest` double(12,2) NOT NULL DEFAULT '0.00',  `chgpmnt1` double(9,2) NOT NULL DEFAULT '0.00',  `chgpmnt2` double(9,2) NOT NULL DEFAULT '0.00',  `chgpmnt3` double(9,2) NOT NULL DEFAULT '0.00',  `chgpmnt4` double(9,2) NOT NULL DEFAULT '0.00',  `chgpmnt5` double(9,2) NOT NULL DEFAULT '0.00',  `chgpmnt6` double(9,2) NOT NULL DEFAULT '0.00',  `penalty` double(12,2) NOT NULL DEFAULT '0.00',  `recby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `timerec` char(8) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `cancelled` tinyint(1) NOT NULL DEFAULT '0',  `cancelledby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `deductedfromloan` tinyint(1) NOT NULL DEFAULT '0',  PRIMARY KEY (`refno`)) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'action_query' AND table_name = 'lnwtermpay'") = 0 Then
            com.CommandText = "CREATE TABLE  `action_query`.`lnwtermpay` (  `refno` char(10) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `branchcode` char(4) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `trnbranch` char(4) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `custcode` char(5) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `pmntcode` char(10) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `gl_grpcode` char(4) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `gl_itemcode` char(10) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `cashtrn` tinyint(1) NOT NULL DEFAULT '0',  `pmntdate` date NOT NULL DEFAULT '1988-08-08',  `totalpmnt` double(12,2) NOT NULL DEFAULT '0.00',  `recby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `timerec` char(8) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `cancelled` tinyint(1) NOT NULL DEFAULT '0',  `cancelledby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  PRIMARY KEY (`refno`),  KEY `lnwtermpay_branchcode` (`branchcode`),  KEY `lnwtermpay_custcode` (`custcode`),  KEY `lnwtermpay_pmntcode` (`pmntcode`)) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'action_query' AND table_name = 'loanadj'") = 0 Then
            com.CommandText = "CREATE TABLE  `action_query`.`loanadj` (  `withterm` tinyint(1) NOT NULL DEFAULT '0',  `trnindex` char(1) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `custcode` char(5) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `adjdate` date NOT NULL DEFAULT '1998-08-08',  `refno` char(6) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `principal` double(10,2) NOT NULL DEFAULT '0.00',  `prin_add` tinyint(1) NOT NULL DEFAULT '1',  `interest` double(10,2) NOT NULL DEFAULT '0.00',  `int_add` tinyint(1) NOT NULL DEFAULT '1',  `penalty` double(10,2) NOT NULL DEFAULT '0.00',  `pen_add` tinyint(1) NOT NULL DEFAULT '1',  `chgadj1` double(9,2) NOT NULL DEFAULT '0.00',  `chg1_add` tinyint(1) NOT NULL DEFAULT '0',  `chgadj2` double(9,2) NOT NULL DEFAULT '0.00',  `chg2_add` tinyint(1) NOT NULL DEFAULT '0',  `chgadj3` double(9,2) NOT NULL DEFAULT '0.00',  `chg3_add` tinyint(1) NOT NULL DEFAULT '0',  `chgadj4` double(9,2) NOT NULL DEFAULT '0.00',  `chg4_add` tinyint(1) NOT NULL DEFAULT '0',  `chgadj5` double(9,2) NOT NULL DEFAULT '0.00',  `chg5_add` tinyint(1) NOT NULL DEFAULT '0',  `chgadj6` double(9,2) NOT NULL DEFAULT '0.00',  `chg6_add` tinyint(1) NOT NULL DEFAULT '0',  `recby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `timerec` char(8) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `brief` char(30) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `remark` char(250) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `trackingnumber` char(17) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `approvedby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `timeapproved` char(8) COLLATE utf8_unicode_ci NOT NULL DEFAULT '') ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'action_query' AND table_name = 'loanpaymentwithterm'") = 0 Then
            com.CommandText = "CREATE TABLE  `action_query`.`loanpaymentwithterm` (  `refno` char(10) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `trackingnumber` char(17) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `pmntdate` date NOT NULL DEFAULT '1988-08-08',  `lnrefno` char(6) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `branchcode` char(4) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `trnbranch` char(4) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `interbranch` tinyint(1) NOT NULL DEFAULT '0',  `amtpaid` double(12,2) NOT NULL DEFAULT '0.00',  `principal` double(12,2) NOT NULL DEFAULT '0.00',  `interest` double(12,2) NOT NULL DEFAULT '0.00',  `chgpmnt1` double(9,2) NOT NULL DEFAULT '0.00',  `chgpmnt2` double(9,2) NOT NULL DEFAULT '0.00',  `chgpmnt3` double(9,2) NOT NULL DEFAULT '0.00',  `chgpmnt4` double(9,2) NOT NULL DEFAULT '0.00',  `chgpmnt5` double(9,2) NOT NULL DEFAULT '0.00',  `chgpmnt6` double(9,2) NOT NULL DEFAULT '0.00',  `penalty` double(12,2) NOT NULL DEFAULT '0.00',  `recby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `timerec` char(8) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `intdisc` double(12,2) NOT NULL DEFAULT '0.00',  `pendisc` double(12,2) NOT NULL DEFAULT '0.00',  `chgdisc1` double(9,2) NOT NULL DEFAULT '0.00',  `chgdisc2` double(9,2) NOT NULL DEFAULT '0.00',  `chgdisc3` double(9,2) NOT NULL DEFAULT '0.00',  `chgdisc4` double(9,2) NOT NULL DEFAULT '0.00',  `chgdisc5` double(9,2) NOT NULL DEFAULT '0.00',  `chgdisc6` double(9,2) NOT NULL DEFAULT '0.00',  `approved` tinyint(1) NOT NULL DEFAULT '0',  `approvedby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `approvedtime` char(8) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `executionrefno` char(10) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `trnexecuted` tinyint(1) NOT NULL DEFAULT '0',  `trnexecutedby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `trnexecutedtime` char(8) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  KEY `lnwtermdet_refno` (`refno`),  KEY `lnwtermdet_lnrefno` (`lnrefno`),  KEY `lnwtermdet_branchcode` (`branchcode`)) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'action_query' AND table_name = 'loanwithterm'") = 0 Then
            com.CommandText = "CREATE TABLE  `action_query`.`loanwithterm` (  `refno` char(6) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `dosri` tinyint(1) NOT NULL DEFAULT '0',  `branchcode` char(4) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `newborrower` tinyint(1) NOT NULL DEFAULT '0',  `pastdue` tinyint(1) NOT NULL DEFAULT '0',  `pduedate` date NOT NULL DEFAULT '1988-08-08',  `nextpdueint` date NOT NULL DEFAULT '1900-01-01',  `lastpdueint` date NOT NULL DEFAULT '1900-01-01',  `inlitigation` tinyint(1) NOT NULL DEFAULT '0',  `lildate` date NOT NULL DEFAULT '1988-08-08',  `custcode` char(5) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `loanprod` char(10) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `intrate` double(6,2) NOT NULL DEFAULT '0.00',  `intmethod` tinyint(1) NOT NULL DEFAULT '0',  `amortcode` char(10) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `pmntfreq` int(4) NOT NULL DEFAULT '0',  `factor360` double(10,5) NOT NULL DEFAULT '0.00000',  `factor365` double(10,5) NOT NULL DEFAULT '0.00000',  `loandate` date NOT NULL DEFAULT '1988-08-08',  `firstpmnt` date NOT NULL DEFAULT '1988-08-08',  `lastpmnt` date NOT NULL DEFAULT '1988-08-08',  `maturity` date NOT NULL DEFAULT '1998-08-08',  `numbinst` int(7) NOT NULL DEFAULT '0',  `numbpaidinst` int(7) NOT NULL DEFAULT '0',  `termindays` int(7) NOT NULL DEFAULT '0',  `principal` double(12,2) NOT NULL DEFAULT '0.00',  `intterm` double(12,2) NOT NULL DEFAULT '0.00',  `pribal_bod` double(12,2) NOT NULL DEFAULT '0.00',  `pribal` double(12,2) NOT NULL DEFAULT '0.00',  `intbal` double(12,2) NOT NULL DEFAULT '0.00',  `amortpmnttodate` double(12,2) NOT NULL DEFAULT '0.00',  `lasttrn` date NOT NULL DEFAULT '1900-01-01',  `pnltypmnttodate` double(12,2) NOT NULL DEFAULT '0.00',  `intdue` double(12,2) NOT NULL DEFAULT '0.00',  `pendue` double(12,2) NOT NULL DEFAULT '0.00',  `fixamortmode` tinyint(1) NOT NULL DEFAULT '0',  `advintmode` tinyint(1) NOT NULL DEFAULT '0',  `advintdays` int(4) NOT NULL DEFAULT '0',  `advintcode` char(2) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `advintpmnt` double(10,2) NOT NULL DEFAULT '0.00',  `matpribal` double(12,2) NOT NULL DEFAULT '0.00',  `chgcode1` char(2) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `chgamt1` double(9,2) NOT NULL DEFAULT '0.00',  `chgcode2` char(2) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `chgamt2` double(9,2) NOT NULL DEFAULT '0.00',  `chgcode3` char(2) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `chgamt3` double(9,2) NOT NULL DEFAULT '0.00',  `chgcode4` char(2) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `chgamt4` double(9,2) NOT NULL DEFAULT '0.00',  `chgcode5` char(2) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `chgamt5` double(9,2) NOT NULL DEFAULT '0.00',  `chgcode6` char(2) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `chgamt6` double(9,2) NOT NULL DEFAULT '0.00',  `chgcode7` char(2) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `chgamt7` double(9,2) NOT NULL DEFAULT '0.00',  `forinsurance` tinyint(1) NOT NULL DEFAULT '0',  `categorycode` char(10) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `insurance` double(12,2) NOT NULL DEFAULT '0.00',  `reg_amortpri` double(12,2) NOT NULL DEFAULT '0.00',  `reg_amortint` double(12,2) NOT NULL DEFAULT '0.00',  `last_amortpri` double(12,2) NOT NULL DEFAULT '0.00',  `last_amortint` double(12,2) NOT NULL DEFAULT '0.00',  `dateinstdue` date NOT NULL DEFAULT '1988-08-08',  `cumprindue` double(12,2) NOT NULL DEFAULT '0.00',  `cumintdue` double(12,2) NOT NULL DEFAULT '0.00',  `nextprindue` double(12,2) NOT NULL DEFAULT '0.00',  `nextintdue` double(12,2) NOT NULL DEFAULT '0.00',  `numbinstdue` int(7) NOT NULL DEFAULT '0',  `amort_instdue` int(7) NOT NULL DEFAULT '0',  `daysdelayed` int(5) NOT NULL DEFAULT '0',  `currdue_prin` double(12,2) NOT NULL DEFAULT '0.00',  `currdue_int` double(12,2) NOT NULL DEFAULT '0.00',  `arrdue_prin` double(12,2) NOT NULL DEFAULT '0.00',  `arrdue_int` double(12,2) NOT NULL DEFAULT '0.00',  `recby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `daterec` date NOT NULL DEFAULT '1900-01-01',  `timerec` char(8) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `paid` tinyint(1) NOT NULL DEFAULT '0',  `paidby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `glpmntcode` char(21) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `templatecode` char(10) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `cancelled` tinyint(1) NOT NULL DEFAULT '0',  `cancelledby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `priorupdate` date NOT NULL DEFAULT '1988-08-08',  `lastupdate` date NOT NULL DEFAULT '1988-08-08',  `daysdelay` int(5) NOT NULL DEFAULT '0',  `loanpmnt` double(12,2) NOT NULL DEFAULT '0.00',  `comaker1` char(5) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `comaker2` char(5) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `tobecleared` tinyint(1) NOT NULL DEFAULT '0',  `cleared` tinyint(1) NOT NULL DEFAULT '0',  `clearedby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `clearinfo` char(19) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `crlimitexcess` double(12,2) NOT NULL DEFAULT '0.00',  `forclearingcrlimit` tinyint(1) NOT NULL DEFAULT '0',  `clearedcrlimit` tinyint(1) NOT NULL DEFAULT '0',  `clearedcrlimitby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `clearedcrlimitinfo` char(19) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `arrearsamount` double(12,2) NOT NULL DEFAULT '0.00',  `forclearingarrears` tinyint(1) NOT NULL DEFAULT '0',  `clearedarrears` tinyint(1) NOT NULL DEFAULT '0',  `clearedarrearsby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `clearedarrearsinfo` char(19) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `dayspastdue` int(5) NOT NULL DEFAULT '0',  `forclearingdayspastdue` tinyint(1) NOT NULL DEFAULT '0',  `clearedpastdue` tinyint(1) NOT NULL DEFAULT '0',  `clearedpastdueby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `clearedpastdueinfo` char(19) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `difftermindays` int(5) NOT NULL DEFAULT '0',  `forclearingterm` tinyint(1) NOT NULL DEFAULT '0',  `clearedterm` tinyint(1) NOT NULL DEFAULT '0',  `clearedtermby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `clearedterminfo` char(19) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `excessintpmntmode` tinyint(1) NOT NULL DEFAULT '0',  `intonexcessitem` char(2) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `allowableexcessindays` int(3) NOT NULL DEFAULT '0',  `intonexcessoverallowance` tinyint(1) NOT NULL DEFAULT '0',  `intontermexcess` double(9,2) NOT NULL DEFAULT '0.00',  `eyrate` double(13,9) NOT NULL DEFAULT '0.000000000',  `pnnumber` char(12) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `loantype` tinyint(4) NOT NULL DEFAULT '0',  `econactivity` tinyint(4) NOT NULL DEFAULT '0',  `collateral` tinyint(4) NOT NULL DEFAULT '5',  `presentvalue` double(12,2) NOT NULL DEFAULT '0.00',  `futurevalue` double(12,2) NOT NULL DEFAULT '0.00',  `ldbal_bod` double(12,2) NOT NULL DEFAULT '0.00',  `ldbal_eod` double(12,2) NOT NULL DEFAULT '0.00',  `ldxfer_amount` double(12,2) NOT NULL DEFAULT '0.00',  `ldxfer_priordate` date NOT NULL DEFAULT '1900-01-01',  `ldxfer_currdate` date NOT NULL DEFAULT '1900-01-01',  `effyieldrate` double(13,9) NOT NULL DEFAULT '0.000000000',  `dyieldrate` double(13,9) NOT NULL DEFAULT '0.000000000',  `trackingreference` char(15) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `centerkey` char(12) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `groupkey` char(16) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `pcbr2bal` double(12,2) NOT NULL DEFAULT '0.00',  `locked` tinyint(1) NOT NULL DEFAULT '0',  `lockedby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `trnlocked` tinyint(1) NOT NULL DEFAULT '0',  `trnlockedby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `trnlockremark` char(50) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `beneficiaries` char(120) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `annualeffectiveintrate` double(13,9) NOT NULL DEFAULT '0.000000000',  `withcoborrowers` tinyint(1) NOT NULL DEFAULT '0') ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'action_query' AND table_name = 'vouchers'") = 0 Then
            com.CommandText = "CREATE TABLE  `action_query`.`vouchers` (  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,  `trndate` date NOT NULL DEFAULT '1988-08-08',  `reference` char(10) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `forhoexpensedistribution` tinyint(1) NOT NULL DEFAULT '0',  `payee` char(80) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `purpose` char(200) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `amtdue` double(12,2) NOT NULL DEFAULT '0.00',  `recby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `paid` tinyint(1) NOT NULL DEFAULT '0',  `trnbranch` char(4) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `paidby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `cancelled` tinyint(1) NOT NULL DEFAULT '0',  `cancelledby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  PRIMARY KEY (`id`)) ENGINE=MyISAM AUTO_INCREMENT=49 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.COLUMNS", "TABLE_SCHEMA='action_query' and TABLE_NAME = 'tbltechnicalsupport' AND COLUMN_NAME = 'limited'") = 0 Then
            com.CommandText = "ALTER TABLE `action_query`.`tbltechnicalsupport` ADD COLUMN `limited` BOOLEAN NOT NULL DEFAULT 0 AFTER `reportviewing`;" : com.ExecuteNonQuery()
        End If

        'ADMIN TOOL TABLES
        If countqry("information_schema.tables", "table_schema = 'action_query' AND table_name = 'tbltechnicalsupport'") = 0 Then
            com.CommandText = "CREATE TABLE  `action_query`.`tbltechnicalsupport` (  `itname` varchar(200) NOT NULL,  `password` varchar(45) NOT NULL,  PRIMARY KEY (`itname`) USING BTREE) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;" : com.ExecuteNonQuery()
            com.CommandText = "INSERT INTO `action_query`.`tbltechnicalsupport` VALUES ('Alan Dumalay','iJAe5vkQKf0xTyTfYx6i8Q=='),('Don John Fernandez','N/seA/wr06OUogNN09MXO2jZS3L+7at3'),('Eulen Avancena','1234'),('Fred Tunguia','KwOp/PKhhluoif0xtaVH1O+JBTiULwj8'),('Ian sy','fRqfECe3VCTDyPSD6+PBIg=='),('Ifur Salimbagat','2LXuNrdjLdaTNW+w/VeiUQ=='),('Jan Paulo Canete','AHRThUICD9ahL3AJt4Uy3EHzsA1Pp8sx'),('Juvy Lito Martinez','UNfg2iw+dyy8zNAvie1LtghNQivD91C8'),('Mark Trilan Ochotorena','fuYDqRFYYTAkwl048fT3Juo9Wp4q5d7CQiKRMUO+ruw='),('Ryan Erasmo','RyUuM/fzOw3iYotmUnmDUA=='),('Winter Bugahod','jycaEKA4bOTrKxzqjQZ5H3EEElQdy+If');" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'action_query' AND table_name = 'tbltechnicalreport'") = 0 Then
            com.CommandText = "CREATE TABLE  `action_query`.`tbltechnicalreport` (  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,  `ticketno` varchar(45) DEFAULT NULL,  `branchname` varchar(200) DEFAULT NULL,  `requestorname` varchar(200) DEFAULT NULL,  `concern` text,  `actiontaken` text,  `severitylvl` varchar(45) NOT NULL DEFAULT 'Normal',  `performedby` varchar(200) NOT NULL,  `datetrn` datetime NOT NULL,  `ontechnical` tinyint(1) NOT NULL DEFAULT '0',  `pending` tinyint(1) NOT NULL DEFAULT '0',  `techsupport` varchar(200) DEFAULT NULL,  `timeframe` date DEFAULT NULL,  `dateclose` datetime DEFAULT NULL,  `remarks` text,  PRIMARY KEY (`id`)) ENGINE=InnoDB AUTO_INCREMENT=6868 DEFAULT CHARSET=latin1 ROW_FORMAT=FIXED;" : com.ExecuteNonQuery()
        End If

        If countqry("information_schema.tables", "table_schema = 'action_query' AND table_name = 'tblipinventory'") = 0 Then
            com.CommandText = "CREATE TABLE  `action_query`.`tblipinventory` (  `officeid` int(10) unsigned NOT NULL AUTO_INCREMENT,  `ipseries` varchar(505) NOT NULL,  `officename` varchar(45) NOT NULL,  `officetype` varchar(45) NOT NULL,  `ip1` varchar(3) NOT NULL,  `ip2` varchar(3) NOT NULL,  `ip3` varchar(3) NOT NULL,  `ip4` varchar(3) NOT NULL,  `ip5` varchar(2) NOT NULL,  PRIMARY KEY (`officeid`) USING BTREE) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'action_query' AND table_name = 'tblipnetworks'") = 0 Then
            com.CommandText = "CREATE TABLE  `action_query`.`tblipnetworks` (  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,  `officeid` varchar(4) NOT NULL,  `computername` varchar(500) NOT NULL,  `ipaddress` varchar(15) NOT NULL,  `remoteport` varchar(4) NOT NULL,  `username` varchar(50) NOT NULL,  `encryptpassword` tinyint(1) NOT NULL DEFAULT '0',  `password` varchar(200) NOT NULL,  PRIMARY KEY (`id`) USING BTREE) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'action_query' AND table_name = 'tblaccesstemplate'") = 0 Then
            com.CommandText = "CREATE TABLE  `action_query`.`tblaccesstemplate` (  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,  `templatename` varchar(500) NOT NULL,  `useraccess` varchar(500) NOT NULL,  `supervisoryloans` varchar(500) NOT NULL,  `productemplate` varchar(500) NOT NULL,  `depositoverride` varchar(500) NOT NULL,  PRIMARY KEY (`id`) USING BTREE) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;" : com.ExecuteNonQuery()
        End If

        '#UPDATES
        If countqry("information_schema.COLUMNS", "TABLE_SCHEMA='action_query' and TABLE_NAME = 'tbltechnicalsupport' AND COLUMN_NAME = 'approver'") = 0 Then
            com.CommandText = "ALTER TABLE `action_query`.`tbltechnicalsupport` ADD COLUMN `approver` BOOLEAN NOT NULL DEFAULT 0 AFTER `password`, ADD COLUMN `approving_sequence` INTEGER UNSIGNED NOT NULL DEFAULT 0 AFTER `approver`;" : com.ExecuteNonQuery()
        End If

        '#PLDT
        If countqry("information_schema.tables", "table_schema = 'action_query' AND table_name = 'tblpldtreport'") = 0 Then
            com.CommandText = "CREATE TABLE  `action_query`.`tblpldtoffice` (  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,  `officename` varchar(45) NOT NULL,  `officeaddress` text NOT NULL,  `telnumber` varchar(45) NOT NULL,  `contactperson` text NOT NULL,  `contactpersonnumber` varchar(45) NOT NULL,  `acctnumber` varchar(45) NOT NULL,  `plnumber` varchar(45) NOT NULL,  `accttype` varchar(45) NOT NULL,  PRIMARY KEY (`id`)) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'action_query' AND table_name = 'tblpldtreport'") = 0 Then
            com.CommandText = "CREATE TABLE  `action_query`.`tblpldtreport` (  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,  `officeid` int(10) unsigned NOT NULL,  `downdate` date NOT NULL,  `downtime` time NOT NULL,  `issue` text NOT NULL,  `incendentnumber` varchar(45) NOT NULL,  `closed` tinyint(1) NOT NULL DEFAULT 0,  `closeby` varchar(45) DEFAULT NULL,  `dateclosed` datetime DEFAULT NULL,  `reporteddate` datetime NOT NULL,  `reportby` varchar(105) NOT NULL,  PRIMARY KEY (`id`)) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;" : com.ExecuteNonQuery()
        End If

        If countqry("information_schema.COLUMNS", "TABLE_SCHEMA='action_query' and TABLE_NAME = 'tblpldtoffice' AND COLUMN_NAME = 'ipaddress'") = 0 Then
            com.CommandText = "ALTER TABLE `action_query`.`tblpldtoffice` ADD COLUMN `ipaddress` VARCHAR(105) NOT NULL AFTER `accttype`;" : com.ExecuteNonQuery()
        End If

        If countqry("information_schema.COLUMNS", "TABLE_SCHEMA='action_query' and TABLE_NAME = 'tblpldtreport' AND COLUMN_NAME = 'upconnection'") = 0 Then
            com.CommandText = "ALTER TABLE `action_query`.`tblpldtreport` ADD COLUMN `upconnection` BOOLEAN NOT NULL DEFAULT 0 AFTER `incendentnumber`,ADD COLUMN `upconnectiondate` DATETIME AFTER `upconnection` ;" : com.ExecuteNonQuery()
        End If

        If countqry("information_schema.tables", "table_schema = 'action_query' AND table_name = 'tbldormantsettings'") = 0 Then
            com.CommandText = "CREATE TABLE  `action_query`.`tbldormantsettings` (  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,  `depcode` varchar(500) NOT NULL,  `term` double NOT NULL DEFAULT '0',  PRIMARY KEY (`id`) USING BTREE) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;" : com.ExecuteNonQuery()
        End If

        If countqry("information_schema.tables", "table_schema = 'action_query' AND table_name = 'tblsupportappserver'") = 0 Then
            com.CommandText = "CREATE TABLE  `action_query`.`tblsupportappserver` (  `ipaddress` varchar(45) NOT NULL,  `username` varchar(505) NOT NULL,  `password` varchar(200) NOT NULL,  `port` varchar(45) NOT NULL,  `iticketdb` varchar(200) NOT NULL,  `systemaccessdb` varchar(200) NOT NULL,  PRIMARY KEY (`ipaddress`) USING BTREE) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;" : com.ExecuteNonQuery()
        End If

        If countqry("information_schema.tables", "table_schema = 'master' AND table_name = 'tblloanpaymentcharges'") = 0 Then
            com.CommandText = "CREATE TABLE  `master`.`tblloanpaymentcharges` (  `refno` varchar(20) NOT NULL,  `chgcode1` varchar(400) DEFAULT '',  `chgdesc1` varchar(400) DEFAULT '',  `chgcode2` varchar(400) DEFAULT '',  `chgdesc2` varchar(400) DEFAULT '',  `chgcode3` varchar(400) DEFAULT '',  `chgdesc3` varchar(400) DEFAULT '',  `chgcode4` varchar(400) DEFAULT '',  `chgdesc4` varchar(400) DEFAULT '',  `chgcode5` varchar(400) DEFAULT '',  `chgdesc5` varchar(400) DEFAULT '',  `chgcode6` varchar(400) DEFAULT '',  `chgdesc6` varchar(400) DEFAULT '',  PRIMARY KEY (`refno`) USING BTREE) ENGINE=MyISAM DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;" : com.ExecuteNonQuery()
        End If

        If countqry("information_schema.tables", "table_schema = 'action_query' AND table_name = 'tblsupportliveticketcount'") = 0 Then
            com.CommandText = "CREATE TABLE  `action_query`.`tblsupportliveticketcount` (  `pendingticket` int(11) NOT NULL DEFAULT '0',  PRIMARY KEY (`pendingticket`)) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;" : com.ExecuteNonQuery()
        End If

        If countqry("information_schema.COLUMNS", "TABLE_SCHEMA='action_query' and TABLE_NAME = 'tbltechnicalsupport' AND COLUMN_NAME = 'reportviewing'") = 0 Then
            com.CommandText = "ALTER TABLE `action_query`.`tbltechnicalsupport` ADD COLUMN `reportviewing` BOOLEAN NOT NULL DEFAULT 0 AFTER `approving_sequence`, ROW_FORMAT = FIXED;" : com.ExecuteNonQuery()
        End If

    End Sub
End Module
