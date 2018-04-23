using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;
using DevExpress.Pdf;
using System.Drawing.Imaging;

namespace E5101.Models {
    public class PdfPageModel {
        PdfDocumentProcessor _documentProcessor;

        public PdfPageModel(PdfDocumentProcessor documentProcessor) {
            this._documentProcessor = documentProcessor;
        }

        public PdfDocumentProcessor DocumentProcessor {
            get {
                return _documentProcessor;
            }
        }

        public int PageNumber {
            get;
            set;
        }

        public byte[] GetPageImageBytes() {
            using (Bitmap bitmap = DocumentProcessor.CreateBitmap(PageNumber, 900)) {
                using (MemoryStream stream = new MemoryStream()) {
                    bitmap.Save(stream, ImageFormat.Png);
                    return stream.ToArray();
                }
            }
        }
    }
}