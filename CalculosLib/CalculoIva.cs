﻿
using CalculosDinero.Iva;

namespace CalculosDinero {

	public static class CalculoIva {

		public static double ObtenerPrecioBruto(double total, TipoIva tipoIva) {
			return (total != 0) ? (total / (tipoIva.Value() + 1)) : 0;
		}

		public static double ObtenerPrecioIva(double total, TipoIva tipoIva) {
			return total - ObtenerPrecioBruto(total, tipoIva);
		}


	}

}