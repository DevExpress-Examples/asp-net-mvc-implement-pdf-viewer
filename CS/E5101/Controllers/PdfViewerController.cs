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
            using (FileStream stream = new FileStream(Server.MapPath(pdfFileName), FileMode.Open)) {
                byte[] pdfFileBytes = new byte[stream.Length];
                stream.Read(pdfFileBytes, 0, (int)stream.Length);
                Session[SESSION_KEY] = pdfFileBytes;
            }
            return PartialView("_PdfViewerPartial");
        }

        public ActionResult Preview() {
            return PartialView("_PdfViewerPartial");
        }

        public ActionResult DocumentViewPartial() {
            PdfDocumentProcessor documentProcessor = new PdfDocumentProcessor();

            using (MemoryStream stream = new MemoryStream((byte[]) Session[SESSION_KEY])) {
                documentProcessor.LoadDocument(stream);
            }

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
