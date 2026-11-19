using MigraDoc.DocumentObjectModel.Fields;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.DocumentObjectModel;
using System.Collections.Generic;
using System.Windows.Forms;


namespace InvOps.Reports
{
    public class GeneradorReportes
    {
        public MigraDoc.DocumentObjectModel.Document CrearDocumento(List<DataGridView> tablas)
        {
            // Create a new MigraDoc document.
            var document = new MigraDoc.DocumentObjectModel.Document();

            // Add a section to the document.                
            var cuerpo = document.AddSection();
            var titulo = cuerpo.AddParagraph();
            titulo.Format.Font.Color = Colors.Black;
            titulo.Format.Font.Size = 16;
            titulo.AddFormattedText("INFORME GERENCIAL PARA TOMA DE DECISIONES", TextFormat.Bold);

            var primerParrafo = cuerpo.AddParagraph();
            primerParrafo.Format.Font.Color = Colors.Black;
            primerParrafo.Format.Font.Size = 12;
            string texto = "A continuación se presenta el informe culminación de " +
                "la labor de investigación efectuada, con el fin de realizar la toma " +
                "de decisiones pertinente. Cabe resaltar que para la misma actividad se implementó " +
                "la teoría de decisiones con sus multiples criterios, para tener un panorama mas claro " +
                "frente al análisis gerencial o por el personal competente.";
            primerParrafo.AddFormattedText(texto, TextFormat.NotBold);

            var subtituloContexto = cuerpo.AddParagraph();
            subtituloContexto.Format.Font.Size = 16;
            subtituloContexto.AddFormattedText("Tabla de decisiones / estado de la naturaleza - Contexto", TextFormat.Bold);

            var segundoParrafo = cuerpo.AddParagraph();
            segundoParrafo.Format.Font.Color = Colors.Black;
            segundoParrafo.Format.Font.Size = 12;
            string textoSegundoParrafo = "A continuación se relaciona la tabla de decisiones, en conjunto a sus" +
                "estados de la naturaleza, en donde el contexto es el siguiente: ";
            segundoParrafo.AddFormattedText(textoSegundoParrafo, TextFormat.NotBold);

            var tablaDecisiones = generarTablaReporte(tablas[0].ColumnCount, tablas[0].RowCount, tablas[0]);
            cuerpo.Add(tablaDecisiones);

            // Add a paragraph to the section.
            var paragraph = cuerpo.AddParagraph();

            // Set font color.
            paragraph.Format.Font.Color = Colors.DarkBlue;

            // Add some text to the paragraph.
            paragraph.AddFormattedText("Hello, World!", TextFormat.Bold);

            // Create the primary footer.
            var footer = cuerpo.Footers.Primary;

            // Add content to footer.
            paragraph = footer.AddParagraph();
            paragraph.Add(new DateField { Format = "yyyy/MM/dd HH:mm:ss" });
            paragraph.Format.Alignment = ParagraphAlignment.Center;

            // Add MigraDoc logo.
            const string imagePath = @"..\..\..\..\..\..\..\..\..\assets\migradoc\images\MigraDoc-128x128.png";
            var logo = document.LastSection.AddImage(imagePath);

            return document;
        }

        Table generarTablaReporte(int columnas, int filas, DataGridView dgv)
        {
            var tablaDecisiones = new Table();
            tablaDecisiones.Borders.Style = MigraDoc.DocumentObjectModel.BorderStyle.Single;

            //TEMPORAL - CREAR TABLA (CONFIGURANDO FILAS Y COLUMNAS)
            //SE RESALTA QUE NO SE PUEDEN AÑADIR COLUMNAS DESPUES DE CREAR FILAS, POR LO QUE POR AHORA
            //SE IMPLEMENTA UN TRIPLE BUCLE, UNO PARA CREACIÓN Y OTRO PARA LLENADO

            for (int i = 0; i < columnas + 1; i++)
            {
                tablaDecisiones.Columns.AddColumn();
            }
            for (int j = 0; j <= filas; j++)
            {
                tablaDecisiones.AddRow();
            }

            //SE LLENA LA TABLA
            for (int k = 0; k <= columnas; k++)
            {
                int k1 = k - 1;
                int k2 = k + 1;
                var filaEncabezado = tablaDecisiones.Rows[0];
                if (k != columnas)
                {
                    var cellEncabezado = filaEncabezado.Cells[k2];
                    cellEncabezado.AddParagraph(dgv.Columns[k].HeaderCell.Value.ToString());
                }

                for (int l = 0; l <= filas; l++)
                {
                    var l1 = l - 1;
                    var fila = tablaDecisiones.Rows[l];
                    var cell = fila.Cells[k];
                    if (k == 0 && l == 0)
                    {
                        cell.AddParagraph("/\\");
                    }
                    else if (k == 0 && l1 > -1)
                    {
                        cell.AddParagraph(dgv.Rows[l1].HeaderCell.Value.ToString());
                        //cell.AddParagraph(dgv.Rows[l].Cells[k].Value.ToString());
                    }
                    else if (l1 > -1)
                    {
                        cell.AddParagraph(dgv.Rows[l1].Cells[k1].Value.ToString());
                    }

                }
            }

            return tablaDecisiones;
        }
    }
}
