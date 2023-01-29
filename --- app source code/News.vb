Public Class News
    Dim Lct As Point

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub ShowOnTopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowOnTopToolStripMenuItem.Click
        If Me.TopMost = False Then
            ShowOnTopToolStripMenuItem.Text = "Stop showing on top"
            Me.TopMost = True
        Else
            ShowOnTopToolStripMenuItem.Text = "Show on top"
            Me.TopMost = False
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.WindowState() = FormWindowState.Minimized
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles MenuStrip1.MouseDown, Panel1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Lct = e.Location
        End If
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles MenuStrip1.MouseMove, Panel1.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Location += e.Location - Lct
        End If
    End Sub

    Private Sub AboutPeriodicTable20221ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutPeriodicTable20221ToolStripMenuItem.Click
        My.Forms.About.Show()
    End Sub

    Private Sub About_Click(sender As Object, e As EventArgs) Handles About.Click
        MsgBox("Website made by JerosGamer89 (the same person of this project)
It may look very crappy due to its being rendered using IE9 instead of a modern
Chrome/Chromium version, so you've always got the option to open it with your own
default browser if you want.", vbInformation, "About the website")
    End Sub

    Private Sub OpenBrowser_Click(sender As Object, e As EventArgs) Handles OpenBrowser.Click
        System.Diagnostics.Process.Start("https://ascript89.github.io/adobe/news.html")
    End Sub

End Class