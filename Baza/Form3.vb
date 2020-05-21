Imports System.Data.OleDb
Imports System.Math
Public Class Form3
    Dim id As Double
    Dim h As Double
    Dim m As Double
    Dim r As Double
    Dim V1 As Double
    Dim V2 As Double
    Const G = 0.0000000000667
    Dim c As New OleDbCommand
    Dim ds As New DataSet
    Dim da As New OleDbDataAdapter(c)

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: данная строка кода позволяет загрузить данные в таблицу "BazaDataSet3.Планеты". При необходимости она может быть перемещена или удалена.
        Me.ПланетыTableAdapter.Fill(Me.BazaDataSet3.Планеты)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            id = Int16.Parse(ComboBox1.SelectedValue)
            h = Double.Parse(TextBox3.Text)

        Catch ex As Exception
            MsgBox("")
        End Try
        Dim planets = ПланетыTableAdapter.GetData()
        Dim rows = From Планеты In planets
                   Where Планеты.id = id
                   Select Планеты.Масса, Планеты.Радиус_планеты
        For Each row As Object In rows
            m = row.Масса
            r = row.Радиус_планеты
        Next
        V1 = Sqrt((G * m) / (r + h))
        V2 = V1 * Sqrt(2)
        TextBox1.Text = V1
        TextBox2.Text = V2
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        c.Connection = conn
        c.CommandText = "select * from Планеты"
        da.Fill(ds, "Планеты")
        Grid1.DataSource = ds
        Grid1.DataMember = "Планеты"
    End Sub
End Class