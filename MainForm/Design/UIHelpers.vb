Imports System.Drawing
Imports System.Windows.Forms

Public Class UIHelpers
    Public Shared Sub ApplyFormStyles(form As Form)
        form.BackColor = Color.FromArgb(240, 240, 240)
        form.Font = New Font("Segoe UI", 9)
        form.FormBorderStyle = FormBorderStyle.FixedDialog
        form.MaximizeBox = False
        form.MinimizeBox = False
        form.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Public Shared Sub StyleButton(btn As Button, backColor As Color)
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.BackColor = backColor
        btn.ForeColor = Color.White
        btn.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        btn.Cursor = Cursors.Hand
        btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(
            Math.Min(backColor.R + 30, 255),
            Math.Min(backColor.G + 30, 255),
            Math.Min(backColor.B + 30, 255))
        btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(
            Math.Max(backColor.R - 30, 0),
            Math.Max(backColor.G - 30, 0),
            Math.Max(backColor.B - 30, 0))
    End Sub

    Public Shared Sub StyleTextBox(txt As TextBox)
        txt.BorderStyle = BorderStyle.FixedSingle
        txt.BackColor = Color.White
        txt.ForeColor = Color.FromArgb(64, 64, 64)
        AddHandler txt.Enter, Sub(sender, e) CType(sender, TextBox).BackColor = Color.FromArgb(240, 248, 255)
        AddHandler txt.Leave, Sub(sender, e) CType(sender, TextBox).BackColor = Color.White
    End Sub

    Public Shared Sub AddToolTip(control As Control, text As String)
        Dim toolTip As New ToolTip()
        toolTip.SetToolTip(control, text)
    End Sub
End Class