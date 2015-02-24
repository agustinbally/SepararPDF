using System;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PDFTools;

namespace SepararPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get a fresh copy of the sample PDF file
            const string filename = "Recibos_2015_02.pdf";

            SeparadorPdf.SepararPdf(Path.Combine("../../pdfs/", filename), Directory.GetCurrentDirectory());
        }
    }
}
