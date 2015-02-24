using System;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace PDFTools
{
    public class SeparadorPdf
    {
        public static void SepararPdf(string fileInputFullName, string directoryOutput)
        {
            if (!File.Exists(fileInputFullName))
            {
                throw new Exception(string.Format("No existe el archio {0}.", fileInputFullName));
            }

            if (!Directory.Exists(directoryOutput))
            {
                throw new Exception(string.Format("No existe el directorio {0}.", directoryOutput));
            }

            // Get a fresh copy of the sample PDF file
            var filename = Path.GetFileName(fileInputFullName);
            File.Copy(fileInputFullName, Path.Combine(Directory.GetCurrentDirectory(), filename), true);

            // Open the file
            var inputDocument = PdfReader.Open(filename, PdfDocumentOpenMode.Import);

            var name = Path.GetFileNameWithoutExtension(filename);
            for (var idx = 0; idx < inputDocument.PageCount; idx++)
            {
                // Create new document
                var outputDocument = new PdfDocument { Version = inputDocument.Version };
                outputDocument.Info.Title = String.Format("Page {0} of {1}", idx + 1, inputDocument.Info.Title);
                outputDocument.Info.Creator = inputDocument.Info.Creator;

                // Add the page and save it
                outputDocument.AddPage(inputDocument.Pages[idx]);

                var newFileName = String.Format("{0} - Page {1}.pdf", name, idx + 1);   
                outputDocument.Save(Path.Combine(directoryOutput, newFileName));
            }

            File.Delete(filename);
        }
    }
}
