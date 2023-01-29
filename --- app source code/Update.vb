Imports System.ComponentModel
Imports System.IO

Public Class UpdateForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        AppForm.WindowState = FormWindowState.Minimized
        PB.Visible = True
        Button1.Visible = False

        Dim MissingPNG As Boolean = False
        Dim MissingSVG As Boolean = False
        Dim MissingPDF As Boolean = False

        Dim PNG As String = IO.Path.Combine(Application.StartupPath, "table/pt.png")
        Dim SVG As String = IO.Path.Combine(Application.StartupPath, "table/pt.svg")
        Dim PDF As String = IO.Path.Combine(Application.StartupPath, "docs/documentation.pdf")

        My.Computer.FileSystem.CreateDirectory(IO.Path.Combine(Application.StartupPath, "$old/"))
        Try
            File.Move(PNG, IO.Path.Combine(Application.StartupPath, "$old/pt.png"))
            File.Move(SVG, IO.Path.Combine(Application.StartupPath, "$old/pt.svg"))
            File.Move(PDF, IO.Path.Combine(Application.StartupPath, "$old/documentation.pdf"))
        Catch ex As Exception
            MsgBox("Please close the documentation, the SVG file if opened and the Table Display.

In order to let the updater change all the old files with the new ones, these can not be in use. App needs to be restarted.", vbCritical, "Files are being used")

            File.Move(IO.Path.Combine(Application.StartupPath, "$old/pt.png"), PNG)
            File.Move(IO.Path.Combine(Application.StartupPath, "$old/pt.svg"), SVG)
            File.Move(IO.Path.Combine(Application.StartupPath, "$old/documentation.pdf"), PDF)
            My.Computer.FileSystem.DeleteDirectory(IO.Path.Combine(Application.StartupPath, "$old/"), FileIO.DeleteDirectoryOption.ThrowIfDirectoryNonEmpty)
            End
        End Try


        Try
            My.Computer.Network.DownloadFile("https://ascript89.github.io/adobe/download/pt.png", PNG, "", "", False, 10000, True)
        Catch ex As Exception
            MsgBox("The PNG file for the table couldn't be downloaded. Head up to the website and download it manually.", vbCritical, "Missing file in the download")
        Finally
            PB.Value = 33
        End Try

        Try
            My.Computer.Network.DownloadFile("https://ascript89.github.io/adobe/download/pt.svg", SVG, "", "", False, 10000, True)
        Catch ex As Exception
            MsgBox("The SVG file for the table couldn't be downloaded. Head up to the website and download it manually.", vbCritical, "Missing file in the download")
        Finally
            PB.Value = 66
        End Try

        Try
            My.Computer.Network.DownloadFile("https://ascript89.github.io/adobe/download/documentation.pdf", PDF, "", "", False, 10000, True)
        Catch ex As Exception
            MsgBox("The new documentation couldn't be downloaded. Head up to the website and download it manually.", vbCritical, "Missing file in the download")
        Finally
            PB.Value = 90
        End Try



        If My.Computer.FileSystem.FileExists(PNG) Then
            PB.Value = 93
        Else
            PB.Value = 93
            MissingPNG = True
        End If

        If My.Computer.FileSystem.FileExists(SVG) Then
            PB.Value = 96
        Else
            PB.Value = 96
            MissingSVG = True
        End If

        If My.Computer.FileSystem.FileExists(PDF) Then
            PB.Value = 100
        Else
            PB.Value = 100
            MissingPDF = True
        End If


        PB.Visible = False
        ErrorLabel.Visible = True
        MissingLabel.Visible = True


        If MissingPNG = True Then
            ErrorLabel.Text += "PNG  "
            File.Move(IO.Path.Combine(Application.StartupPath, "$old/pt.png"), PNG)
        End If

        If MissingSVG = True Then
            ErrorLabel.Text += "SVG  "
            File.Move(IO.Path.Combine(Application.StartupPath, "$old/pt.svg"), SVG)
        End If

        If MissingPDF = True Then
            ErrorLabel.Text += "PDF"
            File.Move(IO.Path.Combine(Application.StartupPath, "$old/documentation.pdf"), PDF)
        End If

        My.Computer.FileSystem.DeleteDirectory(IO.Path.Combine(Application.StartupPath, "$old/"), FileIO.DeleteDirectoryOption.DeleteAllContents)

        If MissingPNG AndAlso MissingSVG AndAlso MissingPDF = False Then
            MissingLabel.Text = "The update has finished.
There's no need to restart the application, the changes
have already been applied. You can now close this window."
        End If
    End Sub

    Private Sub UpdateForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        AppForm.WindowState = FormWindowState.Normal
    End Sub
End Class