@Html.DevExpress().CallbackPanel(Sub(settings)
                                     settings.Name = "CallbackPanel"
                                     settings.CallbackRouteValues = New With {
                                         .Controller = "Home",
                                         .Action = "CallbackPanelPartial"
                                     }

                                     settings.SetContent(Sub()
                                                             If Not IsNothing(Session(E5101.Controllers.PdfViewerController.SESSION_KEY)) Then
                                                                 Html.RenderAction("Preview", "PdfViewer")
        
                                                             Else
                                                                 Html.RenderAction("PreviewByFileName", "PdfViewer", New With {
                                                                                                   .PdfFileName = "~/FallCatalog.pdf"
                                                                 })
                                                             End If
                                                         End Sub)
                                 End Sub).GetHtml()
