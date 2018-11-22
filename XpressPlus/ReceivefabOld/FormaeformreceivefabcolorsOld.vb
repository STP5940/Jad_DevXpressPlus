Public Class FormaeformreceivefabcolorsOld

    Private Sub Formaeformreceivefabcolors_Load(sender As Object, e As EventArgs) Handles Me.Load
        Tbclothid.Select()
    End Sub
    Private Sub Tbfabno_KeyDown(sender As Object, e As KeyEventArgs) Handles Tbclothid.KeyDown
        If e.KeyCode = Keys.Enter Then
            Tbkongno.Focus()
        End If
    End Sub
    Private Sub Tbkongno_KeyDown(sender As Object, e As KeyEventArgs) Handles Tbkongno.KeyDown
        If e.KeyCode = Keys.Enter Then
            Tbroll.Focus()
        End If
    End Sub
    Private Sub Tbroll_KeyDown(sender As Object, e As KeyEventArgs) Handles Tbroll.KeyDown
        If e.KeyCode = Keys.Enter Then
            Tbkg.Focus()
        End If
    End Sub
    Private Sub Tbkg_KeyDown(sender As Object, e As KeyEventArgs) Handles Tbkg.KeyDown
        If e.KeyCode = Keys.Enter Then
            Btok.Focus()
        End If
    End Sub
    Private Sub Btok_Click(sender As Object, e As EventArgs) Handles Btok.Click
        If Validinput() = False Then
            Informmessage("กรุณาตรวจสอบข้อมูลให้ถูกต้อง ครบถ้วน")
            Exit Sub
        End If
        If Validnumber() = False Then
            Informmessage("กรุณาตรวจจำนวนให้ถูกต้อง ครบถ้วน")
            Exit Sub
        End If
        Me.Close()
    End Sub
    Private Sub Btcancel_Click(sender As Object, e As EventArgs) Handles Btcancel.Click
        Tbcancel.Text = "C"
        Me.Close()
    End Sub
    Private Function Validinput() As Boolean
        Dim Valid As Boolean = False
        If Tbclothid.Text <> "" And Tbkongno.Text <> "" And Tbroll.Text <> "" And Tbkg.Text <> "" Then
            Valid = True
        End If
        Return Valid
    End Function
    Private Function Validnumber() As Boolean
        Dim Valid As Boolean = False
        If CLng(Tbroll.Text) > 0 And CDbl(Tbkg.Text) > 0 Then
            Valid = True
        End If
        Return Valid
    End Function

    Private Sub Btfindshade_Click(sender As Object, e As EventArgs) Handles Btfindshade.Click
        Dim Frm As New FormdyeddetlistOld
        Frm.Tbknitbill.Text = Trim(Tbknittbill.Text)
        Showdiaformcenter(Frm, Me)
    End Sub
End Class