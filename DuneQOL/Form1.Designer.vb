﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        BTN_Apply = New Button()
        CB_SkipIntro = New CheckBox()
        LIST_LOG = New ListBox()
        CB_UnSkipIntro = New CheckBox()
        BTN_PlayGame = New Button()
        BTN_SetGameFolder = New Button()
        SuspendLayout()
        ' 
        ' BTN_Apply
        ' 
        BTN_Apply.Location = New Point(387, 253)
        BTN_Apply.Name = "BTN_Apply"
        BTN_Apply.Size = New Size(114, 32)
        BTN_Apply.TabIndex = 2
        BTN_Apply.Text = "Apply"
        BTN_Apply.UseVisualStyleBackColor = True
        ' 
        ' CB_SkipIntro
        ' 
        CB_SkipIntro.AutoSize = True
        CB_SkipIntro.Location = New Point(12, 12)
        CB_SkipIntro.Name = "CB_SkipIntro"
        CB_SkipIntro.Size = New Size(76, 19)
        CB_SkipIntro.TabIndex = 3
        CB_SkipIntro.Text = "Skip Intro"
        CB_SkipIntro.UseVisualStyleBackColor = True
        ' 
        ' LIST_LOG
        ' 
        LIST_LOG.BackColor = SystemColors.ButtonFace
        LIST_LOG.BorderStyle = BorderStyle.None
        LIST_LOG.FormattingEnabled = True
        LIST_LOG.ItemHeight = 15
        LIST_LOG.Location = New Point(12, 37)
        LIST_LOG.Name = "LIST_LOG"
        LIST_LOG.SelectionMode = SelectionMode.None
        LIST_LOG.Size = New Size(489, 210)
        LIST_LOG.TabIndex = 4
        ' 
        ' CB_UnSkipIntro
        ' 
        CB_UnSkipIntro.AutoSize = True
        CB_UnSkipIntro.Location = New Point(94, 12)
        CB_UnSkipIntro.Name = "CB_UnSkipIntro"
        CB_UnSkipIntro.Size = New Size(108, 19)
        CB_UnSkipIntro.TabIndex = 5
        CB_UnSkipIntro.Text = "Undo Skip Intro"
        CB_UnSkipIntro.UseVisualStyleBackColor = True
        ' 
        ' BTN_PlayGame
        ' 
        BTN_PlayGame.Location = New Point(12, 253)
        BTN_PlayGame.Name = "BTN_PlayGame"
        BTN_PlayGame.Size = New Size(271, 32)
        BTN_PlayGame.TabIndex = 7
        BTN_PlayGame.Text = "Play Dune"
        BTN_PlayGame.UseVisualStyleBackColor = True
        ' 
        ' BTN_SetGameFolder
        ' 
        BTN_SetGameFolder.Location = New Point(208, 9)
        BTN_SetGameFolder.Name = "BTN_SetGameFolder"
        BTN_SetGameFolder.Size = New Size(293, 23)
        BTN_SetGameFolder.TabIndex = 8
        BTN_SetGameFolder.Text = "Select Game Folder"
        BTN_SetGameFolder.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(513, 295)
        Controls.Add(BTN_SetGameFolder)
        Controls.Add(BTN_PlayGame)
        Controls.Add(CB_UnSkipIntro)
        Controls.Add(LIST_LOG)
        Controls.Add(CB_SkipIntro)
        Controls.Add(BTN_Apply)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Dune: Awakening QOL"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents BTN_Apply As Button
    Friend WithEvents CB_SkipIntro As CheckBox
    Friend WithEvents LIST_LOG As ListBox
    Friend WithEvents CB_UnSkipIntro As CheckBox
    Friend WithEvents BTN_PlayGame As Button
    Friend WithEvents BTN_SetGameFolder As Button

End Class
