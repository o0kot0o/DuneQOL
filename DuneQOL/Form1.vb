Public Class Form1
    Dim var_SkipIntro As Boolean
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Check for x86 or x64 System and get the correct Steam Path
        Dim steamPath As String
        If System.Environment.Is64BitOperatingSystem = True Then
            steamPath = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Valve\Steam", "InstallPath", Nothing)
        Else
            steamPath = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam", "InstallPath", Nothing)
        End If
        If steamPath Is Nothing Then
            'MsgBox("Could not find Steam Path")
            'Close()
        End If

        'MsgBox("Steam Folder is " & steamPath)

        Dim gamePath As String
        gamePath = Nothing
    End Sub

    Private Sub BTN_Apply_Click(sender As Object, e As EventArgs) Handles BTN_Apply.Click
        If CB_SkipIntro.Checked Then
            ' Check if intro already skipped
            MsgBox("Applying Intro Skip")
        End If
    End Sub
End Class
