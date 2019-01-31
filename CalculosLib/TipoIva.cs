
namespace CalculosDinero.Iva {

	public enum TipoIva : int { General = 21, Reducido = 10, SuperReducido = 4 };

	public static class TipoIvaExtension {

		public static double Value(this TipoIva tipoIva) {
			return (int)tipoIva / (double)100;
		}

	}

}
