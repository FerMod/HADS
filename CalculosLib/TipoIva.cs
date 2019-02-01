
namespace CalculosDinero.Iva {

	/// <summary>
	/// Clase que simula el funcionamiento del tipo <code>enum</code>, sin embargo
	/// esta clase permite usar valores de tipo <code>double</code>.
	/// </summary>
	public class TipoIva {

		private TipoIva(double value, [System.Runtime.CompilerServices.CallerMemberName] string name = "") {
			Value = value;
			Name = name;
		}

		public double Value { get; private set; }
		public string Name { get; private set; }


		public static TipoIva General { get; } = new TipoIva(0.21);
		public static TipoIva Reducido { get; } = new TipoIva(0.10);
		public static TipoIva SuperReducido { get; } = new TipoIva(0.4);

		public override string ToString() { return  $"{Value}"; }

		public static bool operator ==(TipoIva a, TipoIva b) {

			// If both are null, or both are same instance, return true.
			if (object.ReferenceEquals(a, b)) {
				return true;
			}

			// If one is null, but not both, return false.
			if (((object)a == null) || ((object)b == null)) {
				return false;
			}

			// Return true if the fields match
			return (a.Name == b.Name) && (a.Value == b.Value);
		}

		public static bool operator !=(TipoIva a, TipoIva b) {
			return !(a == b);
		}

		public override bool Equals(object obj) {
			return Equals(obj as TipoIva);
		}

		public bool Equals(TipoIva other) {

			// If parameter is null, return false.
			if (other is null) {
				return false;
			}

			// Optimization for a common success case.
			if (object.ReferenceEquals(this, other)) {
				return true;
			}

			// If run-time types are not exactly the same, return false.
			if (this.GetType() != other.GetType()) {
				return false;
			}

			// Return true if the fields match.
			return (this.Name == other.Name) && (this.Value == other.Value);
		}

		public override int GetHashCode() {

			unchecked {

				int hash = 17;

				hash = hash * 23 + GetHashCode(Name);
				hash = hash * 23 + GetHashCode(Value);

				return hash;
			}

		}

		private int GetHashCode<T>(T t) {
			return t == null ? 0 : t.GetHashCode();
		}

	}

}
