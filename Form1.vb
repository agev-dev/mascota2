


Imports System.Data.SqlClient

Public Class Form1


    Dim connetionString As String = "Data Source=L201-EQUIPO08\SQLEXPRESS;Initial Catalog=veterinaria;User ID=sa;Password=alumnos"


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cargar_grid()
    End Sub

    Sub cargar_grid()
        Dim cnn As SqlConnection
        Dim cmd As SqlCommand
        Dim sql As String
        Dim reader As SqlDataReader
        DataGridView1.Rows.Clear()


        sql = "SELECT * FROM Mascota"

        cnn = New SqlConnection(connetionString)
        Try
            cnn.Open()
            cmd = New SqlCommand(sql, cnn)
            reader = cmd.ExecuteReader()
            While reader.Read()
                DataGridView1.Rows.Add(reader.Item("codigo"), reader.Item("nombre"))
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


        sql = "INSERT INTO mascota VALUES(" & TextBox1.Text & ",' " & TextBox2.Text & " ' )"

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

        cargar_grid()

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cnn As SqlConnection
        Dim cmd As SqlCommand
        Dim sql As String


        sql = "DELETE FROM mascota WHERE codigo = " & TextBox1.Text

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

        cargar_grid()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim cnn As SqlConnection
        Dim cmd As SqlCommand
        Dim sql As String



        sql = "UPDATE mascota SET nombre = '" & TextBox2.Text & "' WHERE codigo = " & TextBox1.Text

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

        cargar_grid()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Dim fila As Integer
        fila = DataGridView1.CurrentRow.Index()


        TextBox1.Text = DataGridView1.Item(0, fila).Value
        TextBox2.Text = DataGridView1.Item(1, fila).Value




    End Sub





End Class
