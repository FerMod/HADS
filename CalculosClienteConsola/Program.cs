using System;
using System.Collections.Generic;
using System.Linq;
using CalculosLib;
using CalculosLib.Iva;

namespace CalculosClienteConsola {

	class Program {

		static void Main(string[] args) {

			double total = 0.0;
			TipoIva tipoIva;

			total = GetUserInputTotalValue();
			Console.WriteLine();
			tipoIva = GetUserInputTipoIvaValue();

			double totalSinIva = CalculoIva.ObtenerPrecioBruto(total, tipoIva);
			double iva = CalculoIva.ObtenerPrecioIva(total, tipoIva);

			Console.WriteLine();
			Console.WriteLine($"Total sin IVA: {totalSinIva}");
			Console.WriteLine($"IVA: {iva}");
			Console.WriteLine();

			Console.WriteLine("Pulse cualquier tecla para salir...");
			Console.ReadKey(true);

		}

		private static double GetUserInputTotalValue() {

			bool error = false;
			double total = 0.0;

			do {

				Console.WriteLine("Introduzca precio total: ");
				Console.Write("> ");
				if(!double.TryParse(Console.ReadLine(), out total)) {
					error = true;
					Console.WriteLine("\nEl valor introducido no es valido.");
				} else {
					error = false;
				}

			} while(error);

			return total;

		}

		private static TipoIva GetUserInputTipoIvaValue() {

			bool error = false;
			TipoIva tipoIva = TipoIva.Ninguno;

			List<TipoIva> tipoIvaList = Enum.GetValues(typeof(TipoIva)).Cast<TipoIva>().ToList();
			int size = tipoIvaList.Count();
			Console.WriteLine("Tipos de IVA: ");
			for(int i = 0; i < size; i++) {
				Console.WriteLine($"{i} - {tipoIvaList[i].GetName()}");
			}
			Console.WriteLine();

			do {

				Console.WriteLine("Seleccione tipo de IVA:");
				Console.Write("> ");
				if(!int.TryParse(Console.ReadLine(), out int seleccionTipoIva)) {
					error = true;
					Console.WriteLine("\nEl valor introducido no es valido.");
				} else if(seleccionTipoIva < 0 || seleccionTipoIva > size) {
					error = true;
					Console.WriteLine("\nSeleccion no valida.");
				} else {
					error = false;
					tipoIva = (TipoIva)Enum.ToObject(typeof(TipoIva), seleccionTipoIva);
				}

			} while(error);

			return tipoIva;
		}
	}

}
