using System;
using System.Collections.Generic;
using System.Linq;

namespace DataBaseAccess {

	public class DataAccess : IDataAccess {

		public Dictionary<long, Factura> Facturas { get; private set; } = new Dictionary<long, Factura>();

	}

}
