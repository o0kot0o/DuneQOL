Imports System.IO

Public Class Form1
    Dim var_SkipIntro As Boolean
    Dim gamePath As String
    Dim moviePath As String
    Dim intro1 As String = "InitialIntro4k.bk2"
    Dim intro2 As String = "Logo_4K_Funcom_2s.bk2"
    Dim intro3 As String = "Logo_4K_Legendary_2s.bk2"
    Dim intro4 As String = "Logo_4K_LevelInfinite_2s.bk2"
    Dim intro5 As String = "Logo_4K_Unreal_2s.bk2"
    Dim intro6 As String = "StartupUE4.bk2"
    Dim intro7 As String = "EpilepsyInfo.bk2"

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
        End If

        gamePath = steamPath + "\steamapps\common\DuneAwakening"
        moviePath = gamePath + "\DuneSandbox\Content\Movies\"


        LIST_LOG.SendToBack()
    End Sub

    Private Sub BTN_Apply_Click(sender As Object, e As EventArgs) Handles BTN_Apply.Click
        If CB_SkipIntro.Checked Then
            StatusUpdate("Applying Intro Skip to movies")
            Check_Rename_File(intro1, "\IntroMovie\")
            Check_Rename_File(intro2)
            Check_Rename_File(intro3)
            Check_Rename_File(intro4)
            Check_Rename_File(intro5)
            Check_Rename_File(intro6)
            Check_Rename_File(intro7)
            StatusUpdate("Finished applying skip")
        ElseIf CB_UnSkipIntro.Checked Then
            StatusUpdate("Undoing intro movies to skip.")
            UndoSkip(intro1, "\IntroMovie\")
            UndoSkip(intro2)
            UndoSkip(intro3)
            UndoSkip(intro4)
            UndoSkip(intro5)
            UndoSkip(intro6)
            UndoSkip(intro7)
            StatusUpdate("Finished undoing skip")
        End If
    End Sub

    Private Sub StatusUpdate(ByVal update As String)
        LIST_LOG.Items.Add(update)
        LIST_LOG.TopIndex = LIST_LOG.Items.Count - 1
    End Sub

    Private Sub Check_Rename_File(ByVal intro As String, Optional ByVal path As String = "")
        If File.Exists(moviePath + path + intro) Then
            StatusUpdate("Marking " + intro + " as skipped")
            My.Computer.FileSystem.RenameFile(moviePath + path + intro, intro + ".SKIP")
        ElseIf File.Exists(moviePath + path + intro + ".SKIP") Then
            StatusUpdate(intro + " already set to skip")
        End If
    End Sub

    Private Sub UndoSkip(ByVal intro As String, Optional ByVal path As String = "")
        If File.Exists(moviePath + path + intro + ".SKIP") Then
            StatusUpdate("Resetting " + intro + " to play.")
            My.Computer.FileSystem.RenameFile(moviePath + path + intro + ".SKIP", intro)
        ElseIf File.Exists(moviePath + path + intro) Then
            StatusUpdate(intro + " already set to play")
        End If
    End Sub

    Private Sub CB_SkipIntro_CheckedChanged(sender As Object, e As EventArgs) Handles CB_SkipIntro.CheckedChanged
        If CB_SkipIntro.Checked Then
            CB_UnSkipIntro.Checked = False
        End If
    End Sub

    Private Sub CB_UnSkipIntro_CheckedChanged(sender As Object, e As EventArgs) Handles CB_UnSkipIntro.CheckedChanged
        If CB_UnSkipIntro.Checked Then
            CB_SkipIntro.Checked = False
        End If
    End Sub
End Class
