


Imports System.Data.SqlClient

Public Class Form1


    Dim connetionString As String = "Data Source=L201-EQUIPO08\SQLEXPRESS;Initial Catalog=veterinaria;User ID=sa;Password=alumnos"


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim cnn As SqlConnection
        Dim cmd As SqlCommand
        Dim sql As String
        Dim reader As SqlDataReader

        sql = "SELECT * FROM Mascota"

        cnn = New SqlConnection(connetionString)
        Try
            cnn.Open()
            cmd = New SqlCommand(sql, cnn)
            reader = cmd.ExecuteReader()
            While reader.Read()
                MsgBox(reader.Item(0) & "  Codigo " & reader.Item(1) & "  Nombre  ")
            End While
            reader.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception

            MsgBox(ex.Message)
        End Try





    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim cnn As SqlConnection
        Dim cmd As SqlCommand
        Dim sql As String


        sql = "INSERT INTO Mascota VALUES('5','Paracas')"

        cnn = New SqlConnection(connetionString)
        Try
            cnn.Open()
            cmd = New SqlCommand(sql, cnn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class
