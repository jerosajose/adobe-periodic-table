Public Class AppForm
    Dim Lct As Point
    Dim NewVer As Boolean

    Public Function UpdateCheck(NewVer As Boolean)
        Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://ascript89.github.io/adobe/ver.txt")
        Dim response As System.Net.HttpWebResponse = request.GetResponse
        Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream)
        Dim newestversion As String = sr.ReadToEnd
        Dim currentversion As String = Application.ProductVersion

        If newestversion.Contains(currentversion) Then
            NewVer = False
        Else
            NewVer = True
        End If
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.WindowState() = FormWindowState.Minimized
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) 
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

    Private Sub GoToGitHubToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GoToGitHubToolStripMenuItem.Click
        System.Diagnostics.Process.Start("https://ascript89.github.io/adobe")
    End Sub

    Private Sub OpenDocumentationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenDocumentationToolStripMenuItem.Click
        Dim PDFpath As String = IO.Path.Combine(Application.StartupPath, "docs/documentation.pdf")
        System.Diagnostics.Process.Start(PDFpath)
    End Sub

    Private Sub AppForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.FirstLaunch = True Then
            Label1.Text = "Welcome to"
            My.Settings.FirstLaunch = False
            My.Settings.Save()
        ElseIf My.Settings.FirstLaunch = False Then
            Label1.Text = "Welcome back"
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Doc.Show()
    End Sub

    Private Sub AboutPeriodicTable20221ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutPeriodicTable20221ToolStripMenuItem.Click
        About.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim PDFpath As String = IO.Path.Combine(Application.StartupPath, "docs/documentation.pdf")
        System.Diagnostics.Process.Start(PDFpath)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If NewVer = True Then
            MsgBox("A new update is available, continue to update the application.", vbExclamation, "Update available")
            UpdateForm.Show()
        Else
            MsgBox("The application is up to date!", vbInformation, "")
        End If
    End Sub

    Private Sub CheckForUpdatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckForUpdatesToolStripMenuItem.Click
        If NewVer = True Then
            MsgBox("A new update is available, continue to update the application.", vbExclamation, "Update available")
            UpdateForm.Show()
        Else
            MsgBox("The application is up to date!", vbInformation, "")
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        UpdateForm.Show()
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        News.Show()
    End Sub
End Class