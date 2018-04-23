Imports System
Imports System.Data
Imports System.Windows.Forms
Imports DevExpress.XtraCharts
' ...

Namespace BindIndividualSeriesRuntimeCS
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Function CreateChartData(ByVal rowCount As Integer) As DataTable
            ' Create an empty table.
            Dim table As New DataTable("Table1")

            ' Add two columns to the table.
            table.Columns.Add("Argument", GetType(Int32))
            table.Columns.Add("Value", GetType(Int32))

            ' Add data rows to the table.
            Dim rnd As New Random()
            Dim row As DataRow = Nothing
            For i As Integer = 0 To rowCount - 1
                row = table.NewRow()
                row("Argument") = i
                row("Value") = rnd.Next(100)
                table.Rows.Add(row)
            Next i

            Return table
        End Function

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            ' Create a chart.
            Dim chart As New ChartControl()

            ' Create an empty Bar series and add it to the chart.
            Dim series As New Series("Series1", ViewType.Bar)
            chart.Series.Add(series)

            ' Generate a data table and bind the series to it.
            series.DataSource = CreateChartData(50)

            ' Specify data members to bind the series.
            series.ArgumentScaleType = ScaleType.Numerical
            series.ArgumentDataMember = "Argument"
            series.ValueScaleType = ScaleType.Numerical
            series.ValueDataMembers.AddRange(New String() { "Value" })

            ' Set some properties to get a nice-looking chart.
            CType(series.View, SideBySideBarSeriesView).ColorEach = True
            CType(chart.Diagram, XYDiagram).AxisY.Visibility = DevExpress.Utils.DefaultBoolean.False
            chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False

            ' Dock the chart into its parent and add it to the current form.
            chart.Dock = DockStyle.Fill
            Me.Controls.Add(chart)
        End Sub
    End Class
End Namespace