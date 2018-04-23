Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Drawing
Imports System.IO
Imports DevExpress.Pdf
Imports System.Drawing.Imaging

Namespace E5101.Models
	Public Class PdfPageModel
		Private _documentProcessor As PdfDocumentProcessor

		Public Sub New(ByVal documentProcessor As PdfDocumentProcessor)
			Me._documentProcessor = documentProcessor
		End Sub

		Public ReadOnly Property DocumentProcessor() As PdfDocumentProcessor
			Get
				Return _documentProcessor
			End Get
		End Property

		Private privatePageNumber As Integer
		Public Property PageNumber() As Integer
			Get
				Return privatePageNumber
			End Get
			Set(ByVal value As Integer)
				privatePageNumber = value
			End Set
		End Property

		Public Function GetPageImageBytes() As Byte()
			Using bitmap As Bitmap = DocumentProcessor.CreateBitmap(PageNumber, 900)
				Using stream As New MemoryStream()
					bitmap.Save(stream, ImageFormat.Png)
					Return stream.ToArray()
				End Using
			End Using
		End Function
	End Class
End Namespace