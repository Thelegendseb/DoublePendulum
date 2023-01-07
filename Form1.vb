Public Class Form1
    Private Program_ As Program
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.Program_ = New Program(Me)
    End Sub
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Program_.Run()
    End Sub
    Private Sub Form1_Closing(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        Me.Program_.Halt()
    End Sub
End Class