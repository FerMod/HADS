using System;
using System.Collections.Generic;
using System.Linq;

namespace DataBaseAccess {

	public class DataAccess {

		public Dictionary<long, Factura> ListaFacturas { get; private set; } = new Dictionary<long, Factura>();

	}

}
