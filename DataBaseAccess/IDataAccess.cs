﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseAccess {

	public interface IDataAccess {

		Dictionary<long, Factura> Facturas { get; }

	}

}
