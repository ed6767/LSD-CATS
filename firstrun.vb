Public Class firstrun
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            MsgBox("Warning: For advanced users only. If you aren't carefull, this will break the app.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Computer.FileSystem.WriteAllText(Form1.filloc & "firstrundone.dat", "YEEESSSSSS!!", False)
        Kill("CORE.dll")
        If CheckBox1.Checked = True Then
            Process.Start(Form1.filloc)
            MsgBox("Modify files now then press okay to save CORE.dll. To change icon, replace icon.ico with your icon and name it icon.ico.")
        End If
        IO.Compression.ZipFile.CreateFromDirectory(Form1.filloc, "CORE.dll")
        MsgBox("Core successfully re-built, now restarting. You can share this app without this screen showing again.", MsgBoxStyle.Information)
        Close()
    End Sub
End Class