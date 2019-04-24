Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active.
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private Sub MyApplication_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs) Handles Me.UnhandledException
            If e.ToString.ToLower.Contains("could not load file or assembly") Then
                MsgBox("Well, here's a big problem. You don't have the correct version of Microsoft .NET framework, because we couldn't load an assembly. Please make sure you have installed ALL windows updates and try again.")
            End If
            MsgBox("Please email ed@edxtech.uk immedietly with info of this error. " & e.Exception.ToString, MsgBoxStyle.Critical)
            End
        End Sub
    End Class
End Namespace