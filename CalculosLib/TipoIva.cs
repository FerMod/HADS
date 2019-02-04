
using System;

namespace CalculosLib.Iva {

	public enum TipoIva { General, Reducido, SuperReducido, Ninguno = -1 };

	public static class TipoIvaExtension {

		public static double GetValue(this TipoIva tipoIva) {
			switch(tipoIva) {
				case TipoIva.General:
					return 0.21;
				case TipoIva.Reducido:
					return 0.10;
				case TipoIva.SuperReducido:
					return 0.04;
				default:
					return 0.0;
			}
		}

		public static string GetName(this TipoIva tipoIva) {
			return Enum.GetName(typeof(TipoIva), tipoIva);
		}

	}

}
