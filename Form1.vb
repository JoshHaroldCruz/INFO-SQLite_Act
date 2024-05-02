Imports System.Net
Imports System.Net.Mail
Imports System.Data.SQLite
Imports System.Data.SqlClient
Imports Windows.Win32.System
Public Class Form1
    Dim verificationcode As String = Guid.NewGuid().ToString
    Dim isOTPgenerated As Boolean = False
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()
    End Sub

    Private Function GetSQLiteConnection() As SQLiteConnection
        Dim connectionString As String = "Data Source=users.db;Version=3;"
        Return New SQLiteConnection(connectionString)
    End Function

    Private Function IsPasswordStrong(password As String) As Boolean
        Dim minLength As Integer = 8
        Dim hasUpperCase As Boolean = False
        Dim hasLowerCase As Boolean = False
        Dim hasDigit As Boolean = False
        Dim hasSpecialChar As Boolean = False

        For Each c As Char In password
            If Char.IsUpper(c) Then
                hasUpperCase = True
            ElseIf Char.IsLower(c) Then
                hasLowerCase = True
            ElseIf Char.IsDigit(c) Then
                hasDigit = True
            ElseIf Char.IsPunctuation(c) OrElse Char.IsSymbol(c) Then
                hasSpecialChar = True
            End If
        Next

        If password.Length >= minLength AndAlso hasUpperCase AndAlso hasLowerCase AndAlso hasDigit AndAlso hasSpecialChar Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function IsEmailRegistered(email As String) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM Tbl_Users WHERE Email = '" & email & "'"
        Dim count As Integer

        Try
            Using con As New SQLiteConnection(GetSQLiteConnection.ConnectionString)
                con.Open()
                Using cmd As New SQLiteCommand(query, con)
                    count = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error checking email registration: " & ex.Message)
        End Try

        Return count > 0
    End Function

    Private Sub SendOTPByEmail(email As String)
        Dim senderEmail As String = "cruz.joshharold@gmail.com"
        Dim senderPassword As String = "ibcx agfs nvse xxsk"
        Dim smtpServer As String = "smtp.gmail.com"
        Dim smtpPort As Integer = 587

        Try
            Dim cl As New SmtpClient(smtpServer)
            cl.Port = smtpPort
            cl.Credentials = New NetworkCredential(senderEmail, senderPassword)
            cl.EnableSsl = True

            Dim message As New MailMessage(senderEmail, email)
            message.Subject = "OTP Verification"
            message.Body = "Your OTP is: " & verificationcode

            cl.Send(message)
            MessageBox.Show("OTP sent successfully to your email.")
        Catch ex As Exception
            MessageBox.Show("Error sending OTP: " & ex.Message)
        End Try
    End Sub

    Private Sub CreateUserTable()
        Try
            Using con As New SQLiteConnection(GetSQLiteConnection.ConnectionString)
                con.Open()
                Dim SQL As String = "CREATE TABLE IF NOT EXISTS Tbl_Users (user_id INTEGER PRIMARY KEY AUTOINCREMENT, Email TEXT, Password TEXT, RegDate TEXT, RegTime TEXT)"
                Using cmd As New SQLiteCommand(SQL, con)
                    cmd.ExecuteNonQuery()
                End Using
                MessageBox.Show("User table created successfully or already exists.")
            End Using
        Catch ex As Exception
            MessageBox.Show("Error creating user table: " & ex.Message)
        End Try
    End Sub

    Private Sub Btn_LogIn_Click(sender As Object, e As EventArgs) Handles Btn_LogIn.Click
        Dim email As String = TxtBox_Email.Text
        Dim password As String = TxtBox_Password.Text

        If Not String.IsNullOrEmpty(email) AndAlso Not String.IsNullOrEmpty(password) Then
            If IsEmailRegistered(email) Then
                Dim query As String = "SELECT COUNT(*) FROM Tbl_Users WHERE Email = '" & email & "' AND Password = '" & password & "'"
                Dim count As Integer

                Try
                    Using con As New SQLiteConnection(GetSQLiteConnection.ConnectionString)
                        con.Open()
                        Using cmd As New SQLiteCommand(query, con)
                            count = Convert.ToInt32(cmd.ExecuteScalar())
                        End Using
                    End Using
                    If count > 0 Then
                        Mainform.Show()
                    Else
                        MessageBox.Show("Incorrect email or password")
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error during login: " & ex.Message)
                End Try
            Else
                MessageBox.Show("Email is not registered")
            End If
        Else
            MessageBox.Show("Please enter email and password")
        End If
    End Sub

    Private Sub Btn_Register_Click(sender As Object, e As EventArgs) Handles Btn_Register.Click
        Dim enteredOTP As String = TxtBox_OTP.Text
        Dim currentdate As Date = Date.Now
        Dim regDate As String = currentdate.ToShortDateString()
        Dim regTime As String = currentdate.ToShortTimeString()

        If isOTPgenerated Then
            If enteredOTP.Equals(verificationcode, StringComparison.OrdinalIgnoreCase) Then
                Dim email As String = TxtBox_Email.Text
                Dim password As String = TxtBox_Password.Text

                If Not IsEmailRegistered(email) Then
                    If IsPasswordStrong(password) Then
                        CreateUserTable()
                        Dim insertquery As String = "INSERT INTO Tbl_Users (Email, Password, RegDate, RegTime) VALUES('" & email & "', '" & password & "', '" & regDate & "', '" & regTime & "')"

                        Try
                            Using con As New SQLiteConnection(GetSQLiteConnection.ConnectionString)
                                con.Open()
                                Using cmd As New SQLiteCommand(insertquery, con)
                                    cmd.ExecuteNonQuery()
                                End Using
                            End Using
                            MessageBox.Show("Registration Successful")
                        Catch ex As Exception
                            MessageBox.Show("Error registering user: " & ex.Message)
                        End Try
                    Else
                        MessageBox.Show("Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")
                    End If
                Else
                    MessageBox.Show("Email is already registered.")
                End If
            Else
                MessageBox.Show("Entered OTP is incorrect")
            End If
        Else
            MessageBox.Show("Please generate OTP first")
        End If
    End Sub

    Private Sub Lnk_GetOTP_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Lnk_GetOTP.LinkClicked
        Dim email As String = TxtBox_Email.Text
        SendOTPByEmail(email)
        isOTPgenerated = True
    End Sub

    Private Sub CB_ShowPass_CheckedChanged(sender As Object, e As EventArgs) Handles CB_ShowPass.CheckedChanged
        If CB_ShowPass.Checked Then
            TxtBox_Password.UseSystemPasswordChar = False
        Else
            TxtBox_Password.UseSystemPasswordChar = True
        End If
    End Sub
End Class
