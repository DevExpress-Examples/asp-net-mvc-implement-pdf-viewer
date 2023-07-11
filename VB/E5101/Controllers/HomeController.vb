Imports System
Imports System.Web
Imports System.Web.Mvc
Imports DevExpress.Web.Mvc
Imports DevExpress.Web.ASPxUploadControl

Namespace E5101.Controllers

    Public Class HomeController
        Inherits Controller

        Public Function Index() As ActionResult
            Return View()
        End Function

        Public Function PdfUploadControlUpload() As ActionResult
            Call UploadControlExtension.GetUploadedFiles("PdfUploadControl", HomeControllerPdfUploadControlSettings.ValidationSettings, New EventHandler(Of FileUploadCompleteEventArgs)(AddressOf HomeControllerPdfUploadControlSettings.FileUploadComplete))
            Return Nothing
        End Function

        Public Function CallbackPanelPartial() As ActionResult
            Return PartialView("_CallbackPanelPartial")
        End Function
    End Class

    Public Class HomeControllerPdfUploadControlSettings

        Public Shared ValidationSettings As ValidationSettings = New ValidationSettings() With {.AllowedFileExtensions = New String() {".pdf"}, .MaxFileSize = 4194304}

        Public Shared Sub FileUploadComplete(ByVal sender As Object, ByVal e As FileUploadCompleteEventArgs)
            If e.UploadedFile.IsValid Then
                HttpContext.Current.Session(PdfViewerController.SESSION_KEY) = e.UploadedFile.FileBytes
            End If
        End Sub
    End Class
End Namespace
