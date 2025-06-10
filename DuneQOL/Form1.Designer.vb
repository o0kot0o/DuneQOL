<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        ProgressBar1 = New ProgressBar()
        BTN_Apply = New Button()
        CB_SkipIntro = New CheckBox()
        SuspendLayout()
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.Location = New Point(12, 110)
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(430, 10)
        ProgressBar1.TabIndex = 1
        ' 
        ' BTN_Apply
        ' 
        BTN_Apply.Location = New Point(367, 81)
        BTN_Apply.Name = "BTN_Apply"
        BTN_Apply.Size = New Size(75, 23)
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
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(454, 132)
        Controls.Add(CB_SkipIntro)
        Controls.Add(BTN_Apply)
        Controls.Add(ProgressBar1)
        Name = "Form1"
        Text = "Dune: Awakening QOL"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents BTN_Apply As Button
    Friend WithEvents CB_SkipIntro As CheckBox

End Class
