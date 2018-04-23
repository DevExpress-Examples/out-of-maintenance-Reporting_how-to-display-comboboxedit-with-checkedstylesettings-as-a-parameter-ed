Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.XtraReports.UI
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace WpfApplication1
    <POCOViewModel> _
    Public Class MainWindowViewModel
        Inherits ViewModelBase


        Private report_Renamed As XtraReport1
        Public ReadOnly Property Report() As XtraReport
            Get
                Return report_Renamed
            End Get
        End Property
        Public Property DataSet() As nwindDataSet
        Public ReadOnly Property Categories() As DataTable
            Get
                Return DataSet.Tables(0)
            End Get
        End Property
        Public Sub New()
            If IsInDesignMode Then
                Return
            End If
            report_Renamed = New XtraReport1() With {.RequestParameters = False}
            DataSet = New nwindDataSet()
            report_Renamed.categoriesTableAdapter.Fill(DataSet.Categories)
        End Sub
    End Class
End Namespace
