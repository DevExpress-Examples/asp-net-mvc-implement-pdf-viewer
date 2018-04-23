Imports Microsoft.VisualBasic
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
		Inherits Controller
		Public Const SESSION_KEY As String = "PdfFile"

		Public Function PreviewByFileName(ByVal pdfFileName As String) As ActionResult
			Using stream As New FileStream(Server.MapPath(pdfFileName), FileMode.Open)
				Dim pdfFileBytes(stream.Length - 1) As Byte
				stream.Read(pdfFileBytes, 0, CInt(Fix(stream.Length)))
				Session(SESSION_KEY) = pdfFileBytes
			End Using
			Return PartialView("_PdfViewerPartial")
		End Function

		Public Function Preview() As ActionResult
			Return PartialView("_PdfViewerPartial")
		End Function

		Public Function DocumentViewPartial() As ActionResult
			Dim documentProcessor As New PdfDocumentProcessor()

			Using stream As New MemoryStream(CType(Session(SESSION_KEY), Byte()))
				documentProcessor.LoadDocument(stream)
			End Using

			Dim model As New List(Of PdfPageModel)()
			For pageNumber As Integer = 1 To documentProcessor.Document.Pages.Count
				model.Add(New PdfPageModel(documentProcessor) With {.PageNumber = pageNumber})
			Next pageNumber
			Return PartialView("_DocumentViewPartial", model)
		End Function
	End Class
End Namespace
