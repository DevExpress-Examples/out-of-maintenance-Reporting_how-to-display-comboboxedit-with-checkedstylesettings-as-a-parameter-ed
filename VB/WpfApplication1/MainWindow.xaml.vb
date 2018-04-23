Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Printing
Imports DevExpress.Xpf.Editors
Imports DevExpress.XtraReports.UI
Imports System.Data

Namespace WpfApplication1
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub documentPreview1_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)

            DataContext = New MainWindowViewModel(New XtraReport1() With {.RequestParameters = False})
        End Sub


        Public Class MainWindowViewModel
            Public Property ReportModel() As XtraReportPreviewModel
            Public Property DataSet() As nwindDataSet
            Public ReadOnly Property Categories() As DataTable
                Get
                    Return DataSet.Tables(0)
                End Get
            End Property
            Public Sub New(ByVal report As XtraReport)
                DataSet = New nwindDataSet()

                ReportModel = New XtraReportPreviewModel()
                ReportModel.Report = report

                TryCast(report, XtraReport1).categoriesTableAdapter.Fill(DataSet.Categories)
                report.CreateDocument(False)
            End Sub
        End Class
    End Class
End Namespace
