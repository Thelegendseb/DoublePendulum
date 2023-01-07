Imports XApps
Public Class Demo

    Inherits XBase

    Private r1 As Decimal = 200
    Private r2 As Decimal = 200
    Private m1 As Decimal = 10
    Private m2 As Decimal = 10
    Private a1 As Decimal = 0
    Private a2 As Decimal = 0
    Private a1_v As Decimal = 0
    Private a2_v As Decimal = 0
    Private g As Decimal = 1

    Private px2 As Decimal = -1
    Private py2 As Decimal = -1

    Private a1_a As Decimal = 0
    Private a2_a As Decimal = 0

    Private first As Boolean = False

    Private bp As Bitmap

    Sub New(width As Integer, height As Integer)

        Me.SetDrawStatus(True)
        Me.SetUpdateStatus(True)

        a1 = Math.PI / 2
        a2 = Math.PI / 2

        Me.bp = New Bitmap(width, height)

    End Sub

    Public Overrides Sub Update(Session As XSession)

        a1_a = 0
        a2_a = 0

        Dim num1 As Decimal = -g * (2 * m1 + m2) * Math.Sin(a1)
        Dim num2 As Decimal = -m2 * g * Math.Sin(a1 - 2 * a2)
        Dim num3 As Decimal = -2 * Math.Sin(a1 - a2) * m2
        Dim num4 As Decimal = a2_v * a2_v * r2 + a1_v * a1_v * r1 * Math.Cos(a1 - a2)
        Dim den As Decimal = r1 * (2 * m1 + m2 - m2 * Math.Cos(2 * a1 - 2 * a2))

        a1_a = (num1 + num2 + num3 * num4) / den

        num1 = 2 * Math.Sin(a1 - a2)
        num2 = (a1_v * a1_v * r1 * (m1 + m2))
        num3 = g * (m1 + m2) * Math.Cos(a1)
        num4 = a2_v * a2_v * r2 * m2 * Math.Cos(a1 - a2)
        den = r2 * (2 * m1 + m2 - m2 * Math.Cos(2 * a1 - 2 * a2))
        a2_a = (num1 * (num2 + num3 + num4)) / den

    End Sub

    Public Overrides Sub Draw(ByRef g As Graphics)

        Dim x1 As Decimal = r1 * Math.Sin(a1)
        Dim y1 As Decimal = r1 * Math.Cos(a1)

        Dim x2 As Decimal = x1 + r2 * Math.Sin(a2)
        Dim y2 As Decimal = y1 + r2 * Math.Cos(a2)

        Dim cx As Integer = g.VisibleClipBounds.Width / 2
        Dim cy As Integer = g.VisibleClipBounds.Height / 3

        If Not first Then
            first = True
        Else

            Using gg As Graphics = Graphics.FromImage(bp)

                gg.DrawLine(Pens.Red, cx + px2, cy + py2, cx + x2, cy + y2)

            End Using

        End If

        px2 = x2
        py2 = y2

        g.DrawImage(bp, 0, 0)

        g.DrawLine(Pens.Black, cx, cy, cx + x1, cy + y1)

        g.FillEllipse(Brushes.Black, cx + x1 - 10, cy + y1 - 10, 20, 20)

        g.DrawLine(Pens.Black, cx + x1, cy + y1, cx + x2, cy + y2)

        g.FillEllipse(Brushes.Black, cx + x2 - 10, cy + y2 - 10, 20, 20)

        a1_v += a1_a
        a2_v += a2_a
        a1 += a1_v
        a2 += a2_v

        a1_v *= 0.999
        a2_v *= 0.999

    End Sub
End Class
