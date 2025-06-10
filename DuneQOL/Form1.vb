Imports System.IO

Public Class Form1
    Dim var_SkipIntro As Boolean
    Dim gamePath As String
    Dim moviePath As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Check for x86 or x64 System and get the correct Steam Path
        Dim steamPath As String
        If System.Environment.Is64BitOperatingSystem = True Then
            steamPath = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Valve\Steam", "InstallPath", Nothing)
        Else
            steamPath = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam", "InstallPath", Nothing)
        End If
        If steamPath Is Nothing Then
            MsgBox("Could not find Steam Path")
            'Close()
        End If

        'MsgBox("Steam Folder is " & steamPath)


        gamePath = steamPath + "\steamapps\common\DuneAwakening"
        moviePath = gamePath + "\DuneSandbox\Content\Movies"

        LIST_LOG.SendToBack()
    End Sub

    Private Sub BTN_Apply_Click(sender As Object, e As EventArgs) Handles BTN_Apply.Click
        If CB_SkipIntro.Checked Then
            LIST_LOG.Items.Add("Applying Intro Skip....")

            ' Check if intro already skipped
            If File.Exists(moviePath + "\IntroMovie\InitialIntro4k.bk2") Then
                LIST_LOG.Items.Add("Skipping InitialIntro4k.bk2")
                My.Computer.FileSystem.RenameFile(moviePath + "\IntroMovie\InitialIntro4k.bk2", "InitialIntro4k.bk2.SKIP")
            ElseIf File.Exists(moviePath + "\IntroMovie\InitialIntro4k.bk2.SKIP") Then
                LIST_LOG.Items.Add("InitialIntro4k.bk2 already skipped")
            End If

            LIST_LOG.TopIndex = LIST_LOG.Items.Count - 1

            If File.Exists(moviePath + "\Logo_4K_Funcom_2s.bk2") Then
                LIST_LOG.Items.Add("Skipping Logo_4K_Funcom_2s.bk2")
                My.Computer.FileSystem.RenameFile(moviePath + "\Logo_4K_Funcom_2s.bk2", "Logo_4K_Funcom_s2.bk2.SKIP")
            ElseIf File.Exists(moviePath + "\Logo_4K_Funcom_2s.bk2.SKIP") Then
                LIST_LOG.Items.Add("Logo_4K_Funcom_2s.bk2 already skipped")
            End If

            LIST_LOG.TopIndex = LIST_LOG.Items.Count - 1

            If File.Exists(moviePath + "\Logo_4K_Legendary_2s.bk2") Then
                LIST_LOG.Items.Add("Skipping Logo_4K_Legendary_2s.bk2")
            ElseIf File.Exists(moviePath + "\Logo_4K_Legendary_2s.bk2.SKIP") Then
                LIST_LOG.Items.Add("Logo_4K_Legendary_2s.bk2 already skipped")
            End If

            LIST_LOG.TopIndex = LIST_LOG.Items.Count - 1

            If File.Exists(moviePath + "\Logo_4K_LevelInfinite_2s.bk2") Then
                LIST_LOG.Items.Add("Skipping Logo_4K_LevelInfinite_2s.bk2")
            ElseIf File.Exists(moviePath + "\Logo_4K_LevelInfinite_2s.bk2.SKIP") Then
                LIST_LOG.Items.Add("Logo_4K_LevelInfinite_2s.bk2 already skipped")
            End If

            LIST_LOG.TopIndex = LIST_LOG.Items.Count - 1

            If File.Exists(moviePath + "\Logo_4K_Unreal_2s.bk2") Then
                LIST_LOG.Items.Add("Skipping Logo_4K_Unreal_2s.bk2")
            ElseIf File.Exists(moviePath + "\Logo_4K_Unreal_2s.bk2.SKIP") Then
                LIST_LOG.Items.Add("Logo_4K_Unreal_2s.bk2 already skipped")
            End If

            LIST_LOG.TopIndex = LIST_LOG.Items.Count - 1

        End If
    End Sub

    Private Sub LIST_LOG_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LIST_LOG.SelectedIndexChanged

    End Sub
End Class
