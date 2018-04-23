Imports DevExpress.Xpf.Printing.Parameters
Imports DevExpress.Xpf.Printing.Parameters.Models
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace WpfApplication1
    Friend Class CustomParameterTemplateSelector
        Inherits ParameterTemplateSelector

        Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As System.Windows.DependencyObject) As System.Windows.DataTemplate
            Dim parameterModel = TryCast(item, ParameterModel)
            If parameterModel.Name = "CategoryID" Then
                Return LookUpEditTemplate
            End If
            Return MyBase.SelectTemplate(item, container)
        End Function
    End Class
End Namespace
