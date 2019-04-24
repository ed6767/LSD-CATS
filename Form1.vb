Imports System.IO.Compression
Imports System.Net

Public Class Form1
    Public Shared pathname As String = ""
    Public Shared filloc As String = ""
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        End
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IO.Directory.SetCurrentDirectory(My.Application.Info.DirectoryPath)
        Hide()

        Dim fileName As String = Application.ExecutablePath
        pathname = My.Application.Info.DirectoryPath
        Dim result As String

        result = IO.Path.GetFileNameWithoutExtension(fileName)
        Dim appfilename = result

        If IO.File.Exists("CORE.dll") = False Then
            MsgBox("Sorry but " & appfilename & " can't find CORE.dll. This is required to run. Please reinstall " & appfilename & " and check again.", MsgBoxStyle.Critical, appfilename & " had an error.")
            End
        End If
        filloc = My.Computer.FileSystem.SpecialDirectories.Temp & "\EDXSTEAPP" & Now.Ticks & "\"
        IO.Directory.CreateDirectory(filloc)
        Try
            Dim zipPath As String = "CORE.dll"
            Dim extractPath As String = filloc

            ZipFile.ExtractToDirectory(zipPath, extractPath)
            If Not IO.File.Exists(filloc & "firstrundone.dat") Then
                firstrun.ShowDialog()
                Application.Restart()
            End If
            Icon = New Icon(filloc & "icon.ico")
            Text = My.Computer.FileSystem.ReadAllText(filloc & "title.dat")
            Label2.Text = My.Computer.FileSystem.ReadAllText(filloc & "creator.dat")

            Label1.Text = Text
            My.Computer.FileSystem.ReadAllText(filloc & "nointernet.dat")
            If IO.File.Exists(filloc & "hideinfo.dat") Then
                Panel1.Hide()
            End If
            If My.Computer.FileSystem.ReadAllText(filloc & "pannel.dat") = "none" Then
                Panel1.Hide()
            ElseIf My.Computer.FileSystem.ReadAllText(filloc & "pannel.dat") = "invisible" Then

                FormBorderStyle = FormBorderStyle.None

                Me.TransparencyKey = Color.Magenta
                Me.WindowState = FormWindowState.Maximized
            End If

            WebBrowser1.Navigate(My.Computer.FileSystem.ReadAllText(filloc & "link.dat"))
        Catch ex As Exception
            MsgBox("Sorry, " & appfilename & " failed to start because CORE.dll is corrupted. Please reinstall and try again. " & ex.ToString, MsgBoxStyle.Critical, appfilename & " had an error.") 'the comma is there btw
            End
        End Try
        If CheckForInternetConnection() = False Then
            MsgBox(My.Computer.FileSystem.ReadAllText("nointernet.dat"), MsgBoxStyle.Critical, Text)
            End
        End If

    End Sub
    Public Shared Function CheckForInternetConnection() As Boolean
        Try
            If My.Computer.Network.Ping("www.scratch.mit.edu") Then
                Return True
            Else
                Return False
            End If
        Catch
            Return False
        End Try
    End Function

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        If WebBrowser1.Url.ToString.Contains("about:blank") Then
        Else
            Show()
        End If
    End Sub
End Class