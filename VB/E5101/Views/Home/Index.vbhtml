@Code
    ViewBag.Title = "Home Page"
End Code
@Using (Html.BeginForm("PdfUploadControlForm", "UploadControl", FormMethod.Post))
    @Html.DevExpress().UploadControl(Sub(settings)
                                         settings.Name = "PdfUploadControl"
                                         settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "PdfUploadControlUpload"}
		
                                         settings.UploadMode = UploadControlUploadMode.Auto
                                         settings.Width = System.Web.UI.WebControls.Unit.Pixel(288)
                                         settings.ShowUploadButton = True
		
                                         settings.ValidationSettings.Assign(E5101.Controllers.HomeControllerPdfUploadControlSettings.ValidationSettings)
                                         settings.ClientSideEvents.FileUploadComplete = "function(s, e) { if (e.isValid) { CallbackPanel.PerformCallback(); } }"
                                     End Sub).GetHtml()
End Using

@Html.Action("CallbackPanelPartial")
