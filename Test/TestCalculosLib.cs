using System.Collections;
using System.Collections.Generic;
using CalculosLib;
using CalculosLib.Iva;
using NUnit.Framework;

namespace Tests.CalculosLib {

	[TestFixture]
	public class TestCalculosIva {

		private static double Tolerance => 0.01d;

		private static IEnumerable<TestCaseData> PrecioBrutoTestData {
			get {
				yield return new TestCaseData(1000, TipoIva.General, 826.45);
				yield return new TestCaseData(1000, TipoIva.Reducido, 909.09);
				yield return new TestCaseData(1000, TipoIva.SuperReducido, 961.54);
				yield return new TestCaseData(1000, TipoIva.Ninguno, 1000.0);

				yield return new TestCaseData(0.0, TipoIva.General, 0.0);
				yield return new TestCaseData(0.0, TipoIva.Reducido, 0.0);
				yield return new TestCaseData(0.0, TipoIva.SuperReducido, 0.0);
				yield return new TestCaseData(0.0, TipoIva.Ninguno, 0.0);

				yield return new TestCaseData(-1000, TipoIva.General, -826.45);
				yield return new TestCaseData(-1000, TipoIva.Reducido, -909.09);
				yield return new TestCaseData(-1000, TipoIva.SuperReducido, -961.54);
				yield return new TestCaseData(-1000, TipoIva.Ninguno, -1000.0);
			}
		}

		private static IEnumerable<TestCaseData> PrecioIvaTestData {
			get {
				yield return new TestCaseData(1000, TipoIva.General, 173.55);
				yield return new TestCaseData(1000, TipoIva.Reducido, 90.91);
				yield return new TestCaseData(1000, TipoIva.SuperReducido, 38.46);
				yield return new TestCaseData(1000, TipoIva.Ninguno, 0.0);

				yield return new TestCaseData(0.0, TipoIva.General, 0.0);
				yield return new TestCaseData(0.0, TipoIva.Reducido, 0.0);
				yield return new TestCaseData(0.0, TipoIva.SuperReducido, 0.0);
				yield return new TestCaseData(0.0, TipoIva.Ninguno, 0.0);

				yield return new TestCaseData(-1000, TipoIva.General, -173.55);
				yield return new TestCaseData(-1000, TipoIva.Reducido, -90.91);
				yield return new TestCaseData(-1000, TipoIva.SuperReducido, -38.46);
				yield return new TestCaseData(-1000, TipoIva.Ninguno, -0.0);
			}
		}

		[Test, Description("Precio Bruto"), TestCaseSource(nameof(PrecioBrutoTestData))]
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

	[TestFixture]
	public class TestTipoIva {

		class TipoIvaDataClass {

			public static IEnumerable<TestCaseData> GetValueTestCases {
				get {
					yield return new TestCaseData(TipoIva.General).Returns(0.21);
					yield return new TestCaseData(TipoIva.Reducido).Returns(0.10);
					yield return new TestCaseData(TipoIva.SuperReducido).Returns(0.04);
					yield return new TestCaseData(TipoIva.Ninguno).Returns(0.0);
				}
			}

			public static IEnumerable<TestCaseData> GetNameTestCases {
				get {
					yield return new TestCaseData(TipoIva.General).Returns("General");
					yield return new TestCaseData(TipoIva.Reducido).Returns("Reducido");
					yield return new TestCaseData(TipoIva.SuperReducido).Returns("SuperReducido");
					yield return new TestCaseData(TipoIva.Ninguno).Returns("Ninguno");
				}
			}

		}

		[Test, Description("GetValue"), TestCaseSource(typeof(TipoIvaDataClass), "GetValueTestCases")]
		public double TestGetValue(TipoIva tipoIva) {
			return tipoIva.GetValue();
		}

		[Test, Description("GetName"), TestCaseSource(typeof(TipoIvaDataClass), "GetNameTestCases")]
		public string TestGetName(TipoIva tipoIva) {
			return tipoIva.GetName();
		}

	}

}
