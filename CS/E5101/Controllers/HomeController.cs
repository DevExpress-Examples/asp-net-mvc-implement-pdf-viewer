using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using DevExpress.Web.ASPxUploadControl;

namespace E5101.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult PdfUploadControlUpload() {
            UploadControlExtension.GetUploadedFiles("PdfUploadControl", HomeControllerPdfUploadControlSettings.ValidationSettings, HomeControllerPdfUploadControlSettings.FileUploadComplete);
            return null;
        }

        public ActionResult CallbackPanelPartial() {
            return PartialView("_CallbackPanelPartial");
        }
    }
    public class HomeControllerPdfUploadControlSettings {
        public static DevExpress.Web.ASPxUploadControl.ValidationSettings ValidationSettings = new ValidationSettings() {
            AllowedFileExtensions = new string[] { ".pdf" },
            MaxFileSize = 4194304
        };
        public static void FileUploadComplete(object sender, FileUploadCompleteEventArgs e) {
            if (e.UploadedFile.IsValid) {
                HttpContext.Current.Session[E5101.Controllers.PdfViewerController.SESSION_KEY] = e.UploadedFile.FileBytes;
            }
        }
    }

}