Imports System.ComponentModel.Design
Imports System.Configuration
Imports System.DirectoryServices.ActiveDirectory
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms.Design
Imports System.Xml


Public Class Form1
    Dim var_SkipIntro As Boolean
    Dim Seperator As String = "-------------------------------------------------------------------------------------------------"
    Dim manifestFile As String = "appmanifest_1172710.acf"
    Dim steamPath As String
    Dim gamePath As String
    Dim moviePath As String
    Dim grace_gamePath As String = "D:\SteamLibrary\steamapps\common\DuneAwakening"
    Dim grace_moviePath As String = grace_gamePath + "\DuneSandbox\Content\Movies\"
    Dim intro1 As String = "InitialIntro4k.bk2"
    Dim intro2 As String = "Logo_4K_Funcom_2s.bk2"
    Dim intro3 As String = "Logo_4K_Legendary_2s.bk2"
    Dim intro4 As String = "Logo_4K_LevelInfinite_2s.bk2"
    Dim intro5 As String = "Logo_4K_Unreal_2s.bk2"
    Dim intro6 As String = "StartupUE4.bk2"
    Dim intro7 As String = "EpilepsyInfo.bk2"

    Private Sub GetGamePath()
        'Check for x86 or x64 System and get the correct Steam Path
        StatusUpdate(Seperator)
        StatusUpdate("Looking for Steam")
        StatusUpdate(Seperator)
        steamPath = GetSteamPath()
        If steamPath Is Nothing Then
            StatusUpdate("Could Not find Steam")
            StatusUpdate(Seperator)
            BTN_Apply.Enabled = False
            CB_SkipIntro.Enabled = False
            CB_UnSkipIntro.Enabled = False
        Else
            If 0 Then
                'StatusUpdate("Steam found at " & steamPath)
                ''gamePath = steamPath + "\steamapps\common\DuneAwakening"
                'gamePath = GetInstallDir(steamPath + "\steamapps\" + manifestFile)
                'If gamePath = Nothing Then
                '    gamePath = GetInstallDir("D:\SteamLibrary\steamapps\" + manifestFile)
                'End If
                'moviePath = gamePath + "\DuneSandbox\Content\Movies\"
                ''StatusUpdate("Found Dune at " & gamePath)
                'StatusUpdate(Seperator)
            End If
            StatusUpdate("Steam Found at " + steamPath)
            gamePath = LoadConfigFile()
            If gamePath Is Nothing Then
                StatusUpdate("Did not select a folder!")
                StatusUpdate("Exit and try again!")
            Else
                If File.Exists(gamePath + "\DuneSandbox.exe") Then
                    BTN_PlayGame.Enabled = True
                    StatusUpdate("Game Found at " + gamePath)
                    moviePath = gamePath + "\DuneSandbox\Content\Movies\"
                    StatusUpdate(Seperator)
                End If
            End If
        End If
    End Sub

    Private Function GetSteamPath()
        If System.Environment.Is64BitOperatingSystem Then
            If System.Environment.Is64BitOperatingSystem = True Then
                Return My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Valve\Steam", "InstallPath", Nothing)
            Else
                Return My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam", "InstallPath", Nothing)
            End If
            Return ""
        End If
        Return ""
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BTN_PlayGame.Enabled = False
        GetGamePath()
        'MsgBox(LoadConfigFile())
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
            StatusUpdate("Please choose an option from above.")
        End If
        StatusUpdate(Seperator)
    End Sub

    Private Sub StatusUpdate(ByVal update As String)
        LIST_LOG.Items.Add(update)
        LIST_LOG.TopIndex = LIST_LOG.Items.Count - 1
    End Sub

    Private Sub Check_Rename_File(ByVal intro As String, Optional ByVal path As String = "", Optional ByVal isgrace As Boolean = False)
        'If isgrace Then
        '    If File.Exists(grace_moviePath + path + intro) Then
        '        StatusUpdate("Marking " + intro + " as skipped")
        '        My.Computer.FileSystem.RenameFile(grace_moviePath + path + intro, intro + ".SKIP")
        '    ElseIf File.Exists(grace_moviePath + path + intro + ".SKIP") Then
        '        StatusUpdate(intro + " already set to skip")
        '    Else
        '        StatusUpdate(intro + " could not be found")
        '    End If
        'Else
        If File.Exists(moviePath + path + intro) Then
            StatusUpdate("Marking " + intro + " as skipped")
            My.Computer.FileSystem.RenameFile(moviePath + path + intro, intro + ".SKIP")
        ElseIf File.Exists(moviePath + path + intro + ".SKIP") Then
            StatusUpdate(intro + " already set to skip")
        Else
            StatusUpdate(intro + " could not be found")
        End If
        'End If
    End Sub

    Private Sub UndoSkip(ByVal intro As String, Optional ByVal path As String = "", Optional ByVal isgrace As Boolean = False)
        'If isgrace Then
        '    If File.Exists(grace_moviePath + path + intro + ".SKIP") Then
        '        StatusUpdate("Resetting " + intro + " to show.")
        '        My.Computer.FileSystem.RenameFile(grace_moviePath + path + intro + ".SKIP", intro)
        '    ElseIf File.Exists(grace_moviePath + path + intro) Then
        '        StatusUpdate(intro + " already set to show")
        '    Else
        '        StatusUpdate(intro + " could not be found")
        '    End If
        'Else
        If File.Exists(moviePath + path + intro + ".SKIP") Then
            StatusUpdate("Resetting " + intro + " to show.")
            My.Computer.FileSystem.RenameFile(moviePath + path + intro + ".SKIP", intro)
        ElseIf File.Exists(moviePath + path + intro) Then
            StatusUpdate(intro + " already set to show")
        Else
            StatusUpdate(intro + " could not be found")
        End If
        'End If
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

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        LIST_LOG.Items.Clear()
        StatusUpdate(Seperator)
        If CB_SkipIntro.Checked Then
            StatusUpdate("Applying Intro Skip to movies")
            StatusUpdate(Seperator)
            Check_Rename_File(intro1, "\IntroMovie\", isgrace:=True)
            Check_Rename_File(intro2, isgrace:=True)
            Check_Rename_File(intro3, isgrace:=True)
            Check_Rename_File(intro4, isgrace:=True)
            Check_Rename_File(intro5, isgrace:=True)
            Check_Rename_File(intro6, isgrace:=True)
            Check_Rename_File(intro7, isgrace:=True)
            StatusUpdate("Finished applying skip")
        ElseIf CB_UnSkipIntro.Checked Then
            StatusUpdate("Removing intro movies skip.")
            StatusUpdate(Seperator)
            UndoSkip(intro1, "\IntroMovie\", True)
            UndoSkip(intro2, isgrace:=True)
            UndoSkip(intro3, isgrace:=True)
            UndoSkip(intro4, isgrace:=True)
            UndoSkip(intro5, isgrace:=True)
            UndoSkip(intro6, isgrace:=True)
            UndoSkip(intro7, isgrace:=True)
            StatusUpdate("Finished undoing skip")
        ElseIf CB_SkipIntro.Checked = False And CB_UnSkipIntro.Checked = False Then
            StatusUpdate("Nothing to do")
            StatusUpdate("Please choose an option")
        End If
        StatusUpdate(Seperator)
    End Sub

    Private Function GetInstallDir(ByVal manifestfile As String)
        Dim filePath As String = manifestfile
        Dim installdir As String = ""

        If File.Exists(filePath) Then
            For Each line As String In File.ReadLines(filePath)
                If line.Trim().StartsWith("""installdir""") Then
                    ' Extract the value using split and clean-up
                    Dim parts() As String = line.Split(ControlChars.Quote)
                    If parts.Length >= 4 Then
                        installdir = parts(3) ' The value is the 4th quoted item
                        Exit For
                    End If
                End If
            Next
            If File.Exists(steamPath + "\steamapps\common\" + installdir + "\DuneSandbox.exe") Then
                BTN_PlayGame.Enabled = True
                StatusUpdate("Install Directory: " + steamPath + "\steamapps\common\" + installdir)
                Return steamPath + "\steamapps\common\" + installdir
            Else
                StatusUpdate("Could not find install directory: " + filePath)
                Return ""
            End If
        Else
            StatusUpdate("Could not find install directory: " + filePath)
        End If
        Return ""
    End Function

    Private Sub BTN_PlayGame_Click(sender As Object, e As EventArgs) Handles BTN_PlayGame.Click
        If File.Exists(gamePath + "\DuneSandbox\Binaries\Win64\DuneSandbox_BE.exe") Then
            LIST_LOG.Items.Clear()
            StatusUpdate(Seperator)
            StatusUpdate("Starting Dune")
            StatusUpdate("Please Wait...")
            Process.Start(gamePath + "\DuneSandbox\Binaries\Win64\DuneSandbox_BE.exe", "-nosplash -BattlEye -continuesession %command%")
        Else
            LIST_LOG.Items.Clear()
            StatusUpdate(Seperator)
            StatusUpdate("Could not find DuneSandbox_BE.exe")
        End If
    End Sub

    Private Function LoadConfigFile()
        If File.Exists("config.Conf") Then
            Dim configFile As IO.StreamReader = IO.File.OpenText("config.conf")
            Dim folderPath As String = configFile.ReadLine()
            configFile.Close()
            Return folderPath
        Else
            Using FolderBrowserDialog As New FolderBrowserDialog()
                FolderBrowserDialog.Description = "Select DuneAwakening Folder"
                Dim result As DialogResult = FolderBrowserDialog.ShowDialog()
                If result = DialogResult.OK Then
                    Dim folderPath As String = FolderBrowserDialog.SelectedPath
                    Dim configFile As IO.StreamWriter
                    configFile = My.Computer.FileSystem.OpenTextFileWriter("config.conf", True)
                    configFile.WriteLine(folderPath)
                    configFile.Close()
                    Return folderPath
                End If
                Return ""
            End Using
        End If
        Return ""
    End Function
End Class
