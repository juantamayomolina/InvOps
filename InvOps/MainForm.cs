/*
 * Created by SharpDevelop.
 * User: Juan
 * Date: 27/01/2023
 * Time: 4:38 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using InvOps.Model;
using System.Linq;
using System.Windows.Forms.VisualStyles;

namespace InvOps
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			decisionesDgv.Columns.Add("MAXIMAX/MINIMIN", "MAXIMAX/MINIMIN");
			decisionesDgv.Columns.Add("WALD", "WALD");
			decisionesDgv.Columns.Add("LAPLACE", "LAPLACE");
			decisionesDgv.Columns.Add("HURWICZ","HURWICZ");
			categoriaCostoCmb.SelectedIndex = 0;

		}
		
		void GenerarCostosBtnClick(object sender, EventArgs e)
		{
			int filas = Convert.ToInt16(this.filasCostosTxt.Text);
			int columnas = Convert.ToInt16(this.columnasCostosTxt.Text);
			
			if(filas == 0 || columnas == 0){
				MessageBox.Show("No se puede generar correctamente una tabla de Costos / Rentabilidad con valores en Cero");
				return;
			}
			
			int[,] costos = new int[filas,columnas];
			costosDgv.Rows.Clear();
			costosDgv.Columns.Clear();
			decisionesDgv.Rows.Clear();
            decisionesDgvSavage.Rows.Clear();
            decisionesDgvSavage.Columns.Clear();

            for (int i = 1; i <= columnas; i++){
				costosDgv.Columns.Add("E"+i, "E"+i);
                decisionesDgvSavage.Columns.Add("E" + i, "E" + i);
            }
			costosDgv.Rows.Add(filas);
			for(int i = 0; i < filas; i++){
				costosDgv.Rows[i].HeaderCell.Value = "D"+(i+1);
			}

            decisionesDgv.Rows.Add(filas+1);
            //SE AÑADE UNA COLUMNA A SAVAGE PARA CALCULOS POR FILA DE CADA DECISION
            decisionesDgvSavage.Columns.Add("RESULTADO DECISION", "RESULTADO DECISION");
            decisionesDgvSavage.Rows.Add(filas + 1);

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
                limpiarTabla(decisionesDgvSavage);
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

                /*ESTE BLOQUE CORRESPONDE AL CALCULO SAVAGE, TENIENDO EN CUENTA QUE EL PROCESAMIENTO DE ESTA SE REALIZA 
				 CALCULANDO EL VALOR ABSOLUTO DEL VALOR (MIN / MAX DEPENDIENDO DE SI ES RENTABILIDAD O COSTO) DE CADA DECISIÓN
				Y POR ULTIMO SE RESTA EL VALOR DE CADA CELDA
				
				 POR LO ANTERIOR, SE DESIGNÓ UNA TABLA SOLO PARA PROYECCIÓN Y CALCULO DE SAVAGE*/

				for(int a = 0; a < columnasSavage; a++)
				{
                    if (a < columnasSavage - 1)
                    {
                        for (int c = 0; c < filas; c++)
                        {
                            //DETERMINAR TAMAÑO LISTA COSTOS SAVAGE
                            if (costosSavage.Count < filas)
                            {
                                costosSavage.Add(0);
                            }
                            //-------------------------------------
                            for (int b = 0; b < filas; b++)
                            {
                                //SE OBTIENE EL VALOR DE LA CELDA ACTUAL Y SE GENERA LA LISTA DE VALORES DE LAS COLUMNAS CORRESPONDIENTES A ESTADOS DE LA NATURALEZA
                                double valor = Convert.ToDouble(costosDgv.Rows[b].Cells[a].Value);
                                valores.Add(valor);

                                if (b == filas - 1)
                                {
                                    //SE HACE USO DE ESTA VARIABLE PUES SE DEBE TOMAR EL ELEMENTO O VALOR SIN MODIFICACIONES POSTERIORES
                                    double celdaActual = valores[c];
                                    valores.Sort();

                                    if (esRentabilidad)
                                    {
                                        valores.Reverse();

                                    }
                                    double valorSavage = Math.Abs(valores[0] - celdaActual);
                                    decisionesDgvSavage.Rows[c].Cells[a].Value = valorSavage;

                                    /*RESULTADO PARCIAL ULTIMA COLUMNA, SE CALCULA TOMANDO EL VALOR MAXIMO DE LA FILA ACTUAL
                                    SE UTILIZA ESTE METODO PARA EVITAR TENER QUE ITERAR SOBRE TODA LA TABLA NUEVAMENTE*/

                                    double ultColumna = (decisionesDgvSavage.Rows[c].Cells[columnasSavage - 1].Value == null) ? -1 : (double)decisionesDgvSavage.Rows[c].Cells[columnasSavage - 1].Value;
                                    if (ultColumna < valorSavage)
                                    {
                                        decisionesDgvSavage.Rows[c].Cells[columnasSavage - 1].Value = valorSavage;

                                    }

                                    //--------------------------------

                                    valores.Clear();
                                }
                            }
                            costosSavage[c] = (double)decisionesDgvSavage.Rows[c].Cells[columnasSavage - 1].Value;
//costosSavage.Add((double)decisionesDgvSavage.Rows[c].Cells[columnasSavage - 1].Value);
                        }
                        
                    }
                    

                    valores.Clear();
                }
				valores.Clear();
				//-------------------------------------------------------------------------------

                for (int i = 0; i < filas; i++)
                {
                    double valorFinal = 0;
                    double valorHurwicz;

                    for (int j = 0; j < columnas; j++)
                    {
						//SE OBTIENE EL VALOR DE LA CELDA ACTUAL Y SE GENERA LA LISTA DE VALORES DE LAS COLUMNAS CORRESPONDIENTES A ESTADOS DE LA NATURALEZA
                        double valor = Convert.ToDouble(costosDgv.Rows[i].Cells[j].Value);
                        valores.Add(valor);

                        //CALCULO VALORES LAPLACE					
                        valorFinal += valor;
                    }
                    valores.Sort();

                    if (esRentabilidad)
                    {
                        valores.Reverse();

                    }

                    //CALCULO VALORES HURWICZ
                    //valorHurwicz = ((alfaHurwicz * valores[0])) + (1 - alfaHurwicz) * valores[valores.Count - 1];
					valorHurwicz = calculadorTeoriaDecisiones.calcularValorHurwicz(alfaHurwicz, valores[0], valores[valores.Count - 1]);

                    costos.Add(valores[0]);
                    costosLaplace.Add(valorFinal / valores.Count);
                    costosHurwicz.Add(valorHurwicz);
                    decisionesDgv.Rows[i].Cells[0].Value = valores[0];
                    decisionesDgv.Rows[i].Cells[1].Value = valores[0];
                    decisionesDgv.Rows[i].Cells[2].Value = valorFinal / valores.Count;
                    decisionesDgv.Rows[i].Cells[3].Value = valorHurwicz;

					//SE LIMPIA LA LISTA DE VALORES PARA LA SIGUIENTE ITERACIÒN.
                    valores.Clear();
                }


                int ultimaFila = decisionesDgv.Rows.Count - 1;
                decisionesDgv.Rows[ultimaFila].Cells[0].Value = (esRentabilidad) ? calculadorTeoriaDecisiones.calcularMaximax(costos) : calculadorTeoriaDecisiones.calcularMinimin(costos);
                decisionesDgv.Rows[ultimaFila].Cells[1].Value = (esRentabilidad) ? calculadorTeoriaDecisiones.calcularWald(costos, true) : calculadorTeoriaDecisiones.calcularWald(costos, false);
                decisionesDgv.Rows[ultimaFila].Cells[2].Value = (esRentabilidad) ? calculadorTeoriaDecisiones.calcularLaplace(costosLaplace, true) : calculadorTeoriaDecisiones.calcularLaplace(costosLaplace, false);
                decisionesDgv.Rows[ultimaFila].Cells[3].Value = (esRentabilidad) ? calculadorTeoriaDecisiones.calcularHurwicz(costosHurwicz, true) : calculadorTeoriaDecisiones.calcularHurwicz(costosHurwicz, false);                
                decisionesDgv.Rows[ultimaFila].HeaderCell.Value = "RESULTADO";
                decisionesDgvSavage.Rows[ultimaFila].Cells[decisionesDgvSavage.Columns.Count -1].Value = (esRentabilidad) ? calculadorTeoriaDecisiones.calcularSavage(costosSavage, true) : calculadorTeoriaDecisiones.calcularSavage(costosSavage, false);
                decisionesDgvSavage.Rows[ultimaFila].HeaderCell.Value = "RESULTADO";
            }
			catch(Exception ex) { MessageBox.Show(ex.Message); }
			
			
		}

        void limpiarTabla(DataGridView tabla)
        {
            for(int i = 0; i < tabla.Rows.Count; i++)
            {
                for(int j = 0; j < tabla.Columns.Count; j++)
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
    }
}
