using System;
using System.Globalization;
using System.Windows.Forms;
using CalculosDinero;
using CalculosDinero.Iva;

namespace CalculosClienteWindows {

	public partial class MainWindow : Form {

		private RegionInfo regionInfo;

		public MainWindow() {
			InitializeComponent();

			regionInfo = new RegionInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.LCID);

			lTotalSinIva.Text = $"0.00 {regionInfo.CurrencySymbol}";
			lIva.Text = $"0.00 {regionInfo.CurrencySymbol}";

		}

		#region Components Initialization

		protected void InitDropDownItems() {
			cbTipoIva.DataSource = Enum.GetValues(typeof(TipoIva));
		}

		#endregion

		#region Components Events

		private void Application_Load(object sender, EventArgs e) {
			InitDropDownItems();
		}

		private void BCalcular_Click(object sender, EventArgs e) {

			if(!string.IsNullOrWhiteSpace(mtbTotal.Text)) {

				bool isNumeric = double.TryParse(mtbTotal.Text, out double precioTotal);
				if(isNumeric) {

					Enum.TryParse(cbTipoIva.SelectedValue.ToString(), out TipoIva tipoIva);

					double precioBruto = Math.Round(CalculoIva.ObtenerPrecioBruto(precioTotal, tipoIva), 2);
					double precioIva = Math.Round(CalculoIva.ObtenerPrecioIva(precioTotal, tipoIva), 2);

					lTotalSinIva.Text = $"{precioBruto:0.00} {regionInfo.CurrencySymbol}";
					lIva.Text = $"{precioIva:0.00} {regionInfo.CurrencySymbol}";

				}

			}

		}

		#endregion
	}

}
