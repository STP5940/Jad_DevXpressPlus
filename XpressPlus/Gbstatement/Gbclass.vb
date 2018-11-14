Imports System.Data.SqlClient
Module Gbclass
    Public Gsusergroupid As String
    Public Gsuserid As String = "1001"
    Public Gsusername As String
    Public Gscomname As String 'Company
    Public Gscomid As String = "101"
    Public Pic() As Byte
    Public Gsreaau As Boolean
    Public Gswriau As Boolean
    Public Gscreau As Boolean
    Public Gsdelau As Boolean
    Public Gsseaau As Boolean
    Public Gspriau As Boolean
    Public Gsexpau As Boolean
    Public Computername As String
    Public Usrproname As String
    Public Sub Insertlog(Comid As String, Ugrpid As String, Usrid As String, Usrname As String, Modid As String, Docid As String, Updt As String, Updet As String, Updtime As String, Tcompname As String, Tusrprof As String)
        SQLCommand("INSERT INTO Tsyslogxp(Comid,Updgusrid,Updusrid,Updusrname,Updmodid,Docid,Udptype,
                    Upddetails,Updtime,Comname,Usrprof)
                    VALUES ('" & Comid & "','" & Ugrpid & "','" & Usrid & "','" & Usrname & "','" & Modid & "','" & Docid & "','" & Updt & "',
                    '" & Updet & "','" & Updtime & "','" & Tcompname & "','" & Tusrprof & "')")
    End Sub
    Public Function Confirmdelete() As Boolean
        Dim Yesmessage As String = ""
        Dim Confirm As Boolean = False
        Yesmessage = InputBox("ท่านต้องการลบข้อมูลรายการนี้? กรุณายืนยันด้วยการพิมพ์  DELETE ", "ยืนยันการลบข้อมูล", " ")
        If Yesmessage <> "DELETE" Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function Confirmcloseform(Frmname) As Boolean
        If MessageBox.Show("คุณต้องการปิดหน้าจอ " & Frmname & "?", "ยืนยันอีกครั้ง", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub Informmessage(Msg As String)
        MessageBox.Show(Msg, "ข้อความแจ้ง", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Public Function Confirmedit() As Boolean
        Dim Yesmessage As String = ""
        Dim Confirm As Boolean = False
        Yesmessage = InputBox("รายการนี้ได้ทำการรับสินค้าแล้ว ท่านต้องการแก้ไขรายการนี้? กรุณายืนยันด้วยการพิมพ์ CONFIRM ", "ยืนยันการแก้ไขข้อมูล", " ")
        If Yesmessage <> "CONFIRM" Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub Showdiaformcenter(Frm As Form, Frmm As Form)
        Frm.StartPosition = FormStartPosition.CenterParent
        Frm.ShowDialog()
    End Sub
    Public Function Formatdatesave(tmp As DateTime) As String
        Dim Rtimestamp, TmpYear, TmpMont, TmpDay, TmpHour, TmpMin, TmpSec As String
        If tmp.Year > 2500 Then
            TmpYear = (tmp.Year - 543).ToString
        Else
            TmpYear = tmp.Year.ToString
        End If
        If tmp.Month < 10 Then
            TmpMont = "0" & (tmp.Month).ToString
        Else
            TmpMont = tmp.Month.ToString
        End If
        If tmp.Day < 10 Then
            TmpDay = "0" & (tmp.Day).ToString
        Else
            TmpDay = (tmp.Day).ToString
        End If
        If tmp.Hour < 10 Then
            TmpHour = "0" & (tmp.Hour).ToString
        Else
            TmpHour = (tmp.Hour).ToString
        End If
        If tmp.Minute < 10 Then
            TmpMin = "0" & (tmp.Minute).ToString
        Else
            TmpMin = (tmp.Minute).ToString
        End If
        If tmp.Second < 10 Then
            TmpSec = "0" & (tmp.Second).ToString
        Else
            TmpSec = (tmp.Second).ToString
        End If
        Rtimestamp = TmpYear & "-" & TmpMont & "-" & TmpDay & " " & TmpHour & ":" & TmpMin & ":" & TmpSec
        Return Rtimestamp
    End Function
    Public Function Formatshortdatesave(tmp As DateTime) As String
        Dim Rtimestamp, TmpYear, TmpMont, TmpDay, TmpHour, TmpMin, TmpSec As String
        If tmp.Year > 2500 Then
            TmpYear = (tmp.Year - 543).ToString
        Else
            TmpYear = tmp.Year.ToString
        End If
        If tmp.Month < 10 Then
            TmpMont = "0" & (tmp.Month).ToString
        Else
            TmpMont = tmp.Month.ToString
        End If
        If tmp.Day < 10 Then
            TmpDay = "0" & (tmp.Day).ToString
        Else
            TmpDay = (tmp.Day).ToString
        End If
        If tmp.Hour < 10 Then
            TmpHour = "0" & (tmp.Hour).ToString
        Else
            TmpHour = (tmp.Hour).ToString
        End If
        If tmp.Minute < 10 Then
            TmpMin = "0" & (tmp.Minute).ToString
        Else
            TmpMin = (tmp.Minute).ToString
        End If
        If tmp.Second < 10 Then
            TmpSec = "0" & (tmp.Second).ToString
        Else
            TmpSec = (tmp.Second).ToString
        End If
        Rtimestamp = TmpYear & "-" & TmpMont & "-" & TmpDay
        Return Rtimestamp
    End Function
    Public Function SQLCommand(ByVal Sqltext As String) As DataTable
        Dim DTadapter As SqlDataAdapter
        Dim ObjConn As New SqlConnection
        Dim DT As New DataTable
        'ObjConn.ConnectionString = "Data Source = S-PC;Initial Catalog = EXPRESSPLUS;Persist Security Info=True;User ID = SA;Password = !password#"
        ObjConn.ConnectionString = "Data Source = ECSSERVER;Initial Catalog = EXPRESSPLUS;Persist Security Info=True;User ID = SA;Password = Ecs@1234"
        'ObjConn.ConnectionString = "Data Source = localhost;Initial Catalog = EXPRESSPLUS;Persist Security Info=True;User ID = SA;Password = 1234"
        ObjConn.Open()
        DTadapter = New SqlDataAdapter(Sqltext, ObjConn)
        DTadapter.Fill(DT)
        ObjConn.Close()
        ObjConn = Nothing
        Return DT
    End Function
End Module
