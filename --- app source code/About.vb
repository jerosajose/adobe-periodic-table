Public Class About
    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label5.Text = My.Application.Info.Version.ToString

        Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://ascript89.github.io/adobe/ver.txt")
        Dim response As System.Net.HttpWebResponse = request.GetResponse
        Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream)
        Dim newestversion As String = sr.ReadToEnd
        Dim currentversion As String = Application.ProductVersion

        If newestversion.Contains(currentversion) Then

        Else
            MsgBox("A new update is available, click below to update the application.", vbOKOnly, "Update available")
            Button2.Visible = True
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        UpdateForm.Show()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("https://creativecommons.org/")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        System.Diagnostics.Process.Start("https://is-overrated.no-beta-lol.com")
    End Sub
End Class