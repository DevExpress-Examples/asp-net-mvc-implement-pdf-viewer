Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports DevExpress.Web.Mvc
Imports E5101.Models
Imports DevExpress.Pdf
Imports System.IO

Namespace E5101.Controllers

    Public Class PdfViewerController
        Inherits System.Web.Mvc.Controller

        Public Const SESSION_KEY As String = "PdfFile"

        Public Function PreviewByFileName(ByVal pdfFileName As String) As ActionResult
            Using stream As System.IO.FileStream = New System.IO.FileStream(Me.Server.MapPath(pdfFileName), System.IO.FileMode.Open)
                Dim pdfFileBytes As Byte() = New Byte(stream.Length - 1) {}
                stream.Read(pdfFileBytes, 0, CInt(stream.Length))
                Me.Session(E5101.Controllers.PdfViewerController.SESSION_KEY) = pdfFileBytes
            End Using

            Return Me.PartialView("_PdfViewerPartial")
        End Function

        Public Function Preview() As ActionResult
            Return Me.PartialView("_PdfViewerPartial")
        End Function

        Public Function DocumentViewPartial() As ActionResult
            Dim documentProcessor As DevExpress.Pdf.PdfDocumentProcessor = New DevExpress.Pdf.PdfDocumentProcessor()
            Using stream As System.IO.MemoryStream = New System.IO.MemoryStream(CType(Me.Session(E5101.Controllers.PdfViewerController.SESSION_KEY), Byte()))
                documentProcessor.LoadDocument(stream)
            End Using

            Dim model As System.Collections.Generic.List(Of E5101.Models.PdfPageModel) = New System.Collections.Generic.List(Of E5101.Models.PdfPageModel)()
            For pageNumber As Integer = 1 To documentProcessor.Document.Pages.Count
                model.Add(New E5101.Models.PdfPageModel(documentProcessor) With {.PageNumber = pageNumber})
            Next

            Return Me.PartialView("_DocumentViewPartial", model)
        End Function
    End Class
End Namespace
