@Imports E5101.Models
@ModelType List(Of PdfPageModel)
@Html.DevExpress().DataView(Sub(settings)
                                settings.Name = "DocumentView"
                                settings.CallbackRouteValues = New With {
                                    .Controller = "PdfViewer",
                                    .Action = "DocumentViewPartial"
                                }
                                settings.SettingsTableLayout.RowsPerPage = 1
                                settings.SettingsTableLayout.ColumnCount = 1
                                settings.PagerSettings.AllButton.Visible = True
                                settings.SetItemTemplateContent(Sub(c)
                                                                    Dim pageModel As PdfPageModel = CType(c.DataItem, PdfPageModel)
                                                                    Html.DevExpress().BinaryImage(Sub(imageSettings)
                                                                                                      imageSettings.Name = "bimPdfPage" + pageModel.PageNumber.ToString()
                                                                                                  End Sub).Bind(pageModel.GetPageImageBytes()).Render()
                                                                End Sub)

                            End Sub).Bind(Model).GetHtml()
