using System;
using System.Collections.Generic;
using System.Text;
using CalculosLib;
using CalculosLib.Iva;

namespace DataBaseAccess {

	public class Factura {

		public long Id { get; private set; }
		public double Total { get; private set; }
		public TipoIva TipoIva { get; private set; }

		private Lazy<double> lazyPrecioBruto;
		public double PrecioBruto => lazyPrecioBruto.Value;

		private Lazy<double> lazyPrecioIva;
		public double PrecioIva => lazyPrecioIva.Value;

		public Factura(long id, double total, TipoIva tipoIva) {

			this.Id = id;
			this.Total = total;
			this.TipoIva = tipoIva;

			lazyPrecioBruto = new Lazy<double>(() => CalculoIva.ObtenerPrecioBruto(total, tipoIva));
			lazyPrecioIva = new Lazy<double>(() => CalculoIva.ObtenerPrecioIva(total, tipoIva));

		}

		public static bool operator ==(Factura a, Factura b) {

			// If both are null, or both are same instance, return true.
			if(object.ReferenceEquals(a, b)) {
				return true;
			}

			// If one is null, but not both, return false.
			if(((object)a == null) || ((object)b == null)) {
				return false;
			}

			// Return true if the fields match
			return (a.Id == b.Id)
				&& (a.Total == b.Total)
				&& (a.TipoIva == b.TipoIva);
		}

		public static bool operator !=(Factura a, Factura b) {
			return !(a == b);
		}

		public override bool Equals(object obj) {
			return Equals(obj as Factura);
		}

		public bool Equals(Factura other) {

			// If parameter is null, return false.
			if(other is null) {
				return false;
			}

			// Optimization for a common success case.
			if(object.ReferenceEquals(this, other)) {
				return true;
			}

			// If run-time types are not exactly the same, return false.
			if(this.GetType() != other.GetType()) {
				return false;
			}

			// Return true if the fields match.
			return (this.Id == other.Id)
				&& (this.Total == other.Total)
				&& (this.TipoIva == other.TipoIva);
		}

		public override int GetHashCode() {

			unchecked {

				int hash = 17;

				hash = hash * 23 + GetHashCode(Id);
				hash = hash * 23 + GetHashCode(Total);
				hash = hash * 23 + GetHashCode(TipoIva);

				return hash;
			}

		}

		private int GetHashCode<T>(T t) {
			return t == null ? 0 : t.GetHashCode();
		}

	}

}
