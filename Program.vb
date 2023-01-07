Imports XApps

Public Class Program
    Inherits XApp

    Sub New(FormIn As Form)

        MyBase.New(FormIn)

        FormIn.Text = "Double Pendulum"

        ' // Main line
        Me.Session.AddObj(New Demo(Me.Session.Window.Width,Me.Session.Window.Height))

        Me.Session.QueueRelease()

    End Sub

End Class