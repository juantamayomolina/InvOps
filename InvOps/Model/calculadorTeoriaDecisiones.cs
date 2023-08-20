/*
 * Created by SharpDevelop.
 * User: Juan
 * Date: 28/01/2023
 * Time: 12:46 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace InvOps.Model
{
	/// <summary>
	/// Description of calculadorMaximin.
	/// </summary>
	public static class calculadorTeoriaDecisiones
	{
		public static double calcularMaximax(List<double> valores){
			valores.Sort();
			valores.Reverse();
			return valores[0];
		}
		
		public static double calcularMinimin(List<double> valores){
			valores.Sort();			
			return valores[0];
		}
		/*tener en cuenta que wald equivale a lo peor de lo mejor*/
		public static double calcularWald(List<double> valores, bool esRentabilidad)
		{
			if (esRentabilidad)
			{
				valores.Sort();				
			}
			else
			{
				valores.Sort();
				valores.Reverse();
			}

			return valores[0];
		}

		public static double calcularLaplace(List<double> valores, bool esRentabilidad)
		{
            if (esRentabilidad)
            {
				valores.Sort();
				valores.Reverse();
			}
            else
            {
				valores.Sort();
			}
			
			
			return valores[0];
		}

		public static double calcularValorHurwicz(double alfaHurwicz, double valorMinimo, double valorMaximo)
		{
			return ((alfaHurwicz * valorMinimo)) + (1 - alfaHurwicz) * valorMaximo;

        }

		public static double calcularHurwicz(List<double> valores, bool esRentabilidad)
		{
			if (esRentabilidad)
			{
				valores.Sort();
				valores.Reverse();
			}
			else
			{
				valores.Sort();
			}


			return valores[0];
		}

		public static double calcularSavage(List<double> valores, bool esRentabilidad)
        {
            if (esRentabilidad)
            {
                valores.Sort();
                valores.Reverse();
            }
            else
            {
                valores.Sort();
            }


            return valores[0];
        }
    }
}
