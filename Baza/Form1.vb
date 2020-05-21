Imports System.Data.OleDb
Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RefreshGrid()
    End Sub

    Private Sub RefreshGrid()
        Dim c As New OleDbCommand
        c.Connection = conn
        c.CommandText = "select * from Планеты"
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter(c)
        da.Fill(ds, "Планеты")
        Grid1.DataSource = ds
        Grid1.DataMember = "Планеты"
        Grid1.Columns("Id").Visible = False
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New OleDbConnection
        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Комплюхтар\Desktop\Программирование\Baza\Baza\Baza.accdb;Persist Security Info=False"
        conn.Open()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim s1 As String
        Dim s2 As Double
        Dim s3 As Double
        Dim r As DialogResult
        Form2.ShowDialog()
        s1 = Form2.TextBox1.Text
        s2 = Form2.TextBox2.Text
        s3 = Form2.TextBox3.Text
        r = Form2.DialogResult
        Form2.Close()
        If r <> DialogResult.OK Then
            Exit Sub
        End If
        Dim c As New OleDbCommand
        c.Connection = conn
        c.CommandText = "insert into [Планеты]([Название], [Радиус планеты], [Масса]) values('" & s1 & "' , '" & s2 & "' , '" & s3 & "') "
        c.ExecuteNonQuery()
        RefreshGrid()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim k As Integer
        k = Grid1.CurrentRow.Cells("id").Value
        Dim c As New OleDbCommand
        c.Connection = conn
        c.CommandText = "delete from Планеты where id = " & k
        c.ExecuteNonQuery()
        RefreshGrid()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form3.Show()
        RefreshGrid()
    End Sub
End Class
