Imports System.Data.SqlClient
Public Class Libros
    Dim con As New SqlConnection(My.Settings.Conexion)
    Dim cmd As New SqlCommand
    Public nombre As String
    Public genero As String
    Public precio As Integer


    Public Function AgregarLibro()
        Try
            con.Open()
            cmd = New SqlCommand("SP_AgregarLibros", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@nombre", nombre)
            cmd.Parameters.AddWithValue("@genero", genero)
            cmd.Parameters.AddWithValue("@precio", precio)
            If cmd.ExecuteNonQuery() Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            con.Close()
        End Try
    End Function

End Class
