Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Check for x86 or x64 System and get the correct Steam Path
        Dim steamPath As String
        If System.Environment.Is64BitOperatingSystem = True Then
            steamPath = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Valve\Steam", "InstallPath", Nothing)
        Else
            steamPath = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam", "InstallPath", Nothing)
        End If
        'MsgBox("Steam Folder is " & steamPath)
        Button1.Location = New Point((ClientSize.Width - Button1.Width) \ 2, (ClientSize.Height - Button1.Height) \ 2)
    End Sub
End Class
