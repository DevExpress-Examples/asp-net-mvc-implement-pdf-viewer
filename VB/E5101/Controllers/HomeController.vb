Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports DevExpress.Web.Mvc
Imports DevExpress.Web

Namespace E5101.Controllers
	Public Class HomeController
		Inherits Controller
		Public Function Index() As ActionResult
			Return View()
		End Function

		Public Function PdfUploadControlUpload() As ActionResult
            UploadControlExtension.GetUploadedFiles("PdfUploadControl", HomeControllerPdfUploadControlSettings.ValidationSettings, AddressOf HomeControllerPdfUploadControlSettings.FileUploadComplete)
			Return Nothing
		End Function

		Public Function CallbackPanelPartial() As ActionResult
			Return PartialView("_CallbackPanelPartial")
		End Function
	End Class
	Public Class HomeControllerPdfUploadControlSettings
		Public Shared ValidationSettings As DevExpress.Web.UploadControlValidationSettings = New UploadControlValidationSettings() With {.AllowedFileExtensions = New String() { ".pdf" }, .MaxFileSize = 4194304}
		Public Shared Sub FileUploadComplete(ByVal sender As Object, ByVal e As FileUploadCompleteEventArgs)
			If e.UploadedFile.IsValid Then
				HttpContext.Current.Session(E5101.Controllers.PdfViewerController.SESSION_KEY) = e.UploadedFile.FileBytes
			End If
		End Sub
	End Class

End Namespace