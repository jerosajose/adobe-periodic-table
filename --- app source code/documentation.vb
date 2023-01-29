Imports System.ComponentModel

Public Class Doc
    Dim Lct As Point

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.WindowState() = FormWindowState.Minimized
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Me.WindowState() = FormWindowState.Maximized Then
            Me.WindowState() = FormWindowState.Normal
        Else
            Me.WindowState() = FormWindowState.Maximized
        End If
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

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
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

    Private Sub ExitTheApplicationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitTheApplicationToolStripMenuItem.Click
        End
    End Sub

    Private Sub AboutPeriodicTable20221ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutPeriodicTable20221ToolStripMenuItem.Click
        About.Show()
    End Sub

    Private Sub Doc_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim IMGpath As String = IO.Path.Combine(Application.StartupPath, "table/pt.png")
        Try
            TableDisplay.BackgroundImage = System.Drawing.Image.FromFile(IMGpath)
        Catch ex As Exception
            MsgBox("The table couldn't be displayed. Check there's a folder named 'table' with an image in it. Please do not modify the app files.", vbCritical, "File not found")
            Me.Close()
        End Try
    End Sub

    Private Sub OpenSVG_Click(sender As Object, e As EventArgs) Handles OpenSVG.Click
        Dim SVGpath As String = IO.Path.Combine(Application.StartupPath, "table/svg/")
        System.Diagnostics.Process.Start(SVGpath)
    End Sub

    Private Sub OpenDis_Click(sender As Object, e As EventArgs) Handles OpenDis.Click
        Dim DISpath As String = IO.Path.Combine(Application.StartupPath, "table/disassembled/")
        System.Diagnostics.Process.Start(DISpath)
    End Sub

    Private Sub OpenPDF_Click(sender As Object, e As EventArgs) Handles OpenPDF.Click
        Dim PDFpath As String = IO.Path.Combine(Application.StartupPath, "docs/documentation.pdf")
        System.Diagnostics.Process.Start(PDFpath)
    End Sub

    Private Sub OpenWPhotos_Click(sender As Object, e As EventArgs) Handles OpenWPhotos.Click
        Dim PNGpath As String = IO.Path.Combine(Application.StartupPath, "table/pt.png")
        System.Diagnostics.Process.Start(PNGpath)
    End Sub
End Class