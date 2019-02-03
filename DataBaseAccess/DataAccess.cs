using System;
using System.Collections.Generic;
using System.Linq;

namespace DataBaseAccess {

	public sealed class DataAccess : IDataAccess {

		public static IDataAccess Instance { get; } = new DataAccess();

		// Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
		static DataAccess() {
		}

		private DataAccess() {
		}

		public Dictionary<long, Factura> Facturas { get; private set; } = new Dictionary<long, Factura>();

	}

}
