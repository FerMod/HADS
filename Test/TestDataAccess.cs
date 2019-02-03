using System.Collections.Generic;
using CalculosLib.Iva;
using DataBaseAccess;
using NUnit.Framework;

namespace Tests.DataBaseAccess {

	public class TestDataAccess {

		private IDataAccess dataAccess;

		private static IEnumerable<TestCaseData> FacturaTestData {
			get {
				yield return new TestCaseData(1, 1000, TipoIva.General);
				yield return new TestCaseData(2, 1000, TipoIva.Reducido);
				yield return new TestCaseData(3, 1000, TipoIva.SuperReducido);
				yield return new TestCaseData(4, 1000, TipoIva.Ninguno);

				yield return new TestCaseData(5, 0, TipoIva.General);
				yield return new TestCaseData(6, 0, TipoIva.Reducido);
				yield return new TestCaseData(7, 0, TipoIva.SuperReducido);
				yield return new TestCaseData(8, 0, TipoIva.Ninguno);

				yield return new TestCaseData(9, -1000, TipoIva.General);
				yield return new TestCaseData(10, -1000, TipoIva.Reducido);
				yield return new TestCaseData(11, -1000, TipoIva.SuperReducido);
				yield return new TestCaseData(12, -1000, TipoIva.Ninguno);
			}
		}

		[OneTimeSetUp]
		public void OneTimeSetUp() {
			dataAccess = new DataAccess();
		}

		[SetUp]
		public void SetUp() {
			dataAccess.Facturas.Clear();
		}

		[Test, Description("Add Factura"), TestCaseSource(nameof(FacturaTestData))]
		public void TestAddFactura(int id, double total, TipoIva tipoIva) {
			Factura factura = new Factura(id, total, tipoIva);
			Assert.That(dataAccess.Facturas.TryAdd(id, factura));
		}

		[Test, Description("Remove Factura"), TestCaseSource(nameof(FacturaTestData))]
		public void TestRemoveFactura(int id, double total, TipoIva tipoIva) {
			Factura factura = new Factura(id, total, tipoIva);
			Assume.That(dataAccess.Facturas.TryAdd(id, factura));
			Assert.That(dataAccess.Facturas.Remove(factura.Id));
		}

		[Test, Description("Get Factura"), TestCaseSource(nameof(FacturaTestData))]
		public void TestGetFactura(int id, double total, TipoIva tipoIva) {
			Factura expected = new Factura(id, total, tipoIva);
			Assume.That(dataAccess.Facturas.TryAdd(id, expected));
			Assert.That(dataAccess.Facturas.TryGetValue(id, out Factura factura));
			Assert.That(expected, Is.EqualTo(factura));
		}

	}

}