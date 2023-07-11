Imports System.Drawing
Imports System.IO
Imports DevExpress.Pdf
Imports System.Drawing.Imaging

Namespace E5101.Models

    Public Class PdfPageModel

        Private _documentProcessor As PdfDocumentProcessor

        Public Sub New(ByVal documentProcessor As PdfDocumentProcessor)
            _documentProcessor = documentProcessor
        End Sub

        Public ReadOnly Property DocumentProcessor As PdfDocumentProcessor
            Get
                Return _documentProcessor
            End Get
        End Property

        Public Property PageNumber As Integer

        Public Function GetPageImageBytes() As Byte()
            Using bitmap As Bitmap = DocumentProcessor.CreateBitmap(PageNumber, 900)
                Using stream As MemoryStream = New MemoryStream()
                    bitmap.Save(stream, ImageFormat.Png)
                    Return stream.ToArray()
                End Using
            End Using
        End Function
    End Class
End Namespace
