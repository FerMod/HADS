using System.Collections;
using System.Collections.Generic;
using CalculosLib;
using CalculosLib.Iva;
using NUnit.Framework;

namespace Tests {

	[TestFixture]
	public class TestCalculosLib {

		private static double Tolerance => 0.01d;

		private static IEnumerable<TestCaseData> PrecioBrutoTestData {
			get {
				yield return new TestCaseData(1000, TipoIva.General, 826.45);
				yield return new TestCaseData(1000, TipoIva.Reducido, 909.09);
				yield return new TestCaseData(1000, TipoIva.SuperReducido, 961.54);
				yield return new TestCaseData(1000, TipoIva.Ninguno, 1000.0);
			}
		}

		private static IEnumerable<TestCaseData> PrecioIvaTestData {
			get {
				yield return new TestCaseData(1000, TipoIva.General, 173.55);
				yield return new TestCaseData(1000, TipoIva.Reducido, 90.91);
				yield return new TestCaseData(1000, TipoIva.SuperReducido, 38.46);
				yield return new TestCaseData(1000, TipoIva.Ninguno, 0.0);
			}
		}

		[Test, Description("Precio sin IVA"), TestCaseSource(nameof(PrecioBrutoTestData))]
		public void TestPrecioBruto(double total, TipoIva tipoIva, double expected) {
			double value = CalculoIva.ObtenerPrecioBruto(total, tipoIva);
			Assert.That(expected, Is.EqualTo(value).Within(Tolerance));
		}

		[Test, Description("Precio IVA"), TestCaseSource(nameof(PrecioIvaTestData))]
		public void TestPrecioIva(double total, TipoIva tipoIva, double expected) {
			double value = CalculoIva.ObtenerPrecioIva(total, tipoIva);
			Assert.That(expected, Is.EqualTo(value).Within(Tolerance));
		}

	}

}
