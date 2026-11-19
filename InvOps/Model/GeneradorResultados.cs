using InvOps.UI.Pub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvOps.Model
{
    public class GeneradorResultados
    {
        public static void GenerarCostos(DataGridView dgv, TipoTabla elem, int filas = 0, int columnas = 0)
        {
            int[,] costos = new int[filas, columnas];

            switch (elem)
            {
                case TipoTabla.Costos:
                    dgv.Rows.Clear();
                    dgv.Columns.Clear();
                    for (int i = 1; i <= columnas; i++)
                    {
                        dgv.Columns.Add("E" + i, "E" + i);
                    }

                    dgv.Rows.Add(filas);

                    for (int i = 0; i < filas; i++)
                    {
                        dgv.Rows[i].HeaderCell.Value = "D" + (i + 1);
                    }
                    break;

                case TipoTabla.Decisiones:
                    dgv.Rows.Clear();
                    dgv.Columns.Clear();
                    dgv.Columns.Add("MAXIMAX/MINIMIN", "MAXIMAX");
                    dgv.Columns.Add("WALD", "WALD");
                    dgv.Columns.Add("LAPLACE", "LAPLACE");
                    dgv.Columns.Add("HURWICZ", "HURWICZ");
                    dgv.Rows.Add(filas + 1);
                    break;

                case TipoTabla.Savage:
                    dgv.Rows.Clear();
                    dgv.Columns.Clear();
                    for (int i = 1; i <= columnas; i++)
                    {
                        dgv.Columns.Add("E" + i, "E" + i);
                    }
                    dgv.Columns.Add("RESULTADO DECISION", "RESULTADO DECISION");
                    dgv.Rows.Add(filas + 1);
                    break;

                case TipoTabla.AnalisisRiesgo:
                    dgv.Rows.Clear();
                    dgv.Columns.Clear();
                    dgv.Columns.Add("VALOR ESPERADO", "VALOR ESPERADO");
                    dgv.Columns.Add("MAXIMA PROBABILIDAD", "MAXIMA PROBABILIDAD");
                    dgv.Rows.Add(filas);
                    break;

                default:
                    break;
            }
        }

        public static void GenerarResultadosDecisiones(DataGridView costosDgv, DataGridView dgv, bool esRentabilidad, double alfaHurwicz, int filas = 0, int columnas = 0, ResultadosPub resultadosPub = null)
        {
            List<double> valores = new List<double>();
            List<double> costos = new List<double>();
            List<double> costosWald = new List<double>();
            List<double> costosLaplace = new List<double>();
            List<double> costosHurwicz = new List<double>();
            double[,] tablaDecisiones = ObtenerDatosDecisionesDgv(costosDgv, filas, columnas);
            for (int i = 0; i < tablaDecisiones.GetLength(0); i++)
            {
                double valorFinal = 0;
                double valorHurwicz;

                for (int j = 0; j < tablaDecisiones.GetLength(1); j++)
                {
                    //SE OBTIENE EL VALOR DE LA CELDA ACTUAL Y SE GENERA LA LISTA DE VALORES DE LAS COLUMNAS CORRESPONDIENTES A ESTADOS DE LA NATURALEZA
                    double valor = tablaDecisiones[i, j];
                    valores.Add(valor);

                    //CALCULO VALORES LAPLACE					
                    valorFinal += valor;
                }
                valores.Sort();

                if (esRentabilidad)
                {
                    valores.Reverse();
                }
                List<double> valoresFinal = valores.GetRange(0, valores.Count);
                List<double> valoresWald = valores.GetRange(0, valores.Count);
                valoresWald.Reverse();

                //CALCULO VALORES HURWICZ
                //valorHurwicz = ((alfaHurwicz * valores[0])) + (1 - alfaHurwicz) * valores[valores.Count - 1];
                valorHurwicz = calculadorTeoriaDecisiones.calcularValorHurwicz(alfaHurwicz, valoresFinal[0], valoresFinal[valores.Count - 1]);

                costos.Add(valoresFinal[0]);
                costosWald.Add(valoresWald[0]);
                costosLaplace.Add(valorFinal / valores.Count);
                costosHurwicz.Add(valorHurwicz);
                dgv.Rows[i].Cells[0].Value = Math.Round(valoresFinal[0], 3);
                dgv.Rows[i].Cells[1].Value = Math.Round(valoresWald[0], 3);
                dgv.Rows[i].Cells[2].Value = Math.Round(valorFinal / valores.Count, 3);
                dgv.Rows[i].Cells[3].Value = Math.Round(valorHurwicz, 3);

                //SE REVERSA nuevamente LA LISTA DE WALD, PARA PODER PASARLA A LA FUNCION DE CALCULAR WALD
                valoresWald.Reverse();

                //SE LIMPIA LA LISTA DE VALORES PARA LA SIGUIENTE ITERACIÒN.
                valores.Clear();
            }


            int ultimaFila = dgv.Rows.Count - 1;
            double resMaximax = (esRentabilidad) ? calculadorTeoriaDecisiones.calcularMaximax(costos) : calculadorTeoriaDecisiones.calcularMinimin(costos);
            double resWald = (esRentabilidad) ? calculadorTeoriaDecisiones.calcularWald(costosWald, true) : calculadorTeoriaDecisiones.calcularWald(costosWald, false);
            double resLaplace = (esRentabilidad) ? calculadorTeoriaDecisiones.calcularLaplace(costosLaplace, true) : calculadorTeoriaDecisiones.calcularLaplace(costosLaplace, false);
            double resHurwicz = (esRentabilidad) ? calculadorTeoriaDecisiones.calcularHurwicz(costosHurwicz, true) : calculadorTeoriaDecisiones.calcularHurwicz(costosHurwicz, false); ;
            dgv.Rows[ultimaFila].Cells[0].Value = Math.Round(resMaximax, 3);
            dgv.Rows[ultimaFila].Cells[1].Value = Math.Round(resWald);
            dgv.Rows[ultimaFila].Cells[2].Value = Math.Round(resLaplace);
            dgv.Rows[ultimaFila].Cells[3].Value = Math.Round(resHurwicz);
            dgv.Rows[ultimaFila].HeaderCell.Value = "RESULTADO";
            if (resultadosPub != null)
            {
                resultadosPub.ActualizarResultado("Maximax", resMaximax, DeterminarDecision(tablaDecisiones, resMaximax));
                resultadosPub.ActualizarResultado("Wald", resWald, DeterminarDecision(tablaDecisiones, resWald));
                resultadosPub.ActualizarResultado("Laplace", resLaplace, DeterminarDecision(tablaDecisiones, resLaplace));
                resultadosPub.ActualizarResultado("Hurwicz", resHurwicz, DeterminarDecision(tablaDecisiones, resHurwicz));
                resultadosPub.Notify();
            }
        }

        public static void GenerarResultadosSavage(DataGridView dgv, DataGridView costosDgv, bool esRentabilidad, int filas = 0, int columnas = 0)
        {
            List<double> valores = new List<double>();
            List<double> costos = new List<double>();

            /*ESTE BLOQUE CORRESPONDE AL CALCULO SAVAGE, TENIENDO EN CUENTA QUE EL PROCESAMIENTO DE ESTA SE REALIZA 
             CALCULANDO EL VALOR ABSOLUTO DEL VALOR (MIN / MAX DEPENDIENDO DE SI ES RENTABILIDAD O COSTO) DE CADA DECISIÓN
            Y POR ULTIMO SE RESTA EL VALOR DE CADA CELDA

             POR LO ANTERIOR, SE DESIGNÓ UNA TABLA SOLO PARA PROYECCIÓN Y CALCULO DE SAVAGE*/

            for (int a = 0; a < columnas; a++)
            {
                if (a < columnas - 1)
                {
                    for (int c = 0; c < filas; c++)
                    {
                        //DETERMINAR TAMAÑO LISTA COSTOS SAVAGE
                        if (costos.Count < filas)
                        {
                            costos.Add(0);
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
                                dgv.Rows[c].Cells[a].Value = valorSavage;

                                /*RESULTADO PARCIAL ULTIMA COLUMNA, SE CALCULA TOMANDO EL VALOR MAXIMO DE LA FILA ACTUAL
                                SE UTILIZA ESTE METODO PARA EVITAR TENER QUE ITERAR SOBRE TODA LA TABLA NUEVAMENTE*/

                                double ultColumna = (dgv.Rows[c].Cells[columnas - 1].Value == null) ? -1 : (double)dgv.Rows[c].Cells[columnas - 1].Value;
                                if (ultColumna < valorSavage)
                                {
                                    dgv.Rows[c].Cells[columnas - 1].Value = valorSavage;

                                }

                                //--------------------------------

                                valores.Clear();
                            }
                        }
                        costos[c] = (double)dgv.Rows[c].Cells[columnas - 1].Value;
                    }
                }
                valores.Clear();
            }
            int ultimaFila = dgv.Rows.Count - 1;
            dgv.Rows[ultimaFila].Cells[dgv.Columns.Count - 1].Value = (esRentabilidad) ? calculadorTeoriaDecisiones.calcularSavage(costos, true) : calculadorTeoriaDecisiones.calcularSavage(costos, false);
            dgv.Rows[ultimaFila].HeaderCell.Value = "RESULTADO";
        }

        public static void GenerarResultadosAnalisisRiesgo(DataGridView costosDgv, DataGridView dgv, List<double> probabilidades, bool esRentabilidad, int filas = 0, int columnas = 0, ResultadosPub resultadosPub = null)
        {
            List<double> valores = new List<double>();
            List<double> costos = new List<double>();
            List<double> costosMaximaProbabilidad = new List<double>();
            double[,] tablaDecisiones = ObtenerDatosDecisionesDgv(costosDgv, filas, columnas);
            double valorProbabilidadMasAlta = 0.0;
            double valorMaximaProbabilidad = 0.0;
            int indiceMaximaProbabilidad = 0;
            for (int i = 0; i < tablaDecisiones.GetLength(0); i++)
            {
                double valorFinal = 0;

                for (int j = 0; j < tablaDecisiones.GetLength(1); j++)
                {
                    //SE OBTIENE EL VALOR DE LA CELDA ACTUAL Y SE GENERA LA LISTA DE VALORES DE LAS COLUMNAS CORRESPONDIENTES A ESTADOS DE LA NATURALEZA
                    double valor = tablaDecisiones[i, j] * probabilidades[j];

                    //SE OBTIENE LA PROBABILIDAD MAS ALTA (CALCULO MAXIMA PROBABILIDAD)
                    if (valorProbabilidadMasAlta < probabilidades[j])
                    {
                        valorProbabilidadMasAlta = probabilidades[j];
                        indiceMaximaProbabilidad = j;
                    }

                    //CALCULO VALOR ESPERADO			
                    valorFinal += valor;
                }

                //TEMPORAL - PARA EVITAR QUE SE ASIGNE UN NUEVO VALOR EN ITERACIONES POSTERIORES, CON UNA ITERACION ES SUFICIENTE
                //PARA OBTENER EL INDICE DE LA PROBABILIDAD MAS ALTA
                valorProbabilidadMasAlta = Double.MaxValue;

                //SE OBTIENE DIRECTAMENTE EL VALOR DE LA TABLA DE DECISIONES, PUES YA SE CUENTA CON EL INDICE DEL
                //ESTADO DE LA NATURALEZA
                valorMaximaProbabilidad = tablaDecisiones[i, indiceMaximaProbabilidad];
                costosMaximaProbabilidad.Add(valorMaximaProbabilidad);
                dgv.Rows[i].Cells[1].Value = valorMaximaProbabilidad;

                //SE PROCESA LA INFORMACIÓN PARA EL CRITERIO DE VALOR ESPERADO
                costos.Add(valorFinal);
                dgv.Rows[i].Cells[0].Value = valorFinal;

                //SE LIMPIA LA LISTA DE VALORES PARA LA SIGUIENTE ITERACIÒN.
                valores.Clear();
            }

            int ultimaFila = dgv.Rows.Count - 1;
            double resValorEsperado = (esRentabilidad) ? calculadorTeoriaDecisiones.calcularValorEsperado(costos, true) : calculadorTeoriaDecisiones.calcularValorEsperado(costos, false);
            double resMaximaProbabilidad = (esRentabilidad) ? calculadorTeoriaDecisiones.calcularMaximaProbabilidad(costosMaximaProbabilidad, true) : calculadorTeoriaDecisiones.calcularMaximaProbabilidad(costosMaximaProbabilidad, false);
            dgv.Rows[ultimaFila].Cells[0].Value = resValorEsperado;
            dgv.Rows[ultimaFila].Cells[1].Value = resMaximaProbabilidad;
            dgv.Rows[ultimaFila].HeaderCell.Value = "RES";
            if (resultadosPub != null)
            {
                resultadosPub.ActualizarResultado("ValorEsperado", resValorEsperado, DeterminarDecision(costos, resValorEsperado, 0));
                resultadosPub.ActualizarResultado("MaximaProbabilidad", resMaximaProbabilidad, DeterminarDecision(costosMaximaProbabilidad, resMaximaProbabilidad, indiceMaximaProbabilidad + 1));
                resultadosPub.Notify();
            }

        }

        private static double[,] ObtenerDatosDecisionesDgv(DataGridView dgv, int filas, int columnas)
        {
            double[,] tablaDecisiones = new double[filas, columnas];
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    //SE OBTIENE EL VALOR DE LA CELDA ACTUAL Y SE GENERA LA LISTA DE VALORES DE LAS COLUMNAS CORRESPONDIENTES A ESTADOS DE LA NATURALEZA
                    double valor = Convert.ToDouble(dgv.Rows[i].Cells[j].Value);

                    /*SE CREA UN ARREGLO BIDIMENSIONAL PARA ALMACENAR EL VALOR DE LA CELDA CON SU DECISION Y ESTADO DE LA NATURALEZA CORRESPONDIENTE
                     BASICAMENTE, SE REPLICA EL CONTENIDO DE LA TABLA EN UN ARREGLO, SIN LAS CELDAS DE RESULTADO*/
                    tablaDecisiones[i, j] = valor;
                }
            }
            return tablaDecisiones;
        }

        private static string DeterminarDecision(double[,] tabla, double valor)
        {
            /*CORRECCION DE LOGICA: SE RETIRA CAMPO DE COLUMNA DEBIDO A QUE SE DEBE DE RECORRER LA TABLA EN SU TOTALIDAD PARA
             DETERMINAR LA DECISIÓN CORRECTA DE ACUERDO AL VALOR PRESENTE EN LA TABLA DE DECISIONES / ESTADOS DE LA NATURALEZA*/
            string resultado = "";
            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    if (tabla[i, j] == valor)
                    {
                        resultado += "Decisión " + (i + 1).ToString() + " Estado " + (j + 1).ToString() + "; ";
                    }
                }
            }
            return resultado;
        }

        private static string DeterminarDecision(List<double> valores, double valor, int estado)
        {
            /*ALTERNATIVA A AQUELLAS DECISIONES QUE SE TOMAN SOBRE UNA COLUMNA INDIVIDUAL- ANALISIS DE RIESGO*/
            string resultado = "";
            for (int i = 0; i < valores.Count; i++)
            {
                if (valores[i] == valor)
                {
                    resultado += "Decisión " + (i + 1).ToString() + " Estado " + (estado).ToString() + "; ";
                }
            }
            return resultado;
        }
    }
}
