using InvOps.Model;
using InvOps.Reports;
using InvOps.UI.Pub;
using InvOps.UI.Sub;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Quality;
using PdfSharp.Snippets.Font;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace InvOps
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        ResultadosPub resultadosPub = new ResultadosPub();
        ResultadoMaximaxSub resultadoMaximaxSub = null;
        ResultadoWaldSub resultadoWaldSub = null;
        ResultadoLaplaceSub resultadoLaplaceSub = null;
        ResultadoHurwiczSub resultadoHurwiczSub = null;        
        ResultadoValorEsperado resultadoValorEsperado = null;
        ResultadoMaximaProbabilidad resultadoMaximaProbabilidad = null;
        List<double> listaProbabilidades = new List<double>();
        private System.Drawing.Printing.PrintDocument docToPrint = new System.Drawing.Printing.PrintDocument();

        public MainForm()
        {
            InitializeComponent();
            categoriaCostoCmb.SelectedIndex = 0;
            //EN PROCESO DE CREACION DE OBSERVER PATTERN -- FUNCIONA!!
            resultadoMaximaxSub = new ResultadoMaximaxSub(ref maximaxResLabel);
            resultadoWaldSub = new ResultadoWaldSub(ref waldResLabel);
            resultadoLaplaceSub = new ResultadoLaplaceSub(ref laplaceResLabel);
            resultadoHurwiczSub = new ResultadoHurwiczSub(ref hurwiczResLabel);
            resultadoValorEsperado = new ResultadoValorEsperado(ref valorEsperadoLabel);
            resultadoMaximaProbabilidad = new ResultadoMaximaProbabilidad(ref maximaProbabilidadLabel);
            resultadosPub.Attach(resultadoMaximaxSub);
            resultadosPub.Attach(resultadoWaldSub);
            resultadosPub.Attach(resultadoLaplaceSub);
            resultadosPub.Attach(resultadoHurwiczSub);
            resultadosPub.Attach(resultadoValorEsperado);
            resultadosPub.Attach(resultadoMaximaProbabilidad);

        }

        /*RETORNAR TABLAS PARA REPORTE*/

        public List<DataGridView> ObtenerTablasReporte()
        {
            List<DataGridView> tablasParaReporte = new List<DataGridView>
            {
                costosDgv,
                decisionesDgv,
                decisionesDgvSavage,
                analisisRiesgosDgv
            };
            return tablasParaReporte;
        }



        void GenerarCostosBtnClick(object sender, EventArgs e)
        {
            try
            {
                int filas = Convert.ToInt16(this.filasCostosTxt.Text);
                int columnas = Convert.ToInt16(this.columnasCostosTxt.Text);

                if (filas == 0 || columnas == 0)
                {
                    MessageBox.Show("No se puede generar correctamente una tabla de Costos / Rentabilidad con valores en Cero");
                    return;
                }            
                GeneradorResultados.GenerarCostos(costosDgv, TipoTabla.Costos, filas, columnas);
                GeneradorResultados.GenerarCostos(decisionesDgv, TipoTabla.Decisiones, filas, columnas);
                GeneradorResultados.GenerarCostos(decisionesDgvSavage, TipoTabla.Savage, filas, columnas);
                GeneradorResultados.GenerarCostos(analisisRiesgosDgv, TipoTabla.AnalisisRiesgo, filas, columnas);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        void CalcularBtnClick(object sender, EventArgs e)
        {

            try
            {
                if (costosDgv.Rows.Count == 0 || costosDgv.Columns.Count == 0)
                {
                    MessageBox.Show("No se puede realizar el calculo sin generar correctamente una tabla de Costos / Rentabilidad");
                    return;
                }

                //LIMPIA CONTENIDO DE TABLAS, NECESARIA PARA EVITAR ERRORES DE CALCULO
                LimpiarTabla(decisionesDgvSavage);
                //-------------------------------------------------------

                int filas = costosDgv.Rows.Count;
                int columnas = costosDgv.Columns.Count;
                int columnasSavage = decisionesDgvSavage.Columns.Count;
                List<double> valores = new List<double>();
                List<double> costos = new List<double>();
                List<double> costosLaplace = new List<double>();
                List<double> costosHurwicz = new List<double>();
                List<double> costosSavage = new List<double>();

                bool esRentabilidad = (categoriaCostoCmb.SelectedIndex == 1) ? true : false;
                double alfaHurwicz = double.Parse(alfaHurwiczTxt.Text);

                GeneradorResultados.GenerarResultadosSavage(decisionesDgvSavage, costosDgv, esRentabilidad, filas, columnasSavage);
                GeneradorResultados.GenerarResultadosDecisiones(costosDgv, decisionesDgv, esRentabilidad, alfaHurwicz, filas, columnas, resultadosPub);
                GeneradorResultados.GenerarResultadosAnalisisRiesgo(costosDgv, analisisRiesgosDgv, listaProbabilidades, esRentabilidad, filas, columnas, resultadosPub);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


        }


        void LimpiarTabla(DataGridView tabla)
        {
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                for (int j = 0; j < tabla.Columns.Count; j++)
                {
                    tabla.Rows[i].Cells[j].Value = null;
                }
            }
        }

        void FilasCostosTxtKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void ColumnasCostosTxtKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void CostosDgvCellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void costosDgv_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            string valor = ((string)costosDgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == null ? "" : (string)costosDgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            bool esLetra = valor.All(char.IsLetter);
            if (esLetra)
            {
                costosDgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";

            }
        }

        private void alfaHurwiczTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void probabilidadesBtn_Click(object sender, EventArgs e)
        {
            int filasTxt = Convert.ToInt16(this.filasCostosTxt.Text);
            int columnasTxt = Convert.ToInt16(this.columnasCostosTxt.Text);

            if (filasTxt == 0 || columnasTxt == 0)
            {
                MessageBox.Show("No se puede asignar probabilidades sino se genera la tabla de registros de decisiones");
                return;
            }

            int columnas = costosDgv.Columns.Count;
            int ultimaPosicionY = 32 * (columnas + 1);

            Form probabilidadesFrm = new Form
            {
                StartPosition = FormStartPosition.CenterParent,
                Text = "Asignar probabilidades",
                Width = 260,
                Height = 50 * (columnas + 1),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MinimizeBox = false,
                MaximizeBox = false
            };

            Button asignarProbabilidadesBtn = new Button { Text = "Aceptar", Name = "asignarProbabilidadesBtn", Location = new Point(20, ultimaPosicionY) };
            for (int i = 0; i < columnas; i++)
            {
                string textoLabel = "Probabilidad Decisión " + i.ToString() + ":";
                string nombreTextBox = "valorProbabilidad" + i.ToString() + "Txt";
                probabilidadesFrm.Controls.Add(new Label { Text = textoLabel, Location = new Point(20, 32 * (i + 1)), Size = new Size(160, 23) });
                probabilidadesFrm.Controls.Add(new TextBox { Name = nombreTextBox, Location = new Point(180, 30 * (i + 1)), TabIndex = i + 1, Size = new Size(40, 23) });
            }
            asignarProbabilidadesBtn.Click += new EventHandler(asignarProbabilidadesBtn_Click);
            probabilidadesFrm.Controls.Add(asignarProbabilidadesBtn);
            probabilidadesFrm.ShowDialog();
        }

        private void asignarProbabilidadesBtn_Click(object sender, EventArgs e)
        {
            //foreach(TextBox txt in sender)
            listaProbabilidades.Clear();
            Form parent = ((Button)sender).Parent as Form;
            for (int i = 0; i < parent.Controls.Count; i++)
            {
                if (parent.Controls[i].GetType() == typeof(TextBox))
                {
                    listaProbabilidades.Add(Convert.ToDouble(parent.Controls[i].Text));
                }
            }
            parent.Close();

        }

        private void ImprimirTsmi_Click(object sender, EventArgs e)
        {

            // NET6FIX - will be removed
            if (PdfSharp.Capabilities.Build.IsCoreBuild && GlobalFontSettings.FontResolver == null)
                GlobalFontSettings.FontResolver = new FailsafeFontResolver();
            GeneradorReportes generadorReportes = new GeneradorReportes();
            // Create a MigraDoc document.
            var document = generadorReportes.CrearDocumento(ObtenerTablasReporte());

            var style = document.Styles[StyleNames.Normal]!;
            style.Font.Name = "Arial";

            // Create a renderer for the MigraDoc document.
            var pdfRenderer = new PdfDocumentRenderer
            {
                // Associate the MigraDoc document with a renderer.
                Document = document,
                PdfDocument = new PdfDocument()
            };

            // Layout and render document to PDF.
            pdfRenderer.RenderDocument();

            // Save the document...
            var filename = IOHelper.CreateTemporaryPdfFileName("HelloWorldMigraDoc");
            pdfRenderer.PdfDocument.Save(filename);
            // ...and start a viewer.
            Process.Start(new ProcessStartInfo(filename) { UseShellExecute = true });

            // Creates a minimalistic document.


        }


    }
}
