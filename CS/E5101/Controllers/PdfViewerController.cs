using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using E5101.Models;
using DevExpress.Pdf;
using System.IO;

namespace E5101.Controllers {
    public class PdfViewerController : Controller {
        public const string SESSION_KEY = "PdfFile";

        public ActionResult PreviewByFileName(string pdfFileName) {
            Session[SESSION_KEY] = System.IO.File.ReadAllBytes(Server.MapPath(pdfFileName));
            return PartialView("_PdfViewerPartial");
        }

        public ActionResult Preview() {
            return PartialView("_PdfViewerPartial");
        }

        public ActionResult DocumentViewPartial() {
            PdfDocumentProcessor documentProcessor = new PdfDocumentProcessor();

            MemoryStream stream = new MemoryStream((byte[])Session[SESSION_KEY]);
            documentProcessor.LoadDocument(stream);

            List<PdfPageModel> model = new List<PdfPageModel>();
            for (int pageNumber = 1; pageNumber <= documentProcessor.Document.Pages.Count; pageNumber++) {
                model.Add(new PdfPageModel(documentProcessor) {
                    PageNumber = pageNumber
                });
            }
            return PartialView("_DocumentViewPartial", model);
        }
    }
}
