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

Namespace WpfApplication1
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub
        Private report As XtraReport1
        Private ds As New nwindDataSet()

        Private Sub documentPreview1_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            report = New XtraReport1() With {.RequestParameters = False}
            report.categoriesTableAdapter.Fill(ds.Categories)


            Dim model As New XtraReportPreviewModel()
            model.Report = report
            AddHandler model.CustomizeParameterEditors, AddressOf model_CustomizeParameterEditors
            report.CreateDocument()
            documentPreview1.Model = model
        End Sub

        Private Sub model_CustomizeParameterEditors(ByVal sender As Object, ByVal e As CustomizeParameterEditorsEventArgs)

            If e.Parameter.Name = "CategoryID" Then
                Dim editor As New ComboBoxEdit()
                editor.ItemsSource = ds.Categories
                editor.DisplayMember = "CategoryName"
                editor.ValueMember = "CategoryID"
                editor.StyleSettings = New CheckedComboBoxStyleSettings()
                e.BoundDataMember = "EditValue"
                e.Editor = editor
            End If

        End Sub
    End Class
End Namespace
