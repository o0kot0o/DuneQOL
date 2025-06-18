Imports System.ComponentModel.Design
Imports System.Configuration
Imports System.DirectoryServices.ActiveDirectory
Imports System.IO
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms.Design
Imports System.Xml


Public Class Form1
    Dim Seperator As String = "-------------------------------------------------------------------------------------------------"
    Dim gamePath As String
    Dim moviePath As String
    Dim movie_List As New List(Of String)(
        {"IntroMovie\InitialIntro4k.bk2", "Logo_4K_Funcom_2s.bk2", "Logo_4K_Legendary_2s.bk2", "Logo_4K_LevelInfinite_2s.bk2", "Logo_4K_Unreal_2s.bk2",
        "StartupUE4.bk2", "EpilepsyInfo.bk2"})

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
            For Each movie As String In movie_List
                Check_Rename_File(movie)
            Next
            StatusUpdate("Finished applying skip")
        ElseIf CB_UnSkipIntro.Checked Then
            StatusUpdate("Removing intro movies skip.")
            StatusUpdate(Seperator)
            For Each movie As String In movie_List
                UndoSkip(movie)
            Next
            StatusUpdate("Finished undoing skip")
        ElseIf CB_SkipIntro.Checked = False And CB_UnSkipIntro.Checked = False Then
            StatusUpdate("Please choose an option from above.")
        End If
        StatusUpdate(Seperator)
    End Sub

    Private Sub StatusUpdate(ByVal update As String)
        LIST_LOG.Items.Add(update)
        LIST_LOG.TopIndex = LIST_LOG.Items.Count - 1
    End Sub

    Private Sub Check_Rename_File(ByVal intro As String)
        If File.Exists(moviePath + intro) Then
            StatusUpdate("Marking " + IO.Path.GetFileName(intro) + " as skipped")
            My.Computer.FileSystem.RenameFile(moviePath + intro, IO.Path.GetFileName(intro) + ".SKIP")
        ElseIf File.Exists(moviePath + intro + ".SKIP") Then
            StatusUpdate(IO.Path.GetFileName(intro) + " already set to skip")
        Else
            StatusUpdate(IO.Path.GetFileName(intro) + " could not be found")
        End If
        'End If
    End Sub

    Private Sub UndoSkip(ByVal intro As String)
        If File.Exists(moviePath + intro + ".SKIP") Then
            StatusUpdate("Resetting " + IO.Path.GetFileName(intro) + " to show.")
            My.Computer.FileSystem.RenameFile(moviePath + intro + ".SKIP", IO.Path.GetFileName(intro))
        ElseIf File.Exists(moviePath + intro) Then
            StatusUpdate(IO.Path.GetFileName(intro) + " already set to show")
        Else
            StatusUpdate(IO.Path.GetFileName(intro) + " could not be found")
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
        If File.Exists("config.conf") Then
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
            Return ""
        End If
        Return ""
    End Function

    Private Sub BTN_SetGameFolder_Click(sender As Object, e As EventArgs) Handles BTN_SetGameFolder.Click
        LIST_LOG.Items.Clear()
        StatusUpdate(Seperator)
        StatusUpdate("Find the DuneAwakening folder")
        StatusUpdate(Seperator)
        Using FolderBrowserDialog As New FolderBrowserDialog()
            FolderBrowserDialog.Description = "Select DuneAwakening Folder"
            Dim result As DialogResult = FolderBrowserDialog.ShowDialog()
            If result = DialogResult.OK Then
                If File.Exists("config.conf") Then
                    My.Computer.FileSystem.DeleteFile("config.conf")
                End If
                Dim folderPath As String = FolderBrowserDialog.SelectedPath
                Dim configFile As IO.StreamWriter
                configFile = My.Computer.FileSystem.OpenTextFileWriter("config.conf", True)
                configFile.WriteLine(folderPath)
                configFile.Close()
                gamePath = folderPath
                CheckGamePath()
            End If
        End Using
    End Sub

    Private Sub CheckGamePath()
        LIST_LOG.Items.Clear()
        StatusUpdate(Seperator)
        If gamePath Is Nothing Then
            StatusUpdate("Did not select a folder!")
            StatusUpdate("Exit and try again!")
        Else
            If File.Exists(gamePath + "\DuneSandbox.exe") Then
                BTN_PlayGame.Enabled = True
                BTN_Apply.Enabled = True
                CB_SkipIntro.Enabled = True
                CB_UnSkipIntro.Enabled = True
                StatusUpdate("Game Found at " + gamePath)
                moviePath = gamePath + "\DuneSandbox\Content\Movies\"
                StatusUpdate(Seperator)
            Else
                BTN_PlayGame.Enabled = False
                BTN_Apply.Enabled = False
                StatusUpdate("Could not find game at")
                StatusUpdate(gamePath)
                StatusUpdate("Select a new game folder")
            End If
            StatusUpdate(Seperator)
        End If
    End Sub

    Private Sub GetGamePath()
        BTN_Apply.Enabled = False
        CB_SkipIntro.Enabled = False
        CB_UnSkipIntro.Enabled = False
        gamePath = LoadConfigFile()
        CheckGamePath()
    End Sub
End Class
