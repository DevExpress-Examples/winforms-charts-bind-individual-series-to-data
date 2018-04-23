Imports System
Imports System.Data
Imports System.Windows.Forms
Imports DevExpress.XtraCharts
' ...


Public Class Form1

    Private Function CreateChartData(ByVal rowCount As Integer) As DataTable
        ' Create an empty table.
        Dim Table As New DataTable("Table1")

        ' Add two columns to the table.
        Table.Columns.Add("Argument", GetType(Int32))
        Table.Columns.Add("Value", GetType(Int32))

        ' Add data rows to the table.
        Dim Rnd As New Random()
        Dim Row As DataRow = Nothing
        Dim i As Integer
        For i = 0 To rowCount - 1
            Row = Table.NewRow()
            Row("Argument") = i
            Row("Value") = Rnd.Next(100)
            Table.Rows.Add(Row)
        Next i

        Return Table
    End Function


    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.Load
        ' Create a chart.
        Dim Chart As New ChartControl()

        ' Create an empty Bar series and add it to the chart.
        Dim Series As New Series("Series1", ViewType.Bar)
        Chart.Series.Add(Series)

        ' Generate a data table and bind the series to it.
        Series.DataSource = CreateChartData(50)

        ' Specify data members to bind the series.
        Series.ArgumentScaleType = ScaleType.Numerical
        Series.ArgumentDataMember = "Argument"
        Series.ValueScaleType = ScaleType.Numerical
        Series.ValueDataMembers.AddRange(New String() {"Value"})

        ' Set some properties to get a nice-looking chart.
        CType(Series.View, SideBySideBarSeriesView).ColorEach = True
        CType(Chart.Diagram, XYDiagram).AxisY.Visible = False
        Chart.Legend.Visible = False

        ' Dock the chart into its parent and add it to the current form.
        Chart.Dock = DockStyle.Fill
        Me.Controls.Add(Chart)
    End Sub
End Class
