<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        TxtBox_Email = New TextBox()
        TextBox2 = New TextBox()
        TxtBox_Password = New TextBox()
        TxtBox_OTP = New TextBox()
        Lnk_GetOTP = New LinkLabel()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Btn_LogIn = New Button()
        Btn_Register = New Button()
        CB_ShowPass = New CheckBox()
        LB_ForgotPassword = New LinkLabel()
        SuspendLayout()
        ' 
        ' TxtBox_Email
        ' 
        TxtBox_Email.Location = New Point(133, 93)
        TxtBox_Email.Name = "TxtBox_Email"
        TxtBox_Email.Size = New Size(354, 27)
        TxtBox_Email.TabIndex = 0
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(183, 152)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(0, 27)
        TextBox2.TabIndex = 0
        ' 
        ' TxtBox_Password
        ' 
        TxtBox_Password.Location = New Point(133, 138)
        TxtBox_Password.Name = "TxtBox_Password"
        TxtBox_Password.Size = New Size(354, 27)
        TxtBox_Password.TabIndex = 0
        TxtBox_Password.UseSystemPasswordChar = True
        ' 
        ' TxtBox_OTP
        ' 
        TxtBox_OTP.Location = New Point(133, 201)
        TxtBox_OTP.Name = "TxtBox_OTP"
        TxtBox_OTP.Size = New Size(125, 27)
        TxtBox_OTP.TabIndex = 0
        ' 
        ' Lnk_GetOTP
        ' 
        Lnk_GetOTP.AutoSize = True
        Lnk_GetOTP.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Lnk_GetOTP.LinkColor = Color.Black
        Lnk_GetOTP.Location = New Point(264, 204)
        Lnk_GetOTP.Name = "Lnk_GetOTP"
        Lnk_GetOTP.Size = New Size(63, 20)
        Lnk_GetOTP.TabIndex = 1
        Lnk_GetOTP.TabStop = True
        Lnk_GetOTP.Text = "Get OTP"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(78, 96)
        Label1.Name = "Label1"
        Label1.Size = New Size(49, 20)
        Label1.TabIndex = 2
        Label1.Text = "Email:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(54, 141)
        Label2.Name = "Label2"
        Label2.Size = New Size(73, 20)
        Label2.TabIndex = 2
        Label2.Text = "Password:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(89, 204)
        Label3.Name = "Label3"
        Label3.Size = New Size(38, 20)
        Label3.TabIndex = 2
        Label3.Text = "OTP:"
        ' 
        ' Btn_LogIn
        ' 
        Btn_LogIn.Location = New Point(195, 243)
        Btn_LogIn.Name = "Btn_LogIn"
        Btn_LogIn.Size = New Size(94, 29)
        Btn_LogIn.TabIndex = 3
        Btn_LogIn.Text = "Log In"
        Btn_LogIn.UseVisualStyleBackColor = True
        ' 
        ' Btn_Register
        ' 
        Btn_Register.Location = New Point(295, 243)
        Btn_Register.Name = "Btn_Register"
        Btn_Register.Size = New Size(94, 29)
        Btn_Register.TabIndex = 3
        Btn_Register.Text = "Register"
        Btn_Register.UseVisualStyleBackColor = True
        ' 
        ' CB_ShowPass
        ' 
        CB_ShowPass.AutoSize = True
        CB_ShowPass.Location = New Point(133, 167)
        CB_ShowPass.Name = "CB_ShowPass"
        CB_ShowPass.Size = New Size(132, 24)
        CB_ShowPass.TabIndex = 4
        CB_ShowPass.Text = "Show Password"
        CB_ShowPass.UseVisualStyleBackColor = True
        ' 
        ' LB_ForgotPassword
        ' 
        LB_ForgotPassword.AutoSize = True
        LB_ForgotPassword.LinkColor = Color.Black
        LB_ForgotPassword.Location = New Point(369, 171)
        LB_ForgotPassword.Name = "LB_ForgotPassword"
        LB_ForgotPassword.Size = New Size(118, 20)
        LB_ForgotPassword.TabIndex = 5
        LB_ForgotPassword.TabStop = True
        LB_ForgotPassword.Text = "Forgot Password"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(573, 323)
        Controls.Add(LB_ForgotPassword)
        Controls.Add(CB_ShowPass)
        Controls.Add(Btn_Register)
        Controls.Add(Btn_LogIn)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(Lnk_GetOTP)
        Controls.Add(TextBox2)
        Controls.Add(TxtBox_OTP)
        Controls.Add(TxtBox_Password)
        Controls.Add(TxtBox_Email)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TxtBox_Email As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TxtBox_Password As TextBox
    Friend WithEvents TxtBox_OTP As TextBox
    Friend WithEvents Lnk_GetOTP As LinkLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Btn_LogIn As Button
    Friend WithEvents Btn_Register As Button
    Friend WithEvents CB_ShowPass As CheckBox
    Friend WithEvents LB_ForgotPassword As LinkLabel

End Class
