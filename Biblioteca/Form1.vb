Imports System.Data.SqlClient
Public Class Form1
    Dim libros1 As New Libros

    Private Sub Btn_Enviar_Click(sender As Object, e As EventArgs) Handles Btn_Enviar.Click
        libros1.nombre = Text_nom.Text
        libros1.genero = Text_gen.Text
        libros1.precio = Val(Text_precio.Text)

        If libros1.AgregarLibro Then
            MsgBox("Agregado")
        Else
            MsgBox("Error al agregar")
        End If
    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click
        Dim con As New SqlConnection(My.Settings.Conexion)
        Dim sql As String = "Select * from libros"
        Dim cmd As New SqlCommand(sql, con)
        Try
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds, "libros")
            Me.DGV.DataSource = ds.Tables("libros")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
