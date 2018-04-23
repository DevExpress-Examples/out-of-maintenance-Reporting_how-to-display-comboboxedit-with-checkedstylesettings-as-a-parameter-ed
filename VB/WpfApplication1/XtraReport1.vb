Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Linq
Imports DevExpress.XtraReports.UI
Imports System.Collections.Generic

Namespace WpfApplication1
    Partial Public Class XtraReport1
        Inherits DevExpress.XtraReports.UI.XtraReport

        Public Sub New()
            InitializeComponent()
            AddHandler BeforePrint, AddressOf XtraReport1_BeforePrint
        End Sub

        Private Sub XtraReport1_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
            Me.FilterString = "[CategoryID] In (" & ConvertParameterValues() & ")"
        End Sub

        Private Function ConvertParameterValues() As String
            If Parameters(0).Value.GetType() Is GetType(System.Int32) Then
                Return Parameters(0).Value.ToString()
            End If

            Dim valuesList As List(Of Object) = TryCast(Parameters(0).Value, List(Of Object))
            Dim FilterStringValue As String = String.Empty

            If valuesList IsNot Nothing Then
                For i As Integer = 0 To valuesList.Count - 1
                    FilterStringValue &= valuesList(i).ToString()
                    If i <> valuesList.Count - 1 Then
                        FilterStringValue &= ","
                    End If
                Next i
            End If
            Return FilterStringValue
        End Function
    End Class
End Namespace
