Imports System.Data.SqlClient
Public Class Form1
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim i As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.ConnectionString = "Data Source=DESKTOP-V9FBPK8\SQLEXPRESS; Initial Catalog=linuxejemplo;integrated Security=True
"
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        Label1.Text = "Guatemala tierra bendita por Dios"
        Disp_data()
    End Sub

    Public Sub Disp_data()
        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select * from Categoria2"
        cmd.ExecuteNonQuery()
        Dim dt As New DataTable()
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(dt)
        DataGridView1.DataSource = dt
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "insert into Categoria2 values('" & TextBox1.Text & "','" & TextBox2.Text & "')"
        cmd.ExecuteNonQuery()
        TextBox1.Text = ""
        TextBox2.Text = ""
        Label1.Text = "Exito al grabar información."
        Disp_data()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            i = Convert.ToInt32(DataGridView1.SelectedCells.Item(0).Value.ToString())
            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select * from Categoria2 where Codigo=" & i&
            cmd.ExecuteNonQuery()
            Dim dt As New DataTable()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            Dim dr As SqlClient.SqlDataReader
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While dr.Read
                TextBox1.Text = dr.GetString(1).ToString()
                TextBox2.Text = dr.GetString(2).ToString()
            End While
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Disp_data()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "delete from Categoria2 where Codigo=" & TextBox1.Text
        cmd.ExecuteNonQuery()
        Disp_data()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        Dim valorNumerico As Integer
        valorNumerico = Val(TextBox1.Text)
        Label1.Text = valorNumerico.ToString(ToString)
        cmd.CommandText = "update Categoria2 set Codigo='" & TextBox1.Text & "', Descripcion='" & TextBox2.Text & "' where Codigo='" & i & "'"
        cmd.ExecuteNonQuery()
        Disp_data()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class
