using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using PDFTools;
using SeparadorPdfApp.Properties;

namespace SeparadorPdfApp
{
    public partial class FormSepararPdf : Form
    {
        public FormSepararPdf()
        {
            InitializeComponent();
        }

        private void btnDirectory_Click(object sender, EventArgs e)
        {
            var inputDirectory = GetInputDirectory();

            var fld = new FolderBrowserDialog
            {
                ShowNewFolderButton = true,
                SelectedPath = inputDirectory
            };

            if (fld.ShowDialog() == DialogResult.OK)
            {
                txtDirectory.Text = fld.SelectedPath;
            }
        }

        private string GetInputDirectory()
        {
            return File.Exists(txtInputFile.Text)
                ? Path.GetDirectoryName(txtInputFile.Text)
                : string.Empty ;
        }

        private void btnInputFile_Click(object sender, EventArgs e)
        {
            var opf = new OpenFileDialog { Multiselect = false };

            if (opf.ShowDialog() == DialogResult.OK)
            {
                txtInputFile.Text = opf.FileName;
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                SeparadorPdf.SepararPdf(txtInputFile.Text, txtDirectory.Text);
                MessageBox.Show(this, Resources.ProcesoCorrecto, Resources.NombreApp, MessageBoxButtons.OK);
                Process.Start(txtDirectory.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Resources.Generar_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
    }
}
