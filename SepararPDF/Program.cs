using System;
using PDFTools;

namespace SepararPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length != 2)
            {
                MostrarUso();
            }
            else
            {
                try
                {
                    SeparadorPdf.SepararPdf(args[0], args[1]);   
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                    MostrarUso();
                }
            }
        }

        private static void MostrarUso()
        {
            Console.WriteLine("Uso: SepararPDF.exe inputFilePath outputDir");
        }
    }
}
