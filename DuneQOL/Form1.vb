Imports System.IO
Imports System.Security.Cryptography.X509Certificates

Public Class Form1
    Dim var_SkipIntro As Boolean
    Dim Seperator As String = "-------------------------------------------------------------------------------------------------"
    Dim gamePath As String
    Dim moviePath As String
    Dim intro1 As String = "InitialIntro4k.bk2"
    Dim intro2 As String = "Logo_4K_Funcom_2s.bk2"
    Dim intro3 As String = "Logo_4K_Legendary_2s.bk2"
    Dim intro4 As String = "Logo_4K_LevelInfinite_2s.bk2"
    Dim intro5 As String = "Logo_4K_Unreal_2s.bk2"
    Dim intro6 As String = "StartupUE4.bk2"
    Dim intro7 As String = "EpilepsyInfo.bk2"

    Private Sub GetGamePath()
        'Check for x86 or x64 System and get the correct Steam Path
        Dim steamPath As String
        StatusUpdate(Seperator)
        StatusUpdate("Looking for Steam")
        StatusUpdate(Seperator)
        If System.Environment.Is64BitOperatingSystem = True Then
            steamPath = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Valve\Steam", "InstallPath", Nothing)
        Else
            steamPath = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam", "InstallPath", Nothing)
        End If
        If steamPath Is Nothing Then
            StatusUpdate("Could Not find Steam")
            StatusUpdate(Seperator)
            BTN_Apply.Enabled = False
            CB_SkipIntro.Enabled = False
            CB_UnSkipIntro.Enabled = False
        Else
            StatusUpdate("Steam found at " & steamPath)
            gamePath = steamPath + "\steamapps\common\DuneAwakening"
            moviePath = gamePath + "\DuneSandbox\Content\Movies\"
            StatusUpdate("Found Dune at " & gamePath)
            StatusUpdate(Seperator)
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGamePath()
    End Sub

    Private Sub BTN_Apply_Click(sender As Object, e As EventArgs) Handles BTN_Apply.Click
        LIST_LOG.Items.Clear()
        StatusUpdate(Seperator)
        If CB_SkipIntro.Checked Then
            StatusUpdate("Applying Intro Skip to movies")
            StatusUpdate(Seperator)
            Check_Rename_File(intro1, "\IntroMovie\")
            Check_Rename_File(intro2)
            Check_Rename_File(intro3)
            Check_Rename_File(intro4)
            Check_Rename_File(intro5)
            Check_Rename_File(intro6)
            Check_Rename_File(intro7)
            StatusUpdate("Finished applying skip")
        ElseIf CB_UnSkipIntro.Checked Then
            StatusUpdate("Removing intro movies skip.")
            StatusUpdate(Seperator)
            UndoSkip(intro1, "\IntroMovie\")
            UndoSkip(intro2)
            UndoSkip(intro3)
            UndoSkip(intro4)
            UndoSkip(intro5)
            UndoSkip(intro6)
            UndoSkip(intro7)
            StatusUpdate("Finished undoing skip")
        ElseIf CB_SkipIntro.Checked = False And CB_UnSkipIntro.Checked = False Then
            StatusUpdate("Nothing to do")
            StatusUpdate("Please choose an option")
        End If
        StatusUpdate(Seperator)
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
        Else
            StatusUpdate(intro + " could not be found")
        End If
    End Sub

    Private Sub UndoSkip(ByVal intro As String, Optional ByVal path As String = "")
        If File.Exists(moviePath + path + intro + ".SKIP") Then
            StatusUpdate("Resetting " + intro + " to show.")
            My.Computer.FileSystem.RenameFile(moviePath + path + intro + ".SKIP", intro)
        ElseIf File.Exists(moviePath + path + intro) Then
            StatusUpdate(intro + " already set to show")
        Else
            StatusUpdate(intro + " could not be found")
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
